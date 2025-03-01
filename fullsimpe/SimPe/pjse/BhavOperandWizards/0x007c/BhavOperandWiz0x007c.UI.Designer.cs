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

namespace whse.PrimitiveWizards.Wiz0x007c
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
            this.lblType = new System.Windows.Forms.Label();
            this.lblWantName = new System.Windows.Forms.Label();
            this.lblTargetSim = new System.Windows.Forms.Label();
            this.lblSubjectSim = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblWant = new System.Windows.Forms.Label();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.textDataValue3 = new System.Windows.Forms.TextBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.comboDataPicker3 = new System.Windows.Forms.ComboBox();
            this.textGUID = new System.Windows.Forms.TextBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner3 = new System.Windows.Forms.ComboBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblType);
            this.panelMain.Controls.Add(this.lblWantName);
            this.panelMain.Controls.Add(this.lblTargetSim);
            this.panelMain.Controls.Add(this.lblSubjectSim);
            this.panelMain.Controls.Add(this.lblLevel);
            this.panelMain.Controls.Add(this.lblWant);
            this.panelMain.Controls.Add(this.textDataValue1);
            this.panelMain.Controls.Add(this.textDataValue2);
            this.panelMain.Controls.Add(this.textDataValue3);
            this.panelMain.Controls.Add(this.comboDataPicker1);
            this.panelMain.Controls.Add(this.comboDataPicker2);
            this.panelMain.Controls.Add(this.comboType);
            this.panelMain.Controls.Add(this.comboDataPicker3);
            this.panelMain.Controls.Add(this.textGUID);
            this.panelMain.Controls.Add(this.comboDataOwner1);
            this.panelMain.Controls.Add(this.comboDataOwner2);
            this.panelMain.Controls.Add(this.comboDataOwner3);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 180);
            this.panelMain.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(5, 131);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(95, 13);
            this.lblType.TabIndex = 27;
            this.lblType.Text = "Type:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblWantName
            // 
            this.lblWantName.AutoSize = true;
            this.lblWantName.Location = new System.Drawing.Point(97, 29);
            this.lblWantName.Name = "lblWantName";
            this.lblWantName.Size = new System.Drawing.Size(59, 13);
            this.lblWantName.TabIndex = 26;
            this.lblWantName.Text = "want name";
            // 
            // lblTargetSim
            // 
            this.lblTargetSim.Location = new System.Drawing.Point(5, 50);
            this.lblTargetSim.Name = "lblTargetSim";
            this.lblTargetSim.Size = new System.Drawing.Size(95, 13);
            this.lblTargetSim.TabIndex = 5;
            this.lblTargetSim.Text = "Target Sim:";
            this.lblTargetSim.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSubjectSim
            // 
            this.lblSubjectSim.Location = new System.Drawing.Point(5, 77);
            this.lblSubjectSim.Name = "lblSubjectSim";
            this.lblSubjectSim.Size = new System.Drawing.Size(95, 13);
            this.lblSubjectSim.TabIndex = 23;
            this.lblSubjectSim.Text = "Subject Sim:";
            this.lblSubjectSim.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLevel
            // 
            this.lblLevel.Location = new System.Drawing.Point(5, 104);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(95, 13);
            this.lblLevel.TabIndex = 25;
            this.lblLevel.Text = "Level:";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblWant
            // 
            this.lblWant.Location = new System.Drawing.Point(5, 7);
            this.lblWant.Name = "lblWant";
            this.lblWant.Size = new System.Drawing.Size(95, 13);
            this.lblWant.TabIndex = 9;
            this.lblWant.Text = "Want:";
            this.lblWant.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 47);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 3;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 74);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 6;
            // 
            // textDataValue3
            // 
            this.textDataValue3.Location = new System.Drawing.Point(310, 101);
            this.textDataValue3.Name = "textDataValue3";
            this.textDataValue3.Size = new System.Drawing.Size(120, 20);
            this.textDataValue3.TabIndex = 9;
            // 
            // comboDataPicker1
            // 
            this.comboDataPicker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker1.FormattingEnabled = true;
            this.comboDataPicker1.Location = new System.Drawing.Point(310, 47);
            this.comboDataPicker1.Name = "comboDataPicker1";
            this.comboDataPicker1.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker1.TabIndex = 2;
            // 
            // comboDataPicker2
            // 
            this.comboDataPicker2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker2.FormattingEnabled = true;
            this.comboDataPicker2.Location = new System.Drawing.Point(310, 74);
            this.comboDataPicker2.Name = "comboDataPicker2";
            this.comboDataPicker2.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker2.TabIndex = 5;
            // 
            // comboType
            // 
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "Generic",
            "Sim",
            "Object",
            "{unused}",
            "Skill",
            "Career"});
            this.comboType.Location = new System.Drawing.Point(100, 128);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(90, 21);
            this.comboType.TabIndex = 10;
            this.comboType.SelectedIndexChanged += new System.EventHandler(this.OnWantControlChanged);
            // 
            // comboDataPicker3
            // 
            this.comboDataPicker3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker3.FormattingEnabled = true;
            this.comboDataPicker3.Location = new System.Drawing.Point(310, 101);
            this.comboDataPicker3.Name = "comboDataPicker3";
            this.comboDataPicker3.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker3.TabIndex = 8;
            // 
            // textGUID
            // 
            this.textGUID.Location = new System.Drawing.Point(100, 4);
            this.textGUID.Name = "textGUID";
            this.textGUID.Size = new System.Drawing.Size(120, 20);
            this.textGUID.TabIndex = 0;
            this.textGUID.TextChanged += new System.EventHandler(this.OnGuidChanged);
            this.textGUID.Validating += new System.ComponentModel.CancelEventHandler(this.OnGuidValidating);
            this.textGUID.Validated += new System.EventHandler(this.OnGuidValidated);
            // 
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(100, 47);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner1.TabIndex = 1;
            // 
            // comboDataOwner2
            // 
            this.comboDataOwner2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner2.FormattingEnabled = true;
            this.comboDataOwner2.Location = new System.Drawing.Point(100, 74);
            this.comboDataOwner2.Name = "comboDataOwner2";
            this.comboDataOwner2.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner2.TabIndex = 4;
            // 
            // comboDataOwner3
            // 
            this.comboDataOwner3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner3.FormattingEnabled = true;
            this.comboDataOwner3.Location = new System.Drawing.Point(100, 101);
            this.comboDataOwner3.Name = "comboDataOwner3";
            this.comboDataOwner3.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner3.TabIndex = 7;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 145);
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
            this.checkDecimal.Location = new System.Drawing.Point(136, 160);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 11;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 160);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 12;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 180);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.TextBox textGUID;
        private System.Windows.Forms.Label lblTargetSim;
        private System.Windows.Forms.Label lblSubjectSim;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblWant;
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
        private System.Windows.Forms.Label lblWantName;
        private System.Windows.Forms.Label lblType;
    }
}
