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

namespace whse.PrimitiveWizards.Wiz0x0074
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
            this.lblReachAnims = new System.Windows.Forms.Label();
            this.checkReachAnims = new System.Windows.Forms.CheckBox();
            this.panelObjectAnim = new System.Windows.Forms.Panel();
            this.textObjectAnim = new System.Windows.Forms.TextBox();
            this.btnObjectAnim = new System.Windows.Forms.Button();
            this.lblObjectAnimName = new System.Windows.Forms.Label();
            this.panelGraspAnim = new System.Windows.Forms.Panel();
            this.textGraspAnim = new System.Windows.Forms.TextBox();
            this.btnGraspAnim = new System.Windows.Forms.Button();
            this.lblGraspAnimName = new System.Windows.Forms.Label();
            this.panelSlot = new System.Windows.Forms.Panel();
            this.textSlot = new System.Windows.Forms.TextBox();
            this.lblHandedness = new System.Windows.Forms.Label();
            this.lblUseSimAge = new System.Windows.Forms.Label();
            this.comboSlot = new System.Windows.Forms.ComboBox();
            this.lblSlot = new System.Windows.Forms.Label();
            this.lblObjectAnim = new System.Windows.Forms.Label();
            this.checkObjectAnim = new System.Windows.Forms.CheckBox();
            this.lblGraspAnim = new System.Windows.Forms.Label();
            this.checkGraspAnim = new System.Windows.Forms.CheckBox();
            this.checkHandedness = new System.Windows.Forms.CheckBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.checkUseSimAge = new System.Windows.Forms.CheckBox();
            this.comboAction = new System.Windows.Forms.ComboBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.panelObject = new System.Windows.Forms.Panel();
            this.lblObject = new System.Windows.Forms.Label();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            this.panelObjectAnim.SuspendLayout();
            this.panelGraspAnim.SuspendLayout();
            this.panelSlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblReachAnims);
            this.panelMain.Controls.Add(this.checkReachAnims);
            this.panelMain.Controls.Add(this.panelObjectAnim);
            this.panelMain.Controls.Add(this.panelGraspAnim);
            this.panelMain.Controls.Add(this.panelSlot);
            this.panelMain.Controls.Add(this.lblHandedness);
            this.panelMain.Controls.Add(this.lblUseSimAge);
            this.panelMain.Controls.Add(this.comboSlot);
            this.panelMain.Controls.Add(this.lblSlot);
            this.panelMain.Controls.Add(this.lblObjectAnim);
            this.panelMain.Controls.Add(this.checkObjectAnim);
            this.panelMain.Controls.Add(this.lblGraspAnim);
            this.panelMain.Controls.Add(this.checkGraspAnim);
            this.panelMain.Controls.Add(this.checkHandedness);
            this.panelMain.Controls.Add(this.lblAction);
            this.panelMain.Controls.Add(this.checkUseSimAge);
            this.panelMain.Controls.Add(this.comboAction);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.panelObject);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 260);
            this.panelMain.TabIndex = 0;
            // 
            // lblReachAnims
            // 
            this.lblReachAnims.Location = new System.Drawing.Point(5, 232);
            this.lblReachAnims.Name = "lblReachAnims";
            this.lblReachAnims.Size = new System.Drawing.Size(95, 13);
            this.lblReachAnims.TabIndex = 64;
            this.lblReachAnims.Text = "Use Reach Anims:";
            this.lblReachAnims.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblReachAnims, "See https://www.picknmixmods.com/Sims2/Notes/ReachPutOp9Bit4/ReachPutOp9Bit4.html" +
        "");
            // 
            // checkReachAnims
            // 
            this.checkReachAnims.AutoSize = true;
            this.checkReachAnims.Location = new System.Drawing.Point(100, 232);
            this.checkReachAnims.Name = "checkReachAnims";
            this.checkReachAnims.Size = new System.Drawing.Size(15, 14);
            this.checkReachAnims.TabIndex = 63;
            this.toolTip.SetToolTip(this.checkReachAnims, "See https://www.picknmixmods.com/Sims2/Notes/ReachPutOp9Bit4/ReachPutOp9Bit4.html" +
        "");
            this.checkReachAnims.UseVisualStyleBackColor = true;
            this.checkReachAnims.CheckedChanged += new System.EventHandler(this.OnAnimsChanged);
            // 
            // panelObjectAnim
            // 
            this.panelObjectAnim.Controls.Add(this.textObjectAnim);
            this.panelObjectAnim.Controls.Add(this.btnObjectAnim);
            this.panelObjectAnim.Controls.Add(this.lblObjectAnimName);
            this.panelObjectAnim.Location = new System.Drawing.Point(121, 139);
            this.panelObjectAnim.Name = "panelObjectAnim";
            this.panelObjectAnim.Size = new System.Drawing.Size(264, 46);
            this.panelObjectAnim.TabIndex = 62;
            // 
            // textObjectAnim
            // 
            this.textObjectAnim.Location = new System.Drawing.Point(0, 0);
            this.textObjectAnim.Name = "textObjectAnim";
            this.textObjectAnim.Size = new System.Drawing.Size(60, 20);
            this.textObjectAnim.TabIndex = 8;
            // 
            // btnObjectAnim
            // 
            this.btnObjectAnim.Location = new System.Drawing.Point(0, 24);
            this.btnObjectAnim.Margin = new System.Windows.Forms.Padding(1);
            this.btnObjectAnim.Name = "btnObjectAnim";
            this.btnObjectAnim.Size = new System.Drawing.Size(27, 21);
            this.btnObjectAnim.TabIndex = 9;
            this.btnObjectAnim.Text = ">>";
            this.btnObjectAnim.UseVisualStyleBackColor = true;
            this.btnObjectAnim.Click += new System.EventHandler(this.OnObjectAnimClicked);
            // 
            // lblObjectAnimName
            // 
            this.lblObjectAnimName.AutoSize = true;
            this.lblObjectAnimName.Location = new System.Drawing.Point(31, 28);
            this.lblObjectAnimName.Name = "lblObjectAnimName";
            this.lblObjectAnimName.Size = new System.Drawing.Size(61, 13);
            this.lblObjectAnimName.TabIndex = 57;
            this.lblObjectAnimName.Text = "object anim";
            // 
            // panelGraspAnim
            // 
            this.panelGraspAnim.Controls.Add(this.textGraspAnim);
            this.panelGraspAnim.Controls.Add(this.btnGraspAnim);
            this.panelGraspAnim.Controls.Add(this.lblGraspAnimName);
            this.panelGraspAnim.Location = new System.Drawing.Point(121, 90);
            this.panelGraspAnim.Name = "panelGraspAnim";
            this.panelGraspAnim.Size = new System.Drawing.Size(264, 46);
            this.panelGraspAnim.TabIndex = 61;
            // 
            // textGraspAnim
            // 
            this.textGraspAnim.Location = new System.Drawing.Point(0, 0);
            this.textGraspAnim.Name = "textGraspAnim";
            this.textGraspAnim.Size = new System.Drawing.Size(60, 20);
            this.textGraspAnim.TabIndex = 5;
            // 
            // btnGraspAnim
            // 
            this.btnGraspAnim.Location = new System.Drawing.Point(0, 24);
            this.btnGraspAnim.Margin = new System.Windows.Forms.Padding(1);
            this.btnGraspAnim.Name = "btnGraspAnim";
            this.btnGraspAnim.Size = new System.Drawing.Size(27, 21);
            this.btnGraspAnim.TabIndex = 6;
            this.btnGraspAnim.Text = ">>";
            this.btnGraspAnim.UseVisualStyleBackColor = true;
            this.btnGraspAnim.Click += new System.EventHandler(this.OnGraspAnimClicked);
            // 
            // lblGraspAnimName
            // 
            this.lblGraspAnimName.AutoSize = true;
            this.lblGraspAnimName.Location = new System.Drawing.Point(31, 28);
            this.lblGraspAnimName.Name = "lblGraspAnimName";
            this.lblGraspAnimName.Size = new System.Drawing.Size(58, 13);
            this.lblGraspAnimName.TabIndex = 56;
            this.lblGraspAnimName.Text = "grasp anim";
            // 
            // panelSlot
            // 
            this.panelSlot.Controls.Add(this.textSlot);
            this.panelSlot.Location = new System.Drawing.Point(176, 63);
            this.panelSlot.Name = "panelSlot";
            this.panelSlot.Size = new System.Drawing.Size(264, 21);
            this.panelSlot.TabIndex = 60;
            // 
            // textSlot
            // 
            this.textSlot.Location = new System.Drawing.Point(0, 0);
            this.textSlot.Name = "textSlot";
            this.textSlot.Size = new System.Drawing.Size(50, 20);
            this.textSlot.TabIndex = 3;
            // 
            // lblHandedness
            // 
            this.lblHandedness.Location = new System.Drawing.Point(5, 210);
            this.lblHandedness.Name = "lblHandedness";
            this.lblHandedness.Size = new System.Drawing.Size(95, 13);
            this.lblHandedness.TabIndex = 59;
            this.lblHandedness.Text = "Handed in T3:";
            this.lblHandedness.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblHandedness, "Handedness in Temp 3");
            // 
            // lblUseSimAge
            // 
            this.lblUseSimAge.Location = new System.Drawing.Point(5, 188);
            this.lblUseSimAge.Name = "lblUseSimAge";
            this.lblUseSimAge.Size = new System.Drawing.Size(95, 13);
            this.lblUseSimAge.TabIndex = 58;
            this.lblUseSimAge.Text = "Use Sim Age:";
            this.lblUseSimAge.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblUseSimAge, "Use Sim\'s age to pick animation");
            // 
            // comboSlot
            // 
            this.comboSlot.FormattingEnabled = true;
            this.comboSlot.Items.AddRange(new object[] {
            "Literal",
            "Temp 0"});
            this.comboSlot.Location = new System.Drawing.Point(100, 63);
            this.comboSlot.Name = "comboSlot";
            this.comboSlot.Size = new System.Drawing.Size(70, 21);
            this.comboSlot.TabIndex = 2;
            this.comboSlot.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblSlot
            // 
            this.lblSlot.Location = new System.Drawing.Point(5, 66);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(95, 13);
            this.lblSlot.TabIndex = 53;
            this.lblSlot.Text = "Slot:";
            this.lblSlot.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblObjectAnim
            // 
            this.lblObjectAnim.Location = new System.Drawing.Point(5, 142);
            this.lblObjectAnim.Name = "lblObjectAnim";
            this.lblObjectAnim.Size = new System.Drawing.Size(95, 13);
            this.lblObjectAnim.TabIndex = 51;
            this.lblObjectAnim.Text = "Object Anim:";
            this.lblObjectAnim.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkObjectAnim
            // 
            this.checkObjectAnim.AutoSize = true;
            this.checkObjectAnim.Location = new System.Drawing.Point(100, 142);
            this.checkObjectAnim.Name = "checkObjectAnim";
            this.checkObjectAnim.Size = new System.Drawing.Size(15, 14);
            this.checkObjectAnim.TabIndex = 7;
            this.checkObjectAnim.UseVisualStyleBackColor = true;
            this.checkObjectAnim.CheckedChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblGraspAnim
            // 
            this.lblGraspAnim.Location = new System.Drawing.Point(5, 93);
            this.lblGraspAnim.Name = "lblGraspAnim";
            this.lblGraspAnim.Size = new System.Drawing.Size(95, 13);
            this.lblGraspAnim.TabIndex = 46;
            this.lblGraspAnim.Text = "Grasp Anim:";
            this.lblGraspAnim.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkGraspAnim
            // 
            this.checkGraspAnim.AutoSize = true;
            this.checkGraspAnim.Location = new System.Drawing.Point(100, 93);
            this.checkGraspAnim.Name = "checkGraspAnim";
            this.checkGraspAnim.Size = new System.Drawing.Size(15, 14);
            this.checkGraspAnim.TabIndex = 4;
            this.checkGraspAnim.UseVisualStyleBackColor = true;
            this.checkGraspAnim.CheckedChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // checkHandedness
            // 
            this.checkHandedness.AutoSize = true;
            this.checkHandedness.Location = new System.Drawing.Point(100, 210);
            this.checkHandedness.Name = "checkHandedness";
            this.checkHandedness.Size = new System.Drawing.Size(15, 14);
            this.checkHandedness.TabIndex = 11;
            this.toolTip.SetToolTip(this.checkHandedness, "Handedness in Temp 3");
            this.checkHandedness.UseVisualStyleBackColor = true;
            // 
            // lblAction
            // 
            this.lblAction.Location = new System.Drawing.Point(5, 7);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(95, 13);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "Action:";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkUseSimAge
            // 
            this.checkUseSimAge.AutoSize = true;
            this.checkUseSimAge.Location = new System.Drawing.Point(100, 188);
            this.checkUseSimAge.Name = "checkUseSimAge";
            this.checkUseSimAge.Size = new System.Drawing.Size(15, 14);
            this.checkUseSimAge.TabIndex = 10;
            this.toolTip.SetToolTip(this.checkUseSimAge, "Use Sim\'s age to pick animation");
            this.checkUseSimAge.UseVisualStyleBackColor = true;
            // 
            // comboAction
            // 
            this.comboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAction.FormattingEnabled = true;
            this.comboAction.Items.AddRange(new object[] {
            "Pick up Object",
            "Drop onto Object",
            "Drop onto floor"});
            this.comboAction.Location = new System.Drawing.Point(100, 4);
            this.comboAction.Name = "comboAction";
            this.comboAction.Size = new System.Drawing.Size(120, 21);
            this.comboAction.TabIndex = 0;
            this.comboAction.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 225);
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
            this.checkDecimal.Location = new System.Drawing.Point(136, 240);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 12;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 240);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 13;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // panelObject
            // 
            this.panelObject.Controls.Add(this.lblObject);
            this.panelObject.Controls.Add(this.textDataValue1);
            this.panelObject.Controls.Add(this.comboDataPicker1);
            this.panelObject.Controls.Add(this.comboDataOwner1);
            this.panelObject.Location = new System.Drawing.Point(0, 36);
            this.panelObject.Name = "panelObject";
            this.panelObject.Size = new System.Drawing.Size(440, 21);
            this.panelObject.TabIndex = 1;
            // 
            // lblObject
            // 
            this.lblObject.Location = new System.Drawing.Point(5, 3);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(95, 13);
            this.lblObject.TabIndex = 5;
            this.lblObject.Text = "Object:";
            this.lblObject.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.Size = new System.Drawing.Size(440, 260);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelObjectAnim.ResumeLayout(false);
            this.panelObjectAnim.PerformLayout();
            this.panelGraspAnim.ResumeLayout(false);
            this.panelGraspAnim.PerformLayout();
            this.panelSlot.ResumeLayout(false);
            this.panelSlot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelObject.ResumeLayout(false);
            this.panelObject.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox comboAction;
        private System.Windows.Forms.Button btnGraspAnim;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Panel panelObject;
        private System.Windows.Forms.CheckBox checkUseSimAge;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkHandedness;
        private System.Windows.Forms.Label lblGraspAnim;
        private System.Windows.Forms.CheckBox checkGraspAnim;
        private System.Windows.Forms.TextBox textGraspAnim;
        private System.Windows.Forms.ComboBox comboSlot;
        private System.Windows.Forms.TextBox textSlot;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.TextBox textObjectAnim;
        private System.Windows.Forms.Label lblObjectAnim;
        private System.Windows.Forms.CheckBox checkObjectAnim;
        private System.Windows.Forms.Button btnObjectAnim;
        private System.Windows.Forms.Label lblObjectAnimName;
        private System.Windows.Forms.Label lblGraspAnimName;
        private System.Windows.Forms.Label lblHandedness;
        private System.Windows.Forms.Label lblUseSimAge;
        private System.Windows.Forms.Panel panelSlot;
        private System.Windows.Forms.Panel panelObjectAnim;
        private System.Windows.Forms.Panel panelGraspAnim;
        private System.Windows.Forms.Label lblReachAnims;
        private System.Windows.Forms.CheckBox checkReachAnims;
    }
}
