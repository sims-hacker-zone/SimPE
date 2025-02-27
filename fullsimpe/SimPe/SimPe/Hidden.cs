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
using System.Windows.Forms;

namespace SimPe
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
				new System.ComponentModel.ComponentResourceManager(typeof(Hidden));
			this.label1 = new Label();
			this.tbComp = new TextBox();
			this.tbBig = new TextBox();
			this.label2 = new Label();
			this.label3 = new Label();
			this.lbMem = new Label();
			this.button1 = new Button();
			this.button2 = new Button();
			this.button3 = new Button();
			this.button4 = new Button();
			this.SuspendLayout();
			//
			// label1
			//
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Compression Strength:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// tbComp
			//
			this.tbComp.Location = new System.Drawing.Point(200, 24);
			this.tbComp.Name = "tbComp";
			this.tbComp.Size = new System.Drawing.Size(104, 21);
			this.tbComp.TabIndex = 1;
			//
			// tbBig
			//
			this.tbBig.Location = new System.Drawing.Point(200, 48);
			this.tbBig.Name = "tbBig";
			this.tbBig.Size = new System.Drawing.Size(104, 21);
			this.tbBig.TabIndex = 3;
			//
			// label2
			//
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Big Package Resource Count:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// label3
			//
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(176, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Used Memory:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			//
			// lbMem
			//
			this.lbMem.Location = new System.Drawing.Point(200, 88);
			this.lbMem.Name = "lbMem";
			this.lbMem.Size = new System.Drawing.Size(176, 23);
			this.lbMem.TabIndex = 6;
			this.lbMem.Text = "0";
			this.lbMem.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			//
			// button1
			//
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(200, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Collect Garbage";
			this.button1.Click += new EventHandler(this.button1_Click);
			//
			// button2
			//
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(8, 160);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "StreamManager";
			this.button2.Click += new EventHandler(this.button2_Click);
			//
			// button3
			//
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button3.Location = new System.Drawing.Point(144, 160);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(128, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "File Table Content";
			this.button3.Click += new EventHandler(this.button3_Click);
			//
			// button4
			//
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button4.Location = new System.Drawing.Point(318, 160);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(128, 23);
			this.button4.TabIndex = 10;
			this.button4.Text = "Properties";
			this.button4.Click += new EventHandler(this.button4_Click);
			//
			// Hidden
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(458, 192);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lbMem);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbBig);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbComp);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				((byte)(0))
			);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Hidden";
			this.Opacity = 0.8;
			this.Text = "Hidden";
			this.Closed += new EventHandler(this.Hidden_Closed);
			this.Load += new EventHandler(this.Hidden_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		private void Hidden_Load(object sender, EventArgs e)
		{
			UpdateDialog();
		}

		private void UpdateDialog()
		{
			this.tbComp.Text = SimPe.Packages.PackedFile.CompressionStrength.ToString();
			tbBig.Text = Helper.WindowsRegistry.BigPackageResourceCount.ToString();

			this.lbMem.Text = GC.GetTotalMemory(false).ToString("N0") + " Byte";
		}

		private void Hidden_Closed(object sender, EventArgs e)
		{
			try
			{
				SimPe.Packages.PackedFile.CompressionStrength = Convert.ToInt32(
					this.tbComp.Text
				);
				Helper.WindowsRegistry.BigPackageResourceCount = Convert.ToInt32(
					tbBig.Text
				);
			}
			catch { }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			this.lbMem.Text = GC.GetTotalMemory(false).ToString("N0") + " Byte";

			this.Cursor = Cursors.Default;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			SimPe.Packages.StreamFactory.WriteToConsole();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			SimPe.FileTable.FileIndex.WriteContentToConsole();
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
