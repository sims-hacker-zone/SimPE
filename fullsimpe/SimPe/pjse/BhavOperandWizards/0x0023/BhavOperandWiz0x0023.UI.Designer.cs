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

namespace whse.PrimitiveWizards.Wiz0x0023
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
            this.lblSlowDown = new System.Windows.Forms.Label();
            this.checkSlowDown = new System.Windows.Forms.CheckBox();
            this.lblCentre = new System.Windows.Forms.Label();
            this.lblVisible = new System.Windows.Forms.Label();
            this.comboZoom = new System.Windows.Forms.ComboBox();
            this.textTimeout = new System.Windows.Forms.TextBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkCentre = new System.Windows.Forms.CheckBox();
            this.checkVisible = new System.Windows.Forms.CheckBox();
            this.comboTimeout = new System.Windows.Forms.ComboBox();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.lblZoom = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblSlowDown);
            this.panelMain.Controls.Add(this.checkSlowDown);
            this.panelMain.Controls.Add(this.lblCentre);
            this.panelMain.Controls.Add(this.lblVisible);
            this.panelMain.Controls.Add(this.comboZoom);
            this.panelMain.Controls.Add(this.textTimeout);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkCentre);
            this.panelMain.Controls.Add(this.checkVisible);
            this.panelMain.Controls.Add(this.comboTimeout);
            this.panelMain.Controls.Add(this.lblTimeout);
            this.panelMain.Controls.Add(this.lblZoom);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(350, 130);
            this.panelMain.TabIndex = 0;
            // 
            // lblSlowDown
            // 
            this.lblSlowDown.Location = new System.Drawing.Point(5, 100);
            this.lblSlowDown.Name = "lblSlowDown";
            this.lblSlowDown.Size = new System.Drawing.Size(95, 13);
            this.lblSlowDown.TabIndex = 39;
            this.lblSlowDown.Text = "Slow Down:";
            this.lblSlowDown.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkSlowDown
            // 
            this.checkSlowDown.AutoSize = true;
            this.checkSlowDown.Location = new System.Drawing.Point(100, 100);
            this.checkSlowDown.Name = "checkSlowDown";
            this.checkSlowDown.Size = new System.Drawing.Size(15, 14);
            this.checkSlowDown.TabIndex = 38;
            this.checkSlowDown.UseVisualStyleBackColor = true;
            // 
            // lblCentre
            // 
            this.lblCentre.Location = new System.Drawing.Point(5, 80);
            this.lblCentre.Name = "lblCentre";
            this.lblCentre.Size = new System.Drawing.Size(95, 13);
            this.lblCentre.TabIndex = 37;
            this.lblCentre.Text = "Centre:";
            this.lblCentre.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVisible
            // 
            this.lblVisible.Location = new System.Drawing.Point(5, 60);
            this.lblVisible.Name = "lblVisible";
            this.lblVisible.Size = new System.Drawing.Size(95, 13);
            this.lblVisible.TabIndex = 36;
            this.lblVisible.Text = "Visible:";
            this.lblVisible.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboZoom
            // 
            this.comboZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboZoom.FormattingEnabled = true;
            this.comboZoom.Items.AddRange(new object[] {
            "Far",
            "Mid",
            "Near"});
            this.comboZoom.Location = new System.Drawing.Point(100, 4);
            this.comboZoom.Name = "comboZoom";
            this.comboZoom.Size = new System.Drawing.Size(100, 21);
            this.comboZoom.TabIndex = 0;
            // 
            // textTimeout
            // 
            this.textTimeout.Location = new System.Drawing.Point(210, 30);
            this.textTimeout.Name = "textTimeout";
            this.textTimeout.Size = new System.Drawing.Size(70, 20);
            this.textTimeout.TabIndex = 2;
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(169, 110);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 5;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(315, 95);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 16;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // checkCentre
            // 
            this.checkCentre.AutoSize = true;
            this.checkCentre.Location = new System.Drawing.Point(100, 80);
            this.checkCentre.Name = "checkCentre";
            this.checkCentre.Size = new System.Drawing.Size(15, 14);
            this.checkCentre.TabIndex = 4;
            this.checkCentre.UseVisualStyleBackColor = true;
            // 
            // checkVisible
            // 
            this.checkVisible.AutoSize = true;
            this.checkVisible.Location = new System.Drawing.Point(100, 60);
            this.checkVisible.Name = "checkVisible";
            this.checkVisible.Size = new System.Drawing.Size(15, 14);
            this.checkVisible.TabIndex = 3;
            this.checkVisible.UseVisualStyleBackColor = true;
            // 
            // comboTimeout
            // 
            this.comboTimeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTimeout.FormattingEnabled = true;
            this.comboTimeout.Items.AddRange(new object[] {
            "Literal",
            "Temp 0"});
            this.comboTimeout.Location = new System.Drawing.Point(100, 31);
            this.comboTimeout.Name = "comboTimeout";
            this.comboTimeout.Size = new System.Drawing.Size(100, 21);
            this.comboTimeout.TabIndex = 1;
            this.comboTimeout.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblTimeout
            // 
            this.lblTimeout.Location = new System.Drawing.Point(5, 37);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(95, 13);
            this.lblTimeout.TabIndex = 3;
            this.lblTimeout.Text = "Time Out:";
            this.lblTimeout.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblZoom
            // 
            this.lblZoom.Location = new System.Drawing.Point(5, 7);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(95, 13);
            this.lblZoom.TabIndex = 0;
            this.lblZoom.Text = "Zoom:";
            this.lblZoom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(350, 130);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.ComboBox comboTimeout;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.CheckBox checkVisible;
        private System.Windows.Forms.CheckBox checkCentre;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.TextBox textTimeout;
        private System.Windows.Forms.ComboBox comboZoom;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblCentre;
        private System.Windows.Forms.Label lblVisible;
        private System.Windows.Forms.Label lblSlowDown;
        private System.Windows.Forms.CheckBox checkSlowDown;
    }
}
