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
using System.Collections;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for WantsForm.
	/// </summary>
	public class WantsForm : Form
	{
		private Panel panel2;
		private Label label27;
		internal Panel wantsPanel;
		internal TabControl tabControl1;
		internal System.Windows.Forms.TabPage tblife;
		private System.Windows.Forms.TabPage tbwant;
		private System.Windows.Forms.TabPage tbfear;
		private System.Windows.Forms.TabPage tbhist;
		internal ImageList iwant;
		internal ImageList ifear;
		internal ImageList ihist;
		internal ImageList ilife;
		internal ListView lvwant;
		internal ListView lvfear;
		internal ListView lvlife;
		internal TreeView tvhist;
		internal Label lbsimname;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private TextBox tbversion;
		private TextBox tbguid;
		private TextBox tbval;
		private TextBox tbprop;
		private TextBox tbsiminst;
		private TextBox tbindex;
		private TextBox tbunknown1;
		internal ComboBox cbtype;
		private TextBox tbunknown2;
		private TextBox tbpoints;
		private GroupBox gbprop;
		private PictureBox pb;
		private TreeView tv;
		internal ImageList itv;
		private LinkLabel linkLabel1;
		private CheckBox cblock;
		private ComboBox cbsel;
		private System.ComponentModel.IContainer components;

		public WantsForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			wrapper = null;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
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
			components = new System.ComponentModel.Container();
			wantsPanel = new Panel();
			linkLabel1 = new LinkLabel();
			gbprop = new GroupBox();
			cbsel = new ComboBox();
			cblock = new CheckBox();
			tv = new TreeView();
			itv = new ImageList(components);
			cbtype = new ComboBox();
			tbpoints = new TextBox();
			tbunknown2 = new TextBox();
			tbunknown1 = new TextBox();
			tbindex = new TextBox();
			tbsiminst = new TextBox();
			tbprop = new TextBox();
			tbval = new TextBox();
			tbguid = new TextBox();
			tbversion = new TextBox();
			label10 = new Label();
			label9 = new Label();
			label8 = new Label();
			label7 = new Label();
			label6 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			pb = new PictureBox();
			label5 = new Label();
			tabControl1 = new TabControl();
			tbwant = new System.Windows.Forms.TabPage();
			lvwant = new ListView();
			iwant = new ImageList(components);
			tbfear = new System.Windows.Forms.TabPage();
			lvfear = new ListView();
			ifear = new ImageList(components);
			tbhist = new System.Windows.Forms.TabPage();
			tvhist = new TreeView();
			ihist = new ImageList(components);
			tblife = new System.Windows.Forms.TabPage();
			lvlife = new ListView();
			ilife = new ImageList(components);
			panel2 = new Panel();
			lbsimname = new Label();
			label27 = new Label();
			wantsPanel.SuspendLayout();
			gbprop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pb)).BeginInit();
			tabControl1.SuspendLayout();
			tbwant.SuspendLayout();
			tbfear.SuspendLayout();
			tbhist.SuspendLayout();
			tblife.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			//
			// wantsPanel
			//
			wantsPanel.AutoScroll = true;
			wantsPanel.BackColor = System.Drawing.Color.Transparent;
			wantsPanel.Controls.Add(gbprop);
			wantsPanel.Controls.Add(tabControl1);
			wantsPanel.Controls.Add(panel2);
			wantsPanel.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			wantsPanel.Location = new System.Drawing.Point(16, 8);
			wantsPanel.Name = "wantsPanel";
			wantsPanel.Size = new System.Drawing.Size(768, 344);
			wantsPanel.TabIndex = 20;
			//
			// linkLabel1
			//
			linkLabel1.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			linkLabel1.AutoSize = true;
			linkLabel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			linkLabel1.Location = new System.Drawing.Point(707, 319);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(56, 13);
			linkLabel1.TabIndex = 3;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Commit";
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Commit);
			//
			// gbprop
			//
			gbprop.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			gbprop.BackColor = System.Drawing.Color.Transparent;
			gbprop.Controls.Add(cbsel);
			gbprop.Controls.Add(cblock);
			gbprop.Controls.Add(tv);
			gbprop.Controls.Add(cbtype);
			gbprop.Controls.Add(tbpoints);
			gbprop.Controls.Add(tbunknown2);
			gbprop.Controls.Add(tbunknown1);
			gbprop.Controls.Add(tbindex);
			gbprop.Controls.Add(tbsiminst);
			gbprop.Controls.Add(tbprop);
			gbprop.Controls.Add(tbval);
			gbprop.Controls.Add(tbguid);
			gbprop.Controls.Add(tbversion);
			gbprop.Controls.Add(label10);
			gbprop.Controls.Add(label9);
			gbprop.Controls.Add(label8);
			gbprop.Controls.Add(label7);
			gbprop.Controls.Add(label6);
			gbprop.Controls.Add(label4);
			gbprop.Controls.Add(label3);
			gbprop.Controls.Add(label2);
			gbprop.Controls.Add(label1);
			gbprop.Controls.Add(pb);
			gbprop.Controls.Add(label5);
			gbprop.Enabled = false;
			gbprop.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			gbprop.Location = new System.Drawing.Point(336, 32);
			gbprop.Name = "gbprop";
			gbprop.Size = new System.Drawing.Size(424, 284);
			gbprop.TabIndex = 2;
			gbprop.TabStop = false;
			gbprop.Text = "Properties:";
			//
			// cbsel
			//
			cbsel.Anchor =

					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			cbsel.DropDownStyle = ComboBoxStyle.DropDownList;
			cbsel.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbsel.Location = new System.Drawing.Point(200, 256);
			cbsel.Name = "cbsel";
			cbsel.Size = new System.Drawing.Size(120, 21);
			cbsel.TabIndex = 23;
			cbsel.SelectedIndexChanged += new EventHandler(
				cbsel_SelectedIndexChanged
			);
			//
			// cblock
			//
			cblock.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			cblock.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			cblock.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cblock.Location = new System.Drawing.Point(272, 184);
			cblock.Name = "cblock";
			cblock.Size = new System.Drawing.Size(72, 24);
			cblock.TabIndex = 22;
			cblock.Text = "Locked:";
			cblock.CheckedChanged += new EventHandler(ChangedText);
			//
			// tv
			//
			tv.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tv.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tv.HideSelection = false;
			tv.ImageIndex = 0;
			tv.ImageList = itv;
			tv.Location = new System.Drawing.Point(8, 80);
			tv.Name = "tv";
			tv.SelectedImageIndex = 0;
			tv.Size = new System.Drawing.Size(224, 168);
			tv.TabIndex = 21;
			tv.AfterSelect += new TreeViewEventHandler(
				SelectWant
			);
			//
			// itv
			//
			itv.ColorDepth = ColorDepth.Depth32Bit;
			itv.ImageSize = new System.Drawing.Size(16, 16);
			itv.TransparentColor = System.Drawing.Color.Transparent;
			//
			// cbtype
			//
			cbtype.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			cbtype.DropDownStyle = ComboBoxStyle.DropDownList;
			cbtype.Enabled = false;
			cbtype.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbtype.Location = new System.Drawing.Point(56, 256);
			cbtype.Name = "cbtype";
			cbtype.Size = new System.Drawing.Size(88, 21);
			cbtype.TabIndex = 19;
			cbtype.SelectedIndexChanged += new EventHandler(
				ChangeType
			);
			//
			// tbpoints
			//
			tbpoints.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tbpoints.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbpoints.Location = new System.Drawing.Point(328, 160);
			tbpoints.Name = "tbpoints";
			tbpoints.Size = new System.Drawing.Size(88, 21);
			tbpoints.TabIndex = 18;
			tbpoints.Text = "0";
			tbpoints.TextChanged += new EventHandler(ChangedText);
			//
			// tbunknown2
			//
			tbunknown2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tbunknown2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbunknown2.Location = new System.Drawing.Point(328, 136);
			tbunknown2.Name = "tbunknown2";
			tbunknown2.Size = new System.Drawing.Size(88, 21);
			tbunknown2.TabIndex = 17;
			tbunknown2.Text = "0";
			tbunknown2.TextChanged += new EventHandler(ChangedText);
			//
			// tbunknown1
			//
			tbunknown1.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tbunknown1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbunknown1.Location = new System.Drawing.Point(328, 104);
			tbunknown1.Name = "tbunknown1";
			tbunknown1.ReadOnly = true;
			tbunknown1.Size = new System.Drawing.Size(56, 21);
			tbunknown1.TabIndex = 16;
			tbunknown1.Text = "0x00";
			//
			// tbindex
			//
			tbindex.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tbindex.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbindex.Location = new System.Drawing.Point(328, 80);
			tbindex.Name = "tbindex";
			tbindex.ReadOnly = true;
			tbindex.Size = new System.Drawing.Size(88, 21);
			tbindex.TabIndex = 15;
			tbindex.Text = "0x00000000";
			//
			// tbsiminst
			//
			tbsiminst.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tbsiminst.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbsiminst.Location = new System.Drawing.Point(328, 48);
			tbsiminst.Name = "tbsiminst";
			tbsiminst.ReadOnly = true;
			tbsiminst.Size = new System.Drawing.Size(56, 21);
			tbsiminst.TabIndex = 14;
			tbsiminst.Text = "0x0000";
			//
			// tbprop
			//
			tbprop.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			tbprop.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbprop.Location = new System.Drawing.Point(328, 232);
			tbprop.Name = "tbprop";
			tbprop.Size = new System.Drawing.Size(88, 21);
			tbprop.TabIndex = 13;
			tbprop.Text = "0";
			tbprop.TextChanged += new EventHandler(ChangedText);
			//
			// tbval
			//
			tbval.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			tbval.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbval.Location = new System.Drawing.Point(328, 256);
			tbval.Name = "tbval";
			tbval.Size = new System.Drawing.Size(88, 21);
			tbval.TabIndex = 12;
			tbval.Text = "0x00000000";
			tbval.TextChanged += new EventHandler(ChangedText);
			//
			// tbguid
			//
			tbguid.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbguid.Location = new System.Drawing.Point(88, 56);
			tbguid.Name = "tbguid";
			tbguid.ReadOnly = true;
			tbguid.Size = new System.Drawing.Size(88, 21);
			tbguid.TabIndex = 11;
			tbguid.Text = "0x00000000";
			//
			// tbversion
			//
			tbversion.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			tbversion.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbversion.Location = new System.Drawing.Point(328, 24);
			tbversion.Name = "tbversion";
			tbversion.ReadOnly = true;
			tbversion.Size = new System.Drawing.Size(88, 21);
			tbversion.TabIndex = 10;
			tbversion.Text = "0x00000000";
			//
			// label10
			//
			label10.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label10.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label10.Location = new System.Drawing.Point(248, 136);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(72, 24);
			label10.TabIndex = 9;
			label10.Text = "Influence:";
			label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label9
			//
			label9.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label9.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label9.Location = new System.Drawing.Point(248, 104);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(72, 24);
			label9.TabIndex = 8;
			label9.Text = "Flags:";
			label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label8
			//
			label8.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label8.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label8.Location = new System.Drawing.Point(264, 160);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(56, 24);
			label8.TabIndex = 7;
			label8.Text = "Points:";
			label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label7
			//
			label7.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label7.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label7.Location = new System.Drawing.Point(272, 80);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(48, 24);
			label7.TabIndex = 6;
			label7.Text = "Index:";
			label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label6
			//
			label6.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Right
					)

			;
			label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label6.Location = new System.Drawing.Point(248, 232);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(72, 24);
			label6.TabIndex = 5;
			label6.Text = "Amount:";
			label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label4
			//
			label4.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(8, 256);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(40, 24);
			label4.TabIndex = 3;
			label4.Text = "Type:";
			label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label3
			//
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(8, 56);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(80, 24);
			label3.TabIndex = 2;
			label3.Text = "Want GUID:";
			label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// label2
			//
			label2.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(232, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(88, 24);
			label2.TabIndex = 1;
			label2.Text = "Sim Inst.:";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label1
			//
			label1.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(224, 24);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(100, 24);
			label1.TabIndex = 0;
			label1.Text = "Version:";
			label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// pb
			//
			pb.Location = new System.Drawing.Point(184, 24);
			pb.Name = "pb";
			pb.Size = new System.Drawing.Size(56, 56);
			pb.SizeMode = PictureBoxSizeMode.CenterImage;
			pb.TabIndex = 20;
			pb.TabStop = false;
			//
			// label5
			//
			label5.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(144, 256);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(48, 24);
			label5.TabIndex = 4;
			label5.Text = "Value:";
			label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tabControl1
			//
			tabControl1.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			tabControl1.Controls.Add(tbwant);
			tabControl1.Controls.Add(tbfear);
			tabControl1.Controls.Add(tbhist);
			tabControl1.Controls.Add(tblife);
			tabControl1.Location = new System.Drawing.Point(8, 32);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(320, 304);
			tabControl1.TabIndex = 1;
			tabControl1.SelectedIndexChanged += new EventHandler(
				SelectTab
			);
			//
			// tbwant
			//
			tbwant.Controls.Add(lvwant);
			tbwant.Location = new System.Drawing.Point(4, 22);
			tbwant.Name = "tbwant";
			tbwant.Size = new System.Drawing.Size(312, 278);
			tbwant.TabIndex = 1;
			tbwant.Text = "Wants";
			//
			// lvwant
			//
			lvwant.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lvwant.HideSelection = false;
			lvwant.LargeImageList = iwant;
			lvwant.Location = new System.Drawing.Point(8, 8);
			lvwant.MultiSelect = false;
			lvwant.Name = "lvwant";
			lvwant.Size = new System.Drawing.Size(296, 264);
			lvwant.TabIndex = 0;
			lvwant.UseCompatibleStateImageBehavior = false;
			lvwant.SelectedIndexChanged += new EventHandler(
				SelectWant
			);
			//
			// iwant
			//
			iwant.ColorDepth = ColorDepth.Depth32Bit;
			iwant.ImageSize = new System.Drawing.Size(44, 44);
			iwant.TransparentColor = System.Drawing.Color.Transparent;
			//
			// tbfear
			//
			tbfear.Controls.Add(lvfear);
			tbfear.Location = new System.Drawing.Point(4, 22);
			tbfear.Name = "tbfear";
			tbfear.Size = new System.Drawing.Size(312, 278);
			tbfear.TabIndex = 2;
			tbfear.Text = "Fears";
			//
			// lvfear
			//
			lvfear.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lvfear.HideSelection = false;
			lvfear.LargeImageList = ifear;
			lvfear.Location = new System.Drawing.Point(8, 8);
			lvfear.MultiSelect = false;
			lvfear.Name = "lvfear";
			lvfear.Size = new System.Drawing.Size(296, 264);
			lvfear.TabIndex = 1;
			lvfear.UseCompatibleStateImageBehavior = false;
			lvfear.SelectedIndexChanged += new EventHandler(
				SelectWant
			);
			//
			// ifear
			//
			ifear.ColorDepth = ColorDepth.Depth32Bit;
			ifear.ImageSize = new System.Drawing.Size(44, 44);
			ifear.TransparentColor = System.Drawing.Color.Transparent;
			//
			// tbhist
			//
			tbhist.Controls.Add(tvhist);
			tbhist.Location = new System.Drawing.Point(4, 22);
			tbhist.Name = "tbhist";
			tbhist.Size = new System.Drawing.Size(312, 278);
			tbhist.TabIndex = 3;
			tbhist.Text = "History";
			//
			// tvhist
			//
			tvhist.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tvhist.HideSelection = false;
			tvhist.ImageIndex = 0;
			tvhist.ImageList = ihist;
			tvhist.Location = new System.Drawing.Point(8, 8);
			tvhist.Name = "tvhist";
			tvhist.SelectedImageIndex = 0;
			tvhist.Size = new System.Drawing.Size(296, 264);
			tvhist.TabIndex = 0;
			tvhist.AfterSelect += new TreeViewEventHandler(
				SeletTv
			);
			//
			// ihist
			//
			ihist.ColorDepth = ColorDepth.Depth32Bit;
			ihist.ImageSize = new System.Drawing.Size(16, 16);
			ihist.TransparentColor = System.Drawing.Color.Transparent;
			//
			// tblife
			//
			tblife.Controls.Add(lvlife);
			tblife.Location = new System.Drawing.Point(4, 22);
			tblife.Name = "tblife";
			tblife.Size = new System.Drawing.Size(312, 278);
			tblife.TabIndex = 0;
			tblife.Text = "Lifetime Wants";
			//
			// lvlife
			//
			lvlife.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			lvlife.HideSelection = false;
			lvlife.LargeImageList = ilife;
			lvlife.Location = new System.Drawing.Point(8, 8);
			lvlife.MultiSelect = false;
			lvlife.Name = "lvlife";
			lvlife.Size = new System.Drawing.Size(296, 264);
			lvlife.TabIndex = 1;
			lvlife.UseCompatibleStateImageBehavior = false;
			lvlife.SelectedIndexChanged += new EventHandler(
				SelectWant
			);
			//
			// ilife
			//
			ilife.ColorDepth = ColorDepth.Depth32Bit;
			ilife.ImageSize = new System.Drawing.Size(44, 44);
			ilife.TransparentColor = System.Drawing.Color.Transparent;
			//
			// panel2
			//
			panel2.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			panel2.Controls.Add(lbsimname);
			panel2.Controls.Add(label27);
			panel2.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Bold
			);
			panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			panel2.Location = new System.Drawing.Point(0, 0);
			panel2.Margin = new Padding(0);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(768, 24);
			panel2.TabIndex = 0;
			//
			// lbsimname
			//
			lbsimname.AutoSize = true;
			lbsimname.BackColor = System.Drawing.Color.Transparent;
			lbsimname.Cursor = Cursors.Hand;
			lbsimname.Font = new System.Drawing.Font(
				"Verdana",
				9.75F,
				System.Drawing.FontStyle.Underline,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			lbsimname.ImeMode = ImeMode.NoControl;
			lbsimname.Location = new System.Drawing.Point(260, 4);
			lbsimname.Name = "lbsimname";
			lbsimname.Size = new System.Drawing.Size(29, 16);
			lbsimname.TabIndex = 1;
			lbsimname.Text = "---";
			lbsimname.Click += new EventHandler(lbsimname_Click);
			//
			// label27
			//
			label27.AutoSize = true;
			label27.ImeMode = ImeMode.NoControl;
			label27.Location = new System.Drawing.Point(0, 4);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(208, 16);
			label27.TabIndex = 0;
			label27.Text = "Wants and Fears Viewer for";
			//
			// WantsForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(864, 358);
			Controls.Add(wantsPanel);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Name = "WantsForm";
			Text = "WantsForm";
			wantsPanel.ResumeLayout(false);
			gbprop.ResumeLayout(false);
			gbprop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(pb)).EndInit();
			tabControl1.ResumeLayout(false);
			tbwant.ResumeLayout(false);
			tbfear.ResumeLayout(false);
			tbhist.ResumeLayout(false);
			tblife.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		internal Want wrapper;

		internal void AddWantToList(ListView lv, ImageList il, WantItem wnt)
		{
			ListViewItem lvi = new ListViewItem
			{
				Text = wnt.ToString(),
				Tag = wnt
			};

			if (wnt.Information.Icon != null)
			{
				lvi.ImageIndex = il.Images.Count;
				il.Images.Add(wnt.Information.Icon);
				Wait.Message = wnt.ToString();
				Wait.Image = wnt.Information.Icon;
			}

			lv.Items.Add(lvi);
		}

		void LoadHistory()
		{
			lasttve = null;
			Wait.SubStart();
			tvhist.BeginUpdate();
			foreach (WantItemContainer wic in wrapper.History)
			{
				AddWant(tvhist, wic);
			}

			tvhist.EndUpdate();
			Wait.SubStop();
		}

		internal void AddWant(TreeView tv, WantItemContainer wc)
		{
			TreeNode parent = new TreeNode(wc.ToString())
			{
				Tag = wc
			};

			if (wc.Information.Icon != null)
			{
				parent.SelectedImageIndex = ihist.Images.Count;
				parent.ImageIndex = ihist.Images.Count;
				ihist.Images.Add(wc.Information.Icon);

				Wait.Message = wc.ToString();
				Wait.Image = wc.Information.Icon;
			}

			foreach (WantItem wi in wc.Items)
			{
				TreeNode node = new TreeNode(wi.ToString())
				{
					ImageIndex = parent.ImageIndex,
					SelectedImageIndex = parent.SelectedImageIndex,
					Tag = wi
				};

				parent.Nodes.Add(node);
			}

			tv.Nodes.Add(parent);
		}

		void SelectTvNode(WantItem wi)
		{
			foreach (TreeNode parent in tv.Nodes)
			{
				foreach (TreeNode node in parent.Nodes)
				{
					WantInformation winfo = (WantInformation)node.Tag;
					if (wi != null)
					{
						if (winfo.Guid == wi.Guid)
						{
							tv.SelectedNode = node;
							node.Parent.Expand();
							node.EnsureVisible();
							return;
						}
					}
				}
			}
		}

		void ShowWantItem(WantItem wi)
		{
			lastwi = wi;

			tbversion.Text = "0x" + Helper.HexString(wi.Version);
			tbsiminst.Text = "0x" + Helper.HexString(wi.SimInstance);
			tbguid.Text = "0x" + Helper.HexString(wi.Guid);
			tbprop.Text = wi.Property.ToString();
			tbindex.Text = "0x" + Helper.HexString(wi.Index);
			tbpoints.Text = wi.Score.ToString();
			tbunknown1.Text = "0x" + Helper.HexString((byte)wi.Flag.Value);
			tbunknown2.Text = wi.Influence.ToString();
			cblock.Checked = wi.Flag.Locked;

			pb.Image = wi.Information.Icon;

			cbtype.SelectedIndex = 0;
			for (int i = 1; i < cbtype.Items.Count; i++)
			{
				WantType wt = (WantType)cbtype.Items[i];
				if (wt == wi.Type)
				{
					cbtype.SelectedIndex = i;
					break;
				}
			}

			tbval.Text = "0x" + Helper.HexString(wi.Value);

			//if (this.Tag!=null) return;
			Tag = true;
			try
			{
				SelectTvNode(wi);
			}
			finally
			{
				Tag = null;
			}
		}

		internal WantItem lastwi;
		internal ListViewItem lastlvi;

		private void SelectWant(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			gbprop.Enabled = false;
			lastwi = null;
			if (lv.SelectedItems.Count == 0)
			{
				return;
			}

			gbprop.Enabled = true;

			WantItem wi = (WantItem)lv.SelectedItems[0].Tag;
			lastlvi = lv.SelectedItems[0];

			if (Tag != null)
			{
				return;
			}

			Tag = true;
			ShowWantItem(wi);
			Tag = null;
		}

		private void cbsel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbsel.SelectedIndex < 0)
			{
				return;
			}

			Data.Alias a = (Data.Alias)cbsel.Items[cbsel.SelectedIndex];
			tbval.Text = "0x" + Helper.HexString(a.Id);
		}

		private void ChangeType(object sender, EventArgs e)
		{
			cbsel.Items.Clear();
			cbsel.Sorted = false;
			ArrayList list = WantLoader.WantNameLoader.GetNames(
				(WantType)cbtype.Items[cbtype.SelectedIndex]
			);
			foreach (Data.Alias a in list)
			{
				cbsel.Items.Add(a);
			}

			cbsel.Sorted = true;

			int ct = 0;
			foreach (Data.Alias a in cbsel.Items)
			{
				if (lastwi != null)
				{
					if (a.Id == lastwi.Value)
					{
						cbsel.SelectedIndex = ct;
					}
				}

				ct++;
			}
		}

		private void lbsimname_Click(object sender, EventArgs e)
		{
			try
			{
				if (Helper.StartedGui == Executable.Classic && wrapper.Changed)
				{
					if (
						MessageBox.Show(
							Localization.Manager.GetString("open_wnt_from_sdsc"),
							Localization.Manager.GetString("question"),
							MessageBoxButtons.YesNo
						) == DialogResult.Yes
					)
					{
						wrapper.SynchronizeUserData();
					}
				}

				//Open File

				Interfaces.Files.IPackedFileDescriptor pfd =
					wrapper.Package.NewDescriptor(
						Data.MetaData.SIM_DESCRIPTION_FILE,
						wrapper.FileDescriptor.SubType,
						wrapper.FileDescriptor.Group,
						wrapper.FileDescriptor.Instance
					); //try a W&f File
				pfd = wrapper.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, wrapper.Package);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void Commit(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			wrapper.SynchronizeUserData();
		}

		private void ChangedText(object sender, EventArgs e)
		{
			if (lastwi == null)
			{
				return;
			}

			if (Tag != null)
			{
				return;
			}

			Tag = true;

			try
			{
				lastwi.Influence = Convert.ToInt32(tbunknown2.Text);
				lastwi.Score = Convert.ToInt32(tbpoints.Text);
				lastwi.Value = Convert.ToUInt32(tbval.Text, 16);
				lastwi.Property = Convert.ToUInt16(tbprop.Text);

				lastwi.Flag.Locked = cblock.Checked;
				wrapper.Changed = true;

				if (lastlvi != null)
				{
					lastlvi.Text = lastwi.ToString();
				}
			}
			catch { }
			finally
			{
				Tag = null;
			}
		}

		private void SelectTab(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 2 && tvhist.Nodes.Count == 0)
			{
				LoadHistory();
			}

			if (tabControl1.SelectedIndex == 0)
			{
				SelectWant(lvwant, (EventArgs)null);
			}
			else if (tabControl1.SelectedIndex == 1)
			{
				SelectWant(lvfear, (EventArgs)null);
			}
			else if (tabControl1.SelectedIndex == 3)
			{
				SelectWant(lvlife, (EventArgs)null);
			}
			else
			{
				SeletTv(null, lasttve);
			}
		}

		TreeViewEventArgs lasttve;

		private void SeletTv(object sender, TreeViewEventArgs e)
		{
			lastwi = null;
			gbprop.Enabled = false;
			if (e == null)
			{
				return;
			}

			if (e.Node == null)
			{
				return;
			}

			lasttve = e;
			TreeNode node = e.Node;

			if (node.Tag.GetType() == typeof(WantItem))
			{
				//gbprop.Enabled = true;

				WantItem wi = (WantItem)node.Tag;
				ShowWantItem(wi);
				//lastwi = null;
			}
		}

		internal void ListWants()
		{
			if (tv.Nodes.Count > 0)
			{
				return;
			}

			itv.Images.Add(
				new System.Drawing.Bitmap(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.subitems.png")
				)
			);
			itv.Images.Add(
				new System.Drawing.Bitmap(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.nothumb.png")
				)
			);
			Wait.SubStart();
			Hashtable ht = new Hashtable();
			string max = " / " + WantLoader.Wants.Keys.Count.ToString();
			int ct = 0;
			Wait.MaxProgress = WantLoader.Wants.Keys.Count;
			Wait.Message = "Loading Wants";
			foreach (uint guid in WantLoader.Wants.Keys)
			{
				ct++;
				WantInformation wi = WantInformation.LoadWant(guid);
				ArrayList al = (ArrayList)ht[wi.XWant.Folder];
				if (al == null)
				{
					al = new ArrayList();
					ht[wi.XWant.Folder] = al;
				}

				wi.prefix = "    ";
				al.Add(wi);

				if ((ct % 3) == 1)
				{
					Wait.Image = wi.Icon;
					Wait.Progress = ct;
				}
			}

			foreach (string k in ht.Keys)
			{
				TreeNode parent = new TreeNode(k);

				foreach (WantInformation wi in (ArrayList)ht[k])
				{
					TreeNode node = new TreeNode(wi.Name)
					{
						Tag = wi
					};

					if (wi.Icon != null)
					{
						node.ImageIndex = itv.Images.Count;
						itv.Images.Add(wi.Icon);
					}
					else
					{
						node.ImageIndex = 1;
					}
					node.SelectedImageIndex = node.ImageIndex;
					parent.Nodes.Add(node);
				}
				tv.Nodes.Add(parent);
			}
			tv.Sorted = true;

			Wait.SubStop();
		}

		private void SelectWant(object sender, TreeViewEventArgs e)
		{
			if (Tag != null)
			{
				return;
			}

			if (e == null)
			{
				return;
			}

			if (e.Node == null)
			{
				return;
			}

			if (e.Node.Tag == null)
			{
				return;
			}

			WantInformation wi = (WantInformation)e.Node.Tag;
			tbguid.Text = "0x" + Helper.HexString(wi.Guid);
			pb.Image = wi.Icon;

			if (lastlvi != null)
			{
				if (lastlvi.ImageIndex >= 0)
				{
					lastlvi.ListView.LargeImageList.Images[lastlvi.ImageIndex] =
						ImageLoader.Preview(
							wi.Icon,
							lastlvi.ListView.LargeImageList.ImageSize
						);
				}

				lastlvi.Text = wi.Name;
			}

			if (lastwi != null)
			{
				lastwi.Guid = wi.Guid;
				lastwi.Type = wi.XWant.WantType;
				lastwi.Influence = wi.XWant.Influence;
				lastwi.Score = wi.XWant.Score;
				lastlvi.Text = lastwi.ToString();

				wrapper.Changed = true;

				ShowWantItem(lastwi);
			}

			lastlvi?.ListView.Refresh();
		}
	}
}
