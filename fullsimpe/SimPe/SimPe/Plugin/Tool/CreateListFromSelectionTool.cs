// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;

using SimPe.Data;
using SimPe.Events;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Zusammenfassung für ImportSemiTool.
	/// </summary>
	public class CreateListFromSelectionTool : Interfaces.IToolPlus
	{
		internal CreateListFromSelectionTool()
		{
		}

		public static void WriteHeader(
			System.IO.StreamWriter sw,
			Interfaces.Files.IPackedFileDescriptor pfd,
			IFileWrapper wrapper
		)
		{
			sw.WriteLine(Serializer.SerializeTypeHeader(wrapper, pfd, true));
		}

		public static void WriteItem(
			System.IO.StreamWriter sw,
			Interfaces.Files.IPackedFileDescriptor pfd,
			IFileWrapper wrapper
		)
		{
			sw.WriteLine(Serializer.Serialize(wrapper, pfd, true));
		}

		public static string ProcessItem(
			System.IO.StreamWriter sw,
			ResourceContainer e,
			bool first
		)
		{
			string error = "";
			if (!e.HasFileDescriptor)
			{
				return "";
			}

			if (!e.HasPackage)
			{
				return "";
			}

			try
			{
				Interfaces.Files.IPackedFileDescriptor pfd = e.Resource.FileDescriptor;
				IFileWrapper wrapper =
					(IFileWrapper)
						FileTableBase.WrapperRegistry.FindHandler(pfd.Type)?.ProcessFile(e.Resource);

				if (first)
				{
					WriteHeader(sw, pfd, wrapper);
				}

				WriteItem(sw, pfd, wrapper);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
				error += ex.Message + Helper.lbr;
			}

			return error;
		}

		public static void Execute(List<ResourceContainer> es)
		{
			//Select the Type
			if (Helper.WindowsRegistry.Config.ReportFormat == Registry.ReportFormats.CSV)
			{
				Serializer.Formater = new CsvSerializer();
			}

			System.Collections.Hashtable map = new System.Collections.Hashtable();

			foreach (ResourceContainer e in es)
			{
				FileTypes t = e.Resource.FileDescriptor.Type;
				if (!(map[t] is List<ResourceContainer> o))
				{
					o = new List<ResourceContainer>();
					map[t] = o;
				}

				o.Add(e);
			}

			System.IO.StreamWriter sw = new System.IO.StreamWriter(
				new System.IO.MemoryStream()
			);
			string error = "";
			int ct = 0;
			string max = "/ " + es.Count.ToString();

			try
			{
				foreach (uint type in map.Keys)
				{
					List<ResourceContainer> rc =
						map[type] as List<ResourceContainer>;
					bool first = true;

					foreach (ResourceContainer e in rc)
					{
						error += ProcessItem(sw, e, first);
						first = false;
					}
				}

				if (error != "")
				{
					throw new Warning("Not all Selected Files were processed.", error);
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
			finally
			{
				sw.Close();
				Serializer.ResetFormater();
			}
		}

		#region ITool Member

		public bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e)
		{
			return e.Loaded && e.HasFileDescriptor;
		}

		public void Execute(object sender, ResourceEventArgs es)
		{
			if (!ChangeEnabledStateEventHandler(sender, es))
			{
				return;
			}

			Execute(es.Items);
		}

		public override string ToString()
		{
			return "Create Description\\from Selection...";
		}

		#endregion

		#region IToolExt Member

		public System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.selected.png")
				);

		public virtual bool Visible => true;

		#endregion
	}
}
