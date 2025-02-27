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
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin.TabPage
{
	/// <summary>
	/// Summary description for fExtension.
	/// </summary>
	public class Extension
		:
		//System.Windows.Forms.UserControl
		System.Windows.Forms.TabPage
	{
		private GroupBox groupBox10;
		internal TextBox tb_ver;
		private Label label28;
		internal TextBox tb_type;
		private Label label1;
		internal TextBox tb_name;
		private Label label2;
		internal ListBox lb_items;
		private GroupBox gbval;
		private GroupBox gbtrans;
		private GroupBox gbrot;
		private GroupBox gbbin;
		private GroupBox gbstr;
		private GroupBox gbar;
		private Button btedit;
		private GroupBox gfootprintbar;
		private Button btfootprintedit;
		internal GroupBox gbIems;
		internal TextBox tbFootprint;
		private ComboBox cbtype;
		private LinkLabel linkLabel1;
		private LinkLabel lldel;
		private Label label3;
		private TextBox tb_itemname;
		private TextBox tbval;
		private TextBox tbstr;
		private TextBox tbbin;
		private TextBox tbtrans2;
		private TextBox tbtrans3;
		private TextBox tbtrans1;
		private TextBox tbrot1;
		private TextBox tbrot3;
		private TextBox tbrot2;
		private TextBox tbrot4;
		private GroupBox gbfloat;
		private TextBox tbfloat;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Extension()
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

			HideAll();
			cbtype.Items.Add(ExtensionItem.ItemTypes.Array);
			cbtype.Items.Add(ExtensionItem.ItemTypes.Binary);
			cbtype.Items.Add(ExtensionItem.ItemTypes.Float);
			cbtype.Items.Add(ExtensionItem.ItemTypes.Rotation);
			cbtype.Items.Add(ExtensionItem.ItemTypes.String);
			cbtype.Items.Add(ExtensionItem.ItemTypes.Translation);
			cbtype.Items.Add(ExtensionItem.ItemTypes.Value);
			cbtype.SelectedIndex = 0;

			this.UseVisualStyleBackColor = true;
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
			this.gbIems = new GroupBox();
			this.gbfloat = new GroupBox();
			this.tbfloat = new TextBox();
			this.gbval = new GroupBox();
			this.tbval = new TextBox();
			this.tb_itemname = new TextBox();
			this.label3 = new Label();
			this.lldel = new LinkLabel();
			this.linkLabel1 = new LinkLabel();
			this.cbtype = new ComboBox();
			this.gbar = new GroupBox();
			this.btedit = new Button();
			this.gfootprintbar = new GroupBox();
			this.btfootprintedit = new Button();
			this.gbstr = new GroupBox();
			this.tbstr = new TextBox();
			this.gbbin = new GroupBox();
			this.tbbin = new TextBox();
			this.gbrot = new GroupBox();
			this.tbrot4 = new TextBox();
			this.tbrot1 = new TextBox();
			this.tbrot3 = new TextBox();
			this.tbrot2 = new TextBox();
			this.gbtrans = new GroupBox();
			this.tbtrans1 = new TextBox();
			this.tbtrans3 = new TextBox();
			this.tbtrans2 = new TextBox();
			this.lb_items = new ListBox();
			this.tbFootprint = new TextBox();
			this.groupBox10 = new GroupBox();
			this.tb_name = new TextBox();
			this.label2 = new Label();
			this.tb_type = new TextBox();
			this.label1 = new Label();
			this.tb_ver = new TextBox();
			this.label28 = new Label();
			this.gbIems.SuspendLayout();
			this.gbfloat.SuspendLayout();
			this.gbval.SuspendLayout();
			this.gbar.SuspendLayout();
			this.gfootprintbar.SuspendLayout();
			this.gbstr.SuspendLayout();
			this.gbbin.SuspendLayout();
			this.gbrot.SuspendLayout();
			this.gbtrans.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.SuspendLayout();
			//
			// gbIems
			//
			this.gbIems.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbIems.Controls.Add(this.gbfloat);
			this.gbIems.Controls.Add(this.gbval);
			this.gbIems.Controls.Add(this.tb_itemname);
			this.gbIems.Controls.Add(this.label3);
			this.gbIems.Controls.Add(this.lldel);
			this.gbIems.Controls.Add(this.linkLabel1);
			this.gbIems.Controls.Add(this.cbtype);
			this.gbIems.Controls.Add(this.gbar);
			this.gbIems.Controls.Add(this.gfootprintbar);
			this.gbIems.Controls.Add(this.gbstr);
			this.gbIems.Controls.Add(this.gbbin);
			this.gbIems.Controls.Add(this.gbrot);
			this.gbIems.Controls.Add(this.gbtrans);
			this.gbIems.Controls.Add(this.lb_items);
			this.gbIems.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbIems.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.gbIems.Location = new Point(248, 8);
			this.gbIems.Name = "gbIems";
			this.gbIems.Size = new Size(536, 288);
			this.gbIems.TabIndex = 13;
			this.gbIems.TabStop = false;
			this.gbIems.Text = "Items";
			//
			// gbfloat
			//
			this.gbfloat.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbfloat.Controls.Add(this.tbfloat);
			this.gbfloat.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbfloat.Location = new Point(416, 128);
			this.gbfloat.Name = "gbfloat";
			this.gbfloat.Size = new Size(120, 56);
			this.gbfloat.TabIndex = 2;
			this.gbfloat.TabStop = false;
			this.gbfloat.Text = "Float Value";
			//
			// tbfloat
			//
			this.tbfloat.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbfloat.Location = new Point(16, 24);
			this.tbfloat.Name = "tbfloat";
			this.tbfloat.Size = new Size(88, 21);
			this.tbfloat.TabIndex = 0;
			this.tbfloat.Text = "0";
			this.tbfloat.TextChanged += new EventHandler(this.FloatChange);
			//
			// gbval
			//
			this.gbval.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbval.Controls.Add(this.tbval);
			this.gbval.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbval.Location = new Point(160, 216);
			this.gbval.Name = "gbval";
			this.gbval.Size = new Size(120, 56);
			this.gbval.TabIndex = 1;
			this.gbval.TabStop = false;
			this.gbval.Text = "Value";
			//
			// tbval
			//
			this.tbval.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbval.Location = new Point(16, 24);
			this.tbval.Name = "tbval";
			this.tbval.Size = new Size(88, 21);
			this.tbval.TabIndex = 0;
			this.tbval.Text = "0x00000000";
			this.tbval.TextChanged += new EventHandler(this.ValChange);
			//
			// tb_itemname
			//
			this.tb_itemname.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tb_itemname.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tb_itemname.Location = new Point(288, 40);
			this.tb_itemname.Name = "tb_itemname";
			this.tb_itemname.Size = new Size(240, 21);
			this.tb_itemname.TabIndex = 11;
			this.tb_itemname.TextChanged += new EventHandler(this.ChangeName);
			//
			// label3
			//
			this.label3.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.label3.AutoSize = true;
			this.label3.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label3.Location = new Point(280, 24);
			this.label3.Name = "label3";
			this.label3.Size = new Size(48, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Name:";
			//
			// lldel
			//
			this.lldel.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lldel.AutoSize = true;
			this.lldel.Location = new Point(488, 264);
			this.lldel.Name = "lldel";
			this.lldel.Size = new Size(48, 13);
			this.lldel.TabIndex = 9;
			this.lldel.TabStop = true;
			this.lldel.Text = "delete";
			this.lldel.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.DeleteItem
				);
			//
			// linkLabel1
			//
			this.linkLabel1.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new Point(456, 264);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new Size(31, 13);
			this.linkLabel1.TabIndex = 8;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "add";
			this.linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(this.AddItem);
			//
			// cbtype
			//
			this.cbtype.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.cbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbtype.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbtype.Location = new Point(280, 240);
			this.cbtype.Name = "cbtype";
			this.cbtype.Size = new Size(248, 21);
			this.cbtype.TabIndex = 7;
			//
			// gbar
			//
			this.gbar.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbar.Location = new Point(16, 216);
			this.gbar.Name = "gbar";
			this.gbar.Size = new Size(136, 56);
			this.gbar.TabIndex = 6;
			this.gbar.TabStop = false;
			this.gbar.Text = "Array";
			//
			// btedit
			//
			this.btedit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btedit.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.btedit.Location = new Point(16, 24);
			this.btedit.Name = "btedit";
			this.btedit.Size = new Size(104, 23);
			this.btedit.TabIndex = 0;
			this.btedit.Text = "Edit";
			this.btedit.Click += new EventHandler(this.OpenArrayEditor);
			//
			// gfootprintbar
			//
			this.gfootprintbar.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gfootprintbar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gfootprintbar.Location = new Point(16, 216);
			this.gfootprintbar.Name = "gfootprintbar";
			this.gfootprintbar.Size = new Size(136, 90);
			this.gfootprintbar.TabIndex = 6;
			this.gfootprintbar.TabStop = false;
			this.gfootprintbar.Text = "Footprint";
			//
			// btfootprintedit
			//
			this.btfootprintedit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btfootprintedit.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.btfootprintedit.Location = new Point(16, 55);
			this.btfootprintedit.Name = "btfootprintedit";
			this.btfootprintedit.Size = new Size(104, 23);
			this.btfootprintedit.TabIndex = 0;
			this.btfootprintedit.Text = "Draw";
			this.btfootprintedit.Click += new EventHandler(
				this.OpenFootprintEditor
			);
			//
			// gbstr
			//
			this.gbstr.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbstr.Controls.Add(this.tbstr);
			this.gbstr.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbstr.Location = new Point(280, 64);
			this.gbstr.Name = "gbstr";
			this.gbstr.Size = new Size(240, 56);
			this.gbstr.TabIndex = 5;
			this.gbstr.TabStop = false;
			this.gbstr.Text = "String";
			//
			// tbstr
			//
			this.tbstr.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbstr.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbstr.Location = new Point(16, 24);
			this.tbstr.Name = "tbstr";
			this.tbstr.Size = new Size(216, 21);
			this.tbstr.TabIndex = 1;
			this.tbstr.TextChanged += new EventHandler(this.StrChange);
			//
			// gbbin
			//
			this.gbbin.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbbin.Controls.Add(this.tbbin);
			this.gbbin.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbbin.Location = new Point(16, 40);
			this.gbbin.Name = "gbbin";
			this.gbbin.Size = new Size(248, 80);
			this.gbbin.TabIndex = 4;
			this.gbbin.TabStop = false;
			this.gbbin.Text = "Binary";
			//
			// tbbin
			//
			this.tbbin.Anchor = (
				(AnchorStyles)(
					(
						(
							System.Windows.Forms.AnchorStyles.Top
							| System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.tbbin.Font = new Font(
				"Courier New",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbbin.Location = new Point(16, 26);
			this.tbbin.Multiline = true;
			this.tbbin.Name = "tbbin";
			this.tbbin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbbin.Size = new Size(216, 40);
			this.tbbin.TabIndex = 2;
			this.tbbin.TextChanged += new EventHandler(this.BinChange);
			//
			// gbrot
			//
			this.gbrot.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbrot.Controls.Add(this.tbrot4);
			this.gbrot.Controls.Add(this.tbrot1);
			this.gbrot.Controls.Add(this.tbrot3);
			this.gbrot.Controls.Add(this.tbrot2);
			this.gbrot.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbrot.Location = new Point(280, 136);
			this.gbrot.Name = "gbrot";
			this.gbrot.Size = new Size(224, 80);
			this.gbrot.TabIndex = 3;
			this.gbrot.TabStop = false;
			this.gbrot.Text = "Rotation";
			//
			// tbrot4
			//
			this.tbrot4.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbrot4.Location = new Point(120, 48);
			this.tbrot4.Name = "tbrot4";
			this.tbrot4.Size = new Size(88, 21);
			this.tbrot4.TabIndex = 7;
			this.tbrot4.Text = "0x00000000";
			this.tbrot4.TextChanged += new EventHandler(this.RotChange);
			//
			// tbrot1
			//
			this.tbrot1.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbrot1.Location = new Point(16, 24);
			this.tbrot1.Name = "tbrot1";
			this.tbrot1.Size = new Size(88, 21);
			this.tbrot1.TabIndex = 6;
			this.tbrot1.Text = "0x00000000";
			this.tbrot1.TextChanged += new EventHandler(this.RotChange);
			//
			// tbrot3
			//
			this.tbrot3.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbrot3.Location = new Point(16, 48);
			this.tbrot3.Name = "tbrot3";
			this.tbrot3.Size = new Size(88, 21);
			this.tbrot3.TabIndex = 5;
			this.tbrot3.Text = "0x00000000";
			this.tbrot3.TextChanged += new EventHandler(this.RotChange);
			//
			// tbrot2
			//
			this.tbrot2.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbrot2.Location = new Point(120, 24);
			this.tbrot2.Name = "tbrot2";
			this.tbrot2.Size = new Size(88, 21);
			this.tbrot2.TabIndex = 4;
			this.tbrot2.Text = "0x00000000";
			this.tbrot2.TextChanged += new EventHandler(this.RotChange);
			//
			// gbtrans
			//
			this.gbtrans.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Top
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.gbtrans.Controls.Add(this.tbtrans1);
			this.gbtrans.Controls.Add(this.tbtrans3);
			this.gbtrans.Controls.Add(this.tbtrans2);
			this.gbtrans.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbtrans.Location = new Point(16, 120);
			this.gbtrans.Name = "gbtrans";
			this.gbtrans.Size = new Size(224, 80);
			this.gbtrans.TabIndex = 2;
			this.gbtrans.TabStop = false;
			this.gbtrans.Text = "Translation";
			//
			// tbtrans1
			//
			this.tbtrans1.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbtrans1.Location = new Point(16, 24);
			this.tbtrans1.Name = "tbtrans1";
			this.tbtrans1.Size = new Size(88, 21);
			this.tbtrans1.TabIndex = 3;
			this.tbtrans1.Text = "0x00000000";
			this.tbtrans1.TextChanged += new EventHandler(this.TransChange);
			//
			// tbtrans3
			//
			this.tbtrans3.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbtrans3.Location = new Point(16, 48);
			this.tbtrans3.Name = "tbtrans3";
			this.tbtrans3.Size = new Size(88, 21);
			this.tbtrans3.TabIndex = 2;
			this.tbtrans3.Text = "0x00000000";
			this.tbtrans3.TextChanged += new EventHandler(this.TransChange);
			//
			// tbtrans2
			//
			this.tbtrans2.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbtrans2.Location = new Point(120, 24);
			this.tbtrans2.Name = "tbtrans2";
			this.tbtrans2.Size = new Size(88, 21);
			this.tbtrans2.TabIndex = 1;
			this.tbtrans2.Text = "0x00000000";
			this.tbtrans2.TextChanged += new EventHandler(this.TransChange);
			//
			// lb_items
			//
			this.lb_items.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								System.Windows.Forms.AnchorStyles.Top
								| System.Windows.Forms.AnchorStyles.Bottom
							) | System.Windows.Forms.AnchorStyles.Left
						) | System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.lb_items.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.lb_items.HorizontalScrollbar = true;
			this.lb_items.IntegralHeight = false;
			this.lb_items.Location = new Point(8, 24);
			this.lb_items.Name = "lb_items";
			this.lb_items.Size = new Size(264, 256); // if I take 200 off there's very little left
			this.lb_items.TabIndex = 0;
			this.lb_items.SelectedIndexChanged += new EventHandler(
				this.SelectItem
			);
			//
			// tbFootprint
			//
			this.tbFootprint.Font = new Font(
				"Courier New",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbFootprint.Location = new Point(0, 0);
			this.tbFootprint.Name = "tbFootprint";
			this.tbFootprint.Size = new Size(100, 20);
			this.tbFootprint.TabIndex = 0;
			//
			// groupBox10
			//
			this.groupBox10.Controls.Add(this.tb_name);
			this.groupBox10.Controls.Add(this.label2);
			this.groupBox10.Controls.Add(this.tb_type);
			this.groupBox10.Controls.Add(this.label1);
			this.groupBox10.Controls.Add(this.tb_ver);
			this.groupBox10.Controls.Add(this.label28);
			this.groupBox10.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox10.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.groupBox10.Location = new Point(8, 8);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new Size(232, 112);
			this.groupBox10.TabIndex = 12;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Settings";
			//
			// tb_name
			//
			this.tb_name.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tb_name.Location = new Point(16, 80);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new Size(200, 21);
			this.tb_name.TabIndex = 28;
			this.tb_name.Text = "0x00";
			this.tb_name.TextChanged += new EventHandler(this.GNSettingsChange);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label2.Location = new Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new Size(40, 13);
			this.label2.TabIndex = 27;
			this.label2.Text = "Name";
			//
			// tb_type
			//
			this.tb_type.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tb_type.Location = new Point(128, 40);
			this.tb_type.Name = "tb_type";
			this.tb_type.Size = new Size(88, 21);
			this.tb_type.TabIndex = 26;
			this.tb_type.Text = "0x00";
			this.tb_type.TextChanged += new EventHandler(this.GNSettingsChange);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new Point(120, 24);
			this.label1.Name = "label1";
			this.label1.Size = new Size(67, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Typecode:";
			//
			// tb_ver
			//
			this.tb_ver.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tb_ver.Location = new Point(16, 40);
			this.tb_ver.Name = "tb_ver";
			this.tb_ver.Size = new Size(88, 21);
			this.tb_ver.TabIndex = 24;
			this.tb_ver.Text = "0x00000000";
			this.tb_ver.TextChanged += new EventHandler(this.GNSettingsChange);
			//
			// label28
			//
			this.label28.AutoSize = true;
			this.label28.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label28.Location = new Point(8, 24);
			this.label28.Name = "label28";
			this.label28.Size = new Size(55, 13);
			this.label28.TabIndex = 23;
			this.label28.Text = "Version:";
			//
			// Extension
			//
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Controls.Add(this.gbIems);
			this.Controls.Add(this.groupBox10);
			this.Location = new Point(4, 22);
			this.Name = "tExtension";
			this.Size = new Size(792, 302);
			this.Text = "Extension";
			this.gbIems.ResumeLayout(false);
			this.gbIems.PerformLayout();
			this.gbfloat.ResumeLayout(false);
			this.gbfloat.PerformLayout();
			this.gbval.ResumeLayout(false);
			this.gbval.PerformLayout();
			this.gbar.ResumeLayout(false);
			this.gfootprintbar.ResumeLayout(false);
			this.gbstr.ResumeLayout(false);
			this.gbstr.PerformLayout();
			this.gbbin.ResumeLayout(false);
			this.gbbin.PerformLayout();
			this.gbrot.ResumeLayout(false);
			this.gbrot.PerformLayout();
			this.gbtrans.ResumeLayout(false);
			this.gbtrans.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void GNSettingsChange(object sender, EventArgs e)
		{
			if (Tag == null)
			{
				return;
			}

			try
			{
				Plugin.Extension ext = (Plugin.Extension)Tag;

				ext.Version = Convert.ToUInt32(tb_ver.Text, 16);
				ext.VarName = tb_name.Text;
				ext.TypeCode = Convert.ToByte(tb_type.Text, 16);
				ext.Changed = true;
				lldel.Enabled = false;
			}
			catch (Exception)
			{
				//Helper.ExceptionMessage("", ex);
			}
		}

		internal void HideAll()
		{
			this.gbval.Visible = false;
			this.gbar.Visible = false;
			this.gfootprintbar.Visible = false;
			this.gbfloat.Visible = false;
			this.gbbin.Visible = false;
			this.gbrot.Visible = false;
			this.gbstr.Visible = false;
			this.gbtrans.Visible = false;
		}

		internal void ShowGroup(GroupBox gb)
		{
			gb.Left = this.lb_items.Left + this.lb_items.Width + 8;
			gb.Top = this.tb_itemname.Top + tb_itemname.Height + 4;
			gb.Visible = true;
		}

		private void SelectItem(object sender, EventArgs e)
		{
			if (tb_itemname.Tag != null)
			{
				return;
			}

			HideAll();
			if (lb_items.SelectedIndex < 0)
			{
				return;
			}

			lldel.Enabled = true;
			try
			{
				tb_itemname.Tag = true;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];
				tb_itemname.Text = ei.Name;

				switch (ei.Typecode)
				{
					case ExtensionItem.ItemTypes.Value:
					{
						tbval.Text = "0x" + Helper.HexString((uint)ei.Value);
						ShowGroup(this.gbval);
						break;
					}
					case ExtensionItem.ItemTypes.Float:
					{
						tbfloat.Text = ei.Single.ToString();
						;
						ShowGroup(this.gbfloat);
						break;
					}
					case ExtensionItem.ItemTypes.Translation:
					{
						tbtrans1.Text = ei.Translation.X.ToString("N6");
						tbtrans2.Text = ei.Translation.Y.ToString("N6");
						tbtrans3.Text = ei.Translation.Z.ToString("N6");
						ShowGroup(this.gbtrans);
						break;
					}
					case ExtensionItem.ItemTypes.String:
					{
						tbstr.Text = ei.String;
						ShowGroup(this.gbstr);
						break;
					}
					case ExtensionItem.ItemTypes.Rotation:
					{
						tbrot1.Text = ei.Rotation.X.ToString("N6");
						tbrot2.Text = ei.Rotation.Y.ToString("N6");
						tbrot3.Text = ei.Rotation.Z.ToString("N6");
						tbrot4.Text = ei.Rotation.W.ToString("N6");
						ShowGroup(this.gbrot);
						break;
					}
					case ExtensionItem.ItemTypes.Binary:
					{
						tbbin.Text = Helper.BytesToHexList(ei.Data);
						ShowGroup(this.gbbin);
						break;
					}
					case ExtensionItem.ItemTypes.Array:
					{
						Plugin.Extension ext = (Plugin.Extension)Tag;

						if (ext.VarName.Equals("footprint"))
						{
							this.gfootprintbar.Controls.Add(this.btfootprintedit);
							this.gfootprintbar.Controls.Add(this.btedit);
							ShowGroup(this.gfootprintbar);
						}
						else
						{
							this.gbar.Controls.Add(this.btedit);
							ShowGroup(this.gbar);
						}
						break;
					}
				} //switch
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				tb_itemname.Tag = null;
			}
		}

		private void OpenArrayEditor(object sender, EventArgs e)
		{
			try
			{
				Extension fe = new Extension();
				Form f = new Form();
				f.Text = SimPe.Localization.GetString("Sub Array Editor");
				f.ShowInTaskbar = false;
				f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
				f.Size = new Size(840, 368);
				f.Controls.Add(fe.gbIems);

				fe.gbIems.Left = 8;
				fe.gbIems.Top = 8;
				fe.gbIems.Width = f.Width - 24;
				fe.gbIems.Height = f.ClientRectangle.Height - 16;
				fe.gbIems.BackColor = SystemColors.Control;

				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];
				fe.gbIems.Tag = ei.Items;
				foreach (ExtensionItem i in ei.Items)
				{
					fe.lb_items.Items.Add(i);
				}

				f.ShowDialog();

				ei.Items = (ExtensionItem[])fe.gbIems.Tag;
				lb_items.Items[lb_items.SelectedIndex] = ei;

				f.Dispose();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void OpenFootprintEditor(object sender, EventArgs e)
		{
			try
			{
				Extension fe = new Extension();
				Form f = new Form();
				f.Text = SimPe.Localization.GetString("Sub Array Editor");
				f.ShowInTaskbar = false;
				f.FormBorderStyle = FormBorderStyle.FixedToolWindow;

				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];

				int boxsize = 225;

				int minx = ei.Items[0].Value;
				int maxx = ei.Items[1].Value;
				int miny = ei.Items[2].Value;
				int maxy = ei.Items[3].Value;

				int windowHeight = 0;
				int windowWidth = 0;

				if (maxx - minx <= 3)
				{
					windowWidth = boxsize * (maxx - minx + 1) + 6;
				}
				else
				{
					windowWidth = 702;
					windowHeight += 22;
				}
				if (maxy - miny <= 3)
				{
					windowHeight += boxsize * (maxy - miny + 1) + 23;
				}
				else
				{
					windowHeight += 702;
					windowWidth += 22;
				}

				f.Size = new Size(windowWidth, windowHeight);
				Panel scroller = new Panel();
				scroller.Height = f.Height - 22;
				scroller.Width = f.Width - 5;
				scroller.AutoScroll = true;
				f.Controls.Add(scroller);

				for (int i = 4; i < ei.Items.Length; i++)
				{
					ExtensionItem item = ei.Items[i];
					String[] a = item.Name.Split(new char[] { '(', ',', ')' });

					int tilex = int.Parse(a[1]) - minx;
					int tiley = int.Parse(a[2]) - miny;

					GroupBox gb = new GroupBox();
					gb.Left = tilex * boxsize;
					gb.Top = tiley * boxsize;
					gb.Width = boxsize;
					gb.Height = boxsize;
					gb.Name = item.Name;

					UnPackFootprint(gb, item);
					scroller.Controls.Add(gb);
				}

				f.ShowDialog();

				for (int i = 4; i < ei.Items.Length; i++)
				{
					ExtensionItem item = ei.Items[i];
					int index = scroller.Controls.IndexOfKey(item.Name);
					GroupBox gb = (GroupBox)scroller.Controls[index];
					RePackFootprint(gb, item);
				}

				//ei.Items = (ExtensionItem[])fe.gbIems.Tag;
				lb_items.Items[lb_items.SelectedIndex] = ei;

				f.Dispose();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void UnPackFootprint(GroupBox gb, ExtensionItem item)
		{
			for (int j = 0; j < 32; j += 2)
			{
				int part2 = item.Data[j];
				int part1 = item.Data[j + 1];
				for (int k = 0; k < 8; k++)
				{
					CheckBox cb = new CheckBox();
					cb.Width = 14;
					cb.Height = 14;
					cb.Left = k * cb.Width;
					cb.Top = j * 7;
					cb.Name = "cb." + j + "." + k + ".2";
					int isSet = (part2 & 1);
					if (isSet == 1)
					{
						cb.Checked = true;
					}
					else
					{
						cb.Checked = false;
					}
					gb.Controls.Add(cb);
					part2 = part2 >> 1;
				}
				for (int k = 0; k < 8; k++)
				{
					CheckBox cb = new CheckBox();
					cb.Width = 14;
					cb.Height = 14;
					cb.Left = 8 * cb.Width + k * cb.Width;
					cb.Top = j * 7;
					cb.Name = "cb." + j + "." + k + ".1";
					int isSet = (part1 & 1);
					if (isSet == 1)
					{
						cb.Checked = true;
					}
					else
					{
						cb.Checked = false;
					}
					gb.Controls.Add(cb);
					part1 = part1 >> 1;
				}
			}
		}

		private void RePackFootprint(GroupBox gb, ExtensionItem item)
		{
			for (int j = 0; j < 32; j += 2)
			{
				int part1 = 0;
				int part2 = 0;

				for (int k = 0; k < 8; k++)
				{
					String name = "cb." + j + "." + (7 - k) + ".1";
					int index = gb.Controls.IndexOfKey(name);
					CheckBox cb = (CheckBox)gb.Controls[index];

					part1 = part1 << 1;
					if (cb.Checked == true)
					{
						part1 = part1 | 1;
					}
				}
				for (int k = 0; k < 8; k++)
				{
					String name = "cb." + j + "." + (7 - k) + ".2";
					int index = gb.Controls.IndexOfKey(name);
					CheckBox cb = (CheckBox)gb.Controls[index];

					part2 = part2 << 1;
					if (cb.Checked == true)
					{
						part2 = part2 | 1;
					}
				}
				item.Data[j + 1] = (byte)part1;
				item.Data[j] = (byte)part2;
			}
		}

		private void DeleteItem(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lb_items.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				ExtensionItem[] list = (ExtensionItem[])gbIems.Tag;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];

				list = (ExtensionItem[])Helper.Delete(list, ei);
				gbIems.Tag = list;
				lb_items.Items.Remove(ei);

				//write back to the wrapper
				if (Tag != null)
				{
					Plugin.Extension ext = (Plugin.Extension)Tag;
					ext.Items = list;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void AddItem(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				ExtensionItem[] list = (ExtensionItem[])gbIems.Tag;
				ExtensionItem ei = new ExtensionItem();
				ei.Typecode = (ExtensionItem.ItemTypes)
					cbtype.Items[cbtype.SelectedIndex];

				list = (ExtensionItem[])Helper.Add(list, ei);
				gbIems.Tag = list;
				lb_items.Items.Add(ei);

				//write back to the wrapper
				if (Tag != null)
				{
					Plugin.Extension ext = (Plugin.Extension)Tag;
					ext.Items = list;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void ChangeName(object sender, EventArgs e)
		{
			if (tb_itemname.Tag != null)
			{
				return;
			}

			if (lb_items.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tb_itemname.Tag = true;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];
				ei.Name = tb_itemname.Text;

				lb_items.Items[lb_items.SelectedIndex] = ei;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				tb_itemname.Tag = null;
			}
		}

		private void ValChange(object sender, EventArgs e)
		{
			if (tb_itemname.Tag != null)
			{
				return;
			}

			if (lb_items.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tb_itemname.Tag = true;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];
				ei.Value = (int)Convert.ToUInt32(tbval.Text, 16);

				lb_items.Items[lb_items.SelectedIndex] = ei;
			}
			catch (Exception) { }
			finally
			{
				tb_itemname.Tag = null;
			}
		}

		private void FloatChange(object sender, EventArgs e)
		{
			if (tb_itemname.Tag != null)
			{
				return;
			}

			if (lb_items.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tb_itemname.Tag = true;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];
				ei.Single = Convert.ToSingle(tbfloat.Text);

				lb_items.Items[lb_items.SelectedIndex] = ei;
			}
			catch (Exception) { }
			finally
			{
				tb_itemname.Tag = null;
			}
		}

		private void TransChange(object sender, EventArgs e)
		{
			if (tb_itemname.Tag != null)
			{
				return;
			}

			if (lb_items.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tb_itemname.Tag = true;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];
				ei.Translation.X = Convert.ToSingle(tbtrans1.Text);
				ei.Translation.Y = Convert.ToSingle(tbtrans2.Text);
				ei.Translation.Z = Convert.ToSingle(tbtrans3.Text);

				lb_items.Items[lb_items.SelectedIndex] = ei;
			}
			catch (Exception) { }
			finally
			{
				tb_itemname.Tag = null;
			}
		}

		private void RotChange(object sender, EventArgs e)
		{
			if (tb_itemname.Tag != null)
			{
				return;
			}

			if (lb_items.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tb_itemname.Tag = true;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];
				ei.Rotation.X = Convert.ToSingle(tbrot1.Text);
				ei.Rotation.Y = Convert.ToSingle(tbrot2.Text);
				ei.Rotation.Z = Convert.ToSingle(tbrot3.Text);
				ei.Rotation.W = Convert.ToSingle(tbrot4.Text);

				lb_items.Items[lb_items.SelectedIndex] = ei;
			}
			catch (Exception) { }
			finally
			{
				tb_itemname.Tag = null;
			}
		}

		private void StrChange(object sender, EventArgs e)
		{
			if (tb_itemname.Tag != null)
			{
				return;
			}

			if (lb_items.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tb_itemname.Tag = true;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];
				ei.String = tbstr.Text;

				lb_items.Items[lb_items.SelectedIndex] = ei;
			}
			catch (Exception) { }
			finally
			{
				tb_itemname.Tag = null;
			}
		}

		private void BinChange(object sender, EventArgs e)
		{
			if (tb_itemname.Tag != null)
			{
				return;
			}

			if (lb_items.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				tb_itemname.Tag = true;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];
				ei.Data = Helper.HexListToBytes(tbbin.Text);

				lb_items.Items[lb_items.SelectedIndex] = ei;
			}
			catch (Exception) { }
			finally
			{
				tb_itemname.Tag = null;
			}
		}
	}
}
