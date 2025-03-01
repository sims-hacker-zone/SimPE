// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImageSize.
	/// </summary>
	public class ImageSize : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbheight;
		private System.Windows.Forms.TextBox tbwidth;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		ImageSize()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			//
			// TODO: F�gen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
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
			label5 = new System.Windows.Forms.Label();
			tbheight = new System.Windows.Forms.TextBox();
			tbwidth = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
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
			label5.Location = new Point(104, 16);
			label5.Name = "label5";
			label5.Size = new Size(12, 17);
			label5.TabIndex = 19;
			label5.Text = "x";
			//
			// tbheight
			//
			tbheight.Location = new Point(128, 8);
			tbheight.Name = "tbheight";
			tbheight.Size = new Size(56, 21);
			tbheight.TabIndex = 18;
			tbheight.Text = "";
			//
			// tbwidth
			//
			tbwidth.Location = new Point(48, 8);
			tbwidth.Name = "tbwidth";
			tbwidth.Size = new Size(56, 21);
			tbwidth.TabIndex = 17;
			tbwidth.Text = "";
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
			label4.Location = new Point(8, 16);
			label4.Name = "label4";
			label4.Size = new Size(35, 17);
			label4.TabIndex = 16;
			label4.Text = "Size:";
			//
			// button1
			//
			button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			button1.Location = new Point(112, 40);
			button1.Name = "button1";
			button1.TabIndex = 20;
			button1.Text = "OK";
			button1.Click += new System.EventHandler(button1_Click);
			//
			// ImageSize
			//
			AutoScaleBaseSize = new Size(5, 14);
			ClientSize = new Size(194, 72);
			ControlBox = false;
			Controls.Add(button1);
			Controls.Add(label5);
			Controls.Add(tbheight);
			Controls.Add(tbwidth);
			Controls.Add(label4);
			Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				0
			);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			Name = "ImageSize";
			Text = "Image Size";
			ResumeLayout(false);
		}
		#endregion

		public static Size Execute(Size sz)
		{
			ImageSize f = new ImageSize();
			f.tbheight.Text = sz.Height.ToString();
			f.tbwidth.Text = sz.Width.ToString();

			RemoteControl.ShowSubForm(f);

			Size nsz = new Size(
				Helper.StringToInt32(f.tbwidth.Text, sz.Width, 10),
				Helper.StringToInt32(f.tbheight.Text, sz.Height, 10)
			);
			return nsz;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
