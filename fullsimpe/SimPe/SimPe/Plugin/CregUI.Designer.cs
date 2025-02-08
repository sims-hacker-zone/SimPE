using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Plugin
{
    partial class CregPackedFileUI
    {

        private void InitializeComponent()
        {
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.tbVer = new System.Windows.Forms.TextBox();
            this.tbCrc = new System.Windows.Forms.TextBox();
            this.tbGuid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbContent
            // 
            this.rtbContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbContent.Location = new System.Drawing.Point(14, 82);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(350, 322);
            this.rtbContent.TabIndex = 12;
            this.rtbContent.Text = "";
            this.rtbContent.WordWrap = false;
            // 
            // tbVer
            // 
            this.tbVer.Location = new System.Drawing.Point(72, 175);
            this.tbVer.Name = "tbVer";
            this.tbVer.Size = new System.Drawing.Size(288, 21);
            this.tbVer.TabIndex = 11;
            this.tbVer.TextChanged += new System.EventHandler(this.tbVer_TextChanged);
            // 
            // tbCrc
            // 
            this.tbCrc.Location = new System.Drawing.Point(72, 143);
            this.tbCrc.Name = "tbCrc";
            this.tbCrc.ReadOnly = true;
            this.tbCrc.Size = new System.Drawing.Size(288, 21);
            this.tbCrc.TabIndex = 10;
            // 
            // tbGuid
            // 
            this.tbGuid.Location = new System.Drawing.Point(72, 111);
            this.tbGuid.Name = "tbGuid";
            this.tbGuid.ReadOnly = true;
            this.tbGuid.Size = new System.Drawing.Size(288, 21);
            this.tbGuid.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Version:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "CRC:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "GUID:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            // CregPackedFileUI
            // 
            this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.Centered;
            this.BackgroundImageZoomToFit = true;
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.tbVer);
            this.Controls.Add(this.tbCrc);
            this.Controls.Add(this.tbGuid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderText = "Content Registry";
            this.Name = "CregPackedFileUI";
            this.Size = new System.Drawing.Size(1300, 416);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbGuid, 0);
            this.Controls.SetChildIndex(this.tbCrc, 0);
            this.Controls.SetChildIndex(this.tbVer, 0);
            this.Controls.SetChildIndex(this.rtbContent, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVer;
        private System.Windows.Forms.TextBox tbCrc;
        private System.Windows.Forms.TextBox tbGuid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbContent;
    }
}
