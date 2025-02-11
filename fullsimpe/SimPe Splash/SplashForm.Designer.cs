namespace SimPe.Windows.Forms
{
    partial class SplashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.lbtxt = new System.Windows.Forms.Label();
            this.lbver = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbtxt
            // 
            this.lbtxt.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lbtxt, "lbtxt");
            this.lbtxt.Name = "lbtxt";
            // 
            // lbver
            // 
            resources.ApplyResources(this.lbver, "lbver");
            this.lbver.BackColor = System.Drawing.Color.White;
            this.lbver.ForeColor = System.Drawing.Color.DimGray;
            this.lbver.Name = "lbver";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Name = "label2";
            // 
            // SplashForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbver);
            this.Controls.Add(this.lbtxt);
            this.Name = "SplashForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbtxt;
        private System.Windows.Forms.Label lbver;
        private System.Windows.Forms.Label label2;

    }
}