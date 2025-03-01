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

namespace whse.PrimitiveWizards.Wiz0x001a
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
            this.lblDontCheckSecondObject = new System.Windows.Forms.Label();
            this.checkDontCheckSecondObject = new System.Windows.Forms.CheckBox();
            this.lblFailIfTooSmall = new System.Windows.Forms.Label();
            this.checkUseNids = new System.Windows.Forms.CheckBox();
            this.checkFailIfTooSmall = new System.Windows.Forms.CheckBox();
            this.comboRelationship = new System.Windows.Forms.ComboBox();
            this.lblRelationship = new System.Windows.Forms.Label();
            this.comboAssignment = new System.Windows.Forms.ComboBox();
            this.lblAssignment = new System.Windows.Forms.Label();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.lblVariable = new System.Windows.Forms.Label();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.lblUseNids = new System.Windows.Forms.Label();
            this.lblNodeVersion1 = new System.Windows.Forms.Label();
            this.lblNodeVersion0 = new System.Windows.Forms.Label();
            this.panelFromTo = new System.Windows.Forms.Panel();
            this.lblTo = new System.Windows.Forms.Label();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.comboDataPicker3 = new System.Windows.Forms.ComboBox();
            this.textDataValue3 = new System.Windows.Forms.TextBox();
            this.comboDataOwner3 = new System.Windows.Forms.ComboBox();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.panelBetween = new System.Windows.Forms.Panel();
            this.comboBetween = new System.Windows.Forms.ComboBox();
            this.lblBetween = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelFromTo.SuspendLayout();
            this.panelBetween.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblDontCheckSecondObject);
            this.panelMain.Controls.Add(this.checkDontCheckSecondObject);
            this.panelMain.Controls.Add(this.lblFailIfTooSmall);
            this.panelMain.Controls.Add(this.checkUseNids);
            this.panelMain.Controls.Add(this.checkFailIfTooSmall);
            this.panelMain.Controls.Add(this.comboRelationship);
            this.panelMain.Controls.Add(this.lblRelationship);
            this.panelMain.Controls.Add(this.comboAssignment);
            this.panelMain.Controls.Add(this.lblAssignment);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.lblVariable);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.comboDataPicker1);
            this.panelMain.Controls.Add(this.textDataValue1);
            this.panelMain.Controls.Add(this.comboDataOwner1);
            this.panelMain.Controls.Add(this.lblUseNids);
            this.panelMain.Controls.Add(this.lblNodeVersion1);
            this.panelMain.Controls.Add(this.lblNodeVersion0);
            this.panelMain.Controls.Add(this.panelFromTo);
            this.panelMain.Controls.Add(this.panelBetween);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 225);
            this.panelMain.TabIndex = 0;
            // 
            // lblDontCheckSecondObject
            // 
            this.lblDontCheckSecondObject.Location = new System.Drawing.Point(5, 180);
            this.lblDontCheckSecondObject.Name = "lblDontCheckSecondObject";
            this.lblDontCheckSecondObject.Size = new System.Drawing.Size(95, 13);
            this.lblDontCheckSecondObject.TabIndex = 48;
            this.lblDontCheckSecondObject.Text = "Don\'t Check 2nd:";
            this.lblDontCheckSecondObject.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblDontCheckSecondObject, "Don\'t check presence of second bbject");
            // 
            // checkDontCheckSecondObject
            // 
            this.checkDontCheckSecondObject.AutoSize = true;
            this.checkDontCheckSecondObject.Location = new System.Drawing.Point(100, 180);
            this.checkDontCheckSecondObject.Name = "checkDontCheckSecondObject";
            this.checkDontCheckSecondObject.Size = new System.Drawing.Size(15, 14);
            this.checkDontCheckSecondObject.TabIndex = 47;
            this.toolTip.SetToolTip(this.checkDontCheckSecondObject, "Don\'t check presence of second bbject");
            this.checkDontCheckSecondObject.UseVisualStyleBackColor = true;
            // 
            // lblFailIfTooSmall
            // 
            this.lblFailIfTooSmall.Location = new System.Drawing.Point(5, 160);
            this.lblFailIfTooSmall.Name = "lblFailIfTooSmall";
            this.lblFailIfTooSmall.Size = new System.Drawing.Size(95, 13);
            this.lblFailIfTooSmall.TabIndex = 46;
            this.lblFailIfTooSmall.Text = "Fail If Too Small:";
            this.lblFailIfTooSmall.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkUseNids
            // 
            this.checkUseNids.AutoSize = true;
            this.checkUseNids.Location = new System.Drawing.Point(100, 140);
            this.checkUseNids.Name = "checkUseNids";
            this.checkUseNids.Size = new System.Drawing.Size(15, 14);
            this.checkUseNids.TabIndex = 6;
            this.checkUseNids.UseVisualStyleBackColor = true;
            // 
            // checkFailIfTooSmall
            // 
            this.checkFailIfTooSmall.AutoSize = true;
            this.checkFailIfTooSmall.Location = new System.Drawing.Point(100, 160);
            this.checkFailIfTooSmall.Name = "checkFailIfTooSmall";
            this.checkFailIfTooSmall.Size = new System.Drawing.Size(15, 14);
            this.checkFailIfTooSmall.TabIndex = 4;
            this.checkFailIfTooSmall.UseVisualStyleBackColor = true;
            // 
            // comboRelationship
            // 
            this.comboRelationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRelationship.FormattingEnabled = true;
            this.comboRelationship.Items.AddRange(new object[] {
            "STR",
            "UI Flags/Ownership",
            "LTR",
            "Familial Relationship",
            "Sync People",
            "Childhood UI Flags",
            "Teen UI Flags",
            "Adult UI Flags",
            "Attraction Score",
            "UI Flags 2"});
            this.comboRelationship.Location = new System.Drawing.Point(100, 3);
            this.comboRelationship.Name = "comboRelationship";
            this.comboRelationship.Size = new System.Drawing.Size(170, 21);
            this.comboRelationship.TabIndex = 5;
            // 
            // lblRelationship
            // 
            this.lblRelationship.Location = new System.Drawing.Point(5, 6);
            this.lblRelationship.Name = "lblRelationship";
            this.lblRelationship.Size = new System.Drawing.Size(95, 13);
            this.lblRelationship.TabIndex = 45;
            this.lblRelationship.Text = "Relationship:";
            this.lblRelationship.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboAssignment
            // 
            this.comboAssignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAssignment.FormattingEnabled = true;
            this.comboAssignment.Items.AddRange(new object[] {
            "Variable := Relationship",
            "Relationship := Variable"});
            this.comboAssignment.Location = new System.Drawing.Point(100, 30);
            this.comboAssignment.Name = "comboAssignment";
            this.comboAssignment.Size = new System.Drawing.Size(170, 21);
            this.comboAssignment.TabIndex = 3;
            // 
            // lblAssignment
            // 
            this.lblAssignment.Location = new System.Drawing.Point(5, 33);
            this.lblAssignment.Name = "lblAssignment";
            this.lblAssignment.Size = new System.Drawing.Size(95, 13);
            this.lblAssignment.TabIndex = 43;
            this.lblAssignment.Text = "Assignment:";
            this.lblAssignment.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(136, 205);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 15;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 205);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 16;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // lblVariable
            // 
            this.lblVariable.Location = new System.Drawing.Point(5, 61);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(95, 13);
            this.lblVariable.TabIndex = 37;
            this.lblVariable.Text = "Variable:";
            this.lblVariable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 190);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // comboDataPicker1
            // 
            this.comboDataPicker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker1.FormattingEnabled = true;
            this.comboDataPicker1.Location = new System.Drawing.Point(310, 57);
            this.comboDataPicker1.Name = "comboDataPicker1";
            this.comboDataPicker1.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker1.TabIndex = 1;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 58);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 2;
            // 
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(100, 57);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner1.TabIndex = 0;
            // 
            // lblUseNids
            // 
            this.lblUseNids.Location = new System.Drawing.Point(5, 140);
            this.lblUseNids.Name = "lblUseNids";
            this.lblUseNids.Size = new System.Drawing.Size(95, 13);
            this.lblUseNids.TabIndex = 5;
            this.lblUseNids.Text = "Use NIDs:";
            this.lblUseNids.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNodeVersion1
            // 
            this.lblNodeVersion1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNodeVersion1.AutoSize = true;
            this.lblNodeVersion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNodeVersion1.Location = new System.Drawing.Point(5, 206);
            this.lblNodeVersion1.Name = "lblNodeVersion1";
            this.lblNodeVersion1.Size = new System.Drawing.Size(114, 13);
            this.lblNodeVersion1.TabIndex = 51;
            this.lblNodeVersion1.Text = "Node Version 0x01";
            // 
            // lblNodeVersion0
            // 
            this.lblNodeVersion0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNodeVersion0.AutoSize = true;
            this.lblNodeVersion0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNodeVersion0.ForeColor = System.Drawing.Color.Red;
            this.lblNodeVersion0.Location = new System.Drawing.Point(5, 206);
            this.lblNodeVersion0.Name = "lblNodeVersion0";
            this.lblNodeVersion0.Size = new System.Drawing.Size(114, 13);
            this.lblNodeVersion0.TabIndex = 50;
            this.lblNodeVersion0.Text = "Node Version 0x00";
            this.toolTip.SetToolTip(this.lblNodeVersion0, "It is strongly recommended to use Node Version 0x01");
            // 
            // panelFromTo
            // 
            this.panelFromTo.Controls.Add(this.lblTo);
            this.panelFromTo.Controls.Add(this.comboDataOwner2);
            this.panelFromTo.Controls.Add(this.comboDataPicker2);
            this.panelFromTo.Controls.Add(this.lblFrom);
            this.panelFromTo.Controls.Add(this.comboDataPicker3);
            this.panelFromTo.Controls.Add(this.textDataValue3);
            this.panelFromTo.Controls.Add(this.comboDataOwner3);
            this.panelFromTo.Controls.Add(this.textDataValue2);
            this.panelFromTo.Location = new System.Drawing.Point(0, 84);
            this.panelFromTo.Name = "panelFromTo";
            this.panelFromTo.Size = new System.Drawing.Size(440, 48);
            this.panelFromTo.TabIndex = 7;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(5, 30);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(95, 13);
            this.lblTo.TabIndex = 23;
            this.lblTo.Text = "And:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.comboDataPicker2.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(5, 3);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(95, 13);
            this.lblFrom.TabIndex = 47;
            this.lblFrom.Text = "Between:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboDataPicker3
            // 
            this.comboDataPicker3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker3.FormattingEnabled = true;
            this.comboDataPicker3.Location = new System.Drawing.Point(310, 27);
            this.comboDataPicker3.Name = "comboDataPicker3";
            this.comboDataPicker3.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker3.TabIndex = 28;
            // 
            // textDataValue3
            // 
            this.textDataValue3.Location = new System.Drawing.Point(310, 27);
            this.textDataValue3.Name = "textDataValue3";
            this.textDataValue3.Size = new System.Drawing.Size(120, 20);
            this.textDataValue3.TabIndex = 11;
            // 
            // comboDataOwner3
            // 
            this.comboDataOwner3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner3.FormattingEnabled = true;
            this.comboDataOwner3.Location = new System.Drawing.Point(100, 27);
            this.comboDataOwner3.Name = "comboDataOwner3";
            this.comboDataOwner3.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner3.TabIndex = 9;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 0);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 1;
            // 
            // panelBetween
            // 
            this.panelBetween.Controls.Add(this.comboBetween);
            this.panelBetween.Controls.Add(this.lblBetween);
            this.panelBetween.Location = new System.Drawing.Point(0, 84);
            this.panelBetween.Name = "panelBetween";
            this.panelBetween.Size = new System.Drawing.Size(440, 21);
            this.panelBetween.TabIndex = 49;
            // 
            // comboBetween
            // 
            this.comboBetween.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBetween.FormattingEnabled = true;
            this.comboBetween.Items.AddRange(new object[] {
            "Me to Stack Object",
            "Stack Object to Me",
            "Stack Object to Param 0",
            "Param 0 to Stack Object"});
            this.comboBetween.Location = new System.Drawing.Point(100, 0);
            this.comboBetween.Name = "comboBetween";
            this.comboBetween.Size = new System.Drawing.Size(170, 21);
            this.comboBetween.TabIndex = 50;
            // 
            // lblBetween
            // 
            this.lblBetween.Location = new System.Drawing.Point(5, 3);
            this.lblBetween.Name = "lblBetween";
            this.lblBetween.Size = new System.Drawing.Size(95, 13);
            this.lblBetween.TabIndex = 51;
            this.lblBetween.Text = "Between:";
            this.lblBetween.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 225);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelFromTo.ResumeLayout(false);
            this.panelFromTo.PerformLayout();
            this.panelBetween.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblUseNids;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox textDataValue3;
        private System.Windows.Forms.ComboBox comboDataPicker3;
        private System.Windows.Forms.ComboBox comboDataOwner3;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.ComboBox comboRelationship;
        private System.Windows.Forms.Label lblRelationship;
        private System.Windows.Forms.ComboBox comboAssignment;
        private System.Windows.Forms.Label lblAssignment;
        private System.Windows.Forms.ComboBox comboDataOwner2;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox textDataValue2;
        private System.Windows.Forms.ComboBox comboDataPicker2;
        private System.Windows.Forms.CheckBox checkFailIfTooSmall;
        private System.Windows.Forms.Panel panelFromTo;
        private System.Windows.Forms.CheckBox checkUseNids;
        private System.Windows.Forms.Label lblDontCheckSecondObject;
        private System.Windows.Forms.CheckBox checkDontCheckSecondObject;
        private System.Windows.Forms.Label lblFailIfTooSmall;
        private System.Windows.Forms.Panel panelBetween;
        private System.Windows.Forms.ComboBox comboBetween;
        private System.Windows.Forms.Label lblBetween;
        private System.Windows.Forms.Label lblNodeVersion0;
        private System.Windows.Forms.Label lblNodeVersion1;
    }
}
