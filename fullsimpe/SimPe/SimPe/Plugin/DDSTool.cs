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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for DDSTool.
	/// </summary>
	public class DDSTool : Form
	{
		private LinkLabel linkLabel1;
		private OpenFileDialog ofd;
		private PictureBox pb;
		private GroupBox groupBox1;
		private Button button1;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private CheckedListBox cbfilter;
		private TextBox tblevel;
		private TextBox tbwidth;
		private TextBox tbheight;
		private Label label6;
		private ComboBox cbformat;
		private ComboBox cbsharpen;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DDSTool()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			cbformat.Items.Clear();
			cbformat.Items.Add(ImageLoader.TxtrFormats.DXT1Format);
			cbformat.Items.Add(ImageLoader.TxtrFormats.DXT3Format);
			cbformat.Items.Add(ImageLoader.TxtrFormats.DXT5Format);
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
				new System.ComponentModel.ComponentResourceManager(typeof(DDSTool));
			pb = new PictureBox();
			linkLabel1 = new LinkLabel();
			ofd = new OpenFileDialog();
			groupBox1 = new GroupBox();
			cbformat = new ComboBox();
			label6 = new Label();
			tbheight = new TextBox();
			tbwidth = new TextBox();
			tblevel = new TextBox();
			cbfilter = new CheckedListBox();
			label5 = new Label();
			cbsharpen = new ComboBox();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			button1 = new Button();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			//
			// pb
			//
			pb.BorderStyle = BorderStyle.FixedSingle;
			pb.Location = new Point(16, 24);
			pb.Name = "pb";
			pb.Size = new Size(128, 128);
			pb.SizeMode = PictureBoxSizeMode.Zoom;
			pb.TabIndex = 0;
			pb.TabStop = false;
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
			linkLabel1.LinkArea = new LinkArea(0, 4);
			linkLabel1.Location = new Point(48, 160);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(93, 18);
			linkLabel1.TabIndex = 1;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "open Image...";
			linkLabel1.UseCompatibleTextRendering = true;
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel1_LinkClicked
				);
			//
			// ofd
			//
			ofd.Filter =
				"All Image Files (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png|Bitmap (*.bmp)|"
				+ "*.bmp|Gif (*.gif)|*.gif|JPEG File (*.jpg)|*.jpg|Png (*.png)|*.png|All Files (*.*"
				+ ")|*.*";
			//
			// groupBox1
			//
			groupBox1.BackColor = Color.Transparent;
			groupBox1.Controls.Add(cbformat);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(tbheight);
			groupBox1.Controls.Add(tbwidth);
			groupBox1.Controls.Add(tblevel);
			groupBox1.Controls.Add(cbfilter);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(cbsharpen);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				0
			);
			groupBox1.Location = new Point(160, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(312, 208);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "Settings";
			//
			// cbformat
			//
			cbformat.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbformat.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbformat.Items.AddRange(
				new object[]
				{
					"None",
					"Negative",
					"Lighter",
					"Darker",
					"ContrastMore",
					"ContrastLess",
					"Smoothen",
					"SharpenSoft",
					"SharpenMedium",
					"SharpenStrong",
					"FindEdges",
					"Contour",
					"EdgeDetect",
					"EdgeDetectSoft",
					"Emboss",
					"MeanRemoval",
				}
			);
			cbformat.Location = new Point(80, 64);
			cbformat.Name = "cbformat";
			cbformat.Size = new Size(224, 21);
			cbformat.TabIndex = 12;
			//
			// label6
			//
			label6.AutoSize = true;
			label6.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			label6.Location = new Point(136, 48);
			label6.Name = "label6";
			label6.Size = new Size(14, 13);
			label6.TabIndex = 11;
			label6.Text = "x";
			//
			// tbheight
			//
			tbheight.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbheight.Location = new Point(152, 40);
			tbheight.Name = "tbheight";
			tbheight.ReadOnly = true;
			tbheight.Size = new Size(48, 21);
			tbheight.TabIndex = 10;
			tbheight.Text = "0";
			//
			// tbwidth
			//
			tbwidth.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tbwidth.Location = new Point(80, 40);
			tbwidth.Name = "tbwidth";
			tbwidth.ReadOnly = true;
			tbwidth.Size = new Size(48, 21);
			tbwidth.TabIndex = 9;
			tbwidth.Text = "0";
			//
			// tblevel
			//
			tblevel.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			tblevel.Location = new Point(80, 16);
			tblevel.Name = "tblevel";
			tblevel.Size = new Size(80, 21);
			tblevel.TabIndex = 8;
			tblevel.Text = "0";
			//
			// cbfilter
			//
			cbfilter.CheckOnClick = true;
			cbfilter.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbfilter.IntegralHeight = false;
			cbfilter.Items.AddRange(
				new object[]
				{
					"dither",
					"Point",
					"Box",
					"Triangle",
					"Quadratic",
					"Cubic",
					"Catrom",
					"Mitchell",
					"Gaussian",
					"Sinc",
					"Bessel",
					"Hanning",
					"Hamming",
					"Blackman",
					"Kaiser",
				}
			);
			cbfilter.Location = new Point(80, 120);
			cbfilter.Name = "cbfilter";
			cbfilter.Size = new Size(224, 80);
			cbfilter.TabIndex = 7;
			//
			// label5
			//
			label5.AutoSize = true;
			label5.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			label5.Location = new Point(35, 120);
			label5.Name = "label5";
			label5.Size = new Size(40, 13);
			label5.TabIndex = 6;
			label5.Text = "Filter:";
			//
			// cbsharpen
			//
			cbsharpen.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbsharpen.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			cbsharpen.Items.AddRange(
				new object[]
				{
					"None",
					"Negative",
					"Lighter",
					"Darker",
					"ContrastMore",
					"ContrastLess",
					"Smoothen",
					"SharpenSoft",
					"SharpenMedium",
					"SharpenStrong",
					"FindEdges",
					"Contour",
					"EdgeDetect",
					"EdgeDetectSoft",
					"Emboss",
					"MeanRemoval",
				}
			);
			cbsharpen.Location = new Point(80, 88);
			cbsharpen.Name = "cbsharpen";
			cbsharpen.Size = new Size(224, 21);
			cbsharpen.TabIndex = 5;
			//
			// label4
			//
			label4.AutoSize = true;
			label4.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			label4.Location = new Point(16, 96);
			label4.Name = "label4";
			label4.Size = new Size(60, 13);
			label4.TabIndex = 3;
			label4.Text = "Sharpen:";
			//
			// label3
			//
			label3.AutoSize = true;
			label3.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			label3.Location = new Point(23, 72);
			label3.Name = "label3";
			label3.Size = new Size(52, 13);
			label3.TabIndex = 2;
			label3.Text = "Format:";
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
			label2.Location = new Point(40, 48);
			label2.Name = "label2";
			label2.Size = new Size(36, 13);
			label2.TabIndex = 1;
			label2.Text = "Size:";
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
			label1.Location = new Point(28, 24);
			label1.Name = "label1";
			label1.Size = new Size(48, 13);
			label1.TabIndex = 0;
			label1.Text = "Levels:";
			//
			// button1
			//
			button1.Anchor =


						AnchorStyles.Bottom
						| AnchorStyles.Right


			;
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new Point(397, 224);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 3;
			button1.Text = "Build";
			button1.Click += new EventHandler(Build);
			//
			// DDSTool
			//
			AutoScaleBaseSize = new Size(6, 14);
			ClientSize = new Size(480, 254);
			Controls.Add(button1);
			Controls.Add(groupBox1);
			Controls.Add(linkLabel1);
			Controls.Add(pb);
			Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "DDSTool";
			Text = "DDS Builder";
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		Image img;
		string imgname;
		DDSData[] dds;

		public DDSData[] Execute(int level, Size size, ImageLoader.TxtrFormats format)
		{
			pb.Image = null;
			img = null;
			dds = null;

			cbsharpen.SelectedIndex = 0;
			tblevel.Text = level.ToString();
			tbwidth.Text = size.Width.ToString();
			tbheight.Text = size.Height.ToString();

			cbformat.SelectedIndex = 2;
			for (int i = 0; i < cbformat.Items.Count; i++)
			{
				ImageLoader.TxtrFormats fr = (ImageLoader.TxtrFormats)cbformat.Items[i];
				if (fr == format)
				{
					cbformat.SelectedIndex = i;
					break;
				}
			}

			button1.Enabled = false;
			ShowDialog();

			return dds;
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				//System.IO.Stream s = System.IO.File.OpenRead(ofd.FileName);
				//img = (Image)Image.FromStream(s).Clone();
				//s.Close();
				img = Image.FromFile(ofd.FileName);

				imgname = ofd.FileName;
				pb.Image = ImageLoader.Preview(img, pb.Size);

				tbwidth.Text = img.Width.ToString();
				tbheight.Text = img.Height.ToString();
				button1.Enabled = img != null;
			}
		}

		public static DDSData[] BuildDDS(
			Image img,
			int levels,
			ImageLoader.TxtrFormats format,
			string parameters
		)
		{
			string imgname = System.IO.Path.GetTempFileName() + ".png";
			img.Save(imgname, System.Drawing.Imaging.ImageFormat.Png);

			try
			{
				return BuildDDS(imgname, levels, format, parameters);
			}
			finally
			{
				if (System.IO.File.Exists(imgname))
				{
					System.IO.File.Delete(imgname);
				}
			}
		}

		public static DDSData[] BuildDDS(
			string imgname,
			int levels,
			ImageLoader.TxtrFormats format,
			string parameters
		)
		{
			string ddsfile = System.IO.Path.GetTempFileName() + ".dds";

			//img.Save(imgname);

			string arg = "-file \"" + imgname + "\" ";
			arg += "-output \"" + ddsfile + "\" ";

			if (format == ImageLoader.TxtrFormats.DXT1Format)
			{
				arg += " -dxt1c";
			}
			else if (format == ImageLoader.TxtrFormats.DXT5Format)
			{
				arg += "-dxt5";
			}
			else
			{
				arg += "-dxt3";
			}

			arg += " -nmips " + levels.ToString();
			arg += " " + parameters;

			string flname = PathProvider.Global.NvidiaDDSTool;

			if (!System.IO.File.Exists(flname))
			{
				return new DDSData[0];
			}

			try
			{
				Process p = new Process();
				p.StartInfo.FileName = flname;
				p.StartInfo.Arguments = arg;

				p.Start();

				p.WaitForExit();
				p.Close();

				DDSData[] ret = ImageLoader.ParesDDS(ddsfile);
				if (System.IO.File.Exists(ddsfile))
				{
					System.IO.File.Delete(ddsfile);
				}

				return ret;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				if (System.IO.File.Exists(ddsfile))
				{
					System.IO.File.Delete(ddsfile);
				}
			}

			return new DDSData[0];
		}

		public static void AddDDsData(ImageData id, DDSData[] data)
		{
			id.TextureSize = data[0].ParentSize;
			id.Format = data[0].Format;
			id.MipMapLevels = (uint)data.Length;

			id.MipMapBlocks[0].AddDDSData(data);
		}

		private void Build(object sender, EventArgs e)
		{
			string arg = "-sharpenMethod " + cbsharpen.Text + " ";
			foreach (string name in cbfilter.CheckedItems)
			{
				arg += "-" + name + " ";
			}

			try
			{
				dds = BuildDDS(
					img,
					Convert.ToInt32(tblevel.Text),
					(ImageLoader.TxtrFormats)cbformat.Items[cbformat.SelectedIndex],
					arg
				);
				Close();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}
	}
}
