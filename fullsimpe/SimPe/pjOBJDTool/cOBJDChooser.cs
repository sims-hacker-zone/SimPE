// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace pjOBJDTool
{
	public partial class cOBJDChooser : Form
	{
		public pfOBJD Value { get; private set; } = null;
		List<pfOBJD> items = null;

		public cOBJDChooser()
		{
			InitializeComponent();
		}

		public DialogResult Execute(List<pfOBJD> items)
		{
			this.items = items;
			Value = null;

			lbItems.Items.Clear();
			foreach (pfOBJD item in items)
			{
				lbItems.Items.Add((IsLead(item) ? "* " : "   ") + item.Filename);
				if (IsLead(item))
				{
					lbItems.SelectedIndex = lbItems.Items.Count - 1;
				}
			}

			return ShowDialog();
		}

		bool IsLead(pfOBJD item)
		{
			return item[0x0a] == 0 || (item[0x0a] > 0 && (short)item[0x0b] < 0);
		}

		private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbItems.SelectedIndex >= 0)
			{
				Value = items[lbItems.SelectedIndex];
			}
		}

		private void lbItems_DoubleClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
