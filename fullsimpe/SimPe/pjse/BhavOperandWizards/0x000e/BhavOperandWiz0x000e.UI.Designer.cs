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

namespace whse.PrimitiveWizards.Wiz0x000e
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
            this.lblLocation = new System.Windows.Forms.Label();
            this.comboLocation = new System.Windows.Forms.ComboBox();
            this.lblRelativeTo = new System.Windows.Forms.Label();
            this.comboRelativeTo = new System.Windows.Forms.ComboBox();
            this.lblLineOfSight = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.checkLineOfSight = new System.Windows.Forms.CheckBox();
            this.comboFunction = new System.Windows.Forms.ComboBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.panelObject = new System.Windows.Forms.Panel();
            this.lblObject = new System.Windows.Forms.Label();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkIgnoreLockout = new System.Windows.Forms.CheckBox();
            this.lblIgnoreLockout = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblLocation);
            this.panelMain.Controls.Add(this.comboLocation);
            this.panelMain.Controls.Add(this.lblRelativeTo);
            this.panelMain.Controls.Add(this.comboRelativeTo);
            this.panelMain.Controls.Add(this.lblLineOfSight);
            this.panelMain.Controls.Add(this.lblFunction);
            this.panelMain.Controls.Add(this.checkLineOfSight);
            this.panelMain.Controls.Add(this.comboFunction);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.panelObject);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkIgnoreLockout);
            this.panelMain.Controls.Add(this.lblIgnoreLockout);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 170);
            this.panelMain.TabIndex = 0;
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(5, 90);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(95, 13);
            this.lblLocation.TabIndex = 21;
            this.lblLocation.Text = "Location:";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboLocation
            // 
            this.comboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLocation.FormattingEnabled = true;
            this.comboLocation.Items.AddRange(new object[] {
            "Anywhere",
            "Outside Only",
            "Inside Only",
            "Same Room"});
            this.comboLocation.Location = new System.Drawing.Point(100, 87);
            this.comboLocation.Name = "comboLocation";
            this.comboLocation.Size = new System.Drawing.Size(150, 21);
            this.comboLocation.TabIndex = 20;
            // 
            // lblRelativeTo
            // 
            this.lblRelativeTo.Location = new System.Drawing.Point(5, 34);
            this.lblRelativeTo.Name = "lblRelativeTo";
            this.lblRelativeTo.Size = new System.Drawing.Size(95, 13);
            this.lblRelativeTo.TabIndex = 19;
            this.lblRelativeTo.Text = "Relative To:";
            this.lblRelativeTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboRelativeTo
            // 
            this.comboRelativeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRelativeTo.FormattingEnabled = true;
            this.comboRelativeTo.Items.AddRange(new object[] {
            "Me",
            "Object"});
            this.comboRelativeTo.Location = new System.Drawing.Point(100, 31);
            this.comboRelativeTo.Name = "comboRelativeTo";
            this.comboRelativeTo.Size = new System.Drawing.Size(150, 21);
            this.comboRelativeTo.TabIndex = 18;
            this.comboRelativeTo.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblLineOfSight
            // 
            this.lblLineOfSight.Location = new System.Drawing.Point(5, 116);
            this.lblLineOfSight.Name = "lblLineOfSight";
            this.lblLineOfSight.Size = new System.Drawing.Size(95, 13);
            this.lblLineOfSight.TabIndex = 15;
            this.lblLineOfSight.Text = "In Line Of Sight:";
            this.lblLineOfSight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFunction
            // 
            this.lblFunction.Location = new System.Drawing.Point(5, 7);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(95, 13);
            this.lblFunction.TabIndex = 5;
            this.lblFunction.Text = "Function:";
            this.lblFunction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkLineOfSight
            // 
            this.checkLineOfSight.AutoSize = true;
            this.checkLineOfSight.Location = new System.Drawing.Point(100, 116);
            this.checkLineOfSight.Name = "checkLineOfSight";
            this.checkLineOfSight.Size = new System.Drawing.Size(15, 14);
            this.checkLineOfSight.TabIndex = 0;
            this.checkLineOfSight.UseVisualStyleBackColor = true;
            // 
            // comboFunction
            // 
            this.comboFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFunction.FormattingEnabled = true;
            this.comboFunction.Items.AddRange(new object[] {
            "Prepare Food",
            "Cook Food",
            "Flat Surface",
            "Dispose",
            "Eat",
            "Pick Up From Slot",
            "Wash Dish",
            "Eating Surface",
            "Sit",
            "Stand",
            "Serving Surface",
            "Clean",
            "Garden",
            "Wash Hands",
            "Repair",
            "Restock",
            "{Wash Clothes}",
            "Message Handler",
            "Pre Route",
            "Post Route",
            "Goal Check",
            "Reaction Handler",
            "Along Route Callback",
            "Awareness",
            "Reset",
            "Loot At Target",
            "Utility State Change",
            "Global Awareness"});
            this.comboFunction.Location = new System.Drawing.Point(100, 4);
            this.comboFunction.Name = "comboFunction";
            this.comboFunction.Size = new System.Drawing.Size(150, 21);
            this.comboFunction.TabIndex = 0;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 135);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // panelObject
            // 
            this.panelObject.Controls.Add(this.lblObject);
            this.panelObject.Controls.Add(this.comboDataOwner1);
            this.panelObject.Controls.Add(this.textDataValue1);
            this.panelObject.Controls.Add(this.comboDataPicker1);
            this.panelObject.Location = new System.Drawing.Point(0, 58);
            this.panelObject.Name = "panelObject";
            this.panelObject.Size = new System.Drawing.Size(440, 23);
            this.panelObject.TabIndex = 1;
            // 
            // lblObject
            // 
            this.lblObject.Location = new System.Drawing.Point(5, 3);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(95, 13);
            this.lblObject.TabIndex = 23;
            this.lblObject.Text = "Object:";
            this.lblObject.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(100, 0);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner1.TabIndex = 1;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 0);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 3;
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
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 150);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 3;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(136, 150);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 2;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // checkIgnoreLockout
            // 
            this.checkIgnoreLockout.AutoSize = true;
            this.checkIgnoreLockout.Location = new System.Drawing.Point(100, 138);
            this.checkIgnoreLockout.Name = "checkIgnoreLockout";
            this.checkIgnoreLockout.Size = new System.Drawing.Size(15, 14);
            this.checkIgnoreLockout.TabIndex = 7;
            this.checkIgnoreLockout.UseVisualStyleBackColor = true;
            // 
            // lblIgnoreLockout
            // 
            this.lblIgnoreLockout.Location = new System.Drawing.Point(5, 138);
            this.lblIgnoreLockout.Name = "lblIgnoreLockout";
            this.lblIgnoreLockout.Size = new System.Drawing.Size(95, 13);
            this.lblIgnoreLockout.TabIndex = 16;
            this.lblIgnoreLockout.Text = "Ignoring Lockout:";
            this.lblIgnoreLockout.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 170);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelObject.ResumeLayout(false);
            this.panelObject.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.ComboBox comboFunction;
        private System.Windows.Forms.Label lblIgnoreLockout;
        private System.Windows.Forms.Label lblLineOfSight;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.CheckBox checkIgnoreLockout;
        private System.Windows.Forms.CheckBox checkLineOfSight;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelObject;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox comboLocation;
        private System.Windows.Forms.Label lblRelativeTo;
        private System.Windows.Forms.ComboBox comboRelativeTo;
    }
}
