// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	[ToolboxItem(false)]
	public class RubberBandHelper : Control
	{
		private DockContainer dc;

		private Dictionary<Control, bool> map;

		private DockStyle dock;

		public DockStyle ContainerDock => dock;

		internal RubberBandHelper(DockContainer dc)
		{
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			this.dc = dc;
			map = new Dictionary<Control, bool>();
			foreach (Control control in dc.Controls)
			{
				map[control] = control.Visible;
				control.Visible = false;
			}

			Dock = DockStyle.Fill;
			dock = dc.Dock;
			dc.Controls.Add(this);
		}

		internal void Close()
		{
			dc.Controls.Remove(this);
			foreach (Control key in map.Keys)
			{
				if (key is DockPanel)
				{
					((DockPanel)key).NCRefresh();
				}

				key.Visible = map[key];
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			dc.Manager.Renderer.DockPanelRenderer.RenderResizePanel(dc, this, e);
		}
	}
}
