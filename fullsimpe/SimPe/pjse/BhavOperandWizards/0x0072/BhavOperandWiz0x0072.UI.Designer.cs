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

namespace whse.PrimitiveWizards.Wiz0x0072
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
            this.comboAction = new System.Windows.Forms.ComboBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.panelLocoAnim = new System.Windows.Forms.Panel();
            this.comboLocoAnimScope = new System.Windows.Forms.ComboBox();
            this.textLocoAnimEntry = new System.Windows.Forms.TextBox();
            this.btnLocoAnimPicker = new System.Windows.Forms.Button();
            this.lblLocoAnimName = new System.Windows.Forms.Label();
            this.lblLocoAnim = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelLocoAnim.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.comboAction);
            this.panelMain.Controls.Add(this.lblAction);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.panelLocoAnim);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 115);
            this.panelMain.TabIndex = 0;
            // 
            // comboAction
            // 
            this.comboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAction.FormattingEnabled = true;
            this.comboAction.Items.AddRange(new object[] {
            "Pop All",
            "Pop",
            "Push"});
            this.comboAction.Location = new System.Drawing.Point(100, 4);
            this.comboAction.Name = "comboAction";
            this.comboAction.Size = new System.Drawing.Size(90, 21);
            this.comboAction.TabIndex = 53;
            this.comboAction.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblAction
            // 
            this.lblAction.Location = new System.Drawing.Point(5, 7);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(95, 13);
            this.lblAction.TabIndex = 52;
            this.lblAction.Text = "Action:";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 80);
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
            this.checkDecimal.Location = new System.Drawing.Point(259, 95);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 7;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // panelLocoAnim
            // 
            this.panelLocoAnim.Controls.Add(this.comboLocoAnimScope);
            this.panelLocoAnim.Controls.Add(this.textLocoAnimEntry);
            this.panelLocoAnim.Controls.Add(this.btnLocoAnimPicker);
            this.panelLocoAnim.Controls.Add(this.lblLocoAnimName);
            this.panelLocoAnim.Controls.Add(this.lblLocoAnim);
            this.panelLocoAnim.Location = new System.Drawing.Point(0, 31);
            this.panelLocoAnim.Name = "panelLocoAnim";
            this.panelLocoAnim.Size = new System.Drawing.Size(440, 49);
            this.panelLocoAnim.TabIndex = 54;
            // 
            // comboLocoAnimScope
            // 
            this.comboLocoAnimScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLocoAnimScope.FormattingEnabled = true;
            this.comboLocoAnimScope.Items.AddRange(new object[] {
            "Private",
            "Semi-Global",
            "Global"});
            this.comboLocoAnimScope.Location = new System.Drawing.Point(100, 0);
            this.comboLocoAnimScope.Name = "comboLocoAnimScope";
            this.comboLocoAnimScope.Size = new System.Drawing.Size(90, 21);
            this.comboLocoAnimScope.TabIndex = 1;
            this.comboLocoAnimScope.SelectedIndexChanged += new System.EventHandler(this.OnLocoAnimControlChanged);
            // 
            // textLocoAnimEntry
            // 
            this.textLocoAnimEntry.Location = new System.Drawing.Point(196, 0);
            this.textLocoAnimEntry.Name = "textLocoAnimEntry";
            this.textLocoAnimEntry.Size = new System.Drawing.Size(60, 20);
            this.textLocoAnimEntry.TabIndex = 2;
            // 
            // btnLocoAnimPicker
            // 
            this.btnLocoAnimPicker.Location = new System.Drawing.Point(100, 25);
            this.btnLocoAnimPicker.Margin = new System.Windows.Forms.Padding(1);
            this.btnLocoAnimPicker.Name = "btnLocoAnimPicker";
            this.btnLocoAnimPicker.Size = new System.Drawing.Size(27, 21);
            this.btnLocoAnimPicker.TabIndex = 4;
            this.btnLocoAnimPicker.Text = ">>";
            this.btnLocoAnimPicker.UseVisualStyleBackColor = true;
            this.btnLocoAnimPicker.Click += new System.EventHandler(this.OnLocoAnimPickerClicked);
            // 
            // lblLocoAnimName
            // 
            this.lblLocoAnimName.AutoSize = true;
            this.lblLocoAnimName.Location = new System.Drawing.Point(131, 29);
            this.lblLocoAnimName.Name = "lblLocoAnimName";
            this.lblLocoAnimName.Size = new System.Drawing.Size(35, 13);
            this.lblLocoAnimName.TabIndex = 44;
            this.lblLocoAnimName.Text = "label1";
            // 
            // lblLocoAnim
            // 
            this.lblLocoAnim.Location = new System.Drawing.Point(5, 4);
            this.lblLocoAnim.Name = "lblLocoAnim";
            this.lblLocoAnim.Size = new System.Drawing.Size(95, 13);
            this.lblLocoAnim.TabIndex = 9;
            this.lblLocoAnim.Text = "Animation:";
            this.lblLocoAnim.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 115);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelLocoAnim.ResumeLayout(false);
            this.panelLocoAnim.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox comboLocoAnimScope;
        private System.Windows.Forms.TextBox textLocoAnimEntry;
        private System.Windows.Forms.Button btnLocoAnimPicker;
        private System.Windows.Forms.Label lblLocoAnim;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblLocoAnimName;
        private System.Windows.Forms.ComboBox comboAction;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Panel panelLocoAnim;
    }
}
