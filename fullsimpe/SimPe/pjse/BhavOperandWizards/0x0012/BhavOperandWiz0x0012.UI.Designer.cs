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

namespace whse.PrimitiveWizards.Wiz0x0012
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
            this.lblImmediate = new System.Windows.Forms.Label();
            this.checkImmediate = new System.Windows.Forms.CheckBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.comboRemove = new System.Windows.Forms.ComboBox();
            this.lblRemove = new System.Windows.Forms.Label();
            this.lblCleanUpAll = new System.Windows.Forms.Label();
            this.checkCleanUpAll = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblImmediate);
            this.panelMain.Controls.Add(this.checkImmediate);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.comboRemove);
            this.panelMain.Controls.Add(this.lblRemove);
            this.panelMain.Controls.Add(this.lblCleanUpAll);
            this.panelMain.Controls.Add(this.checkCleanUpAll);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(250, 100);
            this.panelMain.TabIndex = 0;
            // 
            // lblImmediate
            // 
            this.lblImmediate.Location = new System.Drawing.Point(5, 33);
            this.lblImmediate.Name = "lblImmediate";
            this.lblImmediate.Size = new System.Drawing.Size(95, 13);
            this.lblImmediate.TabIndex = 20;
            this.lblImmediate.Text = "Immediate:";
            this.lblImmediate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkImmediate
            // 
            this.checkImmediate.AutoSize = true;
            this.checkImmediate.Location = new System.Drawing.Point(100, 33);
            this.checkImmediate.Name = "checkImmediate";
            this.checkImmediate.Size = new System.Drawing.Size(15, 14);
            this.checkImmediate.TabIndex = 1;
            this.checkImmediate.UseVisualStyleBackColor = true;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(215, 65);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // comboRemove
            // 
            this.comboRemove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRemove.FormattingEnabled = true;
            this.comboRemove.Items.AddRange(new object[] {
            "Me",
            "Stack Object"});
            this.comboRemove.Location = new System.Drawing.Point(100, 4);
            this.comboRemove.Name = "comboRemove";
            this.comboRemove.Size = new System.Drawing.Size(87, 21);
            this.comboRemove.TabIndex = 0;
            // 
            // lblRemove
            // 
            this.lblRemove.Location = new System.Drawing.Point(5, 7);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(95, 13);
            this.lblRemove.TabIndex = 2;
            this.lblRemove.Text = "Remove:";
            this.lblRemove.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCleanUpAll
            // 
            this.lblCleanUpAll.Location = new System.Drawing.Point(5, 55);
            this.lblCleanUpAll.Name = "lblCleanUpAll";
            this.lblCleanUpAll.Size = new System.Drawing.Size(95, 13);
            this.lblCleanUpAll.TabIndex = 15;
            this.lblCleanUpAll.Text = "Clean Up All:";
            this.lblCleanUpAll.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkCleanUpAll
            // 
            this.checkCleanUpAll.AutoSize = true;
            this.checkCleanUpAll.Location = new System.Drawing.Point(100, 55);
            this.checkCleanUpAll.Name = "checkCleanUpAll";
            this.checkCleanUpAll.Size = new System.Drawing.Size(15, 14);
            this.checkCleanUpAll.TabIndex = 2;
            this.checkCleanUpAll.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(250, 100);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblRemove;
        private System.Windows.Forms.ComboBox comboRemove;
        private System.Windows.Forms.Label lblCleanUpAll;
        private System.Windows.Forms.CheckBox checkCleanUpAll;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblImmediate;
        private System.Windows.Forms.CheckBox checkImmediate;
    }
}
