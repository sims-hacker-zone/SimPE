using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Plugin
{
    partial class WallLayerPackedFileUI
    {

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WallLayerPackedFileUI));
            this.taskBox1 = new System.Windows.Forms.GroupBox();
            this.llConvwals = new System.Windows.Forms.LinkLabel();
            this.cbClear = new System.Windows.Forms.CheckBox();
            this.lbConvwals = new System.Windows.Forms.Label();
            this.lbwarning = new System.Windows.Forms.Label();
            this.btchanger = new System.Windows.Forms.Button();
            this.lbknowned = new System.Windows.Forms.Label();
            this.lbfounded = new System.Windows.Forms.Label();
            this.cbExistFences = new System.Windows.Forms.ComboBox();
            this.cballFences = new System.Windows.Forms.ComboBox();
            this.tbWalls = new System.Windows.Forms.GroupBox();
            this.lbscreenwood = new System.Windows.Forms.Label();
            this.lbNormal = new System.Windows.Forms.Label();
            this.lbofbnormal = new System.Windows.Forms.Label();
            this.lbpicket = new System.Windows.Forms.Label();
            this.lbunlpool = new System.Windows.Forms.Label();
            this.lbattic = new System.Windows.Forms.Label();
            this.lbunlevel = new System.Windows.Forms.Label();
            this.lbnrskirt = new System.Windows.Forms.Label();
            this.lbpool = new System.Windows.Forms.Label();
            this.lbredskirt = new System.Windows.Forms.Label();
            this.lbwoodfence = new System.Windows.Forms.Label();
            this.lbfoundation = new System.Windows.Forms.Label();
            this.lbminskirt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.taskBox1.SuspendLayout();
            this.tbWalls.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskBox1
            // 
            this.taskBox1.BackColor = System.Drawing.Color.Transparent;
            this.taskBox1.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.taskBox1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.taskBox1.Controls.Add(this.llConvwals);
            this.taskBox1.Controls.Add(this.cbClear);
            this.taskBox1.Controls.Add(this.lbConvwals);
            this.taskBox1.Controls.Add(this.lbwarning);
            this.taskBox1.Controls.Add(this.btchanger);
            this.taskBox1.Controls.Add(this.lbknowned);
            this.taskBox1.Controls.Add(this.lbfounded);
            this.taskBox1.Controls.Add(this.cbExistFences);
            this.taskBox1.Controls.Add(this.cballFences);
            this.taskBox1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.taskBox1.HeaderText = "Fences";
            this.taskBox1.HeaderTextColor = System.Drawing.SystemColors.ControlText;
            this.taskBox1.IconLocation = new System.Drawing.Point(4, 12);
            this.taskBox1.IconSize = new System.Drawing.Size(32, 32);
            this.taskBox1.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.taskBox1.Location = new System.Drawing.Point(337, 78);
            this.taskBox1.Name = "taskBox1";
            this.taskBox1.Padding = new System.Windows.Forms.Padding(4, 44, 4, 4);
            this.taskBox1.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.taskBox1.Size = new System.Drawing.Size(444, 326);
            this.taskBox1.TabIndex = 18;
            // 
            // llConvwals
            // 
            this.llConvwals.AutoSize = true;
            this.llConvwals.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic);
            this.llConvwals.LinkArea = new System.Windows.Forms.LinkArea(30, 44);
            this.llConvwals.Location = new System.Drawing.Point(10, 300);
            this.llConvwals.Name = "llConvwals";
            this.llConvwals.Size = new System.Drawing.Size(310, 21);
            this.llConvwals.TabIndex = 10;
            this.llConvwals.TabStop = true;
            this.llConvwals.Text = "To change Walls use Mootilda\'s Converti-Wall";
            this.llConvwals.UseCompatibleTextRendering = true;
            this.llConvwals.Visible = false;
            this.llConvwals.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llConvwals_LinkClicked);
            // 
            // cbClear
            // 
            this.cbClear.AutoSize = true;
            this.cbClear.Checked = true;
            this.cbClear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClear.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.cbClear.Location = new System.Drawing.Point(9, 82);
            this.cbClear.Name = "cbClear";
            this.cbClear.Size = new System.Drawing.Size(98, 20);
            this.cbClear.TabIndex = 9;
            this.cbClear.Text = "Clear Paint";
            this.toolTip1.SetToolTip(this.cbClear, "Having this set will remove any wall coverings\r\nIf changing from a paintable fenc" +
                    "e (half wall)\r\nto a non paintable fence having this set is highly\r\nrecommended.");
            this.cbClear.UseVisualStyleBackColor = true;
            // 
            // lbConvwals
            // 
            this.lbConvwals.AutoSize = true;
            this.lbConvwals.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConvwals.Location = new System.Drawing.Point(10, 300);
            this.lbConvwals.Name = "lbConvwals";
            this.lbConvwals.Size = new System.Drawing.Size(307, 16);
            this.lbConvwals.TabIndex = 8;
            this.lbConvwals.Text = "To change Walls use Mootilda\'s Converti-Wall";
            // 
            // lbwarning
            // 
            this.lbwarning.AutoSize = true;
            this.lbwarning.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwarning.ForeColor = System.Drawing.Color.Maroon;
            this.lbwarning.Location = new System.Drawing.Point(10, 151);
            this.lbwarning.Name = "lbwarning";
            this.lbwarning.Size = new System.Drawing.Size(370, 102);
            this.lbwarning.TabIndex = 7;
            this.lbwarning.Text = resources.GetString("lbwarning.Text");
            // 
            // btchanger
            // 
            this.btchanger.Enabled = false;
            this.btchanger.Location = new System.Drawing.Point(113, 82);
            this.btchanger.Name = "btchanger";
            this.btchanger.Size = new System.Drawing.Size(113, 23);
            this.btchanger.TabIndex = 6;
            this.btchanger.Text = "Change All To..";
            this.btchanger.UseVisualStyleBackColor = true;
            this.btchanger.Click += new System.EventHandler(this.btchanger_Click);
            // 
            // lbknowned
            // 
            this.lbknowned.AutoSize = true;
            this.lbknowned.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbknowned.Location = new System.Drawing.Point(4, 113);
            this.lbknowned.Name = "lbknowned";
            this.lbknowned.Size = new System.Drawing.Size(103, 16);
            this.lbknowned.TabIndex = 5;
            this.lbknowned.Text = "Known Fences";
            // 
            // lbfounded
            // 
            this.lbfounded.AutoSize = true;
            this.lbfounded.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfounded.Location = new System.Drawing.Point(7, 55);
            this.lbfounded.Name = "lbfounded";
            this.lbfounded.Size = new System.Drawing.Size(100, 16);
            this.lbfounded.TabIndex = 4;
            this.lbfounded.Text = "Found Fences";
            // 
            // cbExistFences
            // 
            this.cbExistFences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExistFences.FormattingEnabled = true;
            this.cbExistFences.Location = new System.Drawing.Point(113, 53);
            this.cbExistFences.Name = "cbExistFences";
            this.cbExistFences.Size = new System.Drawing.Size(324, 21);
            this.cbExistFences.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cbExistFences, "Unknown fence types will show up as\r\nGUID only.\r\nThese could either be custom fen" +
                    "ces\r\nor a fence from an EP that SimPe thinks\r\nyou don\'t have.");
            this.cbExistFences.SelectedIndexChanged += new System.EventHandler(this.cbExistFences_SelectedIndexChanged);
            // 
            // cballFences
            // 
            this.cballFences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cballFences.FormattingEnabled = true;
            this.cballFences.Location = new System.Drawing.Point(113, 111);
            this.cballFences.Name = "cballFences";
            this.cballFences.Size = new System.Drawing.Size(324, 21);
            this.cballFences.TabIndex = 2;
            this.cballFences.SelectedIndexChanged += new System.EventHandler(this.cballFences_SelectedIndexChanged);
            // 
            // tbWalls
            // 
            this.tbWalls.BackColor = System.Drawing.Color.Transparent;
            this.tbWalls.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.tbWalls.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbWalls.Controls.Add(this.lbscreenwood);
            this.tbWalls.Controls.Add(this.lbNormal);
            this.tbWalls.Controls.Add(this.lbofbnormal);
            this.tbWalls.Controls.Add(this.lbpicket);
            this.tbWalls.Controls.Add(this.lbunlpool);
            this.tbWalls.Controls.Add(this.lbattic);
            this.tbWalls.Controls.Add(this.lbunlevel);
            this.tbWalls.Controls.Add(this.lbnrskirt);
            this.tbWalls.Controls.Add(this.lbpool);
            this.tbWalls.Controls.Add(this.lbredskirt);
            this.tbWalls.Controls.Add(this.lbwoodfence);
            this.tbWalls.Controls.Add(this.lbfoundation);
            this.tbWalls.Controls.Add(this.lbminskirt);
            this.tbWalls.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.tbWalls.HeaderText = "Walls";
            this.tbWalls.HeaderTextColor = System.Drawing.SystemColors.ControlText;
            this.tbWalls.IconLocation = new System.Drawing.Point(4, 12);
            this.tbWalls.IconSize = new System.Drawing.Size(32, 32);
            this.tbWalls.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbWalls.Location = new System.Drawing.Point(15, 78);
            this.tbWalls.Name = "tbWalls";
            this.tbWalls.Padding = new System.Windows.Forms.Padding(4, 44, 4, 4);
            this.tbWalls.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbWalls.Size = new System.Drawing.Size(316, 326);
            this.tbWalls.TabIndex = 17;
            // 
            // lbscreenwood
            // 
            this.lbscreenwood.AutoSize = true;
            this.lbscreenwood.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbscreenwood.Location = new System.Drawing.Point(18, 237);
            this.lbscreenwood.Name = "lbscreenwood";
            this.lbscreenwood.Size = new System.Drawing.Size(201, 16);
            this.lbscreenwood.TabIndex = 16;
            this.lbscreenwood.Text = "0 screen wood (OFB or later)";
            // 
            // lbNormal
            // 
            this.lbNormal.AutoSize = true;
            this.lbNormal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNormal.Location = new System.Drawing.Point(18, 48);
            this.lbNormal.Name = "lbNormal";
            this.lbNormal.Size = new System.Drawing.Size(101, 16);
            this.lbNormal.TabIndex = 4;
            this.lbNormal.Text = "0 normal walls";
            // 
            // lbofbnormal
            // 
            this.lbofbnormal.AutoSize = true;
            this.lbofbnormal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbofbnormal.Location = new System.Drawing.Point(18, 300);
            this.lbofbnormal.Name = "lbofbnormal";
            this.lbofbnormal.Size = new System.Drawing.Size(192, 16);
            this.lbofbnormal.TabIndex = 15;
            this.lbofbnormal.Text = "0 abnormal walls (OFB only)";
            // 
            // lbpicket
            // 
            this.lbpicket.AutoSize = true;
            this.lbpicket.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpicket.Location = new System.Drawing.Point(18, 69);
            this.lbpicket.Name = "lbpicket";
            this.lbpicket.Size = new System.Drawing.Size(134, 16);
            this.lbpicket.TabIndex = 5;
            this.lbpicket.Text = "0 picket rail fences";
            // 
            // lbunlpool
            // 
            this.lbunlpool.AutoSize = true;
            this.lbunlpool.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbunlpool.Location = new System.Drawing.Point(18, 279);
            this.lbunlpool.Name = "lbunlpool";
            this.lbunlpool.Size = new System.Drawing.Size(143, 16);
            this.lbunlpool.TabIndex = 14;
            this.lbunlpool.Text = "0 un-level pool walls";
            // 
            // lbattic
            // 
            this.lbattic.AutoSize = true;
            this.lbattic.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbattic.Location = new System.Drawing.Point(18, 90);
            this.lbattic.Name = "lbattic";
            this.lbattic.Size = new System.Drawing.Size(89, 16);
            this.lbattic.TabIndex = 6;
            this.lbattic.Text = "0 attic walls";
            // 
            // lbunlevel
            // 
            this.lbunlevel.AutoSize = true;
            this.lbunlevel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbunlevel.Location = new System.Drawing.Point(18, 258);
            this.lbunlevel.Name = "lbunlevel";
            this.lbunlevel.Size = new System.Drawing.Size(159, 16);
            this.lbunlevel.TabIndex = 13;
            this.lbunlevel.Text = "0 un-level terrain walls";
            // 
            // lbnrskirt
            // 
            this.lbnrskirt.AutoSize = true;
            this.lbnrskirt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnrskirt.Location = new System.Drawing.Point(18, 111);
            this.lbnrskirt.Name = "lbnrskirt";
            this.lbnrskirt.Size = new System.Drawing.Size(186, 16);
            this.lbnrskirt.TabIndex = 7;
            this.lbnrskirt.Text = "0 non-rendered deck skirts";
            // 
            // lbpool
            // 
            this.lbpool.AutoSize = true;
            this.lbpool.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpool.Location = new System.Drawing.Point(18, 216);
            this.lbpool.Name = "lbpool";
            this.lbpool.Size = new System.Drawing.Size(85, 16);
            this.lbpool.TabIndex = 12;
            this.lbpool.Text = "0 pool walls";
            // 
            // lbredskirt
            // 
            this.lbredskirt.AutoSize = true;
            this.lbredskirt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbredskirt.Location = new System.Drawing.Point(18, 132);
            this.lbredskirt.Name = "lbredskirt";
            this.lbredskirt.Size = new System.Drawing.Size(165, 16);
            this.lbredskirt.TabIndex = 8;
            this.lbredskirt.Text = "0 deck skirts (redwood)";
            // 
            // lbwoodfence
            // 
            this.lbwoodfence.AutoSize = true;
            this.lbwoodfence.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwoodfence.Location = new System.Drawing.Point(18, 195);
            this.lbwoodfence.Name = "lbwoodfence";
            this.lbwoodfence.Size = new System.Drawing.Size(178, 16);
            this.lbwoodfence.TabIndex = 11;
            this.lbwoodfence.Text = "0 deck aged wood fences";
            // 
            // lbfoundation
            // 
            this.lbfoundation.AutoSize = true;
            this.lbfoundation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfoundation.Location = new System.Drawing.Point(18, 153);
            this.lbfoundation.Name = "lbfoundation";
            this.lbfoundation.Size = new System.Drawing.Size(128, 16);
            this.lbfoundation.TabIndex = 9;
            this.lbfoundation.Text = "0 foundation walls";
            // 
            // lbminskirt
            // 
            this.lbminskirt.AutoSize = true;
            this.lbminskirt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbminskirt.Location = new System.Drawing.Point(18, 174);
            this.lbminskirt.Name = "lbminskirt";
            this.lbminskirt.Size = new System.Drawing.Size(156, 16);
            this.lbminskirt.TabIndex = 10;
            this.lbminskirt.Text = "0 deck skirts (minimal)";
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
            this.label1.Visible = false;
            // 
            // WallLayerPackedFileUI
            // 
            this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
            this.BackgroundImageLocation = new System.Drawing.Point(784, 0);
            this.BackgroundImageZoomToFit = true;
            this.Controls.Add(this.taskBox1);
            this.Controls.Add(this.tbWalls);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderText = "Wall Layer";
            this.Name = "WallLayerPackedFileUI";
            this.Size = new System.Drawing.Size(1300, 416);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbWalls, 0);
            this.Controls.SetChildIndex(this.taskBox1, 0);
            this.taskBox1.ResumeLayout(false);
            this.taskBox1.PerformLayout();
            this.tbWalls.ResumeLayout(false);
            this.tbWalls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cballFences;
        private System.Windows.Forms.ComboBox cbExistFences;
        private System.Windows.Forms.Label lbNormal;
        private System.Windows.Forms.GroupBox taskBox1;
        private System.Windows.Forms.Label lbknowned;
        private System.Windows.Forms.Label lbfounded;
        private System.Windows.Forms.GroupBox tbWalls;
        private System.Windows.Forms.Label lbscreenwood;
        private System.Windows.Forms.Label lbofbnormal;
        private System.Windows.Forms.Label lbpicket;
        private System.Windows.Forms.Label lbunlpool;
        private System.Windows.Forms.Label lbattic;
        private System.Windows.Forms.Label lbunlevel;
        private System.Windows.Forms.Label lbnrskirt;
        private System.Windows.Forms.Label lbpool;
        private System.Windows.Forms.Label lbredskirt;
        private System.Windows.Forms.Label lbwoodfence;
        private System.Windows.Forms.Label lbfoundation;
        private System.Windows.Forms.Label lbminskirt;
        private System.Windows.Forms.Button btchanger;
        private System.Windows.Forms.Label lbConvwals;
        private System.Windows.Forms.Label lbwarning;
        private System.Windows.Forms.CheckBox cbClear;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.LinkLabel llConvwals;
    }
}
