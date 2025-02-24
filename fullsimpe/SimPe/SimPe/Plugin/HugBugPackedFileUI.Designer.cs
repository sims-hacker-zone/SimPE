using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Plugin
{
    partial class HugBugPackedFileUI
    {

        private void InitializeComponent()
        {
            this.lbFail = new System.Windows.Forms.Label();
            this.lbpass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btShow = new System.Windows.Forms.Button();
            this.TBsting = new System.Windows.Forms.RichTextBox();
            this.btcustom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbFail
            // 
            this.lbFail.AutoSize = true;
            this.lbFail.BackColor = System.Drawing.Color.Transparent;
            this.lbFail.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFail.ForeColor = System.Drawing.Color.DarkRed;
            this.lbFail.Location = new System.Drawing.Point(482, 46);
            this.lbFail.Name = "lbFail";
            this.lbFail.Size = new System.Drawing.Size(61, 29);
            this.lbFail.TabIndex = 4;
            this.lbFail.Text = "Fail";
            this.lbFail.Visible = false;
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.BackColor = System.Drawing.Color.Transparent;
            this.lbpass.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpass.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbpass.Location = new System.Drawing.Point(395, 46);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(83, 29);
            this.lbpass.TabIndex = 3;
            this.lbpass.Text = "Pass ";
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
            // 
            // btShow
            // 
            this.btShow.BackColor = System.Drawing.Color.Transparent;
            this.btShow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShow.Location = new System.Drawing.Point(685, 35);
            this.btShow.Name = "btShow";
            this.btShow.Size = new System.Drawing.Size(123, 39);
            this.btShow.TabIndex = 8;
            this.btShow.Text = "Show All Items";
            this.btShow.UseVisualStyleBackColor = false;
            this.btShow.Click += new System.EventHandler(this.btShow_Click);
            // 
            // TBsting
            // 
            this.TBsting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.TBsting.BackColor = System.Drawing.SystemColors.Window;
            this.TBsting.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBsting.HideSelection = false;
            this.TBsting.Location = new System.Drawing.Point(13, 80);
            this.TBsting.Name = "TBsting";
            this.TBsting.ReadOnly = true;
            this.TBsting.Size = new System.Drawing.Size(813, 327);
            this.TBsting.TabIndex = 7;
            // 
            // btcustom
            // 
            this.btcustom.BackColor = System.Drawing.Color.Transparent;
            this.btcustom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcustom.Location = new System.Drawing.Point(552, 35);
            this.btcustom.Name = "btcustom";
            this.btcustom.Size = new System.Drawing.Size(123, 39);
            this.btcustom.TabIndex = 9;
            this.btcustom.Text = "Show Only CC";
            this.btcustom.UseVisualStyleBackColor = false;
            this.btcustom.Click += new System.EventHandler(this.btcustom_Click);
            // 
            // HugBugPackedFileUI
            // 
            this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
            this.BackgroundImageLocation = new System.Drawing.Point(826, 0);
            this.BackgroundImageZoomToFit = true;
            this.CanCommit = false;
            this.Controls.Add(this.TBsting);
            this.Controls.Add(this.lbFail);
            this.Controls.Add(this.lbpass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btShow);
            this.Controls.Add(this.btcustom);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderText = "Lot Objects Reader";
            this.Name = "HugBugPackedFileUI";
            this.Size = new System.Drawing.Size(1300, 416);
            this.Controls.SetChildIndex(this.btcustom, 0);
            this.Controls.SetChildIndex(this.btShow, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lbpass, 0);
            this.Controls.SetChildIndex(this.lbFail, 0);
            this.Controls.SetChildIndex(this.TBsting, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFail;
        private System.Windows.Forms.Label lbpass;
        private System.Windows.Forms.RichTextBox TBsting;
        private System.Windows.Forms.Button btShow;
        private System.Windows.Forms.Button btcustom;
    }
}
