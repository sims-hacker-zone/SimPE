// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Windows.Forms;

namespace SimPe.Plugin.Scanner
{
	/// <summary>
	/// Summary description for ScannerPanelForm.
	/// </summary>
	internal class ScannerPanelForm : Form
	{
		private TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		internal Panel pncloth;
		private Label label1;
		private Label label2;
		private CheckBox cbswim;
		private CheckBox cbact;
		private CheckBox cbskin;
		private CheckBox cbformal;
		private CheckBox cbpreg;
		private CheckBox cbundies;
		private CheckBox cbpj;
		private CheckBox cbevery;
		private CheckBox cbelder;
		private CheckBox cbadult;
		private CheckBox cbyoung;
		private CheckBox cbteen;
		private CheckBox cbchild;
		private CheckBox cbtoddler;
		private CheckBox cbbaby;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		internal CheckBox[] cbages = new CheckBox[7];
		internal CheckBox[] cbsexes = new CheckBox[2];
		private LinkLabel llsetage;
		private LinkLabel llsetcat;
		private System.Windows.Forms.TabPage tabPage2;
		internal Panel pnep;
		private LinkLabel visualStyleLinkLabel1;
		private TextBox tbname;
		private Label label3;
		private System.Windows.Forms.TabPage tabPage3;
		internal Panel pnskin;
		private Label label4;
		private LinkLabel visualStyleLinkLabel2;
		private ComboBox cbskins;
		private SaveFileDialog sfd;
		private CheckBox cbtxmt;
		private CheckBox cbtxtr;
		private CheckBox cbref;
		private System.Windows.Forms.TabPage tabPage4;
		internal Panel pnShelve;
		private Label label5;
		internal Ambertation.Windows.Forms.EnumComboBox cbshelve;
		private LinkLabel llShelve;
		private CheckBox cbout;
		private LinkLabel llsetsex;
		private Label label6;
		private CheckBox cbmale;
		private CheckBox cbfemale;
		internal CheckBox[] cbcategories = new CheckBox[9];

		public ScannerPanelForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			cbages[0] = cbbaby;
			cbbaby.Tag = Data.Ages.Baby;
			cbages[1] = cbtoddler;
			cbtoddler.Tag = Data.Ages.Toddler;
			cbages[2] = cbchild;
			cbchild.Tag = Data.Ages.Child;
			cbages[3] = cbteen;
			cbteen.Tag = Data.Ages.Teen;
			cbages[4] = cbyoung;
			cbyoung.Tag = Data.Ages.YoungAdult;
			cbages[5] = cbadult;
			cbadult.Tag = Data.Ages.Adult;
			cbages[6] = cbelder;
			cbelder.Tag = Data.Ages.Elder;

			cbcategories[0] = cbact;
			cbact.Tag = Data.OutfitCats.Gym;
			cbcategories[1] = cbevery;
			cbevery.Tag = Data.OutfitCats.Everyday;
			cbcategories[2] = cbformal;
			cbformal.Tag = Data.OutfitCats.Formal;
			cbcategories[3] = cbpj;
			cbpj.Tag = Data.OutfitCats.Pyjamas;
			cbcategories[4] = cbpreg;
			cbpreg.Tag = Data.OutfitCats.Maternity;
			cbcategories[5] = cbskin;
			cbskin.Tag = Data.OutfitCats.Skin;
			cbcategories[6] = cbswim;
			cbswim.Tag = Data.OutfitCats.Swimsuit;
			cbcategories[7] = cbundies;
			cbundies.Tag = Data.OutfitCats.Underwear;
			cbcategories[8] = cbout;
			cbout.Tag = Data.OutfitCats.WinterWear;

			cbsexes[0] = cbmale;
			cbmale.Tag = Data.Gender.Male;
			cbsexes[1] = cbfemale;
			cbfemale.Tag = Data.Gender.Female;

			if (Helper.WindowsRegistry.Username.Trim() != "")
			{
				tbname.Text = Helper.WindowsRegistry.Username + "-";
			}

			cbskins.SelectedIndex = 0;
			sfd.InitialDirectory = PathProvider.SimSavegameFolder;

			cbshelve.Enum = typeof(PackedFiles.Wrapper.ShelveDimension);
			cbshelve.ResourceManager = Localization.Manager;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		static ScannerPanelForm form;
		public static ScannerPanelForm Form
		{
			get
			{
				if (form == null)
				{
					form = new ScannerPanelForm();
				}

				return form;
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tabControl1 = new TabControl();
			tabPage2 = new System.Windows.Forms.TabPage();
			pnep = new Panel();
			tbname = new TextBox();
			label3 = new Label();
			visualStyleLinkLabel1 = new LinkLabel();
			tabPage1 = new System.Windows.Forms.TabPage();
			pncloth = new Panel();
			label6 = new Label();
			cbmale = new CheckBox();
			cbfemale = new CheckBox();
			llsetsex = new LinkLabel();
			cbout = new CheckBox();
			llsetcat = new LinkLabel();
			llsetage = new LinkLabel();
			cbswim = new CheckBox();
			cbact = new CheckBox();
			cbskin = new CheckBox();
			cbformal = new CheckBox();
			cbpreg = new CheckBox();
			cbundies = new CheckBox();
			cbpj = new CheckBox();
			cbevery = new CheckBox();
			cbelder = new CheckBox();
			cbadult = new CheckBox();
			cbyoung = new CheckBox();
			cbteen = new CheckBox();
			cbchild = new CheckBox();
			cbtoddler = new CheckBox();
			cbbaby = new CheckBox();
			label2 = new Label();
			label1 = new Label();
			tabPage4 = new System.Windows.Forms.TabPage();
			pnShelve = new Panel();
			cbshelve = new Ambertation.Windows.Forms.EnumComboBox();
			label5 = new Label();
			llShelve = new LinkLabel();
			tabPage3 = new System.Windows.Forms.TabPage();
			pnskin = new Panel();
			cbtxtr = new CheckBox();
			cbtxmt = new CheckBox();
			cbskins = new ComboBox();
			label4 = new Label();
			visualStyleLinkLabel2 = new LinkLabel();
			cbref = new CheckBox();
			sfd = new SaveFileDialog();
			tabControl1.SuspendLayout();
			tabPage2.SuspendLayout();
			pnep.SuspendLayout();
			tabPage1.SuspendLayout();
			pncloth.SuspendLayout();
			tabPage4.SuspendLayout();
			pnShelve.SuspendLayout();
			tabPage3.SuspendLayout();
			pnskin.SuspendLayout();
			SuspendLayout();
			//
			// tabControl1
			//
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Location = new System.Drawing.Point(8, 8);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(432, 284);
			tabControl1.TabIndex = 0;
			//
			// tabPage2
			//
			tabPage2.Controls.Add(pnep);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(424, 258);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "EP-Ready?";
			//
			// pnep
			//
			pnep.Controls.Add(tbname);
			pnep.Controls.Add(label3);
			pnep.Controls.Add(visualStyleLinkLabel1);
			pnep.Location = new System.Drawing.Point(24, 8);
			pnep.Name = "pnep";
			pnep.Size = new System.Drawing.Size(289, 72);
			pnep.TabIndex = 0;
			//
			// tbname
			//
			tbname.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			tbname.Location = new System.Drawing.Point(23, 24);
			tbname.Name = "tbname";
			tbname.Size = new System.Drawing.Size(190, 21);
			tbname.TabIndex = 40;
			tbname.Text = "SimPe-";
			//
			// label3
			//
			label3.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,



							System.Drawing.FontStyle.Bold
							| System.Drawing.FontStyle.Italic


				,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label3.Location = new System.Drawing.Point(7, 8);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(128, 16);
			label3.TabIndex = 39;
			label3.Text = "Name Prefix:";
			//
			// visualStyleLinkLabel1
			//
			visualStyleLinkLabel1.AutoSize = true;
			visualStyleLinkLabel1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			visualStyleLinkLabel1.Location = new System.Drawing.Point(0, 56);
			visualStyleLinkLabel1.Name = "visualStyleLinkLabel1";
			visualStyleLinkLabel1.Size = new System.Drawing.Size(160, 13);
			visualStyleLinkLabel1.TabIndex = 38;
			visualStyleLinkLabel1.TabStop = true;
			visualStyleLinkLabel1.Text = "make University-Ready";
			visualStyleLinkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					MakeEPReady
				);
			//
			// tabPage1
			//
			tabPage1.Controls.Add(pncloth);
			tabPage1.Location = new System.Drawing.Point(4, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(424, 258);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Clothes";
			//
			// pncloth
			//
			pncloth.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			pncloth.Controls.Add(label6);
			pncloth.Controls.Add(cbmale);
			pncloth.Controls.Add(cbfemale);
			pncloth.Controls.Add(llsetsex);
			pncloth.Controls.Add(cbout);
			pncloth.Controls.Add(llsetcat);
			pncloth.Controls.Add(llsetage);
			pncloth.Controls.Add(cbswim);
			pncloth.Controls.Add(cbact);
			pncloth.Controls.Add(cbskin);
			pncloth.Controls.Add(cbformal);
			pncloth.Controls.Add(cbpreg);
			pncloth.Controls.Add(cbundies);
			pncloth.Controls.Add(cbpj);
			pncloth.Controls.Add(cbevery);
			pncloth.Controls.Add(cbelder);
			pncloth.Controls.Add(cbadult);
			pncloth.Controls.Add(cbyoung);
			pncloth.Controls.Add(cbteen);
			pncloth.Controls.Add(cbchild);
			pncloth.Controls.Add(cbtoddler);
			pncloth.Controls.Add(cbbaby);
			pncloth.Controls.Add(label2);
			pncloth.Controls.Add(label1);
			pncloth.Location = new System.Drawing.Point(24, 8);
			pncloth.Name = "pncloth";
			pncloth.Size = new System.Drawing.Size(386, 184);
			pncloth.TabIndex = 0;
			//
			// label6
			//
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,



							System.Drawing.FontStyle.Bold
							| System.Drawing.FontStyle.Italic


				,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label6.Location = new System.Drawing.Point(24, 139);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(58, 13);
			label6.TabIndex = 43;
			label6.Text = "Gender:";
			//
			// cbmale
			//
			cbmale.FlatStyle = FlatStyle.System;
			cbmale.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbmale.Location = new System.Drawing.Point(104, 155);
			cbmale.Name = "cbmale";
			cbmale.Size = new System.Drawing.Size(80, 24);
			cbmale.TabIndex = 42;
			cbmale.Text = "Male";
			//
			// cbfemale
			//
			cbfemale.FlatStyle = FlatStyle.System;
			cbfemale.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbfemale.Location = new System.Drawing.Point(16, 155);
			cbfemale.Name = "cbfemale";
			cbfemale.Size = new System.Drawing.Size(80, 24);
			cbfemale.TabIndex = 41;
			cbfemale.Text = "Female";
			//
			// llsetsex
			//
			llsetsex.AutoSize = true;
			llsetsex.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llsetsex.Location = new System.Drawing.Point(0, 139);
			llsetsex.Name = "llsetsex";
			llsetsex.Size = new System.Drawing.Size(27, 13);
			llsetsex.TabIndex = 40;
			llsetsex.TabStop = true;
			llsetsex.Text = "set";
			llsetsex.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(setSex);
			//
			// cbout
			//
			cbout.FlatStyle = FlatStyle.System;
			cbout.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbout.Location = new System.Drawing.Point(256, 112);
			cbout.Name = "cbout";
			cbout.Size = new System.Drawing.Size(101, 24);
			cbout.TabIndex = 39;
			cbout.Text = "Winter Wear";
			//
			// llsetcat
			//
			llsetcat.AutoSize = true;
			llsetcat.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llsetcat.Location = new System.Drawing.Point(0, 72);
			llsetcat.Name = "llsetcat";
			llsetcat.Size = new System.Drawing.Size(27, 13);
			llsetcat.TabIndex = 38;
			llsetcat.TabStop = true;
			llsetcat.Text = "set";
			llsetcat.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(SetCat);
			//
			// llsetage
			//
			llsetage.AutoSize = true;
			llsetage.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llsetage.Location = new System.Drawing.Point(0, 8);
			llsetage.Name = "llsetage";
			llsetage.Size = new System.Drawing.Size(27, 13);
			llsetage.TabIndex = 37;
			llsetage.TabStop = true;
			llsetage.Text = "set";
			llsetage.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(setAge);
			//
			// cbswim
			//
			cbswim.FlatStyle = FlatStyle.System;
			cbswim.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbswim.Location = new System.Drawing.Point(16, 112);
			cbswim.Name = "cbswim";
			cbswim.Size = new System.Drawing.Size(80, 24);
			cbswim.TabIndex = 36;
			cbswim.Text = "Swim Suit";
			//
			// cbact
			//
			cbact.FlatStyle = FlatStyle.System;
			cbact.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbact.Location = new System.Drawing.Point(192, 112);
			cbact.Name = "cbact";
			cbact.Size = new System.Drawing.Size(50, 24);
			cbact.TabIndex = 35;
			cbact.Text = "Gym";
			cbact.CheckedChanged += new EventHandler(
				cbact_CheckedChanged
			);
			//
			// cbskin
			//
			cbskin.FlatStyle = FlatStyle.System;
			cbskin.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbskin.Location = new System.Drawing.Point(256, 136);
			cbskin.Name = "cbskin";
			cbskin.Size = new System.Drawing.Size(56, 24);
			cbskin.TabIndex = 34;
			cbskin.Text = "Skin";
			//
			// cbformal
			//
			cbformal.FlatStyle = FlatStyle.System;
			cbformal.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbformal.Location = new System.Drawing.Point(182, 88);
			cbformal.Name = "cbformal";
			cbformal.Size = new System.Drawing.Size(64, 24);
			cbformal.TabIndex = 33;
			cbformal.Text = "Formal";
			//
			// cbpreg
			//
			cbpreg.FlatStyle = FlatStyle.System;
			cbpreg.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbpreg.Location = new System.Drawing.Point(256, 88);
			cbpreg.Name = "cbpreg";
			cbpreg.Size = new System.Drawing.Size(75, 24);
			cbpreg.TabIndex = 32;
			cbpreg.Text = "Maternity";
			//
			// cbundies
			//
			cbundies.FlatStyle = FlatStyle.System;
			cbundies.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbundies.Location = new System.Drawing.Point(104, 112);
			cbundies.Name = "cbundies";
			cbundies.Size = new System.Drawing.Size(82, 24);
			cbundies.TabIndex = 31;
			cbundies.Text = "Underwear";
			//
			// cbpj
			//
			cbpj.FlatStyle = FlatStyle.System;
			cbpj.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbpj.Location = new System.Drawing.Point(104, 88);
			cbpj.Name = "cbpj";
			cbpj.Size = new System.Drawing.Size(72, 24);
			cbpj.TabIndex = 30;
			cbpj.Text = "Pyjamas";
			//
			// cbevery
			//
			cbevery.FlatStyle = FlatStyle.System;
			cbevery.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbevery.Location = new System.Drawing.Point(16, 88);
			cbevery.Name = "cbevery";
			cbevery.Size = new System.Drawing.Size(80, 24);
			cbevery.TabIndex = 29;
			cbevery.Text = "Everyday";
			//
			// cbelder
			//
			cbelder.FlatStyle = FlatStyle.System;
			cbelder.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbelder.Location = new System.Drawing.Point(182, 48);
			cbelder.Name = "cbelder";
			cbelder.Size = new System.Drawing.Size(64, 24);
			cbelder.TabIndex = 28;
			cbelder.Text = "Elder";
			//
			// cbadult
			//
			cbadult.FlatStyle = FlatStyle.System;
			cbadult.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbadult.Location = new System.Drawing.Point(112, 48);
			cbadult.Name = "cbadult";
			cbadult.Size = new System.Drawing.Size(64, 24);
			cbadult.TabIndex = 27;
			cbadult.Text = "Adult";
			//
			// cbyoung
			//
			cbyoung.FlatStyle = FlatStyle.System;
			cbyoung.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbyoung.Location = new System.Drawing.Point(16, 48);
			cbyoung.Name = "cbyoung";
			cbyoung.Size = new System.Drawing.Size(88, 24);
			cbyoung.TabIndex = 26;
			cbyoung.Text = "young Adult";
			//
			// cbteen
			//
			cbteen.FlatStyle = FlatStyle.System;
			cbteen.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbteen.Location = new System.Drawing.Point(256, 24);
			cbteen.Name = "cbteen";
			cbteen.Size = new System.Drawing.Size(80, 24);
			cbteen.TabIndex = 25;
			cbteen.Text = "Teenager";
			//
			// cbchild
			//
			cbchild.FlatStyle = FlatStyle.System;
			cbchild.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbchild.Location = new System.Drawing.Point(182, 24);
			cbchild.Name = "cbchild";
			cbchild.Size = new System.Drawing.Size(64, 24);
			cbchild.TabIndex = 24;
			cbchild.Text = "Child";
			//
			// cbtoddler
			//
			cbtoddler.FlatStyle = FlatStyle.System;
			cbtoddler.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbtoddler.Location = new System.Drawing.Point(104, 24);
			cbtoddler.Name = "cbtoddler";
			cbtoddler.Size = new System.Drawing.Size(64, 24);
			cbtoddler.TabIndex = 23;
			cbtoddler.Text = "Toddler";
			//
			// cbbaby
			//
			cbbaby.FlatStyle = FlatStyle.System;
			cbbaby.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			cbbaby.Location = new System.Drawing.Point(16, 24);
			cbbaby.Name = "cbbaby";
			cbbaby.Size = new System.Drawing.Size(64, 24);
			cbbaby.TabIndex = 22;
			cbbaby.Text = "Baby";
			//
			// label2
			//
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,



							System.Drawing.FontStyle.Bold
							| System.Drawing.FontStyle.Italic


				,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label2.Location = new System.Drawing.Point(24, 72);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(80, 13);
			label2.TabIndex = 1;
			label2.Text = "Categories:";
			//
			// label1
			//
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,



							System.Drawing.FontStyle.Bold
							| System.Drawing.FontStyle.Italic


				,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label1.Location = new System.Drawing.Point(24, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 13);
			label1.TabIndex = 0;
			label1.Text = "Ages:";
			//
			// tabPage4
			//
			tabPage4.Controls.Add(pnShelve);
			tabPage4.Location = new System.Drawing.Point(4, 22);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new System.Drawing.Size(424, 258);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "SheleveReady?";
			//
			// pnShelve
			//
			pnShelve.Controls.Add(cbshelve);
			pnShelve.Controls.Add(label5);
			pnShelve.Controls.Add(llShelve);
			pnShelve.Location = new System.Drawing.Point(8, 8);
			pnShelve.Name = "pnShelve";
			pnShelve.Size = new System.Drawing.Size(361, 72);
			pnShelve.TabIndex = 1;
			//
			// cbshelve
			//
			cbshelve.Anchor =



							AnchorStyles.Top
							| AnchorStyles.Left
						 | AnchorStyles.Right


			;
			cbshelve.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbshelve.Enum = null;
			cbshelve.Location = new System.Drawing.Point(16, 24);
			cbshelve.Name = "cbshelve";
			cbshelve.ResourceManager = null;
			cbshelve.Size = new System.Drawing.Size(329, 21);
			cbshelve.TabIndex = 40;
			cbshelve.SelectedIndexChanged += new EventHandler(
				cbshelve_SelectedIndexChanged
			);
			//
			// label5
			//
			label5.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,



							System.Drawing.FontStyle.Bold
							| System.Drawing.FontStyle.Italic


				,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label5.Location = new System.Drawing.Point(0, 8);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(128, 16);
			label5.TabIndex = 39;
			label5.Text = "Dimension:";
			//
			// llShelve
			//
			llShelve.AutoSize = true;
			llShelve.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			llShelve.Location = new System.Drawing.Point(0, 56);
			llShelve.Name = "llShelve";
			llShelve.Size = new System.Drawing.Size(147, 13);
			llShelve.TabIndex = 38;
			llShelve.TabStop = true;
			llShelve.Text = "set Shelve Dimension";
			llShelve.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					visualStyleLinkLabel3_LinkClicked
				);
			//
			// tabPage3
			//
			tabPage3.Controls.Add(pnskin);
			tabPage3.Location = new System.Drawing.Point(4, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(424, 258);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Skin";
			//
			// pnskin
			//
			pnskin.Controls.Add(cbtxtr);
			pnskin.Controls.Add(cbtxmt);
			pnskin.Controls.Add(cbskins);
			pnskin.Controls.Add(label4);
			pnskin.Controls.Add(visualStyleLinkLabel2);
			pnskin.Controls.Add(cbref);
			pnskin.Location = new System.Drawing.Point(24, 8);
			pnskin.Name = "pnskin";
			pnskin.Size = new System.Drawing.Size(343, 120);
			pnskin.TabIndex = 1;
			//
			// cbtxtr
			//
			cbtxtr.Checked = true;
			cbtxtr.CheckState = CheckState.Checked;
			cbtxtr.FlatStyle = FlatStyle.System;
			cbtxtr.Location = new System.Drawing.Point(136, 48);
			cbtxtr.Name = "cbtxtr";
			cbtxtr.Size = new System.Drawing.Size(104, 24);
			cbtxtr.TabIndex = 42;
			cbtxtr.Text = "override TXTR";
			//
			// cbtxmt
			//
			cbtxmt.Checked = true;
			cbtxmt.CheckState = CheckState.Checked;
			cbtxmt.FlatStyle = FlatStyle.System;
			cbtxmt.Location = new System.Drawing.Point(16, 48);
			cbtxmt.Name = "cbtxmt";
			cbtxmt.Size = new System.Drawing.Size(112, 24);
			cbtxmt.TabIndex = 41;
			cbtxmt.Text = "override TXMT";
			//
			// cbskins
			//
			cbskins.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbskins.Items.AddRange(
				new object[]
				{
					"Light",
					"Normal",
					"Medium",
					"Dark",
					"Alien",
					"Zombie",
					"Mannequin",
					"CAS Mannequin",
					"Vampire",
				}
			);
			cbskins.Location = new System.Drawing.Point(16, 24);
			cbskins.Name = "cbskins";
			cbskins.Size = new System.Drawing.Size(256, 21);
			cbskins.TabIndex = 40;
			//
			// label4
			//
			label4.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,



							System.Drawing.FontStyle.Bold
							| System.Drawing.FontStyle.Italic


				,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			label4.Location = new System.Drawing.Point(0, 8);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(128, 16);
			label4.TabIndex = 39;
			label4.Text = "Base Skin:";
			//
			// visualStyleLinkLabel2
			//
			visualStyleLinkLabel2.AutoSize = true;
			visualStyleLinkLabel2.Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Bold,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			visualStyleLinkLabel2.Location = new System.Drawing.Point(0, 96);
			visualStyleLinkLabel2.Name = "visualStyleLinkLabel2";
			visualStyleLinkLabel2.Size = new System.Drawing.Size(191, 13);
			visualStyleLinkLabel2.TabIndex = 38;
			visualStyleLinkLabel2.TabStop = true;
			visualStyleLinkLabel2.Text = "create default Skin override";
			visualStyleLinkLabel2.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					CreateSkinOverride
				);
			//
			// cbref
			//
			cbref.FlatStyle = FlatStyle.System;
			cbref.Location = new System.Drawing.Point(16, 68);
			cbref.Name = "cbref";
			cbref.Size = new System.Drawing.Size(136, 24);
			cbref.TabIndex = 43;
			cbref.Text = "override Reference";
			//
			// sfd
			//
			sfd.Filter = "Package File (*.package)|*.package|All Files (*.*)|*.*";
			sfd.Title = "Skin Override";
			//
			// ScannerPanelForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			ClientSize = new System.Drawing.Size(736, 357);
			Controls.Add(tabControl1);
			Font = new System.Drawing.Font(
				"Verdana",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			Name = "ScannerPanelForm";
			Text = "ScannerPanelForm";
			tabControl1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			pnep.ResumeLayout(false);
			pnep.PerformLayout();
			tabPage1.ResumeLayout(false);
			pncloth.ResumeLayout(false);
			pncloth.PerformLayout();
			tabPage4.ResumeLayout(false);
			pnShelve.ResumeLayout(false);
			pnShelve.PerformLayout();
			tabPage3.ResumeLayout(false);
			pnskin.ResumeLayout(false);
			pnskin.PerformLayout();
			ResumeLayout(false);
		}
		#endregion



		private void SetCat(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			ClothingScanner cs = (ClothingScanner)pncloth.Tag;
			cs.SetCategory();
		}

		private void setAge(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			ClothingScanner cs = (ClothingScanner)pncloth.Tag;
			cs.SetAge();
		}

		private void setSex(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ClothingScanner cs = (ClothingScanner)pncloth.Tag;
			cs.SetSex();
		}

		private void MakeEPReady(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			EPReadyScanner cs = (EPReadyScanner)pnep.Tag;
			cs.Fix(tbname.Text);
		}

		private void CreateSkinOverride(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (!cbtxtr.Checked && !cbtxmt.Checked && !cbref.Checked)
			{
				MessageBox.Show("Please select at least one Checkbox!");
				return;
			}

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string skintone = "";
				string family = "";
				if (cbskins.SelectedIndex < 4)
				{
					skintone =
						"0000000"
						+ (cbskins.SelectedIndex + 1).ToString()
						+ "-0000-0000-0000-000000000000";
				}
				else if (cbskins.SelectedIndex == 4)
				{
					skintone = "6baf064a-85ad-4e37-8d81-a987e9f8da46"; //Alien Skin
				}
				else if (cbskins.SelectedIndex == 5)
				{
					skintone = "b6ee1dbc-5bb3-4146-8315-02bd64eda707"; //Zombie Skin
				}
				else if (cbskins.SelectedIndex == 6)
				{
					skintone = "b9a94827-7544-450c-a8f4-6f643ae89a71"; //Mannequin Skin
				}
				else if (cbskins.SelectedIndex == 7)
				{
					skintone = "6eea47c7-8a35-4be7-9242-dcd082f53b55"; //CAS Mannequin Skin
				}
				else if (cbskins.SelectedIndex == 8)
				{
					skintone = "00000000-0000-0000-0000-000000000000"; //Vampire
				}

				if (cbskins.SelectedIndex < 4)
				{
					family = "21afb87c-e872-4f4c-af3c-c3685ed4e220";
				}
				else if (cbskins.SelectedIndex == 4)
				{
					family = "ad5da337-bdd1-4593-acdd-19001595cbbb"; //Alien Skin
				}
				else if (cbskins.SelectedIndex == 5)
				{
					family = "b6ee1dbc-5bb3-4146-8315-02bd64eda707"; //Zombie Skin
				}
				else if (cbskins.SelectedIndex == 6)
				{
					family = "59621330-1005-4b88-b4f2-77deb751fcf3"; //Mannequin Skin
				}
				else if (cbskins.SelectedIndex == 7)
				{
					family = "59621330-1005-4b88-b4f2-77deb751fcf3"; //CAS Mannequin Skin
				}
				else if (cbskins.SelectedIndex == 8)
				{
					family = "13ae91e7-b825-4559-82a3-0ead8e8dd7fd"; //Vampire
				}

				SkinScanner cs = (SkinScanner)pnskin.Tag;
				cs.CreateOverride(
					skintone,
					family,
					sfd.FileName,
					cbtxmt.Checked,
					cbtxtr.Checked,
					cbref.Checked
				);
			}
		}

		private void visualStyleLinkLabel3_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			PackedFiles.Wrapper.ShelveDimension sd =
				(PackedFiles.Wrapper.ShelveDimension)cbshelve.SelectedValue;
			ShelveScanner cs = (ShelveScanner)pnShelve.Tag;
			cs.Set(sd);
		}

		private void cbshelve_SelectedIndexChanged(object sender, EventArgs e)
		{
			PackedFiles.Wrapper.ShelveDimension sd =
				(PackedFiles.Wrapper.ShelveDimension)cbshelve.SelectedValue;
			llShelve.Enabled =
				sd != PackedFiles.Wrapper.ShelveDimension.Indetermined
				&& sd != PackedFiles.Wrapper.ShelveDimension.Multitile
				&& sd != PackedFiles.Wrapper.ShelveDimension.Unknown1
				&& sd != PackedFiles.Wrapper.ShelveDimension.Unknown2
			;
		}

		private void cbact_CheckedChanged(object sender, EventArgs e)
		{
		}
	}
}
