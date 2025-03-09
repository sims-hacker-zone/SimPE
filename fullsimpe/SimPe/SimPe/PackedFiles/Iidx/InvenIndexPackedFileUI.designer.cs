using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.PackedFiles.Iidx
{
	partial class InvenIndexPackedFileUI
	{

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvenIndexPackedFileUI));
			this.warnlbl = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.invinstlbl = new System.Windows.Forms.Label();
			this.scinst = new System.Windows.Forms.TextBox();
			this.desclbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// warnlbl
			//
			resources.ApplyResources(this.warnlbl, "warnlbl");
			this.warnlbl.BackColor = System.Drawing.Color.Transparent;
			this.warnlbl.ForeColor = System.Drawing.Color.DarkRed;
			this.warnlbl.Name = "warnlbl";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Name = "label1";
			//
			// invinstlbl
			//
			resources.ApplyResources(this.invinstlbl, "invinstlbl");
			this.invinstlbl.BackColor = System.Drawing.Color.Transparent;
			this.invinstlbl.Name = "invinstlbl";
			//
			// scinst
			//
			resources.ApplyResources(this.scinst, "scinst");
			this.scinst.Name = "scinst";
			this.scinst.TextChanged += new System.EventHandler(this.scinst_TextChanged);
			//
			// desclbl
			//
			resources.ApplyResources(this.desclbl, "desclbl");
			this.desclbl.BackColor = System.Drawing.Color.Transparent;
			this.desclbl.Name = "desclbl";
			//
			// InvenIndexPackedFileUI
			//
			this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
			this.BackgroundImageLocation = new System.Drawing.Point(425, 0);
			this.BackgroundImageZoomToFit = true;
			this.Controls.Add(this.warnlbl);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.invinstlbl);
			this.Controls.Add(this.scinst);
			this.Controls.Add(this.desclbl);
			this.DoubleBuffered = true;
			resources.ApplyResources(this, "$this");
			this.Name = "InvenIndexPackedFileUI";
			this.Controls.SetChildIndex(this.desclbl, 0);
			this.Controls.SetChildIndex(this.scinst, 0);
			this.Controls.SetChildIndex(this.invinstlbl, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.warnlbl, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label invinstlbl;
		private System.Windows.Forms.Label desclbl;
		internal System.Windows.Forms.TextBox scinst;
		private System.Windows.Forms.Label warnlbl;
	}
}
