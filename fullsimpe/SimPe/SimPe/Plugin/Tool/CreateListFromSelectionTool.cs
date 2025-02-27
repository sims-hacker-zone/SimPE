/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;

using SimPe.Events;

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

		static Report f;

		public static void WriteHeader(
			System.IO.StreamWriter sw,
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Plugin.IFileWrapper wrapper
		)
		{
			sw.WriteLine(Serializer.SerializeTypeHeader(wrapper, pfd, true));
		}

		public static void WriteItem(
			System.IO.StreamWriter sw,
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Plugin.IFileWrapper wrapper
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
				Interfaces.Plugin.IFileWrapper wrapper =
					(Interfaces.Plugin.IFileWrapper)
						FileTable.WrapperRegistry.FindHandler(pfd.Type);
				if (wrapper != null)
				{
					wrapper.ProcessData(e.Resource);
				}

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

		public static void Execute(ResourceContainers es)
		{
			//Select the Type
			if (Helper.WindowsRegistry.ReportFormat == Registry.ReportFormats.CSV)
			{
				Serializer.Formater = new CsvSerializer();
			}

			System.Collections.Hashtable map = new System.Collections.Hashtable();

			foreach (ResourceContainer e in es)
			{
				uint t = e.Resource.FileDescriptor.Type;
				ResourceContainers o =
					map[t] as ResourceContainers;
				if (o == null)
				{
					o = new ResourceContainers();
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

			WaitingScreen.Wait();
			try
			{
				foreach (uint type in map.Keys)
				{
					ResourceContainers rc =
						map[type] as ResourceContainers;
					bool first = true;

					foreach (ResourceContainer e in rc)
					{
						error += ProcessItem(sw, e, first);
						WaitingScreen.UpdateMessage(
							(ct++).ToString() + " / " + max.ToString()
						);
						first = false;
					}
				}
				WaitingScreen.Stop();

				if (error != "")
				{
					throw new Warning("Not all Selected Files were processed.", error);
				}

				if (f == null)
				{
					f = new Report();
				}

				f.Execute(sw);
			}
#if !DEBUG
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
#endif
			finally
			{
				sw.Close();
				Serializer.ResetFormater();
				WaitingScreen.Stop();
			}
		}

		#region ITool Member

		public bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e)
		{
			return (e.Loaded && e.HasFileDescriptor);
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
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlD;

		public System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.selected.png")
				);

		public virtual bool Visible => true;

		#endregion
	}
}
