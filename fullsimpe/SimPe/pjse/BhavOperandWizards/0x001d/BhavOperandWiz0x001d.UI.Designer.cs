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

namespace whse.PrimitiveWizards.Wiz0x001d
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
            this.lblClearAll = new System.Windows.Forms.Label();
            this.checkClearAll = new System.Windows.Forms.CheckBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.panelMotive = new System.Windows.Forms.Panel();
            this.lblMotiveMax = new System.Windows.Forms.Label();
            this.lblMotiveDelta = new System.Windows.Forms.Label();
            this.lblMotive = new System.Windows.Forms.Label();
            this.comboMotive = new System.Windows.Forms.ComboBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.lblAutoClearing = new System.Windows.Forms.Label();
            this.checkAutoClearing = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelMotive.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblClearAll);
            this.panelMain.Controls.Add(this.checkClearAll);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.panelMotive);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 150);
            this.panelMain.TabIndex = 0;
            // 
            // lblClearAll
            // 
            this.lblClearAll.Location = new System.Drawing.Point(5, 7);
            this.lblClearAll.Name = "lblClearAll";
            this.lblClearAll.Size = new System.Drawing.Size(95, 13);
            this.lblClearAll.TabIndex = 15;
            this.lblClearAll.Text = "Clear All:";
            this.lblClearAll.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkClearAll
            // 
            this.checkClearAll.AutoSize = true;
            this.checkClearAll.Location = new System.Drawing.Point(100, 7);
            this.checkClearAll.Name = "checkClearAll";
            this.checkClearAll.Size = new System.Drawing.Size(15, 14);
            this.checkClearAll.TabIndex = 0;
            this.checkClearAll.UseVisualStyleBackColor = true;
            this.checkClearAll.CheckedChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 115);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // panelMotive
            // 
            this.panelMotive.Controls.Add(this.lblMotiveMax);
            this.panelMotive.Controls.Add(this.lblMotiveDelta);
            this.panelMotive.Controls.Add(this.lblMotive);
            this.panelMotive.Controls.Add(this.comboMotive);
            this.panelMotive.Controls.Add(this.comboDataPicker1);
            this.panelMotive.Controls.Add(this.comboDataPicker2);
            this.panelMotive.Controls.Add(this.textDataValue1);
            this.panelMotive.Controls.Add(this.textDataValue2);
            this.panelMotive.Controls.Add(this.comboDataOwner1);
            this.panelMotive.Controls.Add(this.comboDataOwner2);
            this.panelMotive.Controls.Add(this.lblAutoClearing);
            this.panelMotive.Controls.Add(this.checkAutoClearing);
            this.panelMotive.Location = new System.Drawing.Point(0, 25);
            this.panelMotive.Name = "panelMotive";
            this.panelMotive.Size = new System.Drawing.Size(440, 100);
            this.panelMotive.TabIndex = 1;
            // 
            // lblMotiveMax
            // 
            this.lblMotiveMax.Location = new System.Drawing.Point(5, 57);
            this.lblMotiveMax.Name = "lblMotiveMax";
            this.lblMotiveMax.Size = new System.Drawing.Size(95, 13);
            this.lblMotiveMax.TabIndex = 25;
            this.lblMotiveMax.Text = "Max:";
            this.lblMotiveMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMotiveDelta
            // 
            this.lblMotiveDelta.Location = new System.Drawing.Point(5, 30);
            this.lblMotiveDelta.Name = "lblMotiveDelta";
            this.lblMotiveDelta.Size = new System.Drawing.Size(95, 13);
            this.lblMotiveDelta.TabIndex = 23;
            this.lblMotiveDelta.Text = "Delta:";
            this.lblMotiveDelta.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMotive
            // 
            this.lblMotive.Location = new System.Drawing.Point(5, 3);
            this.lblMotive.Name = "lblMotive";
            this.lblMotive.Size = new System.Drawing.Size(95, 13);
            this.lblMotive.TabIndex = 5;
            this.lblMotive.Text = "Motive:";
            this.lblMotive.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboMotive
            // 
            this.comboMotive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMotive.FormattingEnabled = true;
            this.comboMotive.Items.AddRange(new object[] {
            "{shopping}",
            "Scratch/Chew",
            "{unused2}",
            "Mood",
            "{Mood+Mem}",
            "Energy",
            "Comfort",
            "Hunger",
            "Hygiene/Water",
            "Bladder",
            "{unusedA}",
            "{sleep state}",
            "{unusedC}",
            "Environment",
            "Social",
            "Fun"});
            this.comboMotive.Location = new System.Drawing.Point(100, 0);
            this.comboMotive.Name = "comboMotive";
            this.comboMotive.Size = new System.Drawing.Size(120, 21);
            this.comboMotive.TabIndex = 0;
            // 
            // comboDataPicker1
            // 
            this.comboDataPicker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker1.FormattingEnabled = true;
            this.comboDataPicker1.Location = new System.Drawing.Point(310, 27);
            this.comboDataPicker1.Name = "comboDataPicker1";
            this.comboDataPicker1.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker1.TabIndex = 2;
            // 
            // comboDataPicker2
            // 
            this.comboDataPicker2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker2.FormattingEnabled = true;
            this.comboDataPicker2.Location = new System.Drawing.Point(310, 54);
            this.comboDataPicker2.Name = "comboDataPicker2";
            this.comboDataPicker2.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker2.TabIndex = 5;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 27);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 3;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 54);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 6;
            // 
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(100, 27);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner1.TabIndex = 1;
            // 
            // comboDataOwner2
            // 
            this.comboDataOwner2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner2.FormattingEnabled = true;
            this.comboDataOwner2.Location = new System.Drawing.Point(100, 54);
            this.comboDataOwner2.Name = "comboDataOwner2";
            this.comboDataOwner2.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner2.TabIndex = 4;
            // 
            // lblAutoClearing
            // 
            this.lblAutoClearing.Location = new System.Drawing.Point(5, 81);
            this.lblAutoClearing.Name = "lblAutoClearing";
            this.lblAutoClearing.Size = new System.Drawing.Size(95, 13);
            this.lblAutoClearing.TabIndex = 16;
            this.lblAutoClearing.Text = "Auto Clearing:";
            this.lblAutoClearing.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblAutoClearing, "Auto Clearing the Person Data Motive Decay");
            // 
            // checkAutoClearing
            // 
            this.checkAutoClearing.AutoSize = true;
            this.checkAutoClearing.Location = new System.Drawing.Point(100, 81);
            this.checkAutoClearing.Name = "checkAutoClearing";
            this.checkAutoClearing.Size = new System.Drawing.Size(15, 14);
            this.checkAutoClearing.TabIndex = 7;
            this.toolTip.SetToolTip(this.checkAutoClearing, "Auto Clearing the Person Data Motive Decay");
            this.checkAutoClearing.UseVisualStyleBackColor = true;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 130);
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
            this.checkDecimal.Location = new System.Drawing.Point(136, 130);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 2;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelMotive.ResumeLayout(false);
            this.panelMotive.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblMotive;
        private System.Windows.Forms.ComboBox comboMotive;
        private System.Windows.Forms.Label lblAutoClearing;
        private System.Windows.Forms.Label lblClearAll;
        private System.Windows.Forms.Label lblMotiveMax;
        private System.Windows.Forms.Label lblMotiveDelta;
        private System.Windows.Forms.CheckBox checkAutoClearing;
        private System.Windows.Forms.CheckBox checkClearAll;
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
        private System.Windows.Forms.Panel panelMotive;
    }
}
