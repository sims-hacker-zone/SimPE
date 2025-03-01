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

namespace whse.PrimitiveWizards.Wiz0x0079
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkClear = new System.Windows.Forms.CheckBox();
            this.lblClear = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.textGUID = new System.Windows.Forms.TextBox();
            this.lblGuid = new System.Windows.Forms.Label();
            this.lblOutfitType = new System.Windows.Forms.Label();
            this.comboOutfitType = new System.Windows.Forms.ComboBox();
            this.checkOutfitVariable = new System.Windows.Forms.CheckBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.comboSource = new System.Windows.Forms.ComboBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.checkRebuild = new System.Windows.Forms.CheckBox();
            this.lblRebuild = new System.Windows.Forms.Label();
            this.checkSave = new System.Windows.Forms.CheckBox();
            this.lblSave = new System.Windows.Forms.Label();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.lblVariable = new System.Windows.Forms.Label();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 165);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 16;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // checkClear
            // 
            this.checkClear.AutoSize = true;
            this.checkClear.Location = new System.Drawing.Point(100, 165);
            this.checkClear.Name = "checkClear";
            this.checkClear.Size = new System.Drawing.Size(15, 14);
            this.checkClear.TabIndex = 10;
            this.toolTip.SetToolTip(this.checkClear, "Clear GUID pointers in Person Data fields");
            this.checkClear.UseVisualStyleBackColor = true;
            // 
            // lblClear
            // 
            this.lblClear.Location = new System.Drawing.Point(5, 165);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(95, 13);
            this.lblClear.TabIndex = 56;
            this.lblClear.Text = "Clear Pointers:";
            this.lblClear.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblClear, "Clear GUID pointers in Person Data fields");
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(5, 34);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(95, 13);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source:";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textGUID
            // 
            this.textGUID.Location = new System.Drawing.Point(280, 31);
            this.textGUID.Name = "textGUID";
            this.textGUID.Size = new System.Drawing.Size(150, 20);
            this.textGUID.TabIndex = 4;
            this.textGUID.TextChanged += new System.EventHandler(this.OnGuidChanged);
            this.textGUID.Validating += new System.ComponentModel.CancelEventHandler(this.OnGuidValidating);
            this.textGUID.Validated += new System.EventHandler(this.OnGuidValidated);
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(97, 55);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(118, 13);
            this.lblGuid.TabIndex = 2;
            this.lblGuid.Text = "GUID {guid} (\"{name}\")";
            // 
            // lblOutfitType
            // 
            this.lblOutfitType.Location = new System.Drawing.Point(5, 74);
            this.lblOutfitType.Name = "lblOutfitType";
            this.lblOutfitType.Size = new System.Drawing.Size(95, 13);
            this.lblOutfitType.TabIndex = 5;
            this.lblOutfitType.Text = "Outfit:";
            this.lblOutfitType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboOutfitType
            // 
            this.comboOutfitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOutfitType.FormattingEnabled = true;
            this.comboOutfitType.Items.AddRange(new object[] {
            "Everyday",
            "Naked",
            "Swimwear",
            "Gym",
            "Formal",
            "PJs",
            "{unused6}",
            "{unused7}",
            "Maternity",
            "{unused9}",
            "{unusedA}",
            "Underwear",
            "{unusedC}",
            "Outerwear"});
            this.comboOutfitType.Location = new System.Drawing.Point(100, 71);
            this.comboOutfitType.Name = "comboOutfitType";
            this.comboOutfitType.Size = new System.Drawing.Size(90, 21);
            this.comboOutfitType.TabIndex = 5;
            // 
            // checkOutfitVariable
            // 
            this.checkOutfitVariable.AutoSize = true;
            this.checkOutfitVariable.Location = new System.Drawing.Point(196, 73);
            this.checkOutfitVariable.Name = "checkOutfitVariable";
            this.checkOutfitVariable.Size = new System.Drawing.Size(86, 17);
            this.checkOutfitVariable.TabIndex = 6;
            this.checkOutfitVariable.Text = "Use Variable";
            this.checkOutfitVariable.UseVisualStyleBackColor = true;
            this.checkOutfitVariable.CheckedChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(136, 180);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 11;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // comboSource
            // 
            this.comboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSource.FormattingEnabled = true;
            this.comboSource.Items.AddRange(new object[] {
            "My Outfits",
            "Specific GUID",
            "GUID in T0/1",
            "Stack Object"});
            this.comboSource.Location = new System.Drawing.Point(100, 31);
            this.comboSource.Name = "comboSource";
            this.comboSource.Size = new System.Drawing.Size(167, 21);
            this.comboSource.TabIndex = 3;
            this.comboSource.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(100, 4);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner1.TabIndex = 0;
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
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(5, 7);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(95, 13);
            this.lblTarget.TabIndex = 37;
            this.lblTarget.Text = "Target:";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 4);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblClear);
            this.panelMain.Controls.Add(this.checkClear);
            this.panelMain.Controls.Add(this.checkRebuild);
            this.panelMain.Controls.Add(this.lblRebuild);
            this.panelMain.Controls.Add(this.checkSave);
            this.panelMain.Controls.Add(this.lblSave);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.textDataValue1);
            this.panelMain.Controls.Add(this.lblTarget);
            this.panelMain.Controls.Add(this.comboDataPicker1);
            this.panelMain.Controls.Add(this.comboDataOwner1);
            this.panelMain.Controls.Add(this.comboSource);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkOutfitVariable);
            this.panelMain.Controls.Add(this.comboOutfitType);
            this.panelMain.Controls.Add(this.lblOutfitType);
            this.panelMain.Controls.Add(this.lblGuid);
            this.panelMain.Controls.Add(this.textGUID);
            this.panelMain.Controls.Add(this.lblSource);
            this.panelMain.Controls.Add(this.panelVariable);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 200);
            this.panelMain.TabIndex = 0;
            // 
            // checkRebuild
            // 
            this.checkRebuild.AutoSize = true;
            this.checkRebuild.Location = new System.Drawing.Point(100, 145);
            this.checkRebuild.Name = "checkRebuild";
            this.checkRebuild.Size = new System.Drawing.Size(15, 14);
            this.checkRebuild.TabIndex = 9;
            this.checkRebuild.UseVisualStyleBackColor = true;
            // 
            // lblRebuild
            // 
            this.lblRebuild.Location = new System.Drawing.Point(5, 145);
            this.lblRebuild.Name = "lblRebuild";
            this.lblRebuild.Size = new System.Drawing.Size(95, 13);
            this.lblRebuild.TabIndex = 53;
            this.lblRebuild.Text = "Rebuild:";
            this.lblRebuild.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkSave
            // 
            this.checkSave.AutoSize = true;
            this.checkSave.Location = new System.Drawing.Point(100, 125);
            this.checkSave.Name = "checkSave";
            this.checkSave.Size = new System.Drawing.Size(15, 14);
            this.checkSave.TabIndex = 8;
            this.checkSave.UseVisualStyleBackColor = true;
            // 
            // lblSave
            // 
            this.lblSave.Location = new System.Drawing.Point(5, 125);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(95, 13);
            this.lblSave.TabIndex = 51;
            this.lblSave.Text = "Save:";
            this.lblSave.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 180);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 12;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // panelVariable
            // 
            this.panelVariable.Controls.Add(this.comboDataOwner2);
            this.panelVariable.Controls.Add(this.lblVariable);
            this.panelVariable.Controls.Add(this.comboDataPicker2);
            this.panelVariable.Controls.Add(this.textDataValue2);
            this.panelVariable.Location = new System.Drawing.Point(0, 98);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(440, 21);
            this.panelVariable.TabIndex = 7;
            // 
            // comboDataOwner2
            // 
            this.comboDataOwner2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner2.FormattingEnabled = true;
            this.comboDataOwner2.Location = new System.Drawing.Point(100, 0);
            this.comboDataOwner2.Name = "comboDataOwner2";
            this.comboDataOwner2.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner2.TabIndex = 0;
            // 
            // lblVariable
            // 
            this.lblVariable.Location = new System.Drawing.Point(5, 3);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(95, 13);
            this.lblVariable.TabIndex = 43;
            this.lblVariable.Text = "Variable:";
            this.lblVariable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboDataPicker2
            // 
            this.comboDataPicker2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker2.FormattingEnabled = true;
            this.comboDataPicker2.Location = new System.Drawing.Point(310, 0);
            this.comboDataPicker2.Name = "comboDataPicker2";
            this.comboDataPicker2.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker2.TabIndex = 1;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 0);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 2;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 200);
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.TextBox textGUID;
        private System.Windows.Forms.Label lblGuid;
        private System.Windows.Forms.Label lblOutfitType;
        private System.Windows.Forms.ComboBox comboOutfitType;
        private System.Windows.Forms.CheckBox checkOutfitVariable;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.ComboBox comboSource;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox textDataValue2;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.ComboBox comboDataOwner2;
        private System.Windows.Forms.ComboBox comboDataPicker2;
        private System.Windows.Forms.CheckBox checkSave;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.CheckBox checkClear;
        private System.Windows.Forms.CheckBox checkRebuild;
        private System.Windows.Forms.Label lblRebuild;
    }
}
