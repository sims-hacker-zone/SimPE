/*
 * SimpePrimitiveWizards - additional primitive wizards for SimPe
 *                       - see https://www.picknmixmods.com/Sims2/Notes/SimpePrimitiveWizards/SimpePrimitiveWizards.html
 *
 * William Howard - 2023-2023
 *
 * Permission granted to use this code in any way, except to claim it as your own or sell it
 *
 * NOTE: Code should not be "using Simpe;" or "using pjse;" but fully qualifying classes in those high level namespaces
 *
 */

namespace whse.PrimitiveWizards.Wiz0x0007
{
    partial class UI
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
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.comboWhat = new System.Windows.Forms.ComboBox();
            this.lblWhat = new System.Windows.Forms.Label();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.comboWho = new System.Windows.Forms.ComboBox();
            this.lblWho = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.comboWhat);
            this.panelMain.Controls.Add(this.lblWhat);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.comboWho);
            this.panelMain.Controls.Add(this.lblWho);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(300, 70);
            this.panelMain.TabIndex = 0;
            // 
            // comboWhat
            // 
            this.comboWhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWhat.FormattingEnabled = true;
            this.comboWhat.Items.AddRange(new object[] {
            "Graphic",
            "Lighting Contribution",
            "Room Score Contribution"});
            this.comboWhat.Location = new System.Drawing.Point(100, 31);
            this.comboWhat.Name = "comboWhat";
            this.comboWhat.Size = new System.Drawing.Size(150, 21);
            this.comboWhat.TabIndex = 1;
            // 
            // lblWhat
            // 
            this.lblWhat.Location = new System.Drawing.Point(5, 34);
            this.lblWhat.Name = "lblWhat";
            this.lblWhat.Size = new System.Drawing.Size(95, 13);
            this.lblWhat.TabIndex = 18;
            this.lblWhat.Text = "What:";
            this.lblWhat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(265, 35);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // comboWho
            // 
            this.comboWho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWho.FormattingEnabled = true;
            this.comboWho.Items.AddRange(new object[] {
            "My",
            "Stack Object\'s"});
            this.comboWho.Location = new System.Drawing.Point(100, 4);
            this.comboWho.Name = "comboWho";
            this.comboWho.Size = new System.Drawing.Size(150, 21);
            this.comboWho.TabIndex = 0;
            // 
            // lblWho
            // 
            this.lblWho.Location = new System.Drawing.Point(5, 7);
            this.lblWho.Name = "lblWho";
            this.lblWho.Size = new System.Drawing.Size(95, 13);
            this.lblWho.TabIndex = 2;
            this.lblWho.Text = "Refresh:";
            this.lblWho.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(300, 70);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblWho;
        private System.Windows.Forms.ComboBox comboWho;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox comboWhat;
        private System.Windows.Forms.Label lblWhat;
    }
}
