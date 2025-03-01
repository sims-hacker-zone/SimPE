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

namespace whse.PrimitiveWizards.Wiz0x000c
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
            this.lblInto = new System.Windows.Forms.Label();
            this.lblToSO = new System.Windows.Forms.Label();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.comboFrom = new System.Windows.Forms.ComboBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.lblVariable = new System.Windows.Forms.Label();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkDegrees = new System.Windows.Forms.CheckBox();
            this.lblDegrees = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblInto);
            this.panelMain.Controls.Add(this.lblToSO);
            this.panelMain.Controls.Add(this.comboDataPicker2);
            this.panelMain.Controls.Add(this.textDataValue2);
            this.panelMain.Controls.Add(this.lblFrom);
            this.panelMain.Controls.Add(this.comboFrom);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.panelVariable);
            this.panelMain.Controls.Add(this.comboDataOwner2);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkDegrees);
            this.panelMain.Controls.Add(this.lblDegrees);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 125);
            this.panelMain.TabIndex = 0;
            // 
            // lblInto
            // 
            this.lblInto.Location = new System.Drawing.Point(5, 61);
            this.lblInto.Name = "lblInto";
            this.lblInto.Size = new System.Drawing.Size(95, 13);
            this.lblInto.TabIndex = 25;
            this.lblInto.Text = "Into:";
            this.lblInto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblToSO
            // 
            this.lblToSO.AutoSize = true;
            this.lblToSO.Location = new System.Drawing.Point(226, 7);
            this.lblToSO.Name = "lblToSO";
            this.lblToSO.Size = new System.Drawing.Size(81, 13);
            this.lblToSO.TabIndex = 38;
            this.lblToSO.Text = "to Stack Object";
            this.lblToSO.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboDataPicker2
            // 
            this.comboDataPicker2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker2.FormattingEnabled = true;
            this.comboDataPicker2.Location = new System.Drawing.Point(310, 58);
            this.comboDataPicker2.Name = "comboDataPicker2";
            this.comboDataPicker2.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker2.TabIndex = 3;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 58);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 35;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(5, 7);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(95, 13);
            this.lblFrom.TabIndex = 15;
            this.lblFrom.Text = "From:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboFrom
            // 
            this.comboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFrom.FormattingEnabled = true;
            this.comboFrom.Items.AddRange(new object[] {
            "Me",
            "Variable"});
            this.comboFrom.Location = new System.Drawing.Point(100, 4);
            this.comboFrom.Name = "comboFrom";
            this.comboFrom.Size = new System.Drawing.Size(120, 21);
            this.comboFrom.TabIndex = 0;
            this.comboFrom.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 90);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // panelVariable
            // 
            this.panelVariable.Controls.Add(this.lblVariable);
            this.panelVariable.Controls.Add(this.comboDataPicker1);
            this.panelVariable.Controls.Add(this.textDataValue1);
            this.panelVariable.Controls.Add(this.comboDataOwner1);
            this.panelVariable.Location = new System.Drawing.Point(0, 31);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(440, 21);
            this.panelVariable.TabIndex = 1;
            // 
            // lblVariable
            // 
            this.lblVariable.Location = new System.Drawing.Point(5, 3);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(95, 13);
            this.lblVariable.TabIndex = 23;
            this.lblVariable.Text = "Variable:";
            this.lblVariable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboDataPicker1
            // 
            this.comboDataPicker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker1.FormattingEnabled = true;
            this.comboDataPicker1.Location = new System.Drawing.Point(310, 0);
            this.comboDataPicker1.Name = "comboDataPicker1";
            this.comboDataPicker1.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker1.TabIndex = 1;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 0);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 2;
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
            this.comboDataOwner2.Location = new System.Drawing.Point(100, 58);
            this.comboDataOwner2.Name = "comboDataOwner2";
            this.comboDataOwner2.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner2.TabIndex = 2;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 105);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 6;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(136, 105);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 5;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // checkDegrees
            // 
            this.checkDegrees.AutoSize = true;
            this.checkDegrees.Location = new System.Drawing.Point(100, 87);
            this.checkDegrees.Name = "checkDegrees";
            this.checkDegrees.Size = new System.Drawing.Size(15, 14);
            this.checkDegrees.TabIndex = 4;
            this.checkDegrees.UseVisualStyleBackColor = true;
            // 
            // lblDegrees
            // 
            this.lblDegrees.Location = new System.Drawing.Point(5, 87);
            this.lblDegrees.Name = "lblDegrees";
            this.lblDegrees.Size = new System.Drawing.Size(95, 13);
            this.lblDegrees.TabIndex = 16;
            this.lblDegrees.Text = "Degrees:";
            this.lblDegrees.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 125);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox comboFrom;
        private System.Windows.Forms.Label lblDegrees;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblInto;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.CheckBox checkDegrees;
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
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.Label lblToSO;
    }
}
