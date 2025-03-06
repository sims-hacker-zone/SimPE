// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
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
				components?.Dispose();
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
			gbIems = new GroupBox();
			gbfloat = new GroupBox();
			tbfloat = new TextBox();
			gbval = new GroupBox();
			tbval = new TextBox();
			tb_itemname = new TextBox();
			label3 = new Label();
			lldel = new LinkLabel();
			linkLabel1 = new LinkLabel();
			cbtype = new ComboBox();
			gbar = new GroupBox();
			btedit = new Button();
			gfootprintbar = new GroupBox();
			btfootprintedit = new Button();
			gbstr = new GroupBox();
			tbstr = new TextBox();
			gbbin = new GroupBox();
			tbbin = new TextBox();
			gbrot = new GroupBox();
			tbrot4 = new TextBox();
			tbrot1 = new TextBox();
			tbrot3 = new TextBox();
			tbrot2 = new TextBox();
			gbtrans = new GroupBox();
			tbtrans1 = new TextBox();
			tbtrans3 = new TextBox();
			tbtrans2 = new TextBox();
			lb_items = new ListBox();
			tbFootprint = new TextBox();
			groupBox10 = new GroupBox();
			tb_name = new TextBox();
			label2 = new Label();
			tb_type = new TextBox();
			label1 = new Label();
			tb_ver = new TextBox();
			label28 = new Label();
			gbIems.SuspendLayout();
			gbfloat.SuspendLayout();
			gbval.SuspendLayout();
			gbar.SuspendLayout();
			gfootprintbar.SuspendLayout();
			gbstr.SuspendLayout();
			gbbin.SuspendLayout();
			gbrot.SuspendLayout();
			gbtrans.SuspendLayout();
			groupBox10.SuspendLayout();
			SuspendLayout();
			//
			// gbIems
			//
			gbIems.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			gbIems.Controls.Add(gbfloat);
			gbIems.Controls.Add(gbval);
			gbIems.Controls.Add(tb_itemname);
			gbIems.Controls.Add(label3);
			gbIems.Controls.Add(lldel);
			gbIems.Controls.Add(linkLabel1);
			gbIems.Controls.Add(cbtype);
			gbIems.Controls.Add(gbar);
			gbIems.Controls.Add(gfootprintbar);
			gbIems.Controls.Add(gbstr);
			gbIems.Controls.Add(gbbin);
			gbIems.Controls.Add(gbrot);
			gbIems.Controls.Add(gbtrans);
			gbIems.Controls.Add(lb_items);
			gbIems.FlatStyle = FlatStyle.System;
			gbIems.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			gbIems.Location = new Point(248, 8);
			gbIems.Name = "gbIems";
			gbIems.Size = new Size(536, 288);
			gbIems.TabIndex = 13;
			gbIems.TabStop = false;
			gbIems.Text = "Items";
			//
			// gbfloat
			//
			gbfloat.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbfloat.Controls.Add(tbfloat);
			gbfloat.FlatStyle = FlatStyle.System;
			gbfloat.Location = new Point(416, 128);
			gbfloat.Name = "gbfloat";
			gbfloat.Size = new Size(120, 56);
			gbfloat.TabIndex = 2;
			gbfloat.TabStop = false;
			gbfloat.Text = "Float Value";
			//
			// tbfloat
			//
			tbfloat.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbfloat.Location = new Point(16, 24);
			tbfloat.Name = "tbfloat";
			tbfloat.Size = new Size(88, 21);
			tbfloat.TabIndex = 0;
			tbfloat.Text = "0";
			tbfloat.TextChanged += new EventHandler(FloatChange);
			//
			// gbval
			//
			gbval.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbval.Controls.Add(tbval);
			gbval.FlatStyle = FlatStyle.System;
			gbval.Location = new Point(160, 216);
			gbval.Name = "gbval";
			gbval.Size = new Size(120, 56);
			gbval.TabIndex = 1;
			gbval.TabStop = false;
			gbval.Text = "Value";
			//
			// tbval
			//
			tbval.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbval.Location = new Point(16, 24);
			tbval.Name = "tbval";
			tbval.Size = new Size(88, 21);
			tbval.TabIndex = 0;
			tbval.Text = "0x00000000";
			tbval.TextChanged += new EventHandler(ValChange);
			//
			// tb_itemname
			//
			tb_itemname.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			tb_itemname.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tb_itemname.Location = new Point(288, 40);
			tb_itemname.Name = "tb_itemname";
			tb_itemname.Size = new Size(240, 21);
			tb_itemname.TabIndex = 11;
			tb_itemname.TextChanged += new EventHandler(ChangeName);
			//
			// label3
			//
			label3.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			label3.AutoSize = true;
			label3.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label3.Location = new Point(280, 24);
			label3.Name = "label3";
			label3.Size = new Size(48, 13);
			label3.TabIndex = 10;
			label3.Text = "Name:";
			//
			// lldel
			//
			lldel.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			lldel.AutoSize = true;
			lldel.Location = new Point(488, 264);
			lldel.Name = "lldel";
			lldel.Size = new Size(48, 13);
			lldel.TabIndex = 9;
			lldel.TabStop = true;
			lldel.Text = "delete";
			lldel.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					DeleteItem
				);
			//
			// linkLabel1
			//
			linkLabel1.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new Point(456, 264);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(31, 13);
			linkLabel1.TabIndex = 8;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "add";
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(AddItem);
			//
			// cbtype
			//
			cbtype.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			cbtype.DropDownStyle = ComboBoxStyle.DropDownList;
			cbtype.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbtype.Location = new Point(280, 240);
			cbtype.Name = "cbtype";
			cbtype.Size = new Size(248, 21);
			cbtype.TabIndex = 7;
			//
			// gbar
			//
			gbar.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbar.FlatStyle = FlatStyle.System;
			gbar.Location = new Point(16, 216);
			gbar.Name = "gbar";
			gbar.Size = new Size(136, 56);
			gbar.TabIndex = 6;
			gbar.TabStop = false;
			gbar.Text = "Array";
			//
			// btedit
			//
			btedit.FlatStyle = FlatStyle.System;
			btedit.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			btedit.Location = new Point(16, 24);
			btedit.Name = "btedit";
			btedit.Size = new Size(104, 23);
			btedit.TabIndex = 0;
			btedit.Text = "Edit";
			btedit.Click += new EventHandler(OpenArrayEditor);
			//
			// gfootprintbar
			//
			gfootprintbar.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gfootprintbar.FlatStyle = FlatStyle.System;
			gfootprintbar.Location = new Point(16, 216);
			gfootprintbar.Name = "gfootprintbar";
			gfootprintbar.Size = new Size(136, 90);
			gfootprintbar.TabIndex = 6;
			gfootprintbar.TabStop = false;
			gfootprintbar.Text = "Footprint";
			//
			// btfootprintedit
			//
			btfootprintedit.FlatStyle = FlatStyle.System;
			btfootprintedit.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			btfootprintedit.Location = new Point(16, 55);
			btfootprintedit.Name = "btfootprintedit";
			btfootprintedit.Size = new Size(104, 23);
			btfootprintedit.TabIndex = 0;
			btfootprintedit.Text = "Draw";
			btfootprintedit.Click += new EventHandler(
				OpenFootprintEditor
			);
			//
			// gbstr
			//
			gbstr.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbstr.Controls.Add(tbstr);
			gbstr.FlatStyle = FlatStyle.System;
			gbstr.Location = new Point(280, 64);
			gbstr.Name = "gbstr";
			gbstr.Size = new Size(240, 56);
			gbstr.TabIndex = 5;
			gbstr.TabStop = false;
			gbstr.Text = "String";
			//
			// tbstr
			//
			tbstr.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbstr.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbstr.Location = new Point(16, 24);
			tbstr.Name = "tbstr";
			tbstr.Size = new Size(216, 21);
			tbstr.TabIndex = 1;
			tbstr.TextChanged += new EventHandler(StrChange);
			//
			// gbbin
			//
			gbbin.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbbin.Controls.Add(tbbin);
			gbbin.FlatStyle = FlatStyle.System;
			gbbin.Location = new Point(16, 40);
			gbbin.Name = "gbbin";
			gbbin.Size = new Size(248, 80);
			gbbin.TabIndex = 4;
			gbbin.TabStop = false;
			gbbin.Text = "Binary";
			//
			// tbbin
			//
			tbbin.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			tbbin.Font = new Font(
				"Courier New",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbbin.Location = new Point(16, 26);
			tbbin.Multiline = true;
			tbbin.Name = "tbbin";
			tbbin.ScrollBars = ScrollBars.Vertical;
			tbbin.Size = new Size(216, 40);
			tbbin.TabIndex = 2;
			tbbin.TextChanged += new EventHandler(BinChange);
			//
			// gbrot
			//
			gbrot.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbrot.Controls.Add(tbrot4);
			gbrot.Controls.Add(tbrot1);
			gbrot.Controls.Add(tbrot3);
			gbrot.Controls.Add(tbrot2);
			gbrot.FlatStyle = FlatStyle.System;
			gbrot.Location = new Point(280, 136);
			gbrot.Name = "gbrot";
			gbrot.Size = new Size(224, 80);
			gbrot.TabIndex = 3;
			gbrot.TabStop = false;
			gbrot.Text = "Rotation";
			//
			// tbrot4
			//
			tbrot4.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbrot4.Location = new Point(120, 48);
			tbrot4.Name = "tbrot4";
			tbrot4.Size = new Size(88, 21);
			tbrot4.TabIndex = 7;
			tbrot4.Text = "0x00000000";
			tbrot4.TextChanged += new EventHandler(RotChange);
			//
			// tbrot1
			//
			tbrot1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbrot1.Location = new Point(16, 24);
			tbrot1.Name = "tbrot1";
			tbrot1.Size = new Size(88, 21);
			tbrot1.TabIndex = 6;
			tbrot1.Text = "0x00000000";
			tbrot1.TextChanged += new EventHandler(RotChange);
			//
			// tbrot3
			//
			tbrot3.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbrot3.Location = new Point(16, 48);
			tbrot3.Name = "tbrot3";
			tbrot3.Size = new Size(88, 21);
			tbrot3.TabIndex = 5;
			tbrot3.Text = "0x00000000";
			tbrot3.TextChanged += new EventHandler(RotChange);
			//
			// tbrot2
			//
			tbrot2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbrot2.Location = new Point(120, 24);
			tbrot2.Name = "tbrot2";
			tbrot2.Size = new Size(88, 21);
			tbrot2.TabIndex = 4;
			tbrot2.Text = "0x00000000";
			tbrot2.TextChanged += new EventHandler(RotChange);
			//
			// gbtrans
			//
			gbtrans.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			gbtrans.Controls.Add(tbtrans1);
			gbtrans.Controls.Add(tbtrans3);
			gbtrans.Controls.Add(tbtrans2);
			gbtrans.FlatStyle = FlatStyle.System;
			gbtrans.Location = new Point(16, 120);
			gbtrans.Name = "gbtrans";
			gbtrans.Size = new Size(224, 80);
			gbtrans.TabIndex = 2;
			gbtrans.TabStop = false;
			gbtrans.Text = "Translation";
			//
			// tbtrans1
			//
			tbtrans1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbtrans1.Location = new Point(16, 24);
			tbtrans1.Name = "tbtrans1";
			tbtrans1.Size = new Size(88, 21);
			tbtrans1.TabIndex = 3;
			tbtrans1.Text = "0x00000000";
			tbtrans1.TextChanged += new EventHandler(TransChange);
			//
			// tbtrans3
			//
			tbtrans3.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbtrans3.Location = new Point(16, 48);
			tbtrans3.Name = "tbtrans3";
			tbtrans3.Size = new Size(88, 21);
			tbtrans3.TabIndex = 2;
			tbtrans3.Text = "0x00000000";
			tbtrans3.TextChanged += new EventHandler(TransChange);
			//
			// tbtrans2
			//
			tbtrans2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbtrans2.Location = new Point(120, 24);
			tbtrans2.Name = "tbtrans2";
			tbtrans2.Size = new Size(88, 21);
			tbtrans2.TabIndex = 1;
			tbtrans2.Text = "0x00000000";
			tbtrans2.TextChanged += new EventHandler(TransChange);
			//
			// lb_items
			//
			lb_items.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			lb_items.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			lb_items.HorizontalScrollbar = true;
			lb_items.IntegralHeight = false;
			lb_items.Location = new Point(8, 24);
			lb_items.Name = "lb_items";
			lb_items.Size = new Size(264, 256); // if I take 200 off there's very little left
			lb_items.TabIndex = 0;
			lb_items.SelectedIndexChanged += new EventHandler(
				SelectItem
			);
			//
			// tbFootprint
			//
			tbFootprint.Font = new Font(
				"Courier New",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbFootprint.Location = new Point(0, 0);
			tbFootprint.Name = "tbFootprint";
			tbFootprint.Size = new Size(100, 20);
			tbFootprint.TabIndex = 0;
			//
			// groupBox10
			//
			groupBox10.Controls.Add(tb_name);
			groupBox10.Controls.Add(label2);
			groupBox10.Controls.Add(tb_type);
			groupBox10.Controls.Add(label1);
			groupBox10.Controls.Add(tb_ver);
			groupBox10.Controls.Add(label28);
			groupBox10.FlatStyle = FlatStyle.System;
			groupBox10.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			groupBox10.Location = new Point(8, 8);
			groupBox10.Name = "groupBox10";
			groupBox10.Size = new Size(232, 112);
			groupBox10.TabIndex = 12;
			groupBox10.TabStop = false;
			groupBox10.Text = "Settings";
			//
			// tb_name
			//
			tb_name.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tb_name.Location = new Point(16, 80);
			tb_name.Name = "tb_name";
			tb_name.Size = new Size(200, 21);
			tb_name.TabIndex = 28;
			tb_name.Text = "0x00";
			tb_name.TextChanged += new EventHandler(GNSettingsChange);
			//
			// label2
			//
			label2.AutoSize = true;
			label2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			label2.Location = new Point(8, 64);
			label2.Name = "label2";
			label2.Size = new Size(40, 13);
			label2.TabIndex = 27;
			label2.Text = "Name";
			//
			// tb_type
			//
			tb_type.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tb_type.Location = new Point(128, 40);
			tb_type.Name = "tb_type";
			tb_type.Size = new Size(88, 21);
			tb_type.TabIndex = 26;
			tb_type.Text = "0x00";
			tb_type.TextChanged += new EventHandler(GNSettingsChange);
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			label1.Location = new Point(120, 24);
			label1.Name = "label1";
			label1.Size = new Size(67, 13);
			label1.TabIndex = 25;
			label1.Text = "Typecode:";
			//
			// tb_ver
			//
			tb_ver.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tb_ver.Location = new Point(16, 40);
			tb_ver.Name = "tb_ver";
			tb_ver.Size = new Size(88, 21);
			tb_ver.TabIndex = 24;
			tb_ver.Text = "0x00000000";
			tb_ver.TextChanged += new EventHandler(GNSettingsChange);
			//
			// label28
			//
			label28.AutoSize = true;
			label28.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			label28.Location = new Point(8, 24);
			label28.Name = "label28";
			label28.Size = new Size(55, 13);
			label28.TabIndex = 23;
			label28.Text = "Version:";
			//
			// Extension
			//
			BackColor = SystemColors.ControlLightLight;
			Controls.Add(gbIems);
			Controls.Add(groupBox10);
			Location = new Point(4, 22);
			Name = "tExtension";
			Size = new Size(792, 302);
			Text = "Extension";
			gbIems.ResumeLayout(false);
			gbIems.PerformLayout();
			gbfloat.ResumeLayout(false);
			gbfloat.PerformLayout();
			gbval.ResumeLayout(false);
			gbval.PerformLayout();
			gbar.ResumeLayout(false);
			gfootprintbar.ResumeLayout(false);
			gbstr.ResumeLayout(false);
			gbstr.PerformLayout();
			gbbin.ResumeLayout(false);
			gbbin.PerformLayout();
			gbrot.ResumeLayout(false);
			gbrot.PerformLayout();
			gbtrans.ResumeLayout(false);
			gbtrans.PerformLayout();
			groupBox10.ResumeLayout(false);
			groupBox10.PerformLayout();
			ResumeLayout(false);
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
			gbval.Visible = false;
			gbar.Visible = false;
			gfootprintbar.Visible = false;
			gbfloat.Visible = false;
			gbbin.Visible = false;
			gbrot.Visible = false;
			gbstr.Visible = false;
			gbtrans.Visible = false;
		}

		internal void ShowGroup(GroupBox gb)
		{
			gb.Left = lb_items.Left + lb_items.Width + 8;
			gb.Top = tb_itemname.Top + tb_itemname.Height + 4;
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
						ShowGroup(gbval);
						break;
					}
					case ExtensionItem.ItemTypes.Float:
					{
						tbfloat.Text = ei.Single.ToString();
						;
						ShowGroup(gbfloat);
						break;
					}
					case ExtensionItem.ItemTypes.Translation:
					{
						tbtrans1.Text = ei.Translation.X.ToString("N6");
						tbtrans2.Text = ei.Translation.Y.ToString("N6");
						tbtrans3.Text = ei.Translation.Z.ToString("N6");
						ShowGroup(gbtrans);
						break;
					}
					case ExtensionItem.ItemTypes.String:
					{
						tbstr.Text = ei.String;
						ShowGroup(gbstr);
						break;
					}
					case ExtensionItem.ItemTypes.Rotation:
					{
						tbrot1.Text = ei.Rotation.X.ToString("N6");
						tbrot2.Text = ei.Rotation.Y.ToString("N6");
						tbrot3.Text = ei.Rotation.Z.ToString("N6");
						tbrot4.Text = ei.Rotation.W.ToString("N6");
						ShowGroup(gbrot);
						break;
					}
					case ExtensionItem.ItemTypes.Binary:
					{
						tbbin.Text = Helper.BytesToHexList(ei.Data);
						ShowGroup(gbbin);
						break;
					}
					case ExtensionItem.ItemTypes.Array:
					{
						Plugin.Extension ext = (Plugin.Extension)Tag;

						if (ext.VarName.Equals("footprint"))
						{
							gfootprintbar.Controls.Add(btfootprintedit);
							gfootprintbar.Controls.Add(btedit);
							ShowGroup(gfootprintbar);
						}
						else
						{
							gbar.Controls.Add(btedit);
							ShowGroup(gbar);
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
				Form f = new Form
				{
					Text = Localization.GetString("Sub Array Editor"),
					ShowInTaskbar = false,
					FormBorderStyle = FormBorderStyle.FixedToolWindow,
					Size = new Size(840, 368)
				};
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

				ei.Items = (List<ExtensionItem>)fe.gbIems.Tag;
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
				Form f = new Form
				{
					Text = Localization.GetString("Sub Array Editor"),
					ShowInTaskbar = false,
					FormBorderStyle = FormBorderStyle.FixedToolWindow
				};

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
					windowWidth = (boxsize * (maxx - minx + 1)) + 6;
				}
				else
				{
					windowWidth = 702;
					windowHeight += 22;
				}
				if (maxy - miny <= 3)
				{
					windowHeight += (boxsize * (maxy - miny + 1)) + 23;
				}
				else
				{
					windowHeight += 702;
					windowWidth += 22;
				}

				f.Size = new Size(windowWidth, windowHeight);
				Panel scroller = new Panel
				{
					Height = f.Height - 22,
					Width = f.Width - 5,
					AutoScroll = true
				};
				f.Controls.Add(scroller);

				for (int i = 4; i < ei.Items.Count; i++)
				{
					ExtensionItem item = ei.Items[i];
					string[] a = item.Name.Split(new char[] { '(', ',', ')' });

					int tilex = int.Parse(a[1]) - minx;
					int tiley = int.Parse(a[2]) - miny;

					GroupBox gb = new GroupBox
					{
						Left = tilex * boxsize,
						Top = tiley * boxsize,
						Width = boxsize,
						Height = boxsize,
						Name = item.Name
					};

					UnPackFootprint(gb, item);
					scroller.Controls.Add(gb);
				}

				f.ShowDialog();

				for (int i = 4; i < ei.Items.Count; i++)
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
					CheckBox cb = new CheckBox
					{
						Width = 14,
						Height = 14
					};
					cb.Left = k * cb.Width;
					cb.Top = j * 7;
					cb.Name = "cb." + j + "." + k + ".2";
					int isSet = part2 & 1;
					cb.Checked = isSet == 1;
					gb.Controls.Add(cb);
					part2 >>= 1;
				}
				for (int k = 0; k < 8; k++)
				{
					CheckBox cb = new CheckBox
					{
						Width = 14,
						Height = 14
					};
					cb.Left = (8 * cb.Width) + (k * cb.Width);
					cb.Top = j * 7;
					cb.Name = "cb." + j + "." + k + ".1";
					int isSet = part1 & 1;
					cb.Checked = isSet == 1;
					gb.Controls.Add(cb);
					part1 >>= 1;
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
					string name = "cb." + j + "." + (7 - k) + ".1";
					int index = gb.Controls.IndexOfKey(name);
					CheckBox cb = (CheckBox)gb.Controls[index];

					part1 <<= 1;
					if (cb.Checked)
					{
						part1 |= 1;
					}
				}
				for (int k = 0; k < 8; k++)
				{
					string name = "cb." + j + "." + (7 - k) + ".2";
					int index = gb.Controls.IndexOfKey(name);
					CheckBox cb = (CheckBox)gb.Controls[index];

					part2 <<= 1;
					if (cb.Checked)
					{
						part2 |= 1;
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
				List<ExtensionItem> list = (List<ExtensionItem>)gbIems.Tag;
				ExtensionItem ei = (ExtensionItem)
					lb_items.Items[lb_items.SelectedIndex];

				list.Remove(ei);
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
				List<ExtensionItem> list = (List<ExtensionItem>)gbIems.Tag;
				ExtensionItem ei = new ExtensionItem
				{
					Typecode = (ExtensionItem.ItemTypes)
					cbtype.Items[cbtype.SelectedIndex]
				};

				list.Add(ei);
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
