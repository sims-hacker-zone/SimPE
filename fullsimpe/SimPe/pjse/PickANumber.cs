/***************************************************************************
 *   Copyright (C) 2007 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace pjse
{
	public partial class PickANumber : Form
	{
		public PickANumber()
		{
			InitializeComponent();
		}

		private List<TextBox> ltb = new List<TextBox>();
		private List<RadioButton> lrb = new List<RadioButton>();
		private List<pjse.BhavOperandWizards.DataOwnerControl> ldoc =
			new List<pjse.BhavOperandWizards.DataOwnerControl>();
		private int selectedRB = -1;

		public PickANumber(ushort[] values, string[] labels)
			: this()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(PickANumber));
			this.tableLayoutPanel1.Controls.Clear();
			this.tableLayoutPanel1.ColumnStyles.Clear();
			this.tableLayoutPanel1.RowStyles.Clear();
			this.tableLayoutPanel1.RowCount = 0;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

			this.tableLayoutPanel1.RowCount++;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);

			for (int i = 0; i < values.Length; i++)
			{
				this.tableLayoutPanel1.RowCount++;
				this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

				TextBox t = new TextBox();
				t.Name = "textBox" + (i + 2).ToString();
				resources.ApplyResources(t, "textBox1");
				ltb.Add(t);
				t.Enabled = false;
				pjse.BhavOperandWizards.DataOwnerControl d =
					new pjse.BhavOperandWizards.DataOwnerControl(
						null,
						null,
						null,
						t,
						null,
						null,
						null,
						0x07,
						values[i]
					);
				ldoc.Add(d);
				this.tableLayoutPanel1.Controls.Add(
					t,
					1,
					tableLayoutPanel1.RowCount - 1
				);

				RadioButton r = new RadioButton();
				resources.ApplyResources(r, "radioButton1");
				r.Text = labels[i];
				r.Checked = false;
				r.CheckedChanged += new System.EventHandler(
					this.radioButton1_CheckedChanged
				);
				r.TextAlign = ContentAlignment.MiddleRight;
				lrb.Add(r);
				this.tableLayoutPanel1.Controls.Add(
					r,
					0,
					tableLayoutPanel1.RowCount - 1
				);
			}

			ltb[ltb.Count - 1].Enabled = true;
			ltb[ltb.Count - 1].Enter += new System.EventHandler(this.ltbLast_Enter);
			lrb[0].Checked = true;

			this.tableLayoutPanel1.RowCount++;
			int last = this.tableLayoutPanel1.RowStyles.Add(
				new RowStyle(SizeType.Absolute, (float)(btnOK.Height * 1.5))
			);
			this.tableLayoutPanel1.Controls.Add(btnOK, 0, last);
			this.tableLayoutPanel1.Controls.Add(btnCancel, 1, last);
			this.AcceptButton = btnOK;
			this.CancelButton = btnCancel;
		}

		public uint Value => (selectedRB >= 0) ? ldoc[selectedRB].Value : (ushort)0xffff;

		public String Title
		{
			get
			{
				return this.Text;
			}
			set
			{
				this.Text = value;
			}
		}

		public String Prompt
		{
			get
			{
				return this.label1.Text;
			}
			set
			{
				this.label1.Text = value;
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			selectedRB = lrb.IndexOf((RadioButton)sender);
		}

		private void ltbLast_Enter(object sender, EventArgs e)
		{
			lrb[ltb.Count - 1].Checked = true;
		}
	}
}
