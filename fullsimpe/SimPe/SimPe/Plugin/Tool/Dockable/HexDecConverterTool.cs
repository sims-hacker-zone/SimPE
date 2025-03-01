// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Hex to Decimal Converter Dialog
	/// </summary>
	public class HexDecConverterTool : Interfaces.IDockableTool
	{
		ResourceDock rd;

		public HexDecConverterTool(ResourceDock rd)
		{
			this.rd = rd;
		}

		#region IDockableTool Member

		public Ambertation.Windows.Forms.DockPanel GetDockableControl()
		{
			return rd.dcConvert;
		}

		public event Events.ChangedResourceEvent ShowNewResource;

		public void RefreshDock(object sender, Events.ResourceEventArgs es)
		{
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return rd.dcConvert.Text;
		}

		#endregion

		#region IToolExt Member

		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlH;

		public System.Drawing.Image Icon => rd.dcConvert.TabImage;

		public virtual bool Visible => GetDockableControl().IsDocked || GetDockableControl().IsFloating;
		#endregion
	}
}
