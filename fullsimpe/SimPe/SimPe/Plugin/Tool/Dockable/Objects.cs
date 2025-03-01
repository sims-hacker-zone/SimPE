// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Tghe Object Workshop as new Dockable Tool
	/// </summary>
	public class ObectWorkshopDockTool : Interfaces.IDockableTool
	{
		dcObjectWorkshop dc;

		public ObectWorkshopDockTool()
		{
			dc = new dcObjectWorkshop();
		}

		#region IDockableTool Member

		public Ambertation.Windows.Forms.DockPanel GetDockableControl()
		{
			return dc;
		}

		public event Events.ChangedResourceEvent ShowNewResource;

		public void RefreshDock(object sender, Events.ResourceEventArgs es)
		{
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return dc.Text;
		}

		#endregion

		#region IToolExt Member

		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => dc.TabImage;

		public virtual bool Visible => GetDockableControl().IsDocked || GetDockableControl().IsFloating;

		#endregion
	}
}
