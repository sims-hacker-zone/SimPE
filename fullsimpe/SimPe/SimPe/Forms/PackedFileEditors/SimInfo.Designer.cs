namespace SimPe.PackedFiles.Wrapper
{
    partial class SimInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimInfo));
            this.pngradient = new System.Windows.Forms.Panel();
            this.lbshead = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lbInform = new System.Windows.Forms.Label();
            this.pnheader = new System.Windows.Forms.Panel();
            this.pngradient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pngradient
            // 
            this.pngradient.BackColor = System.Drawing.Color.Transparent;
            this.pngradient.Controls.Add(this.lbshead);
            this.pngradient.Controls.Add(this.pbImage);
            this.pngradient.Controls.Add(this.lbInform);
            this.pngradient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pngradient.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pngradient.Location = new System.Drawing.Point(0, 0);
            this.pngradient.Name = "pngradient";
            this.pngradient.Size = new System.Drawing.Size(715, 367);
            this.pngradient.TabIndex = 0;
            // 
            // lbshead
            // 
            this.lbshead.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbshead.Location = new System.Drawing.Point(48, 43);
            this.lbshead.Name = "lbshead";
            this.lbshead.Size = new System.Drawing.Size(520, 100);
            this.lbshead.TabIndex = 2;
            this.lbshead.Text = "Name";
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImage.Location = new System.Drawing.Point(574, 28);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(138, 138);
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // lbInform
            // 
            this.lbInform.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbInform.Location = new System.Drawing.Point(2, 178);
            this.lbInform.Margin = new System.Windows.Forms.Padding(0);
            this.lbInform.Name = "lbInform";
            this.lbInform.Size = new System.Drawing.Size(712, 185);
            this.lbInform.TabIndex = 0;
            // 
            // pnheader
            // 
            this.pnheader.Dock = System.Windows.Forms.DockStyle.Top;
            //this.pnheader.HeaderText = "Sim Profile";
            this.pnheader.Location = new System.Drawing.Point(0, 0);
            this.pnheader.Margin = new System.Windows.Forms.Padding(0);
            this.pnheader.Name = "pnheader";
            this.pnheader.Size = new System.Drawing.Size(715, 24);
            this.pnheader.TabIndex = 1;
            // 
            // SimInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 367);
            this.Controls.Add(this.pnheader);
            this.Controls.Add(this.pngradient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimInfo";
            this.Opacity = 0.96;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sim Profile";
            this.pngradient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pngradient;
        private System.Windows.Forms.Panel pnheader;
        private System.Windows.Forms.Label lbInform;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lbshead;
    }
}