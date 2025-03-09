using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.PackedFiles.Init
{
	partial class InventItemPackedFileUI
	{

		private void InitializeComponent()
		{
			this.lbdisp = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// lbdisp
			//
			this.lbdisp.AutoSize = true;
			this.lbdisp.BackColor = System.Drawing.Color.Transparent;
			this.lbdisp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbdisp.Location = new System.Drawing.Point(8, 105);
			this.lbdisp.Name = "lbdisp";
			this.lbdisp.Size = new System.Drawing.Size(142, 19);
			this.lbdisp.TabIndex = 2;
			this.lbdisp.Text = "GUID 0x00000000";
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
			// InventItemPackedFileUI
			//
			this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
			this.BackgroundImageLocation = new System.Drawing.Point(391, 0);
			this.BackgroundImageZoomToFit = true;
			this.CanCommit = false;
			this.Controls.Add(this.lbdisp);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.HeaderText = "Inventory Item Reader";
			this.Name = "InventItemPackedFileUI";
			this.Size = new System.Drawing.Size(1300, 416);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.lbdisp, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbdisp;
	}
}
