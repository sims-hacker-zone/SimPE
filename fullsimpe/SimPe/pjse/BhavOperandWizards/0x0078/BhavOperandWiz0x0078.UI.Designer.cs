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

namespace whse.PrimitiveWizards.Wiz0x0078
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
            this.panelObjectSlot = new System.Windows.Forms.Panel();
            this.textObjectSlot = new System.Windows.Forms.TextBox();
            this.panelTargetSlot = new System.Windows.Forms.Panel();
            this.textTagetSlot = new System.Windows.Forms.TextBox();
            this.labelObjectSlot = new System.Windows.Forms.Label();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.comboObjectSlot = new System.Windows.Forms.ComboBox();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblObject = new System.Windows.Forms.Label();
            this.lblTargetSlot = new System.Windows.Forms.Label();
            this.comboTargetSlot = new System.Windows.Forms.ComboBox();
            this.lblWindows = new System.Windows.Forms.Label();
            this.checkWindows = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            this.panelObjectSlot.SuspendLayout();
            this.panelTargetSlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelObjectSlot);
            this.panelMain.Controls.Add(this.panelTargetSlot);
            this.panelMain.Controls.Add(this.labelObjectSlot);
            this.panelMain.Controls.Add(this.comboDataPicker1);
            this.panelMain.Controls.Add(this.comboObjectSlot);
            this.panelMain.Controls.Add(this.comboDataPicker2);
            this.panelMain.Controls.Add(this.textDataValue1);
            this.panelMain.Controls.Add(this.textDataValue2);
            this.panelMain.Controls.Add(this.comboDataOwner1);
            this.panelMain.Controls.Add(this.comboDataOwner2);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.lblTarget);
            this.panelMain.Controls.Add(this.lblObject);
            this.panelMain.Controls.Add(this.lblTargetSlot);
            this.panelMain.Controls.Add(this.comboTargetSlot);
            this.panelMain.Controls.Add(this.lblWindows);
            this.panelMain.Controls.Add(this.checkWindows);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 150);
            this.panelMain.TabIndex = 0;
            // 
            // panelObjectSlot
            // 
            this.panelObjectSlot.Controls.Add(this.textObjectSlot);
            this.panelObjectSlot.Location = new System.Drawing.Point(235, 31);
            this.panelObjectSlot.Name = "panelObjectSlot";
            this.panelObjectSlot.Size = new System.Drawing.Size(205, 21);
            this.panelObjectSlot.TabIndex = 53;
            // 
            // textObjectSlot
            // 
            this.textObjectSlot.Location = new System.Drawing.Point(0, 1);
            this.textObjectSlot.Name = "textObjectSlot";
            this.textObjectSlot.Size = new System.Drawing.Size(65, 20);
            this.textObjectSlot.TabIndex = 7;
            // 
            // panelTargetSlot
            // 
            this.panelTargetSlot.Controls.Add(this.textTagetSlot);
            this.panelTargetSlot.Location = new System.Drawing.Point(235, 85);
            this.panelTargetSlot.Name = "panelTargetSlot";
            this.panelTargetSlot.Size = new System.Drawing.Size(205, 21);
            this.panelTargetSlot.TabIndex = 50;
            // 
            // textTagetSlot
            // 
            this.textTagetSlot.Location = new System.Drawing.Point(0, 1);
            this.textTagetSlot.Name = "textTagetSlot";
            this.textTagetSlot.Size = new System.Drawing.Size(65, 20);
            this.textTagetSlot.TabIndex = 7;
            // 
            // labelObjectSlot
            // 
            this.labelObjectSlot.Location = new System.Drawing.Point(5, 34);
            this.labelObjectSlot.Name = "labelObjectSlot";
            this.labelObjectSlot.Size = new System.Drawing.Size(95, 13);
            this.labelObjectSlot.TabIndex = 51;
            this.labelObjectSlot.Text = "Object Point:";
            this.labelObjectSlot.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboDataPicker1
            // 
            this.comboDataPicker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker1.FormattingEnabled = true;
            this.comboDataPicker1.Location = new System.Drawing.Point(310, 4);
            this.comboDataPicker1.Name = "comboDataPicker1";
            this.comboDataPicker1.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker1.TabIndex = 1;
            // 
            // comboObjectSlot
            // 
            this.comboObjectSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboObjectSlot.FormattingEnabled = true;
            this.comboObjectSlot.Items.AddRange(new object[] {
            "3/4 Height",
            "Target Slot",
            "Route Slot",
            "Container Slot"});
            this.comboObjectSlot.Location = new System.Drawing.Point(105, 31);
            this.comboObjectSlot.Name = "comboObjectSlot";
            this.comboObjectSlot.Size = new System.Drawing.Size(120, 21);
            this.comboObjectSlot.TabIndex = 52;
            this.comboObjectSlot.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // comboDataPicker2
            // 
            this.comboDataPicker2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker2.FormattingEnabled = true;
            this.comboDataPicker2.Location = new System.Drawing.Point(310, 58);
            this.comboDataPicker2.Name = "comboDataPicker2";
            this.comboDataPicker2.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker2.TabIndex = 4;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 4);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 2;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 58);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 5;
            // 
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(105, 4);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(195, 21);
            this.comboDataOwner1.TabIndex = 0;
            // 
            // comboDataOwner2
            // 
            this.comboDataOwner2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner2.FormattingEnabled = true;
            this.comboDataOwner2.Location = new System.Drawing.Point(105, 58);
            this.comboDataOwner2.Name = "comboDataOwner2";
            this.comboDataOwner2.Size = new System.Drawing.Size(195, 21);
            this.comboDataOwner2.TabIndex = 3;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 116);
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
            this.checkDecimal.Location = new System.Drawing.Point(136, 130);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 10;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 130);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 11;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(5, 61);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(95, 13);
            this.lblTarget.TabIndex = 25;
            this.lblTarget.Text = "Target:";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblObject
            // 
            this.lblObject.Location = new System.Drawing.Point(5, 7);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(95, 13);
            this.lblObject.TabIndex = 23;
            this.lblObject.Text = "Object:";
            this.lblObject.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTargetSlot
            // 
            this.lblTargetSlot.Location = new System.Drawing.Point(5, 88);
            this.lblTargetSlot.Name = "lblTargetSlot";
            this.lblTargetSlot.Size = new System.Drawing.Size(95, 13);
            this.lblTargetSlot.TabIndex = 5;
            this.lblTargetSlot.Text = "Target Point:";
            this.lblTargetSlot.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboTargetSlot
            // 
            this.comboTargetSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTargetSlot.FormattingEnabled = true;
            this.comboTargetSlot.Items.AddRange(new object[] {
            "3/4 Height",
            "Target Slot",
            "Route Slot",
            "Container Slot"});
            this.comboTargetSlot.Location = new System.Drawing.Point(105, 85);
            this.comboTargetSlot.Name = "comboTargetSlot";
            this.comboTargetSlot.Size = new System.Drawing.Size(120, 21);
            this.comboTargetSlot.TabIndex = 6;
            this.comboTargetSlot.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblWindows
            // 
            this.lblWindows.Location = new System.Drawing.Point(5, 115);
            this.lblWindows.Name = "lblWindows";
            this.lblWindows.Size = new System.Drawing.Size(95, 13);
            this.lblWindows.TabIndex = 15;
            this.lblWindows.Text = "Ignore Windows:";
            this.lblWindows.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkWindows
            // 
            this.checkWindows.AutoSize = true;
            this.checkWindows.Location = new System.Drawing.Point(105, 115);
            this.checkWindows.Name = "checkWindows";
            this.checkWindows.Size = new System.Drawing.Size(15, 14);
            this.checkWindows.TabIndex = 8;
            this.checkWindows.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 150);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelObjectSlot.ResumeLayout(false);
            this.panelObjectSlot.PerformLayout();
            this.panelTargetSlot.ResumeLayout(false);
            this.panelTargetSlot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTargetSlot;
        private System.Windows.Forms.TextBox textTagetSlot;
        private System.Windows.Forms.ComboBox comboTargetSlot;
        private System.Windows.Forms.Label lblWindows;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.CheckBox checkWindows;
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
        private System.Windows.Forms.Panel panelTargetSlot;
        private System.Windows.Forms.Panel panelObjectSlot;
        private System.Windows.Forms.TextBox textObjectSlot;
        private System.Windows.Forms.Label labelObjectSlot;
        private System.Windows.Forms.ComboBox comboObjectSlot;
    }
}
