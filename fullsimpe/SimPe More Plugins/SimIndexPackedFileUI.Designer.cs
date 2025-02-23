using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Plugin
{
    partial class SimindexPackedFileUI
    {

        private void InitializeComponent()
        {
            this.warnlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scinstlbl = new System.Windows.Forms.Label();
            this.scinst = new System.Windows.Forms.TextBox();
            this.desclbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // warnlbl
            // 
            this.warnlbl.AutoSize = true;
            this.warnlbl.BackColor = System.Drawing.Color.Transparent;
            this.warnlbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline);
            this.warnlbl.ForeColor = System.Drawing.Color.DarkRed;
            this.warnlbl.Location = new System.Drawing.Point(15, 260);
            this.warnlbl.Name = "warnlbl";
            this.warnlbl.Size = new System.Drawing.Size(437, 19);
            this.warnlbl.TabIndex = 8;
            this.warnlbl.Text = "Using a Value Below 0x0001 Will Crash your neighbourhood";
            this.warnlbl.Visible = false;
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
            // scinstlbl
            // 
            this.scinstlbl.AutoSize = true;
            this.scinstlbl.BackColor = System.Drawing.Color.Transparent;
            this.scinstlbl.Location = new System.Drawing.Point(125, 94);
            this.scinstlbl.Name = "scinstlbl";
            this.scinstlbl.Size = new System.Drawing.Size(145, 19);
            this.scinstlbl.TabIndex = 6;
            this.scinstlbl.Text = "Sim Creation Index";
            // 
            // scinst
            // 
            this.scinst.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.scinst.Location = new System.Drawing.Point(19, 92);
            this.scinst.Name = "scinst";
            this.scinst.Size = new System.Drawing.Size(100, 21);
            this.scinst.TabIndex = 0;
            this.scinst.TextChanged += new System.EventHandler(this.scinst_TextChanged);
            // 
            // desclbl
            // 
            this.desclbl.AutoSize = true;
            this.desclbl.BackColor = System.Drawing.Color.Transparent;
            this.desclbl.Location = new System.Drawing.Point(15, 126);
            this.desclbl.Name = "desclbl";
            this.desclbl.Size = new System.Drawing.Size(303, 114);
            this.desclbl.TabIndex = 7;
            this.desclbl.Text = "The Sim Creation Index\r\n Is the instance value and Neighbour ID\r\nthat this neighb" +
                "ourhood will use for the\r\nnext sim created.\r\nIf that value is in use then your g" +
                "ame will\r\nuse the next free value.";
            // 
            // SimindexPackedFileUI
            // 
            this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
            this.BackgroundImageLocation = new System.Drawing.Point(452, 0);
            this.BackgroundImageZoomToFit = true;
            this.Controls.Add(this.warnlbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scinstlbl);
            this.Controls.Add(this.scinst);
            this.Controls.Add(this.desclbl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.HeaderText = "Sim Creation Index";
            this.Name = "SimindexPackedFileUI";
            this.Size = new System.Drawing.Size(1300, 416);
            this.Controls.SetChildIndex(this.desclbl, 0);
            this.Controls.SetChildIndex(this.scinst, 0);
            this.Controls.SetChildIndex(this.scinstlbl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.warnlbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label scinstlbl;
        private System.Windows.Forms.Label desclbl;
        internal System.Windows.Forms.TextBox scinst;
        private System.Windows.Forms.Label warnlbl;
    }
}
