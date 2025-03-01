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

namespace whse.PrimitiveWizards.Wiz0x006f
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
            this.lblLightName = new System.Windows.Forms.Label();
            this.btnLightPicker = new System.Windows.Forms.Button();
            this.textLight = new System.Windows.Forms.TextBox();
            this.textIntensity = new System.Windows.Forms.TextBox();
            this.lblIntensity = new System.Windows.Forms.Label();
            this.comboIntensity = new System.Windows.Forms.ComboBox();
            this.textTickCount = new System.Windows.Forms.TextBox();
            this.lblLight = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.checkAllLights = new System.Windows.Forms.CheckBox();
            this.lblTickCount = new System.Windows.Forms.Label();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.comboTickCount = new System.Windows.Forms.ComboBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelTickCount = new System.Windows.Forms.Panel();
            this.panelIntensity = new System.Windows.Forms.Panel();
            this.panelLight = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelTickCount.SuspendLayout();
            this.panelIntensity.SuspendLayout();
            this.panelLight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelLight);
            this.panelMain.Controls.Add(this.panelIntensity);
            this.panelMain.Controls.Add(this.panelTickCount);
            this.panelMain.Controls.Add(this.lblIntensity);
            this.panelMain.Controls.Add(this.comboIntensity);
            this.panelMain.Controls.Add(this.lblLight);
            this.panelMain.Controls.Add(this.lblTarget);
            this.panelMain.Controls.Add(this.checkAllLights);
            this.panelMain.Controls.Add(this.lblTickCount);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.comboTickCount);
            this.panelMain.Controls.Add(this.comboDataPicker1);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.textDataValue1);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.comboDataOwner1);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 155);
            this.panelMain.TabIndex = 0;
            // 
            // lblLightName
            // 
            this.lblLightName.AutoSize = true;
            this.lblLightName.Location = new System.Drawing.Point(79, 4);
            this.lblLightName.Name = "lblLightName";
            this.lblLightName.Size = new System.Drawing.Size(35, 13);
            this.lblLightName.TabIndex = 47;
            this.lblLightName.Text = "label1";
            // 
            // btnLightPicker
            // 
            this.btnLightPicker.Location = new System.Drawing.Point(48, 0);
            this.btnLightPicker.Margin = new System.Windows.Forms.Padding(1);
            this.btnLightPicker.Name = "btnLightPicker";
            this.btnLightPicker.Size = new System.Drawing.Size(27, 21);
            this.btnLightPicker.TabIndex = 46;
            this.btnLightPicker.Text = ">>";
            this.btnLightPicker.UseVisualStyleBackColor = true;
            this.btnLightPicker.Click += new System.EventHandler(this.OnLightPickerClicked);
            // 
            // textLight
            // 
            this.textLight.Location = new System.Drawing.Point(0, 0);
            this.textLight.Name = "textLight";
            this.textLight.Size = new System.Drawing.Size(44, 20);
            this.textLight.TabIndex = 45;
            // 
            // textIntensity
            // 
            this.textIntensity.Location = new System.Drawing.Point(0, 0);
            this.textIntensity.Name = "textIntensity";
            this.textIntensity.Size = new System.Drawing.Size(100, 20);
            this.textIntensity.TabIndex = 29;
            // 
            // lblIntensity
            // 
            this.lblIntensity.Location = new System.Drawing.Point(5, 61);
            this.lblIntensity.Name = "lblIntensity";
            this.lblIntensity.Size = new System.Drawing.Size(95, 13);
            this.lblIntensity.TabIndex = 28;
            this.lblIntensity.Text = "Intensity %:";
            this.lblIntensity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboIntensity
            // 
            this.comboIntensity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIntensity.FormattingEnabled = true;
            this.comboIntensity.Items.AddRange(new object[] {
            "Literal",
            "In Temp 0"});
            this.comboIntensity.Location = new System.Drawing.Point(100, 58);
            this.comboIntensity.Name = "comboIntensity";
            this.comboIntensity.Size = new System.Drawing.Size(95, 21);
            this.comboIntensity.TabIndex = 27;
            this.comboIntensity.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // textTickCount
            // 
            this.textTickCount.Location = new System.Drawing.Point(0, 0);
            this.textTickCount.Name = "textTickCount";
            this.textTickCount.Size = new System.Drawing.Size(100, 20);
            this.textTickCount.TabIndex = 26;
            // 
            // lblLight
            // 
            this.lblLight.Location = new System.Drawing.Point(5, 87);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(95, 13);
            this.lblLight.TabIndex = 15;
            this.lblLight.Text = "Light:";
            this.lblLight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(5, 7);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(95, 13);
            this.lblTarget.TabIndex = 23;
            this.lblTarget.Text = "Target:";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkAllLights
            // 
            this.checkAllLights.AutoSize = true;
            this.checkAllLights.Location = new System.Drawing.Point(100, 87);
            this.checkAllLights.Name = "checkAllLights";
            this.checkAllLights.Size = new System.Drawing.Size(37, 17);
            this.checkAllLights.TabIndex = 0;
            this.checkAllLights.Text = "All";
            this.checkAllLights.UseVisualStyleBackColor = true;
            this.checkAllLights.CheckedChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblTickCount
            // 
            this.lblTickCount.Location = new System.Drawing.Point(5, 34);
            this.lblTickCount.Name = "lblTickCount";
            this.lblTickCount.Size = new System.Drawing.Size(95, 13);
            this.lblTickCount.TabIndex = 5;
            this.lblTickCount.Text = "Tick Count:";
            this.lblTickCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 120);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // comboTickCount
            // 
            this.comboTickCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTickCount.FormattingEnabled = true;
            this.comboTickCount.Items.AddRange(new object[] {
            "Literal",
            "In Temp 1"});
            this.comboTickCount.Location = new System.Drawing.Point(100, 31);
            this.comboTickCount.Name = "comboTickCount";
            this.comboTickCount.Size = new System.Drawing.Size(95, 21);
            this.comboTickCount.TabIndex = 0;
            this.comboTickCount.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // comboDataPicker1
            // 
            this.comboDataPicker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker1.FormattingEnabled = true;
            this.comboDataPicker1.Location = new System.Drawing.Point(310, 4);
            this.comboDataPicker1.Name = "comboDataPicker1";
            this.comboDataPicker1.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker1.TabIndex = 2;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 135);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 3;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 4);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 3;
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(136, 135);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 2;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(100, 4);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner1.TabIndex = 1;
            // 
            // panelTickCount
            // 
            this.panelTickCount.Controls.Add(this.textTickCount);
            this.panelTickCount.Location = new System.Drawing.Point(200, 31);
            this.panelTickCount.Name = "panelTickCount";
            this.panelTickCount.Size = new System.Drawing.Size(240, 21);
            this.panelTickCount.TabIndex = 48;
            // 
            // panelIntensity
            // 
            this.panelIntensity.Controls.Add(this.textIntensity);
            this.panelIntensity.Location = new System.Drawing.Point(200, 58);
            this.panelIntensity.Name = "panelIntensity";
            this.panelIntensity.Size = new System.Drawing.Size(240, 21);
            this.panelIntensity.TabIndex = 49;
            // 
            // panelLight
            // 
            this.panelLight.Controls.Add(this.textLight);
            this.panelLight.Controls.Add(this.btnLightPicker);
            this.panelLight.Controls.Add(this.lblLightName);
            this.panelLight.Location = new System.Drawing.Point(100, 108);
            this.panelLight.Name = "panelLight";
            this.panelLight.Size = new System.Drawing.Size(240, 21);
            this.panelLight.TabIndex = 50;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 155);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelTickCount.ResumeLayout(false);
            this.panelTickCount.PerformLayout();
            this.panelIntensity.ResumeLayout(false);
            this.panelIntensity.PerformLayout();
            this.panelLight.ResumeLayout(false);
            this.panelLight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTickCount;
        private System.Windows.Forms.ComboBox comboTickCount;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.CheckBox checkAllLights;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox textIntensity;
        private System.Windows.Forms.Label lblIntensity;
        private System.Windows.Forms.ComboBox comboIntensity;
        private System.Windows.Forms.TextBox textTickCount;
        private System.Windows.Forms.Label lblLightName;
        private System.Windows.Forms.Button btnLightPicker;
        private System.Windows.Forms.TextBox textLight;
        private System.Windows.Forms.Panel panelTickCount;
        private System.Windows.Forms.Panel panelIntensity;
        private System.Windows.Forms.Panel panelLight;
    }
}
