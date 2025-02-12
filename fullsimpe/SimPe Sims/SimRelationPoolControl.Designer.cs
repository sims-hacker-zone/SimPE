namespace SimPe.PackedFiles.Wrapper
{
    partial class SimRelationPoolControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimRelationPoolControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNoRelation = new System.Windows.Forms.CheckBox();
            this.cbRelation = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp
            // 
            resources.ApplyResources(this.gp, "gp");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cbNoRelation);
            this.panel1.Controls.Add(this.cbRelation);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbNoRelation
            // 
            resources.ApplyResources(this.cbNoRelation, "cbNoRelation");
            this.cbNoRelation.Name = "cbNoRelation";
            this.cbNoRelation.UseVisualStyleBackColor = true;
            this.cbNoRelation.CheckedChanged += new System.EventHandler(this.cbNoRelation_CheckedChanged);
            // 
            // cbRelation
            // 
            resources.ApplyResources(this.cbRelation, "cbRelation");
            this.cbRelation.Name = "cbRelation";
            this.cbRelation.UseVisualStyleBackColor = true;
            this.cbRelation.CheckedChanged += new System.EventHandler(this.cbRelation_CheckedChanged);
            // 
            // SimRelationPoolControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SimRelationPoolControl";
            this.Controls.SetChildIndex(this.gp, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbNoRelation;
        private System.Windows.Forms.CheckBox cbRelation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}
