// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.PackedFiles.Nmap;

namespace SimPe.Plugin.Tool.Action
{
	/// <summary>
	/// The BuildNameMap Action
	/// </summary>
	public class ActionBuildNameMap : Interfaces.IToolAction
	{
		#region IToolAction Member

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return true;
		}

		private bool RealChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return es.HasFileDescriptor && es.Loaded;
		}

		public void ExecuteEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			if (!RealChangeEnabledStateEventHandler(null, es))
			{
				System.Windows.Forms.MessageBox.Show(
					Localization.GetString(
						"This is not an appropriate context in which to use this tool"
					),
					Localization.GetString(ToString())
				);
				return;
			}

			Interfaces.Files.IPackedFileDescriptor pfd = null;
			for (int i = 0; i < es.Count; i++)
			{
				if (es[i].HasFileDescriptor)
				{
					pfd = es[i].Resource.FileDescriptor;
					break;
				}
			}

			if (Data.MetaData.RcolList.Contains(pfd.Type))
			{
				Packages.PackedFileDescriptor fd =
					new Packages.PackedFileDescriptor
					{
						Type = Data.FileTypes.NMAP,
						Group = 0x52737256,
						Instance = (uint)pfd.Type,
						SubType = 0
					};

				Nmap nmap = new Nmap(
					FileTableBase.ProviderRegistry
				)
				{
					FileDescriptor = fd
				};
				bool add = false;
				if (es.LoadedPackage.Package.FindFile(fd) == null)
				{
					add = true;
				}

				System.Collections.ArrayList list = new System.Collections.ArrayList();
				foreach (Events.ResourceContainer e in es)
				{
					if (!e.HasFileDescriptor)
					{
						continue;
					}

					if (e.Resource.FileDescriptor.Type != pfd.Type)
					{
						continue;
					}

					try
					{
						Packages.PackedFileDescriptor p =
							(Packages.PackedFileDescriptor)
								e.Resource.FileDescriptor;

						Rcol rcol = new GenericRcol(
							null,
							false
						);
						rcol.ProcessData(p, es.LoadedPackage.Package);

						p.Filename = rcol.FileName;
						list.Add(p);
					}
					catch (Exception) { }
				} //foreach
				nmap.Items.Clear();
				nmap.Items.AddRange((System.Collections.Generic.IEnumerable<Interfaces.Files.IPackedFileDescriptor>)list);
				nmap.SynchronizeUserData();
				if (add)
				{
					es.LoadedPackage.Package.Add(nmap.FileDescriptor);
				}
			}
		}

		#endregion


		#region IToolPlugin Member
		public override string ToString()
		{
			return "Build Namemap";
		}
		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => GetIcon.NameMap;

		public virtual bool Visible => true;

		#endregion
	}
}
