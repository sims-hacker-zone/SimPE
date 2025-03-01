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

namespace whse.PrimitiveWizards.Wiz0x007a
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
            this.panelStartModify = new System.Windows.Forms.Panel();
            this.panelTickCount = new System.Windows.Forms.Panel();
            this.textTickCount = new System.Windows.Forms.TextBox();
            this.comboTickCount = new System.Windows.Forms.ComboBox();
            this.lblReset = new System.Windows.Forms.Label();
            this.checkReset = new System.Windows.Forms.CheckBox();
            this.lblLooping = new System.Windows.Forms.Label();
            this.lblTickCount = new System.Windows.Forms.Label();
            this.checkLooping = new System.Windows.Forms.CheckBox();
            this.comboEventTreeScope = new System.Windows.Forms.ComboBox();
            this.lblEventTree = new System.Windows.Forms.Label();
            this.textEventTree = new System.Windows.Forms.TextBox();
            this.lblParameters = new System.Windows.Forms.Label();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.lblParam1 = new System.Windows.Forms.Label();
            this.lblParam2 = new System.Windows.Forms.Label();
            this.lblParam3 = new System.Windows.Forms.Label();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.textDataValue3 = new System.Windows.Forms.TextBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.comboDataPicker3 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner3 = new System.Windows.Forms.ComboBox();
            this.btnEventTreePicker = new System.Windows.Forms.Button();
            this.lblEventTreeName = new System.Windows.Forms.Label();
            this.comboParamType = new System.Windows.Forms.ComboBox();
            this.comboAction = new System.Windows.Forms.ComboBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            this.panelStartModify.SuspendLayout();
            this.panelTickCount.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelStartModify);
            this.panelMain.Controls.Add(this.comboAction);
            this.panelMain.Controls.Add(this.lblAction);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 290);
            this.panelMain.TabIndex = 0;
            // 
            // panelStartModify
            // 
            this.panelStartModify.Controls.Add(this.panelTickCount);
            this.panelStartModify.Controls.Add(this.comboTickCount);
            this.panelStartModify.Controls.Add(this.lblReset);
            this.panelStartModify.Controls.Add(this.checkReset);
            this.panelStartModify.Controls.Add(this.lblLooping);
            this.panelStartModify.Controls.Add(this.lblTickCount);
            this.panelStartModify.Controls.Add(this.checkLooping);
            this.panelStartModify.Controls.Add(this.comboEventTreeScope);
            this.panelStartModify.Controls.Add(this.lblEventTree);
            this.panelStartModify.Controls.Add(this.textEventTree);
            this.panelStartModify.Controls.Add(this.lblParameters);
            this.panelStartModify.Controls.Add(this.panelParameters);
            this.panelStartModify.Controls.Add(this.btnEventTreePicker);
            this.panelStartModify.Controls.Add(this.lblEventTreeName);
            this.panelStartModify.Controls.Add(this.comboParamType);
            this.panelStartModify.Location = new System.Drawing.Point(0, 30);
            this.panelStartModify.Name = "panelStartModify";
            this.panelStartModify.Size = new System.Drawing.Size(440, 223);
            this.panelStartModify.TabIndex = 1;
            // 
            // panelTickCount
            // 
            this.panelTickCount.Controls.Add(this.textTickCount);
            this.panelTickCount.Location = new System.Drawing.Point(196, 0);
            this.panelTickCount.Name = "panelTickCount";
            this.panelTickCount.Size = new System.Drawing.Size(240, 21);
            this.panelTickCount.TabIndex = 52;
            // 
            // textTickCount
            // 
            this.textTickCount.Location = new System.Drawing.Point(0, 0);
            this.textTickCount.Name = "textTickCount";
            this.textTickCount.Size = new System.Drawing.Size(60, 20);
            this.textTickCount.TabIndex = 1;
            // 
            // comboTickCount
            // 
            this.comboTickCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTickCount.FormattingEnabled = true;
            this.comboTickCount.Items.AddRange(new object[] {
            "Literal",
            "Temp 1"});
            this.comboTickCount.Location = new System.Drawing.Point(100, 0);
            this.comboTickCount.Name = "comboTickCount";
            this.comboTickCount.Size = new System.Drawing.Size(90, 21);
            this.comboTickCount.TabIndex = 0;
            this.comboTickCount.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblReset
            // 
            this.lblReset.Location = new System.Drawing.Point(5, 99);
            this.lblReset.Name = "lblReset";
            this.lblReset.Size = new System.Drawing.Size(95, 13);
            this.lblReset.TabIndex = 51;
            this.lblReset.Text = "Reset:";
            this.lblReset.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkReset
            // 
            this.checkReset.AutoSize = true;
            this.checkReset.Location = new System.Drawing.Point(100, 99);
            this.checkReset.Name = "checkReset";
            this.checkReset.Size = new System.Drawing.Size(15, 14);
            this.checkReset.TabIndex = 6;
            this.checkReset.UseVisualStyleBackColor = true;
            // 
            // lblLooping
            // 
            this.lblLooping.Location = new System.Drawing.Point(5, 79);
            this.lblLooping.Name = "lblLooping";
            this.lblLooping.Size = new System.Drawing.Size(95, 13);
            this.lblLooping.TabIndex = 49;
            this.lblLooping.Text = "Looping:";
            this.lblLooping.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTickCount
            // 
            this.lblTickCount.Location = new System.Drawing.Point(5, 3);
            this.lblTickCount.Name = "lblTickCount";
            this.lblTickCount.Size = new System.Drawing.Size(95, 13);
            this.lblTickCount.TabIndex = 48;
            this.lblTickCount.Text = "Tick Count:";
            this.lblTickCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkLooping
            // 
            this.checkLooping.AutoSize = true;
            this.checkLooping.Location = new System.Drawing.Point(100, 79);
            this.checkLooping.Name = "checkLooping";
            this.checkLooping.Size = new System.Drawing.Size(15, 14);
            this.checkLooping.TabIndex = 5;
            this.checkLooping.UseVisualStyleBackColor = true;
            // 
            // comboEventTreeScope
            // 
            this.comboEventTreeScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEventTreeScope.FormattingEnabled = true;
            this.comboEventTreeScope.Items.AddRange(new object[] {
            "Private",
            "Semi-Global",
            "Global"});
            this.comboEventTreeScope.Location = new System.Drawing.Point(100, 27);
            this.comboEventTreeScope.Name = "comboEventTreeScope";
            this.comboEventTreeScope.Size = new System.Drawing.Size(90, 21);
            this.comboEventTreeScope.TabIndex = 2;
            this.comboEventTreeScope.SelectedIndexChanged += new System.EventHandler(this.OnEventTreeControlChanged);
            // 
            // lblEventTree
            // 
            this.lblEventTree.Location = new System.Drawing.Point(5, 31);
            this.lblEventTree.Name = "lblEventTree";
            this.lblEventTree.Size = new System.Drawing.Size(95, 13);
            this.lblEventTree.TabIndex = 46;
            this.lblEventTree.Text = "Event Tree:";
            this.lblEventTree.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textEventTree
            // 
            this.textEventTree.Location = new System.Drawing.Point(196, 28);
            this.textEventTree.Name = "textEventTree";
            this.textEventTree.Size = new System.Drawing.Size(60, 20);
            this.textEventTree.TabIndex = 3;
            // 
            // lblParameters
            // 
            this.lblParameters.Location = new System.Drawing.Point(5, 122);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(95, 13);
            this.lblParameters.TabIndex = 45;
            this.lblParameters.Text = "Parameters:";
            this.lblParameters.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelParameters
            // 
            this.panelParameters.Controls.Add(this.lblParam1);
            this.panelParameters.Controls.Add(this.lblParam2);
            this.panelParameters.Controls.Add(this.lblParam3);
            this.panelParameters.Controls.Add(this.textDataValue1);
            this.panelParameters.Controls.Add(this.textDataValue2);
            this.panelParameters.Controls.Add(this.textDataValue3);
            this.panelParameters.Controls.Add(this.comboDataPicker1);
            this.panelParameters.Controls.Add(this.comboDataPicker2);
            this.panelParameters.Controls.Add(this.comboDataPicker3);
            this.panelParameters.Controls.Add(this.comboDataOwner1);
            this.panelParameters.Controls.Add(this.comboDataOwner2);
            this.panelParameters.Controls.Add(this.comboDataOwner3);
            this.panelParameters.Location = new System.Drawing.Point(0, 146);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(440, 76);
            this.panelParameters.TabIndex = 8;
            // 
            // lblParam1
            // 
            this.lblParam1.Location = new System.Drawing.Point(5, 3);
            this.lblParam1.Name = "lblParam1";
            this.lblParam1.Size = new System.Drawing.Size(95, 13);
            this.lblParam1.TabIndex = 0;
            this.lblParam1.Text = "Param 0:";
            this.lblParam1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblParam2
            // 
            this.lblParam2.Location = new System.Drawing.Point(5, 30);
            this.lblParam2.Name = "lblParam2";
            this.lblParam2.Size = new System.Drawing.Size(95, 13);
            this.lblParam2.TabIndex = 23;
            this.lblParam2.Text = "Param 1:";
            this.lblParam2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblParam3
            // 
            this.lblParam3.Location = new System.Drawing.Point(5, 57);
            this.lblParam3.Name = "lblParam3";
            this.lblParam3.Size = new System.Drawing.Size(95, 13);
            this.lblParam3.TabIndex = 25;
            this.lblParam3.Text = "Param 2:";
            this.lblParam3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 0);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 2;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 27);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 5;
            // 
            // textDataValue3
            // 
            this.textDataValue3.Location = new System.Drawing.Point(310, 54);
            this.textDataValue3.Name = "textDataValue3";
            this.textDataValue3.Size = new System.Drawing.Size(120, 20);
            this.textDataValue3.TabIndex = 8;
            // 
            // comboDataPicker1
            // 
            this.comboDataPicker1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker1.FormattingEnabled = true;
            this.comboDataPicker1.Location = new System.Drawing.Point(310, 0);
            this.comboDataPicker1.Name = "comboDataPicker1";
            this.comboDataPicker1.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker1.TabIndex = 3;
            // 
            // comboDataPicker2
            // 
            this.comboDataPicker2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker2.FormattingEnabled = true;
            this.comboDataPicker2.Location = new System.Drawing.Point(310, 27);
            this.comboDataPicker2.Name = "comboDataPicker2";
            this.comboDataPicker2.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker2.TabIndex = 6;
            // 
            // comboDataPicker3
            // 
            this.comboDataPicker3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker3.FormattingEnabled = true;
            this.comboDataPicker3.Location = new System.Drawing.Point(310, 54);
            this.comboDataPicker3.Name = "comboDataPicker3";
            this.comboDataPicker3.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker3.TabIndex = 9;
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
            // comboDataOwner2
            // 
            this.comboDataOwner2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner2.FormattingEnabled = true;
            this.comboDataOwner2.Location = new System.Drawing.Point(100, 27);
            this.comboDataOwner2.Name = "comboDataOwner2";
            this.comboDataOwner2.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner2.TabIndex = 4;
            // 
            // comboDataOwner3
            // 
            this.comboDataOwner3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner3.FormattingEnabled = true;
            this.comboDataOwner3.Location = new System.Drawing.Point(100, 54);
            this.comboDataOwner3.Name = "comboDataOwner3";
            this.comboDataOwner3.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner3.TabIndex = 7;
            // 
            // btnEventTreePicker
            // 
            this.btnEventTreePicker.Location = new System.Drawing.Point(100, 52);
            this.btnEventTreePicker.Margin = new System.Windows.Forms.Padding(1);
            this.btnEventTreePicker.Name = "btnEventTreePicker";
            this.btnEventTreePicker.Size = new System.Drawing.Size(27, 21);
            this.btnEventTreePicker.TabIndex = 4;
            this.btnEventTreePicker.Text = ">>";
            this.btnEventTreePicker.UseVisualStyleBackColor = true;
            this.btnEventTreePicker.Click += new System.EventHandler(this.OnEventTreePickerClicked);
            // 
            // lblEventTreeName
            // 
            this.lblEventTreeName.AutoSize = true;
            this.lblEventTreeName.Location = new System.Drawing.Point(131, 56);
            this.lblEventTreeName.Name = "lblEventTreeName";
            this.lblEventTreeName.Size = new System.Drawing.Size(35, 13);
            this.lblEventTreeName.TabIndex = 44;
            this.lblEventTreeName.Text = "label1";
            // 
            // comboParamType
            // 
            this.comboParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboParamType.FormattingEnabled = true;
            this.comboParamType.Items.AddRange(new object[] {
            "Callers",
            "Variables"});
            this.comboParamType.Location = new System.Drawing.Point(100, 119);
            this.comboParamType.Name = "comboParamType";
            this.comboParamType.Size = new System.Drawing.Size(90, 21);
            this.comboParamType.TabIndex = 7;
            this.comboParamType.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // comboAction
            // 
            this.comboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAction.FormattingEnabled = true;
            this.comboAction.Items.AddRange(new object[] {
            "Start",
            "Modify",
            "Delete"});
            this.comboAction.Location = new System.Drawing.Point(100, 3);
            this.comboAction.Name = "comboAction";
            this.comboAction.Size = new System.Drawing.Size(90, 21);
            this.comboAction.TabIndex = 0;
            this.comboAction.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblAction
            // 
            this.lblAction.Location = new System.Drawing.Point(5, 6);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(95, 13);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "Action:";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 255);
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
            this.checkDecimal.Location = new System.Drawing.Point(136, 270);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 2;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 270);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 3;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 290);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelStartModify.ResumeLayout(false);
            this.panelStartModify.PerformLayout();
            this.panelTickCount.ResumeLayout(false);
            this.panelTickCount.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox textTickCount;
        private System.Windows.Forms.ComboBox comboEventTreeScope;
        private System.Windows.Forms.TextBox textEventTree;
        private System.Windows.Forms.ComboBox comboParamType;
        private System.Windows.Forms.Button btnEventTreePicker;
        private System.Windows.Forms.Label lblParam1;
        private System.Windows.Forms.Label lblParam2;
        private System.Windows.Forms.Label lblParam3;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataOwner2;
        private System.Windows.Forms.ComboBox comboDataPicker2;
        private System.Windows.Forms.TextBox textDataValue2;
        private System.Windows.Forms.ComboBox comboDataOwner3;
        private System.Windows.Forms.ComboBox comboDataPicker3;
        private System.Windows.Forms.TextBox textDataValue3;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblEventTreeName;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.Label lblEventTree;
        private System.Windows.Forms.ComboBox comboAction;
        private System.Windows.Forms.Label lblTickCount;
        private System.Windows.Forms.ComboBox comboTickCount;
        private System.Windows.Forms.CheckBox checkReset;
        private System.Windows.Forms.Label lblReset;
        private System.Windows.Forms.CheckBox checkLooping;
        private System.Windows.Forms.Label lblLooping;
        private System.Windows.Forms.Panel panelStartModify;
        private System.Windows.Forms.Panel panelTickCount;
    }
}
