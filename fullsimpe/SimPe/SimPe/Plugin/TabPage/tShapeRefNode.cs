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
using System;
using System.Windows.Forms;

namespace SimPe.Plugin.TabPage
{
	/// <summary>
	/// Summary description for fShapeRefNode.
	/// </summary>
	public class ShapeRefNode
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		internal ListBox lb_srn_b;
		internal ListBox lb_srn_a;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private LinkLabel ll_srn_dela;
		private LinkLabel ll_srn_delb;
		private LinkLabel linkLabel3;
		private LinkLabel linkLabel4;
		private GroupBox groupBox3;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label11;
		private Label label12;
		internal TextBox tb_srn_uk2;
		internal TextBox tb_srn_uk1;
		internal TextBox tb_srn_uk4;
		internal TextBox tb_srn_uk3;
		internal TextBox tb_srn_uk6;
		internal TextBox tb_srn_uk5;
		internal TextBox tb_srn_kind;
		internal TextBox tb_srn_data;
		private TextBox tb_srn_b_name;
		private TextBox tb_srn_b_1;
		private TextBox tb_srn_a_2;
		private TextBox tb_srn_a_1;
		internal TextBox tb_srn_ver;
		private Label label24;
		private System.ComponentModel.IContainer components;

		public ShapeRefNode()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			//
			// Required designer variable.
			//
			InitializeComponent();

			UseVisualStyleBackColor = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Tag = null;
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
			components = new System.ComponentModel.Container();
			groupBox3 = new GroupBox();
			tb_srn_ver = new TextBox();
			label24 = new Label();
			tb_srn_data = new TextBox();
			label12 = new Label();
			tb_srn_kind = new TextBox();
			label11 = new Label();
			tb_srn_uk6 = new TextBox();
			label9 = new Label();
			tb_srn_uk5 = new TextBox();
			label10 = new Label();
			tb_srn_uk4 = new TextBox();
			label7 = new Label();
			tb_srn_uk3 = new TextBox();
			label8 = new Label();
			tb_srn_uk2 = new TextBox();
			label5 = new Label();
			tb_srn_uk1 = new TextBox();
			label6 = new Label();
			groupBox2 = new GroupBox();
			linkLabel4 = new LinkLabel();
			tb_srn_b_name = new TextBox();
			label4 = new Label();
			tb_srn_b_1 = new TextBox();
			label3 = new Label();
			lb_srn_b = new ListBox();
			ll_srn_delb = new LinkLabel();
			groupBox1 = new GroupBox();
			linkLabel3 = new LinkLabel();
			tb_srn_a_2 = new TextBox();
			label2 = new Label();
			tb_srn_a_1 = new TextBox();
			label1 = new Label();
			lb_srn_a = new ListBox();
			ll_srn_dela = new LinkLabel();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			//
			// tShapeRefNode
			//
			BackColor = System.Drawing.Color.White;
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Location = new System.Drawing.Point(4, 22);
			Name = "tShapeRefNode";
			Size = new System.Drawing.Size(792, 262);
			TabIndex = 0;
			Text = "ShapeRefNode";
			//
			// groupBox3
			//
			groupBox3.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			groupBox3.Controls.Add(tb_srn_ver);
			groupBox3.Controls.Add(label24);
			groupBox3.Controls.Add(tb_srn_data);
			groupBox3.Controls.Add(label12);
			groupBox3.Controls.Add(tb_srn_kind);
			groupBox3.Controls.Add(label11);
			groupBox3.Controls.Add(tb_srn_uk6);
			groupBox3.Controls.Add(label9);
			groupBox3.Controls.Add(tb_srn_uk5);
			groupBox3.Controls.Add(label10);
			groupBox3.Controls.Add(tb_srn_uk4);
			groupBox3.Controls.Add(label7);
			groupBox3.Controls.Add(tb_srn_uk3);
			groupBox3.Controls.Add(label8);
			groupBox3.Controls.Add(tb_srn_uk2);
			groupBox3.Controls.Add(label5);
			groupBox3.Controls.Add(tb_srn_uk1);
			groupBox3.Controls.Add(label6);
			groupBox3.FlatStyle = FlatStyle.System;
			groupBox3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox3.Location = new System.Drawing.Point(8, 8);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(344, 248);
			groupBox3.TabIndex = 6;
			groupBox3.TabStop = false;
			groupBox3.Text = "Settings";
			//
			// tb_srn_ver
			//
			tb_srn_ver.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_ver.Location = new System.Drawing.Point(16, 32);
			tb_srn_ver.Name = "tb_srn_ver";
			tb_srn_ver.Size = new System.Drawing.Size(88, 21);
			tb_srn_ver.TabIndex = 22;
			tb_srn_ver.Text = "0x00000000";
			tb_srn_ver.TextChanged += new EventHandler(
				SRNChangeSettings
			);
			//
			// label24
			//
			label24.AutoSize = true;
			label24.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label24.Location = new System.Drawing.Point(8, 16);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(52, 17);
			label24.TabIndex = 21;
			label24.Text = "Version:";
			//
			// tb_srn_data
			//
			tb_srn_data.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tb_srn_data.Font = new System.Drawing.Font(
				"Courier New",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_data.Location = new System.Drawing.Point(16, 192);
			tb_srn_data.Multiline = true;
			tb_srn_data.Name = "tb_srn_data";
			tb_srn_data.Size = new System.Drawing.Size(312, 48);
			tb_srn_data.TabIndex = 20;
			tb_srn_data.Text = "";
			tb_srn_data.TextChanged += new EventHandler(
				SRNChangeSettings
			);
			//
			// label12
			//
			label12.AccessibleDescription = "d";
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label12.Location = new System.Drawing.Point(8, 176);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(36, 17);
			label12.TabIndex = 19;
			label12.Text = "Data:";
			//
			// tb_srn_kind
			//
			tb_srn_kind.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tb_srn_kind.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_kind.Location = new System.Drawing.Point(16, 152);
			tb_srn_kind.Name = "tb_srn_kind";
			tb_srn_kind.Size = new System.Drawing.Size(312, 21);
			tb_srn_kind.TabIndex = 18;
			tb_srn_kind.Text = "0x0000";
			tb_srn_kind.TextChanged += new EventHandler(
				SRNChangeSettings
			);
			//
			// label11
			//
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label11.Location = new System.Drawing.Point(8, 136);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(35, 17);
			label11.TabIndex = 17;
			label11.Text = "Kind:";
			//
			// tb_srn_uk6
			//
			tb_srn_uk6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_uk6.Location = new System.Drawing.Point(240, 112);
			tb_srn_uk6.Name = "tb_srn_uk6";
			tb_srn_uk6.Size = new System.Drawing.Size(88, 21);
			tb_srn_uk6.TabIndex = 16;
			tb_srn_uk6.Text = "0x00000000";
			tb_srn_uk6.TextChanged += new EventHandler(
				SRNChangeSettings
			);
			//
			// label9
			//
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label9.Location = new System.Drawing.Point(232, 96);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(73, 17);
			label9.TabIndex = 15;
			label9.Text = "Unknown 6:";
			//
			// tb_srn_uk5
			//
			tb_srn_uk5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_uk5.Location = new System.Drawing.Point(240, 72);
			tb_srn_uk5.Name = "tb_srn_uk5";
			tb_srn_uk5.Size = new System.Drawing.Size(88, 21);
			tb_srn_uk5.TabIndex = 14;
			tb_srn_uk5.Text = "0x00000000";
			tb_srn_uk5.TextChanged += new EventHandler(
				SRNChangeSettings
			);
			//
			// label10
			//
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label10.Location = new System.Drawing.Point(232, 56);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(73, 17);
			label10.TabIndex = 13;
			label10.Text = "Unknown 5:";
			//
			// tb_srn_uk4
			//
			tb_srn_uk4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_uk4.Location = new System.Drawing.Point(128, 112);
			tb_srn_uk4.Name = "tb_srn_uk4";
			tb_srn_uk4.Size = new System.Drawing.Size(88, 21);
			tb_srn_uk4.TabIndex = 12;
			tb_srn_uk4.Text = "0x00";
			tb_srn_uk4.TextChanged += new EventHandler(
				SRNChangeSettings
			);
			//
			// label7
			//
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label7.Location = new System.Drawing.Point(120, 96);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(73, 17);
			label7.TabIndex = 11;
			label7.Text = "Unknown 4:";
			//
			// tb_srn_uk3
			//
			tb_srn_uk3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_uk3.Location = new System.Drawing.Point(128, 72);
			tb_srn_uk3.Name = "tb_srn_uk3";
			tb_srn_uk3.Size = new System.Drawing.Size(88, 21);
			tb_srn_uk3.TabIndex = 10;
			tb_srn_uk3.Text = "0x00000000";
			tb_srn_uk3.TextChanged += new EventHandler(
				SRNChangeSettings
			);
			//
			// label8
			//
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label8.Location = new System.Drawing.Point(120, 56);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(73, 17);
			label8.TabIndex = 9;
			label8.Text = "Unknown 3:";
			//
			// tb_srn_uk2
			//
			tb_srn_uk2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_uk2.Location = new System.Drawing.Point(16, 112);
			tb_srn_uk2.Name = "tb_srn_uk2";
			tb_srn_uk2.Size = new System.Drawing.Size(88, 21);
			tb_srn_uk2.TabIndex = 8;
			tb_srn_uk2.Text = "0x00000000";
			tb_srn_uk2.TextChanged += new EventHandler(
				SRNChangeSettings
			);
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(8, 96);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(73, 17);
			label5.TabIndex = 7;
			label5.Text = "Unknown 2:";
			//
			// tb_srn_uk1
			//
			tb_srn_uk1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_uk1.Location = new System.Drawing.Point(16, 72);
			tb_srn_uk1.Name = "tb_srn_uk1";
			tb_srn_uk1.Size = new System.Drawing.Size(88, 21);
			tb_srn_uk1.TabIndex = 6;
			tb_srn_uk1.Text = "0x0000";
			tb_srn_uk1.TextChanged += new EventHandler(
				SRNChangeSettings
			);
			//
			// label6
			//
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label6.Location = new System.Drawing.Point(8, 56);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(73, 17);
			label6.TabIndex = 5;
			label6.Text = "Unknown 1:";
			//
			// groupBox2
			//
			groupBox2.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			groupBox2.Controls.Add(linkLabel4);
			groupBox2.Controls.Add(tb_srn_b_name);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(tb_srn_b_1);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(lb_srn_b);
			groupBox2.Controls.Add(ll_srn_delb);
			groupBox2.FlatStyle = FlatStyle.System;
			groupBox2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox2.Location = new System.Drawing.Point(360, 136);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(424, 120);
			groupBox2.TabIndex = 5;
			groupBox2.TabStop = false;
			groupBox2.Text = "Unknown List B:";
			//
			// linkLabel4
			//
			linkLabel4.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			linkLabel4.AutoSize = true;
			linkLabel4.Location = new System.Drawing.Point(344, 96);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new System.Drawing.Size(28, 17);
			linkLabel4.TabIndex = 8;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "add";
			linkLabel4.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					SRNItemsBAdd
				);
			//
			// tb_srn_b_name
			//
			tb_srn_b_name.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tb_srn_b_name.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_b_name.Location = new System.Drawing.Point(160, 72);
			tb_srn_b_name.Multiline = true;
			tb_srn_b_name.Name = "tb_srn_b_name";
			tb_srn_b_name.ScrollBars = ScrollBars.Vertical;
			tb_srn_b_name.Size = new System.Drawing.Size(256, 24);
			tb_srn_b_name.TabIndex = 6;
			tb_srn_b_name.Text = "";
			//
			// label4
			//
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(152, 56);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(42, 17);
			label4.TabIndex = 5;
			label4.Text = "Name:";
			//
			// tb_srn_b_1
			//
			tb_srn_b_1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_b_1.Location = new System.Drawing.Point(160, 32);
			tb_srn_b_1.Name = "tb_srn_b_1";
			tb_srn_b_1.Size = new System.Drawing.Size(88, 21);
			tb_srn_b_1.TabIndex = 4;
			tb_srn_b_1.Text = "0x00000000";
			//
			// label3
			//
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(152, 16);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(73, 17);
			label3.TabIndex = 3;
			label3.Text = "Unknown 1:";
			//
			// lb_srn_b
			//
			lb_srn_b.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			lb_srn_b.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_srn_b.IntegralHeight = false;
			lb_srn_b.Location = new System.Drawing.Point(8, 24);
			lb_srn_b.Name = "lb_srn_b";
			lb_srn_b.Size = new System.Drawing.Size(136, 88);
			lb_srn_b.TabIndex = 2;
			//
			// ll_srn_delb
			//
			ll_srn_delb.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			ll_srn_delb.AutoSize = true;
			ll_srn_delb.Location = new System.Drawing.Point(372, 96);
			ll_srn_delb.Name = "ll_srn_delb";
			ll_srn_delb.Size = new System.Drawing.Size(44, 17);
			ll_srn_delb.TabIndex = 7;
			ll_srn_delb.TabStop = true;
			ll_srn_delb.Text = "delete";
			ll_srn_delb.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					SRNItemsBDelete
				);
			//
			// groupBox1
			//
			groupBox1.Controls.Add(linkLabel3);
			groupBox1.Controls.Add(tb_srn_a_2);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(tb_srn_a_1);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(lb_srn_a);
			groupBox1.Controls.Add(ll_srn_dela);
			groupBox1.FlatStyle = FlatStyle.System;
			groupBox1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			groupBox1.Location = new System.Drawing.Point(360, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(256, 120);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Shape Reference Index:";
			//
			// linkLabel3
			//
			linkLabel3.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			linkLabel3.AutoSize = true;
			linkLabel3.Location = new System.Drawing.Point(176, 96);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(28, 17);
			linkLabel3.TabIndex = 6;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "add";
			linkLabel3.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					SRNItemsAAdd
				);
			//
			// tb_srn_a_2
			//
			tb_srn_a_2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_a_2.Location = new System.Drawing.Point(160, 72);
			tb_srn_a_2.Name = "tb_srn_a_2";
			tb_srn_a_2.Size = new System.Drawing.Size(88, 21);
			tb_srn_a_2.TabIndex = 4;
			tb_srn_a_2.Text = "0x00000000";
			tb_srn_a_2.TextChanged += new EventHandler(
				SRNChangedItemsA
			);
			//
			// label2
			//
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(152, 56);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(74, 17);
			label2.TabIndex = 3;
			label2.Text = "Child Index:";
			//
			// tb_srn_a_1
			//
			tb_srn_a_1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tb_srn_a_1.Location = new System.Drawing.Point(160, 32);
			tb_srn_a_1.Name = "tb_srn_a_1";
			tb_srn_a_1.Size = new System.Drawing.Size(88, 21);
			tb_srn_a_1.TabIndex = 2;
			tb_srn_a_1.Text = "0x0000";
			tb_srn_a_1.TextChanged += new EventHandler(
				SRNChangedItemsA
			);
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(152, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(73, 17);
			label1.TabIndex = 1;
			label1.Text = "Unknown 1:";
			//
			// lb_srn_a
			//
			lb_srn_a.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			lb_srn_a.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lb_srn_a.IntegralHeight = false;
			lb_srn_a.Location = new System.Drawing.Point(8, 24);
			lb_srn_a.Name = "lb_srn_a";
			lb_srn_a.Size = new System.Drawing.Size(136, 88);
			lb_srn_a.TabIndex = 0;
			lb_srn_a.SelectedIndexChanged += new EventHandler(
				SRNSelectA
			);
			//
			// ll_srn_dela
			//
			ll_srn_dela.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			ll_srn_dela.AutoSize = true;
			ll_srn_dela.Location = new System.Drawing.Point(204, 96);
			ll_srn_dela.Name = "ll_srn_dela";
			ll_srn_dela.Size = new System.Drawing.Size(44, 17);
			ll_srn_dela.TabIndex = 5;
			ll_srn_dela.TabStop = true;
			ll_srn_dela.Text = "delete";
			ll_srn_dela.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					SRNItemsADelete
				);
			//
			// fShapeRefNode
			//
			groupBox3.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void SRNChangeSettings(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.ShapeRefNode srn = (Plugin.ShapeRefNode)Tag;

				srn.Unknown1 = Convert.ToInt16(tb_srn_uk1.Text, 16);
				srn.Unknown2 = Convert.ToInt32(tb_srn_uk2.Text, 16);
				srn.Unknown3 = Convert.ToInt32(tb_srn_uk3.Text, 16);
				srn.Unknown4 = Convert.ToByte(tb_srn_uk4.Text, 16);
				srn.Unknown5 = Convert.ToInt32(tb_srn_uk5.Text, 16);
				srn.Unknown6 = Convert.ToInt32(tb_srn_uk6.Text, 16);

				srn.Name = tb_srn_kind.Text;
				srn.Data = Helper.HexListToBytes(tb_srn_data.Text);

				srn.Version = Convert.ToUInt32(tb_srn_ver.Text, 16);

				srn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		#region Select SRN Items A
		private void SRNSelectA(object sender, EventArgs e)
		{
			if (lb_srn_a.Tag != null)
			{
				return;
			}

			if (lb_srn_a.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_srn_a.Tag = true;
				ShapeRefNodeItem_A a = (ShapeRefNodeItem_A)
					lb_srn_a.Items[lb_srn_a.SelectedIndex];

				tb_srn_a_1.Text = "0x" + Helper.HexString(a.Unknown1);
				tb_srn_a_2.Text = "0x" + Helper.HexString((uint)a.Unknown2);

				Plugin.ShapeRefNode srn = (Plugin.ShapeRefNode)Tag;
				srn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_srn_a.Tag = null;
			}
		}

		private void SRNChangedItemsA(object sender, EventArgs e)
		{
			if (lb_srn_a.Tag != null)
			{
				return;
			}

			if (lb_srn_a.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_srn_a.Tag = true;
				ShapeRefNodeItem_A a = (ShapeRefNodeItem_A)
					lb_srn_a.Items[lb_srn_a.SelectedIndex];

				a.Unknown1 = Convert.ToUInt16(tb_srn_a_1.Text, 16);
				a.Unknown2 = (int)Convert.ToUInt32(tb_srn_a_2.Text, 16);

				lb_srn_a.Items[lb_srn_a.SelectedIndex] = a;

				Plugin.ShapeRefNode srn = (Plugin.ShapeRefNode)Tag;
				srn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_srn_a.Tag = null;
			}
		}

		private void SRNItemsAAdd(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				lb_srn_a.Tag = true;
				Plugin.ShapeRefNode srn = (Plugin.ShapeRefNode)Tag;
				ShapeRefNodeItem_A a = new ShapeRefNodeItem_A();

				tb_srn_a_1.Text = "0x" + Helper.HexString(a.Unknown1);
				tb_srn_a_2.Text = "0x" + Helper.HexString((uint)a.Unknown2);

				srn.ItemsA = (ShapeRefNodeItem_A[])Helper.Add(srn.ItemsA, a);
				lb_srn_a.Items.Add(a);

				srn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_srn_a.Tag = null;
			}
		}

		private void SRNItemsADelete(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			if (lb_srn_a.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_srn_a.Tag = true;
				Plugin.ShapeRefNode srn = (Plugin.ShapeRefNode)Tag;
				ShapeRefNodeItem_A a = (ShapeRefNodeItem_A)
					lb_srn_a.Items[lb_srn_a.SelectedIndex];

				srn.ItemsA = (ShapeRefNodeItem_A[])Helper.Delete(srn.ItemsA, a);
				lb_srn_a.Items.Remove(a);

				srn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_srn_a.Tag = null;
			}
		}
		#endregion

		#region Select SRN Items B
		private void SRNSelectB(object sender, EventArgs e)
		{
			if (lb_srn_b.Tag != null)
			{
				return;
			}

			if (lb_srn_b.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_srn_b.Tag = true;
				ShapeRefNodeItem_B b = (ShapeRefNodeItem_B)
					lb_srn_b.Items[lb_srn_b.SelectedIndex];

				tb_srn_b_1.Text = "0x" + Helper.HexString((uint)b.Unknown1);
				tb_srn_b_name.Text = b.Name;

				Plugin.ShapeRefNode srn = (Plugin.ShapeRefNode)Tag;
				srn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_srn_b.Tag = null;
			}
		}

		private void SRNChangedItemsB(object sender, EventArgs e)
		{
			if (lb_srn_b.Tag != null)
			{
				return;
			}

			if (lb_srn_b.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_srn_b.Tag = true;
				ShapeRefNodeItem_B b = (ShapeRefNodeItem_B)
					lb_srn_b.Items[lb_srn_b.SelectedIndex];

				b.Unknown1 = (int)Convert.ToUInt32(tb_srn_b_1.Text, 16);
				b.Name = tb_srn_b_name.Text;

				lb_srn_b.Items[lb_srn_b.SelectedIndex] = b;
				Plugin.ShapeRefNode srn = (Plugin.ShapeRefNode)Tag;
				srn.Changed = true;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_srn_b.Tag = null;
			}
		}

		private void SRNItemsBAdd(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				lb_srn_b.Tag = true;
				Plugin.ShapeRefNode srn = (Plugin.ShapeRefNode)Tag;
				ShapeRefNodeItem_B b = new ShapeRefNodeItem_B
				{
					Unknown1 = (int)Convert.ToUInt32(tb_srn_b_1.Text, 16),
					Name = tb_srn_b_name.Text
				};

				srn.ItemsB = (ShapeRefNodeItem_B[])Helper.Add(srn.ItemsB, b);
				lb_srn_b.Items.Add(b);
				srn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_srn_b.Tag = null;
			}
		}

		private void SRNItemsBDelete(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (Tag == null)
			{
				return;
			}

			if (lb_srn_b.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				lb_srn_b.Tag = true;
				Plugin.ShapeRefNode srn = (Plugin.ShapeRefNode)Tag;
				ShapeRefNodeItem_B b = (ShapeRefNodeItem_B)
					lb_srn_b.Items[lb_srn_b.SelectedIndex];

				srn.ItemsB = (ShapeRefNodeItem_B[])Helper.Delete(srn.ItemsB, b);
				lb_srn_b.Items.Remove(b);

				srn.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				lb_srn_b.Tag = null;
			}
		}
		#endregion
	}
}
