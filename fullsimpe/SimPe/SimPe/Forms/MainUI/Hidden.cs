// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe.Forms.MainUI
{
	/// <summary>
	/// Summary description for Hidden.
	/// </summary>
	public class Hidden : Form
	{
		private Label label1;
		private TextBox tbComp;
		private TextBox tbBig;
		private Label label2;
		private Label label3;
		private Label lbMem;
		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Hidden()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
				new System.ComponentModel.ComponentResourceManager(typeof(Hidden));
			label1 = new Label();
			tbComp = new TextBox();
			tbBig = new TextBox();
			label2 = new Label();
			label3 = new Label();
			lbMem = new Label();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			button4 = new Button();
			SuspendLayout();
			//
			// label1
			//
			label1.Location = new System.Drawing.Point(16, 24);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(176, 23);
			label1.TabIndex = 0;
			label1.Text = "Compression Strength:";
			label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbComp
			//
			tbComp.Location = new System.Drawing.Point(200, 24);
			tbComp.Name = "tbComp";
			tbComp.Size = new System.Drawing.Size(104, 21);
			tbComp.TabIndex = 1;
			//
			// tbBig
			//
			tbBig.Location = new System.Drawing.Point(200, 48);
			tbBig.Name = "tbBig";
			tbBig.Size = new System.Drawing.Size(104, 21);
			tbBig.TabIndex = 3;
			//
			// label2
			//
			label2.Location = new System.Drawing.Point(16, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(176, 23);
			label2.TabIndex = 2;
			label2.Text = "Big Package Resource Count:";
			label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label3
			//
			label3.Location = new System.Drawing.Point(16, 88);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(176, 23);
			label3.TabIndex = 4;
			label3.Text = "Used Memory:";
			label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// lbMem
			//
			lbMem.Location = new System.Drawing.Point(200, 88);
			lbMem.Name = "lbMem";
			lbMem.Size = new System.Drawing.Size(176, 23);
			lbMem.TabIndex = 6;
			lbMem.Text = "0";
			lbMem.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// button1
			//
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new System.Drawing.Point(200, 112);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(120, 23);
			button1.TabIndex = 7;
			button1.Text = "Collect Garbage";
			button1.Click += new EventHandler(button1_Click);
			//
			// button2
			//
			button2.FlatStyle = FlatStyle.System;
			button2.Location = new System.Drawing.Point(8, 160);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(128, 23);
			button2.TabIndex = 8;
			button2.Text = "StreamManager";
			button2.Click += new EventHandler(button2_Click);
			//
			// button3
			//
			button3.FlatStyle = FlatStyle.System;
			button3.Location = new System.Drawing.Point(144, 160);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(128, 23);
			button3.TabIndex = 9;
			button3.Text = "File Table Content";
			button3.Click += new EventHandler(button3_Click);
			//
			// button4
			//
			button4.FlatStyle = FlatStyle.System;
			button4.Location = new System.Drawing.Point(318, 160);
			button4.Name = "button4";
			button4.Size = new System.Drawing.Size(128, 23);
			button4.TabIndex = 10;
			button4.Text = "Properties";
			button4.Click += new EventHandler(button4_Click);
			//
			// Hidden
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(458, 192);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(lbMem);
			Controls.Add(label3);
			Controls.Add(tbBig);
			Controls.Add(label2);
			Controls.Add(tbComp);
			Controls.Add(label1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "Hidden";
			Opacity = 0.8;
			Text = "Hidden";
			Closed += new EventHandler(Hidden_Closed);
			Load += new EventHandler(Hidden_Load);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private void Hidden_Load(object sender, EventArgs e)
		{
			UpdateDialog();
		}

		private void UpdateDialog()
		{
			tbComp.Text = Packages.PackedFile.CompressionStrength.ToString();
			tbBig.Text = Helper.WindowsRegistry.BigPackageResourceCount.ToString();

			lbMem.Text = GC.GetTotalMemory(false).ToString("N0") + " Byte";
		}

		private void Hidden_Closed(object sender, EventArgs e)
		{
			try
			{
				Packages.PackedFile.CompressionStrength = Convert.ToInt32(
					tbComp.Text
				);
				Helper.WindowsRegistry.BigPackageResourceCount = Convert.ToInt32(
					tbBig.Text
				);
			}
			catch { }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			lbMem.Text = GC.GetTotalMemory(false).ToString("N0") + " Byte";

			Cursor = Cursors.Default;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Packages.StreamFactory.WriteToConsole();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			FileTableBase.FileIndex.WriteContentToConsole();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Form f = new Form();
			PropertyGrid pg = new PropertyGrid();
			f.Controls.Add(pg);
			pg.Dock = DockStyle.Fill;
			f.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			f.Text = "SimPe Settings";
			pg.SelectedObject = Helper.WindowsRegistry;
			f.ShowDialog();
			UpdateDialog();
		}
	}
}
