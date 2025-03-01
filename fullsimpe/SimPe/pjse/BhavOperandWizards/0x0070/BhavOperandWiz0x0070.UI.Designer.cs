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

namespace whse.PrimitiveWizards.Wiz0x0070
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
            this.panelSlot = new System.Windows.Forms.Panel();
            this.textSlot = new System.Windows.Forms.TextBox();
            this.comboSlotType = new System.Windows.Forms.ComboBox();
            this.lblSlot = new System.Windows.Forms.Label();
            this.panelIconIndex = new System.Windows.Forms.Panel();
            this.textIconIndex = new System.Windows.Forms.TextBox();
            this.panelEffect = new System.Windows.Forms.Panel();
            this.labelDefaultEffect = new System.Windows.Forms.Label();
            this.textEffect = new System.Windows.Forms.TextBox();
            this.comboEffect = new System.Windows.Forms.ComboBox();
            this.lblEffect = new System.Windows.Forms.Label();
            this.panelEffectVariable = new System.Windows.Forms.Panel();
            this.comboEffectScope = new System.Windows.Forms.ComboBox();
            this.btnEffect = new System.Windows.Forms.Button();
            this.lblEffectName = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.comboIconType = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.checkModel = new System.Windows.Forms.CheckBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.comboAction = new System.Windows.Forms.ComboBox();
            this.panelIconVariable = new System.Windows.Forms.Panel();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.checkPriority = new System.Windows.Forms.CheckBox();
            this.lblIcon = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            this.panelSlot.SuspendLayout();
            this.panelIconIndex.SuspendLayout();
            this.panelEffect.SuspendLayout();
            this.panelEffectVariable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelIconVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelSlot);
            this.panelMain.Controls.Add(this.panelIconIndex);
            this.panelMain.Controls.Add(this.panelEffect);
            this.panelMain.Controls.Add(this.panelEffectVariable);
            this.panelMain.Controls.Add(this.lblPriority);
            this.panelMain.Controls.Add(this.comboIconType);
            this.panelMain.Controls.Add(this.lblModel);
            this.panelMain.Controls.Add(this.lblTarget);
            this.panelMain.Controls.Add(this.checkModel);
            this.panelMain.Controls.Add(this.lblAction);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.comboAction);
            this.panelMain.Controls.Add(this.panelIconVariable);
            this.panelMain.Controls.Add(this.comboDataPicker1);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.textDataValue1);
            this.panelMain.Controls.Add(this.comboDataOwner1);
            this.panelMain.Controls.Add(this.checkPriority);
            this.panelMain.Controls.Add(this.lblIcon);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 245);
            this.panelMain.TabIndex = 0;
            // 
            // panelSlot
            // 
            this.panelSlot.Controls.Add(this.textSlot);
            this.panelSlot.Controls.Add(this.comboSlotType);
            this.panelSlot.Controls.Add(this.lblSlot);
            this.panelSlot.Location = new System.Drawing.Point(0, 111);
            this.panelSlot.Name = "panelSlot";
            this.panelSlot.Size = new System.Drawing.Size(440, 21);
            this.panelSlot.TabIndex = 70;
            // 
            // textSlot
            // 
            this.textSlot.Location = new System.Drawing.Point(196, 1);
            this.textSlot.Name = "textSlot";
            this.textSlot.Size = new System.Drawing.Size(60, 20);
            this.textSlot.TabIndex = 8;
            // 
            // comboSlotType
            // 
            this.comboSlotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSlotType.FormattingEnabled = true;
            this.comboSlotType.Items.AddRange(new object[] {
            "Target",
            "Routing",
            "Container"});
            this.comboSlotType.Location = new System.Drawing.Point(100, 0);
            this.comboSlotType.Name = "comboSlotType";
            this.comboSlotType.Size = new System.Drawing.Size(90, 21);
            this.comboSlotType.TabIndex = 7;
            // 
            // lblSlot
            // 
            this.lblSlot.Location = new System.Drawing.Point(5, 4);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(95, 13);
            this.lblSlot.TabIndex = 63;
            this.lblSlot.Text = "Slot:";
            this.lblSlot.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelIconIndex
            // 
            this.panelIconIndex.Controls.Add(this.textIconIndex);
            this.panelIconIndex.Location = new System.Drawing.Point(196, 138);
            this.panelIconIndex.Name = "panelIconIndex";
            this.panelIconIndex.Size = new System.Drawing.Size(244, 21);
            this.panelIconIndex.TabIndex = 69;
            // 
            // textIconIndex
            // 
            this.textIconIndex.Location = new System.Drawing.Point(0, 1);
            this.textIconIndex.Name = "textIconIndex";
            this.textIconIndex.Size = new System.Drawing.Size(60, 20);
            this.textIconIndex.TabIndex = 10;
            // 
            // panelEffect
            // 
            this.panelEffect.Controls.Add(this.labelDefaultEffect);
            this.panelEffect.Controls.Add(this.textEffect);
            this.panelEffect.Controls.Add(this.comboEffect);
            this.panelEffect.Controls.Add(this.lblEffect);
            this.panelEffect.Location = new System.Drawing.Point(0, 58);
            this.panelEffect.Name = "panelEffect";
            this.panelEffect.Size = new System.Drawing.Size(440, 21);
            this.panelEffect.TabIndex = 68;
            // 
            // labelDefaultEffect
            // 
            this.labelDefaultEffect.AutoSize = true;
            this.labelDefaultEffect.Location = new System.Drawing.Point(262, 4);
            this.labelDefaultEffect.Name = "labelDefaultEffect";
            this.labelDefaultEffect.Size = new System.Drawing.Size(129, 13);
            this.labelDefaultEffect.TabIndex = 60;
            this.labelDefaultEffect.Text = "(0xFF is the default effect)";
            // 
            // textEffect
            // 
            this.textEffect.Location = new System.Drawing.Point(196, 1);
            this.textEffect.Name = "textEffect";
            this.textEffect.Size = new System.Drawing.Size(60, 20);
            this.textEffect.TabIndex = 5;
            // 
            // comboEffect
            // 
            this.comboEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEffect.FormattingEnabled = true;
            this.comboEffect.Items.AddRange(new object[] {
            "Literal",
            "In Temp 1"});
            this.comboEffect.Location = new System.Drawing.Point(100, 0);
            this.comboEffect.Name = "comboEffect";
            this.comboEffect.Size = new System.Drawing.Size(90, 21);
            this.comboEffect.TabIndex = 4;
            this.comboEffect.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblEffect
            // 
            this.lblEffect.Location = new System.Drawing.Point(5, 4);
            this.lblEffect.Name = "lblEffect";
            this.lblEffect.Size = new System.Drawing.Size(95, 13);
            this.lblEffect.TabIndex = 59;
            this.lblEffect.Text = "Effect:";
            this.lblEffect.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelEffectVariable
            // 
            this.panelEffectVariable.Controls.Add(this.comboEffectScope);
            this.panelEffectVariable.Controls.Add(this.btnEffect);
            this.panelEffectVariable.Controls.Add(this.lblEffectName);
            this.panelEffectVariable.Location = new System.Drawing.Point(0, 84);
            this.panelEffectVariable.Name = "panelEffectVariable";
            this.panelEffectVariable.Size = new System.Drawing.Size(440, 21);
            this.panelEffectVariable.TabIndex = 6;
            // 
            // comboEffectScope
            // 
            this.comboEffectScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEffectScope.FormattingEnabled = true;
            this.comboEffectScope.Items.AddRange(new object[] {
            "Private",
            "Semi-Global",
            "Global"});
            this.comboEffectScope.Location = new System.Drawing.Point(100, 0);
            this.comboEffectScope.Name = "comboEffectScope";
            this.comboEffectScope.Size = new System.Drawing.Size(90, 21);
            this.comboEffectScope.TabIndex = 0;
            this.comboEffectScope.SelectedIndexChanged += new System.EventHandler(this.OnEffectControlChanged);
            // 
            // btnEffect
            // 
            this.btnEffect.Location = new System.Drawing.Point(196, 0);
            this.btnEffect.Margin = new System.Windows.Forms.Padding(1);
            this.btnEffect.Name = "btnEffect";
            this.btnEffect.Size = new System.Drawing.Size(27, 21);
            this.btnEffect.TabIndex = 1;
            this.btnEffect.Text = ">>";
            this.btnEffect.UseVisualStyleBackColor = true;
            this.btnEffect.Click += new System.EventHandler(this.OnEffectPickerClicked);
            // 
            // lblEffectName
            // 
            this.lblEffectName.AutoSize = true;
            this.lblEffectName.Location = new System.Drawing.Point(227, 4);
            this.lblEffectName.Name = "lblEffectName";
            this.lblEffectName.Size = new System.Drawing.Size(34, 13);
            this.lblEffectName.TabIndex = 61;
            this.lblEffectName.Text = "effect";
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(5, 192);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(95, 13);
            this.lblPriority.TabIndex = 67;
            this.lblPriority.Text = "Priority:";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboIconType
            // 
            this.comboIconType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIconType.FormattingEnabled = true;
            this.comboIconType.Items.AddRange(new object[] {
            "None",
            "Normal",
            "NID",
            "Conversation",
            "GUID In T4/5",
            "In Temp 6"});
            this.comboIconType.Location = new System.Drawing.Point(100, 138);
            this.comboIconType.Name = "comboIconType";
            this.comboIconType.Size = new System.Drawing.Size(90, 21);
            this.comboIconType.TabIndex = 9;
            this.comboIconType.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblModel
            // 
            this.lblModel.Location = new System.Drawing.Point(5, 214);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(95, 13);
            this.lblModel.TabIndex = 15;
            this.lblModel.Text = "Model in T6:";
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(5, 33);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(95, 13);
            this.lblTarget.TabIndex = 23;
            this.lblTarget.Text = "Target:";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkModel
            // 
            this.checkModel.AutoSize = true;
            this.checkModel.Location = new System.Drawing.Point(100, 214);
            this.checkModel.Name = "checkModel";
            this.checkModel.Size = new System.Drawing.Size(15, 14);
            this.checkModel.TabIndex = 13;
            this.checkModel.UseVisualStyleBackColor = true;
            // 
            // lblAction
            // 
            this.lblAction.Location = new System.Drawing.Point(5, 7);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(95, 13);
            this.lblAction.TabIndex = 5;
            this.lblAction.Text = "Action:";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;

			this.iconPnM.Location = new System.Drawing.Point(405, 210);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // comboAction
            // 
            this.comboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAction.FormattingEnabled = true;
            this.comboAction.Items.AddRange(new object[] {
            "Soft Start effect#",
            "Hard Start effect#",
            "Soft Stop effect#",
            "Hard Stop effect#",
            "Hard Stop effect ID",
            "Hard Stop All effect IDs",
            "Fire and Forget effect#",
            "Interrogate Bone for effects",
            "Clear Qeue & Hard Stop All effects",
            "Hard Stop All effects",
            "Set State 1 for all effects",
            "Set State 2 for all effects",
            "Set State 3 for all effects",
            "Set Satate 4 for all effects",
            "Soft Stop All effect#"});
            this.comboAction.Location = new System.Drawing.Point(100, 3);
            this.comboAction.Name = "comboAction";
            this.comboAction.Size = new System.Drawing.Size(200, 21);
            this.comboAction.TabIndex = 0;
            this.comboAction.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // panelIconVariable
            // 
            this.panelIconVariable.Controls.Add(this.comboDataOwner2);
            this.panelIconVariable.Controls.Add(this.comboDataPicker2);
            this.panelIconVariable.Controls.Add(this.textDataValue2);
            this.panelIconVariable.Location = new System.Drawing.Point(0, 165);
            this.panelIconVariable.Name = "panelIconVariable";
            this.panelIconVariable.Size = new System.Drawing.Size(440, 21);
            this.panelIconVariable.TabIndex = 11;
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
            // comboDataPicker1
            // 
            this.comboDataPicker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker1.FormattingEnabled = true;
            this.comboDataPicker1.Location = new System.Drawing.Point(310, 30);
            this.comboDataPicker1.Name = "comboDataPicker1";
            this.comboDataPicker1.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker1.TabIndex = 2;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 225);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 15;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(136, 225);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 14;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 30);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 3;
            // 
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(100, 30);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner1.TabIndex = 1;
            // 
            // checkPriority
            // 
            this.checkPriority.AutoSize = true;
            this.checkPriority.Location = new System.Drawing.Point(100, 192);
            this.checkPriority.Name = "checkPriority";
            this.checkPriority.Size = new System.Drawing.Size(15, 14);
            this.checkPriority.TabIndex = 12;
            this.checkPriority.UseVisualStyleBackColor = true;
            // 
            // lblIcon
            // 
            this.lblIcon.Location = new System.Drawing.Point(5, 142);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(95, 13);
            this.lblIcon.TabIndex = 16;
            this.lblIcon.Text = "Icon:";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 245);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelSlot.ResumeLayout(false);
            this.panelSlot.PerformLayout();
            this.panelIconIndex.ResumeLayout(false);
            this.panelIconIndex.PerformLayout();
            this.panelEffect.ResumeLayout(false);
            this.panelEffect.PerformLayout();
            this.panelEffectVariable.ResumeLayout(false);
            this.panelEffectVariable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelIconVariable.ResumeLayout(false);
            this.panelIconVariable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.ComboBox comboAction;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.CheckBox checkPriority;
        private System.Windows.Forms.CheckBox checkModel;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.TextBox textDataValue2;
        private System.Windows.Forms.ComboBox comboDataPicker2;
        private System.Windows.Forms.ComboBox comboDataOwner2;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelIconVariable;
        private System.Windows.Forms.ComboBox comboEffectScope;
        private System.Windows.Forms.ComboBox comboSlotType;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.TextBox textSlot;
        private System.Windows.Forms.Label lblEffectName;
        private System.Windows.Forms.TextBox textIconIndex;
        private System.Windows.Forms.Label lblEffect;
        private System.Windows.Forms.Button btnEffect;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox comboIconType;
        private System.Windows.Forms.ComboBox comboEffect;
        private System.Windows.Forms.TextBox textEffect;
        private System.Windows.Forms.Panel panelEffectVariable;
        private System.Windows.Forms.Panel panelSlot;
        private System.Windows.Forms.Panel panelIconIndex;
        private System.Windows.Forms.Panel panelEffect;
        private System.Windows.Forms.Label labelDefaultEffect;
    }
}
