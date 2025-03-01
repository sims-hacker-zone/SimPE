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

namespace whse.PrimitiveWizards.Wiz0x000b
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
            this.labelStackObject = new System.Windows.Forms.Label();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.textIntoTemp = new System.Windows.Forms.TextBox();
            this.lblIntoTemp = new System.Windows.Forms.Label();
            this.comboTarget = new System.Windows.Forms.ComboBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblIn100ths = new System.Windows.Forms.Label();
            this.checkIn100ths = new System.Windows.Forms.CheckBox();
            this.panelDataOwner1 = new System.Windows.Forms.Panel();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelDataOwner1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labelStackObject);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.textIntoTemp);
            this.panelMain.Controls.Add(this.lblIntoTemp);
            this.panelMain.Controls.Add(this.comboTarget);
            this.panelMain.Controls.Add(this.lblTarget);
            this.panelMain.Controls.Add(this.lblDistance);
            this.panelMain.Controls.Add(this.lblIn100ths);
            this.panelMain.Controls.Add(this.checkIn100ths);
            this.panelMain.Controls.Add(this.panelDataOwner1);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 150);
            this.panelMain.TabIndex = 0;
            // 
            // labelStackObject
            // 
            this.labelStackObject.AutoSize = true;
            this.labelStackObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStackObject.Location = new System.Drawing.Point(97, 7);
            this.labelStackObject.Name = "labelStackObject";
            this.labelStackObject.Size = new System.Drawing.Size(122, 13);
            this.labelStackObject.TabIndex = 42;
            this.labelStackObject.Text = "Stack Object and ...";
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
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(136, 130);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 4;
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
            this.checkAttrPicker.TabIndex = 5;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // textIntoTemp
            // 
            this.textIntoTemp.Location = new System.Drawing.Point(100, 79);
            this.textIntoTemp.Name = "textIntoTemp";
            this.textIntoTemp.Size = new System.Drawing.Size(60, 20);
            this.textIntoTemp.TabIndex = 2;
            // 
            // lblIntoTemp
            // 
            this.lblIntoTemp.Location = new System.Drawing.Point(5, 82);
            this.lblIntoTemp.Name = "lblIntoTemp";
            this.lblIntoTemp.Size = new System.Drawing.Size(95, 13);
            this.lblIntoTemp.TabIndex = 5;
            this.lblIntoTemp.Text = "Into Temp:";
            this.lblIntoTemp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboTarget
            // 
            this.comboTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTarget.FormattingEnabled = true;
            this.comboTarget.Items.AddRange(new object[] {
            "Me",
            "Variable"});
            this.comboTarget.Location = new System.Drawing.Point(100, 25);
            this.comboTarget.Name = "comboTarget";
            this.comboTarget.Size = new System.Drawing.Size(87, 21);
            this.comboTarget.TabIndex = 0;
            this.comboTarget.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(5, 28);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(95, 13);
            this.lblTarget.TabIndex = 2;
            this.lblTarget.Text = "Target:";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDistance
            // 
            this.lblDistance.Location = new System.Drawing.Point(5, 7);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(95, 13);
            this.lblDistance.TabIndex = 1;
            this.lblDistance.Text = "Between:";
            this.lblDistance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIn100ths
            // 
            this.lblIn100ths.Location = new System.Drawing.Point(5, 105);
            this.lblIn100ths.Name = "lblIn100ths";
            this.lblIn100ths.Size = new System.Drawing.Size(95, 13);
            this.lblIn100ths.TabIndex = 15;
            this.lblIn100ths.Text = "In 1/100ths:";
            this.lblIn100ths.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkIn100ths
            // 
            this.checkIn100ths.AutoSize = true;
            this.checkIn100ths.Location = new System.Drawing.Point(100, 105);
            this.checkIn100ths.Name = "checkIn100ths";
            this.checkIn100ths.Size = new System.Drawing.Size(15, 14);
            this.checkIn100ths.TabIndex = 3;
            this.checkIn100ths.UseVisualStyleBackColor = true;
            // 
            // panelDataOwner1
            // 
            this.panelDataOwner1.Controls.Add(this.textDataValue1);
            this.panelDataOwner1.Controls.Add(this.comboDataPicker1);
            this.panelDataOwner1.Controls.Add(this.comboDataOwner1);
            this.panelDataOwner1.Location = new System.Drawing.Point(0, 52);
            this.panelDataOwner1.Name = "panelDataOwner1";
            this.panelDataOwner1.Size = new System.Drawing.Size(440, 21);
            this.panelDataOwner1.TabIndex = 1;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 0);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 1;
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
            // comboDataOwner1
            // 
            this.comboDataOwner1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner1.FormattingEnabled = true;
            this.comboDataOwner1.Location = new System.Drawing.Point(100, 0);
            this.comboDataOwner1.Name = "comboDataOwner1";
            this.comboDataOwner1.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner1.TabIndex = 0;
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
            this.panelDataOwner1.ResumeLayout(false);
            this.panelDataOwner1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox comboTarget;
        private System.Windows.Forms.Panel panelDataOwner1;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.Label lblIntoTemp;
        private System.Windows.Forms.TextBox textIntoTemp;
        private System.Windows.Forms.Label lblIn100ths;
        private System.Windows.Forms.CheckBox checkIn100ths;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelStackObject;
    }
}
