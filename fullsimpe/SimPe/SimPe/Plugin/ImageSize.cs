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
			this.label5 = new System.Windows.Forms.Label();
			this.tbheight = new System.Windows.Forms.TextBox();
			this.tbwidth = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label5.Location = new Point(104, 16);
			this.label5.Name = "label5";
			this.label5.Size = new Size(12, 17);
			this.label5.TabIndex = 19;
			this.label5.Text = "x";
			//
			// tbheight
			//
			this.tbheight.Location = new Point(128, 8);
			this.tbheight.Name = "tbheight";
			this.tbheight.Size = new Size(56, 21);
			this.tbheight.TabIndex = 18;
			this.tbheight.Text = "";
			//
			// tbwidth
			//
			this.tbwidth.Location = new Point(48, 8);
			this.tbwidth.Name = "tbwidth";
			this.tbwidth.Size = new Size(56, 21);
			this.tbwidth.TabIndex = 17;
			this.tbwidth.Text = "";
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Font = new Font(
				"Verdana",
				8.25F,
				FontStyle.Bold,
				GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.label4.Location = new Point(8, 16);
			this.label4.Name = "label4";
			this.label4.Size = new Size(35, 17);
			this.label4.TabIndex = 16;
			this.label4.Text = "Size:";
			//
			// button1
			//
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new Point(112, 40);
			this.button1.Name = "button1";
			this.button1.TabIndex = 20;
			this.button1.Text = "OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			//
			// ImageSize
			//
			this.AutoScaleBaseSize = new Size(5, 14);
			this.ClientSize = new Size(194, 72);
			this.ControlBox = false;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbheight);
			this.Controls.Add(this.tbwidth);
			this.Controls.Add(this.label4);
			this.Font = new Font(
				"Tahoma",
				8.25F,
				FontStyle.Regular,
				GraphicsUnit.Point,
				((System.Byte)(0))
			);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ImageSize";
			this.Text = "Image Size";
			this.ResumeLayout(false);
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
