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

namespace whse.PrimitiveWizards.Wiz0x007e
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
            this.lblParameters = new System.Windows.Forms.Label();
            this.lblScriptName = new System.Windows.Forms.Label();
            this.lblScript = new System.Windows.Forms.Label();
            this.btnScriptPicker = new System.Windows.Forms.Button();
            this.comboScriptType = new System.Windows.Forms.ComboBox();
            this.textStrRes = new System.Windows.Forms.TextBox();
            this.checkParameters = new System.Windows.Forms.CheckBox();
            this.comboStrScope = new System.Windows.Forms.ComboBox();
            this.textStrEntry = new System.Windows.Forms.TextBox();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.lblParam1 = new System.Windows.Forms.Label();
            this.lblParam2 = new System.Windows.Forms.Label();
            this.lblParam3 = new System.Windows.Forms.Label();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.textDataValue3 = new System.Windows.Forms.TextBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.comboDataPicker3 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner3 = new System.Windows.Forms.ComboBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblParameters);
            this.panelMain.Controls.Add(this.lblScriptName);
            this.panelMain.Controls.Add(this.lblScript);
            this.panelMain.Controls.Add(this.btnScriptPicker);
            this.panelMain.Controls.Add(this.comboScriptType);
            this.panelMain.Controls.Add(this.textStrRes);
            this.panelMain.Controls.Add(this.checkParameters);
            this.panelMain.Controls.Add(this.comboStrScope);
            this.panelMain.Controls.Add(this.textStrEntry);
            this.panelMain.Controls.Add(this.panelParameters);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 190);
            this.panelMain.TabIndex = 0;
            // 
            // lblParameters
            // 
            this.lblParameters.Location = new System.Drawing.Point(5, 53);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(95, 13);
            this.lblParameters.TabIndex = 45;
            this.lblParameters.Text = "Pass Parameters:";
            this.lblParameters.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblScriptName
            // 
            this.lblScriptName.AutoSize = true;
            this.lblScriptName.Location = new System.Drawing.Point(131, 32);
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(35, 13);
            this.lblScriptName.TabIndex = 44;
            this.lblScriptName.Text = "label1";
            // 
            // lblScript
            // 
            this.lblScript.Location = new System.Drawing.Point(5, 7);
            this.lblScript.Name = "lblScript";
            this.lblScript.Size = new System.Drawing.Size(95, 13);
            this.lblScript.TabIndex = 9;
            this.lblScript.Text = "Script:";
            this.lblScript.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnScriptPicker
            // 
            this.btnScriptPicker.Location = new System.Drawing.Point(100, 28);
            this.btnScriptPicker.Margin = new System.Windows.Forms.Padding(1);
            this.btnScriptPicker.Name = "btnScriptPicker";
            this.btnScriptPicker.Size = new System.Drawing.Size(27, 21);
            this.btnScriptPicker.TabIndex = 4;
            this.btnScriptPicker.Text = ">>";
            this.btnScriptPicker.UseVisualStyleBackColor = true;
            this.btnScriptPicker.Click += new System.EventHandler(this.OnScriptPickerClicked);
            // 
            // comboScriptType
            // 
            this.comboScriptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboScriptType.FormattingEnabled = true;
            this.comboScriptType.Items.AddRange(new object[] {
            "System Script",
            "Script in Desc"});
            this.comboScriptType.Location = new System.Drawing.Point(330, 4);
            this.comboScriptType.Name = "comboScriptType";
            this.comboScriptType.Size = new System.Drawing.Size(100, 21);
            this.comboScriptType.TabIndex = 3;
            // 
            // textStrRes
            // 
            this.textStrRes.Location = new System.Drawing.Point(100, 4);
            this.textStrRes.Name = "textStrRes";
            this.textStrRes.Size = new System.Drawing.Size(60, 20);
            this.textStrRes.TabIndex = 0;
            // 
            // checkParameters
            // 
            this.checkParameters.AutoSize = true;
            this.checkParameters.Location = new System.Drawing.Point(100, 53);
            this.checkParameters.Name = "checkParameters";
            this.checkParameters.Size = new System.Drawing.Size(15, 14);
            this.checkParameters.TabIndex = 5;
            this.checkParameters.UseVisualStyleBackColor = true;
            this.checkParameters.CheckedChanged += new System.EventHandler(this.OnParametersClicked);
            // 
            // comboStrScope
            // 
            this.comboStrScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStrScope.FormattingEnabled = true;
            this.comboStrScope.Items.AddRange(new object[] {
            "Private",
            "Semi-Global",
            "Global"});
            this.comboStrScope.Location = new System.Drawing.Point(166, 3);
            this.comboStrScope.Name = "comboStrScope";
            this.comboStrScope.Size = new System.Drawing.Size(90, 21);
            this.comboStrScope.TabIndex = 1;
            this.comboStrScope.SelectedIndexChanged += new System.EventHandler(this.OnScriptControlChanged);
            // 
            // textStrEntry
            // 
            this.textStrEntry.Location = new System.Drawing.Point(262, 4);
            this.textStrEntry.Name = "textStrEntry";
            this.textStrEntry.Size = new System.Drawing.Size(60, 20);
            this.textStrEntry.TabIndex = 2;
            // 
            // panelParameters
            // 
            this.panelParameters.Controls.Add(this.lblParam1);
            this.panelParameters.Controls.Add(this.lblParam2);
            this.panelParameters.Controls.Add(this.lblParam3);
            this.panelParameters.Controls.Add(this.textDataValue1);
            this.panelParameters.Controls.Add(this.textDataValue2);
            this.panelParameters.Controls.Add(this.textDataValue3);
            this.panelParameters.Controls.Add(this.comboDataPicker1);
            this.panelParameters.Controls.Add(this.comboDataPicker2);
            this.panelParameters.Controls.Add(this.comboDataPicker3);
            this.panelParameters.Controls.Add(this.comboDataOwner1);
            this.panelParameters.Controls.Add(this.comboDataOwner2);
            this.panelParameters.Controls.Add(this.comboDataOwner3);
            this.panelParameters.Location = new System.Drawing.Point(0, 73);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(440, 76);
            this.panelParameters.TabIndex = 6;
            // 
            // lblParam1
            // 
            this.lblParam1.Location = new System.Drawing.Point(5, 3);
            this.lblParam1.Name = "lblParam1";
            this.lblParam1.Size = new System.Drawing.Size(95, 13);
            this.lblParam1.TabIndex = 5;
            this.lblParam1.Text = "Param 0:";
            this.lblParam1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblParam2
            // 
            this.lblParam2.Location = new System.Drawing.Point(5, 30);
            this.lblParam2.Name = "lblParam2";
            this.lblParam2.Size = new System.Drawing.Size(95, 13);
            this.lblParam2.TabIndex = 23;
            this.lblParam2.Text = "Param 1:";
            this.lblParam2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblParam3
            // 
            this.lblParam3.Location = new System.Drawing.Point(5, 57);
            this.lblParam3.Name = "lblParam3";
            this.lblParam3.Size = new System.Drawing.Size(95, 13);
            this.lblParam3.TabIndex = 25;
            this.lblParam3.Text = "Param 2:";
            this.lblParam3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 0);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 2;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 27);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 5;
            // 
            // textDataValue3
            // 
            this.textDataValue3.Location = new System.Drawing.Point(310, 54);
            this.textDataValue3.Name = "textDataValue3";
            this.textDataValue3.Size = new System.Drawing.Size(120, 20);
            this.textDataValue3.TabIndex = 8;
            // 
            // comboDataPicker1
            // 
            this.comboDataPicker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker1.FormattingEnabled = true;
            this.comboDataPicker1.Location = new System.Drawing.Point(310, 0);
            this.comboDataPicker1.Name = "comboDataPicker1";
            this.comboDataPicker1.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker1.TabIndex = 2;
            // 
            // comboDataPicker2
            // 
            this.comboDataPicker2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker2.FormattingEnabled = true;
            this.comboDataPicker2.Location = new System.Drawing.Point(310, 27);
            this.comboDataPicker2.Name = "comboDataPicker2";
            this.comboDataPicker2.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker2.TabIndex = 5;
            // 
            // comboDataPicker3
            // 
            this.comboDataPicker3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker3.FormattingEnabled = true;
            this.comboDataPicker3.Location = new System.Drawing.Point(310, 54);
            this.comboDataPicker3.Name = "comboDataPicker3";
            this.comboDataPicker3.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker3.TabIndex = 8;
            // 
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(100, 0);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner1.TabIndex = 0;
            // 
            // comboDataOwner2
            // 
            this.comboDataOwner2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner2.FormattingEnabled = true;
            this.comboDataOwner2.Location = new System.Drawing.Point(100, 27);
            this.comboDataOwner2.Name = "comboDataOwner2";
            this.comboDataOwner2.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner2.TabIndex = 3;
            // 
            // comboDataOwner3
            // 
            this.comboDataOwner3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner3.FormattingEnabled = true;
            this.comboDataOwner3.Location = new System.Drawing.Point(100, 54);
            this.comboDataOwner3.Name = "comboDataOwner3";
            this.comboDataOwner3.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner3.TabIndex = 6;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 155);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(136, 170);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 7;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 170);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 8;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 190);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox textStrRes;
        private System.Windows.Forms.ComboBox comboStrScope;
        private System.Windows.Forms.TextBox textStrEntry;
        private System.Windows.Forms.ComboBox comboScriptType;
        private System.Windows.Forms.Button btnScriptPicker;
        private System.Windows.Forms.Label lblParam1;
        private System.Windows.Forms.Label lblParam2;
        private System.Windows.Forms.Label lblParam3;
        private System.Windows.Forms.Label lblScript;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.CheckBox checkParameters;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataOwner2;
        private System.Windows.Forms.ComboBox comboDataPicker2;
        private System.Windows.Forms.TextBox textDataValue2;
        private System.Windows.Forms.ComboBox comboDataOwner3;
        private System.Windows.Forms.ComboBox comboDataPicker3;
        private System.Windows.Forms.TextBox textDataValue3;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblScriptName;
        private System.Windows.Forms.Label lblParameters;
    }
}
