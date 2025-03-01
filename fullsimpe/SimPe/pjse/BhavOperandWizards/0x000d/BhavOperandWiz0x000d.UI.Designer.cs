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

namespace whse.PrimitiveWizards.Wiz0x000d
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
            this.panelInteractNumber = new System.Windows.Forms.Panel();
            this.textInteractNumber = new System.Windows.Forms.TextBox();
            this.panelObjectParam = new System.Windows.Forms.Panel();
            this.textObjectParam = new System.Windows.Forms.TextBox();
            this.comboObjectParam = new System.Windows.Forms.ComboBox();
            this.comboObjectType = new System.Windows.Forms.ComboBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.checkAttrPicker = new System.Windows.Forms.CheckBox();
            this.checkReturning = new System.Windows.Forms.CheckBox();
            this.lblReturning = new System.Windows.Forms.Label();
            this.checkLinking = new System.Windows.Forms.CheckBox();
            this.lblLinking = new System.Windows.Forms.Label();
            this.comboPriority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.comboIconIndexType = new System.Windows.Forms.ComboBox();
            this.comboIconType = new System.Windows.Forms.ComboBox();
            this.lblIconObject = new System.Windows.Forms.Label();
            this.labelIconIndex = new System.Windows.Forms.Label();
            this.comboInteractNumber = new System.Windows.Forms.ComboBox();
            this.lblIntNumber = new System.Windows.Forms.Label();
            this.lblIntObject = new System.Windows.Forms.Label();
            this.textIntSim = new System.Windows.Forms.Label();
            this.lblIntSim = new System.Windows.Forms.Label();
            this.lblCallerParams = new System.Windows.Forms.Label();
            this.checkCallerParams = new System.Windows.Forms.CheckBox();
            this.lblUseName = new System.Windows.Forms.Label();
            this.checkRunCheckTree = new System.Windows.Forms.CheckBox();
            this.checkUseName = new System.Windows.Forms.CheckBox();
            this.lblRunCheckTree = new System.Windows.Forms.Label();
            this.panelDataOwner1 = new System.Windows.Forms.Panel();
            this.textDataValue1 = new System.Windows.Forms.TextBox();
            this.comboDataPicker1 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner1 = new System.Windows.Forms.ComboBox();
            this.panelDataOwner2 = new System.Windows.Forms.Panel();
            this.textDataValue2 = new System.Windows.Forms.TextBox();
            this.comboDataPicker2 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner2 = new System.Windows.Forms.ComboBox();
            this.panelDataOwner3 = new System.Windows.Forms.Panel();
            this.textDataValue3 = new System.Windows.Forms.TextBox();
            this.comboDataPicker3 = new System.Windows.Forms.ComboBox();
            this.comboDataOwner3 = new System.Windows.Forms.ComboBox();
            this.panelIconIndex = new System.Windows.Forms.Panel();
            this.textIconIndex = new System.Windows.Forms.TextBox();
            this.panelIconObject = new System.Windows.Forms.Panel();
            this.comboIconObject = new System.Windows.Forms.ComboBox();
            this.textIconObject = new System.Windows.Forms.TextBox();
            this.panelObjectLocal = new System.Windows.Forms.Panel();
            this.textObjectLocal = new System.Windows.Forms.TextBox();
            this.comboObjectLocal = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblContinuation = new System.Windows.Forms.Label();
            this.checkContinuation = new System.Windows.Forms.CheckBox();
            this.panelMain.SuspendLayout();
            this.panelInteractNumber.SuspendLayout();
            this.panelObjectParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.panelDataOwner1.SuspendLayout();
            this.panelDataOwner2.SuspendLayout();
            this.panelDataOwner3.SuspendLayout();
            this.panelIconIndex.SuspendLayout();
            this.panelIconObject.SuspendLayout();
            this.panelObjectLocal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblContinuation);
            this.panelMain.Controls.Add(this.checkContinuation);
            this.panelMain.Controls.Add(this.panelInteractNumber);
            this.panelMain.Controls.Add(this.panelObjectParam);
            this.panelMain.Controls.Add(this.comboObjectType);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.checkAttrPicker);
            this.panelMain.Controls.Add(this.checkReturning);
            this.panelMain.Controls.Add(this.lblReturning);
            this.panelMain.Controls.Add(this.checkLinking);
            this.panelMain.Controls.Add(this.lblLinking);
            this.panelMain.Controls.Add(this.comboPriority);
            this.panelMain.Controls.Add(this.lblPriority);
            this.panelMain.Controls.Add(this.comboIconIndexType);
            this.panelMain.Controls.Add(this.comboIconType);
            this.panelMain.Controls.Add(this.lblIconObject);
            this.panelMain.Controls.Add(this.labelIconIndex);
            this.panelMain.Controls.Add(this.comboInteractNumber);
            this.panelMain.Controls.Add(this.lblIntNumber);
            this.panelMain.Controls.Add(this.lblIntObject);
            this.panelMain.Controls.Add(this.textIntSim);
            this.panelMain.Controls.Add(this.lblIntSim);
            this.panelMain.Controls.Add(this.lblCallerParams);
            this.panelMain.Controls.Add(this.checkCallerParams);
            this.panelMain.Controls.Add(this.lblUseName);
            this.panelMain.Controls.Add(this.checkRunCheckTree);
            this.panelMain.Controls.Add(this.checkUseName);
            this.panelMain.Controls.Add(this.lblRunCheckTree);
            this.panelMain.Controls.Add(this.panelDataOwner1);
            this.panelMain.Controls.Add(this.panelDataOwner2);
            this.panelMain.Controls.Add(this.panelDataOwner3);
            this.panelMain.Controls.Add(this.panelIconIndex);
            this.panelMain.Controls.Add(this.panelIconObject);
            this.panelMain.Controls.Add(this.panelObjectLocal);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 315);
            this.panelMain.TabIndex = 0;
            // 
            // panelInteractNumber
            // 
            this.panelInteractNumber.Controls.Add(this.textInteractNumber);
            this.panelInteractNumber.Location = new System.Drawing.Point(196, 50);
            this.panelInteractNumber.Name = "panelInteractNumber";
            this.panelInteractNumber.Size = new System.Drawing.Size(244, 21);
            this.panelInteractNumber.TabIndex = 29;
            // 
            // textInteractNumber
            // 
            this.textInteractNumber.Location = new System.Drawing.Point(0, 0);
            this.textInteractNumber.Name = "textInteractNumber";
            this.textInteractNumber.Size = new System.Drawing.Size(60, 20);
            this.textInteractNumber.TabIndex = 3;
            // 
            // panelObjectParam
            // 
            this.panelObjectParam.Controls.Add(this.textObjectParam);
            this.panelObjectParam.Controls.Add(this.comboObjectParam);
            this.panelObjectParam.Location = new System.Drawing.Point(196, 23);
            this.panelObjectParam.Name = "panelObjectParam";
            this.panelObjectParam.Size = new System.Drawing.Size(244, 21);
            this.panelObjectParam.TabIndex = 5;
            // 
            // textObjectParam
            // 
            this.textObjectParam.Location = new System.Drawing.Point(0, 0);
            this.textObjectParam.Name = "textObjectParam";
            this.textObjectParam.Size = new System.Drawing.Size(60, 20);
            this.textObjectParam.TabIndex = 1;
            // 
            // comboObjectParam
            // 
            this.comboObjectParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboObjectParam.FormattingEnabled = true;
            this.comboObjectParam.Location = new System.Drawing.Point(0, 0);
            this.comboObjectParam.Name = "comboObjectParam";
            this.comboObjectParam.Size = new System.Drawing.Size(104, 21);
            this.comboObjectParam.TabIndex = 27;
            // 
            // comboObjectType
            // 
            this.comboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboObjectType.FormattingEnabled = true;
            this.comboObjectType.Items.AddRange(new object[] {
            "Param",
            "Local"});
            this.comboObjectType.Location = new System.Drawing.Point(100, 23);
            this.comboObjectType.Name = "comboObjectType";
            this.comboObjectType.Size = new System.Drawing.Size(90, 21);
            this.comboObjectType.TabIndex = 0;
            this.comboObjectType.SelectedIndexChanged += new System.EventHandler(this.OnObjectTypeControlChanged);
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(405, 280);
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
            this.checkDecimal.Location = new System.Drawing.Point(136, 295);
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
            this.checkAttrPicker.Location = new System.Drawing.Point(282, 295);
            this.checkAttrPicker.Name = "checkAttrPicker";
            this.checkAttrPicker.Size = new System.Drawing.Size(117, 17);
            this.checkAttrPicker.TabIndex = 18;
            this.checkAttrPicker.Text = "use Attribute picker";
            this.checkAttrPicker.UseVisualStyleBackColor = true;
            // 
            // checkReturning
            // 
            this.checkReturning.AutoSize = true;
            this.checkReturning.Location = new System.Drawing.Point(100, 232);
            this.checkReturning.Name = "checkReturning";
            this.checkReturning.Size = new System.Drawing.Size(15, 14);
            this.checkReturning.TabIndex = 15;
            this.checkReturning.UseVisualStyleBackColor = true;
            this.checkReturning.CheckedChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblReturning
            // 
            this.lblReturning.Location = new System.Drawing.Point(5, 232);
            this.lblReturning.Name = "lblReturning";
            this.lblReturning.Size = new System.Drawing.Size(95, 13);
            this.lblReturning.TabIndex = 25;
            this.lblReturning.Text = "Returning ID:";
            this.lblReturning.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkLinking
            // 
            this.checkLinking.AutoSize = true;
            this.checkLinking.Location = new System.Drawing.Point(100, 185);
            this.checkLinking.Name = "checkLinking";
            this.checkLinking.Size = new System.Drawing.Size(15, 14);
            this.checkLinking.TabIndex = 13;
            this.checkLinking.UseVisualStyleBackColor = true;
            this.checkLinking.CheckedChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblLinking
            // 
            this.lblLinking.Location = new System.Drawing.Point(5, 185);
            this.lblLinking.Name = "lblLinking";
            this.lblLinking.Size = new System.Drawing.Size(95, 13);
            this.lblLinking.TabIndex = 23;
            this.lblLinking.Text = "Link Interaction:";
            this.lblLinking.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboPriority
            // 
            this.comboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Items.AddRange(new object[] {
            "Inherited",
            "Maximum",
            "Autonomous",
            "User Driven"});
            this.comboPriority.Location = new System.Drawing.Point(100, 104);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(90, 21);
            this.comboPriority.TabIndex = 5;
            // 
            // lblPriority
            // 
            this.lblPriority.Location = new System.Drawing.Point(5, 107);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(95, 13);
            this.lblPriority.TabIndex = 14;
            this.lblPriority.Text = "Priority:";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboIconIndexType
            // 
            this.comboIconIndexType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIconIndexType.FormattingEnabled = true;
            this.comboIconIndexType.Items.AddRange(new object[] {
            "Literal",
            "In T6"});
            this.comboIconIndexType.Location = new System.Drawing.Point(100, 158);
            this.comboIconIndexType.Name = "comboIconIndexType";
            this.comboIconIndexType.Size = new System.Drawing.Size(90, 21);
            this.comboIconIndexType.TabIndex = 10;
            this.comboIconIndexType.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // comboIconType
            // 
            this.comboIconType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIconType.FormattingEnabled = true;
            this.comboIconType.Items.AddRange(new object[] {
            "Target",
            "Local",
            "In T4/5"});
            this.comboIconType.Location = new System.Drawing.Point(100, 131);
            this.comboIconType.Name = "comboIconType";
            this.comboIconType.Size = new System.Drawing.Size(90, 21);
            this.comboIconType.TabIndex = 7;
            this.comboIconType.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblIconObject
            // 
            this.lblIconObject.Location = new System.Drawing.Point(5, 134);
            this.lblIconObject.Name = "lblIconObject";
            this.lblIconObject.Size = new System.Drawing.Size(95, 13);
            this.lblIconObject.TabIndex = 9;
            this.lblIconObject.Text = "Icon Object:";
            this.lblIconObject.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelIconIndex
            // 
            this.labelIconIndex.Location = new System.Drawing.Point(5, 161);
            this.labelIconIndex.Name = "labelIconIndex";
            this.labelIconIndex.Size = new System.Drawing.Size(95, 13);
            this.labelIconIndex.TabIndex = 8;
            this.labelIconIndex.Text = "Icon Index:";
            this.labelIconIndex.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboInteractNumber
            // 
            this.comboInteractNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInteractNumber.FormattingEnabled = true;
            this.comboInteractNumber.Items.AddRange(new object[] {
            "Literal",
            "Variable",
            "Last FBA"});
            this.comboInteractNumber.Location = new System.Drawing.Point(100, 50);
            this.comboInteractNumber.Name = "comboInteractNumber";
            this.comboInteractNumber.Size = new System.Drawing.Size(90, 21);
            this.comboInteractNumber.TabIndex = 2;
            this.comboInteractNumber.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblIntNumber
            // 
            this.lblIntNumber.Location = new System.Drawing.Point(5, 53);
            this.lblIntNumber.Name = "lblIntNumber";
            this.lblIntNumber.Size = new System.Drawing.Size(95, 13);
            this.lblIntNumber.TabIndex = 5;
            this.lblIntNumber.Text = "Interaction:";
            this.lblIntNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIntObject
            // 
            this.lblIntObject.Location = new System.Drawing.Point(5, 27);
            this.lblIntObject.Name = "lblIntObject";
            this.lblIntObject.Size = new System.Drawing.Size(95, 13);
            this.lblIntObject.TabIndex = 2;
            this.lblIntObject.Text = "Object:";
            this.lblIntObject.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textIntSim
            // 
            this.textIntSim.AutoSize = true;
            this.textIntSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIntSim.Location = new System.Drawing.Point(97, 7);
            this.textIntSim.Name = "textIntSim";
            this.textIntSim.Size = new System.Drawing.Size(81, 13);
            this.textIntSim.TabIndex = 1;
            this.textIntSim.Text = "Always in SO";
            // 
            // lblIntSim
            // 
            this.lblIntSim.Location = new System.Drawing.Point(5, 7);
            this.lblIntSim.Name = "lblIntSim";
            this.lblIntSim.Size = new System.Drawing.Size(95, 13);
            this.lblIntSim.TabIndex = 0;
            this.lblIntSim.Text = "Sim:";
            this.lblIntSim.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCallerParams
            // 
            this.lblCallerParams.Location = new System.Drawing.Point(285, 107);
            this.lblCallerParams.Name = "lblCallerParams";
            this.lblCallerParams.Size = new System.Drawing.Size(130, 13);
            this.lblCallerParams.TabIndex = 15;
            this.lblCallerParams.Text = "Passing Callers Params:";
            this.lblCallerParams.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkCallerParams
            // 
            this.checkCallerParams.AutoSize = true;
            this.checkCallerParams.Location = new System.Drawing.Point(415, 107);
            this.checkCallerParams.Name = "checkCallerParams";
            this.checkCallerParams.Size = new System.Drawing.Size(15, 14);
            this.checkCallerParams.TabIndex = 6;
            this.checkCallerParams.UseVisualStyleBackColor = true;
            // 
            // lblUseName
            // 
            this.lblUseName.Location = new System.Drawing.Point(315, 134);
            this.lblUseName.Name = "lblUseName";
            this.lblUseName.Size = new System.Drawing.Size(100, 13);
            this.lblUseName.TabIndex = 16;
            this.lblUseName.Text = "Use Name:";
            this.lblUseName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkRunCheckTree
            // 
            this.checkRunCheckTree.AutoSize = true;
            this.checkRunCheckTree.Location = new System.Drawing.Point(415, 161);
            this.checkRunCheckTree.Name = "checkRunCheckTree";
            this.checkRunCheckTree.Size = new System.Drawing.Size(15, 14);
            this.checkRunCheckTree.TabIndex = 12;
            this.checkRunCheckTree.UseVisualStyleBackColor = true;
            // 
            // checkUseName
            // 
            this.checkUseName.AutoSize = true;
            this.checkUseName.Location = new System.Drawing.Point(415, 134);
            this.checkUseName.Name = "checkUseName";
            this.checkUseName.Size = new System.Drawing.Size(15, 14);
            this.checkUseName.TabIndex = 9;
            this.checkUseName.UseVisualStyleBackColor = true;
            // 
            // lblRunCheckTree
            // 
            this.lblRunCheckTree.Location = new System.Drawing.Point(285, 161);
            this.lblRunCheckTree.Name = "lblRunCheckTree";
            this.lblRunCheckTree.Size = new System.Drawing.Size(130, 13);
            this.lblRunCheckTree.TabIndex = 17;
            this.lblRunCheckTree.Text = "Force Run Check Tree:";
            this.lblRunCheckTree.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelDataOwner1
            // 
            this.panelDataOwner1.Controls.Add(this.textDataValue1);
            this.panelDataOwner1.Controls.Add(this.comboDataPicker1);
            this.panelDataOwner1.Controls.Add(this.comboDataOwner1);
            this.panelDataOwner1.Location = new System.Drawing.Point(0, 77);
            this.panelDataOwner1.Name = "panelDataOwner1";
            this.panelDataOwner1.Size = new System.Drawing.Size(440, 21);
            this.panelDataOwner1.TabIndex = 4;
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
            // panelDataOwner2
            // 
            this.panelDataOwner2.Controls.Add(this.textDataValue2);
            this.panelDataOwner2.Controls.Add(this.comboDataPicker2);
            this.panelDataOwner2.Controls.Add(this.comboDataOwner2);
            this.panelDataOwner2.Location = new System.Drawing.Point(0, 205);
            this.panelDataOwner2.Name = "panelDataOwner2";
            this.panelDataOwner2.Size = new System.Drawing.Size(440, 21);
            this.panelDataOwner2.TabIndex = 14;
            // 
            // textDataValue2
            // 
            this.textDataValue2.Location = new System.Drawing.Point(310, 0);
            this.textDataValue2.Name = "textDataValue2";
            this.textDataValue2.Size = new System.Drawing.Size(120, 20);
            this.textDataValue2.TabIndex = 1;
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
            // panelDataOwner3
            // 
            this.panelDataOwner3.Controls.Add(this.textDataValue3);
            this.panelDataOwner3.Controls.Add(this.comboDataPicker3);
            this.panelDataOwner3.Controls.Add(this.comboDataOwner3);
            this.panelDataOwner3.Location = new System.Drawing.Point(0, 252);
            this.panelDataOwner3.Name = "panelDataOwner3";
            this.panelDataOwner3.Size = new System.Drawing.Size(440, 21);
            this.panelDataOwner3.TabIndex = 16;
            // 
            // textDataValue3
            // 
            this.textDataValue3.Location = new System.Drawing.Point(310, 0);
            this.textDataValue3.Name = "textDataValue3";
            this.textDataValue3.Size = new System.Drawing.Size(120, 20);
            this.textDataValue3.TabIndex = 1;
            // 
            // comboDataPicker3
            // 
            this.comboDataPicker3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataPicker3.FormattingEnabled = true;
            this.comboDataPicker3.Location = new System.Drawing.Point(310, 0);
            this.comboDataPicker3.Name = "comboDataPicker3";
            this.comboDataPicker3.Size = new System.Drawing.Size(120, 21);
            this.comboDataPicker3.TabIndex = 2;
            // 
            // comboDataOwner3
            // 
            this.comboDataOwner3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataOwner3.FormattingEnabled = true;
            this.comboDataOwner3.Location = new System.Drawing.Point(100, 0);
            this.comboDataOwner3.Name = "comboDataOwner3";
            this.comboDataOwner3.Size = new System.Drawing.Size(200, 21);
            this.comboDataOwner3.TabIndex = 0;
            // 
            // panelIconIndex
            // 
            this.panelIconIndex.Controls.Add(this.textIconIndex);
            this.panelIconIndex.Location = new System.Drawing.Point(196, 158);
            this.panelIconIndex.Name = "panelIconIndex";
            this.panelIconIndex.Size = new System.Drawing.Size(244, 21);
            this.panelIconIndex.TabIndex = 30;
            // 
            // textIconIndex
            // 
            this.textIconIndex.Location = new System.Drawing.Point(0, 0);
            this.textIconIndex.Name = "textIconIndex";
            this.textIconIndex.Size = new System.Drawing.Size(60, 20);
            this.textIconIndex.TabIndex = 11;
            // 
            // panelIconObject
            // 
            this.panelIconObject.Controls.Add(this.comboIconObject);
            this.panelIconObject.Controls.Add(this.textIconObject);
            this.panelIconObject.Location = new System.Drawing.Point(196, 131);
            this.panelIconObject.Name = "panelIconObject";
            this.panelIconObject.Size = new System.Drawing.Size(244, 21);
            this.panelIconObject.TabIndex = 29;
            // 
            // comboIconObject
            // 
            this.comboIconObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIconObject.FormattingEnabled = true;
            this.comboIconObject.Location = new System.Drawing.Point(0, 0);
            this.comboIconObject.Name = "comboIconObject";
            this.comboIconObject.Size = new System.Drawing.Size(104, 21);
            this.comboIconObject.TabIndex = 29;
            // 
            // textIconObject
            // 
            this.textIconObject.Location = new System.Drawing.Point(0, 0);
            this.textIconObject.Name = "textIconObject";
            this.textIconObject.Size = new System.Drawing.Size(60, 20);
            this.textIconObject.TabIndex = 8;
            // 
            // panelObjectLocal
            // 
            this.panelObjectLocal.Controls.Add(this.textObjectLocal);
            this.panelObjectLocal.Controls.Add(this.comboObjectLocal);
            this.panelObjectLocal.Location = new System.Drawing.Point(196, 23);
            this.panelObjectLocal.Name = "panelObjectLocal";
            this.panelObjectLocal.Size = new System.Drawing.Size(244, 21);
            this.panelObjectLocal.TabIndex = 5;
            // 
            // textObjectLocal
            // 
            this.textObjectLocal.Location = new System.Drawing.Point(0, 0);
            this.textObjectLocal.Name = "textObjectLocal";
            this.textObjectLocal.Size = new System.Drawing.Size(60, 20);
            this.textObjectLocal.TabIndex = 26;
            // 
            // comboObjectLocal
            // 
            this.comboObjectLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboObjectLocal.FormattingEnabled = true;
            this.comboObjectLocal.Location = new System.Drawing.Point(0, 0);
            this.comboObjectLocal.Name = "comboObjectLocal";
            this.comboObjectLocal.Size = new System.Drawing.Size(104, 21);
            this.comboObjectLocal.TabIndex = 28;
            // 
            // lblContinuation
            // 
            this.lblContinuation.Location = new System.Drawing.Point(285, 185);
            this.lblContinuation.Name = "lblContinuation";
            this.lblContinuation.Size = new System.Drawing.Size(130, 13);
            this.lblContinuation.TabIndex = 32;
            this.lblContinuation.Text = "Continuation:";
            this.lblContinuation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblContinuation, "See https://www.picknmixmods.com/Sims2/Notes/PushIntOp3Bit3/PushIntOp3Bit3.html");
            // 
            // checkContinuation
            // 
            this.checkContinuation.AutoSize = true;
            this.checkContinuation.Location = new System.Drawing.Point(415, 185);
            this.checkContinuation.Name = "checkContinuation";
            this.checkContinuation.Size = new System.Drawing.Size(15, 14);
            this.checkContinuation.TabIndex = 31;
            this.toolTip.SetToolTip(this.checkContinuation, "See https://www.picknmixmods.com/Sims2/Notes/PushIntOp3Bit3/PushIntOp3Bit3.html");
            this.checkContinuation.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 315);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelInteractNumber.ResumeLayout(false);
            this.panelInteractNumber.PerformLayout();
            this.panelObjectParam.ResumeLayout(false);
            this.panelObjectParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.panelDataOwner1.ResumeLayout(false);
            this.panelDataOwner1.PerformLayout();
            this.panelDataOwner2.ResumeLayout(false);
            this.panelDataOwner2.PerformLayout();
            this.panelDataOwner3.ResumeLayout(false);
            this.panelDataOwner3.PerformLayout();
            this.panelIconIndex.ResumeLayout(false);
            this.panelIconIndex.PerformLayout();
            this.panelIconObject.ResumeLayout(false);
            this.panelIconObject.PerformLayout();
            this.panelObjectLocal.ResumeLayout(false);
            this.panelObjectLocal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblIntSim;
        private System.Windows.Forms.ComboBox comboInteractNumber;
        private System.Windows.Forms.Label lblIntNumber;
        private System.Windows.Forms.TextBox textObjectParam;
        private System.Windows.Forms.ComboBox comboObjectType;
        private System.Windows.Forms.Label lblIntObject;
        private System.Windows.Forms.Label textIntSim;
        private System.Windows.Forms.Label lblIconObject;
        private System.Windows.Forms.Label labelIconIndex;
        private System.Windows.Forms.TextBox textInteractNumber;
        private System.Windows.Forms.Label lblUseName;
        private System.Windows.Forms.Label lblCallerParams;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.TextBox textIconIndex;
        private System.Windows.Forms.ComboBox comboIconIndexType;
        private System.Windows.Forms.TextBox textIconObject;
        private System.Windows.Forms.ComboBox comboIconType;
        private System.Windows.Forms.Label lblReturning;
        private System.Windows.Forms.CheckBox checkLinking;
        private System.Windows.Forms.Label lblLinking;
        private System.Windows.Forms.ComboBox comboPriority;
        private System.Windows.Forms.CheckBox checkRunCheckTree;
        private System.Windows.Forms.CheckBox checkUseName;
        private System.Windows.Forms.CheckBox checkCallerParams;
        private System.Windows.Forms.Label lblRunCheckTree;
        private System.Windows.Forms.CheckBox checkReturning;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.CheckBox checkAttrPicker;
        private System.Windows.Forms.TextBox textDataValue2;
        private System.Windows.Forms.ComboBox comboDataPicker2;
        private System.Windows.Forms.ComboBox comboDataOwner2;
        private System.Windows.Forms.TextBox textDataValue3;
        private System.Windows.Forms.ComboBox comboDataPicker3;
        private System.Windows.Forms.ComboBox comboDataOwner3;
        private System.Windows.Forms.TextBox textDataValue1;
        private System.Windows.Forms.ComboBox comboDataPicker1;
        private System.Windows.Forms.ComboBox comboDataOwner1;
        private System.Windows.Forms.Panel panelDataOwner1;
        private System.Windows.Forms.Panel panelDataOwner2;
        private System.Windows.Forms.Panel panelDataOwner3;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox comboObjectLocal;
        private System.Windows.Forms.ComboBox comboObjectParam;
        private System.Windows.Forms.TextBox textObjectLocal;
        private System.Windows.Forms.ComboBox comboIconObject;
        private System.Windows.Forms.Panel panelObjectParam;
        private System.Windows.Forms.Panel panelObjectLocal;
        private System.Windows.Forms.Panel panelIconObject;
        private System.Windows.Forms.Panel panelInteractNumber;
        private System.Windows.Forms.Panel panelIconIndex;
        private System.Windows.Forms.Label lblContinuation;
        private System.Windows.Forms.CheckBox checkContinuation;
    }
}
