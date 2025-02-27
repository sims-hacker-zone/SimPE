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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(DDSTool));
			this.pb = new PictureBox();
			this.linkLabel1 = new LinkLabel();
			this.ofd = new OpenFileDialog();
			this.groupBox1 = new GroupBox();
			this.cbformat = new ComboBox();
			this.label6 = new Label();
			this.tbheight = new TextBox();
			this.tbwidth = new TextBox();
			this.tblevel = new TextBox();
			this.cbfilter = new CheckedListBox();
			this.label5 = new Label();
			this.cbsharpen = new ComboBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.button1 = new Button();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			// pb
			//
			this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pb.Location = new Point(16, 24);
			this.pb.Name = "pb";
			this.pb.Size = new Size(128, 128);
			this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb.TabIndex = 0;
			this.pb.TabStop = false;
			//
			// linkLabel1
			//
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.linkLabel1.LinkArea = new LinkArea(0, 4);
			this.linkLabel1.Location = new Point(48, 160);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new Size(93, 18);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "open Image...";
			this.linkLabel1.UseCompatibleTextRendering = true;
			this.linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.linkLabel1_LinkClicked
				);
			//
			// ofd
			//
			this.ofd.Filter =
				"All Image Files (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png|Bitmap (*.bmp)|"
				+ "*.bmp|Gif (*.gif)|*.gif|JPEG File (*.jpg)|*.jpg|Png (*.png)|*.png|All Files (*.*"
				+ ")|*.*";
			//
			// groupBox1
			//
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.cbformat);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbheight);
			this.groupBox1.Controls.Add(this.tbwidth);
			this.groupBox1.Controls.Add(this.tblevel);
			this.groupBox1.Controls.Add(this.cbfilter);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.cbsharpen);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.groupBox1.Location = new Point(160, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(312, 208);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			//
			// cbformat
			//
			this.cbformat.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbformat.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbformat.Items.AddRange(
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
			this.cbformat.Location = new Point(80, 64);
			this.cbformat.Name = "cbformat";
			this.cbformat.Size = new Size(224, 21);
			this.cbformat.TabIndex = 12;
			//
			// label6
			//
			this.label6.AutoSize = true;
			this.label6.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label6.Location = new Point(136, 48);
			this.label6.Name = "label6";
			this.label6.Size = new Size(14, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "x";
			//
			// tbheight
			//
			this.tbheight.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbheight.Location = new Point(152, 40);
			this.tbheight.Name = "tbheight";
			this.tbheight.ReadOnly = true;
			this.tbheight.Size = new Size(48, 21);
			this.tbheight.TabIndex = 10;
			this.tbheight.Text = "0";
			//
			// tbwidth
			//
			this.tbwidth.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tbwidth.Location = new Point(80, 40);
			this.tbwidth.Name = "tbwidth";
			this.tbwidth.ReadOnly = true;
			this.tbwidth.Size = new Size(48, 21);
			this.tbwidth.TabIndex = 9;
			this.tbwidth.Text = "0";
			//
			// tblevel
			//
			this.tblevel.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.tblevel.Location = new Point(80, 16);
			this.tblevel.Name = "tblevel";
			this.tblevel.Size = new Size(80, 21);
			this.tblevel.TabIndex = 8;
			this.tblevel.Text = "0";
			//
			// cbfilter
			//
			this.cbfilter.CheckOnClick = true;
			this.cbfilter.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbfilter.IntegralHeight = false;
			this.cbfilter.Items.AddRange(
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
			this.cbfilter.Location = new Point(80, 120);
			this.cbfilter.Name = "cbfilter";
			this.cbfilter.Size = new Size(224, 80);
			this.cbfilter.TabIndex = 7;
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label5.Location = new Point(35, 120);
			this.label5.Name = "label5";
			this.label5.Size = new Size(40, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Filter:";
			//
			// cbsharpen
			//
			this.cbsharpen.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbsharpen.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.cbsharpen.Items.AddRange(
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
			this.cbsharpen.Location = new Point(80, 88);
			this.cbsharpen.Name = "cbsharpen";
			this.cbsharpen.Size = new Size(224, 21);
			this.cbsharpen.TabIndex = 5;
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label4.Location = new Point(16, 96);
			this.label4.Name = "label4";
			this.label4.Size = new Size(60, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Sharpen:";
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.label3.Location = new Point(23, 72);
			this.label3.Name = "label3";
			this.label3.Size = new Size(52, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Format:";
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
			this.label2.Location = new Point(40, 48);
			this.label2.Name = "label2";
			this.label2.Size = new Size(36, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Size:";
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
			this.label1.Location = new Point(28, 24);
			this.label1.Name = "label1";
			this.label1.Size = new Size(48, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Levels:";
			//
			// button1
			//
			this.button1.Anchor = (
				(AnchorStyles)(
					(
						System.Windows.Forms.AnchorStyles.Bottom
						| System.Windows.Forms.AnchorStyles.Right
					)
				)
			);
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new Point(397, 224);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Build";
			this.button1.Click += new EventHandler(this.Build);
			//
			// DDSTool
			//
			this.AutoScaleBaseSize = new Size(6, 14);
			this.ClientSize = new Size(480, 254);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.pb);
			this.Font = new Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DDSTool";
			this.Text = "DDS Builder";
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
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

			this.cbsharpen.SelectedIndex = 0;
			this.tblevel.Text = level.ToString();
			this.tbwidth.Text = size.Width.ToString();
			this.tbheight.Text = size.Height.ToString();

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

			this.button1.Enabled = false;
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
				this.button1.Enabled = (img != null);
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
