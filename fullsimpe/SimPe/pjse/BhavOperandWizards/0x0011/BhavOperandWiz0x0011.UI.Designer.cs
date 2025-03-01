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

namespace whse.PrimitiveWizards.Wiz0x0011
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
            this.panelTickCount = new System.Windows.Forms.Panel();
            this.textTickCount = new System.Windows.Forms.TextBox();
            this.lblTickCount = new System.Windows.Forms.Label();
            this.lblAllowPush = new System.Windows.Forms.Label();
            this.comboAction = new System.Windows.Forms.ComboBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkAllowPush = new System.Windows.Forms.CheckBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            this.panelTickCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelTickCount);
            this.panelMain.Controls.Add(this.lblAllowPush);
            this.panelMain.Controls.Add(this.comboAction);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkAllowPush);
            this.panelMain.Controls.Add(this.lblAction);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(350, 100);
            this.panelMain.TabIndex = 0;
            // 
            // panelTickCount
            // 
            this.panelTickCount.Controls.Add(this.textTickCount);
            this.panelTickCount.Controls.Add(this.lblTickCount);
            this.panelTickCount.Location = new System.Drawing.Point(0, 34);
            this.panelTickCount.Name = "panelTickCount";
            this.panelTickCount.Size = new System.Drawing.Size(350, 21);
            this.panelTickCount.TabIndex = 37;
            // 
            // textTickCount
            // 
            this.textTickCount.Location = new System.Drawing.Point(100, 0);
            this.textTickCount.Name = "textTickCount";
            this.textTickCount.Size = new System.Drawing.Size(120, 20);
            this.textTickCount.TabIndex = 2;
            // 
            // lblTickCount
            // 
            this.lblTickCount.Location = new System.Drawing.Point(5, 3);
            this.lblTickCount.Name = "lblTickCount";
            this.lblTickCount.Size = new System.Drawing.Size(95, 13);
            this.lblTickCount.TabIndex = 3;
            this.lblTickCount.Text = "Tick Count:";
            this.lblTickCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAllowPush
            // 
            this.lblAllowPush.Location = new System.Drawing.Point(5, 60);
            this.lblAllowPush.Name = "lblAllowPush";
            this.lblAllowPush.Size = new System.Drawing.Size(95, 13);
            this.lblAllowPush.TabIndex = 36;
            this.lblAllowPush.Text = "Allow Push:";
            this.lblAllowPush.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboAction
            // 
            this.comboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAction.FormattingEnabled = true;
            this.comboAction.Items.AddRange(new object[] {
            "Idle",
            "Process Sub-Queue"});
            this.comboAction.Location = new System.Drawing.Point(100, 4);
            this.comboAction.Name = "comboAction";
            this.comboAction.Size = new System.Drawing.Size(120, 21);
            this.comboAction.TabIndex = 0;
            this.comboAction.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(169, 80);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 5;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(315, 65);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 16;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // checkAllowPush
            // 
            this.checkAllowPush.AutoSize = true;
            this.checkAllowPush.Location = new System.Drawing.Point(100, 60);
            this.checkAllowPush.Name = "checkAllowPush";
            this.checkAllowPush.Size = new System.Drawing.Size(15, 14);
            this.checkAllowPush.TabIndex = 3;
            this.checkAllowPush.UseVisualStyleBackColor = true;
            // 
            // lblAction
            // 
            this.lblAction.Location = new System.Drawing.Point(5, 7);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(95, 13);
            this.lblAction.TabIndex = 0;
            this.lblAction.Text = "Action:";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(350, 100);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelTickCount.ResumeLayout(false);
            this.panelTickCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblTickCount;
        private System.Windows.Forms.CheckBox checkAllowPush;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.TextBox textTickCount;
        private System.Windows.Forms.ComboBox comboAction;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblAllowPush;
        private System.Windows.Forms.Panel panelTickCount;
    }
}
