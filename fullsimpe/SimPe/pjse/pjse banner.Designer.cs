namespace pjse
{
    partial class pjse_banner
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnFloat = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTree = new System.Windows.Forms.Button();
            this.btnSibling = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnRefreshFT = new System.Windows.Forms.Button();
            this.lbLabel = new System.Windows.Forms.Label();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHelp.Location = new System.Drawing.Point(349, 0);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(32, 0, 0, 0);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(57, 27);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnFloat
            // 
            this.btnFloat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFloat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFloat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFloat.Location = new System.Drawing.Point(114, 0);
            this.btnFloat.Margin = new System.Windows.Forms.Padding(0);
            this.btnFloat.Name = "btnFloat";
            this.btnFloat.Size = new System.Drawing.Size(57, 27);
            this.btnFloat.TabIndex = 2;
            this.btnFloat.Text = "Float";
            this.btnFloat.Visible = false;
            this.btnFloat.Click += new System.EventHandler(this.btnFloat_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(57, 0);
            this.btnView.Margin = new System.Windows.Forms.Padding(0);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(57, 27);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // flpButtons
            // 
            this.flpButtons.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flpButtons.AutoSize = true;
            this.flpButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpButtons.BackColor = System.Drawing.Color.Transparent;
            this.flpButtons.Controls.Add(this.btnTree);
            this.flpButtons.Controls.Add(this.btnSibling);
            this.flpButtons.Controls.Add(this.btnView);
            this.flpButtons.Controls.Add(this.btnFloat);
            this.flpButtons.Controls.Add(this.btnExtract);
            this.flpButtons.Controls.Add(this.btnRefreshFT);
            this.flpButtons.Controls.Add(this.btnHelp);
            this.flpButtons.Location = new System.Drawing.Point(269, 0);
            this.flpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(493, 27);
            this.flpButtons.TabIndex = 6;
            // 
            // btnTree
            // 
            this.btnTree.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTree.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTree.Location = new System.Drawing.Point(0, 0);
            this.btnTree.Margin = new System.Windows.Forms.Padding(0);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(82, 27);
            this.btnTree.TabIndex = 8;
            this.btnTree.Text = "Comments";
            this.btnTree.Visible = false;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // btnSibling
            // 
            this.btnSibling.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSibling.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSibling.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSibling.Location = new System.Drawing.Point(0, 0);
            this.btnSibling.Margin = new System.Windows.Forms.Padding(0);
            this.btnSibling.Name = "btnSibling";
            this.btnSibling.Size = new System.Drawing.Size(57, 27);
            this.btnSibling.TabIndex = 5;
            this.btnSibling.Text = "{Type}";
            this.btnSibling.Visible = false;
            this.btnSibling.Click += new System.EventHandler(this.btnSibling_Click);
            // 
            // btnExtract
            // 
            this.btnExtract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExtract.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExtract.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExtract.Location = new System.Drawing.Point(203, 0);
            this.btnExtract.Margin = new System.Windows.Forms.Padding(32, 0, 0, 0);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(62, 27);
            this.btnExtract.TabIndex = 2;
            this.btnExtract.Text = "Extract";
            this.btnExtract.Visible = false;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnRefreshFT
            // 
            this.btnRefreshFT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRefreshFT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefreshFT.Location = new System.Drawing.Point(260, 0);
            this.btnRefreshFT.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshFT.Name = "btnRefreshFT";
            this.btnRefreshFT.Size = new System.Drawing.Size(57, 27);
            this.btnRefreshFT.TabIndex = 7;
            this.btnRefreshFT.Text = "RFT";
            this.btnRefreshFT.Visible = false;
            // 
            // lbLabel
            // 
            this.lbLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbLabel.AutoSize = true;
            this.lbLabel.BackColor = System.Drawing.Color.Transparent;
            this.lbLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbLabel.ForeColor = System.Drawing.Color.White;
            this.lbLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbLabel.Location = new System.Drawing.Point(0, 5);
            this.lbLabel.Margin = new System.Windows.Forms.Padding(0);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(157, 16);
            this.lbLabel.TabIndex = 1;
            this.lbLabel.Text = "PJSE: file type Editor";
            // 
            // pjse_banner
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.lbLabel);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.Name = "pjse_banner";
            this.Size = new System.Drawing.Size(769, 27);
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnFloat;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Label lbLabel;
        private System.Windows.Forms.Button btnSibling;
        private System.Windows.Forms.Button btnTree;
        private System.Windows.Forms.Button btnRefreshFT;
    }
}
