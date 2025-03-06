// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Windows.Forms;

using SimPe.Interfaces.Scenegraph;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Lifo
{
	/// <summary>
	/// Summary description for LifoForm.
	/// </summary>
	public class LifoForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LifoForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(LifoForm));
			LifoPanel = new Panel();
			linkLabel2 = new LinkLabel();
			linkLabel1 = new LinkLabel();
			label1 = new Label();
			tbz = new TextBox();
			label5 = new Label();
			tbheight = new TextBox();
			tbwidth = new TextBox();
			label4 = new Label();
			label3 = new Label();
			cbformats = new ComboBox();
			tbflname = new TextBox();
			label2 = new Label();
			cbitem = new ComboBox();
			panel1 = new Panel();
			pb = new PictureBox();
			contextMenu1 = new ContextMenu();
			menuItem1 = new MenuItem();
			menuItem4 = new MenuItem();
			menuItem2 = new MenuItem();
			menuItem5 = new MenuItem();
			panel2 = new Panel();
			btex = new Button();
			btim = new Button();
			label27 = new Label();
			btcommit = new Button();
			sfd = new SaveFileDialog();
			ofd = new OpenFileDialog();
			menuItem3 = new MenuItem();
			menuItem6 = new MenuItem();
			menuItem7 = new MenuItem();
			LifoPanel.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			panel2.SuspendLayout();
			SuspendLayout();
			//
			// LifoPanel
			//
			LifoPanel.Controls.Add(linkLabel2);
			LifoPanel.Controls.Add(linkLabel1);
			LifoPanel.Controls.Add(label1);
			LifoPanel.Controls.Add(tbz);
			LifoPanel.Controls.Add(label5);
			LifoPanel.Controls.Add(tbheight);
			LifoPanel.Controls.Add(tbwidth);
			LifoPanel.Controls.Add(label4);
			LifoPanel.Controls.Add(label3);
			LifoPanel.Controls.Add(cbformats);
			LifoPanel.Controls.Add(tbflname);
			LifoPanel.Controls.Add(label2);
			LifoPanel.Controls.Add(cbitem);
			LifoPanel.Controls.Add(panel1);
			LifoPanel.Controls.Add(panel2);
			LifoPanel.Location = new Point(8, 8);
			LifoPanel.Name = "LifoPanel";
			LifoPanel.Size = new Size(768, 288);
			LifoPanel.TabIndex = 19;
			//
			// linkLabel2
			//
			linkLabel2.AutoSize = true;
			linkLabel2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			linkLabel2.Location = new Point(288, 80);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new Size(51, 13);
			linkLabel2.TabIndex = 19;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "fix TGI";
			linkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(FixTGI);
			//
			// linkLabel1
			//
			linkLabel1.AutoSize = true;
			linkLabel1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			linkLabel1.Location = new Point(343, 80);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(85, 13);
			linkLabel1.TabIndex = 18;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "assign Hash";
			linkLabel1.Visible = false;
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					BuildFilename
				);
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label1.Location = new Point(248, 136);
			label1.Name = "label1";
			label1.Size = new Size(60, 13);
			label1.TabIndex = 17;
			label1.Text = "Z-Level:";
			//
			// tbz
			//
			tbz.Location = new Point(304, 128);
			tbz.Name = "tbz";
			tbz.Size = new Size(56, 21);
			tbz.TabIndex = 16;
			tbz.TextChanged += new EventHandler(ChangeZLevel);
			//
			// label5
			//
			label5.AutoSize = true;
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
			tbheight.Location = new Point(160, 128);
			tbheight.Name = "tbheight";
			tbheight.ReadOnly = true;
			tbheight.Size = new Size(56, 21);
			tbheight.TabIndex = 14;
			//
			// tbwidth
			//
			tbwidth.Location = new Point(80, 128);
			tbwidth.Name = "tbwidth";
			tbwidth.ReadOnly = true;
			tbwidth.Size = new Size(56, 21);
			tbwidth.TabIndex = 13;
			//
			// label4
			//
			label4.AutoSize = true;
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
			cbformats.Location = new Point(80, 104);
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
			label2.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			label2.Location = new Point(11, 40);
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
			// panel1
			//
			panel1.Anchor =




								AnchorStyles.Top
								| AnchorStyles.Bottom
							 | AnchorStyles.Left
						 | AnchorStyles.Right


			;
			panel1.AutoScroll = true;
			panel1.Controls.Add(pb);
			panel1.Location = new Point(432, 32);
			panel1.Name = "panel1";
			panel1.Size = new Size(328, 248);
			panel1.TabIndex = 4;
			//
			// pb
			//
			pb.BackColor = SystemColors.Control;
			pb.BackgroundImage =
				(Image)resources.GetObject("pb.BackgroundImage")
			;
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
					menuItem4,
					menuItem3,
					menuItem6,
					menuItem7,
					menuItem2,
					menuItem5,
				}
			);
			//
			// menuItem1
			//
			menuItem1.Index = 0;
			menuItem1.Text = "&Import...";
			menuItem1.Click += new EventHandler(btim_Click);
			//
			// menuItem4
			//
			menuItem4.Index = 1;
			menuItem4.Text = "Import &Alpha Channel...";
			menuItem4.Click += new EventHandler(ImportAlpha);
			//
			// menuItem2
			//
			menuItem2.Index = 5;
			menuItem2.Text = "&Export...";
			menuItem2.Click += new EventHandler(btex_Click);
			//
			// menuItem5
			//
			menuItem5.Index = 6;
			menuItem5.Text = "Export Alpha &Channel...";
			menuItem5.Click += new EventHandler(ExportAlpha);
			//
			// panel2
			//
			panel2.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			panel2.BackColor = SystemColors.AppWorkspace;
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
			panel2.Name = "panel2";
			panel2.Size = new Size(768, 24);
			panel2.TabIndex = 0;
			//
			// btex
			//
			btex.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			btex.FlatStyle = FlatStyle.System;
			btex.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
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


						AnchorStyles.Top
						| AnchorStyles.Right


			;
			btim.FlatStyle = FlatStyle.System;
			btim.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
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
			label27.Size = new Size(81, 16);
			label27.TabIndex = 0;
			label27.Text = "Lifo Editor";
			//
			// btcommit
			//
			btcommit.Anchor =


						AnchorStyles.Top
						| AnchorStyles.Right


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
			btcommit.Size = new Size(75, 23);
			btcommit.TabIndex = 6;
			btcommit.Text = "Save";
			btcommit.Click += new EventHandler(btcommit_Click);
			//
			// sfd
			//
			sfd.Filter =
				"Png (*.png)|*.png|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif|JPEG File (*.jpg)|*.jpg|"
				+ "All Files (*.*)|*.*";
			sfd.Title = "Export Image";
			//
			// ofd
			//
			ofd.Filter =
				"All Image Files (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png|Bitmap (*.bmp)|"
				+ "*.bmp|Gif (*.gif)|*.gif|JPEG File (*.jpg)|*.jpg|Png (*.png)|*.png|All Files (*.*"
				+ ")|*.*";
			ofd.FilterIndex = 5;
			//
			// LifoForm
			//
			AutoScaleBaseSize = new Size(6, 14);
			ClientSize = new Size(792, 310);
			Controls.Add(LifoPanel);
			Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			Name = "LifoForm";
			Text = "LifoForm";
			LifoPanel.ResumeLayout(false);
			LifoPanel.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		internal Panel LifoPanel;
		private Panel panel2;
		private Label label27;
		private Panel panel1;
		private PictureBox pb;
		private Button btcommit;
		private Button btim;
		internal Button btex;
		private SaveFileDialog sfd;
		private OpenFileDialog ofd;
		internal ComboBox cbitem;
		private Label label2;
		private TextBox tbflname;
		internal ComboBox cbformats;
		private Label label3;
		private Label label4;
		private TextBox tbwidth;
		private TextBox tbheight;
		private Label label5;
		private TextBox tbz;
		private Label label1;
		private ContextMenu contextMenu1;
		private MenuItem menuItem1;
		private MenuItem menuItem4;
		private MenuItem menuItem2;
		private MenuItem menuItem5;
		private LinkLabel linkLabel1;
		private LinkLabel linkLabel2;
		private MenuItem menuItem3;
		private MenuItem menuItem6;
		private MenuItem menuItem7;

		internal Lifo wrapper = null;

		private void btcommit_Click(object sender, EventArgs e)
		{
			try
			{
				Lifo wrp = wrapper;
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
				+ tbwidth.Text
				+ "x"
				+ tbheight.Text
				+ ".png";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					pb.Image.Save(sfd.FileName);
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
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					LevelInfo id = (LevelInfo)cbitem.Items[cbitem.SelectedIndex];
					Image img = Image.FromFile(ofd.FileName);
					img = CropImage(id, img);
					if (img == null)
					{
						return;
					}

					id.Texture = img;
					pb.Image = img;
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("erropenfile"),
						ex
					);
				}
			}
		}

		private void SelectItem(object sender, EventArgs e)
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
				LevelInfo selecteditem = (LevelInfo)cbitem.Items[cbitem.SelectedIndex];

				tbflname.Text = selecteditem.NameResource.FileName;
				tbwidth.Text = selecteditem.TextureSize.Width.ToString();
				tbheight.Text = selecteditem.TextureSize.Height.ToString();
				tbz.Text = selecteditem.ZLevel.ToString();

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

				pb.Image = selecteditem.Texture;
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
				LevelInfo selecteditem = (LevelInfo)cbitem.Items[cbitem.SelectedIndex];
				selecteditem.NameResource.FileName = tbflname.Text;
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
				LevelInfo selecteditem = (LevelInfo)cbitem.Items[cbitem.SelectedIndex];
				selecteditem.Format = (ImageLoader.TxtrFormats)
					cbformats.Items[cbformats.SelectedIndex];
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

		protected LevelInfo SelectedLevelInfo()
		{
			//add a MipMapBlock if it doesnt already exist
			LevelInfo li;
			if (cbitem.SelectedIndex < 0)
			{
				Lifo wrp = wrapper;
				li = new LevelInfo(wrp);
				li.NameResource.FileName = "Unknown";
				wrp.Blocks.Add(li);
				cbitem.Items.Add(li);
				cbitem.SelectedIndex = cbitem.Items.Count - 1;
			}
			else
			{
				li = (LevelInfo)cbitem.Items[cbitem.SelectedIndex];
			}

			return li;
		}

		private void ChangeZLevel(object sender, EventArgs e)
		{
			try
			{
				LevelInfo li = SelectedLevelInfo();
				li.ZLevel = Convert.ToInt32(tbz.Text);
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

		protected Image CropImage(LevelInfo id, Image img)
		{
			double ratio = id.TextureSize.Width / (double)id.TextureSize.Height;
			double newratio = img.Width / (double)img.Height;

			if (ratio != newratio)
			{
				if (
					MessageBox.Show(
						"The File you want to import does not have the correct aspect Ration!\n\nDo you want SimPe to crop the Image?",
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
					bm.Save(sfd.FileName);
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
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					LevelInfo id = (LevelInfo)cbitem.Items[cbitem.SelectedIndex];
					Image img = Image.FromFile(ofd.FileName);
					img = CropImage(id, img);
					if (img == null)
					{
						return;
					}

					id.Texture = ChangeAlpha(id.Texture, img);
					;
					pb.Image = id.Texture;
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("erropenfile"),
						ex
					);
				}
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

		private void BuildDXT(object sender, EventArgs e)
		{
			DDSTool dds = new DDSTool();

			LevelInfo id = SelectedImageData();
			LoadDDS(dds.Execute(1, id.TextureSize, id.Format));
			//id.Refresh();
		}

		private void ImportDDS(object sender, EventArgs e)
		{
			ofd.Filter = "NVIDIA DDS File (*.dds)|*.dds|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					cbitem.Tag = true;
					//ImageData id = SelectedImageData();
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

					LevelInfo id = SelectedImageData();
					id.Format = data[0].Format;
					id.Data = data[0].Data;
					pb.Image = data[0].Texture;

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
		}

		protected LevelInfo SelectedImageData()
		{
			//add a MipMapBlock if it doesnt already exist
			LevelInfo id;
			if (cbitem.SelectedIndex < 0)
			{
				Lifo wrp = wrapper;
				id = new LevelInfo(wrp);
				id.NameResource.FileName = "Unknown";
				id.Format = (ImageLoader.TxtrFormats)cbformats.SelectedItem;
				wrp.Blocks.Add(id);
				cbitem.Items.Add(id);
				cbitem.SelectedIndex = cbitem.Items.Count - 1;
			}
			else
			{
				id = (LevelInfo)cbitem.Items[cbitem.SelectedIndex];
			}

			return id;
		}
	}
}
