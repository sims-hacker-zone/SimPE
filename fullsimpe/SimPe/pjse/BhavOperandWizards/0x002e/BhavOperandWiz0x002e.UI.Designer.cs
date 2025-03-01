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

namespace whse.PrimitiveWizards.Wiz0x002e
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
            this.lblMoveSim = new System.Windows.Forms.Label();
            this.lblTestOnly = new System.Windows.Forms.Label();
            this.comboSnapType = new System.Windows.Forms.ComboBox();
            this.textSlotNumber = new System.Windows.Forms.TextBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkMoveSim = new System.Windows.Forms.CheckBox();
            this.checkTestOnly = new System.Windows.Forms.CheckBox();
            this.comboSlotNumber = new System.Windows.Forms.ComboBox();
            this.lblSlotNumber = new System.Windows.Forms.Label();
            this.lblSnapType = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblMoveSim);
            this.panelMain.Controls.Add(this.lblTestOnly);
            this.panelMain.Controls.Add(this.comboSnapType);
            this.panelMain.Controls.Add(this.textSlotNumber);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkMoveSim);
            this.panelMain.Controls.Add(this.checkTestOnly);
            this.panelMain.Controls.Add(this.comboSlotNumber);
            this.panelMain.Controls.Add(this.lblSlotNumber);
            this.panelMain.Controls.Add(this.lblSnapType);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(350, 120);
            this.panelMain.TabIndex = 0;
            // 
            // lblMoveSim
            // 
            this.lblMoveSim.Location = new System.Drawing.Point(5, 80);
            this.lblMoveSim.Name = "lblMoveSim";
            this.lblMoveSim.Size = new System.Drawing.Size(95, 13);
            this.lblMoveSim.TabIndex = 37;
            this.lblMoveSim.Text = "Move Sim:";
            this.lblMoveSim.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblMoveSim, "Ask Sim to move");
            // 
            // lblTestOnly
            // 
            this.lblTestOnly.Location = new System.Drawing.Point(5, 60);
            this.lblTestOnly.Name = "lblTestOnly";
            this.lblTestOnly.Size = new System.Drawing.Size(95, 13);
            this.lblTestOnly.TabIndex = 36;
            this.lblTestOnly.Text = "Test Only:";
            this.lblTestOnly.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboSnapType
            // 
            this.comboSnapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSnapType.FormattingEnabled = true;
            this.comboSnapType.Items.AddRange(new object[] {
            "SO\'s Slot Param [Slot Number]",
            "Be Contained in SO",
            "Be In Front of SO",
            "SO\'s Slot [Slot Number]",
            "Global Slot [Slot Number]"});
            this.comboSnapType.Location = new System.Drawing.Point(100, 4);
            this.comboSnapType.Name = "comboSnapType";
            this.comboSnapType.Size = new System.Drawing.Size(170, 21);
            this.comboSnapType.TabIndex = 0;
            this.comboSnapType.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // textSlotNumber
            // 
            this.textSlotNumber.Location = new System.Drawing.Point(280, 30);
            this.textSlotNumber.Name = "textSlotNumber";
            this.textSlotNumber.Size = new System.Drawing.Size(50, 20);
            this.textSlotNumber.TabIndex = 2;
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(169, 100);
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
			this.iconPnM.Location = new System.Drawing.Point(315, 85);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 16;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // checkMoveSim
            // 
            this.checkMoveSim.AutoSize = true;
            this.checkMoveSim.Location = new System.Drawing.Point(100, 80);
            this.checkMoveSim.Name = "checkMoveSim";
            this.checkMoveSim.Size = new System.Drawing.Size(15, 14);
            this.checkMoveSim.TabIndex = 4;
            this.toolTip.SetToolTip(this.checkMoveSim, "Ask Sim to move");
            this.checkMoveSim.UseVisualStyleBackColor = true;
            // 
            // checkTestOnly
            // 
            this.checkTestOnly.AutoSize = true;
            this.checkTestOnly.Location = new System.Drawing.Point(100, 60);
            this.checkTestOnly.Name = "checkTestOnly";
            this.checkTestOnly.Size = new System.Drawing.Size(15, 14);
            this.checkTestOnly.TabIndex = 3;
            this.checkTestOnly.UseVisualStyleBackColor = true;
            // 
            // comboSlotNumber
            // 
            this.comboSlotNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSlotNumber.FormattingEnabled = true;
            this.comboSlotNumber.Items.AddRange(new object[] {
            "Literal",
            "Temp 0",
            "Temp 1"});
            this.comboSlotNumber.Location = new System.Drawing.Point(100, 31);
            this.comboSlotNumber.Name = "comboSlotNumber";
            this.comboSlotNumber.Size = new System.Drawing.Size(170, 21);
            this.comboSlotNumber.TabIndex = 1;
            this.comboSlotNumber.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblSlotNumber
            // 
            this.lblSlotNumber.Location = new System.Drawing.Point(5, 37);
            this.lblSlotNumber.Name = "lblSlotNumber";
            this.lblSlotNumber.Size = new System.Drawing.Size(95, 13);
            this.lblSlotNumber.TabIndex = 3;
            this.lblSlotNumber.Text = "Slot Number:";
            this.lblSlotNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSnapType
            // 
            this.lblSnapType.Location = new System.Drawing.Point(5, 7);
            this.lblSnapType.Name = "lblSnapType";
            this.lblSnapType.Size = new System.Drawing.Size(95, 13);
            this.lblSnapType.TabIndex = 0;
            this.lblSnapType.Text = "Type:";
            this.lblSnapType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(350, 120);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblSnapType;
        private System.Windows.Forms.ComboBox comboSlotNumber;
        private System.Windows.Forms.Label lblSlotNumber;
        private System.Windows.Forms.CheckBox checkTestOnly;
        private System.Windows.Forms.CheckBox checkMoveSim;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.TextBox textSlotNumber;
        private System.Windows.Forms.ComboBox comboSnapType;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblMoveSim;
        private System.Windows.Forms.Label lblTestOnly;
    }
}
