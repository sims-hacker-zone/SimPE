namespace System.Windows.Forms
{
    partial class LabelledBoolsetControl
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
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cklbBoolset = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAll.Location = new System.Drawing.Point(3, 0);
            this.btnAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(45, 23);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNone
            // 
            this.btnNone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNone.Location = new System.Drawing.Point(54, 0);
            this.btnNone.Margin = new System.Windows.Forms.Padding(0);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(45, 23);
            this.btnNone.TabIndex = 1;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNone, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cklbBoolset, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(102, 274);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cklbBoolset
            // 
            this.cklbBoolset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cklbBoolset.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.cklbBoolset, 2);
            this.cklbBoolset.FormattingEnabled = true;
            this.cklbBoolset.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cklbBoolset.Location = new System.Drawing.Point(3, 26);
            this.cklbBoolset.Name = "cklbBoolset";
            this.cklbBoolset.Size = new System.Drawing.Size(96, 244);
            this.cklbBoolset.TabIndex = 2;
            this.cklbBoolset.SelectedIndexChanged += new System.EventHandler(this.cklbBoolset_SelectedIndexChanged);
            // 
            // LabelledBoolsetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LabelledBoolsetControl";
            this.Size = new System.Drawing.Size(102, 274);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAll;
        private Button btnNone;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckedListBox cklbBoolset;
    }
}
