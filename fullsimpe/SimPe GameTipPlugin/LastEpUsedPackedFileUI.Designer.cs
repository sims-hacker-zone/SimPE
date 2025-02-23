using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Plugin
{
    partial class LastEPusePackedFileUI
    {

        private void InitializeComponent()
        {
            this.CatawayPnl = new System.Windows.Forms.Panel();
            this.lbMission = new System.Windows.Forms.Label();
            this.btfore = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.preveplbl = new System.Windows.Forms.Label();
            this.previep = new System.Windows.Forms.TextBox();
            this.CatawayPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // CatawayPnl
            // 
            this.CatawayPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CatawayPnl.Controls.Add(this.lbMission);
            this.CatawayPnl.Controls.Add(this.btfore);
            this.CatawayPnl.Controls.Add(this.btBack);
            this.CatawayPnl.Location = new System.Drawing.Point(1000, 24);
            this.CatawayPnl.Name = "CatawayPnl";
            this.CatawayPnl.Size = new System.Drawing.Size(300, 390);
            this.CatawayPnl.TabIndex = 7;
            this.CatawayPnl.Visible = false;
            // 
            // lbMission
            // 
            this.lbMission.AutoSize = true;
            this.lbMission.BackColor = System.Drawing.Color.Transparent;
            this.lbMission.Location = new System.Drawing.Point(120, 10);
            this.lbMission.Name = "lbMission";
            this.lbMission.Size = new System.Drawing.Size(61, 19);
            this.lbMission.TabIndex = 2;
            this.lbMission.Text = "Mission";
            // 
            // btfore
            // 
            this.btfore.Location = new System.Drawing.Point(65, 3);
            this.btfore.Name = "btfore";
            this.btfore.Size = new System.Drawing.Size(43, 32);
            this.btfore.TabIndex = 1;
            this.btfore.Text = ">>";
            this.btfore.UseVisualStyleBackColor = true;
            this.btfore.Click += new System.EventHandler(this.btfore_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(3, 3);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(43, 32);
            this.btBack.TabIndex = 0;
            this.btBack.Text = "<<";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Blackadder ITC", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Boobies Make me Happy!";
            this.label1.Visible = false;
            // 
            // preveplbl
            // 
            this.preveplbl.AutoSize = true;
            this.preveplbl.BackColor = System.Drawing.Color.Transparent;
            this.preveplbl.Location = new System.Drawing.Point(218, 94);
            this.preveplbl.Name = "preveplbl";
            this.preveplbl.Size = new System.Drawing.Size(156, 19);
            this.preveplbl.TabIndex = 6;
            this.preveplbl.Text = "Previous EP that Ran";
            // 
            // previep
            // 
            this.previep.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previep.Location = new System.Drawing.Point(19, 92);
            this.previep.Name = "previep";
            this.previep.ReadOnly = true;
            this.previep.Size = new System.Drawing.Size(193, 23);
            this.previep.TabIndex = 0;
            this.previep.Text = "The Sims™ 2";
            // 
            // LastEPusePackedFileUI
            // 
            this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
            this.BackgroundImageLocation = new System.Drawing.Point(391, 0);
            this.BackgroundImageZoomToFit = true;
            this.CanCommit = false;
            this.Controls.Add(this.CatawayPnl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.preveplbl);
            this.Controls.Add(this.previep);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.HeaderText = "Last EP Used";
            this.Name = "LastEPusePackedFileUI";
            this.Size = new System.Drawing.Size(1300, 416);
            this.Controls.SetChildIndex(this.previep, 0);
            this.Controls.SetChildIndex(this.preveplbl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.CatawayPnl, 0);
            this.CatawayPnl.ResumeLayout(false);
            this.CatawayPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label preveplbl;
        internal System.Windows.Forms.TextBox previep;
        private System.Windows.Forms.Panel CatawayPnl;
        private System.Windows.Forms.Label lbMission;
        private System.Windows.Forms.Button btfore;
        private System.Windows.Forms.Button btBack;
    }
}
