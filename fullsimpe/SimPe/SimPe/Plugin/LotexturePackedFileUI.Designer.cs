using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Plugin
{
    partial class LotexturePackedFileUI
    {

        private void InitializeComponent()
        {
            this.rtLotTex = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtLotTex
            // 
            this.rtLotTex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.rtLotTex.BackColor = System.Drawing.SystemColors.Window;
            this.rtLotTex.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtLotTex.Location = new System.Drawing.Point(20, 84);
            this.rtLotTex.Name = "rtLotTex";
            this.rtLotTex.ReadOnly = true;
            this.rtLotTex.Size = new System.Drawing.Size(500, 320);
            this.rtLotTex.TabIndex = 2;
            this.rtLotTex.Text = "";
            this.rtLotTex.WordWrap = false;
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
            // LotexturePackedFileUI
            // 
            this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
            this.BackgroundImageLocation = new System.Drawing.Point(522, 0);
            this.BackgroundImageZoomToFit = true;
            this.CanCommit = false;
            this.Controls.Add(this.rtLotTex);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LotexturePackedFileUI";
            this.Size = new System.Drawing.Size(1300, 416);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rtLotTex, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtLotTex;
    }
}
