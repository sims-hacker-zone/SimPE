using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.PackedFiles.Wthr
{
	partial class WinfoPackedFileUI
	{

		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.wiunk10lbl = new System.Windows.Forms.Label();
			this.wiunk10 = new System.Windows.Forms.TextBox();
			this.wiunk4lbl = new System.Windows.Forms.Label();
			this.wiunk4 = new System.Windows.Forms.TextBox();
			this.Notelbl = new System.Windows.Forms.Label();
			this.wiunk2 = new System.Windows.Forms.TextBox();
			this.wiunk3 = new System.Windows.Forms.TextBox();
			this.wiunk9 = new System.Windows.Forms.TextBox();
			this.wiunk2lbl = new System.Windows.Forms.Label();
			this.witemperatelbl = new System.Windows.Forms.Label();
			this.wiunk3lbl = new System.Windows.Forms.Label();
			this.witemperate = new System.Windows.Forms.TextBox();
			this.wiunk9lbl = new System.Windows.Forms.Label();
			this.wiunk5 = new System.Windows.Forms.TextBox();
			this.wiunk5lbl = new System.Windows.Forms.Label();
			this.wiunk6 = new System.Windows.Forms.TextBox();
			this.wiunk6lbl = new System.Windows.Forms.Label();
			this.wiunk8lbl = new System.Windows.Forms.Label();
			this.wiunk7 = new System.Windows.Forms.TextBox();
			this.wiunk8 = new System.Windows.Forms.TextBox();
			this.wiunk7lbl = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.wiversionlbl = new System.Windows.Forms.Label();
			this.wiversion = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			// groupBox1
			//
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.wiunk10lbl);
			this.groupBox1.Controls.Add(this.wiunk10);
			this.groupBox1.Controls.Add(this.wiunk4lbl);
			this.groupBox1.Controls.Add(this.wiunk4);
			this.groupBox1.Controls.Add(this.Notelbl);
			this.groupBox1.Controls.Add(this.wiunk2);
			this.groupBox1.Controls.Add(this.wiunk3);
			this.groupBox1.Controls.Add(this.wiunk9);
			this.groupBox1.Controls.Add(this.wiunk2lbl);
			this.groupBox1.Controls.Add(this.witemperatelbl);
			this.groupBox1.Controls.Add(this.wiunk3lbl);
			this.groupBox1.Controls.Add(this.witemperate);
			this.groupBox1.Controls.Add(this.wiunk9lbl);
			this.groupBox1.Controls.Add(this.wiunk5);
			this.groupBox1.Controls.Add(this.wiunk5lbl);
			this.groupBox1.Controls.Add(this.wiunk6);
			this.groupBox1.Controls.Add(this.wiunk6lbl);
			this.groupBox1.Controls.Add(this.wiunk8lbl);
			this.groupBox1.Controls.Add(this.wiunk7);
			this.groupBox1.Controls.Add(this.wiunk8);
			this.groupBox1.Controls.Add(this.wiunk7lbl);
			this.groupBox1.Location = new System.Drawing.Point(8, 136);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(612, 292);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			//
			// wiunk10lbl
			//
			this.wiunk10lbl.AutoSize = true;
			this.wiunk10lbl.BackColor = System.Drawing.Color.Transparent;
			this.wiunk10lbl.Location = new System.Drawing.Point(112, 263);
			this.wiunk10lbl.Name = "wiunk10lbl";
			this.wiunk10lbl.Size = new System.Drawing.Size(287, 19);
			this.wiunk10lbl.TabIndex = 26;
			this.wiunk10lbl.Text = "Pond Frozen State (0 or 1 ~ 1=Frozen)";
			//
			// wiunk10
			//
			this.wiunk10.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiunk10.Location = new System.Drawing.Point(6, 262);
			this.wiunk10.Name = "wiunk10";
			this.wiunk10.Size = new System.Drawing.Size(100, 21);
			this.wiunk10.TabIndex = 25;
			this.wiunk10.TextChanged += new System.EventHandler(this.wiunk10_TextChanged);
			//
			// wiunk4lbl
			//
			this.wiunk4lbl.AutoSize = true;
			this.wiunk4lbl.BackColor = System.Drawing.Color.Transparent;
			this.wiunk4lbl.Location = new System.Drawing.Point(112, 95);
			this.wiunk4lbl.Name = "wiunk4lbl";
			this.wiunk4lbl.Size = new System.Drawing.Size(175, 19);
			this.wiunk4lbl.TabIndex = 24;
			this.wiunk4lbl.Text = "Season Days Additional";
			//
			// wiunk4
			//
			this.wiunk4.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiunk4.Location = new System.Drawing.Point(6, 94);
			this.wiunk4.Name = "wiunk4";
			this.wiunk4.Size = new System.Drawing.Size(100, 21);
			this.wiunk4.TabIndex = 23;
			this.wiunk4.TextChanged += new System.EventHandler(this.wiunk4_TextChanged);
			//
			// Notelbl
			//
			this.Notelbl.AutoSize = true;
			this.Notelbl.BackColor = System.Drawing.Color.Transparent;
			this.Notelbl.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Notelbl.Location = new System.Drawing.Point(364, 31);
			this.Notelbl.Name = "Notelbl";
			this.Notelbl.Size = new System.Drawing.Size(235, 230);
			this.Notelbl.TabIndex = 22;
			this.Notelbl.Text = "Precipitation and Accumulation\r\nType 0 is None\r\nType 1 is Snow\r\nType 2 is Rain\r\nT" +
				"ype 3 is Hail\r\n\r\nLevel 0 is None\r\nLevel 1 is Light\r\nLevel 2 is Heavy\r\nLevel 3 is" +
				" Torrential";
			//
			// wiunk2
			//
			this.wiunk2.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiunk2.Location = new System.Drawing.Point(6, 38);
			this.wiunk2.Name = "wiunk2";
			this.wiunk2.Size = new System.Drawing.Size(100, 21);
			this.wiunk2.TabIndex = 2;
			this.wiunk2.TextChanged += new System.EventHandler(this.wiunk2_TextChanged);
			//
			// wiunk3
			//
			this.wiunk3.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiunk3.Location = new System.Drawing.Point(6, 66);
			this.wiunk3.Name = "wiunk3";
			this.wiunk3.Size = new System.Drawing.Size(100, 21);
			this.wiunk3.TabIndex = 3;
			this.wiunk3.TextChanged += new System.EventHandler(this.wiunk3_TextChanged);
			//
			// wiunk9
			//
			this.wiunk9.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiunk9.Location = new System.Drawing.Point(6, 234);
			this.wiunk9.Name = "wiunk9";
			this.wiunk9.Size = new System.Drawing.Size(100, 21);
			this.wiunk9.TabIndex = 4;
			this.wiunk9.TextChanged += new System.EventHandler(this.wiunk9_TextChanged);
			//
			// wiunk2lbl
			//
			this.wiunk2lbl.AutoSize = true;
			this.wiunk2lbl.BackColor = System.Drawing.Color.Transparent;
			this.wiunk2lbl.Location = new System.Drawing.Point(112, 39);
			this.wiunk2lbl.Name = "wiunk2lbl";
			this.wiunk2lbl.Size = new System.Drawing.Size(189, 19);
			this.wiunk2lbl.TabIndex = 8;
			this.wiunk2lbl.Text = "Season Quadrant (0 to 3)";
			//
			// witemperatelbl
			//
			this.witemperatelbl.AutoSize = true;
			this.witemperatelbl.BackColor = System.Drawing.Color.Transparent;
			this.witemperatelbl.Location = new System.Drawing.Point(112, 12);
			this.witemperatelbl.Name = "witemperatelbl";
			this.witemperatelbl.Size = new System.Drawing.Size(185, 19);
			this.witemperatelbl.TabIndex = 21;
			this.witemperatelbl.Text = "Temperature (0�c ~ 0�f)";
			//
			// wiunk3lbl
			//
			this.wiunk3lbl.AutoSize = true;
			this.wiunk3lbl.BackColor = System.Drawing.Color.Transparent;
			this.wiunk3lbl.Location = new System.Drawing.Point(112, 67);
			this.wiunk3lbl.Name = "wiunk3lbl";
			this.wiunk3lbl.Size = new System.Drawing.Size(143, 19);
			this.wiunk3lbl.TabIndex = 9;
			this.wiunk3lbl.Text = "Days left in Season";
			//
			// witemperate
			//
			this.witemperate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.witemperate.Location = new System.Drawing.Point(6, 11);
			this.witemperate.Name = "witemperate";
			this.witemperate.Size = new System.Drawing.Size(100, 21);
			this.witemperate.TabIndex = 20;
			this.witemperate.TextChanged += new System.EventHandler(this.witemperate_TextChanged);
			//
			// wiunk9lbl
			//
			this.wiunk9lbl.AutoSize = true;
			this.wiunk9lbl.BackColor = System.Drawing.Color.Transparent;
			this.wiunk9lbl.Location = new System.Drawing.Point(112, 235);
			this.wiunk9lbl.Name = "wiunk9lbl";
			this.wiunk9lbl.Size = new System.Drawing.Size(223, 19);
			this.wiunk9lbl.TabIndex = 10;
			this.wiunk9lbl.Text = "Sky Clarity (0 or 1 ~ 0=Clear)";
			//
			// wiunk5
			//
			this.wiunk5.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiunk5.Location = new System.Drawing.Point(6, 122);
			this.wiunk5.Name = "wiunk5";
			this.wiunk5.Size = new System.Drawing.Size(100, 21);
			this.wiunk5.TabIndex = 12;
			this.wiunk5.TextChanged += new System.EventHandler(this.wiunk5_TextChanged);
			//
			// wiunk5lbl
			//
			this.wiunk5lbl.AutoSize = true;
			this.wiunk5lbl.BackColor = System.Drawing.Color.Transparent;
			this.wiunk5lbl.Location = new System.Drawing.Point(112, 123);
			this.wiunk5lbl.Name = "wiunk5lbl";
			this.wiunk5lbl.Size = new System.Drawing.Size(195, 19);
			this.wiunk5lbl.TabIndex = 13;
			this.wiunk5lbl.Text = "Precipitation Type (0 to 3)";
			//
			// wiunk6
			//
			this.wiunk6.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiunk6.Location = new System.Drawing.Point(6, 150);
			this.wiunk6.Name = "wiunk6";
			this.wiunk6.Size = new System.Drawing.Size(100, 21);
			this.wiunk6.TabIndex = 14;
			this.wiunk6.TextChanged += new System.EventHandler(this.wiunk6_TextChanged);
			//
			// wiunk6lbl
			//
			this.wiunk6lbl.AutoSize = true;
			this.wiunk6lbl.BackColor = System.Drawing.Color.Transparent;
			this.wiunk6lbl.Location = new System.Drawing.Point(112, 151);
			this.wiunk6lbl.Name = "wiunk6lbl";
			this.wiunk6lbl.Size = new System.Drawing.Size(196, 19);
			this.wiunk6lbl.TabIndex = 15;
			this.wiunk6lbl.Text = "Precipitation Level (0 to 3)";
			//
			// wiunk8lbl
			//
			this.wiunk8lbl.AutoSize = true;
			this.wiunk8lbl.BackColor = System.Drawing.Color.Transparent;
			this.wiunk8lbl.Location = new System.Drawing.Point(112, 207);
			this.wiunk8lbl.Name = "wiunk8lbl";
			this.wiunk8lbl.Size = new System.Drawing.Size(204, 19);
			this.wiunk8lbl.TabIndex = 19;
			this.wiunk8lbl.Text = "Accumulation Type (0 to 3)";
			//
			// wiunk7
			//
			this.wiunk7.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiunk7.Location = new System.Drawing.Point(6, 178);
			this.wiunk7.Name = "wiunk7";
			this.wiunk7.Size = new System.Drawing.Size(100, 21);
			this.wiunk7.TabIndex = 16;
			this.wiunk7.TextChanged += new System.EventHandler(this.wiunk7_TextChanged);
			//
			// wiunk8
			//
			this.wiunk8.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiunk8.Location = new System.Drawing.Point(6, 206);
			this.wiunk8.Name = "wiunk8";
			this.wiunk8.Size = new System.Drawing.Size(100, 21);
			this.wiunk8.TabIndex = 18;
			this.wiunk8.TextChanged += new System.EventHandler(this.wiunk8_TextChanged);
			//
			// wiunk7lbl
			//
			this.wiunk7lbl.AutoSize = true;
			this.wiunk7lbl.BackColor = System.Drawing.Color.Transparent;
			this.wiunk7lbl.Location = new System.Drawing.Point(112, 179);
			this.wiunk7lbl.Name = "wiunk7lbl";
			this.wiunk7lbl.Size = new System.Drawing.Size(205, 19);
			this.wiunk7lbl.TabIndex = 17;
			this.wiunk7lbl.Text = "Accumulation Level (0 to 2)";
			//
			// textBox1
			//
			this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(8, 80);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(612, 23);
			this.textBox1.TabIndex = 28;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Blackadder ITC", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(56, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(335, 41);
			this.label1.TabIndex = 1;
			this.label1.Visible = false;
			//
			// wiversionlbl
			//
			this.wiversionlbl.AutoSize = true;
			this.wiversionlbl.BackColor = System.Drawing.Color.Transparent;
			this.wiversionlbl.Location = new System.Drawing.Point(120, 110);
			this.wiversionlbl.Name = "wiversionlbl";
			this.wiversionlbl.Size = new System.Drawing.Size(62, 19);
			this.wiversionlbl.TabIndex = 6;
			this.wiversionlbl.Text = "Version";
			//
			// wiversion
			//
			this.wiversion.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.wiversion.Location = new System.Drawing.Point(14, 109);
			this.wiversion.Name = "wiversion";
			this.wiversion.ReadOnly = true;
			this.wiversion.Size = new System.Drawing.Size(100, 21);
			this.wiversion.TabIndex = 0;
			//
			// WinfoPackedFileUI
			//
			this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
			this.BackgroundImageLocation = new System.Drawing.Point(622, 0);
			this.BackgroundImageZoomToFit = true;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.wiversionlbl);
			this.Controls.Add(this.wiversion);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Tahoma", 12F);
			this.HeaderText = "Weather Information Reader";
			this.Name = "WinfoPackedFileUI";
			this.Size = new System.Drawing.Size(1150, 434);
			this.Controls.SetChildIndex(this.wiversion, 0);
			this.Controls.SetChildIndex(this.wiversionlbl, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.textBox1, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label wiversionlbl;
		private System.Windows.Forms.Label wiunk9lbl;
		private System.Windows.Forms.Label wiunk3lbl;
		private System.Windows.Forms.Label wiunk2lbl;
		internal System.Windows.Forms.TextBox wiversion;
		internal System.Windows.Forms.TextBox wiunk9;
		internal System.Windows.Forms.TextBox wiunk3;
		internal System.Windows.Forms.TextBox wiunk2;
		private System.Windows.Forms.Label witemperatelbl;
		internal System.Windows.Forms.TextBox witemperate;
		private System.Windows.Forms.Label wiunk8lbl;
		internal System.Windows.Forms.TextBox wiunk8;
		private System.Windows.Forms.Label wiunk7lbl;
		internal System.Windows.Forms.TextBox wiunk7;
		private System.Windows.Forms.Label wiunk6lbl;
		internal System.Windows.Forms.TextBox wiunk6;
		private System.Windows.Forms.Label wiunk5lbl;
		internal System.Windows.Forms.TextBox wiunk5;
		internal System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label Notelbl;
		private System.Windows.Forms.Label wiunk10lbl;
		internal System.Windows.Forms.TextBox wiunk10;
		private System.Windows.Forms.Label wiunk4lbl;
		internal System.Windows.Forms.TextBox wiunk4;
	}
}
