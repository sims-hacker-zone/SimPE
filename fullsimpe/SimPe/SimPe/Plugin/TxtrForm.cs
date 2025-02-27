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
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(TxtrForm));
			txtrPanel = new Panel();
			linkLabel4 = new LinkLabel();
			linkLabel3 = new LinkLabel();
			linkLabel1 = new LinkLabel();
			tblevel = new TextBox();
			label8 = new Label();
			linkLabel2 = new LinkLabel();
			lldel = new LinkLabel();
			tblifo = new TextBox();
			label6 = new Label();
			label5 = new Label();
			tbheight = new TextBox();
			tbwidth = new TextBox();
			label4 = new Label();
			label3 = new Label();
			cbformats = new ComboBox();
			tbflname = new TextBox();
			label2 = new Label();
			cbitem = new ComboBox();
			cbmipmaps = new ComboBox();
			panel1 = new Panel();
			label7 = new Label();
			pb = new PictureBox();
			contextMenu1 = new ContextMenu();
			menuItem1 = new MenuItem();
			milifo = new MenuItem();
			menuItem4 = new MenuItem();
			menuItem6 = new MenuItem();
			menuItem7 = new MenuItem();
			mibuild = new MenuItem();
			menuItem3 = new MenuItem();
			menuItem2 = new MenuItem();
			menuItem5 = new MenuItem();
			lbimg = new ListBox();
			panel2 = new Panel();
			btex = new Button();
			btim = new Button();
			label1 = new Label();
			sfd = new SaveFileDialog();
			ofd = new OpenFileDialog();
			txtrPanel.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pb)).BeginInit();
			panel2.SuspendLayout();
			SuspendLayout();
			//
			// txtrPanel
			//
			txtrPanel.BackColor = Color.Transparent;
			txtrPanel.Controls.Add(linkLabel4);
			txtrPanel.Controls.Add(linkLabel3);
			txtrPanel.Controls.Add(linkLabel1);
			txtrPanel.Controls.Add(tblevel);
			txtrPanel.Controls.Add(label8);
			txtrPanel.Controls.Add(linkLabel2);
			txtrPanel.Controls.Add(lldel);
			txtrPanel.Controls.Add(tblifo);
			txtrPanel.Controls.Add(label6);
			txtrPanel.Controls.Add(label5);
			txtrPanel.Controls.Add(tbheight);
			txtrPanel.Controls.Add(tbwidth);
			txtrPanel.Controls.Add(label4);
			txtrPanel.Controls.Add(label3);
			txtrPanel.Controls.Add(cbformats);
			txtrPanel.Controls.Add(tbflname);
			txtrPanel.Controls.Add(label2);
			txtrPanel.Controls.Add(cbitem);
			txtrPanel.Controls.Add(cbmipmaps);
			txtrPanel.Controls.Add(panel1);
			txtrPanel.Controls.Add(lbimg);
			txtrPanel.Controls.Add(panel2);
			txtrPanel.Controls.Add(label1);
			txtrPanel.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			txtrPanel.Location = new Point(8, 8);
			txtrPanel.Name = "txtrPanel";
			txtrPanel.Size = new Size(768, 288);
			txtrPanel.TabIndex = 19;
			//
			// linkLabel4
			//
			linkLabel4.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			linkLabel4.AutoSize = true;
			linkLabel4.BackColor = Color.Transparent;
			linkLabel4.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			linkLabel4.LinkArea = new LinkArea(0, 5);
			linkLabel4.Location = new Point(200, 264);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new Size(137, 18);
			linkLabel4.TabIndex = 24;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "build default MipMap";
			linkLabel4.UseCompatibleTextRendering = true;
			linkLabel4.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					BuildMipMap
				);
			//
			// linkLabel3
			//
			linkLabel3.AutoSize = true;
			linkLabel3.BackColor = Color.Transparent;
			linkLabel3.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			linkLabel3.Location = new Point(288, 88);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new Size(51, 13);
			linkLabel3.TabIndex = 23;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "fix TGI";
			linkLabel3.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(FixTGI);
			//
			// linkLabel1
			//
			linkLabel1.AutoSize = true;
			linkLabel1.BackColor = Color.Transparent;
			linkLabel1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			linkLabel1.Location = new Point(344, 88);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(85, 13);
			linkLabel1.TabIndex = 22;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "assign Hash";
			linkLabel1.Visible = false;
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					BuildFilename
				);
			//
			// tblevel
			//
			tblevel.Location = new Point(336, 134);
			tblevel.Name = "tblevel";
			tblevel.Size = new Size(88, 21);
			tblevel.TabIndex = 21;
			tblevel.TextChanged += new EventHandler(Changedlevel);
			//
			// label8
			//
			label8.AutoSize = true;
			label8.BackColor = Color.Transparent;
			label8.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label8.Location = new Point(240, 136);
			label8.Name = "label8";
			label8.Size = new Size(98, 13);
			label8.TabIndex = 20;
			label8.Text = "MipMap Level:";
			//
			// linkLabel2
			//
			linkLabel2.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			linkLabel2.AutoSize = true;
			linkLabel2.BackColor = Color.Transparent;
			linkLabel2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			linkLabel2.Location = new Point(344, 264);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new Size(31, 13);
			linkLabel2.TabIndex = 19;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "add";
			linkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Add);
			//
			// lldel
			//
			lldel.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			lldel.AutoSize = true;
			lldel.BackColor = Color.Transparent;
			lldel.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			lldel.Location = new Point(380, 264);
			lldel.Name = "lldel";
			lldel.Size = new Size(48, 13);
			lldel.TabIndex = 18;
			lldel.TabStop = true;
			lldel.Text = "delete";
			lldel.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(Delete);
			//
			// tblifo
			//
			tblifo.Anchor =

					(
						(
							AnchorStyles.Bottom
							| AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			tblifo.Location = new Point(440, 252);
			tblifo.Name = "tblifo";
			tblifo.Size = new Size(320, 21);
			tblifo.TabIndex = 16;
			tblifo.TextChanged += new EventHandler(SetLifo);
			//
			// label6
			//
			label6.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label6.AutoSize = true;
			label6.BackColor = Color.Transparent;
			label6.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label6.Location = new Point(432, 236);
			label6.Name = "label6";
			label6.Size = new Size(111, 13);
			label6.TabIndex = 17;
			label6.Text = "LIFO Reference:";
			//
			// label5
			//
			label5.AutoSize = true;
			label5.BackColor = Color.Transparent;
			label5.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label5.Location = new Point(141, 136);
			label5.Name = "label5";
			label5.Size = new Size(15, 13);
			label5.TabIndex = 15;
			label5.Text = "x";
			//
			// tbheight
			//
			tbheight.Location = new Point(160, 134);
			tbheight.Name = "tbheight";
			tbheight.Size = new Size(56, 21);
			tbheight.TabIndex = 14;
			tbheight.TextChanged += new EventHandler(ChangedSize);
			//
			// tbwidth
			//
			tbwidth.Location = new Point(80, 134);
			tbwidth.Name = "tbwidth";
			tbwidth.Size = new Size(56, 21);
			tbwidth.TabIndex = 13;
			tbwidth.TextChanged += new EventHandler(ChangedSize);
			//
			// label4
			//
			label4.AutoSize = true;
			label4.BackColor = Color.Transparent;
			label4.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label4.Location = new Point(43, 136);
			label4.Name = "label4";
			label4.Size = new Size(38, 13);
			label4.TabIndex = 12;
			label4.Text = "Size:";
			//
			// label3
			//
			label3.AutoSize = true;
			label3.BackColor = Color.Transparent;
			label3.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label3.Location = new Point(24, 112);
			label3.Name = "label3";
			label3.Size = new Size(58, 13);
			label3.TabIndex = 11;
			label3.Text = "Format:";
			//
			// cbformats
			//
			cbformats.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbformats.Location = new Point(80, 108);
			cbformats.Name = "cbformats";
			cbformats.Size = new Size(344, 21);
			cbformats.TabIndex = 10;
			cbformats.SelectedIndexChanged += new EventHandler(
				ChangeFormat
			);
			//
			// tbflname
			//
			tbflname.Location = new Point(80, 56);
			tbflname.Name = "tbflname";
			tbflname.Size = new Size(344, 21);
			tbflname.TabIndex = 9;
			tbflname.TextChanged += new EventHandler(FileNameChanged);
			//
			// label2
			//
			label2.AutoSize = true;
			label2.BackColor = Color.Transparent;
			label2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label2.Location = new Point(8, 36);
			label2.Name = "label2";
			label2.Size = new Size(71, 13);
			label2.TabIndex = 8;
			label2.Text = "Filename:";
			//
			// cbitem
			//
			cbitem.DropDownStyle = ComboBoxStyle.DropDownList;
			cbitem.Location = new Point(80, 32);
			cbitem.Name = "cbitem";
			cbitem.Size = new Size(344, 21);
			cbitem.TabIndex = 7;
			cbitem.SelectedIndexChanged += new EventHandler(
				SelectItem
			);
			//
			// cbmipmaps
			//
			cbmipmaps.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbmipmaps.Location = new Point(80, 160);
			cbmipmaps.Name = "cbmipmaps";
			cbmipmaps.Size = new Size(344, 21);
			cbmipmaps.TabIndex = 5;
			cbmipmaps.SelectedIndexChanged += new EventHandler(
				SelectMipMapBlock
			);
			//
			// panel1
			//
			panel1.Anchor =

					(
						(
							(
								AnchorStyles.Top
								| AnchorStyles.Bottom
							) | AnchorStyles.Left
						) | AnchorStyles.Right
					)

			;
			panel1.AutoScroll = true;
			panel1.AutoScrollMinSize = new Size(24, 24);
			panel1.BackColor = Color.Transparent;
			panel1.Controls.Add(label7);
			panel1.Controls.Add(pb);
			panel1.Location = new Point(432, 32);
			panel1.Name = "panel1";
			panel1.Size = new Size(328, 200);
			panel1.TabIndex = 4;
			//
			// label7
			//
			label7.Anchor =

					(
						AnchorStyles.Bottom
						| AnchorStyles.Left
					)

			;
			label7.AutoSize = true;
			label7.Font = new Font("Verdana", 8.25F);
			label7.ForeColor = SystemColors.ActiveCaptionText;
			label7.ImeMode = ImeMode.NoControl;
			label7.Location = new Point(8, 176);
			label7.Name = "label7";
			label7.Size = new Size(293, 13);
			label7.TabIndex = 6;
			label7.Text = "Right click on the Image to get more Interactions.";
			//
			// pb
			//
			pb.BackColor = SystemColors.Control;
			pb.BackgroundImage = (
				(Image)(resources.GetObject("pb.BackgroundImage"))
			);
			pb.ContextMenu = contextMenu1;
			pb.Location = new Point(0, 0);
			pb.Name = "pb";
			pb.Size = new Size(100, 50);
			pb.SizeMode = PictureBoxSizeMode.AutoSize;
			pb.TabIndex = 5;
			pb.TabStop = false;
			//
			// contextMenu1
			//
			contextMenu1.MenuItems.AddRange(
				new MenuItem[]
				{
					menuItem1,
					milifo,
					menuItem4,
					menuItem6,
					menuItem7,
					mibuild,
					menuItem3,
					menuItem2,
					menuItem5,
				}
			);
			contextMenu1.Popup += new EventHandler(ContextPopUp);
			//
			// menuItem1
			//
			menuItem1.Index = 0;
			menuItem1.Text = "&Import...";
			menuItem1.Click += new EventHandler(btim_Click);
			//
			// milifo
			//
			milifo.Enabled = false;
			milifo.Index = 1;
			milifo.Text = "Import local  LIFO";
			milifo.Click += new EventHandler(ImportLifo);
			//
			// menuItem4
			//
			menuItem4.Index = 2;
			menuItem4.Text = "Import &Alpha Channel...";
			menuItem4.Click += new EventHandler(ImportAlpha);
			//
			// menuItem6
			//
			menuItem6.Index = 3;
			menuItem6.Text = "&Update all Sizes";
			menuItem6.Click += new EventHandler(UpdateAllSizes);
			//
			// menuItem7
			//
			menuItem7.Index = 4;
			menuItem7.Text = "Import &DDS...";
			menuItem7.Click += new EventHandler(ImportDDS);
			//
			// mibuild
			//
			mibuild.Index = 5;
			mibuild.Text = "Build DXT...";
			mibuild.Click += new EventHandler(BuildDXT);
			//
			// menuItem3
			//
			menuItem3.Index = 6;
			menuItem3.Text = "-";
			//
			// menuItem2
			//
			menuItem2.Index = 7;
			menuItem2.Text = "&Export...";
			menuItem2.Click += new EventHandler(btex_Click);
			//
			// menuItem5
			//
			menuItem5.Index = 8;
			menuItem5.Text = "Export Alpha &Channel...";
			menuItem5.Click += new EventHandler(ExportAlpha);
			//
			// lbimg
			//
			lbimg.Anchor =

					(
						(
							AnchorStyles.Top
							| AnchorStyles.Bottom
						) | AnchorStyles.Left
					)

			;
			lbimg.IntegralHeight = false;
			lbimg.Location = new Point(8, 184);
			lbimg.Name = "lbimg";
			lbimg.Size = new Size(416, 80);
			lbimg.TabIndex = 3;
			lbimg.SelectedIndexChanged += new EventHandler(
				PictureSelect
			);
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
			panel2.Controls.Add(btex);
			panel2.Controls.Add(btim);
			panel2.Controls.Add(label27);
			panel2.Controls.Add(btcommit);
			panel2.Font = new Font(
				"Verdana",
				9.75F,
				FontStyle.Bold
			);
			panel2.ForeColor = SystemColors.ActiveCaptionText;
			panel2.Location = new Point(0, 0);
			panel2.Margin = new Padding(0);
			panel2.Name = "panel2";
			panel2.Size = new Size(768, 24);
			panel2.TabIndex = 0;
			//
			// btex
			//
			btex.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			btex.FlatStyle = FlatStyle.System;
			btex.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			btex.ForeColor = SystemColors.ControlText;
			btex.Location = new Point(584, 0);
			btex.Name = "btex";
			btex.Size = new Size(80, 23);
			btex.TabIndex = 8;
			btex.Text = "Export...";
			btex.Click += new EventHandler(btex_Click);
			//
			// btim
			//
			btim.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			btim.FlatStyle = FlatStyle.System;
			btim.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			btim.ForeColor = SystemColors.ControlText;
			btim.Location = new Point(504, 0);
			btim.Name = "btim";
			btim.Size = new Size(75, 23);
			btim.TabIndex = 7;
			btim.Text = "Import...";
			btim.Click += new EventHandler(btim_Click);
			//
			// label27
			//
			label27.AutoSize = true;
			label27.ImeMode = ImeMode.NoControl;
			label27.Location = new Point(0, 4);
			label27.Name = "label27";
			label27.Size = new Size(93, 19);
			label27.TabIndex = 0;
			label27.Text = "TXTR Editor";
			//
			// btcommit
			//
			btcommit.Anchor =

					(
						AnchorStyles.Top
						| AnchorStyles.Right
					)

			;
			btcommit.FlatStyle = FlatStyle.System;
			btcommit.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			btcommit.Location = new Point(688, 0);
			btcommit.Name = "btcommit";
			btcommit.TabIndex = 6;
			btcommit.Text = "Commit";
			btcommit.Click += new EventHandler(btcommit_Click);
			//
			// label1
			//
			label1.AutoSize = true;
			label1.BackColor = Color.Transparent;
			label1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label1.Location = new Point(28, 168);
			label1.Name = "label1";
			label1.Size = new Size(53, 13);
			label1.TabIndex = 6;
			label1.Text = "Blocks:";
			//
			// sfd
			//
			sfd.Filter = resources.GetString("sfd.Filter");
			sfd.Title = "Export Image";
			//
			// ofd
			//
			ofd.FilterIndex = 4;
			//
			// TxtrForm
			//
			AutoScaleBaseSize = new Size(6, 14);
			ClientSize = new Size(792, 310);
			Controls.Add(txtrPanel);
			Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			Name = "TxtrForm";
			Text = "TxtrForm";
			txtrPanel.ResumeLayout(false);
			txtrPanel.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(pb)).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
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
				tblifo.Text = mm.Texture == null ? mm.LifoFile : "";

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
				Txtr wrp = wrapper;
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
				tbflname.Text
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

					img = CropImage(id, img);
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

			cbmipmaps.Items.Clear();
			lbimg.Items.Clear();
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
					cbmipmaps.Items.Add(mmp);
				}

				if (cbmipmaps.Items.Count > 0)
				{
					cbmipmaps.SelectedIndex = 0;
				}

				tbflname.Text = selecteditem.NameResource.FileName;
				tbwidth.Text = selecteditem.TextureSize.Width.ToString();
				tbheight.Text = selecteditem.TextureSize.Height.ToString();
				tblevel.Text = selecteditem.MipMapLevels.ToString();

				cbformats.SelectedIndex = 0;
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

			lbimg.Items.Clear();
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
					lbimg.Items.Add(mm);
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
			MipMap mm = new MipMap(SelectedImageData())
			{
				LifoFile = null,
				Texture = new Bitmap(512, 256)
			};
			lbimg.Items.Add(mm);
			UpdateMimMaps();
		}

		protected ImageData SelectedImageData()
		{
			//add a MipMapBlock if it doesnt already exist
			ImageData id = null;
			if (cbitem.SelectedIndex < 0)
			{
				Txtr wrp = wrapper;
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
			if (cbmipmaps.SelectedIndex < 0)
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
			double ratio = id.TextureSize.Width / (double)id.TextureSize.Height;
			double newratio = img.Width / (double)img.Height;

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
				tbflname.Text
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

					img = CropImage(id, img);
					if (img == null)
					{
						return;
					}

					lbimg.Tag = true;
					MipMap mm = (MipMap)lbimg.Items[lbimg.SelectedIndex];
					mm.LifoFile = "";
					mm.Texture = ChangeAlpha(mm.Texture, img);
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
			string fl = Hashes.StripHashFromName(tbflname.Text);
			tbflname.Text = Hashes.AssembleHashedFileName(
				wrapper.Package.FileGroupHash,
				fl
			);
		}

		private void FixTGI(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			string fl = Hashes.StripHashFromName(tbflname.Text);
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
			mibuild.Enabled = System.IO.File.Exists(
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
					MipMap mm = new MipMap(SelectedImageData())
					{
						Texture = new Bitmap(wd, hg)
					};

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

					lbimg.Items.Clear();
					for (int i = data.Length - 1; i >= 0; i--)
					{
						DDSData item = data[i];
						MipMap mm = new MipMap(id)
						{
							Texture = item.Texture,
							Data = item.Data
						};

						lbimg.Items.Add(mm);
					}

					tbwidth.Text = id.TextureSize.Width.ToString();
					tbheight.Text = id.TextureSize.Height.ToString();

					cbformats.SelectedIndex = 0;
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
					Convert.ToInt32(tblevel.Text),
					id.TextureSize,
					id.Format
				)
			);
			id.Refresh();
		}
	}
}
