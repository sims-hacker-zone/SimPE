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

namespace whse.PrimitiveWizards.Wiz0x002a
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
            this.lblMoveInSim = new System.Windows.Forms.Label();
            this.lblFailIfTileNonEmpty = new System.Windows.Forms.Label();
            this.lblCopyMaterial = new System.Windows.Forms.Label();
            this.lblPassToToMain = new System.Windows.Forms.Label();
            this.comboCreateWhat = new System.Windows.Forms.ComboBox();
            this.textSlot = new System.Windows.Forms.TextBox();
            this.checkDecimal = new System.Windows.Forms.CheckBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.checkCopyMaterials = new System.Windows.Forms.CheckBox();
            this.checkMoveInSim = new System.Windows.Forms.CheckBox();
            this.textLocal = new System.Windows.Forms.TextBox();
            this.checkPassT0ToMain = new System.Windows.Forms.CheckBox();
            this.checkFailIfTileNonEmpty = new System.Windows.Forms.CheckBox();
            this.comboCreateHow = new System.Windows.Forms.ComboBox();
            this.lblCreateHow = new System.Windows.Forms.Label();
            this.comboCreateWhere = new System.Windows.Forms.ComboBox();
            this.lblCreateWhere = new System.Windows.Forms.Label();
            this.lblGuid = new System.Windows.Forms.Label();
            this.textGUID = new System.Windows.Forms.TextBox();
            this.lblCreateWhat = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblMoveInSim);
            this.panelMain.Controls.Add(this.lblFailIfTileNonEmpty);
            this.panelMain.Controls.Add(this.lblCopyMaterial);
            this.panelMain.Controls.Add(this.lblPassToToMain);
            this.panelMain.Controls.Add(this.comboCreateWhat);
            this.panelMain.Controls.Add(this.textSlot);
            this.panelMain.Controls.Add(this.checkDecimal);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.checkCopyMaterials);
            this.panelMain.Controls.Add(this.checkMoveInSim);
            this.panelMain.Controls.Add(this.textLocal);
            this.panelMain.Controls.Add(this.checkPassT0ToMain);
            this.panelMain.Controls.Add(this.checkFailIfTileNonEmpty);
            this.panelMain.Controls.Add(this.comboCreateHow);
            this.panelMain.Controls.Add(this.lblCreateHow);
            this.panelMain.Controls.Add(this.comboCreateWhere);
            this.panelMain.Controls.Add(this.lblCreateWhere);
            this.panelMain.Controls.Add(this.lblGuid);
            this.panelMain.Controls.Add(this.textGUID);
            this.panelMain.Controls.Add(this.lblCreateWhat);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(440, 195);
            this.panelMain.TabIndex = 0;
            // 
            // lblMoveInSim
            // 
            this.lblMoveInSim.Location = new System.Drawing.Point(5, 166);
            this.lblMoveInSim.Name = "lblMoveInSim";
            this.lblMoveInSim.Size = new System.Drawing.Size(95, 13);
            this.lblMoveInSim.TabIndex = 39;
            this.lblMoveInSim.Text = "Move In Sim:";
            this.lblMoveInSim.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblMoveInSim, "Move in a new Sim");
            // 
            // lblFailIfTileNonEmpty
            // 
            this.lblFailIfTileNonEmpty.Location = new System.Drawing.Point(5, 146);
            this.lblFailIfTileNonEmpty.Name = "lblFailIfTileNonEmpty";
            this.lblFailIfTileNonEmpty.Size = new System.Drawing.Size(95, 13);
            this.lblFailIfTileNonEmpty.TabIndex = 38;
            this.lblFailIfTileNonEmpty.Text = "Fail If Non-Empty:";
            this.lblFailIfTileNonEmpty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblFailIfTileNonEmpty, "Fail if tile isn\'t empty");
            // 
            // lblCopyMaterial
            // 
            this.lblCopyMaterial.Location = new System.Drawing.Point(5, 126);
            this.lblCopyMaterial.Name = "lblCopyMaterial";
            this.lblCopyMaterial.Size = new System.Drawing.Size(95, 13);
            this.lblCopyMaterial.TabIndex = 37;
            this.lblCopyMaterial.Text = "Copy Materials:";
            this.lblCopyMaterial.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblCopyMaterial, "Copy materials from object in Temp 5");
            // 
            // lblPassToToMain
            // 
            this.lblPassToToMain.Location = new System.Drawing.Point(5, 106);
            this.lblPassToToMain.Name = "lblPassToToMain";
            this.lblPassToToMain.Size = new System.Drawing.Size(95, 13);
            this.lblPassToToMain.TabIndex = 36;
            this.lblPassToToMain.Text = "Pass T0 to Main:";
            this.lblPassToToMain.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboCreateWhat
            // 
            this.comboCreateWhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCreateWhat.FormattingEnabled = true;
            this.comboCreateWhat.Items.AddRange(new object[] {
            "Object of GUID",
            "Object of GUID in T0/1",
            "Object from My Temp Token",
            "Sim from NID in SO"});
            this.comboCreateWhat.Location = new System.Drawing.Point(100, 4);
            this.comboCreateWhat.Name = "comboCreateWhat";
            this.comboCreateWhat.Size = new System.Drawing.Size(200, 21);
            this.comboCreateWhat.TabIndex = 0;
            this.comboCreateWhat.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // textSlot
            // 
            this.textSlot.Location = new System.Drawing.Point(310, 52);
            this.textSlot.Name = "textSlot";
            this.textSlot.Size = new System.Drawing.Size(50, 20);
            this.textSlot.TabIndex = 3;
            // 
            // checkDecimal
            // 
            this.checkDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDecimal.AutoSize = true;
            this.checkDecimal.Location = new System.Drawing.Point(254, 175);
            this.checkDecimal.Name = "checkDecimal";
            this.checkDecimal.Size = new System.Drawing.Size(140, 17);
            this.checkDecimal.TabIndex = 9;
            this.checkDecimal.Text = "Decimal (except Consts)";
            this.checkDecimal.UseVisualStyleBackColor = true;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(400, 160);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 16;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // checkCopyMaterials
            // 
            this.checkCopyMaterials.AutoSize = true;
            this.checkCopyMaterials.Location = new System.Drawing.Point(100, 126);
            this.checkCopyMaterials.Name = "checkCopyMaterials";
            this.checkCopyMaterials.Size = new System.Drawing.Size(15, 14);
            this.checkCopyMaterials.TabIndex = 6;
            this.toolTip.SetToolTip(this.checkCopyMaterials, "Copy materials from object in Temp 5");
            this.checkCopyMaterials.UseVisualStyleBackColor = true;
            // 
            // checkMoveInSim
            // 
            this.checkMoveInSim.AutoSize = true;
            this.checkMoveInSim.Location = new System.Drawing.Point(100, 166);
            this.checkMoveInSim.Name = "checkMoveInSim";
            this.checkMoveInSim.Size = new System.Drawing.Size(15, 14);
            this.checkMoveInSim.TabIndex = 8;
            this.toolTip.SetToolTip(this.checkMoveInSim, "Move in a new Sim");
            this.checkMoveInSim.UseVisualStyleBackColor = true;
            // 
            // textLocal
            // 
            this.textLocal.Location = new System.Drawing.Point(310, 52);
            this.textLocal.Name = "textLocal";
            this.textLocal.Size = new System.Drawing.Size(50, 20);
            this.textLocal.TabIndex = 12;
            // 
            // checkPassT0ToMain
            // 
            this.checkPassT0ToMain.AutoSize = true;
            this.checkPassT0ToMain.Location = new System.Drawing.Point(100, 106);
            this.checkPassT0ToMain.Name = "checkPassT0ToMain";
            this.checkPassT0ToMain.Size = new System.Drawing.Size(15, 14);
            this.checkPassT0ToMain.TabIndex = 5;
            this.checkPassT0ToMain.UseVisualStyleBackColor = true;
            // 
            // checkFailIfTileNonEmpty
            // 
            this.checkFailIfTileNonEmpty.AutoSize = true;
            this.checkFailIfTileNonEmpty.Location = new System.Drawing.Point(100, 146);
            this.checkFailIfTileNonEmpty.Name = "checkFailIfTileNonEmpty";
            this.checkFailIfTileNonEmpty.Size = new System.Drawing.Size(15, 14);
            this.checkFailIfTileNonEmpty.TabIndex = 7;
            this.toolTip.SetToolTip(this.checkFailIfTileNonEmpty, "Fail if tile isn\'t empty");
            this.checkFailIfTileNonEmpty.UseVisualStyleBackColor = true;
            // 
            // comboCreateHow
            // 
            this.comboCreateHow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCreateHow.FormattingEnabled = true;
            this.comboCreateHow.Items.AddRange(new object[] {
            "Normally",
            "Do Not Duplicate",
            "Transfer SO to new"});
            this.comboCreateHow.Location = new System.Drawing.Point(100, 79);
            this.comboCreateHow.Name = "comboCreateHow";
            this.comboCreateHow.Size = new System.Drawing.Size(200, 21);
            this.comboCreateHow.TabIndex = 4;
            // 
            // lblCreateHow
            // 
            this.lblCreateHow.Location = new System.Drawing.Point(5, 82);
            this.lblCreateHow.Name = "lblCreateHow";
            this.lblCreateHow.Size = new System.Drawing.Size(95, 13);
            this.lblCreateHow.TabIndex = 5;
            this.lblCreateHow.Text = "Create How:";
            this.lblCreateHow.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboCreateWhere
            // 
            this.comboCreateWhere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCreateWhere.FormattingEnabled = true;
            this.comboCreateWhere.Items.AddRange(new object[] {
            "In Front of Me",
            "On Top of Me",
            "In My Hand",
            "In Front of SO",
            "In SO\'s Slot",
            "Underneath Me",
            "Out-of-World",
            "Below Object in Param 0",
            "Below Object in Local",
            "Next to Me in Dir of Object in Local",
            "In User Defined Slot of Object in T0"});
            this.comboCreateWhere.Location = new System.Drawing.Point(100, 52);
            this.comboCreateWhere.Name = "comboCreateWhere";
            this.comboCreateWhere.Size = new System.Drawing.Size(200, 21);
            this.comboCreateWhere.TabIndex = 2;
            this.comboCreateWhere.SelectedIndexChanged += new System.EventHandler(this.OnControlChanged);
            // 
            // lblCreateWhere
            // 
            this.lblCreateWhere.Location = new System.Drawing.Point(5, 56);
            this.lblCreateWhere.Name = "lblCreateWhere";
            this.lblCreateWhere.Size = new System.Drawing.Size(95, 13);
            this.lblCreateWhere.TabIndex = 3;
            this.lblCreateWhere.Text = "Create Where:";
            this.lblCreateWhere.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(100, 30);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(118, 13);
            this.lblGuid.TabIndex = 2;
            this.lblGuid.Text = "GUID {guid} (\"{name}\")";
            // 
            // textGUID
            // 
            this.textGUID.Location = new System.Drawing.Point(310, 4);
            this.textGUID.Name = "textGUID";
            this.textGUID.Size = new System.Drawing.Size(120, 20);
            this.textGUID.TabIndex = 1;
            this.textGUID.TextChanged += new System.EventHandler(this.OnGuidChanged);
            this.textGUID.Validating += new System.ComponentModel.CancelEventHandler(this.OnGuidValidating);
            this.textGUID.Validated += new System.EventHandler(this.OnGuidValidated);
            // 
            // lblCreateWhat
            // 
            this.lblCreateWhat.Location = new System.Drawing.Point(5, 7);
            this.lblCreateWhat.Name = "lblCreateWhat";
            this.lblCreateWhat.Size = new System.Drawing.Size(95, 13);
            this.lblCreateWhat.TabIndex = 0;
            this.lblCreateWhat.Text = "Create What:";
            this.lblCreateWhat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(440, 195);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblGuid;
        private System.Windows.Forms.TextBox textGUID;
        private System.Windows.Forms.Label lblCreateWhat;
        private System.Windows.Forms.ComboBox comboCreateWhere;
        private System.Windows.Forms.Label lblCreateWhere;
        private System.Windows.Forms.CheckBox checkFailIfTileNonEmpty;
        private System.Windows.Forms.ComboBox comboCreateHow;
        private System.Windows.Forms.Label lblCreateHow;
        private System.Windows.Forms.CheckBox checkPassT0ToMain;
        private System.Windows.Forms.CheckBox checkCopyMaterials;
        private System.Windows.Forms.CheckBox checkMoveInSim;
        private System.Windows.Forms.TextBox textLocal;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.CheckBox checkDecimal;
        private System.Windows.Forms.TextBox textSlot;
        private System.Windows.Forms.ComboBox comboCreateWhat;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblCopyMaterial;
        private System.Windows.Forms.Label lblPassToToMain;
        private System.Windows.Forms.Label lblMoveInSim;
        private System.Windows.Forms.Label lblFailIfTileNonEmpty;
    }
}
