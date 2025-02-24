namespace SimPe
{    
    partial class WaitControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pb = new System.Windows.Forms.ToolStripProgressBar();
            this.tbPercent = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pb,
            this.tbPercent,
            this.tbInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, -1);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(610, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pb
            // 
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(400, 16);
            // 
            // tbPercent
            // 
            this.tbPercent.BackColor = System.Drawing.Color.Transparent;
            this.tbPercent.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbPercent.Name = "tbPercent";
            this.tbPercent.Size = new System.Drawing.Size(23, 17);
            this.tbPercent.Text = "0%";
            this.tbPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbInfo
            // 
            this.tbInfo.BackColor = System.Drawing.Color.Transparent;
            this.tbInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tbInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(139, 17);
            this.tbInfo.Spring = true;
            this.tbInfo.Text = "---";
            this.tbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WaitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Name = "WaitControl";
            this.Size = new System.Drawing.Size(610, 21);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pb;
        private System.Windows.Forms.ToolStripStatusLabel tbPercent;
        private System.Windows.Forms.ToolStripStatusLabel tbInfo;
    }
}
