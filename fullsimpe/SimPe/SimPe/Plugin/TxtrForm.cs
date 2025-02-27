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

using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for TxtrForm.
	/// </summary>
	public class TxtrForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TxtrForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			tbwidth.ReadOnly = true;
			tbheight.ReadOnly = true;
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
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(TxtrForm));
			this.txtrPanel = new Panel();
			this.linkLabel4 = new LinkLabel();
			this.linkLabel3 = new LinkLabel();
			this.linkLabel1 = new LinkLabel();
			this.tblevel = new TextBox();
			this.label8 = new Label();
			this.linkLabel2 = new LinkLabel();
			this.lldel = new LinkLabel();
			this.tblifo = new TextBox();
			this.label6 = new Label();
			this.label5 = new Label();
			this.tbheight = new TextBox();
			this.tbwidth = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.cbformats = new ComboBox();
			this.tbflname = new TextBox();
			this.label2 = new Label();
			this.cbitem = new ComboBox();
			this.cbmipmaps = new ComboBox();
			this.panel1 = new Panel();
			this.label7 = new Label();
			this.pb = new PictureBox();
			this.contextMenu1 = new ContextMenu();
			this.menuItem1 = new MenuItem();
			this.milifo = new MenuItem();
			this.menuItem4 = new MenuItem();
			this.menuItem6 = new MenuItem();
			this.menuItem7 = new MenuItem();
			this.mibuild = new MenuItem();
			this.menuItem3 = new MenuItem();
			this.menuItem2 = new MenuItem();
			this.menuItem5 = new MenuItem();
			this.lbimg = new ListBox();
			this.panel2 = new Panel();
			this.btex = new Button();
			this.btim = new Button();
			this.label1 = new Label();
			this.sfd = new SaveFileDialog();
			this.ofd = new OpenFileDialog();
			this.txtrPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			//
			// txtrPanel
			//
			this.txtrPanel.BackColor = Color.Transparent;
			this.txtrPanel.Controls.Add(this.linkLabel4);
			this.txtrPanel.Controls.Add(this.linkLabel3);
			this.txtrPanel.Controls.Add(this.linkLabel1);
			this.txtrPanel.Controls.Add(this.tblevel);
			this.txtrPanel.Controls.Add(this.label8);
			this.txtrPanel.Controls.Add(this.linkLabel2);
			this.txtrPanel.Controls.Add(this.lldel);
			this.txtrPanel.Controls.Add(this.tblifo);
			this.txtrPanel.Controls.Add(this.label6);
			this.txtrPanel.Controls.Add(this.label5);
			this.txtrPanel.Controls.Add(this.tbheight);
			this.txtrPanel.Controls.Add(this.tbwidth);
			this.txtrPanel.Controls.Add(this.label4);
			this.txtrPanel.Controls.Add(this.label3);
			this.txtrPanel.Controls.Add(this.cbformats);
			this.txtrPanel.Controls.Add(this.tbflname);
			this.txtrPanel.Controls.Add(this.label2);
			this.txtrPanel.Controls.Add(this.cbitem);
			this.txtrPanel.Controls.Add(this.cbmipmaps);
			this.txtrPanel.Controls.Add(this.panel1);
			this.txtrPanel.Controls.Add(this.lbimg);
			this.txtrPanel.Controls.Add(this.panel2);
			this.txtrPanel.Controls.Add(this.label1);
			this.txtrPanel.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.txtrPanel.Location = new Point(8, 8);
			this.txtrPanel.Name = "txtrPanel";
			this.txtrPanel.Size = new Size(768, 288);
			this.txtrPanel.TabIndex = 19;
			//
			// linkLabel4
			//
			this.linkLabel4.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)
				)
			);
			this.linkLabel4.AutoSize = true;
			this.linkLabel4.BackColor = Color.Transparent;
			this.linkLabel4.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.linkLabel4.LinkArea = new LinkArea(0, 5);
			this.linkLabel4.Location = new Point(200, 264);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Size = new Size(137, 18);
			this.linkLabel4.TabIndex = 24;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Text = "build default MipMap";
			this.linkLabel4.UseCompatibleTextRendering = true;
			this.linkLabel4.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.BuildMipMap
				);
			//
			// linkLabel3
			//
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.BackColor = Color.Transparent;
			this.linkLabel3.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.linkLabel3.Location = new Point(288, 88);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new Size(51, 13);
			this.linkLabel3.TabIndex = 23;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "fix TGI";
			this.linkLabel3.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(this.FixTGI);
			//
			// linkLabel1
			//
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.BackColor = Color.Transparent;
			this.linkLabel1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.linkLabel1.Location = new Point(344, 88);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new Size(85, 13);
			this.linkLabel1.TabIndex = 22;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "assign Hash";
			this.linkLabel1.Visible = false;
			this.linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.BuildFilename
				);
			//
			// tblevel
			//
			this.tblevel.Location = new Point(336, 134);
			this.tblevel.Name = "tblevel";
			this.tblevel.Size = new Size(88, 21);
			this.tblevel.TabIndex = 21;
			this.tblevel.TextChanged += new EventHandler(this.Changedlevel);
			//
			// label8
			//
			this.label8.AutoSize = true;
			this.label8.BackColor = Color.Transparent;
			this.label8.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.label8.Location = new Point(240, 136);
			this.label8.Name = "label8";
			this.label8.Size = new Size(98, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "MipMap Level:";
			//
			// linkLabel2
			//
			this.linkLabel2.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)
				)
			);
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.BackColor = Color.Transparent;
			this.linkLabel2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.linkLabel2.Location = new Point(344, 264);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new Size(31, 13);
			this.linkLabel2.TabIndex = 19;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "add";
			this.linkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(this.Add);
			//
			// lldel
			//
			this.lldel.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)
				)
			);
			this.lldel.AutoSize = true;
			this.lldel.BackColor = Color.Transparent;
			this.lldel.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.lldel.Location = new Point(380, 264);
			this.lldel.Name = "lldel";
			this.lldel.Size = new Size(48, 13);
			this.lldel.TabIndex = 18;
			this.lldel.TabStop = true;
			this.lldel.Text = "delete";
			this.lldel.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(this.Delete);
			//
			// tblifo
			//
			this.tblifo.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.tblifo.Location = new Point(440, 252);
			this.tblifo.Name = "tblifo";
			this.tblifo.Size = new Size(320, 21);
			this.tblifo.TabIndex = 16;
			this.tblifo.TextChanged += new EventHandler(this.SetLifo);
			//
			// label6
			//
			this.label6.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)
				)
			);
			this.label6.AutoSize = true;
			this.label6.BackColor = Color.Transparent;
			this.label6.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.label6.Location = new Point(432, 236);
			this.label6.Name = "label6";
			this.label6.Size = new Size(111, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "LIFO Reference:";
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.Transparent;
			this.label5.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.label5.Location = new Point(141, 136);
			this.label5.Name = "label5";
			this.label5.Size = new Size(15, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "x";
			//
			// tbheight
			//
			this.tbheight.Location = new Point(160, 134);
			this.tbheight.Name = "tbheight";
			this.tbheight.Size = new Size(56, 21);
			this.tbheight.TabIndex = 14;
			this.tbheight.TextChanged += new EventHandler(this.ChangedSize);
			//
			// tbwidth
			//
			this.tbwidth.Location = new Point(80, 134);
			this.tbwidth.Name = "tbwidth";
			this.tbwidth.Size = new Size(56, 21);
			this.tbwidth.TabIndex = 13;
			this.tbwidth.TextChanged += new EventHandler(this.ChangedSize);
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.BackColor = Color.Transparent;
			this.label4.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.label4.Location = new Point(43, 136);
			this.label4.Name = "label4";
			this.label4.Size = new Size(38, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Size:";
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.Transparent;
			this.label3.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.label3.Location = new Point(24, 112);
			this.label3.Name = "label3";
			this.label3.Size = new Size(58, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Format:";
			//
			// cbformats
			//
			this.cbformats.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbformats.Location = new Point(80, 108);
			this.cbformats.Name = "cbformats";
			this.cbformats.Size = new Size(344, 21);
			this.cbformats.TabIndex = 10;
			this.cbformats.SelectedIndexChanged += new EventHandler(
				this.ChangeFormat
			);
			//
			// tbflname
			//
			this.tbflname.Location = new Point(80, 56);
			this.tbflname.Name = "tbflname";
			this.tbflname.Size = new Size(344, 21);
			this.tbflname.TabIndex = 9;
			this.tbflname.TextChanged += new EventHandler(this.FileNameChanged);
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.Transparent;
			this.label2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.label2.Location = new Point(8, 36);
			this.label2.Name = "label2";
			this.label2.Size = new Size(71, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Filename:";
			//
			// cbitem
			//
			this.cbitem.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbitem.Location = new Point(80, 32);
			this.cbitem.Name = "cbitem";
			this.cbitem.Size = new Size(344, 21);
			this.cbitem.TabIndex = 7;
			this.cbitem.SelectedIndexChanged += new EventHandler(
				this.SelectItem
			);
			//
			// cbmipmaps
			//
			this.cbmipmaps.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbmipmaps.Location = new Point(80, 160);
			this.cbmipmaps.Name = "cbmipmaps";
			this.cbmipmaps.Size = new Size(344, 21);
			this.cbmipmaps.TabIndex = 5;
			this.cbmipmaps.SelectedIndexChanged += new EventHandler(
				this.SelectMipMapBlock
			);
			//
			// panel1
			//
			this.panel1.Anchor = (
				(AnchorStyles)(
					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.panel1.AutoScroll = true;
			this.panel1.AutoScrollMinSize = new Size(24, 24);
			this.panel1.BackColor = Color.Transparent;
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.pb);
			this.panel1.Location = new Point(432, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(328, 200);
			this.panel1.TabIndex = 4;
			//
			// label7
			//
			this.label7.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)
				)
			);
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Verdana", 8.25F);
			this.label7.ForeColor = SystemColors.ActiveCaptionText;
			this.label7.ImeMode = ImeMode.NoControl;
			this.label7.Location = new Point(8, 176);
			this.label7.Name = "label7";
			this.label7.Size = new Size(293, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Right click on the Image to get more Interactions.";
			//
			// pb
			//
			this.pb.BackColor = SystemColors.Control;
			this.pb.BackgroundImage = (
				(Image)(resources.GetObject("pb.BackgroundImage"))
			);
			this.pb.ContextMenu = this.contextMenu1;
			this.pb.Location = new Point(0, 0);
			this.pb.Name = "pb";
			this.pb.Size = new Size(100, 50);
			this.pb.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pb.TabIndex = 5;
			this.pb.TabStop = false;
			//
			// contextMenu1
			//
			this.contextMenu1.MenuItems.AddRange(
				new MenuItem[]
				{
					this.menuItem1,
					this.milifo,
					this.menuItem4,
					this.menuItem6,
					this.menuItem7,
					this.mibuild,
					this.menuItem3,
					this.menuItem2,
					this.menuItem5,
				}
			);
			this.contextMenu1.Popup += new EventHandler(this.ContextPopUp);
			//
			// menuItem1
			//
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "&Import...";
			this.menuItem1.Click += new EventHandler(this.btim_Click);
			//
			// milifo
			//
			this.milifo.Enabled = false;
			this.milifo.Index = 1;
			this.milifo.Text = "Import local  LIFO";
			this.milifo.Click += new EventHandler(this.ImportLifo);
			//
			// menuItem4
			//
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Import &Alpha Channel...";
			this.menuItem4.Click += new EventHandler(this.ImportAlpha);
			//
			// menuItem6
			//
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "&Update all Sizes";
			this.menuItem6.Click += new EventHandler(this.UpdateAllSizes);
			//
			// menuItem7
			//
			this.menuItem7.Index = 4;
			this.menuItem7.Text = "Import &DDS...";
			this.menuItem7.Click += new EventHandler(this.ImportDDS);
			//
			// mibuild
			//
			this.mibuild.Index = 5;
			this.mibuild.Text = "Build DXT...";
			this.mibuild.Click += new EventHandler(this.BuildDXT);
			//
			// menuItem3
			//
			this.menuItem3.Index = 6;
			this.menuItem3.Text = "-";
			//
			// menuItem2
			//
			this.menuItem2.Index = 7;
			this.menuItem2.Text = "&Export...";
			this.menuItem2.Click += new EventHandler(this.btex_Click);
			//
			// menuItem5
			//
			this.menuItem5.Index = 8;
			this.menuItem5.Text = "Export Alpha &Channel...";
			this.menuItem5.Click += new EventHandler(this.ExportAlpha);
			//
			// lbimg
			//
			this.lbimg.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)
				)
			);
			this.lbimg.IntegralHeight = false;
			this.lbimg.Location = new Point(8, 184);
			this.lbimg.Name = "lbimg";
			this.lbimg.Size = new Size(416, 80);
			this.lbimg.TabIndex = 3;
			this.lbimg.SelectedIndexChanged += new EventHandler(
				this.PictureSelect
			);
			//
			// panel2
			//
			this.panel2.Anchor = (
				(AnchorStyles)(
					(
						(
							AnchorStyles.Top
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)
				)
			);
			this.panel2.Controls.Add(this.btex);
			this.panel2.Controls.Add(this.btim);
			this.panel2.Controls.Add(this.label27);
			this.panel2.Controls.Add(this.btcommit);
			this.panel2.Font = new Font(
				"Verdana",
				9.75F,
				FontStyle.Bold
			);
			this.panel2.ForeColor = SystemColors.ActiveCaptionText;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Margin = new Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(768, 24);
			this.panel2.TabIndex = 0;
			//
			// btex
			//
			this.btex.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.btex.FlatStyle = FlatStyle.System;
			this.btex.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.btex.ForeColor = SystemColors.ControlText;
			this.btex.Location = new Point(584, 0);
			this.btex.Name = "btex";
			this.btex.Size = new Size(80, 23);
			this.btex.TabIndex = 8;
			this.btex.Text = "Export...";
			this.btex.Click += new EventHandler(this.btex_Click);
			//
			// btim
			//
			this.btim.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.btim.FlatStyle = FlatStyle.System;
			this.btim.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.btim.ForeColor = SystemColors.ControlText;
			this.btim.Location = new Point(504, 0);
			this.btim.Name = "btim";
			this.btim.Size = new Size(75, 23);
			this.btim.TabIndex = 7;
			this.btim.Text = "Import...";
			this.btim.Click += new EventHandler(this.btim_Click);
			//
			// label27
			//
			this.label27.AutoSize = true;
			this.label27.ImeMode = ImeMode.NoControl;
			this.label27.Location = new Point(0, 4);
			this.label27.Name = "label27";
			this.label27.Size = new Size(93, 19);
			this.label27.TabIndex = 0;
			this.label27.Text = "TXTR Editor";
			//
			// btcommit
			//
			this.btcommit.Anchor = (
				(AnchorStyles)(
					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)
				)
			);
			this.btcommit.FlatStyle = FlatStyle.System;
			this.btcommit.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.btcommit.Location = new Point(688, 0);
			this.btcommit.Name = "btcommit";
			this.btcommit.TabIndex = 6;
			this.btcommit.Text = "Commit";
			this.btcommit.Click += new EventHandler(this.btcommit_Click);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.Transparent;
			this.label1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.label1.Location = new Point(28, 168);
			this.label1.Name = "label1";
			this.label1.Size = new Size(53, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Blocks:";
			//
			// sfd
			//
			this.sfd.Filter = resources.GetString("sfd.Filter");
			this.sfd.Title = "Export Image";
			//
			// ofd
			//
			this.ofd.FilterIndex = 4;
			//
			// TxtrForm
			//
			this.AutoScaleBaseSize = new Size(6, 14);
			this.ClientSize = new Size(792, 310);
			this.Controls.Add(this.txtrPanel);
			this.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((byte)(0))
			);
			this.Name = "TxtrForm";
			this.Text = "TxtrForm";
			this.txtrPanel.ResumeLayout(false);
			this.txtrPanel.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		internal Panel txtrPanel;
		internal ListBox lbimg;
		private Panel panel2;
		private Label label27;
		private Panel panel1;
		private PictureBox pb;
		private Button btcommit;
		private Button btim;
		internal Button btex;
		private SaveFileDialog sfd;
		private OpenFileDialog ofd;
		private Label label1;
		internal ComboBox cbmipmaps;
		internal ComboBox cbitem;
		private Label label2;
		private TextBox tbflname;
		internal ComboBox cbformats;
		private Label label3;
		private Label label4;
		private TextBox tbwidth;
		private TextBox tbheight;
		private Label label5;
		private TextBox tblifo;
		private Label label6;
		private LinkLabel linkLabel2;
		internal LinkLabel lldel;
		private ContextMenu contextMenu1;
		private MenuItem menuItem1;
		private MenuItem menuItem2;
		private MenuItem menuItem3;
		private MenuItem menuItem4;
		private MenuItem menuItem5;
		private MenuItem menuItem6;
		private Label label7;
		private TextBox tblevel;
		private Label label8;
		private LinkLabel linkLabel1;
		private LinkLabel linkLabel3;
		private MenuItem milifo;
		private LinkLabel linkLabel4;
		private MenuItem menuItem7;
		private MenuItem mibuild;

		internal Txtr wrapper = null;

		private void PictureSelect(object sender, EventArgs e)
		{
			pb.Image = null;
			btex.Enabled = false;
			lldel.Enabled = false;
			try
			{
				lbimg.Tag = true;
				MipMap mm = (MipMap)lbimg.Items[lbimg.SelectedIndex];
				pb.Image = mm.Texture;
				if (mm.Texture == null)
				{
					tblifo.Text = mm.LifoFile;
				}
				else
				{
					tblifo.Text = "";
				}

				btex.Enabled = (pb.Image != null);
				lldel.Enabled = true;
			}
			catch (Exception) { }
			finally
			{
				lbimg.Tag = null;
			}
		}

		private void btcommit_Click(object sender, EventArgs e)
		{
			try
			{
				Txtr wrp = (Txtr)wrapper;
				wrp.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errwritingfile"),
					ex
				);
			}
		}

		private void btex_Click(object sender, EventArgs e)
		{
			if (pb.Image == null)
			{
				return;
			}

			sfd.FileName =
				this.tbflname.Text
				+ "_"
				+ pb.Image.Size.Width.ToString()
				+ "x"
				+ pb.Image.Size.Height.ToString()
				+ ".png";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					pb.Image.Save(
						sfd.FileName,
						ImageLoader.GetImageFormat(sfd.FileName)
					);
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("errwritingfile"),
						ex
					);
				}
			}
		}

		private void btim_Click(object sender, EventArgs e)
		{
			if (lbimg.SelectedIndex < 0)
			{
				return;
			}

			ofd.Filter =
				"All Image Files (*.jpg;*.jpeg;*.tif.*.tiff;*.wmf;*.emf;*.bmp;*.gif;*.png)|*.jpg;*.jpeg;*.tif.*.tiff;*.wmf;*.emf;*.bmp;*.gif;*.png|Png (*.png)|*.png|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif|Tiff image (*.tiff;*.tif)|*.tiff;*.tif|Windows Meta File (*.wmf)|*.wmf|Enhanced Meta File (*.emf)|*.emf|JPEG File (*.jpg;*.jpeg)|*.jpg;*.jpeg|All Files (*.*)|*.*";
			ofd.FilterIndex = 2;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					ImageData id = (ImageData)cbitem.Items[cbitem.SelectedIndex];
					System.IO.Stream s = System.IO.File.OpenRead(ofd.FileName);
					Image img = Image.FromStream(s);
					s.Close();
					s.Dispose();
					s = null;

					img = this.CropImage(id, img);
					if (img == null)
					{
						return;
					}

					lbimg.Tag = true;
					MipMap mm = (MipMap)lbimg.Items[lbimg.SelectedIndex];
					mm.LifoFile = "";
					mm.Texture = img;
					pb.Image = img;
					lbimg.Items[lbimg.SelectedIndex] = mm;

					//if (img!=null) img.Dispose();
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("erropenfile"),
						ex
					);
				}
				finally
				{
					lbimg.Tag = null;
				}
			}
		}

		private void SelectItem(object sender, EventArgs e)
		{
			if (cbitem.Tag != null)
			{
				return;
			}

			this.cbmipmaps.Items.Clear();
			this.lbimg.Items.Clear();
			if (cbitem.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				cbitem.Tag = true;
				ImageData selecteditem = (ImageData)cbitem.Items[cbitem.SelectedIndex];
				foreach (MipMapBlock mmp in selecteditem.MipMapBlocks)
				{
					this.cbmipmaps.Items.Add(mmp);
				}

				if (cbmipmaps.Items.Count > 0)
				{
					cbmipmaps.SelectedIndex = 0;
				}

				this.tbflname.Text = selecteditem.NameResource.FileName;
				this.tbwidth.Text = selecteditem.TextureSize.Width.ToString();
				this.tbheight.Text = selecteditem.TextureSize.Height.ToString();
				this.tblevel.Text = selecteditem.MipMapLevels.ToString();

				this.cbformats.SelectedIndex = 0;
				for (int i = 0; i < cbformats.Items.Count; i++)
				{
					ImageLoader.TxtrFormats f = (ImageLoader.TxtrFormats)
						cbformats.Items[i];
					if (f == selecteditem.Format)
					{
						cbformats.SelectedIndex = i;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
			finally
			{
				cbitem.Tag = null;
			}
		}

		private void FileNameChanged(object sender, EventArgs e)
		{
			if (cbitem.Tag != null)
			{
				return;
			}

			if (cbitem.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				cbitem.Tag = true;
				ImageData selecteditem = (ImageData)cbitem.Items[cbitem.SelectedIndex];
				selecteditem.NameResource.FileName = tbflname.Text.Trim();
				if (tbflname.Text.ToLower().EndsWith("_txtr"))
				{
					selecteditem.FileNameRepeat =
						selecteditem.NameResource.FileName.Substring(
							0,
							selecteditem.NameResource.FileName.Length - 5
						);
				}
				cbitem.Items[cbitem.SelectedIndex] = selecteditem;
				cbitem.Text = tbflname.Text;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
			finally
			{
				cbitem.Tag = null;
			}
		}

		private void SelectMipMapBlock(object sender, EventArgs e)
		{
			if (cbmipmaps.Tag != null)
			{
				return;
			}

			this.lbimg.Items.Clear();
			if (cbmipmaps.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				cbmipmaps.Tag = true;
				MipMapBlock mmp = (MipMapBlock)cbmipmaps.Items[cbmipmaps.SelectedIndex];
				int minindex = -1;
				for (int i = 0; i < mmp.MipMaps.Length; i++)
				{
					MipMap mm = mmp.MipMaps[i];
					mm.ReloadTexture();
					this.lbimg.Items.Add(mm);
					if (mm.Texture != null)
					{
						minindex = i;
					}
				}

				lbimg.SelectedIndex = minindex;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
			finally
			{
				cbmipmaps.Tag = null;
			}
		}

		private void ChangeFormat(object sender, EventArgs e)
		{
			if (cbitem.Tag != null)
			{
				return;
			}

			if (cbitem.SelectedIndex < 0)
			{
				return;
			}

			if (cbformats.SelectedIndex < 1)
			{
				return;
			}

			try
			{
				cbitem.Tag = true;
				ImageData selecteditem = (ImageData)cbitem.Items[cbitem.SelectedIndex];
				selecteditem.Format = (ImageLoader.TxtrFormats)
					cbformats.Items[cbformats.SelectedIndex];

				//make sure images are resaved when the Format was changed!
				foreach (MipMapBlock mmp in selecteditem.MipMapBlocks)
				{
					foreach (MipMap mm in mmp.MipMaps)
					{
						mm.Data = null;
					}
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
			finally
			{
				cbitem.Tag = null;
			}
		}

		private void SetLifo(object sender, EventArgs e)
		{
			if (lbimg.Tag != null)
			{
				return;
			}

			try
			{
				MipMap mm = (MipMap)lbimg.Items[lbimg.SelectedIndex];
				pb.Image = null;
				mm.Texture = null;
				mm.LifoFile = tblifo.Text;
				lbimg.Items[lbimg.SelectedIndex] = mm;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
		}

		private void Delete(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (lbimg.SelectedIndex < 0)
			{
				return;
			}

			lbimg.Items.Remove(lbimg.Items[lbimg.SelectedIndex]);
			UpdateMimMaps();
		}

		private void Add(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			MipMap mm = new MipMap(SelectedImageData());
			mm.LifoFile = null;
			mm.Texture = new Bitmap(512, 256);
			lbimg.Items.Add(mm);
			UpdateMimMaps();
		}

		protected ImageData SelectedImageData()
		{
			//add a MipMapBlock if it doesnt already exist
			ImageData id = null;
			if (cbitem.SelectedIndex < 0)
			{
				Txtr wrp = (Txtr)wrapper;
				id = new ImageData(wrp);
				id.NameResource.FileName = "Unknown";

				IRcolBlock[] irc = new IRcolBlock[wrp.Blocks.Length + 1];
				wrp.Blocks.CopyTo(irc, 0);
				irc[irc.Length - 1] = id;
				wrp.Blocks = irc;
				cbitem.Items.Add(id);
				cbitem.SelectedIndex = cbitem.Items.Count - 1;
			}
			else
			{
				id = (ImageData)cbitem.Items[cbitem.SelectedIndex];
			}

			return id;
		}

		protected MipMapBlock SelectedMipMapBlock(ImageData id)
		{
			//add a MipMapBlock if it doesnt already exist
			if (this.cbmipmaps.SelectedIndex < 0)
			{
				MipMapBlock[] mmp = new MipMapBlock[id.MipMapBlocks.Length + 1];
				id.MipMapBlocks.CopyTo(mmp, 0);
				mmp[mmp.Length - 1] = new MipMapBlock(id);
				id.MipMapBlocks = mmp;
				cbmipmaps.Items.Add(mmp[mmp.Length - 1]);
				cbmipmaps.SelectedIndex = cbmipmaps.Items.Count - 1;

				return mmp[mmp.Length - 1];
			}
			else
			{
				object o = cbmipmaps.SelectedItem;
				if (o is MipMapBlock)
				{
					return o as MipMapBlock;
				}

				try
				{
					MipMapBlock[] mmb = o as MipMapBlock[];
					return mmb[mmb.Length - 1];
				}
				catch
				{
					return new MipMapBlock(id);
				}
			}
		}

		protected void UpdateMimMaps()
		{
			ImageData id = SelectedImageData();
			MipMapBlock mmp = SelectedMipMapBlock(id);

			MipMap[] mm = new MipMap[lbimg.Items.Count];
			for (int i = 0; i < mm.Length; i++)
			{
				mm[i] = (MipMap)lbimg.Items[i];
			}
			mmp.MipMaps = mm;
			id.MipMapLevels = (uint)mm.Length;
			tblevel.Text = id.MipMapLevels.ToString();
		}

		private void UpdateAllSizes(object sender, EventArgs e)
		{
			try
			{
				lbimg.Tag = true;
				MipMap map = null;
				Size sz = new Size(0, 0);

				//Find biggest Texture
				for (int i = 0; i < lbimg.Items.Count; i++)
				{
					MipMap mm = (MipMap)lbimg.Items[i];

					if (mm.Texture != null)
					{
						if (mm.Texture.Size.Width > sz.Width)
						{
							sz = mm.Texture.Size;
							map = mm;
						}
					}
				} // for i

				if (map == null)
				{
					return;
				}

				//create a Scaled Version for each testure
				for (int i = 0; i < lbimg.Items.Count; i++)
				{
					MipMap mm = (MipMap)lbimg.Items[i];

					if (mm.Texture != null)
					{
						//don't change the original Picture
						if (mm != map)
						{
							Bitmap bm = new Bitmap(
								mm.Texture.Size.Width,
								mm.Texture.Size.Height
							);
							Graphics gr = Graphics.FromImage(bm);

							gr.CompositingQuality = System
								.Drawing
								.Drawing2D
								.CompositingQuality
								.HighQuality;
							gr.InterpolationMode = System
								.Drawing
								.Drawing2D
								.InterpolationMode
								.HighQualityBicubic;
							gr.DrawImage(
								map.Texture,
								new Rectangle(new Point(0, 0), bm.Size),
								new Rectangle(new Point(0, 0), map.Texture.Size),
								GraphicsUnit.Pixel
							);
							mm.Texture = bm;
						}
					}
				} // for i
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errconvert"),
					ex
				);
			}
		}

		protected Image GetAlpha(Image img)
		{
			Bitmap bm = new Bitmap(
				pb.Image.Size.Width,
				pb.Image.Size.Height,
				System.Drawing.Imaging.PixelFormat.Format24bppRgb
			);

			Bitmap src = (Bitmap)img;
			for (int y = 0; y < bm.Size.Height; y++)
			{
				for (int x = 0; x < bm.Size.Width; x++)
				{
					byte a = src.GetPixel(x, y).A;
					bm.SetPixel(x, y, Color.FromArgb(a, a, a));
				} // for x
			} //for y

			return bm;
		}

		protected Image ChangeAlpha(Image img, Image alpha)
		{
			Bitmap bm = new Bitmap(
				pb.Image.Size.Width,
				pb.Image.Size.Height,
				System.Drawing.Imaging.PixelFormat.Format32bppArgb
			);

			Bitmap src = (Bitmap)img;
			Bitmap asrc = (Bitmap)alpha;
			for (int y = 0; y < bm.Size.Height; y++)
			{
				for (int x = 0; x < bm.Size.Width; x++)
				{
					byte a = asrc.GetPixel(x, y).R;
					Color cl = src.GetPixel(x, y);
					bm.SetPixel(x, y, Color.FromArgb(a, cl));
				} // for x
			} //for y

			return bm;
		}

		protected Image CropImage(ImageData id, Image img)
		{
			double ratio = (double)id.TextureSize.Width / (double)id.TextureSize.Height;
			double newratio = (double)img.Width / (double)img.Height;

			if (ratio != newratio)
			{
				if (
					MessageBox.Show(
						"The File you want to import does not have the correct aspect Ratio!\n\nDo you want SimPe to crop the Image?",
						"Warning",
						MessageBoxButtons.YesNo
					) == DialogResult.Yes
				)
				{
					int w = Convert.ToInt32(img.Height * ratio);
					int h = img.Height;
					if (w > img.Width)
					{
						w = img.Width;
						h = Convert.ToInt32(img.Width / ratio);
					}

					Image img2 = new Bitmap(w, h);
					Graphics gr = Graphics.FromImage(img2);
					gr.InterpolationMode = System
						.Drawing
						.Drawing2D
						.InterpolationMode
						.HighQualityBicubic;

					gr.DrawImageUnscaled(img, 0, 0);
					img = img2;
				}
				else
				{
					return null;
				}
			}

			return img;
		}

		private void ExportAlpha(object sender, EventArgs e)
		{
			if (pb.Image == null)
			{
				return;
			}

			sfd.FileName =
				this.tbflname.Text
				+ "_alpha_"
				+ pb.Image.Size.Width.ToString()
				+ "x"
				+ pb.Image.Size.Height.ToString()
				+ ".png";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Image bm = GetAlpha(pb.Image);
					bm.Save(sfd.FileName, ImageLoader.GetImageFormat(sfd.FileName));
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("errwritingfile"),
						ex
					);
				}
			}
		}

		private void ImportAlpha(object sender, EventArgs e)
		{
			if (lbimg.SelectedIndex < 0)
			{
				return;
			}

			ofd.Filter =
				"All Image Files (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png|Png (*.png)|*.png|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif|JPEG File (*.jpg)|*.jpg|All Files (*.*)|*.*";
			ofd.FilterIndex = 2;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					ImageData id = (ImageData)cbitem.Items[cbitem.SelectedIndex];
					System.IO.Stream s = System.IO.File.OpenRead(ofd.FileName);
					Image img = Image.FromStream(s);
					s.Close();
					s.Dispose();
					s = null;

					img = this.CropImage(id, img);
					if (img == null)
					{
						return;
					}

					lbimg.Tag = true;
					MipMap mm = (MipMap)lbimg.Items[lbimg.SelectedIndex];
					mm.LifoFile = "";
					mm.Texture = this.ChangeAlpha(mm.Texture, img);
					pb.Image = mm.Texture;
					lbimg.Items[lbimg.SelectedIndex] = mm;
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("erropenfile"),
						ex
					);
				}
				finally
				{
					lbimg.Tag = null;
				}
			}
		}

		private void Changedlevel(object sender, EventArgs e)
		{
			if (cbitem.Tag != null)
			{
				return;
			}

			if (cbitem.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				cbitem.Tag = true;
				ImageData selecteditem = (ImageData)cbitem.Items[cbitem.SelectedIndex];
				selecteditem.MipMapLevels = Convert.ToUInt32(tblevel.Text);
				cbitem.Items[cbitem.SelectedIndex] = selecteditem;
				cbitem.Text = tbflname.Text;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
			finally
			{
				cbitem.Tag = null;
			}
		}

		private void BuildFilename(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			string fl = Hashes.StripHashFromName(this.tbflname.Text);
			this.tbflname.Text = Hashes.AssembleHashedFileName(
				wrapper.Package.FileGroupHash,
				fl
			);
		}

		private void FixTGI(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			string fl = Hashes.StripHashFromName(this.tbflname.Text);
			wrapper.FileDescriptor.Instance = Hashes.InstanceHash(fl);
			wrapper.FileDescriptor.SubType = Hashes.SubTypeHash(fl);
		}

		protected Interfaces.Files.IPackedFileDescriptor GetLocalLifo(MipMap mm)
		{
			if (mm.Texture == null)
			{
				uint st = Hashes.SubTypeHash(mm.LifoFile);
				uint inst = Hashes.InstanceHash(mm.LifoFile);

				Interfaces.Files.IPackedFileDescriptor pfd = wrapper.Package.FindFile(
					0xED534136,
					st,
					wrapper.FileDescriptor.Group,
					inst
				);
				return pfd;
			}

			return null;
		}

		private void ContextPopUp(object sender, EventArgs e)
		{
			milifo.Enabled = false;
			this.mibuild.Enabled = System.IO.File.Exists(
				PathProvider.Global.NvidiaDDSTool
			);
			if (lbimg.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				if (lbimg.SelectedIndex >= 0)
				{
					MipMap mm = (MipMap)lbimg.Items[lbimg.SelectedIndex];
					Interfaces.Files.IPackedFileDescriptor pfd = GetLocalLifo(mm);
					milifo.Enabled = (pfd != null);
				}
				else
				{
					milifo.Enabled = false;
				}
				mibuild.Enabled = (
					System.IO.File.Exists(PathProvider.Global.NvidiaDDSTool)
				);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void ImportLifo(object sender, EventArgs e)
		{
			if (lbimg.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				cbitem.Tag = true;
				MipMap mm = (MipMap)lbimg.Items[lbimg.SelectedIndex];
				Interfaces.Files.IPackedFileDescriptor pfd = GetLocalLifo(mm);
				Lifo lifo = new Lifo(null, false);
				lifo.ProcessData(pfd, wrapper.Package);
				mm.Texture = null; //((LevelInfo)lifo.Blocks[0]).Texture;
				mm.Data = ((LevelInfo)lifo.Blocks[0]).Data;
				pb.Image = mm.Texture;
				lbimg.Items[lbimg.SelectedIndex] = mm;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				cbitem.Tag = null;
			}
		}

		private void BuildMipMap(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			try
			{
				Size sz = ImageSize.Execute(
					SelectedImageData().TextureSize
				);
				cbitem.Tag = true;
				lbimg.Items.Clear();
				int wd = 1;
				int hg = 1;

				/*if (SelectedImageData().TextureSize.Width>SelectedImageData().TextureSize.Height)
				{
					wd = SelectedImageData().TextureSize.Width/SelectedImageData().TextureSize.Height;
					hg = 1;
				}*/

				int levels = Convert.ToInt32(tblevel.Text);
				for (int i = 0; i < levels; i++)
				{
					MipMap mm = new MipMap(SelectedImageData());
					mm.Texture = new Bitmap(wd, hg);

					if (i == levels - 1)
					{
						SelectedImageData().TextureSize = new Size(wd, hg);
					}

					if ((wd == hg) && (wd == 1))
					{
						wd = Math.Max(1, (sz.Width / Math.Max(1, sz.Height)));
						hg = Math.Max(1, (sz.Height / Math.Max(1, sz.Width)));

						if ((wd == hg) && (wd == 1))
						{
							wd *= 2;
							hg *= 2;
						}
					}
					else
					{
						wd *= 2;
						hg *= 2;
					}

					lbimg.Items.Add(mm);
				}

				UpdateMimMaps();
				if (cbitem.Tag == null)
				{
					tbwidth.Text = SelectedImageData().TextureSize.Width.ToString();
					tbheight.Text = SelectedImageData().TextureSize.Height.ToString();
					lbimg.SelectedIndex = lbimg.Items.Count - 1;
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				cbitem.Tag = null;
			}
		}

		void LoadDDS(DDSData[] data)
		{
			if (data == null)
			{
				return;
			}

			if (data.Length > 0)
			{
				try
				{
					cbitem.Tag = true;
					ImageData id = SelectedImageData();

					id.TextureSize = data[0].ParentSize;
					id.Format = data[0].Format;
					id.MipMapLevels = (uint)data.Length;

					this.lbimg.Items.Clear();
					for (int i = data.Length - 1; i >= 0; i--)
					{
						DDSData item = data[i];
						MipMap mm = new MipMap(id);
						mm.Texture = item.Texture;
						mm.Data = item.Data;

						lbimg.Items.Add(mm);
					}

					tbwidth.Text = id.TextureSize.Width.ToString();
					tbheight.Text = id.TextureSize.Height.ToString();

					this.cbformats.SelectedIndex = 0;
					for (int i = 0; i < cbformats.Items.Count; i++)
					{
						if ((ImageLoader.TxtrFormats)cbformats.Items[i] == id.Format)
						{
							cbformats.SelectedIndex = i;
							break;
						}
					}
				}
				finally
				{
					cbitem.Tag = null;
				}
			}

			UpdateMimMaps();
			lbimg.SelectedIndex = lbimg.Items.Count - 1;
		}

		private void ImportDDS(object sender, EventArgs e)
		{
			ofd.Filter = "NVIDIA DDS File (*.dds)|*.dds|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					cbitem.Tag = true;
					ImageData id = SelectedImageData();
					DDSData[] data = ImageLoader.ParesDDS(ofd.FileName);

					LoadDDS(data);
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage("", ex);
				}
				finally
				{
					cbitem.Tag = null;
				}
			}
		}

		private void ChangedSize(object sender, EventArgs e)
		{
			if (cbitem.Tag != null)
			{
				return;
			}

			if (cbitem.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				cbitem.Tag = true;
				ImageData id = (ImageData)cbitem.Items[cbitem.SelectedIndex];
				id.TextureSize = new Size(
					Convert.ToInt32(tbwidth.Text),
					Convert.ToInt32(tbheight.Text)
				);

				BuildMipMap(null, null);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("erropenfile"),
					ex
				);
			}
			finally
			{
				cbitem.Tag = null;
			}
		}

		private void BuildDXT(object sender, EventArgs e)
		{
			DDSTool dds = new DDSTool();

			ImageData id = SelectedImageData();
			LoadDDS(
				dds.Execute(
					Convert.ToInt32(this.tblevel.Text),
					id.TextureSize,
					id.Format
				)
			);
			id.Refresh();
		}
	}
}
