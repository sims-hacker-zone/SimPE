// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	internal class ToolStripButtonExt : ToolStripButton
	{
		private ToolStripItem item;

		private bool intern;

		internal ToolStripItem Item => item;

		internal ToolStripButtonExt(ToolStripItem item, ref int top)
		{
			intern = false;
			item.Overflow = ToolStripItemOverflow.Never;
			Text = item.Text;
			base.Name = "tsbe_" + item.Name;
			Image = item.Image;
			base.ImageScaling = item.ImageScaling;
			base.Overflow = ToolStripItemOverflow.Always;
			base.ImageAlign = ContentAlignment.MiddleLeft;
			this.item = item;
			SetBounds(new Rectangle(0, top, Bounds.Width, Bounds.Height));
			base.Visible = true;
			item.VisibleChanged += item_VisibleChanged;
			item.AvailableChanged += item_AvailableChanged;
			base.Alignment = ToolStripItemAlignment.Left;
			DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
			base.TextImageRelation = TextImageRelation.ImageBeforeText;
			top += Bounds.Height;
			UpdateChecked();
		}

		private void item_AvailableChanged(object sender, EventArgs e)
		{
			UpdateChecked();
		}

		protected override void OnCheckedChanged(EventArgs e)
		{
			base.OnCheckedChanged(e);
			if (!intern)
			{
				item.Available = base.Checked;
			}
		}

		private void item_VisibleChanged(object sender, EventArgs e)
		{
			UpdateChecked();
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			item.Available = !item.Available;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			UpdateChecked();
		}

		private void UpdateChecked()
		{
			intern = true;
			base.Checked = item.Available;
			intern = false;
		}
	}
}
