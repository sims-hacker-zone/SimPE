using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Plugin
{
    partial class SimpleTextPackedFileUI
    {

        private void InitializeComponent()
        {
            this.TBsting = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBsting
            // 
            this.TBsting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.TBsting.BackColor = System.Drawing.SystemColors.Window;
            this.TBsting.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBsting.HideSelection = false;
            this.TBsting.Location = new System.Drawing.Point(13, 78);
            this.TBsting.Name = "TBsting";
            this.TBsting.Size = new System.Drawing.Size(813, 327);
            this.TBsting.TabIndex = 6;
            this.TBsting.Text = "We want boobs";
            this.TBsting.TextChanged += new System.EventHandler(this.TBsting_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Blackadder ITC", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "Boobies Make me Happy!";
            this.label2.Visible = false;
            // 
            // SimpleTextPackedFileUI
            // 
            this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
            this.BackgroundImageLocation = new System.Drawing.Point(826, 0);
            this.BackgroundImageZoomToFit = true;
            this.Controls.Add(this.TBsting);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderText = "Simple Text Editor";
            this.Name = "SimpleTextPackedFileUI";
            this.Size = new System.Drawing.Size(1300, 416);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TBsting, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TBsting;
    }
}
