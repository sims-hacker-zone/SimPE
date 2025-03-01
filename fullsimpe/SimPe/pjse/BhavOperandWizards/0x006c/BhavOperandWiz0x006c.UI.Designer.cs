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

namespace whse.PrimitiveWizards.Wiz0x006c
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
            this.panelAnimation = new System.Windows.Forms.Panel();
            this.panelAnimEntryLiteral = new System.Windows.Forms.Panel();
            this.textAnimEntryLiteral = new System.Windows.Forms.TextBox();
            this.lblAnimationResName = new System.Windows.Forms.Label();
            this.panelAnimEntryParam = new System.Windows.Forms.Panel();
            this.textAnimEntryParam = new System.Windows.Forms.TextBox();
            this.comboAnimEntryParam = new System.Windows.Forms.ComboBox();
            this.textAnimationRes = new System.Windows.Forms.TextBox();
            this.lblAnimationEntry = new System.Windows.Forms.Label();
            this.comboAnimationRes = new System.Windows.Forms.ComboBox();
            this.lblAnimationRes = new System.Windows.Forms.Label();
            this.comboAnimLiteralOrParam = new System.Windows.Forms.ComboBox();
            this.btnAnimationPicker = new System.Windows.Forms.Button();
            this.lblAnimationEntryName = new System.Windows.Forms.Label();
            this.comboFlipFlag = new System.Windows.Forms.ComboBox();
            this.lblFlipFlag = new System.Windows.Forms.Label();
            this.comboPriority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblShortBlendOut = new System.Windows.Forms.Label();
            this.checkShortBlendOut = new System.Windows.Forms.CheckBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.lblObject = new System.Windows.Forms.Label();
            this.lblAnimationType = new System.Windows.Forms.Label();
            this.comboAnimationType = new System.Windows.Forms.ComboBox();
            this.lblNormalAndFlipped = new System.Windows.Forms.Label();
            this.checkNormalAndFlipped = new System.Windows.Forms.CheckBox();
            this.lblBlendOut = new System.Windows.Forms.Label();
            this.checkBlendOut = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            this.panelAnimation.SuspendLayout();
            this.panelAnimEntryLiteral.SuspendLayout();
            this.panelAnimEntryParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelAnimation);
            this.panelMain.Controls.Add(this.comboFlipFlag);
            this.panelMain.Controls.Add(this.lblFlipFlag);
            this.panelMain.Controls.Add(this.comboPriority);
            this.panelMain.Controls.Add(this.lblPriority);
            this.panelMain.Controls.Add(this.lblShortBlendOut);
            this.panelMain.Controls.Add(this.checkShortBlendOut);
            this.panelMain.Controls.Add(this.comboDataPicker1);
            this.panelMain.Controls.Add(this.textDataValue1);
            this.panelMain.Controls.Add(this.comboDataOwner1);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.lblObject);
            this.panelMain.Controls.Add(this.lblAnimationType);
            this.panelMain.Controls.Add(this.comboAnimationType);
            this.panelMain.Controls.Add(this.lblNormalAndFlipped);
            this.panelMain.Controls.Add(this.checkNormalAndFlipped);
            this.panelMain.Controls.Add(this.lblBlendOut);
            this.panelMain.Controls.Add(this.checkBlendOut);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 265);
            this.panelMain.TabIndex = 0;
            // 
            // panelAnimation
            // 
            this.panelAnimation.Controls.Add(this.panelAnimEntryLiteral);
            this.panelAnimation.Controls.Add(this.lblAnimationResName);
            this.panelAnimation.Controls.Add(this.panelAnimEntryParam);
            this.panelAnimation.Controls.Add(this.textAnimationRes);
            this.panelAnimation.Controls.Add(this.lblAnimationEntry);
            this.panelAnimation.Controls.Add(this.comboAnimationRes);
            this.panelAnimation.Controls.Add(this.lblAnimationRes);
            this.panelAnimation.Controls.Add(this.comboAnimLiteralOrParam);
            this.panelAnimation.Controls.Add(this.btnAnimationPicker);
            this.panelAnimation.Controls.Add(this.lblAnimationEntryName);
            this.panelAnimation.Location = new System.Drawing.Point(0, 59);
            this.panelAnimation.Name = "panelAnimation";
            this.panelAnimation.Size = new System.Drawing.Size(440, 73);
            this.panelAnimation.TabIndex = 4;
            // 
            // panelAnimEntryLiteral
            // 
            this.panelAnimEntryLiteral.Controls.Add(this.textAnimEntryLiteral);
            this.panelAnimEntryLiteral.Location = new System.Drawing.Point(176, 26);
            this.panelAnimEntryLiteral.Name = "panelAnimEntryLiteral";
            this.panelAnimEntryLiteral.Size = new System.Drawing.Size(264, 21);
            this.panelAnimEntryLiteral.TabIndex = 50;
            // 
            // textAnimEntryLiteral
            // 
            this.textAnimEntryLiteral.Location = new System.Drawing.Point(0, 0);
            this.textAnimEntryLiteral.Name = "textAnimEntryLiteral";
            this.textAnimEntryLiteral.Size = new System.Drawing.Size(60, 20);
            this.textAnimEntryLiteral.TabIndex = 3;
            // 
            // lblAnimationResName
            // 
            this.lblAnimationResName.AutoSize = true;
            this.lblAnimationResName.Location = new System.Drawing.Point(201, 3);
            this.lblAnimationResName.Name = "lblAnimationResName";
            this.lblAnimationResName.Size = new System.Drawing.Size(100, 13);
            this.lblAnimationResName.TabIndex = 48;
            this.lblAnimationResName.Text = "AnimationResName";
            // 
            // panelAnimEntryParam
            // 
            this.panelAnimEntryParam.Controls.Add(this.textAnimEntryParam);
            this.panelAnimEntryParam.Controls.Add(this.comboAnimEntryParam);
            this.panelAnimEntryParam.Location = new System.Drawing.Point(176, 26);
            this.panelAnimEntryParam.Name = "panelAnimEntryParam";
            this.panelAnimEntryParam.Size = new System.Drawing.Size(264, 21);
            this.panelAnimEntryParam.TabIndex = 49;
            // 
            // textAnimEntryParam
            // 
            this.textAnimEntryParam.Location = new System.Drawing.Point(0, 0);
            this.textAnimEntryParam.Name = "textAnimEntryParam";
            this.textAnimEntryParam.Size = new System.Drawing.Size(60, 20);
            this.textAnimEntryParam.TabIndex = 1;
            // 
            // comboAnimEntryParam
            // 
            this.comboAnimEntryParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnimEntryParam.FormattingEnabled = true;
            this.comboAnimEntryParam.Location = new System.Drawing.Point(0, 0);
            this.comboAnimEntryParam.Name = "comboAnimEntryParam";
            this.comboAnimEntryParam.Size = new System.Drawing.Size(104, 21);
            this.comboAnimEntryParam.TabIndex = 27;
            // 
            // textAnimationRes
            // 
            this.textAnimationRes.Location = new System.Drawing.Point(105, 0);
            this.textAnimationRes.Name = "textAnimationRes";
            this.textAnimationRes.Size = new System.Drawing.Size(65, 20);
            this.textAnimationRes.TabIndex = 0;
            // 
            // lblAnimationEntry
            // 
            this.lblAnimationEntry.Location = new System.Drawing.Point(5, 30);
            this.lblAnimationEntry.Name = "lblAnimationEntry";
            this.lblAnimationEntry.Size = new System.Drawing.Size(95, 13);
            this.lblAnimationEntry.TabIndex = 47;
            this.lblAnimationEntry.Text = "Animation String:";
            this.lblAnimationEntry.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboAnimationRes
            // 
            this.comboAnimationRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnimationRes.FormattingEnabled = true;
            this.comboAnimationRes.Items.AddRange(new object[] {
            "AdultAnims",
            "ChildAnims",
            "SocialAnims",
            "LocoAnims",
            "ObjectAnims",
            "ToddlerAnims",
            "TeenAnims",
            "ElderAnims",
            "CatAnims",
            "DogAnims",
            "BabyAnims",
            "ReachAnims",
            "PuppyAnims",
            "KittenAnims",
            "SmallDogAnims",
            "ElderLargeDogAnims",
            "ElderSmallDogAnims",
            "ElderCatAnims"});
            this.comboAnimationRes.Location = new System.Drawing.Point(176, 0);
            this.comboAnimationRes.Name = "comboAnimationRes";
            this.comboAnimationRes.Size = new System.Drawing.Size(19, 21);
            this.comboAnimationRes.TabIndex = 1;
            this.comboAnimationRes.SelectedIndexChanged += new System.EventHandler(this.OnAnimResChanged);
            // 
            // lblAnimationRes
            // 
            this.lblAnimationRes.Location = new System.Drawing.Point(5, 0);
            this.lblAnimationRes.Name = "lblAnimationRes";
            this.lblAnimationRes.Size = new System.Drawing.Size(95, 13);
            this.lblAnimationRes.TabIndex = 45;
            this.lblAnimationRes.Text = "Animation Type:";
            this.lblAnimationRes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboAnimLiteralOrParam
            // 
            this.comboAnimLiteralOrParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnimLiteralOrParam.FormattingEnabled = true;
            this.comboAnimLiteralOrParam.Items.AddRange(new object[] {
            "Literal",
            "Param"});
            this.comboAnimLiteralOrParam.Location = new System.Drawing.Point(105, 26);
            this.comboAnimLiteralOrParam.Name = "comboAnimLiteralOrParam";
            this.comboAnimLiteralOrParam.Size = new System.Drawing.Size(65, 21);
            this.comboAnimLiteralOrParam.TabIndex = 2;
            this.comboAnimLiteralOrParam.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // btnAnimationPicker
            // 
            this.btnAnimationPicker.Location = new System.Drawing.Point(176, 51);
            this.btnAnimationPicker.Margin = new System.Windows.Forms.Padding(1);
            this.btnAnimationPicker.Name = "btnAnimationPicker";
            this.btnAnimationPicker.Size = new System.Drawing.Size(27, 21);
            this.btnAnimationPicker.TabIndex = 4;
            this.btnAnimationPicker.Text = ">>";
            this.btnAnimationPicker.UseVisualStyleBackColor = true;
            this.btnAnimationPicker.Click += new System.EventHandler(this.OnAnimPickerClicked);
            // 
            // lblAnimationEntryName
            // 
            this.lblAnimationEntryName.AutoSize = true;
            this.lblAnimationEntryName.Location = new System.Drawing.Point(207, 55);
            this.lblAnimationEntryName.Name = "lblAnimationEntryName";
            this.lblAnimationEntryName.Size = new System.Drawing.Size(105, 13);
            this.lblAnimationEntryName.TabIndex = 40;
            this.lblAnimationEntryName.Text = "AnimationEntryName";
            // 
            // comboFlipFlag
            // 
            this.comboFlipFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFlipFlag.FormattingEnabled = true;
            this.comboFlipFlag.Items.AddRange(new object[] {
            "Off",
            "On",
            "In Temp 3"});
            this.comboFlipFlag.Location = new System.Drawing.Point(105, 162);
            this.comboFlipFlag.Name = "comboFlipFlag";
            this.comboFlipFlag.Size = new System.Drawing.Size(90, 21);
            this.comboFlipFlag.TabIndex = 6;
            // 
            // lblFlipFlag
            // 
            this.lblFlipFlag.Location = new System.Drawing.Point(5, 165);
            this.lblFlipFlag.Name = "lblFlipFlag";
            this.lblFlipFlag.Size = new System.Drawing.Size(95, 13);
            this.lblFlipFlag.TabIndex = 38;
            this.lblFlipFlag.Text = "Flip Flag:";
            this.lblFlipFlag.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboPriority
            // 
            this.comboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.comboPriority.Location = new System.Drawing.Point(105, 135);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(90, 21);
            this.comboPriority.TabIndex = 5;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(5, 138);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(95, 13);
            this.lblPriority.TabIndex = 34;
            this.lblPriority.Text = "Priority:";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblShortBlendOut
            // 
            this.lblShortBlendOut.Location = new System.Drawing.Point(5, 235);
            this.lblShortBlendOut.Name = "lblShortBlendOut";
            this.lblShortBlendOut.Size = new System.Drawing.Size(95, 13);
            this.lblShortBlendOut.TabIndex = 32;
            this.lblShortBlendOut.Text = "Short Blend Out:";
            this.lblShortBlendOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkShortBlendOut
            // 
            this.checkShortBlendOut.AutoSize = true;
            this.checkShortBlendOut.Location = new System.Drawing.Point(105, 235);
            this.checkShortBlendOut.Name = "checkShortBlendOut";
            this.checkShortBlendOut.Size = new System.Drawing.Size(15, 14);
            this.checkShortBlendOut.TabIndex = 9;
            this.checkShortBlendOut.UseVisualStyleBackColor = true;
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
            // textDataValue1
            // 
            this.textDataValue1.Location = new System.Drawing.Point(310, 4);
            this.textDataValue1.Name = "textDataValue1";
            this.textDataValue1.Size = new System.Drawing.Size(120, 20);
            this.textDataValue1.TabIndex = 2;
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
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 231);
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
            this.checkDecimal.Location = new System.Drawing.Point(136, 245);
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
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 245);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 11;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
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
            // lblAnimationType
            // 
            this.lblAnimationType.Location = new System.Drawing.Point(5, 34);
            this.lblAnimationType.Name = "lblAnimationType";
            this.lblAnimationType.Size = new System.Drawing.Size(95, 13);
            this.lblAnimationType.TabIndex = 5;
            this.lblAnimationType.Text = "Animation:";
            this.lblAnimationType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboAnimationType
            // 
            this.comboAnimationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnimationType.FormattingEnabled = true;
            this.comboAnimationType.Items.AddRange(new object[] {
            "Specific",
            "All Overlay",
            "All Full Body",
            "All Animations",
            "Carry Poses",
            "Idles",
            "Gestures",
            "Reactions",
            "Normal",
            "Facial",
            "Facial Idle",
            "Receptivity"});
            this.comboAnimationType.Location = new System.Drawing.Point(105, 31);
            this.comboAnimationType.Name = "comboAnimationType";
            this.comboAnimationType.Size = new System.Drawing.Size(90, 21);
            this.comboAnimationType.TabIndex = 3;
            this.comboAnimationType.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblNormalAndFlipped
            // 
            this.lblNormalAndFlipped.Location = new System.Drawing.Point(5, 191);
            this.lblNormalAndFlipped.Name = "lblNormalAndFlipped";
            this.lblNormalAndFlipped.Size = new System.Drawing.Size(95, 13);
            this.lblNormalAndFlipped.TabIndex = 15;
            this.lblNormalAndFlipped.Text = "Normal && Flipped:";
            this.lblNormalAndFlipped.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkNormalAndFlipped
            // 
            this.checkNormalAndFlipped.AutoSize = true;
            this.checkNormalAndFlipped.Location = new System.Drawing.Point(105, 191);
            this.checkNormalAndFlipped.Name = "checkNormalAndFlipped";
            this.checkNormalAndFlipped.Size = new System.Drawing.Size(15, 14);
            this.checkNormalAndFlipped.TabIndex = 7;
            this.checkNormalAndFlipped.UseVisualStyleBackColor = true;
            // 
            // lblBlendOut
            // 
            this.lblBlendOut.Location = new System.Drawing.Point(5, 213);
            this.lblBlendOut.Name = "lblBlendOut";
            this.lblBlendOut.Size = new System.Drawing.Size(95, 13);
            this.lblBlendOut.TabIndex = 16;
            this.lblBlendOut.Text = "Blend Out:";
            this.lblBlendOut.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBlendOut
            // 
            this.checkBlendOut.AutoSize = true;
            this.checkBlendOut.Location = new System.Drawing.Point(105, 213);
            this.checkBlendOut.Name = "checkBlendOut";
            this.checkBlendOut.Size = new System.Drawing.Size(15, 14);
            this.checkBlendOut.TabIndex = 8;
            this.checkBlendOut.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 265);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelAnimation.ResumeLayout(false);
            this.panelAnimation.PerformLayout();
            this.panelAnimEntryLiteral.ResumeLayout(false);
            this.panelAnimEntryLiteral.PerformLayout();
            this.panelAnimEntryParam.ResumeLayout(false);
            this.panelAnimEntryParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblAnimationType;
        private System.Windows.Forms.TextBox textAnimEntryLiteral;
        private System.Windows.Forms.ComboBox comboAnimationType;
        private System.Windows.Forms.Label lblBlendOut;
        private System.Windows.Forms.Label lblNormalAndFlipped;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.CheckBox checkBlendOut;
        private System.Windows.Forms.CheckBox checkNormalAndFlipped;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblShortBlendOut;
        private System.Windows.Forms.CheckBox checkShortBlendOut;
        private System.Windows.Forms.ComboBox comboPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox comboAnimationRes;
        private System.Windows.Forms.ComboBox comboFlipFlag;
        private System.Windows.Forms.Label lblFlipFlag;
        private System.Windows.Forms.ComboBox comboAnimLiteralOrParam;
        private System.Windows.Forms.Label lblAnimationEntryName;
        private System.Windows.Forms.Button btnAnimationPicker;
        private System.Windows.Forms.Label lblAnimationEntry;
        private System.Windows.Forms.TextBox textAnimationRes;
        private System.Windows.Forms.Label lblAnimationRes;
        private System.Windows.Forms.Panel panelAnimation;
        private System.Windows.Forms.Label lblAnimationResName;
        private System.Windows.Forms.Panel panelAnimEntryParam;
        private System.Windows.Forms.TextBox textAnimEntryParam;
        private System.Windows.Forms.ComboBox comboAnimEntryParam;
        private System.Windows.Forms.Panel panelAnimEntryLiteral;
    }
}
