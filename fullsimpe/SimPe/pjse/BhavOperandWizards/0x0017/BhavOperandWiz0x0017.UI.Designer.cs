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

namespace whse.PrimitiveWizards.Wiz0x0017
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
            this.comboPlayStop = new System.Windows.Forms.ComboBox();
            this.lblPlayStop = new System.Windows.Forms.Label();
            this.textVolume = new System.Windows.Forms.TextBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.comboSource = new System.Windows.Forms.ComboBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.textSampleRate = new System.Windows.Forms.TextBox();
            this.lblSampleRate = new System.Windows.Forms.Label();
            this.lblAutoVary = new System.Windows.Forms.Label();
            this.lblSoundName = new System.Windows.Forms.Label();
            this.lblSound = new System.Windows.Forms.Label();
            this.btnSoundPicker = new System.Windows.Forms.Button();
            this.checkAutoVary = new System.Windows.Forms.CheckBox();
            this.comboSoundScope = new System.Windows.Forms.ComboBox();
            this.textSoundEntry = new System.Windows.Forms.TextBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.comboPlayStop);
            this.panelMain.Controls.Add(this.lblPlayStop);
            this.panelMain.Controls.Add(this.textVolume);
            this.panelMain.Controls.Add(this.lblVolume);
            this.panelMain.Controls.Add(this.comboSource);
            this.panelMain.Controls.Add(this.lblSource);
            this.panelMain.Controls.Add(this.textSampleRate);
            this.panelMain.Controls.Add(this.lblSampleRate);
            this.panelMain.Controls.Add(this.lblAutoVary);
            this.panelMain.Controls.Add(this.lblSoundName);
            this.panelMain.Controls.Add(this.lblSound);
            this.panelMain.Controls.Add(this.btnSoundPicker);
            this.panelMain.Controls.Add(this.checkAutoVary);
            this.panelMain.Controls.Add(this.comboSoundScope);
            this.panelMain.Controls.Add(this.textSoundEntry);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 190);
            this.panelMain.TabIndex = 0;
            // 
            // comboPlayStop
            // 
            this.comboPlayStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPlayStop.FormattingEnabled = true;
            this.comboPlayStop.Items.AddRange(new object[] {
            "Play",
            "Stop"});
            this.comboPlayStop.Location = new System.Drawing.Point(100, 4);
            this.comboPlayStop.Name = "comboPlayStop";
            this.comboPlayStop.Size = new System.Drawing.Size(90, 21);
            this.comboPlayStop.TabIndex = 53;
            // 
            // lblPlayStop
            // 
            this.lblPlayStop.Location = new System.Drawing.Point(5, 7);
            this.lblPlayStop.Name = "lblPlayStop";
            this.lblPlayStop.Size = new System.Drawing.Size(95, 13);
            this.lblPlayStop.TabIndex = 52;
            this.lblPlayStop.Text = "Action:";
            this.lblPlayStop.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textVolume
            // 
            this.textVolume.Location = new System.Drawing.Point(100, 134);
            this.textVolume.Name = "textVolume";
            this.textVolume.Size = new System.Drawing.Size(60, 20);
            this.textVolume.TabIndex = 51;
            // 
            // lblVolume
            // 
            this.lblVolume.Location = new System.Drawing.Point(5, 137);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(95, 13);
            this.lblVolume.TabIndex = 50;
            this.lblVolume.Text = "Volume:";
            this.lblVolume.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboSource
            // 
            this.comboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSource.FormattingEnabled = true;
            this.comboSource.Items.AddRange(new object[] {
            "Me",
            "Stack Object"});
            this.comboSource.Location = new System.Drawing.Point(100, 31);
            this.comboSource.Name = "comboSource";
            this.comboSource.Size = new System.Drawing.Size(90, 21);
            this.comboSource.TabIndex = 49;
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(5, 34);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(95, 13);
            this.lblSource.TabIndex = 48;
            this.lblSource.Text = "Source:";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textSampleRate
            // 
            this.textSampleRate.Location = new System.Drawing.Point(100, 108);
            this.textSampleRate.Name = "textSampleRate";
            this.textSampleRate.Size = new System.Drawing.Size(60, 20);
            this.textSampleRate.TabIndex = 47;
            // 
            // lblSampleRate
            // 
            this.lblSampleRate.Location = new System.Drawing.Point(5, 111);
            this.lblSampleRate.Name = "lblSampleRate";
            this.lblSampleRate.Size = new System.Drawing.Size(95, 13);
            this.lblSampleRate.TabIndex = 46;
            this.lblSampleRate.Text = "Sample Rate:";
            this.lblSampleRate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAutoVary
            // 
            this.lblAutoVary.Location = new System.Drawing.Point(5, 160);
            this.lblAutoVary.Name = "lblAutoVary";
            this.lblAutoVary.Size = new System.Drawing.Size(95, 13);
            this.lblAutoVary.TabIndex = 45;
            this.lblAutoVary.Text = "Auto Vary:";
            this.lblAutoVary.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSoundName
            // 
            this.lblSoundName.AutoSize = true;
            this.lblSoundName.Location = new System.Drawing.Point(131, 87);
            this.lblSoundName.Name = "lblSoundName";
            this.lblSoundName.Size = new System.Drawing.Size(35, 13);
            this.lblSoundName.TabIndex = 44;
            this.lblSoundName.Text = "label1";
            // 
            // lblSound
            // 
            this.lblSound.Location = new System.Drawing.Point(5, 62);
            this.lblSound.Name = "lblSound";
            this.lblSound.Size = new System.Drawing.Size(95, 13);
            this.lblSound.TabIndex = 9;
            this.lblSound.Text = "Sound:";
            this.lblSound.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSoundPicker
            // 
            this.btnSoundPicker.Location = new System.Drawing.Point(100, 83);
            this.btnSoundPicker.Margin = new System.Windows.Forms.Padding(1);
            this.btnSoundPicker.Name = "btnSoundPicker";
            this.btnSoundPicker.Size = new System.Drawing.Size(27, 21);
            this.btnSoundPicker.TabIndex = 4;
            this.btnSoundPicker.Text = ">>";
            this.btnSoundPicker.UseVisualStyleBackColor = true;
            this.btnSoundPicker.Click += new System.EventHandler(this.OnSoundPickerClicked);
            // 
            // checkAutoVary
            // 
            this.checkAutoVary.AutoSize = true;
            this.checkAutoVary.Location = new System.Drawing.Point(100, 160);
            this.checkAutoVary.Name = "checkAutoVary";
            this.checkAutoVary.Size = new System.Drawing.Size(15, 14);
            this.checkAutoVary.TabIndex = 5;
            this.checkAutoVary.UseVisualStyleBackColor = true;
            this.checkAutoVary.CheckedChanged += new System.EventHandler(this.OnParametersClicked);
            // 
            // comboSoundScope
            // 
            this.comboSoundScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSoundScope.FormattingEnabled = true;
            this.comboSoundScope.Items.AddRange(new object[] {
            "Private",
            "Semi-Global",
            "Global"});
            this.comboSoundScope.Location = new System.Drawing.Point(100, 58);
            this.comboSoundScope.Name = "comboSoundScope";
            this.comboSoundScope.Size = new System.Drawing.Size(90, 21);
            this.comboSoundScope.TabIndex = 1;
            this.comboSoundScope.SelectedIndexChanged += new System.EventHandler(this.OnSoundControlChanged);
            // 
            // textSoundEntry
            // 
            this.textSoundEntry.Location = new System.Drawing.Point(196, 58);
            this.textSoundEntry.Name = "textSoundEntry";
            this.textSoundEntry.Size = new System.Drawing.Size(60, 20);
            this.textSoundEntry.TabIndex = 2;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 155);
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
            this.checkDecimal.Location = new System.Drawing.Point(259, 170);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 7;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 190);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox comboSoundScope;
        private System.Windows.Forms.TextBox textSoundEntry;
        private System.Windows.Forms.Button btnSoundPicker;
        private System.Windows.Forms.Label lblSound;
        private System.Windows.Forms.CheckBox checkAutoVary;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblSoundName;
        private System.Windows.Forms.Label lblAutoVary;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.TextBox textSampleRate;
        private System.Windows.Forms.Label lblSampleRate;
        private System.Windows.Forms.TextBox textVolume;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.ComboBox comboSource;
        private System.Windows.Forms.ComboBox comboPlayStop;
        private System.Windows.Forms.Label lblPlayStop;
    }
}
