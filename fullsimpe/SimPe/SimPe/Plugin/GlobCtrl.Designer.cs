namespace SimPe.Plugin
{
    partial class GlobCtrl
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
            this.tbgroup = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.cbseminame = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbglobfile = new System.Windows.Forms.Label();
            this.pritee = new System.Windows.Forms.Panel();
            this.lbBug = new System.Windows.Forms.Label();
            this.lbBloat = new System.Windows.Forms.Label();
            this.tbfilenm = new System.Windows.Forms.TextBox();
            this.lbfilenm = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.pritee.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbgroup
            // 
            this.tbgroup.BackColor = System.Drawing.SystemColors.Window;
            this.tbgroup.Location = new System.Drawing.Point(80, 78);
            this.tbgroup.Name = "tbgroup";
            this.tbgroup.ReadOnly = true;
            this.tbgroup.Size = new System.Drawing.Size(100, 21);
            this.tbgroup.TabIndex = 16;
            this.tbgroup.Text = "0x0";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label43.Location = new System.Drawing.Point(24, 80);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(50, 13);
            this.label43.TabIndex = 15;
            this.label43.Text = "Group:";
            // 
            // cbseminame
            // 
            this.cbseminame.ItemHeight = 13;
            this.cbseminame.Location = new System.Drawing.Point(80, 54);
            this.cbseminame.Name = "cbseminame";
            this.cbseminame.Size = new System.Drawing.Size(254, 21);
            this.cbseminame.TabIndex = 14;
            this.cbseminame.SelectedIndexChanged += new System.EventHandler(this.SemiGlobalChanged);
            this.cbseminame.TextUpdate += new System.EventHandler(this.SemiGlobalChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(26, 56);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(48, 13);
            this.label42.TabIndex = 12;
            this.label42.Text = "Name:";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.panel6.CanCommit = true;
            this.panel6.Controls.Add(this.lbglobfile);
            this.panel6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            //this.panel6.HeaderText = "Global Data Editor";
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(554, 24);
            this.panel6.TabIndex = 0;
            //this.panel6.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.GlobCommit);
            // 
            // lbglobfile
            // 
            this.lbglobfile.AutoSize = true;
            this.lbglobfile.BackColor = System.Drawing.Color.Transparent;
            this.lbglobfile.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lbglobfile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbglobfile.Location = new System.Drawing.Point(170, 6);
            this.lbglobfile.Name = "lbglobfile";
            this.lbglobfile.Size = new System.Drawing.Size(44, 13);
            this.lbglobfile.TabIndex = 3;
            this.lbglobfile.Text = "no File";
            // 
            // pritee
            // 
            this.pritee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pritee.BackColor = System.Drawing.Color.Transparent;
            //this.pritee.BackgroundImageAnchor = System.Windows.Forms.Panel.ImageLayout.CenterTop;
            //this.pritee.BackgroundImageLocation = new System.Drawing.Point(0, 24);
            //this.pritee.BackgroundImageZoomToFit = true;
            this.pritee.Controls.Add(this.lbBug);
            this.pritee.Controls.Add(this.lbBloat);
            this.pritee.Controls.Add(this.tbfilenm);
            this.pritee.Controls.Add(this.lbfilenm);
            this.pritee.Controls.Add(this.panel6);
            this.pritee.Controls.Add(this.tbgroup);
            this.pritee.Controls.Add(this.label43);
            this.pritee.Controls.Add(this.cbseminame);
            this.pritee.Controls.Add(this.label42);
            this.pritee.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pritee.Location = new System.Drawing.Point(0, 0);
            this.pritee.Name = "pritee";
            this.pritee.Size = new System.Drawing.Size(554, 291);
            this.pritee.TabIndex = 17;
            // 
            // lbBloat
            // 
            this.lbBloat.AutoSize = true;
            this.lbBloat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBloat.Location = new System.Drawing.Point(24, 115);
            this.lbBloat.Name = "lbBloat";
            this.lbBloat.Size = new System.Drawing.Size(320, 54);
            this.lbBloat.TabIndex = 19;
            this.lbBloat.Text = "This File contains extra, unused data.\r\n\r\n\'Click\' Commit to fix";
            this.lbBloat.Visible = false;
            // 
            // lbBug
            // 
            this.lbBug.AutoSize = true;
            this.lbBug.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBug.Location = new System.Drawing.Point(24, 115);
            this.lbBug.Name = "lbBug";
            this.lbBug.Size = new System.Drawing.Size(272, 72);
            this.lbBug.TabIndex = 19;
            this.lbBug.Text = "This File does not conform to the\r\nstandard GLOB File format.\r\n\r\n\'Click\' Commit to fix";
            this.lbBug.Visible = false;
            // 
            // tbfilenm
            // 
            this.tbfilenm.BackColor = System.Drawing.SystemColors.Window;
            this.tbfilenm.Location = new System.Drawing.Point(80, 30);
            this.tbfilenm.Name = "tbfilenm";
            this.tbfilenm.Size = new System.Drawing.Size(254, 21);
            this.tbfilenm.TabIndex = 18;
            this.tbfilenm.TextChanged += new System.EventHandler(this.tbfilenm_TextChanged);
            // 
            // lbfilenm
            // 
            this.lbfilenm.AutoSize = true;
            this.lbfilenm.BackColor = System.Drawing.Color.Transparent;
            this.lbfilenm.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbfilenm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbfilenm.Location = new System.Drawing.Point(3, 32);
            this.lbfilenm.Name = "lbfilenm";
            this.lbfilenm.Size = new System.Drawing.Size(71, 13);
            this.lbfilenm.TabIndex = 17;
            this.lbfilenm.Text = "Filename:";
            // 
            // GlobCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pritee);
            this.Name = "GlobCtrl";
            this.Size = new System.Drawing.Size(554, 291);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pritee.ResumeLayout(false);
            this.pritee.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox tbgroup;
        private System.Windows.Forms.Label label43;
        internal System.Windows.Forms.ComboBox cbseminame;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel6;
        internal System.Windows.Forms.Label lbglobfile;
        private System.Windows.Forms.Panel pritee;
        internal System.Windows.Forms.TextBox tbfilenm;
        private System.Windows.Forms.Label lbfilenm;
        internal System.Windows.Forms.Label lbBug;
        internal System.Windows.Forms.Label lbBloat;
    }
}
