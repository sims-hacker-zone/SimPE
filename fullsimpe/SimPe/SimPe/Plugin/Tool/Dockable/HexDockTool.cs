// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Docakble Tool to view/change Resource specific Informations
	/// </summary>
	public class HexDockTool : Interfaces.IDockableTool
	{
		ResourceDock rd;

		public HexDockTool(ResourceDock rd)
		{
			this.rd = rd;
		}

		#region IDockableTool Member

		public Ambertation.Windows.Forms.DockPanel GetDockableControl()
		{
			return rd.dcHex;
		}

		public event Events.ChangedResourceEvent ShowNewResource;

		public void RefreshDock(object sender, Events.ResourceEventArgs es)
		{
			rd.button1.Enabled = false;
			if (!rd.dcHex.IsFloating && !rd.dcHex.IsDocked)
			{
				return;
			}

			if (es.HasFileDescriptor)
			{
				foreach (Events.ResourceContainer e in es)
				{
					if (e.HasFileDescriptor && e.HasPackage)
					{
						try
						{
							rd.hexpfd = e.Resource.FileDescriptor;
							Interfaces.Files.IPackedFile pf =
								e.Resource.Package.Read(e.Resource.FileDescriptor);
							rd.hvc.Data = pf.UncompressedData;
							rd.button1.Enabled = true;
							return;
						}
						catch { }
					}
				}
			}

			rd.hvc.Data = null;
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
