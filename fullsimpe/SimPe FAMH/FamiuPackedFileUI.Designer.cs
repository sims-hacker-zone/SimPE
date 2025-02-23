using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.Plugin
{
    partial class FamiuPackedFileUI
    {

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamiuPackedFileUI));
            this.tbEditer = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.lbInvalid = new System.Windows.Forms.Label();
            this.btnuver = new System.Windows.Forms.Button();
            this.btBady = new System.Windows.Forms.Button();
            this.BtGoody = new System.Windows.Forms.Button();
            this.lbfriends = new System.Windows.Forms.Label();
            this.lbFunds = new System.Windows.Forms.Label();
            this.lbGirlNo = new System.Windows.Forms.Label();
            this.lbBoyNo = new System.Windows.Forms.Label();
            this.lbLaduNo = new System.Windows.Forms.Label();
            this.lbMenNo = new System.Windows.Forms.Label();
            this.lbLotNo = new System.Windows.Forms.Label();
            this.tbFriends = new System.Windows.Forms.TextBox();
            this.tbFunds = new System.Windows.Forms.TextBox();
            this.tbGirlNo = new System.Windows.Forms.TextBox();
            this.tbBoyNo = new System.Windows.Forms.TextBox();
            this.tbLadyNo = new System.Windows.Forms.TextBox();
            this.tbMenNo = new System.Windows.Forms.TextBox();
            this.tbLotNo = new System.Windows.Forms.TextBox();
            //this.linkyabout = new booby.linkyicon();
            this.fundGraph = new System.Windows.Forms.Panel();
            this.mateGraph = new System.Windows.Forms.Panel();
            this.boyGraph = new System.Windows.Forms.Panel();
            this.girlGraph = new System.Windows.Forms.Panel();
            this.menGraph = new System.Windows.Forms.Panel();
            this.femGraph = new System.Windows.Forms.Panel();
            this.simGraph = new System.Windows.Forms.Panel();
            this.tbBlocks = new Ambertation.Windows.Forms.XPTaskBoxSimple();
            this.btediter = new System.Windows.Forms.Button();
            this.btRawd = new System.Windows.Forms.Button();
            this.btnext = new System.Windows.Forms.Button();
            this.btprev = new System.Windows.Forms.Button();
            this.lbcurrnt = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.lbTota = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.gtname = new System.Windows.Forms.TextBox();
            this.lbraw = new System.Windows.Forms.Label();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            this.tbEditer.SuspendLayout();
            this.tbBlocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tbEditer
            // 
            this.tbEditer.BackColor = System.Drawing.Color.Transparent;
            this.tbEditer.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.tbEditer.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbEditer.Controls.Add(this.lbInvalid);
            this.tbEditer.Controls.Add(this.btnuver);
            this.tbEditer.Controls.Add(this.btBady);
            this.tbEditer.Controls.Add(this.BtGoody);
            this.tbEditer.Controls.Add(this.lbfriends);
            this.tbEditer.Controls.Add(this.lbFunds);
            this.tbEditer.Controls.Add(this.lbGirlNo);
            this.tbEditer.Controls.Add(this.lbBoyNo);
            this.tbEditer.Controls.Add(this.lbLaduNo);
            this.tbEditer.Controls.Add(this.lbMenNo);
            this.tbEditer.Controls.Add(this.lbLotNo);
            this.tbEditer.Controls.Add(this.tbFriends);
            this.tbEditer.Controls.Add(this.tbFunds);
            this.tbEditer.Controls.Add(this.tbGirlNo);
            this.tbEditer.Controls.Add(this.tbBoyNo);
            this.tbEditer.Controls.Add(this.tbLadyNo);
            this.tbEditer.Controls.Add(this.tbMenNo);
            this.tbEditer.Controls.Add(this.tbLotNo);
            this.tbEditer.HeaderText = "History Block Editer";
            this.tbEditer.HeaderTextColor = System.Drawing.SystemColors.ControlText;
            this.tbEditer.Icon = ((System.Drawing.Image)(resources.GetObject("tbEditer.Icon")));
            this.tbEditer.IconLocation = new System.Drawing.Point(4, 12);
            this.tbEditer.IconSize = new System.Drawing.Size(32, 32);
            this.tbEditer.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbEditer.Location = new System.Drawing.Point(12, 195);
            this.tbEditer.Name = "tbEditer";
            this.tbEditer.Padding = new System.Windows.Forms.Padding(4, 44, 4, 4);
            this.tbEditer.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbEditer.Size = new System.Drawing.Size(492, 218);
            this.tbEditer.TabIndex = 52;
            this.tbEditer.Visible = false;
            // 
            // lbInvalid
            // 
            this.lbInvalid.AutoSize = true;
            this.lbInvalid.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInvalid.ForeColor = System.Drawing.Color.DarkRed;
            this.lbInvalid.Location = new System.Drawing.Point(344, 70);
            this.lbInvalid.Name = "lbInvalid";
            this.lbInvalid.Size = new System.Drawing.Size(120, 18);
            this.lbInvalid.TabIndex = 17;
            this.lbInvalid.Text = "Invalid Input";
            this.lbInvalid.Visible = false;
            // 
            // btnuver
            // 
            this.btnuver.Location = new System.Drawing.Point(400, 148);
            this.btnuver.Name = "btnuver";
            this.btnuver.Size = new System.Drawing.Size(75, 23);
            this.btnuver.TabIndex = 16;
            this.btnuver.Text = "Add Block";
            this.btnuver.UseVisualStyleBackColor = true;
            this.btnuver.Click += new System.EventHandler(this.btnuver_Click);
            // 
            // btBady
            // 
            this.btBady.Location = new System.Drawing.Point(316, 179);
            this.btBady.Name = "btBady";
            this.btBady.Size = new System.Drawing.Size(75, 23);
            this.btBady.TabIndex = 15;
            this.btBady.Text = "Cancel";
            this.btBady.UseVisualStyleBackColor = true;
            this.btBady.Click += new System.EventHandler(this.btBady_Click);
            // 
            // BtGoody
            // 
            this.BtGoody.Location = new System.Drawing.Point(400, 178);
            this.BtGoody.Name = "BtGoody";
            this.BtGoody.Size = new System.Drawing.Size(75, 23);
            this.BtGoody.TabIndex = 14;
            this.BtGoody.Text = "Apply";
            this.BtGoody.UseVisualStyleBackColor = true;
            this.BtGoody.Click += new System.EventHandler(this.BtGoody_Click);
            // 
            // lbfriends
            // 
            this.lbfriends.AutoSize = true;
            this.lbfriends.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfriends.Location = new System.Drawing.Point(69, 193);
            this.lbfriends.Name = "lbfriends";
            this.lbfriends.Size = new System.Drawing.Size(115, 16);
            this.lbfriends.TabIndex = 13;
            this.lbfriends.Text = "Family Friends";
            // 
            // lbFunds
            // 
            this.lbFunds.AutoSize = true;
            this.lbFunds.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFunds.Location = new System.Drawing.Point(79, 169);
            this.lbFunds.Name = "lbFunds";
            this.lbFunds.Size = new System.Drawing.Size(105, 16);
            this.lbFunds.TabIndex = 12;
            this.lbFunds.Text = "Family Funds";
            // 
            // lbGirlNo
            // 
            this.lbGirlNo.AutoSize = true;
            this.lbGirlNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGirlNo.Location = new System.Drawing.Point(65, 145);
            this.lbGirlNo.Name = "lbGirlNo";
            this.lbGirlNo.Size = new System.Drawing.Size(119, 16);
            this.lbGirlNo.TabIndex = 11;
            this.lbGirlNo.Text = "Number of Girls";
            // 
            // lbBoyNo
            // 
            this.lbBoyNo.AutoSize = true;
            this.lbBoyNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBoyNo.Location = new System.Drawing.Point(61, 121);
            this.lbBoyNo.Name = "lbBoyNo";
            this.lbBoyNo.Size = new System.Drawing.Size(123, 16);
            this.lbBoyNo.TabIndex = 10;
            this.lbBoyNo.Text = "Number of Boys";
            // 
            // lbLaduNo
            // 
            this.lbLaduNo.AutoSize = true;
            this.lbLaduNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLaduNo.Location = new System.Drawing.Point(42, 97);
            this.lbLaduNo.Name = "lbLaduNo";
            this.lbLaduNo.Size = new System.Drawing.Size(142, 16);
            this.lbLaduNo.TabIndex = 9;
            this.lbLaduNo.Text = "Number of Women";
            // 
            // lbMenNo
            // 
            this.lbMenNo.AutoSize = true;
            this.lbMenNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenNo.Location = new System.Drawing.Point(67, 73);
            this.lbMenNo.Name = "lbMenNo";
            this.lbMenNo.Size = new System.Drawing.Size(117, 16);
            this.lbMenNo.TabIndex = 8;
            this.lbMenNo.Text = "Number of Men";
            // 
            // lbLotNo
            // 
            this.lbLotNo.AutoSize = true;
            this.lbLotNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLotNo.Location = new System.Drawing.Point(92, 49);
            this.lbLotNo.Name = "lbLotNo";
            this.lbLotNo.Size = new System.Drawing.Size(92, 16);
            this.lbLotNo.TabIndex = 7;
            this.lbLotNo.Text = "Lot Number";
            // 
            // tbFriends
            // 
            this.tbFriends.Location = new System.Drawing.Point(194, 191);
            this.tbFriends.Name = "tbFriends";
            this.tbFriends.Size = new System.Drawing.Size(100, 21);
            this.tbFriends.TabIndex = 6;
            // 
            // tbFunds
            // 
            this.tbFunds.Location = new System.Drawing.Point(194, 167);
            this.tbFunds.Name = "tbFunds";
            this.tbFunds.Size = new System.Drawing.Size(100, 21);
            this.tbFunds.TabIndex = 5;
            // 
            // tbGirlNo
            // 
            this.tbGirlNo.Location = new System.Drawing.Point(194, 143);
            this.tbGirlNo.Name = "tbGirlNo";
            this.tbGirlNo.Size = new System.Drawing.Size(100, 21);
            this.tbGirlNo.TabIndex = 4;
            // 
            // tbBoyNo
            // 
            this.tbBoyNo.Location = new System.Drawing.Point(194, 119);
            this.tbBoyNo.Name = "tbBoyNo";
            this.tbBoyNo.Size = new System.Drawing.Size(100, 21);
            this.tbBoyNo.TabIndex = 3;
            // 
            // tbLadyNo
            // 
            this.tbLadyNo.Location = new System.Drawing.Point(194, 95);
            this.tbLadyNo.Name = "tbLadyNo";
            this.tbLadyNo.Size = new System.Drawing.Size(100, 21);
            this.tbLadyNo.TabIndex = 2;
            // 
            // tbMenNo
            // 
            this.tbMenNo.Location = new System.Drawing.Point(194, 71);
            this.tbMenNo.Name = "tbMenNo";
            this.tbMenNo.Size = new System.Drawing.Size(100, 21);
            this.tbMenNo.TabIndex = 1;
            // 
            // tbLotNo
            // 
            this.tbLotNo.Location = new System.Drawing.Point(194, 47);
            this.tbLotNo.Name = "tbLotNo";
            this.tbLotNo.Size = new System.Drawing.Size(100, 21);
            this.tbLotNo.TabIndex = 0;
            // 
            // linkyabout
            // 
            // this.linkyabout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // this.linkyabout.BackColor = System.Drawing.Color.Transparent;
            // this.linkyabout.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // this.linkyabout.Gap = 2;
            // this.linkyabout.Icon = GetIcon.Support;
            // this.linkyabout.Label = "About...";
            // this.linkyabout.Location = new System.Drawing.Point(1191, 34);
            // this.linkyabout.Margin = new System.Windows.Forms.Padding(0);
            // this.linkyabout.Name = "linkyabout";
            // this.linkyabout.Size = new System.Drawing.Size(98, 18);
            // this.linkyabout.TabIndex = 49;
            // this.linkyabout.LinkClicked += new booby.linkyicon.EventHandler(this.linkyabout_LinkClicked);
            // 
            // fundGraph
            // 
            this.fundGraph.BackColor = System.Drawing.Color.Transparent;
            this.fundGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            //this.fundGraph.BarColour = System.Drawing.Color.Black;
            //this.fundGraph.Datas = new int[] {
        //0,
        //0};
            //this.fundGraph.HighlightColour = System.Drawing.SystemColors.Window;
            //this.fundGraph.LineWidth = 2F;
            this.fundGraph.Location = new System.Drawing.Point(510, 272);
            this.fundGraph.Name = "fundGraph";
            this.fundGraph.Size = new System.Drawing.Size(228, 74);
            this.fundGraph.TabIndex = 51;
            //this.fundGraph.Title = "Family Funds";
            //this.fundGraph.UseBars = false;
            // 
            // mateGraph
            // 
            this.mateGraph.BackColor = System.Drawing.Color.Transparent;
            this.mateGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        //    this.mateGraph.BarColour = System.Drawing.Color.DarkOliveGreen;
        //    this.mateGraph.Datas = new int[] {
        //0,
        //0};
            //this.mateGraph.HighlightColour = System.Drawing.SystemColors.Window;
            //this.mateGraph.LineWidth = 1F;
            this.mateGraph.Location = new System.Drawing.Point(742, 32);
            this.mateGraph.Name = "mateGraph";
            this.mateGraph.Size = new System.Drawing.Size(228, 74);
            this.mateGraph.TabIndex = 50;
            //this.mateGraph.Title = "Family Friends";
            // 
            // boyGraph
            // 
            this.boyGraph.BackColor = System.Drawing.Color.Transparent;
            this.boyGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        //    this.boyGraph.BarColour = System.Drawing.Color.LightSkyBlue;
        //    this.boyGraph.Datas = new int[] {
        //0,
        //0};
            //this.boyGraph.HighlightColour = System.Drawing.SystemColors.Window;
            //this.boyGraph.LineWidth = 1F;
            this.boyGraph.Location = new System.Drawing.Point(742, 192);
            this.boyGraph.Name = "boyGraph";
            this.boyGraph.Size = new System.Drawing.Size(228, 74);
            this.boyGraph.TabIndex = 48;
            //this.boyGraph.Title = "Boys";
            // 
            // girlGraph
            // 
            this.girlGraph.BackColor = System.Drawing.Color.Transparent;
            this.girlGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        //    this.girlGraph.BarColour = System.Drawing.Color.Orchid;
        //    this.girlGraph.Datas = new int[] {
        //0,
        //0};
            //this.girlGraph.HighlightColour = System.Drawing.SystemColors.Window;
            //this.girlGraph.LineWidth = 1F;
            this.girlGraph.Location = new System.Drawing.Point(742, 112);
            this.girlGraph.Name = "girlGraph";
            this.girlGraph.Size = new System.Drawing.Size(228, 74);
            this.girlGraph.TabIndex = 47;
            //this.girlGraph.Title = "Girls";
            // 
            // menGraph
            // 
            this.menGraph.BackColor = System.Drawing.Color.Transparent;
            this.menGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        //    this.menGraph.BarColour = System.Drawing.Color.SteelBlue;
        //    this.menGraph.Datas = new int[] {
        //0,
        //0};
            //this.menGraph.HighlightColour = System.Drawing.SystemColors.Window;
            //this.menGraph.LineWidth = 1F;
            this.menGraph.Location = new System.Drawing.Point(510, 192);
            this.menGraph.Name = "menGraph";
            this.menGraph.Size = new System.Drawing.Size(228, 74);
            this.menGraph.TabIndex = 46;
            //this.menGraph.Title = "Men";
            // 
            // femGraph
            // 
            this.femGraph.BackColor = System.Drawing.Color.Transparent;
            this.femGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        //    this.femGraph.BarColour = System.Drawing.Color.MediumVioletRed;
        //    this.femGraph.Datas = new int[] {
        //0,
        //0};
            //this.femGraph.HighlightColour = System.Drawing.SystemColors.Window;
            //this.femGraph.LineWidth = 1F;
            this.femGraph.Location = new System.Drawing.Point(510, 112);
            this.femGraph.Name = "femGraph";
            this.femGraph.Size = new System.Drawing.Size(228, 74);
            this.femGraph.TabIndex = 45;
            //this.femGraph.Title = "Women";
            // 
            // simGraph
            // 
            this.simGraph.BackColor = System.Drawing.Color.Transparent;
            this.simGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        //    this.simGraph.BarColour = System.Drawing.Color.Black;
        //    this.simGraph.Datas = new int[] {
        //0,
        //0};
            //this.simGraph.HighlightColour = System.Drawing.SystemColors.Window;
            //this.simGraph.LineWidth = 1F;
            this.simGraph.Location = new System.Drawing.Point(510, 32);
            this.simGraph.Name = "simGraph";
            this.simGraph.Size = new System.Drawing.Size(228, 74);
            this.simGraph.TabIndex = 44;
            //this.simGraph.Title = "Family Members";
            // 
            // tbBlocks
            // 
            this.tbBlocks.BackColor = System.Drawing.Color.Transparent;
            this.tbBlocks.BodyColor = System.Drawing.SystemColors.ControlLight;
            this.tbBlocks.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tbBlocks.Controls.Add(this.btediter);
            this.tbBlocks.Controls.Add(this.btRawd);
            this.tbBlocks.Controls.Add(this.btnext);
            this.tbBlocks.Controls.Add(this.btprev);
            this.tbBlocks.Controls.Add(this.lbcurrnt);
            this.tbBlocks.Controls.Add(this.tbValue);
            this.tbBlocks.Controls.Add(this.lbTota);
            this.tbBlocks.Controls.Add(this.btDelete);
            this.tbBlocks.HeaderText = "Valid Days 1";
            this.tbBlocks.HeaderTextColor = System.Drawing.SystemColors.ControlText;
            this.tbBlocks.IconLocation = new System.Drawing.Point(4, 12);
            this.tbBlocks.IconSize = new System.Drawing.Size(32, 32);
            this.tbBlocks.LeftHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbBlocks.Location = new System.Drawing.Point(232, 24);
            this.tbBlocks.Name = "tbBlocks";
            this.tbBlocks.Padding = new System.Windows.Forms.Padding(4, 44, 4, 4);
            this.tbBlocks.RightHeaderColor = System.Drawing.SystemColors.ControlDark;
            this.tbBlocks.Size = new System.Drawing.Size(272, 166);
            this.tbBlocks.TabIndex = 43;
            //this.tbBlocks.TopGap = 6;
            // 
            // btediter
            // 
            this.btediter.Location = new System.Drawing.Point(18, 134);
            this.btediter.Name = "btediter";
            this.btediter.Size = new System.Drawing.Size(106, 23);
            this.btediter.TabIndex = 11;
            this.btediter.Text = "Edit This Day";
            this.btediter.UseVisualStyleBackColor = true;
            this.btediter.Click += new System.EventHandler(this.btediter_Click);
            // 
            // btRawd
            // 
            this.btRawd.Location = new System.Drawing.Point(147, 32);
            this.btRawd.Name = "btRawd";
            this.btRawd.Size = new System.Drawing.Size(109, 23);
            this.btRawd.TabIndex = 10;
            this.btRawd.Text = "Show Raw Data";
            this.btRawd.UseVisualStyleBackColor = true;
            this.btRawd.Click += new System.EventHandler(this.btRawd_Click);
            // 
            // btnext
            // 
            this.btnext.Location = new System.Drawing.Point(166, 83);
            this.btnext.Name = "btnext";
            this.btnext.Size = new System.Drawing.Size(90, 23);
            this.btnext.TabIndex = 3;
            this.btnext.Text = "Next Day ->";
            this.btnext.UseVisualStyleBackColor = true;
            this.btnext.Click += new System.EventHandler(this.btnext_Click);
            // 
            // btprev
            // 
            this.btprev.Location = new System.Drawing.Point(18, 83);
            this.btprev.Name = "btprev";
            this.btprev.Size = new System.Drawing.Size(105, 23);
            this.btprev.TabIndex = 2;
            this.btprev.Text = "<- Previous Day";
            this.btprev.UseVisualStyleBackColor = true;
            this.btprev.Click += new System.EventHandler(this.btprev_Click);
            // 
            // lbcurrnt
            // 
            this.lbcurrnt.AutoSize = true;
            this.lbcurrnt.Location = new System.Drawing.Point(106, 63);
            this.lbcurrnt.Name = "lbcurrnt";
            this.lbcurrnt.Size = new System.Drawing.Size(66, 13);
            this.lbcurrnt.TabIndex = 9;
            this.lbcurrnt.Text = "Day Number";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(129, 84);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(31, 21);
            this.tbValue.TabIndex = 4;
            this.tbValue.Text = "1";
            this.tbValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbTota
            // 
            this.lbTota.AutoSize = true;
            this.lbTota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.lbTota.Location = new System.Drawing.Point(7, 34);
            this.lbTota.Name = "lbTota";
            this.lbTota.Size = new System.Drawing.Size(110, 17);
            this.lbTota.TabIndex = 5;
            this.lbTota.Text = "Invalid Days 0";
            this.lbTota.Visible = false;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(147, 134);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(110, 23);
            this.btDelete.TabIndex = 8;
            this.btDelete.Text = "Delete This Day";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Visible = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbImage.Location = new System.Drawing.Point(12, 32);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(138, 138);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 42;
            this.pbImage.TabStop = false;
            // 
            // gtname
            // 
            this.gtname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gtname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtname.Location = new System.Drawing.Point(12, 225);
            this.gtname.Multiline = true;
            this.gtname.Name = "gtname";
            this.gtname.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gtname.Size = new System.Drawing.Size(492, 186);
            this.gtname.TabIndex = 0;
            // 
            // lbraw
            // 
            this.lbraw.AutoSize = true;
            this.lbraw.BackColor = System.Drawing.Color.Transparent;
            this.lbraw.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbraw.Location = new System.Drawing.Point(18, 202);
            this.lbraw.Name = "lbraw";
            this.lbraw.Size = new System.Drawing.Size(51, 16);
            this.lbraw.TabIndex = 6;
            this.lbraw.Text = "Data :";
            // 
            // rtbAbout
            // 
            this.rtbAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbAbout.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAbout.Location = new System.Drawing.Point(5, 28);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.Size = new System.Drawing.Size(970, 384);
            this.rtbAbout.TabIndex = 50;
            this.rtbAbout.Text = resources.GetString("rtbAbout.Text");
            this.rtbAbout.Visible = false;
            // 
            // FamiuPackedFileUI
            // 
            this.BackgroundImageAnchor = SimPe.Windows.Forms.WrapperBaseControl.ImageLayout.CenterLeft;
            this.BackgroundImageLocation = new System.Drawing.Point(1100, 0);
            this.BackgroundImageZoomToFit = true;
            this.CanCommit = false;
            this.Controls.Add(this.rtbAbout);
            this.Controls.Add(this.tbEditer);
            // this.Controls.Add(this.linkyabout);
            this.Controls.Add(this.fundGraph);
            this.Controls.Add(this.mateGraph);
            this.Controls.Add(this.boyGraph);
            this.Controls.Add(this.girlGraph);
            this.Controls.Add(this.menGraph);
            this.Controls.Add(this.femGraph);
            this.Controls.Add(this.simGraph);
            this.Controls.Add(this.tbBlocks);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.gtname);
            this.Controls.Add(this.lbraw);
            this.DoubleBuffered = true;
            this.HeaderText = "Family History";
            this.Name = "FamiuPackedFileUI";
            this.Size = new System.Drawing.Size(1300, 416);
            this.Controls.SetChildIndex(this.lbraw, 0);
            this.Controls.SetChildIndex(this.gtname, 0);
            this.Controls.SetChildIndex(this.pbImage, 0);
            this.Controls.SetChildIndex(this.tbBlocks, 0);
            this.Controls.SetChildIndex(this.simGraph, 0);
            this.Controls.SetChildIndex(this.femGraph, 0);
            this.Controls.SetChildIndex(this.menGraph, 0);
            this.Controls.SetChildIndex(this.girlGraph, 0);
            this.Controls.SetChildIndex(this.boyGraph, 0);
            this.Controls.SetChildIndex(this.mateGraph, 0);
            this.Controls.SetChildIndex(this.fundGraph, 0);
            //this.Controls.SetChildIndex(this.linkyabout, 0);
            this.Controls.SetChildIndex(this.tbEditer, 0);
            this.Controls.SetChildIndex(this.rtbAbout, 0);
            this.tbEditer.ResumeLayout(false);
            this.tbEditer.PerformLayout();
            this.tbBlocks.ResumeLayout(false);
            this.tbBlocks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.TextBox gtname;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button btnext;
        private System.Windows.Forms.Button btprev;
        private System.Windows.Forms.Label lbTota;
        private System.Windows.Forms.Label lbraw;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label lbcurrnt;
        private Ambertation.Windows.Forms.XPTaskBoxSimple tbBlocks;
        internal System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btRawd;
        private System.Windows.Forms.Panel simGraph;
        private System.Windows.Forms.Panel menGraph;
        private System.Windows.Forms.Panel femGraph;
        private System.Windows.Forms.Panel boyGraph;
        private System.Windows.Forms.Panel mateGraph;
        private System.Windows.Forms.Panel fundGraph;
        private System.Windows.Forms.Panel girlGraph;
        // private booby.linkyicon linkyabout;
        private System.Windows.Forms.RichTextBox rtbAbout;
        private System.Windows.Forms.Button btediter;
        private Ambertation.Windows.Forms.XPTaskBoxSimple tbEditer;
        private System.Windows.Forms.TextBox tbGirlNo;
        private System.Windows.Forms.TextBox tbBoyNo;
        private System.Windows.Forms.TextBox tbLadyNo;
        private System.Windows.Forms.TextBox tbMenNo;
        private System.Windows.Forms.TextBox tbLotNo;
        private System.Windows.Forms.Label lbGirlNo;
        private System.Windows.Forms.Label lbBoyNo;
        private System.Windows.Forms.Label lbLaduNo;
        private System.Windows.Forms.Label lbMenNo;
        private System.Windows.Forms.Label lbLotNo;
        private System.Windows.Forms.TextBox tbFriends;
        private System.Windows.Forms.TextBox tbFunds;
        private System.Windows.Forms.Button BtGoody;
        private System.Windows.Forms.Label lbfriends;
        private System.Windows.Forms.Label lbFunds;
        private System.Windows.Forms.Button btBady;
        private System.Windows.Forms.Button btnuver;
        private System.Windows.Forms.Label lbInvalid;
    }
}
