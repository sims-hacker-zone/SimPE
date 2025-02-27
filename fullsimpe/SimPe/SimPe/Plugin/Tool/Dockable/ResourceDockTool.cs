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
using Ambertation.Windows.Forms;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Docakble Tool to view/change Resource specific Informations
	/// </summary>
	public class ResourceDockTool : Interfaces.IDockableTool
	{
		ResourceDock rd;

		public ResourceDockTool(ResourceDock rd)
		{
			this.rd = rd;
		}

		#region IDockableTool Member

		public DockPanel GetDockableControl()
		{
			return rd.dcResource;
		}

		public event Events.ChangedResourceEvent ShowNewResource;

		public void RefreshDock(object sender, Events.ResourceEventArgs es)
		{
			rd.items = null;
			bool check = false;
			if (!es.Empty)
			{
				if (es[0].HasFileDescriptor)
				{
					check = true;
					rd.tbtype.Text =
						"0x" + Helper.HexString(es[0].Resource.FileDescriptor.Type);
					rd.tbgroup.Text =
						"0x" + Helper.HexString(es[0].Resource.FileDescriptor.Group);
					rd.tbinstance.Text =
						"0x" + Helper.HexString(es[0].Resource.FileDescriptor.Instance);
					rd.tbinstance2.Text =
						"0x" + Helper.HexString(es[0].Resource.FileDescriptor.SubType);
				}
			}

			rd.pntypes.Enabled = check;

			//Set Compression State
			int tct = 0;
			foreach (Events.ResourceContainer e in es)
			{
				if (!e.HasFileDescriptor)
				{
					continue;
				}

				if (
					e.Resource.FileDescriptor.MarkForReCompress
					|| (
						e.Resource.FileDescriptor.WasCompressed
						&& !e.Resource.FileDescriptor.HasUserdata
					)
				)
				{
					tct++;
				}
			}

			rd.cbComp.SelectedIndex = tct == 0 ? 0 : tct == es.Count ? 1 : 2;

			rd.cbComp.Enabled = (es.Count > 0);
			rd.lbComp.Enabled = (es.Count > 0);

			rd.items = es;
			rd.guipackage = es.LoadedPackage;

			if (es.Loaded)
			{
				if (!es.LoadedPackage.Package.LoadedCompressedState)
				{
					rd.cbComp.Enabled = false;
				}
			}
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return rd.dcResource.Text;
		}

		#endregion

		#region IToolExt Member

		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => rd.dcResource.TabImage;

		public virtual bool Visible => GetDockableControl().IsDocked || GetDockableControl().IsFloating;

		#endregion
	}
}
