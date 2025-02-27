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
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for RoadTextureControl.
	/// </summary>
	public class RoadTextureControl
		:
		//System.Windows.Forms.UserControl
		Windows.Forms.WrapperBaseControl
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListBox lb;
		private System.Windows.Forms.Label label5;
		private Ambertation.Windows.Forms.XPTaskBoxSimple xpTaskBoxSimple1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbFlname;
		private System.Windows.Forms.TextBox tbUk1;
		private System.Windows.Forms.TextBox tbUk2;
		private System.Windows.Forms.TextBox tbUk3;
		private System.Windows.Forms.TextBox tbId;
		private System.Windows.Forms.TextBox tbTxmt;
		private System.Windows.Forms.Label label7;
		private Ambertation.Windows.Forms.EnumComboBox cbType;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RoadTextureControl()
			: base()
		{
			// Required designer variable.
			InitializeComponent();

			cbType.Enum = typeof(RoadTexture.RoadTextureType);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			lb = new System.Windows.Forms.ListBox();
			tbFlname = new System.Windows.Forms.TextBox();
			tbUk1 = new System.Windows.Forms.TextBox();
			tbUk2 = new System.Windows.Forms.TextBox();
			tbUk3 = new System.Windows.Forms.TextBox();
			tbId = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			xpTaskBoxSimple1 = new Ambertation.Windows.Forms.XPTaskBoxSimple();
			tbTxmt = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			cbType = new Ambertation.Windows.Forms.EnumComboBox();
			xpTaskBoxSimple1.SuspendLayout();
			SuspendLayout();
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(8, 64);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(100, 23);
			label1.TabIndex = 0;
			label1.Text = "Resource ID:";
			label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label2
			//
			label2.Anchor =

					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)

			;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(368, 64);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(72, 23);
			label2.TabIndex = 1;
			label2.Text = "Unknown2:";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label3
			//
			label3.Anchor =

					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)

			;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(528, 64);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(72, 23);
			label3.TabIndex = 2;
			label3.Text = "Unknown3:";
			label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label4
			//
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(8, 32);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(100, 23);
			label4.TabIndex = 3;
			label4.Text = "Resourcename:";
			label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// lb
			//
			lb.Anchor =

					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)

			;
			lb.HorizontalScrollbar = true;
			lb.IntegralHeight = false;
			lb.Location = new System.Drawing.Point(8, 96);
			lb.Name = "lb";
			lb.Size = new System.Drawing.Size(376, 192);
			lb.TabIndex = 4;
			lb.SelectedIndexChanged += new System.EventHandler(
				lb_SelectedIndexChanged
			);
			//
			// tbFlname
			//
			tbFlname.Anchor =

					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)

			;
			tbFlname.Location = new System.Drawing.Point(120, 32);
			tbFlname.Name = "tbFlname";
			tbFlname.Size = new System.Drawing.Size(560, 21);
			tbFlname.TabIndex = 5;
			tbFlname.Text = "textBox1";
			//
			// tbUk1
			//
			tbUk1.Location = new System.Drawing.Point(120, 64);
			tbUk1.Name = "tbUk1";
			tbUk1.ReadOnly = true;
			tbUk1.Size = new System.Drawing.Size(72, 21);
			tbUk1.TabIndex = 6;
			tbUk1.Text = "0x00000000";
			//
			// tbUk2
			//
			tbUk2.Anchor =

					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)

			;
			tbUk2.Location = new System.Drawing.Point(448, 64);
			tbUk2.Name = "tbUk2";
			tbUk2.Size = new System.Drawing.Size(72, 21);
			tbUk2.TabIndex = 7;
			tbUk2.Text = "0x00000000";
			//
			// tbUk3
			//
			tbUk3.Anchor =

					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)

			;
			tbUk3.Location = new System.Drawing.Point(608, 64);
			tbUk3.Name = "tbUk3";
			tbUk3.Size = new System.Drawing.Size(72, 21);
			tbUk3.TabIndex = 8;
			tbUk3.Text = "0x00000000";
			//
			// tbId
			//
			tbId.Location = new System.Drawing.Point(64, 48);
			tbId.Name = "tbId";
			tbId.Size = new System.Drawing.Size(192, 21);
			tbId.TabIndex = 10;
			//
			// label5
			//
			label5.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(8, 48);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(48, 23);
			label5.TabIndex = 9;
			label5.Text = "ID:";
			label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// xpTaskBoxSimple1
			//
			xpTaskBoxSimple1.Anchor =

					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)

			;
			xpTaskBoxSimple1.BackColor = System.Drawing.Color.Transparent;
			xpTaskBoxSimple1.Controls.Add(tbTxmt);
			xpTaskBoxSimple1.Controls.Add(label6);
			xpTaskBoxSimple1.Controls.Add(tbId);
			xpTaskBoxSimple1.Controls.Add(label5);
			xpTaskBoxSimple1.HeaderFont = new System.Drawing.Font(
				"Microsoft Sans Serif",
				10.25F,
				System.Drawing.FontStyle.Bold
			);
			xpTaskBoxSimple1.HeaderText = "Properties";
			xpTaskBoxSimple1.IconLocation = new System.Drawing.Point(4, 12);
			xpTaskBoxSimple1.IconSize = new System.Drawing.Size(32, 32);
			xpTaskBoxSimple1.Location = new System.Drawing.Point(392, 88);
			xpTaskBoxSimple1.Name = "xpTaskBoxSimple1";
			xpTaskBoxSimple1.Padding = new System.Windows.Forms.Padding(
				4,
				44,
				4,
				4
			);
			xpTaskBoxSimple1.Size = new System.Drawing.Size(288, 100);
			xpTaskBoxSimple1.TabIndex = 11;
			//
			// tbTxmt
			//
			tbTxmt.Location = new System.Drawing.Point(64, 72);
			tbTxmt.Name = "tbTxmt";
			tbTxmt.Size = new System.Drawing.Size(192, 21);
			tbTxmt.TabIndex = 12;
			//
			// label6
			//
			label6.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label6.Location = new System.Drawing.Point(8, 72);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(48, 23);
			label6.TabIndex = 11;
			label6.Text = "Name:";
			label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label7
			//
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label7.Location = new System.Drawing.Point(200, 64);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(40, 23);
			label7.TabIndex = 12;
			label7.Text = "Type:";
			label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// cbType
			//
			cbType.Enabled = false;
			cbType.Enum = null;
			cbType.Location = new System.Drawing.Point(240, 64);
			cbType.Name = "cbType";
			cbType.ResourceManager = null;
			cbType.Size = new System.Drawing.Size(120, 21);
			cbType.TabIndex = 13;
			cbType.Text = "enumComboBox1";
			//
			// RoadTextureControl
			//
			CanCommit = false;
			Controls.Add(cbType);
			Controls.Add(label7);
			Controls.Add(xpTaskBoxSimple1);
			Controls.Add(tbUk3);
			Controls.Add(tbUk2);
			Controls.Add(tbUk1);
			Controls.Add(tbFlname);
			Controls.Add(lb);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Font = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			HeaderText = "Road Texture";
			Name = "RoadTextureControl";
			Size = new System.Drawing.Size(688, 296);
			Controls.SetChildIndex(label1, 0);
			Controls.SetChildIndex(label2, 0);
			Controls.SetChildIndex(label3, 0);
			Controls.SetChildIndex(label4, 0);
			Controls.SetChildIndex(lb, 0);
			Controls.SetChildIndex(tbFlname, 0);
			Controls.SetChildIndex(tbUk1, 0);
			Controls.SetChildIndex(tbUk2, 0);
			Controls.SetChildIndex(tbUk3, 0);
			Controls.SetChildIndex(xpTaskBoxSimple1, 0);
			Controls.SetChildIndex(label7, 0);
			Controls.SetChildIndex(cbType, 0);
			xpTaskBoxSimple1.ResumeLayout(false);
			xpTaskBoxSimple1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		#region IPackedFileUI Member

		public RoadTexture RoadTextureWrapper => (RoadTexture)Wrapper;

		protected override void RefreshGUI()
		{
			base.RefreshGUI();

			tbId.Text = "";
			tbTxmt.Text = "";

			tbFlname.Text = RoadTextureWrapper.FileName;
			tbUk1.Text = "0x" + Helper.HexString(RoadTextureWrapper.Id);
			tbUk2.Text = "0x" + Helper.HexString(RoadTextureWrapper.Unknown2);
			tbUk3.Text = "0x" + Helper.HexString(RoadTextureWrapper.Unknown3);

			cbType.SelectedValue = RoadTextureWrapper.Type;

			lb.Items.Clear();
			foreach (object o in RoadTextureWrapper)
			{
				lb.Items.Add(o);
			}

			if (lb.Items.Count > 0)
			{
				lb.SelectedIndex = 0;
			}
		}

		#endregion

		private void lb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lb.SelectedIndex < 0)
			{
				return;
			}

			if (RoadTextureWrapper == null)
			{
				return;
			}

			if (lb.SelectedItem is uint)
			{
				tbId.Text = "0x" + Helper.HexString((uint)lb.SelectedItem);
				tbTxmt.Text =
					"0x" + Helper.HexString((uint)RoadTextureWrapper[lb.SelectedItem]);
			}
			else
			{
				tbId.Text = lb.SelectedItem.ToString();
				tbTxmt.Text = RoadTextureWrapper[lb.SelectedItem].ToString();
			}
		}
	}
}
