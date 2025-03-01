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

namespace whse.PrimitiveWizards.Wiz0x0014
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
            this.lblCheckTreeOnly = new System.Windows.Forms.Label();
            this.checkCheckTreeOnly = new System.Windows.Forms.CheckBox();
            this.lblPassParams = new System.Windows.Forms.Label();
            this.checkPassParams = new System.Windows.Forms.CheckBox();
            this.iconPnM = new System.Windows.Forms.PictureBox();
            this.comboFunction = new System.Windows.Forms.ComboBox();
            this.lblFunction = new System.Windows.Forms.Label();
            this.lblChangeIcon = new System.Windows.Forms.Label();
            this.checkChangeIcon = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.lblCheckTreeOnly);
            this.panelMain.Controls.Add(this.checkCheckTreeOnly);
            this.panelMain.Controls.Add(this.lblPassParams);
            this.panelMain.Controls.Add(this.checkPassParams);
            this.panelMain.Controls.Add(this.iconPnM);
            this.panelMain.Controls.Add(this.comboFunction);
            this.panelMain.Controls.Add(this.lblFunction);
            this.panelMain.Controls.Add(this.lblChangeIcon);
            this.panelMain.Controls.Add(this.checkChangeIcon);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(300, 100);
            this.panelMain.TabIndex = 0;
            // 
            // lblCheckTreeOnly
            // 
            this.lblCheckTreeOnly.Location = new System.Drawing.Point(5, 31);
            this.lblCheckTreeOnly.Name = "lblCheckTreeOnly";
            this.lblCheckTreeOnly.Size = new System.Drawing.Size(95, 13);
            this.lblCheckTreeOnly.TabIndex = 22;
            this.lblCheckTreeOnly.Text = "Check Tree Only:";
            this.lblCheckTreeOnly.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblCheckTreeOnly, "Running check tree only");
            // 
            // checkCheckTreeOnly
            // 
            this.checkCheckTreeOnly.AccessibleDescription = "";
            this.checkCheckTreeOnly.AutoSize = true;
            this.checkCheckTreeOnly.Location = new System.Drawing.Point(100, 31);
            this.checkCheckTreeOnly.Name = "checkCheckTreeOnly";
            this.checkCheckTreeOnly.Size = new System.Drawing.Size(15, 14);
            this.checkCheckTreeOnly.TabIndex = 21;
            this.toolTip.SetToolTip(this.checkCheckTreeOnly, "Running check tree only");
            this.checkCheckTreeOnly.UseVisualStyleBackColor = true;
            // 
            // lblPassParams
            // 
            this.lblPassParams.Location = new System.Drawing.Point(5, 51);
            this.lblPassParams.Name = "lblPassParams";
            this.lblPassParams.Size = new System.Drawing.Size(95, 13);
            this.lblPassParams.TabIndex = 20;
            this.lblPassParams.Text = "Pass Params:";
            this.lblPassParams.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.lblPassParams, "Passing parameters from calling tree");
            // 
            // checkPassParams
            // 
            this.checkPassParams.AutoSize = true;
            this.checkPassParams.Location = new System.Drawing.Point(100, 51);
            this.checkPassParams.Name = "checkPassParams";
            this.checkPassParams.Size = new System.Drawing.Size(15, 14);
            this.checkPassParams.TabIndex = 1;
            this.toolTip.SetToolTip(this.checkPassParams, "Passing parameters from calling tree");
            this.checkPassParams.UseVisualStyleBackColor = true;
            // 
            // iconPnM
            // 
            this.iconPnM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.iconPnM.Image = SimPe.Properties.Resources.MinionWithNotebook;
			this.iconPnM.Location = new System.Drawing.Point(265, 65);
            this.iconPnM.Name = "iconPnM";
            this.iconPnM.Size = new System.Drawing.Size(32, 32);
            this.iconPnM.TabIndex = 17;
            this.iconPnM.TabStop = false;
            this.toolTip.SetToolTip(this.iconPnM, "Primitive wizard by Pick\'n\'Mix (whoward69)\r\nhttps://www.picknmixmods.com/Sims2/");
            // 
            // comboFunction
            // 
            this.comboFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFunction.FormattingEnabled = true;
            this.comboFunction.Items.AddRange(new object[] {
            "Prepare Food",
            "Cook Food",
            "Flat Surface",
            "Dispose",
            "Eat",
            "Pick Up From Slot",
            "Wash Dish",
            "Eating Surface",
            "Sit",
            "Stand",
            "Serving Surface",
            "Clean",
            "Garden",
            "Wash Hands",
            "Repair",
            "Restock",
            "{Wash Clothes}",
            "Message Handler",
            "Pre Route",
            "Post Route",
            "Goal Check",
            "Reaction Handler",
            "Along Route Callback",
            "Awareness",
            "Reset",
            "Loot At Target",
            "Utility State Change",
            "Global Awareness"});
            this.comboFunction.Location = new System.Drawing.Point(100, 4);
            this.comboFunction.Name = "comboFunction";
            this.comboFunction.Size = new System.Drawing.Size(150, 21);
            this.comboFunction.TabIndex = 0;
            // 
            // lblFunction
            // 
            this.lblFunction.Location = new System.Drawing.Point(5, 7);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(95, 13);
            this.lblFunction.TabIndex = 2;
            this.lblFunction.Text = "Function:";
            this.lblFunction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblChangeIcon
            // 
            this.lblChangeIcon.Location = new System.Drawing.Point(5, 73);
            this.lblChangeIcon.Name = "lblChangeIcon";
            this.lblChangeIcon.Size = new System.Drawing.Size(95, 13);
            this.lblChangeIcon.TabIndex = 15;
            this.lblChangeIcon.Text = "Change Icon:";
            this.lblChangeIcon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkChangeIcon
            // 
            this.checkChangeIcon.AutoSize = true;
            this.checkChangeIcon.Location = new System.Drawing.Point(100, 73);
            this.checkChangeIcon.Name = "checkChangeIcon";
            this.checkChangeIcon.Size = new System.Drawing.Size(15, 14);
            this.checkChangeIcon.TabIndex = 2;
            this.checkChangeIcon.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(300, 100);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPnM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.ComboBox comboFunction;
        private System.Windows.Forms.Label lblChangeIcon;
        private System.Windows.Forms.CheckBox checkChangeIcon;
        private System.Windows.Forms.PictureBox iconPnM;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblPassParams;
        private System.Windows.Forms.CheckBox checkPassParams;
        private System.Windows.Forms.Label lblCheckTreeOnly;
        private System.Windows.Forms.CheckBox checkCheckTreeOnly;
    }
}
