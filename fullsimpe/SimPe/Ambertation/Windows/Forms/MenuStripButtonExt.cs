// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{

	internal class MenuStripButtonExt : ToolStripButton
	{
		private ToolStrip item;

		internal MenuStripButtonExt(ToolStrip item)
		{
			Text = item.Text;
			base.Name = "msbe_" + item.Name;
			if (Text == "")
			{
				Text = item.Name;
			}

			Text += " ";
			this.item = item;
			base.Visible = true;
			base.Available = true;
			item.VisibleChanged += item_VisibleChanged;
			UpdateChecked();
		}

		private void item_VisibleChanged(object sender, EventArgs e)
		{
			UpdateChecked();
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			item.Visible = !item.Visible;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			UpdateChecked();
		}

		private void UpdateChecked()
		{
			base.Checked = item.Visible;
		}
	}
}
