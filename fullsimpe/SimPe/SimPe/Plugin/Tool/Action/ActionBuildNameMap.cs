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

			Data.TypeAlias a = Helper.TGILoader.GetByType(pfd.Type);
			if (Data.MetaData.RcolList.Contains(a.Id))
			{
				Packages.PackedFileDescriptor fd =
					new Packages.PackedFileDescriptor();
				fd.Type = Data.MetaData.NAME_MAP;
				fd.Group = 0x52737256;
				fd.Instance = a.Id;
				fd.SubType = 0;

				Nmap nmap = new Nmap(
					FileTableBase.ProviderRegistry
				);
				nmap.FileDescriptor = fd;
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

					if (e.Resource.FileDescriptor.Type != a.Id)
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

				nmap.Items = new Packages.PackedFileDescriptor[list.Count];
				list.CopyTo(nmap.Items);

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
