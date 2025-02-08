namespace pjHoodTool
{
    partial class Settims
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.simLogo = new TS2Logo();
            this.cbshowbusi = new System.Windows.Forms.CheckBox();
            this.cbExcludeLots = new System.Windows.Forms.CheckBox();
            this.cbshowpets = new System.Windows.Forms.CheckBox();
            this.cbshowdesc = new System.Windows.Forms.CheckBox();
            this.cbshownpcs = new System.Windows.Forms.CheckBox();
            this.lbtypy = new System.Windows.Forms.Label();
            this.rbcsv = new System.Windows.Forms.RadioButton();
            this.rbtext = new System.Windows.Forms.RadioButton();
            this.btdoned = new System.Windows.Forms.Button();
            this.lbheader = new System.Windows.Forms.Label();
            this.cbshowapartments = new System.Windows.Forms.CheckBox();
            this.cbshowfreetime = new System.Windows.Forms.CheckBox();
            this.cbshowuniversity = new System.Windows.Forms.CheckBox();
            this.cbshowskills = new System.Windows.Forms.CheckBox();
            this.cbshowcharacter = new System.Windows.Forms.CheckBox();
            this.cbshowinterests = new System.Windows.Forms.CheckBox();
            this.cbshowbasic = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            //this.Controls.Add(this.simLogo);
            this.Controls.Add(this.cbshowbusi);
            this.Controls.Add(this.cbExcludeLots);
            this.Controls.Add(this.cbshowpets);
            this.Controls.Add(this.cbshowdesc);
            this.Controls.Add(this.cbshownpcs);
            this.Controls.Add(this.lbtypy);
            this.Controls.Add(this.rbcsv);
            this.Controls.Add(this.rbtext);
            this.Controls.Add(this.btdoned);
            this.Controls.Add(this.lbheader);
            this.Controls.Add(this.cbshowapartments);
            this.Controls.Add(this.cbshowfreetime);
            this.Controls.Add(this.cbshowuniversity);
            this.Controls.Add(this.cbshowskills);
            this.Controls.Add(this.cbshowcharacter);
            this.Controls.Add(this.cbshowinterests);
            this.Controls.Add(this.cbshowbasic);
            // 
            // simLogo
            // 
            // this.simLogo.BackImage = null;
            // this.simLogo.ForeImage = null;
            // this.simLogo.ImageLocationX = 70;
            // this.simLogo.ImageLocationY = 0;
            // this.simLogo.ImageWidth = 85;
            // this.simLogo.Location = new System.Drawing.Point(278, 37);
            // this.simLogo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            // this.simLogo.Name = "simLogo";
            // this.simLogo.OverHead = 15;
            // this.simLogo.Run = false;
            // this.simLogo.Scaled = 1.25F;
            // this.simLogo.Size = new System.Drawing.Size(312, 294);
            // this.simLogo.Speed = 32;
            // this.simLogo.TabIndex = 17;
            // 
            // cbshowbusi
            // 
            this.cbshowbusi.AutoSize = true;
            this.cbshowbusi.Checked = true;
            this.cbshowbusi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowbusi.Location = new System.Drawing.Point(25, 217);
            this.cbshowbusi.Name = "cbshowbusi";
            this.cbshowbusi.Size = new System.Drawing.Size(166, 22);
            this.cbshowbusi.TabIndex = 16;
            this.cbshowbusi.Text = "Include Business";
            this.cbshowbusi.UseVisualStyleBackColor = true;
            // 
            // cbExcludeLots
            // 
            this.cbExcludeLots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExcludeLots.AutoSize = true;
            this.cbExcludeLots.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbExcludeLots.Location = new System.Drawing.Point(410, 4);
            this.cbExcludeLots.Name = "cbExcludeLots";
            this.cbExcludeLots.Size = new System.Drawing.Size(262, 22);
            this.cbExcludeLots.TabIndex = 15;
            this.cbExcludeLots.Text = "Don\'t Export Lot Information";
            this.cbExcludeLots.UseVisualStyleBackColor = true;
            // 
            // cbshowpets
            // 
            this.cbshowpets.AutoSize = true;
            this.cbshowpets.Checked = true;
            this.cbshowpets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowpets.Location = new System.Drawing.Point(25, 247);
            this.cbshowpets.Name = "cbshowpets";
            this.cbshowpets.Size = new System.Drawing.Size(129, 22);
            this.cbshowpets.TabIndex = 14;
            this.cbshowpets.Text = "Include Pets";
            this.cbshowpets.UseVisualStyleBackColor = true;
            // 
            // cbshowdesc
            // 
            this.cbshowdesc.AutoSize = true;
            this.cbshowdesc.Checked = true;
            this.cbshowdesc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowdesc.Location = new System.Drawing.Point(25, 67);
            this.cbshowdesc.Name = "cbshowdesc";
            this.cbshowdesc.Size = new System.Drawing.Size(221, 22);
            this.cbshowdesc.TabIndex = 13;
            this.cbshowdesc.Text = "Include Sim Description";
            this.cbshowdesc.UseVisualStyleBackColor = true;
            // 
            // cbshownpcs
            // 
            this.cbshownpcs.AutoSize = true;
            this.cbshownpcs.Location = new System.Drawing.Point(25, 337);
            this.cbshownpcs.Name = "cbshownpcs";
            this.cbshownpcs.Size = new System.Drawing.Size(214, 22);
            this.cbshownpcs.TabIndex = 12;
            this.cbshownpcs.Text = "Include Only Playables";
            this.cbshownpcs.UseVisualStyleBackColor = true;
            // 
            // lbtypy
            // 
            this.lbtypy.AutoSize = true;
            this.lbtypy.Location = new System.Drawing.Point(88, 365);
            this.lbtypy.Name = "lbtypy";
            this.lbtypy.Size = new System.Drawing.Size(94, 18);
            this.lbtypy.TabIndex = 11;
            this.lbtypy.Text = "-File Type-";
            // 
            // rbcsv
            // 
            this.rbcsv.AutoSize = true;
            this.rbcsv.Location = new System.Drawing.Point(190, 365);
            this.rbcsv.Name = "rbcsv";
            this.rbcsv.Size = new System.Drawing.Size(58, 22);
            this.rbcsv.TabIndex = 10;
            this.rbcsv.TabStop = true;
            this.rbcsv.Text = ".csv";
            this.rbcsv.UseVisualStyleBackColor = true;
            // 
            // rbtext
            // 
            this.rbtext.AutoSize = true;
            this.rbtext.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtext.Checked = true;
            this.rbtext.Location = new System.Drawing.Point(25, 365);
            this.rbtext.Name = "rbtext";
            this.rbtext.Size = new System.Drawing.Size(55, 22);
            this.rbtext.TabIndex = 9;
            this.rbtext.TabStop = true;
            this.rbtext.Text = ".txt";
            this.rbtext.UseVisualStyleBackColor = true;
            // 
            // btdoned
            // 
            this.btdoned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btdoned.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdoned.Location = new System.Drawing.Point(606, 373);
            this.btdoned.Name = "btdoned";
            this.btdoned.Size = new System.Drawing.Size(75, 23);
            this.btdoned.TabIndex = 8;
            this.btdoned.Text = "Apply";
            this.btdoned.UseVisualStyleBackColor = true;
            this.btdoned.Click += new System.EventHandler(this.btdoned_Click);
            // 
            // lbheader
            // 
            this.lbheader.AutoSize = true;
            this.lbheader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbheader.Location = new System.Drawing.Point(4, 4);
            this.lbheader.Name = "lbheader";
            this.lbheader.Size = new System.Drawing.Size(290, 25);
            this.lbheader.TabIndex = 7;
            this.lbheader.Text = "Choose the output options";
            // 
            // cbshowapartments
            // 
            this.cbshowapartments.AutoSize = true;
            this.cbshowapartments.Checked = true;
            this.cbshowapartments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowapartments.Location = new System.Drawing.Point(25, 307);
            this.cbshowapartments.Name = "cbshowapartments";
            this.cbshowapartments.Size = new System.Drawing.Size(188, 22);
            this.cbshowapartments.TabIndex = 6;
            this.cbshowapartments.Text = "Include Apartments";
            this.cbshowapartments.UseVisualStyleBackColor = true;
            // 
            // cbshowfreetime
            // 
            this.cbshowfreetime.AutoSize = true;
            this.cbshowfreetime.Checked = true;
            this.cbshowfreetime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowfreetime.Location = new System.Drawing.Point(25, 277);
            this.cbshowfreetime.Name = "cbshowfreetime";
            this.cbshowfreetime.Size = new System.Drawing.Size(165, 22);
            this.cbshowfreetime.TabIndex = 5;
            this.cbshowfreetime.Text = "Include Freetime";
            this.cbshowfreetime.UseVisualStyleBackColor = true;
            // 
            // cbshowuniversity
            // 
            this.cbshowuniversity.AutoSize = true;
            this.cbshowuniversity.Checked = true;
            this.cbshowuniversity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowuniversity.Location = new System.Drawing.Point(25, 187);
            this.cbshowuniversity.Name = "cbshowuniversity";
            this.cbshowuniversity.Size = new System.Drawing.Size(175, 22);
            this.cbshowuniversity.TabIndex = 4;
            this.cbshowuniversity.Text = "Include University";
            this.cbshowuniversity.UseVisualStyleBackColor = true;
            // 
            // cbshowskills
            // 
            this.cbshowskills.AutoSize = true;
            this.cbshowskills.Checked = true;
            this.cbshowskills.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowskills.Location = new System.Drawing.Point(25, 157);
            this.cbshowskills.Name = "cbshowskills";
            this.cbshowskills.Size = new System.Drawing.Size(136, 22);
            this.cbshowskills.TabIndex = 3;
            this.cbshowskills.Text = "Include Skills";
            this.cbshowskills.UseVisualStyleBackColor = true;
            // 
            // cbshowcharacter
            // 
            this.cbshowcharacter.AutoSize = true;
            this.cbshowcharacter.Checked = true;
            this.cbshowcharacter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowcharacter.Location = new System.Drawing.Point(25, 127);
            this.cbshowcharacter.Name = "cbshowcharacter";
            this.cbshowcharacter.Size = new System.Drawing.Size(214, 22);
            this.cbshowcharacter.TabIndex = 2;
            this.cbshowcharacter.Text = "Include Characteristics";
            this.cbshowcharacter.UseVisualStyleBackColor = true;
            // 
            // cbshowinterests
            // 
            this.cbshowinterests.AutoSize = true;
            this.cbshowinterests.Checked = true;
            this.cbshowinterests.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowinterests.Location = new System.Drawing.Point(25, 97);
            this.cbshowinterests.Name = "cbshowinterests";
            this.cbshowinterests.Size = new System.Drawing.Size(168, 22);
            this.cbshowinterests.TabIndex = 1;
            this.cbshowinterests.Text = "Include Interests";
            this.cbshowinterests.UseVisualStyleBackColor = true;
            // 
            // cbshowbasic
            // 
            this.cbshowbasic.AutoSize = true;
            this.cbshowbasic.Checked = true;
            this.cbshowbasic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbshowbasic.Location = new System.Drawing.Point(25, 37);
            this.cbshowbasic.Name = "cbshowbasic";
            this.cbshowbasic.Size = new System.Drawing.Size(181, 22);
            this.cbshowbasic.TabIndex = 0;
            this.cbshowbasic.Text = "Include Basic Stuff";
            this.cbshowbasic.UseVisualStyleBackColor = true;
            // 
            // Settims
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 399);
            this.Name = "Settims";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Output Options";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbshowbasic;
        private System.Windows.Forms.CheckBox cbshowuniversity;
        private System.Windows.Forms.CheckBox cbshowskills;
        private System.Windows.Forms.CheckBox cbshowcharacter;
        private System.Windows.Forms.CheckBox cbshowinterests;
        private System.Windows.Forms.CheckBox cbshowapartments;
        private System.Windows.Forms.CheckBox cbshowfreetime;
        private System.Windows.Forms.CheckBox cbshownpcs;
        private System.Windows.Forms.CheckBox cbshowdesc;
        private System.Windows.Forms.CheckBox cbshowpets;
        private System.Windows.Forms.CheckBox cbExcludeLots;
        private System.Windows.Forms.Label lbheader;
        private System.Windows.Forms.Button btdoned;
        private System.Windows.Forms.RadioButton rbcsv;
        private System.Windows.Forms.RadioButton rbtext;
        private System.Windows.Forms.Label lbtypy;
        private System.Windows.Forms.CheckBox cbshowbusi;
        //private TS2Logo simLogo;
    }
}