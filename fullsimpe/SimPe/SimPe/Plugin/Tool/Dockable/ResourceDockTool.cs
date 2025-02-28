// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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

			rd.cbComp.Enabled = es.Count > 0;
			rd.lbComp.Enabled = es.Count > 0;

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
