using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.PackedFiles.Smap
{
	partial class StringMapPackedFileUI
	{

		private void InitializeComponent()
		{
			this.lbdatas = new System.Windows.Forms.Label();
			this.tbfilenm = new System.Windows.Forms.TextBox();
			this.lbfilenm = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.rtbStrings = new System.Windows.Forms.RichTextBox();
			this.rtbDatas = new System.Windows.Forms.RichTextBox();
			this.lbsrins = new System.Windows.Forms.Label();
			this.lbType = new System.Windows.Forms.Label();
			this.btshowim = new System.Windows.Forms.Button();
			this.rtbnames = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			//
			// lbdatas
			//
			this.lbdatas.AutoSize = true;
			this.lbdatas.BackColor = System.Drawing.Color.Transparent;
			this.lbdatas.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lbdatas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbdatas.Location = new System.Drawing.Point(436, 120);
			this.lbdatas.Name = "lbdatas";
			this.lbdatas.Size = new System.Drawing.Size(41, 13);
			this.lbdatas.TabIndex = 22;
			this.lbdatas.Text = "Data:";
			//
			// tbfilenm
			//
			this.tbfilenm.BackColor = System.Drawing.SystemColors.Window;
			this.tbfilenm.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbfilenm.Location = new System.Drawing.Point(78, 84);
			this.tbfilenm.Name = "tbfilenm";
			this.tbfilenm.Size = new System.Drawing.Size(642, 27);
			this.tbfilenm.TabIndex = 20;
			this.tbfilenm.WordWrap = false;
			this.tbfilenm.TextChanged += new System.EventHandler(this.tbfilenm_TextChanged);
			//
			// lbfilenm
			//
			this.lbfilenm.AutoSize = true;
			this.lbfilenm.BackColor = System.Drawing.Color.Transparent;
			this.lbfilenm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lbfilenm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbfilenm.Location = new System.Drawing.Point(3, 91);
			this.lbfilenm.Name = "lbfilenm";
			this.lbfilenm.Size = new System.Drawing.Size(71, 13);
			this.lbfilenm.TabIndex = 19;
			this.lbfilenm.Text = "Filename:";
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
			// rtbStrings
			//
			this.rtbStrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rtbStrings.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.rtbStrings.Location = new System.Drawing.Point(78, 117);
			this.rtbStrings.Name = "rtbStrings";
			this.rtbStrings.Size = new System.Drawing.Size(350, 286);
			this.rtbStrings.TabIndex = 23;
			this.rtbStrings.Text = "";
			this.rtbStrings.WordWrap = false;
			this.rtbStrings.TextChanged += new System.EventHandler(this.rtbStrings_TextChanged);
			//
			// rtbDatas
			//
			this.rtbDatas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rtbDatas.BackColor = System.Drawing.SystemColors.Window;
			this.rtbDatas.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.rtbDatas.Location = new System.Drawing.Point(480, 117);
			this.rtbDatas.Name = "rtbDatas";
			this.rtbDatas.ReadOnly = true;
			this.rtbDatas.Size = new System.Drawing.Size(240, 286);
			this.rtbDatas.TabIndex = 24;
			this.rtbDatas.Text = "";
			this.rtbDatas.WordWrap = false;
			//
			// lbsrins
			//
			this.lbsrins.AutoSize = true;
			this.lbsrins.BackColor = System.Drawing.Color.Transparent;
			this.lbsrins.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lbsrins.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lbsrins.Location = new System.Drawing.Point(17, 120);
			this.lbsrins.Name = "lbsrins";
			this.lbsrins.Size = new System.Drawing.Size(57, 13);
			this.lbsrins.TabIndex = 25;
			this.lbsrins.Text = "Strings:";
			//
			// lbType
			//
			this.lbType.AutoSize = true;
			this.lbType.BackColor = System.Drawing.Color.Transparent;
			this.lbType.Location = new System.Drawing.Point(465, 51);
			this.lbType.Name = "lbType";
			this.lbType.Size = new System.Drawing.Size(35, 15);
			this.lbType.TabIndex = 26;
			this.lbType.Text = "Type:";
			//
			// btshowim
			//
			this.btshowim.Location = new System.Drawing.Point(631, 47);
			this.btshowim.Name = "btshowim";
			this.btshowim.Size = new System.Drawing.Size(89, 23);
			this.btshowim.TabIndex = 27;
			this.btshowim.Text = "Show Names";
			this.btshowim.UseVisualStyleBackColor = true;
			this.btshowim.Click += new System.EventHandler(this.btshowim_Click);
			//
			// rtbnames
			//
			this.rtbnames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.rtbnames.BackColor = System.Drawing.SystemColors.Window;
			this.rtbnames.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.rtbnames.Location = new System.Drawing.Point(439, 117);
			this.rtbnames.Name = "rtbnames";
			this.rtbnames.ReadOnly = true;
			this.rtbnames.Size = new System.Drawing.Size(481, 286);
			this.rtbnames.TabIndex = 28;
			this.rtbnames.Text = "";
			this.rtbnames.Visible = false;
			this.rtbnames.WordWrap = false;
			//
			// StringMapPackedFileUI
			//
			this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
			this.BackgroundImageLocation = new System.Drawing.Point(730, 0);
			this.BackgroundImageZoomToFit = true;
			this.Controls.Add(this.rtbnames);
			this.Controls.Add(this.btshowim);
			this.Controls.Add(this.lbType);
			this.Controls.Add(this.lbsrins);
			this.Controls.Add(this.rtbDatas);
			this.Controls.Add(this.rtbStrings);
			this.Controls.Add(this.lbdatas);
			this.Controls.Add(this.tbfilenm);
			this.Controls.Add(this.lbfilenm);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.HeaderText = "String Mapping";
			this.Name = "StringMapPackedFileUI";
			this.Size = new System.Drawing.Size(1300, 416);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.lbfilenm, 0);
			this.Controls.SetChildIndex(this.tbfilenm, 0);
			this.Controls.SetChildIndex(this.lbdatas, 0);
			this.Controls.SetChildIndex(this.rtbStrings, 0);
			this.Controls.SetChildIndex(this.rtbDatas, 0);
			this.Controls.SetChildIndex(this.lbsrins, 0);
			this.Controls.SetChildIndex(this.lbType, 0);
			this.Controls.SetChildIndex(this.btshowim, 0);
			this.Controls.SetChildIndex(this.rtbnames, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox tbfilenm;
		private System.Windows.Forms.Label lbfilenm;
		private System.Windows.Forms.Label lbdatas;
		private System.Windows.Forms.RichTextBox rtbStrings;
		private System.Windows.Forms.RichTextBox rtbDatas;
		private System.Windows.Forms.Label lbsrins;
		private System.Windows.Forms.Label lbType;
		private System.Windows.Forms.Button btshowim;
		private System.Windows.Forms.RichTextBox rtbnames;
	}
}
