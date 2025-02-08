using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Plugin
{
    partial class SimmyListPackedFileUI
    {

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimmyListPackedFileUI));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.TBsting = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lbInfo
            // 
            resources.ApplyResources(this.lbInfo, "lbInfo");
            this.lbInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbInfo.Name = "lbInfo";
            // 
            // TBsting
            // 
            resources.ApplyResources(this.TBsting, "TBsting");
            this.TBsting.BackColor = System.Drawing.SystemColors.Window;
            this.TBsting.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBsting.HideSelection = false;
            this.TBsting.Name = "TBsting";
            this.TBsting.ReadOnly = true;
            this.toolTip1.SetToolTip(this.TBsting, resources.GetString("TBsting.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // SimmyListPackedFileUI
            // 
            this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
            this.BackgroundImageLocation = new System.Drawing.Point(835, 0);
            this.BackgroundImageZoomToFit = true;
            this.CanCommit = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.TBsting);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "SimmyListPackedFileUI";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TBsting, 0);
            this.Controls.SetChildIndex(this.lbInfo, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TBsting;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
