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

namespace whse.PrimitiveWizards.Wiz0x0010
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
            this.panelSlotLiteral = new System.Windows.Forms.Panel();
            this.textSlotLiteral = new System.Windows.Forms.TextBox();
            this.comboSlotLiteral = new System.Windows.Forms.ComboBox();
            this.lblWithEmptyBorder = new System.Windows.Forms.Label();
            this.panelSlotParam = new System.Windows.Forms.Panel();
            this.textSlotParam = new System.Windows.Forms.TextBox();
            this.comboSlotParam = new System.Windows.Forms.ComboBox();
            this.checkWithEmptyBorder = new System.Windows.Forms.CheckBox();
            this.lblBeginInFront = new System.Windows.Forms.Label();
            this.checkWithLineOfSight = new System.Windows.Forms.CheckBox();
            this.checkBeginInFront = new System.Windows.Forms.CheckBox();
            this.lblWithLineOfSight = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.comboWhat = new System.Windows.Forms.ComboBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.comboLocation = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblWhat = new System.Windows.Forms.Label();
            this.lblPreferEmpty = new System.Windows.Forms.Label();
            this.checkPreferEmpty = new System.Windows.Forms.CheckBox();
            this.lblUserEditable = new System.Windows.Forms.Label();
            this.checkOnLevelGround = new System.Windows.Forms.CheckBox();
            this.checkUserEditable = new System.Windows.Forms.CheckBox();
            this.lblOnLevelGround = new System.Windows.Forms.Label();
            this.panelVariable = new System.Windows.Forms.Panel();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.lblVariable = new System.Windows.Forms.Label();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.panelStartAt = new System.Windows.Forms.Panel();
            this.comboDataPicker3 = new System.Windows.Forms.ComboBox();
            this.textDataValue3 = new System.Windows.Forms.TextBox();
            this.lblStartAt = new System.Windows.Forms.Label();
            this.panelRelativeTo = new System.Windows.Forms.Panel();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.lblRelativeTo = new System.Windows.Forms.Label();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.panelSlotLocal = new System.Windows.Forms.Panel();
            this.textSlotLocal = new System.Windows.Forms.TextBox();
            this.comboSlotLocal = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblDirectionN = new System.Windows.Forms.Label();
            this.checkDirectionN = new System.Windows.Forms.CheckBox();
            this.lblDirectionNE = new System.Windows.Forms.Label();
            this.checkDirectionNE = new System.Windows.Forms.CheckBox();
            this.checkDirectionE = new System.Windows.Forms.CheckBox();
            this.lblDirectionE = new System.Windows.Forms.Label();
            this.lblDirectionSE = new System.Windows.Forms.Label();
            this.checkDirectionSE = new System.Windows.Forms.CheckBox();
            this.lblDirectionNW = new System.Windows.Forms.Label();
            this.checkDirectionNW = new System.Windows.Forms.CheckBox();
            this.checkDirectionW = new System.Windows.Forms.CheckBox();
            this.lblDirectionW = new System.Windows.Forms.Label();
            this.checkDirectionS = new System.Windows.Forms.CheckBox();
            this.lblDirectionSW = new System.Windows.Forms.Label();
            this.checkDirectionSW = new System.Windows.Forms.CheckBox();
            this.lblDirectionS = new System.Windows.Forms.Label();
            this.checkDirection = new System.Windows.Forms.CheckBox();
            this.panelMain.SuspendLayout();
            this.panelSlotLiteral.SuspendLayout();
            this.panelSlotParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelVariable.SuspendLayout();
            this.panelStartAt.SuspendLayout();
            this.panelRelativeTo.SuspendLayout();
            this.panelSlotLocal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.checkDirection);
            this.panelMain.Controls.Add(this.checkDirectionNW);
            this.panelMain.Controls.Add(this.checkDirectionW);
            this.panelMain.Controls.Add(this.lblDirectionW);
            this.panelMain.Controls.Add(this.checkDirectionS);
            this.panelMain.Controls.Add(this.checkDirectionSW);
            this.panelMain.Controls.Add(this.checkDirectionSE);
            this.panelMain.Controls.Add(this.checkDirectionE);
            this.panelMain.Controls.Add(this.lblDirectionE);
            this.panelMain.Controls.Add(this.checkDirectionN);
            this.panelMain.Controls.Add(this.lblDirectionNE);
            this.panelMain.Controls.Add(this.checkDirectionNE);
            this.panelMain.Controls.Add(this.lblDirectionN);
            this.panelMain.Controls.Add(this.panelSlotLiteral);
            this.panelMain.Controls.Add(this.lblWithEmptyBorder);
            this.panelMain.Controls.Add(this.panelSlotParam);
            this.panelMain.Controls.Add(this.checkWithEmptyBorder);
            this.panelMain.Controls.Add(this.lblBeginInFront);
            this.panelMain.Controls.Add(this.checkWithLineOfSight);
            this.panelMain.Controls.Add(this.checkBeginInFront);
            this.panelMain.Controls.Add(this.lblWithLineOfSight);
            this.panelMain.Controls.Add(this.lblDirection);
            this.panelMain.Controls.Add(this.comboWhat);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.comboLocation);
            this.panelMain.Controls.Add(this.lblLocation);
            this.panelMain.Controls.Add(this.lblWhat);
            this.panelMain.Controls.Add(this.lblPreferEmpty);
            this.panelMain.Controls.Add(this.checkPreferEmpty);
            this.panelMain.Controls.Add(this.lblUserEditable);
            this.panelMain.Controls.Add(this.checkOnLevelGround);
            this.panelMain.Controls.Add(this.checkUserEditable);
            this.panelMain.Controls.Add(this.lblOnLevelGround);
            this.panelMain.Controls.Add(this.panelVariable);
            this.panelMain.Controls.Add(this.panelStartAt);
            this.panelMain.Controls.Add(this.panelRelativeTo);
            this.panelMain.Controls.Add(this.panelSlotLocal);
            this.panelMain.Controls.Add(this.lblDirectionSE);
            this.panelMain.Controls.Add(this.lblDirectionS);
            this.panelMain.Controls.Add(this.lblDirectionSW);
            this.panelMain.Controls.Add(this.lblDirectionNW);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 225);
            this.panelMain.TabIndex = 0;
            // 
            // panelSlotLiteral
            // 
            this.panelSlotLiteral.Controls.Add(this.textSlotLiteral);
            this.panelSlotLiteral.Controls.Add(this.comboSlotLiteral);
            this.panelSlotLiteral.Location = new System.Drawing.Point(310, 83);
            this.panelSlotLiteral.Name = "panelSlotLiteral";
            this.panelSlotLiteral.Size = new System.Drawing.Size(130, 21);
            this.panelSlotLiteral.TabIndex = 47;
            // 
            // textSlotLiteral
            // 
            this.textSlotLiteral.Location = new System.Drawing.Point(0, 0);
            this.textSlotLiteral.Name = "textSlotLiteral";
            this.textSlotLiteral.Size = new System.Drawing.Size(60, 20);
            this.textSlotLiteral.TabIndex = 1;
            // 
            // comboSlotLiteral
            // 
            this.comboSlotLiteral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSlotLiteral.FormattingEnabled = true;
            this.comboSlotLiteral.Location = new System.Drawing.Point(0, 0);
            this.comboSlotLiteral.Name = "comboSlotLiteral";
            this.comboSlotLiteral.Size = new System.Drawing.Size(104, 21);
            this.comboSlotLiteral.TabIndex = 27;
            // 
            // lblWithEmptyBorder
            // 
            this.lblWithEmptyBorder.Location = new System.Drawing.Point(140, 139);
            this.lblWithEmptyBorder.Name = "lblWithEmptyBorder";
            this.lblWithEmptyBorder.Size = new System.Drawing.Size(170, 13);
            this.lblWithEmptyBorder.TabIndex = 42;
            this.lblWithEmptyBorder.Text = "With Empty Border:";
            this.lblWithEmptyBorder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelSlotParam
            // 
            this.panelSlotParam.Controls.Add(this.textSlotParam);
            this.panelSlotParam.Controls.Add(this.comboSlotParam);
            this.panelSlotParam.Location = new System.Drawing.Point(310, 83);
            this.panelSlotParam.Name = "panelSlotParam";
            this.panelSlotParam.Size = new System.Drawing.Size(130, 21);
            this.panelSlotParam.TabIndex = 46;
            // 
            // textSlotParam
            // 
            this.textSlotParam.Location = new System.Drawing.Point(0, 0);
            this.textSlotParam.Name = "textSlotParam";
            this.textSlotParam.Size = new System.Drawing.Size(60, 20);
            this.textSlotParam.TabIndex = 1;
            // 
            // comboSlotParam
            // 
            this.comboSlotParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSlotParam.FormattingEnabled = true;
            this.comboSlotParam.Location = new System.Drawing.Point(0, 0);
            this.comboSlotParam.Name = "comboSlotParam";
            this.comboSlotParam.Size = new System.Drawing.Size(104, 21);
            this.comboSlotParam.TabIndex = 27;
            // 
            // checkWithEmptyBorder
            // 
            this.checkWithEmptyBorder.AutoSize = true;
            this.checkWithEmptyBorder.Location = new System.Drawing.Point(310, 139);
            this.checkWithEmptyBorder.Name = "checkWithEmptyBorder";
            this.checkWithEmptyBorder.Size = new System.Drawing.Size(15, 14);
            this.checkWithEmptyBorder.TabIndex = 39;
            this.checkWithEmptyBorder.UseVisualStyleBackColor = true;
            // 
            // lblBeginInFront
            // 
            this.lblBeginInFront.Location = new System.Drawing.Point(140, 159);
            this.lblBeginInFront.Name = "lblBeginInFront";
            this.lblBeginInFront.Size = new System.Drawing.Size(170, 13);
            this.lblBeginInFront.TabIndex = 43;
            this.lblBeginInFront.Text = "Begin In Front Of refObject:";
            this.lblBeginInFront.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkWithLineOfSight
            // 
            this.checkWithLineOfSight.AutoSize = true;
            this.checkWithLineOfSight.Location = new System.Drawing.Point(310, 179);
            this.checkWithLineOfSight.Name = "checkWithLineOfSight";
            this.checkWithLineOfSight.Size = new System.Drawing.Size(15, 14);
            this.checkWithLineOfSight.TabIndex = 41;
            this.checkWithLineOfSight.UseVisualStyleBackColor = true;
            // 
            // checkBeginInFront
            // 
            this.checkBeginInFront.AutoSize = true;
            this.checkBeginInFront.Location = new System.Drawing.Point(310, 159);
            this.checkBeginInFront.Name = "checkBeginInFront";
            this.checkBeginInFront.Size = new System.Drawing.Size(15, 14);
            this.checkBeginInFront.TabIndex = 40;
            this.checkBeginInFront.UseVisualStyleBackColor = true;
            // 
            // lblWithLineOfSight
            // 
            this.lblWithLineOfSight.Location = new System.Drawing.Point(140, 179);
            this.lblWithLineOfSight.Name = "lblWithLineOfSight";
            this.lblWithLineOfSight.Size = new System.Drawing.Size(170, 13);
            this.lblWithLineOfSight.TabIndex = 44;
            this.lblWithLineOfSight.Text = "With Line Of Sight To Centre:";
            this.lblWithLineOfSight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDirection
            // 
            this.lblDirection.Location = new System.Drawing.Point(5, 114);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(95, 13);
            this.lblDirection.TabIndex = 38;
            this.lblDirection.Text = "Direction:";
            this.lblDirection.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboWhat
            // 
            this.comboWhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWhat.FormattingEnabled = true;
            this.comboWhat.Items.AddRange(new object[] {
            "Variable, relative to ...",
            "Stack Object, start at ..."});
            this.comboWhat.Location = new System.Drawing.Point(100, 3);
            this.comboWhat.Name = "comboWhat";
            this.comboWhat.Size = new System.Drawing.Size(200, 21);
            this.comboWhat.TabIndex = 0;
            this.comboWhat.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 190);
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
            this.checkDecimal.Location = new System.Drawing.Point(136, 205);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 17;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // checkAttrPicker
            // 
            this.checkAttrPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAttrPicker.AutoSize = true;
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 205);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 18;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // comboLocation
            // 
            this.comboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLocation.FormattingEnabled = true;
            this.comboLocation.Items.AddRange(new object[] {
            "Normal",
            "Out Of World",
            "Normal In Same Room",
            "Along Object Vector",
            "Lateral To Object Vector",
            "In Routing Slot In Param ...",
            "In Routing Slot in Local ...",
            "In Literal Routing Slot ...",
            "In Global Routing Slot ..."});
            this.comboLocation.Location = new System.Drawing.Point(100, 84);
            this.comboLocation.Name = "comboLocation";
            this.comboLocation.Size = new System.Drawing.Size(200, 21);
            this.comboLocation.TabIndex = 2;
            this.comboLocation.SelectedIndexChanged += new System.EventHandler(this.OnLocationChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(5, 87);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(95, 13);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "Location:";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblWhat
            // 
            this.lblWhat.Location = new System.Drawing.Point(5, 7);
            this.lblWhat.Name = "lblWhat";
            this.lblWhat.Size = new System.Drawing.Size(95, 13);
            this.lblWhat.TabIndex = 0;
            this.lblWhat.Text = "What:";
            this.lblWhat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPreferEmpty
            // 
            this.lblPreferEmpty.Location = new System.Drawing.Point(5, 140);
            this.lblPreferEmpty.Name = "lblPreferEmpty";
            this.lblPreferEmpty.Size = new System.Drawing.Size(95, 13);
            this.lblPreferEmpty.TabIndex = 15;
            this.lblPreferEmpty.Text = "Prefer Empty:";
            this.lblPreferEmpty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkPreferEmpty
            // 
            this.checkPreferEmpty.AutoSize = true;
            this.checkPreferEmpty.Location = new System.Drawing.Point(100, 140);
            this.checkPreferEmpty.Name = "checkPreferEmpty";
            this.checkPreferEmpty.Size = new System.Drawing.Size(15, 14);
            this.checkPreferEmpty.TabIndex = 6;
            this.checkPreferEmpty.UseVisualStyleBackColor = true;
            // 
            // lblUserEditable
            // 
            this.lblUserEditable.Location = new System.Drawing.Point(5, 160);
            this.lblUserEditable.Name = "lblUserEditable";
            this.lblUserEditable.Size = new System.Drawing.Size(95, 13);
            this.lblUserEditable.TabIndex = 16;
            this.lblUserEditable.Text = "User Editable:";
            this.lblUserEditable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkOnLevelGround
            // 
            this.checkOnLevelGround.AutoSize = true;
            this.checkOnLevelGround.Location = new System.Drawing.Point(100, 180);
            this.checkOnLevelGround.Name = "checkOnLevelGround";
            this.checkOnLevelGround.Size = new System.Drawing.Size(15, 14);
            this.checkOnLevelGround.TabIndex = 12;
            this.checkOnLevelGround.UseVisualStyleBackColor = true;
            // 
            // checkUserEditable
            // 
            this.checkUserEditable.AutoSize = true;
            this.checkUserEditable.Location = new System.Drawing.Point(100, 160);
            this.checkUserEditable.Name = "checkUserEditable";
            this.checkUserEditable.Size = new System.Drawing.Size(15, 14);
            this.checkUserEditable.TabIndex = 9;
            this.checkUserEditable.UseVisualStyleBackColor = true;
            // 
            // lblOnLevelGround
            // 
            this.lblOnLevelGround.Location = new System.Drawing.Point(5, 180);
            this.lblOnLevelGround.Name = "lblOnLevelGround";
            this.lblOnLevelGround.Size = new System.Drawing.Size(95, 13);
            this.lblOnLevelGround.TabIndex = 17;
            this.lblOnLevelGround.Text = "On Level Ground:";
            this.lblOnLevelGround.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelVariable
            // 
            this.panelVariable.Controls.Add(this.comboDataOwner1);
            this.panelVariable.Controls.Add(this.lblVariable);
            this.panelVariable.Controls.Add(this.textDataValue1);
            this.panelVariable.Controls.Add(this.comboDataPicker1);
            this.panelVariable.Location = new System.Drawing.Point(0, 30);
            this.panelVariable.Name = "panelVariable";
            this.panelVariable.Size = new System.Drawing.Size(440, 21);
            this.panelVariable.TabIndex = 4;
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
            // lblVariable
            // 
            this.lblVariable.Location = new System.Drawing.Point(5, 3);
            this.lblVariable.Name = "lblVariable";
            this.lblVariable.Size = new System.Drawing.Size(95, 13);
            this.lblVariable.TabIndex = 9;
            this.lblVariable.Text = "Variable:";
            this.lblVariable.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // panelStartAt
            // 
            this.panelStartAt.Controls.Add(this.comboDataPicker3);
            this.panelStartAt.Controls.Add(this.textDataValue3);
            this.panelStartAt.Controls.Add(this.lblStartAt);
            this.panelStartAt.Location = new System.Drawing.Point(0, 30);
            this.panelStartAt.Name = "panelStartAt";
            this.panelStartAt.Size = new System.Drawing.Size(440, 21);
            this.panelStartAt.TabIndex = 29;
            // 
            // comboDataPicker3
            // 
            this.comboDataPicker3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker3.FormattingEnabled = true;
            this.comboDataPicker3.Location = new System.Drawing.Point(100, 0);
            this.comboDataPicker3.Name = "comboDataPicker3";
            this.comboDataPicker3.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker3.TabIndex = 11;
            // 
            // textDataValue3
            // 
            this.textDataValue3.Location = new System.Drawing.Point(100, 0);
            this.textDataValue3.Name = "textDataValue3";
            this.textDataValue3.Size = new System.Drawing.Size(120, 20);
            this.textDataValue3.TabIndex = 11;
            // 
            // lblStartAt
            // 
            this.lblStartAt.Location = new System.Drawing.Point(5, 3);
            this.lblStartAt.Name = "lblStartAt";
            this.lblStartAt.Size = new System.Drawing.Size(95, 13);
            this.lblStartAt.TabIndex = 8;
            this.lblStartAt.Text = "Start At:";
            this.lblStartAt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelRelativeTo
            // 
            this.panelRelativeTo.Controls.Add(this.comboDataPicker2);
            this.panelRelativeTo.Controls.Add(this.comboDataOwner2);
            this.panelRelativeTo.Controls.Add(this.lblRelativeTo);
            this.panelRelativeTo.Controls.Add(this.textDataValue2);
            this.panelRelativeTo.Location = new System.Drawing.Point(0, 57);
            this.panelRelativeTo.Name = "panelRelativeTo";
            this.panelRelativeTo.Size = new System.Drawing.Size(440, 21);
            this.panelRelativeTo.TabIndex = 26;
            // 
            // comboDataPicker2
            // 
            this.comboDataPicker2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker2.FormattingEnabled = true;
            this.comboDataPicker2.Location = new System.Drawing.Point(310, 0);
            this.comboDataPicker2.Name = "comboDataPicker2";
            this.comboDataPicker2.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker2.TabIndex = 2;
            // 
            // comboDataOwner2
            // 
            this.comboDataOwner2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner2.FormattingEnabled = true;
            this.comboDataOwner2.Location = new System.Drawing.Point(100, 0);
            this.comboDataOwner2.Name = "comboDataOwner2";
            this.comboDataOwner2.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner2.TabIndex = 0;
            // 
            // lblRelativeTo
            // 
            this.lblRelativeTo.Location = new System.Drawing.Point(5, 3);
            this.lblRelativeTo.Name = "lblRelativeTo";
            this.lblRelativeTo.Size = new System.Drawing.Size(95, 13);
            this.lblRelativeTo.TabIndex = 25;
            this.lblRelativeTo.Text = "Relative To:";
            this.lblRelativeTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 0);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 1;
            // 
            // panelSlotLocal
            // 
            this.panelSlotLocal.Controls.Add(this.textSlotLocal);
            this.panelSlotLocal.Controls.Add(this.comboSlotLocal);
            this.panelSlotLocal.Location = new System.Drawing.Point(310, 83);
            this.panelSlotLocal.Name = "panelSlotLocal";
            this.panelSlotLocal.Size = new System.Drawing.Size(133, 21);
            this.panelSlotLocal.TabIndex = 45;
            // 
            // textSlotLocal
            // 
            this.textSlotLocal.Location = new System.Drawing.Point(0, 0);
            this.textSlotLocal.Name = "textSlotLocal";
            this.textSlotLocal.Size = new System.Drawing.Size(60, 20);
            this.textSlotLocal.TabIndex = 1;
            // 
            // comboSlotLocal
            // 
            this.comboSlotLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSlotLocal.FormattingEnabled = true;
            this.comboSlotLocal.Location = new System.Drawing.Point(0, 0);
            this.comboSlotLocal.Name = "comboSlotLocal";
            this.comboSlotLocal.Size = new System.Drawing.Size(104, 21);
            this.comboSlotLocal.TabIndex = 27;
            // 
            // lblDirectionN
            // 
            this.lblDirectionN.Location = new System.Drawing.Point(124, 114);
            this.lblDirectionN.Name = "lblDirectionN";
            this.lblDirectionN.Size = new System.Drawing.Size(15, 13);
            this.lblDirectionN.TabIndex = 49;
            this.lblDirectionN.Text = "N";
            this.lblDirectionN.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkDirectionN
            // 
            this.checkDirectionN.AutoSize = true;
            this.checkDirectionN.Location = new System.Drawing.Point(139, 114);
            this.checkDirectionN.Name = "checkDirectionN";
            this.checkDirectionN.Size = new System.Drawing.Size(15, 14);
            this.checkDirectionN.TabIndex = 48;
            this.checkDirectionN.UseVisualStyleBackColor = true;
            // 
            // lblDirectionNE
            // 
            this.lblDirectionNE.Location = new System.Drawing.Point(153, 114);
            this.lblDirectionNE.Name = "lblDirectionNE";
            this.lblDirectionNE.Size = new System.Drawing.Size(26, 13);
            this.lblDirectionNE.TabIndex = 51;
            this.lblDirectionNE.Text = "NE";
            this.lblDirectionNE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkDirectionNE
            // 
            this.checkDirectionNE.AutoSize = true;
            this.checkDirectionNE.Location = new System.Drawing.Point(179, 114);
            this.checkDirectionNE.Name = "checkDirectionNE";
            this.checkDirectionNE.Size = new System.Drawing.Size(15, 14);
            this.checkDirectionNE.TabIndex = 50;
            this.checkDirectionNE.UseVisualStyleBackColor = true;
            // 
            // checkDirectionE
            // 
            this.checkDirectionE.AutoSize = true;
            this.checkDirectionE.Location = new System.Drawing.Point(211, 114);
            this.checkDirectionE.Name = "checkDirectionE";
            this.checkDirectionE.Size = new System.Drawing.Size(15, 14);
            this.checkDirectionE.TabIndex = 52;
            this.checkDirectionE.UseVisualStyleBackColor = true;
            // 
            // lblDirectionE
            // 
            this.lblDirectionE.Location = new System.Drawing.Point(196, 114);
            this.lblDirectionE.Name = "lblDirectionE";
            this.lblDirectionE.Size = new System.Drawing.Size(15, 13);
            this.lblDirectionE.TabIndex = 53;
            this.lblDirectionE.Text = "E";
            this.lblDirectionE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDirectionSE
            // 
            this.lblDirectionSE.Location = new System.Drawing.Point(222, 114);
            this.lblDirectionSE.Name = "lblDirectionSE";
            this.lblDirectionSE.Size = new System.Drawing.Size(26, 13);
            this.lblDirectionSE.TabIndex = 55;
            this.lblDirectionSE.Text = "SE";
            this.lblDirectionSE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkDirectionSE
            // 
            this.checkDirectionSE.AutoSize = true;
            this.checkDirectionSE.Location = new System.Drawing.Point(248, 114);
            this.checkDirectionSE.Name = "checkDirectionSE";
            this.checkDirectionSE.Size = new System.Drawing.Size(15, 14);
            this.checkDirectionSE.TabIndex = 54;
            this.checkDirectionSE.UseVisualStyleBackColor = true;
            // 
            // lblDirectionNW
            // 
            this.lblDirectionNW.Location = new System.Drawing.Point(374, 114);
            this.lblDirectionNW.Name = "lblDirectionNW";
            this.lblDirectionNW.Size = new System.Drawing.Size(26, 13);
            this.lblDirectionNW.TabIndex = 63;
            this.lblDirectionNW.Text = "NW";
            this.lblDirectionNW.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkDirectionNW
            // 
            this.checkDirectionNW.AutoSize = true;
            this.checkDirectionNW.Location = new System.Drawing.Point(400, 114);
            this.checkDirectionNW.Name = "checkDirectionNW";
            this.checkDirectionNW.Size = new System.Drawing.Size(15, 14);
            this.checkDirectionNW.TabIndex = 62;
            this.checkDirectionNW.UseVisualStyleBackColor = true;
            // 
            // checkDirectionW
            // 
            this.checkDirectionW.AutoSize = true;
            this.checkDirectionW.Location = new System.Drawing.Point(357, 114);
            this.checkDirectionW.Name = "checkDirectionW";
            this.checkDirectionW.Size = new System.Drawing.Size(15, 14);
            this.checkDirectionW.TabIndex = 60;
            this.checkDirectionW.UseVisualStyleBackColor = true;
            // 
            // lblDirectionW
            // 
            this.lblDirectionW.Location = new System.Drawing.Point(342, 114);
            this.lblDirectionW.Name = "lblDirectionW";
            this.lblDirectionW.Size = new System.Drawing.Size(15, 13);
            this.lblDirectionW.TabIndex = 61;
            this.lblDirectionW.Text = "W";
            this.lblDirectionW.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkDirectionS
            // 
            this.checkDirectionS.AutoSize = true;
            this.checkDirectionS.Location = new System.Drawing.Point(280, 114);
            this.checkDirectionS.Name = "checkDirectionS";
            this.checkDirectionS.Size = new System.Drawing.Size(15, 14);
            this.checkDirectionS.TabIndex = 56;
            this.checkDirectionS.UseVisualStyleBackColor = true;
            // 
            // lblDirectionSW
            // 
            this.lblDirectionSW.Location = new System.Drawing.Point(295, 114);
            this.lblDirectionSW.Name = "lblDirectionSW";
            this.lblDirectionSW.Size = new System.Drawing.Size(26, 13);
            this.lblDirectionSW.TabIndex = 59;
            this.lblDirectionSW.Text = "SW";
            this.lblDirectionSW.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkDirectionSW
            // 
            this.checkDirectionSW.AutoSize = true;
            this.checkDirectionSW.Location = new System.Drawing.Point(321, 114);
            this.checkDirectionSW.Name = "checkDirectionSW";
            this.checkDirectionSW.Size = new System.Drawing.Size(15, 14);
            this.checkDirectionSW.TabIndex = 58;
            this.checkDirectionSW.UseVisualStyleBackColor = true;
            // 
            // lblDirectionS
            // 
            this.lblDirectionS.Location = new System.Drawing.Point(265, 114);
            this.lblDirectionS.Name = "lblDirectionS";
            this.lblDirectionS.Size = new System.Drawing.Size(15, 13);
            this.lblDirectionS.TabIndex = 57;
            this.lblDirectionS.Text = "S";
            this.lblDirectionS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkDirection
            // 
            this.checkDirection.AutoSize = true;
            this.checkDirection.Location = new System.Drawing.Point(100, 114);
            this.checkDirection.Name = "checkDirection";
            this.checkDirection.Size = new System.Drawing.Size(15, 14);
            this.checkDirection.TabIndex = 64;
            this.checkDirection.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 225);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelSlotLiteral.ResumeLayout(false);
            this.panelSlotLiteral.PerformLayout();
            this.panelSlotParam.ResumeLayout(false);
            this.panelSlotParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelVariable.ResumeLayout(false);
            this.panelVariable.PerformLayout();
            this.panelStartAt.ResumeLayout(false);
            this.panelStartAt.PerformLayout();
            this.panelRelativeTo.ResumeLayout(false);
            this.panelRelativeTo.PerformLayout();
            this.panelSlotLocal.ResumeLayout(false);
            this.panelSlotLocal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblWhat;
        private System.Windows.Forms.ComboBox comboLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox comboWhat;
        private System.Windows.Forms.Label lblVariable;
        private System.Windows.Forms.Label lblStartAt;
        private System.Windows.Forms.Label lblUserEditable;
        private System.Windows.Forms.Label lblPreferEmpty;
        private System.Windows.Forms.CheckBox checkOnLevelGround;
        private System.Windows.Forms.CheckBox checkUserEditable;
        private System.Windows.Forms.CheckBox checkPreferEmpty;
        private System.Windows.Forms.Label lblOnLevelGround;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.Panel panelVariable;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelStartAt;
        private System.Windows.Forms.Panel panelRelativeTo;
        private System.Windows.Forms.TextBox textDataValue2;
        private System.Windows.Forms.ComboBox comboDataPicker2;
        private System.Windows.Forms.ComboBox comboDataOwner2;
        private System.Windows.Forms.Label lblRelativeTo;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblWithEmptyBorder;
        private System.Windows.Forms.CheckBox checkWithEmptyBorder;
        private System.Windows.Forms.Label lblBeginInFront;
        private System.Windows.Forms.CheckBox checkWithLineOfSight;
        private System.Windows.Forms.CheckBox checkBeginInFront;
        private System.Windows.Forms.Label lblWithLineOfSight;
        private System.Windows.Forms.ComboBox comboDataPicker3;
        private System.Windows.Forms.TextBox textDataValue3;
        private System.Windows.Forms.Panel panelSlotLocal;
        private System.Windows.Forms.TextBox textSlotLocal;
        private System.Windows.Forms.ComboBox comboSlotLocal;
        private System.Windows.Forms.Panel panelSlotParam;
        private System.Windows.Forms.TextBox textSlotParam;
        private System.Windows.Forms.ComboBox comboSlotParam;
        private System.Windows.Forms.Panel panelSlotLiteral;
        private System.Windows.Forms.TextBox textSlotLiteral;
        private System.Windows.Forms.ComboBox comboSlotLiteral;
        private System.Windows.Forms.Label lblDirectionN;
        private System.Windows.Forms.CheckBox checkDirectionN;
        private System.Windows.Forms.Label lblDirectionNE;
        private System.Windows.Forms.CheckBox checkDirectionNE;
        private System.Windows.Forms.Label lblDirectionSE;
        private System.Windows.Forms.CheckBox checkDirectionSE;
        private System.Windows.Forms.CheckBox checkDirectionE;
        private System.Windows.Forms.Label lblDirectionE;
        private System.Windows.Forms.Label lblDirectionNW;
        private System.Windows.Forms.CheckBox checkDirectionNW;
        private System.Windows.Forms.CheckBox checkDirectionW;
        private System.Windows.Forms.Label lblDirectionW;
        private System.Windows.Forms.CheckBox checkDirectionS;
        private System.Windows.Forms.Label lblDirectionSW;
        private System.Windows.Forms.CheckBox checkDirectionSW;
        private System.Windows.Forms.Label lblDirectionS;
        private System.Windows.Forms.CheckBox checkDirection;
    }
}
