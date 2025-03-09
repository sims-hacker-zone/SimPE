using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.PackedFiles.Gtip
{
	partial class GtipUI
	{

		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.gtbodytxt = new System.Windows.Forms.TextBox();
			this.gtheadtxt = new System.Windows.Forms.Label();
			this.gtnametxt = new System.Windows.Forms.Label();
			this.gtpbimage = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.gtimaglbl = new System.Windows.Forms.Label();
			this.gtepacklbl = new System.Windows.Forms.Label();
			this.gtbodylbl = new System.Windows.Forms.Label();
			this.gtheadlbl = new System.Windows.Forms.Label();
			this.gtnamelbl = new System.Windows.Forms.Label();
			this.gtimagy = new System.Windows.Forms.TextBox();
			this.gtepack = new System.Windows.Forms.TextBox();
			this.gtbody = new System.Windows.Forms.TextBox();
			this.gtheader = new System.Windows.Forms.TextBox();
			this.gtname = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.gtpbimage)).BeginInit();
			this.SuspendLayout();
			//
			// button1
			//
			this.button1.Location = new System.Drawing.Point(141, 248);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(74, 61);
			this.button1.TabIndex = 15;
			this.button1.Text = "Show\r\nTexts";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			//
			// gtbodytxt
			//
			this.gtbodytxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.gtbodytxt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.gtbodytxt.Location = new System.Drawing.Point(265, 147);
			this.gtbodytxt.Multiline = true;
			this.gtbodytxt.Name = "gtbodytxt";
			this.gtbodytxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.gtbodytxt.Size = new System.Drawing.Size(383, 257);
			this.gtbodytxt.TabIndex = 14;
			//
			// gtheadtxt
			//
			this.gtheadtxt.AutoSize = true;
			this.gtheadtxt.BackColor = System.Drawing.Color.Transparent;
			this.gtheadtxt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.gtheadtxt.Location = new System.Drawing.Point(265, 123);
			this.gtheadtxt.Name = "gtheadtxt";
			this.gtheadtxt.Size = new System.Drawing.Size(15, 19);
			this.gtheadtxt.TabIndex = 13;
			this.gtheadtxt.Text = "-";
			//
			// gtnametxt
			//
			this.gtnametxt.AutoSize = true;
			this.gtnametxt.BackColor = System.Drawing.Color.Transparent;
			this.gtnametxt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.gtnametxt.Location = new System.Drawing.Point(265, 96);
			this.gtnametxt.Name = "gtnametxt";
			this.gtnametxt.Size = new System.Drawing.Size(15, 19);
			this.gtnametxt.TabIndex = 12;
			this.gtnametxt.Text = "-";
			//
			// gtpbimage
			//
			this.gtpbimage.Location = new System.Drawing.Point(17, 248);
			this.gtpbimage.Name = "gtpbimage";
			this.gtpbimage.Size = new System.Drawing.Size(100, 92);
			this.gtpbimage.TabIndex = 11;
			this.gtpbimage.TabStop = false;
			//
			// gtimaglbl
			//
			this.gtimaglbl.AutoSize = true;
			this.gtimaglbl.BackColor = System.Drawing.Color.Transparent;
			this.gtimaglbl.Location = new System.Drawing.Point(123, 204);
			this.gtimaglbl.Name = "gtimaglbl";
			this.gtimaglbl.Size = new System.Drawing.Size(118, 19);
			this.gtimaglbl.TabIndex = 10;
			this.gtimaglbl.Text = "Image Instance";
			//
			// gtepacklbl
			//
			this.gtepacklbl.AutoSize = true;
			this.gtepacklbl.BackColor = System.Drawing.Color.Transparent;
			this.gtepacklbl.Location = new System.Drawing.Point(123, 177);
			this.gtepacklbl.Name = "gtepacklbl";
			this.gtepacklbl.Size = new System.Drawing.Size(118, 19);
			this.gtepacklbl.TabIndex = 9;
			this.gtepacklbl.Text = "Expansion Pack";
			//
			// gtbodylbl
			//
			this.gtbodylbl.AutoSize = true;
			this.gtbodylbl.BackColor = System.Drawing.Color.Transparent;
			this.gtbodylbl.Location = new System.Drawing.Point(123, 150);
			this.gtbodylbl.Name = "gtbodylbl";
			this.gtbodylbl.Size = new System.Drawing.Size(114, 19);
			this.gtbodylbl.TabIndex = 8;
			this.gtbodylbl.Text = "Game Tip Text";
			//
			// gtheadlbl
			//
			this.gtheadlbl.AutoSize = true;
			this.gtheadlbl.BackColor = System.Drawing.Color.Transparent;
			this.gtheadlbl.Location = new System.Drawing.Point(123, 123);
			this.gtheadlbl.Name = "gtheadlbl";
			this.gtheadlbl.Size = new System.Drawing.Size(133, 19);
			this.gtheadlbl.TabIndex = 7;
			this.gtheadlbl.Text = "Game Tip Header";
			//
			// gtnamelbl
			//
			this.gtnamelbl.AutoSize = true;
			this.gtnamelbl.BackColor = System.Drawing.Color.Transparent;
			this.gtnamelbl.Location = new System.Drawing.Point(123, 96);
			this.gtnamelbl.Name = "gtnamelbl";
			this.gtnamelbl.Size = new System.Drawing.Size(124, 19);
			this.gtnamelbl.TabIndex = 6;
			this.gtnamelbl.Text = "Game Tip Name";
			//
			// gtimagy
			//
			this.gtimagy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.gtimagy.Location = new System.Drawing.Point(17, 206);
			this.gtimagy.Name = "gtimagy";
			this.gtimagy.Size = new System.Drawing.Size(100, 21);
			this.gtimagy.TabIndex = 4;
			this.gtimagy.TextChanged += new System.EventHandler(this.gtimagy_TextChanged);
			//
			// gtepack
			//
			this.gtepack.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.gtepack.Location = new System.Drawing.Point(17, 178);
			this.gtepack.Name = "gtepack";
			this.gtepack.Size = new System.Drawing.Size(100, 21);
			this.gtepack.TabIndex = 3;
			this.gtepack.TextChanged += new System.EventHandler(this.gtepack_TextChanged);
			//
			// gtbody
			//
			this.gtbody.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.gtbody.Location = new System.Drawing.Point(17, 150);
			this.gtbody.Name = "gtbody";
			this.gtbody.Size = new System.Drawing.Size(100, 21);
			this.gtbody.TabIndex = 2;
			this.gtbody.TextChanged += new System.EventHandler(this.gtbody_TextChanged);
			//
			// gtheader
			//
			this.gtheader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.gtheader.Location = new System.Drawing.Point(17, 122);
			this.gtheader.Name = "gtheader";
			this.gtheader.Size = new System.Drawing.Size(100, 21);
			this.gtheader.TabIndex = 1;
			this.gtheader.TextChanged += new System.EventHandler(this.gtheader_TextChanged);
			//
			// gtname
			//
			this.gtname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.gtname.Location = new System.Drawing.Point(17, 94);
			this.gtname.Name = "gtname";
			this.gtname.Size = new System.Drawing.Size(100, 21);
			this.gtname.TabIndex = 0;
			this.gtname.TextChanged += new System.EventHandler(this.gtname_TextChanged);
			//
			// GametipPackedFileUI
			//
			this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
			this.BackgroundImageLocation = new System.Drawing.Point(650, 0);
			this.BackgroundImageZoomToFit = true;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.gtbodytxt);
			this.Controls.Add(this.gtheadtxt);
			this.Controls.Add(this.gtnametxt);
			this.Controls.Add(this.gtpbimage);
			this.Controls.Add(this.gtname);
			this.Controls.Add(this.gtimaglbl);
			this.Controls.Add(this.gtepacklbl);
			this.Controls.Add(this.gtbodylbl);
			this.Controls.Add(this.gtheadlbl);
			this.Controls.Add(this.gtnamelbl);
			this.Controls.Add(this.gtimagy);
			this.Controls.Add(this.gtepack);
			this.Controls.Add(this.gtbody);
			this.Controls.Add(this.gtheader);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Tahoma", 12F);
			this.HeaderText = "Game Tip";
			this.Name = "GametipPackedFileUI";
			this.Size = new System.Drawing.Size(1300, 416);
			this.Controls.SetChildIndex(this.gtheader, 0);
			this.Controls.SetChildIndex(this.gtbody, 0);
			this.Controls.SetChildIndex(this.gtepack, 0);
			this.Controls.SetChildIndex(this.gtimagy, 0);
			this.Controls.SetChildIndex(this.gtnamelbl, 0);
			this.Controls.SetChildIndex(this.gtheadlbl, 0);
			this.Controls.SetChildIndex(this.gtbodylbl, 0);
			this.Controls.SetChildIndex(this.gtepacklbl, 0);
			this.Controls.SetChildIndex(this.gtimaglbl, 0);
			this.Controls.SetChildIndex(this.gtname, 0);
			this.Controls.SetChildIndex(this.gtpbimage, 0);
			this.Controls.SetChildIndex(this.gtnametxt, 0);
			this.Controls.SetChildIndex(this.gtheadtxt, 0);
			this.Controls.SetChildIndex(this.gtbodytxt, 0);
			this.Controls.SetChildIndex(this.button1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			((System.ComponentModel.ISupportInitialize)(this.gtpbimage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label gtnamelbl;
		private System.Windows.Forms.Label gtimaglbl;
		private System.Windows.Forms.Label gtepacklbl;
		private System.Windows.Forms.Label gtbodylbl;
		private System.Windows.Forms.Label gtheadlbl;
		internal System.Windows.Forms.TextBox gtheader;
		internal System.Windows.Forms.TextBox gtname;
		internal System.Windows.Forms.TextBox gtimagy;
		internal System.Windows.Forms.TextBox gtepack;
		internal System.Windows.Forms.TextBox gtbody;
		internal System.Windows.Forms.PictureBox gtpbimage;
		private System.Windows.Forms.Label gtheadtxt;
		private System.Windows.Forms.Label gtnametxt;
		private System.Windows.Forms.TextBox gtbodytxt;
		private System.Windows.Forms.Button button1;
	}
}
