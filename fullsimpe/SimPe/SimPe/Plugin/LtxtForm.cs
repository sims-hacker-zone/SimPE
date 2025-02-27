/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *   Copyright (C) 2008 Peter L Jones                                      *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for LtxtForm.
	/// </summary>
	public class LtxtForm : Form
	{
		#region Form controls
		internal Panel ltxtPanel;
		private Panel panel2;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label11;
		private Label label12;
		private Label label13;
		private Label label14;
		private Label label15;
		private Label label16;
		private Label label17;
		private Label label18;
		private Label label19;
		private Label label20;
		private Label label21;
		private Label label22;
		private Label label23;
		private Label label24;
		internal Label label25;
		private Label label30;
		private Label label31;
		private Label label32;
		internal LinkLabel llFamily;
		internal LinkLabel llSubLot;
		internal LinkLabel llAptBase;
		internal LinkLabel llunknone;
		internal GroupBox gbApartment;
		internal GroupBox gbclarse;
		internal GroupBox gbunown;
		private GroupBox gbFlagg;
		internal GroupBox gbApart;
		internal GroupBox gbtravel;
		internal GroupBox gbhobby;
		internal TextBox tblotname;
		internal TextBox tbdesc;
		internal TextBox tbRoads;
		internal TextBox tbrotation;
		internal TextBox tbtype;
		internal TextBox tbver;
		internal TextBox tbsubver;
		internal TextBox tbhg;
		internal TextBox tbwd;
		internal TextBox tbtop;
		internal TextBox tbleft;
		internal TextBox tbinst;
		internal TextBox tbu2;
		internal ListBox lb;
		internal TextBox tbz;
		internal TextBox tbData;
		internal TextBox tbu0;
		internal TextBox tbu4;
		internal TextBox tbu3;
		internal TextBox tbTexture;
		internal TextBox tbowner;
		internal TextBox tbu5;
		internal TextBox tbApBase;
		internal TextBox tbu6;
		internal ListBox lbApts;
		internal TextBox tbElevationAt;
		internal TextBox tbApartment;
		internal TextBox tbSAu3;
		internal TextBox tbSAu2;
		internal TextBox tbSAFamily;
		internal ListBox lbu7;
		internal TextBox tbu7;
		internal TextBox tblotclass;
		internal TextBox tbcset;
		internal ComboBox cbtype;
		internal ComboBox cbLotClas;
		internal Ambertation.Windows.Forms.EnumComboBox cborient;
		internal CheckBox cbhidim;
		internal CheckBox cbhbmusic;
		internal CheckBox cbhbsport;
		internal CheckBox cbhbscience;
		internal CheckBox cbhbfitness;
		internal CheckBox cbhbtinker;
		internal CheckBox cbhbnature;
		internal CheckBox cbhbgames;
		internal CheckBox cbhbfilm;
		internal CheckBox cbhbart;
		internal CheckBox cbhbcook;
		internal CheckBox cbtrjflag5;
		internal CheckBox cbtrjflag4;
		internal CheckBox cbtrjflag3;
		internal CheckBox cbtrjflag2;
		internal CheckBox cbtrjflag1;
		internal CheckBox cbtrjungle;
		internal CheckBox cbtrhidec;
		internal CheckBox cbtrpool;
		internal CheckBox cbtrmale;
		internal CheckBox cbtrfem;
		internal CheckBox cbtrbeach;
		internal CheckBox cbtrformal;
		internal CheckBox cbtrteen;
		internal CheckBox cbtrnude;
		internal CheckBox cbtrpern;
		internal CheckBox cgtrwhite;
		internal CheckBox cbtrblue;
		internal CheckBox cbtrredred;
		internal CheckBox cbtradult;
		internal CheckBox cbtrclub;
		internal CheckBox cbBeachy;
		internal PictureBox pb;
		internal Button btnDelApt;
		internal Button btnAddApt;
		internal Button bthbytrvl;
		internal Label lbPlayim;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public LtxtForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			wrapper = null;
			cborient.ResourceManager = Localization.Manager;
			cborient.Enum = typeof(LotOrientation);

			if (!Helper.WindowsRegistry.UseBigIcons)
			{
				pb.Size = new Size(124, 108);
				pb.Location = new Point(25, 56);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(LtxtForm));
			ltxtPanel = new Panel();
			lbPlayim = new Label();
			gbApart = new GroupBox();
			label22 = new Label();
			gbApartment = new GroupBox();
			llFamily = new LinkLabel();
			tbApartment = new TextBox();
			tbSAu2 = new TextBox();
			llSubLot = new LinkLabel();
			label31 = new Label();
			tbSAu3 = new TextBox();
			label30 = new Label();
			tbSAFamily = new TextBox();
			lbApts = new ListBox();
			tbApBase = new TextBox();
			llAptBase = new LinkLabel();
			btnDelApt = new Button();
			btnAddApt = new Button();
			tbdesc = new TextBox();
			gbtravel = new GroupBox();
			cbtrjflag5 = new CheckBox();
			cbtrjflag4 = new CheckBox();
			cbtrjflag3 = new CheckBox();
			cbtrjflag2 = new CheckBox();
			cbtrjflag1 = new CheckBox();
			cbtrjungle = new CheckBox();
			cbtrhidec = new CheckBox();
			cbtrpool = new CheckBox();
			cbtrmale = new CheckBox();
			cbtrfem = new CheckBox();
			cbtrbeach = new CheckBox();
			cbtrformal = new CheckBox();
			cbtrteen = new CheckBox();
			cbtrnude = new CheckBox();
			cbtrpern = new CheckBox();
			cgtrwhite = new CheckBox();
			cbtrblue = new CheckBox();
			cbtrredred = new CheckBox();
			cbtradult = new CheckBox();
			cbtrclub = new CheckBox();
			label5 = new Label();
			tblotname = new TextBox();
			gbhobby = new GroupBox();
			cbhbmusic = new CheckBox();
			cbhbsport = new CheckBox();
			cbhbscience = new CheckBox();
			cbhbfitness = new CheckBox();
			cbhbtinker = new CheckBox();
			cbhbnature = new CheckBox();
			cbhbgames = new CheckBox();
			cbhbfilm = new CheckBox();
			cbhbart = new CheckBox();
			cbhbcook = new CheckBox();
			label4 = new Label();
			llunknone = new LinkLabel();
			gbFlagg = new GroupBox();
			tbu0 = new TextBox();
			label21 = new Label();
			cbBeachy = new CheckBox();
			cbhidim = new CheckBox();
			gbunown = new GroupBox();
			tbu2 = new TextBox();
			label18 = new Label();
			label32 = new Label();
			label19 = new Label();
			lbu7 = new ListBox();
			tbu3 = new TextBox();
			label16 = new Label();
			tbData = new TextBox();
			tbu7 = new TextBox();
			tbu5 = new TextBox();
			label24 = new Label();
			tbu6 = new TextBox();
			label23 = new Label();
			gbclarse = new GroupBox();
			label11 = new Label();
			cbLotClas = new ComboBox();
			tbcset = new TextBox();
			tblotclass = new TextBox();
			label17 = new Label();
			label7 = new Label();
			lb = new ListBox();
			tbElevationAt = new TextBox();
			label25 = new Label();
			tbowner = new TextBox();
			label15 = new Label();
			label8 = new Label();
			bthbytrvl = new Button();
			tbinst = new TextBox();
			label14 = new Label();
			tbu4 = new TextBox();
			cborient = new Ambertation.Windows.Forms.EnumComboBox();
			tbTexture = new TextBox();
			label2 = new Label();
			label6 = new Label();
			label3 = new Label();
			tbwd = new TextBox();
			tbrotation = new TextBox();
			label9 = new Label();
			label10 = new Label();
			tbhg = new TextBox();
			tbRoads = new TextBox();
			label12 = new Label();
			tbver = new TextBox();
			tbtop = new TextBox();
			label13 = new Label();
			tbsubver = new TextBox();
			tbleft = new TextBox();
			label20 = new Label();
			label1 = new Label();
			tbz = new TextBox();
			cbtype = new ComboBox();
			tbtype = new TextBox();
			panel2 = new Panel();
			pb = new PictureBox();
			ltxtPanel.SuspendLayout();
			gbApart.SuspendLayout();
			gbApartment.SuspendLayout();
			gbtravel.SuspendLayout();
			gbhobby.SuspendLayout();
			gbFlagg.SuspendLayout();
			gbunown.SuspendLayout();
			gbclarse.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(pb)).BeginInit();
			SuspendLayout();
			//
			// ltxtPanel
			//
			resources.ApplyResources(ltxtPanel, "ltxtPanel");
			ltxtPanel.BackColor = Color.Transparent;
			ltxtPanel.Controls.Add(lbPlayim);
			ltxtPanel.Controls.Add(gbApart);
			ltxtPanel.Controls.Add(tbdesc);
			ltxtPanel.Controls.Add(gbtravel);
			ltxtPanel.Controls.Add(label5);
			ltxtPanel.Controls.Add(tblotname);
			ltxtPanel.Controls.Add(gbhobby);
			ltxtPanel.Controls.Add(label4);
			ltxtPanel.Controls.Add(llunknone);
			ltxtPanel.Controls.Add(gbFlagg);
			ltxtPanel.Controls.Add(gbunown);
			ltxtPanel.Controls.Add(gbclarse);
			ltxtPanel.Controls.Add(label7);
			ltxtPanel.Controls.Add(lb);
			ltxtPanel.Controls.Add(tbElevationAt);
			ltxtPanel.Controls.Add(label25);
			ltxtPanel.Controls.Add(tbowner);
			ltxtPanel.Controls.Add(label15);
			ltxtPanel.Controls.Add(label8);
			ltxtPanel.Controls.Add(bthbytrvl);
			ltxtPanel.Controls.Add(tbinst);
			ltxtPanel.Controls.Add(label14);
			ltxtPanel.Controls.Add(tbu4);
			ltxtPanel.Controls.Add(cborient);
			ltxtPanel.Controls.Add(tbTexture);
			ltxtPanel.Controls.Add(label2);
			ltxtPanel.Controls.Add(label6);
			ltxtPanel.Controls.Add(label3);
			ltxtPanel.Controls.Add(tbwd);
			ltxtPanel.Controls.Add(tbrotation);
			ltxtPanel.Controls.Add(label9);
			ltxtPanel.Controls.Add(label10);
			ltxtPanel.Controls.Add(tbhg);
			ltxtPanel.Controls.Add(tbRoads);
			ltxtPanel.Controls.Add(label12);
			ltxtPanel.Controls.Add(tbver);
			ltxtPanel.Controls.Add(tbtop);
			ltxtPanel.Controls.Add(label13);
			ltxtPanel.Controls.Add(tbsubver);
			ltxtPanel.Controls.Add(tbleft);
			ltxtPanel.Controls.Add(label20);
			ltxtPanel.Controls.Add(label1);
			ltxtPanel.Controls.Add(tbz);
			ltxtPanel.Controls.Add(cbtype);
			ltxtPanel.Controls.Add(tbtype);
			ltxtPanel.Controls.Add(panel2);
			ltxtPanel.Controls.Add(pb);
			ltxtPanel.Name = "ltxtPanel";
			//
			// lbPlayim
			//
			resources.ApplyResources(lbPlayim, "lbPlayim");
			lbPlayim.ForeColor = Color.Blue;
			lbPlayim.Name = "lbPlayim";
			//
			// gbApart
			//
			gbApart.Controls.Add(label22);
			gbApart.Controls.Add(gbApartment);
			gbApart.Controls.Add(lbApts);
			gbApart.Controls.Add(tbApBase);
			gbApart.Controls.Add(llAptBase);
			gbApart.Controls.Add(btnDelApt);
			gbApart.Controls.Add(btnAddApt);
			resources.ApplyResources(gbApart, "gbApart");
			gbApart.Name = "gbApart";
			gbApart.TabStop = false;
			//
			// label22
			//
			resources.ApplyResources(label22, "label22");
			label22.Name = "label22";
			//
			// gbApartment
			//
			resources.ApplyResources(gbApartment, "gbApartment");
			gbApartment.Controls.Add(llFamily);
			gbApartment.Controls.Add(tbApartment);
			gbApartment.Controls.Add(tbSAu2);
			gbApartment.Controls.Add(llSubLot);
			gbApartment.Controls.Add(label31);
			gbApartment.Controls.Add(tbSAu3);
			gbApartment.Controls.Add(label30);
			gbApartment.Controls.Add(tbSAFamily);
			gbApartment.Name = "gbApartment";
			gbApartment.TabStop = false;
			//
			// llFamily
			//
			resources.ApplyResources(llFamily, "llFamily");
			llFamily.Name = "llFamily";
			llFamily.TabStop = true;
			llFamily.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ll_Click
				);
			//
			// tbApartment
			//
			resources.ApplyResources(tbApartment, "tbApartment");
			tbApartment.Name = "tbApartment";
			tbApartment.TextChanged += new EventHandler(SAChange);
			//
			// tbSAu2
			//
			resources.ApplyResources(tbSAu2, "tbSAu2");
			tbSAu2.Name = "tbSAu2";
			tbSAu2.TextChanged += new EventHandler(SAChange);
			//
			// llSubLot
			//
			resources.ApplyResources(llSubLot, "llSubLot");
			llSubLot.Name = "llSubLot";
			llSubLot.TabStop = true;
			llSubLot.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ll_Click
				);
			//
			// label31
			//
			resources.ApplyResources(label31, "label31");
			label31.Name = "label31";
			//
			// tbSAu3
			//
			resources.ApplyResources(tbSAu3, "tbSAu3");
			tbSAu3.Name = "tbSAu3";
			tbSAu3.TextChanged += new EventHandler(SAChange);
			//
			// label30
			//
			resources.ApplyResources(label30, "label30");
			label30.Name = "label30";
			//
			// tbSAFamily
			//
			resources.ApplyResources(tbSAFamily, "tbSAFamily");
			tbSAFamily.Name = "tbSAFamily";
			tbSAFamily.TextChanged += new EventHandler(SAChange);
			//
			// lbApts
			//
			resources.ApplyResources(lbApts, "lbApts");
			lbApts.Items.AddRange(
				new object[]
				{
					resources.GetString("lbApts.Items"),
					resources.GetString("lbApts.Items1"),
					resources.GetString("lbApts.Items2"),
					resources.GetString("lbApts.Items3"),
				}
			);
			lbApts.MinimumSize = new Size(0, 44);
			lbApts.MultiColumn = true;
			lbApts.Name = "lbApts";
			lbApts.SelectedIndexChanged += new EventHandler(
				lbApts_SelectedIndexChanged
			);
			//
			// tbApBase
			//
			resources.ApplyResources(tbApBase, "tbApBase");
			tbApBase.Name = "tbApBase";
			tbApBase.TextChanged += new EventHandler(
				tbApBase_TextChanged
			);
			//
			// llAptBase
			//
			resources.ApplyResources(llAptBase, "llAptBase");
			llAptBase.Name = "llAptBase";
			llAptBase.TabStop = true;
			llAptBase.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					ll_Click
				);
			//
			// btnDelApt
			//
			resources.ApplyResources(btnDelApt, "btnDelApt");
			btnDelApt.Name = "btnDelApt";
			btnDelApt.UseVisualStyleBackColor = true;
			btnDelApt.Click += new EventHandler(btnDelApt_Click);
			//
			// btnAddApt
			//
			resources.ApplyResources(btnAddApt, "btnAddApt");
			btnAddApt.Name = "btnAddApt";
			btnAddApt.UseVisualStyleBackColor = true;
			btnAddApt.Click += new EventHandler(btnAddApt_Click);
			//
			// tbdesc
			//
			resources.ApplyResources(tbdesc, "tbdesc");
			tbdesc.Name = "tbdesc";
			tbdesc.TextChanged += new EventHandler(CommonChange);
			//
			// gbtravel
			//
			gbtravel.BackColor = Color.Transparent;
			gbtravel.Controls.Add(cbtrjflag5);
			gbtravel.Controls.Add(cbtrjflag4);
			gbtravel.Controls.Add(cbtrjflag3);
			gbtravel.Controls.Add(cbtrjflag2);
			gbtravel.Controls.Add(cbtrjflag1);
			gbtravel.Controls.Add(cbtrjungle);
			gbtravel.Controls.Add(cbtrhidec);
			gbtravel.Controls.Add(cbtrpool);
			gbtravel.Controls.Add(cbtrmale);
			gbtravel.Controls.Add(cbtrfem);
			gbtravel.Controls.Add(cbtrbeach);
			gbtravel.Controls.Add(cbtrformal);
			gbtravel.Controls.Add(cbtrteen);
			gbtravel.Controls.Add(cbtrnude);
			gbtravel.Controls.Add(cbtrpern);
			gbtravel.Controls.Add(cgtrwhite);
			gbtravel.Controls.Add(cbtrblue);
			gbtravel.Controls.Add(cbtrredred);
			gbtravel.Controls.Add(cbtradult);
			gbtravel.Controls.Add(cbtrclub);
			resources.ApplyResources(gbtravel, "gbtravel");
			gbtravel.Name = "gbtravel";
			gbtravel.TabStop = false;
			//
			// cbtrjflag5
			//
			resources.ApplyResources(cbtrjflag5, "cbtrjflag5");
			cbtrjflag5.Name = "cbtrjflag5";
			cbtrjflag5.UseVisualStyleBackColor = true;
			cbtrjflag5.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrjflag4
			//
			resources.ApplyResources(cbtrjflag4, "cbtrjflag4");
			cbtrjflag4.Name = "cbtrjflag4";
			cbtrjflag4.UseVisualStyleBackColor = true;
			cbtrjflag4.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrjflag3
			//
			resources.ApplyResources(cbtrjflag3, "cbtrjflag3");
			cbtrjflag3.Name = "cbtrjflag3";
			cbtrjflag3.UseVisualStyleBackColor = true;
			cbtrjflag3.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrjflag2
			//
			resources.ApplyResources(cbtrjflag2, "cbtrjflag2");
			cbtrjflag2.Name = "cbtrjflag2";
			cbtrjflag2.UseVisualStyleBackColor = true;
			cbtrjflag2.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrjflag1
			//
			resources.ApplyResources(cbtrjflag1, "cbtrjflag1");
			cbtrjflag1.Name = "cbtrjflag1";
			cbtrjflag1.UseVisualStyleBackColor = true;
			cbtrjflag1.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrjungle
			//
			resources.ApplyResources(cbtrjungle, "cbtrjungle");
			cbtrjungle.Name = "cbtrjungle";
			cbtrjungle.UseVisualStyleBackColor = true;
			cbtrjungle.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrhidec
			//
			resources.ApplyResources(cbtrhidec, "cbtrhidec");
			cbtrhidec.Name = "cbtrhidec";
			cbtrhidec.UseVisualStyleBackColor = true;
			cbtrhidec.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrpool
			//
			resources.ApplyResources(cbtrpool, "cbtrpool");
			cbtrpool.Name = "cbtrpool";
			cbtrpool.UseVisualStyleBackColor = true;
			cbtrpool.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrmale
			//
			resources.ApplyResources(cbtrmale, "cbtrmale");
			cbtrmale.Name = "cbtrmale";
			cbtrmale.UseVisualStyleBackColor = true;
			cbtrmale.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrfem
			//
			resources.ApplyResources(cbtrfem, "cbtrfem");
			cbtrfem.Name = "cbtrfem";
			cbtrfem.UseVisualStyleBackColor = true;
			cbtrfem.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrbeach
			//
			resources.ApplyResources(cbtrbeach, "cbtrbeach");
			cbtrbeach.Name = "cbtrbeach";
			cbtrbeach.UseVisualStyleBackColor = true;
			cbtrbeach.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrformal
			//
			resources.ApplyResources(cbtrformal, "cbtrformal");
			cbtrformal.Name = "cbtrformal";
			cbtrformal.UseVisualStyleBackColor = true;
			cbtrformal.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrteen
			//
			resources.ApplyResources(cbtrteen, "cbtrteen");
			cbtrteen.Name = "cbtrteen";
			cbtrteen.UseVisualStyleBackColor = true;
			cbtrteen.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrnude
			//
			resources.ApplyResources(cbtrnude, "cbtrnude");
			cbtrnude.Name = "cbtrnude";
			cbtrnude.UseVisualStyleBackColor = true;
			cbtrnude.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrpern
			//
			resources.ApplyResources(cbtrpern, "cbtrpern");
			cbtrpern.Name = "cbtrpern";
			cbtrpern.UseVisualStyleBackColor = true;
			cbtrpern.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cgtrwhite
			//
			resources.ApplyResources(cgtrwhite, "cgtrwhite");
			cgtrwhite.Name = "cgtrwhite";
			cgtrwhite.UseVisualStyleBackColor = true;
			cgtrwhite.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrblue
			//
			resources.ApplyResources(cbtrblue, "cbtrblue");
			cbtrblue.Name = "cbtrblue";
			cbtrblue.UseVisualStyleBackColor = true;
			cbtrblue.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrredred
			//
			resources.ApplyResources(cbtrredred, "cbtrredred");
			cbtrredred.Name = "cbtrredred";
			cbtrredred.UseVisualStyleBackColor = true;
			cbtrredred.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtradult
			//
			resources.ApplyResources(cbtradult, "cbtradult");
			cbtradult.Name = "cbtradult";
			cbtradult.UseVisualStyleBackColor = true;
			cbtradult.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbtrclub
			//
			resources.ApplyResources(cbtrclub, "cbtrclub");
			cbtrclub.Name = "cbtrclub";
			cbtrclub.UseVisualStyleBackColor = true;
			cbtrclub.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// tblotname
			//
			resources.ApplyResources(tblotname, "tblotname");
			tblotname.Name = "tblotname";
			tblotname.TextChanged += new EventHandler(CommonChange);
			//
			// gbhobby
			//
			gbhobby.BackColor = Color.Transparent;
			gbhobby.Controls.Add(cbhbmusic);
			gbhobby.Controls.Add(cbhbsport);
			gbhobby.Controls.Add(cbhbscience);
			gbhobby.Controls.Add(cbhbfitness);
			gbhobby.Controls.Add(cbhbtinker);
			gbhobby.Controls.Add(cbhbnature);
			gbhobby.Controls.Add(cbhbgames);
			gbhobby.Controls.Add(cbhbfilm);
			gbhobby.Controls.Add(cbhbart);
			gbhobby.Controls.Add(cbhbcook);
			resources.ApplyResources(gbhobby, "gbhobby");
			gbhobby.Name = "gbhobby";
			gbhobby.TabStop = false;
			//
			// cbhbmusic
			//
			resources.ApplyResources(cbhbmusic, "cbhbmusic");
			cbhbmusic.Name = "cbhbmusic";
			cbhbmusic.UseVisualStyleBackColor = true;
			cbhbmusic.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbhbsport
			//
			resources.ApplyResources(cbhbsport, "cbhbsport");
			cbhbsport.Name = "cbhbsport";
			cbhbsport.UseVisualStyleBackColor = true;
			cbhbsport.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbhbscience
			//
			resources.ApplyResources(cbhbscience, "cbhbscience");
			cbhbscience.Name = "cbhbscience";
			cbhbscience.UseVisualStyleBackColor = true;
			cbhbscience.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbhbfitness
			//
			resources.ApplyResources(cbhbfitness, "cbhbfitness");
			cbhbfitness.Name = "cbhbfitness";
			cbhbfitness.UseVisualStyleBackColor = true;
			cbhbfitness.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbhbtinker
			//
			resources.ApplyResources(cbhbtinker, "cbhbtinker");
			cbhbtinker.Name = "cbhbtinker";
			cbhbtinker.UseVisualStyleBackColor = true;
			cbhbtinker.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbhbnature
			//
			resources.ApplyResources(cbhbnature, "cbhbnature");
			cbhbnature.Name = "cbhbnature";
			cbhbnature.UseVisualStyleBackColor = true;
			cbhbnature.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbhbgames
			//
			resources.ApplyResources(cbhbgames, "cbhbgames");
			cbhbgames.Name = "cbhbgames";
			cbhbgames.UseVisualStyleBackColor = true;
			cbhbgames.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbhbfilm
			//
			resources.ApplyResources(cbhbfilm, "cbhbfilm");
			cbhbfilm.Name = "cbhbfilm";
			cbhbfilm.UseVisualStyleBackColor = true;
			cbhbfilm.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbhbart
			//
			resources.ApplyResources(cbhbart, "cbhbart");
			cbhbart.Name = "cbhbart";
			cbhbart.UseVisualStyleBackColor = true;
			cbhbart.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// cbhbcook
			//
			resources.ApplyResources(cbhbcook, "cbhbcook");
			cbhbcook.Name = "cbhbcook";
			cbhbcook.UseVisualStyleBackColor = true;
			cbhbcook.CheckedChanged += new EventHandler(
				hobbytravel_CheckedChanged
			);
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// llunknone
			//
			resources.ApplyResources(llunknone, "llunknone");
			llunknone.Name = "llunknone";
			llunknone.TabStop = true;
			llunknone.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llunknone_LinkClicked
				);
			//
			// gbFlagg
			//
			gbFlagg.Controls.Add(tbu0);
			gbFlagg.Controls.Add(label21);
			gbFlagg.Controls.Add(cbBeachy);
			gbFlagg.Controls.Add(cbhidim);
			resources.ApplyResources(gbFlagg, "gbFlagg");
			gbFlagg.Name = "gbFlagg";
			gbFlagg.TabStop = false;
			//
			// tbu0
			//
			resources.ApplyResources(tbu0, "tbu0");
			tbu0.Name = "tbu0";
			tbu0.TextChanged += new EventHandler(CommonChange);
			//
			// label21
			//
			resources.ApplyResources(label21, "label21");
			label21.Name = "label21";
			//
			// cbBeachy
			//
			resources.ApplyResources(cbBeachy, "cbBeachy");
			cbBeachy.Name = "cbBeachy";
			cbBeachy.UseVisualStyleBackColor = true;
			cbBeachy.CheckedChanged += new EventHandler(
				cbhidim_CheckedChanged
			);
			//
			// cbhidim
			//
			resources.ApplyResources(cbhidim, "cbhidim");
			cbhidim.Name = "cbhidim";
			cbhidim.UseVisualStyleBackColor = true;
			cbhidim.CheckedChanged += new EventHandler(
				cbhidim_CheckedChanged
			);
			//
			// gbunown
			//
			resources.ApplyResources(gbunown, "gbunown");
			gbunown.Controls.Add(tbu2);
			gbunown.Controls.Add(label18);
			gbunown.Controls.Add(label32);
			gbunown.Controls.Add(label19);
			gbunown.Controls.Add(lbu7);
			gbunown.Controls.Add(tbu3);
			gbunown.Controls.Add(label16);
			gbunown.Controls.Add(tbData);
			gbunown.Controls.Add(tbu7);
			gbunown.Controls.Add(tbu5);
			gbunown.Controls.Add(label24);
			gbunown.Controls.Add(tbu6);
			gbunown.Controls.Add(label23);
			gbunown.Name = "gbunown";
			gbunown.TabStop = false;
			//
			// tbu2
			//
			resources.ApplyResources(tbu2, "tbu2");
			tbu2.Name = "tbu2";
			tbu2.TextChanged += new EventHandler(CommonChange);
			//
			// label18
			//
			resources.ApplyResources(label18, "label18");
			label18.Name = "label18";
			//
			// label32
			//
			resources.ApplyResources(label32, "label32");
			label32.Name = "label32";
			//
			// label19
			//
			resources.ApplyResources(label19, "label19");
			label19.Name = "label19";
			//
			// lbu7
			//
			resources.ApplyResources(lbu7, "lbu7");
			lbu7.Items.AddRange(
				new object[]
				{
					resources.GetString("lbu7.Items"),
					resources.GetString("lbu7.Items1"),
					resources.GetString("lbu7.Items2"),
					resources.GetString("lbu7.Items3"),
					resources.GetString("lbu7.Items4"),
					resources.GetString("lbu7.Items5"),
					resources.GetString("lbu7.Items6"),
					resources.GetString("lbu7.Items7"),
				}
			);
			lbu7.MinimumSize = new Size(0, 44);
			lbu7.MultiColumn = true;
			lbu7.Name = "lbu7";
			lbu7.SelectedIndexChanged += new EventHandler(
				lbu7_SelectedIndexChanged
			);
			//
			// tbu3
			//
			resources.ApplyResources(tbu3, "tbu3");
			tbu3.Name = "tbu3";
			tbu3.TextChanged += new EventHandler(CommonChange);
			//
			// label16
			//
			resources.ApplyResources(label16, "label16");
			label16.Name = "label16";
			//
			// tbData
			//
			resources.ApplyResources(tbData, "tbData");
			tbData.Name = "tbData";
			tbData.TextChanged += new EventHandler(ChangeData);
			//
			// tbu7
			//
			resources.ApplyResources(tbu7, "tbu7");
			tbu7.Name = "tbu7";
			tbu7.TextChanged += new EventHandler(tbu7_TextChanged);
			//
			// tbu5
			//
			resources.ApplyResources(tbu5, "tbu5");
			tbu5.Name = "tbu5";
			tbu5.TextChanged += new EventHandler(ChangeData);
			//
			// label24
			//
			resources.ApplyResources(label24, "label24");
			label24.Name = "label24";
			//
			// tbu6
			//
			resources.ApplyResources(tbu6, "tbu6");
			tbu6.Name = "tbu6";
			tbu6.TextChanged += new EventHandler(ChangeData);
			//
			// label23
			//
			resources.ApplyResources(label23, "label23");
			label23.Name = "label23";
			//
			// gbclarse
			//
			gbclarse.Controls.Add(label11);
			gbclarse.Controls.Add(cbLotClas);
			gbclarse.Controls.Add(tbcset);
			gbclarse.Controls.Add(tblotclass);
			gbclarse.Controls.Add(label17);
			resources.ApplyResources(gbclarse, "gbclarse");
			gbclarse.Name = "gbclarse";
			gbclarse.TabStop = false;
			//
			// label11
			//
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			//
			// cbLotClas
			//
			resources.ApplyResources(cbLotClas, "cbLotClas");
			cbLotClas.FormattingEnabled = true;
			cbLotClas.Items.AddRange(
				new object[]
				{
					resources.GetString("cbLotClas.Items"),
					resources.GetString("cbLotClas.Items1"),
					resources.GetString("cbLotClas.Items2"),
					resources.GetString("cbLotClas.Items3"),
				}
			);
			cbLotClas.Name = "cbLotClas";
			cbLotClas.SelectedIndexChanged += new EventHandler(
				cbhidim_CheckedChanged
			);
			//
			// tbcset
			//
			resources.ApplyResources(tbcset, "tbcset");
			tbcset.Name = "tbcset";
			//
			// tblotclass
			//
			resources.ApplyResources(tblotclass, "tblotclass");
			tblotclass.Name = "tblotclass";
			//
			// label17
			//
			resources.ApplyResources(label17, "label17");
			label17.Name = "label17";
			//
			// label7
			//
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			//
			// lb
			//
			resources.ApplyResources(lb, "lb");
			lb.Items.AddRange(
				new object[]
				{
					resources.GetString("lb.Items"),
					resources.GetString("lb.Items1"),
					resources.GetString("lb.Items2"),
					resources.GetString("lb.Items3"),
					resources.GetString("lb.Items4"),
					resources.GetString("lb.Items5"),
					resources.GetString("lb.Items6"),
					resources.GetString("lb.Items7"),
					resources.GetString("lb.Items8"),
					resources.GetString("lb.Items9"),
					resources.GetString("lb.Items10"),
					resources.GetString("lb.Items11"),
					resources.GetString("lb.Items12"),
					resources.GetString("lb.Items13"),
					resources.GetString("lb.Items14"),
					resources.GetString("lb.Items15"),
					resources.GetString("lb.Items16"),
					resources.GetString("lb.Items17"),
					resources.GetString("lb.Items18"),
					resources.GetString("lb.Items19"),
					resources.GetString("lb.Items20"),
					resources.GetString("lb.Items21"),
					resources.GetString("lb.Items22"),
					resources.GetString("lb.Items23"),
					resources.GetString("lb.Items24"),
					resources.GetString("lb.Items25"),
					resources.GetString("lb.Items26"),
					resources.GetString("lb.Items27"),
					resources.GetString("lb.Items28"),
					resources.GetString("lb.Items29"),
					resources.GetString("lb.Items30"),
					resources.GetString("lb.Items31"),
					resources.GetString("lb.Items32"),
					resources.GetString("lb.Items33"),
					resources.GetString("lb.Items34"),
					resources.GetString("lb.Items35"),
					resources.GetString("lb.Items36"),
					resources.GetString("lb.Items37"),
					resources.GetString("lb.Items38"),
					resources.GetString("lb.Items39"),
					resources.GetString("lb.Items40"),
					resources.GetString("lb.Items41"),
					resources.GetString("lb.Items42"),
					resources.GetString("lb.Items43"),
					resources.GetString("lb.Items44"),
				}
			);
			lb.MultiColumn = true;
			lb.Name = "lb";
			lb.SelectedIndexChanged += new EventHandler(
				lb_SelectedIndexChanged
			);
			//
			// tbElevationAt
			//
			resources.ApplyResources(tbElevationAt, "tbElevationAt");
			tbElevationAt.Name = "tbElevationAt";
			tbElevationAt.TextChanged += new EventHandler(
				tbElevationAt_TextChanged
			);
			//
			// label25
			//
			resources.ApplyResources(label25, "label25");
			label25.Name = "label25";
			label25.DoubleClick += new EventHandler(label25_Click);
			//
			// tbowner
			//
			resources.ApplyResources(tbowner, "tbowner");
			tbowner.Name = "tbowner";
			tbowner.TextChanged += new EventHandler(CommonChange);
			//
			// label15
			//
			resources.ApplyResources(label15, "label15");
			label15.Name = "label15";
			//
			// label8
			//
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			//
			// bthbytrvl
			//
			resources.ApplyResources(bthbytrvl, "bthbytrvl");
			bthbytrvl.Name = "bthbytrvl";
			bthbytrvl.UseVisualStyleBackColor = true;
			bthbytrvl.Click += new EventHandler(Openpntravel);
			//
			// tbinst
			//
			resources.ApplyResources(tbinst, "tbinst");
			tbinst.Name = "tbinst";
			tbinst.TextChanged += new EventHandler(CommonChange);
			//
			// label14
			//
			resources.ApplyResources(label14, "label14");
			label14.Name = "label14";
			//
			// tbu4
			//
			resources.ApplyResources(tbu4, "tbu4");
			tbu4.Name = "tbu4";
			tbu4.TextChanged += new EventHandler(CommonChange);
			//
			// cborient
			//
			cborient.Enum = null;
			resources.ApplyResources(cborient, "cborient");
			cborient.Name = "cborient";
			cborient.ResourceManager = null;
			cborient.SelectedIndexChanged += new EventHandler(
				CommonChange
			);
			//
			// tbTexture
			//
			resources.ApplyResources(tbTexture, "tbTexture");
			tbTexture.Name = "tbTexture";
			tbTexture.TextChanged += new EventHandler(CommonChange);
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// tbwd
			//
			resources.ApplyResources(tbwd, "tbwd");
			tbwd.Name = "tbwd";
			tbwd.TextChanged += new EventHandler(CommonChange);
			//
			// tbrotation
			//
			resources.ApplyResources(tbrotation, "tbrotation");
			tbrotation.Name = "tbrotation";
			tbrotation.TextChanged += new EventHandler(CommonChange);
			//
			// label9
			//
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			//
			// label10
			//
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			//
			// tbhg
			//
			resources.ApplyResources(tbhg, "tbhg");
			tbhg.Name = "tbhg";
			tbhg.TextChanged += new EventHandler(CommonChange);
			//
			// tbRoads
			//
			resources.ApplyResources(tbRoads, "tbRoads");
			tbRoads.Name = "tbRoads";
			tbRoads.TextChanged += new EventHandler(CommonChange);
			//
			// label12
			//
			resources.ApplyResources(label12, "label12");
			label12.Name = "label12";
			//
			// tbver
			//
			tbver.BackColor = SystemColors.Window;
			resources.ApplyResources(tbver, "tbver");
			tbver.Name = "tbver";
			tbver.ReadOnly = true;
			//
			// tbtop
			//
			resources.ApplyResources(tbtop, "tbtop");
			tbtop.Name = "tbtop";
			tbtop.TextChanged += new EventHandler(CommonChange);
			//
			// label13
			//
			resources.ApplyResources(label13, "label13");
			label13.Name = "label13";
			//
			// tbsubver
			//
			tbsubver.BackColor = SystemColors.Window;
			resources.ApplyResources(tbsubver, "tbsubver");
			tbsubver.Name = "tbsubver";
			tbsubver.ReadOnly = true;
			//
			// tbleft
			//
			resources.ApplyResources(tbleft, "tbleft");
			tbleft.Name = "tbleft";
			tbleft.TextChanged += new EventHandler(CommonChange);
			//
			// label20
			//
			resources.ApplyResources(label20, "label20");
			label20.Name = "label20";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// tbz
			//
			resources.ApplyResources(tbz, "tbz");
			tbz.Name = "tbz";
			tbz.TextChanged += new EventHandler(CommonChange);
			//
			// cbtype
			//
			resources.ApplyResources(cbtype, "cbtype");
			cbtype.Name = "cbtype";
			cbtype.SelectedIndexChanged += new EventHandler(
				SelectType
			);
			//
			// tbtype
			//
			tbtype.BackColor = SystemColors.Window;
			resources.ApplyResources(tbtype, "tbtype");
			tbtype.Name = "tbtype";
			tbtype.ReadOnly = true;
			//
			// panel2
			//
			resources.ApplyResources(panel2, "panel2");
			panel2.Name = "panel2";
			//
			// pb
			//
			resources.ApplyResources(pb, "pb");
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// LtxtForm
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(ltxtPanel);
			Name = "LtxtForm";
			ltxtPanel.ResumeLayout(false);
			ltxtPanel.PerformLayout();
			gbApart.ResumeLayout(false);
			gbApart.PerformLayout();
			gbApartment.ResumeLayout(false);
			gbApartment.PerformLayout();
			gbtravel.ResumeLayout(false);
			gbtravel.PerformLayout();
			gbhobby.ResumeLayout(false);
			gbhobby.PerformLayout();
			gbFlagg.ResumeLayout(false);
			gbFlagg.PerformLayout();
			gbunown.ResumeLayout(false);
			gbunown.PerformLayout();
			gbclarse.ResumeLayout(false);
			gbclarse.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(pb)).EndInit();
			ResumeLayout(false);
		}
		#endregion

		internal Ltxt wrapper;

		private void SelectType(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			if (Enum.IsDefined(typeof(Ltxt.LotType), cbtype.SelectedItem))
			{
				wrapper.Type = (Ltxt.LotType)cbtype.SelectedItem;
			}
			else
			{
				wrapper.Type = Ltxt.LotType.Unknown;
			}

			tbtype.Text = "0x" + Helper.HexString((byte)wrapper.Type);
			btnAddApt.Enabled = btnDelApt.Enabled = (
				wrapper.Type == Ltxt.LotType.ApartmentBase
			);
			cbtrclub.Enabled =
				cbtrhidec.Enabled =
				gbhobby.Enabled =
					(wrapper.Type == Ltxt.LotType.Hobby);
			if (wrapper.SubVersion >= LtxtSubVersion.Freetime)
			{
				bthbytrvl.Enabled = (wrapper.Type == Ltxt.LotType.Hobby);
			}

			if (
				wrapper.Type == Ltxt.LotType.ApartmentBase
				|| wrapper.Type == Ltxt.LotType.ApartmentSublot
			)
			{
				gbApart.Visible = true;
				gbunown.Location = new Point(116, 408);
				llunknone.Location = new Point(41, 408);
				gbhobby.Location = new Point(30, 408);
				gbtravel.Location = new Point(372, 408);
			}
			else
			{
				gbApart.Visible = false;
				gbunown.Location = new Point(116, 333);
				llunknone.Location = new Point(41, 333);
				gbhobby.Location = new Point(30, 333);
				gbtravel.Location = new Point(372, 333);
			}

			wrapper.Changed = true;
		}

		private void Commit(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			try
			{
				wrapper.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("errwritingfile"),
					ex
				);
			}
		}

		private void CommonChange(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			try
			{
				wrapper.LotRoads = Convert.ToByte(tbRoads.Text, 16);

				wrapper.LotSize = new Size(
					Helper.StringToInt32(tbwd.Text, wrapper.LotSize.Width, 10),
					Helper.StringToInt32(tbhg.Text, wrapper.LotSize.Height, 10)
				);
				wrapper.LotPosition = new Point(
					Helper.StringToInt32(tbleft.Text, wrapper.LotPosition.X, 10),
					Helper.StringToInt32(tbtop.Text, wrapper.LotPosition.Y, 10)
				);
				wrapper.LotElevation = Helper.StringToFloat(
					tbz.Text,
					wrapper.LotElevation
				);

				wrapper.Orientation = (LotOrientation)cborient.SelectedValue;
				wrapper.LotRotation = Convert.ToByte(tbrotation.Text, 16);
				wrapper.Unknown0 = Helper.StringToUInt32(
					tbu0.Text,
					wrapper.Unknown0,
					16
				);
				Boolset bby = wrapper.Unknown0;
				cbhidim.Checked = bby[4];
				cbBeachy.Checked = bby[7];
				if (
					wrapper.Version >= LtxtVersion.Apartment
					|| wrapper.SubVersion >= LtxtSubVersion.Apartment
				)
				{
					cbLotClas.Enabled = true;
					if (bby[12])
					{
						cbLotClas.SelectedIndex = 1;
					}
					else if (bby[13])
					{
						cbLotClas.SelectedIndex = 2;
					}
					else if (bby[14])
					{
						cbLotClas.SelectedIndex = 3;
					}
					else
					{
						cbLotClas.SelectedIndex = 0;
					}
				}
				else
				{
					cbLotClas.SelectedIndex = 0;
					cbLotClas.Enabled = false;
				}

				wrapper.LotName = tblotname.Text;
				wrapper.Texture = tbTexture.Text;
				wrapper.LotDesc = tbdesc.Text;

				wrapper.LotInstance = Helper.StringToUInt32(
					tbinst.Text,
					wrapper.LotInstance,
					16
				);
				wrapper.Unknown3 = Helper.StringToFloat(tbu3.Text, wrapper.Unknown3);
				wrapper.Unknown4 = Helper.StringToUInt32(
					tbu4.Text,
					wrapper.Unknown4,
					16
				);
				wrapper.LotClass = Helper.StringToUInt32(
					tblotclass.Text,
					wrapper.LotClass,
					16
				);
				Boolset tty = wrapper.Unknown4;

				cbtrjflag5.Checked = tty[30];
				cbtrjflag4.Checked = tty[28];
				cbtrjflag3.Checked = tty[27];
				cbtrjflag2.Checked = tty[26];
				cbtrjflag1.Checked = tty[25];
				cbtrjungle.Checked = tty[24];
				cbtrhidec.Checked = tty[23];
				cbtrpool.Checked = tty[22];
				cbtrmale.Checked = tty[21];
				cbtrfem.Checked = tty[20];
				cbtrbeach.Checked = tty[19];
				cbtrformal.Checked = tty[18];
				cbtrteen.Checked = tty[17];
				cbtrnude.Checked = tty[16];
				cbtrpern.Checked = tty[15];
				cgtrwhite.Checked = tty[14];
				cbtrblue.Checked = tty[13];
				cbtrredred.Checked = tty[12];
				cbtradult.Checked = tty[11];
				cbtrclub.Checked = tty[10];
				cbhbmusic.Checked = tty[9];
				cbhbscience.Checked = tty[8];
				cbhbfitness.Checked = tty[7];
				cbhbtinker.Checked = tty[6];
				cbhbnature.Checked = tty[5];
				cbhbgames.Checked = tty[4];
				cbhbsport.Checked = tty[3];
				cbhbfilm.Checked = tty[2];
				cbhbart.Checked = tty[1];
				cbhbcook.Checked = tty[0];

				wrapper.Unknown2 = (byte)
					Helper.StringToUInt16(tbu2.Text, wrapper.Unknown2, 16);
				wrapper.OwnerInstance = Helper.StringToUInt32(
					tbowner.Text,
					wrapper.OwnerInstance,
					16
				);

				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void cbhidim_CheckedChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			try
			{
				Boolset bby = wrapper.Unknown0;
				bby[4] = cbhidim.Checked;
				bby[7] = cbBeachy.Checked;
				if (
					wrapper.Version >= LtxtVersion.Apartment
					|| wrapper.SubVersion >= LtxtSubVersion.Apartment
				)
				{
					bby[12] = (cbLotClas.SelectedIndex == 1);
					bby[13] = (cbLotClas.SelectedIndex == 2);
					bby[14] = (cbLotClas.SelectedIndex == 3);
				}
				wrapper.Unknown0 = bby;
				tbu0.Text = "0x" + Helper.HexString(wrapper.Unknown0);
				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void hobbytravel_CheckedChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			try
			{
				uint tty = 0;
				if (cbhbcook.Checked)
				{
					tty += 1;
				}

				if (cbhbart.Checked)
				{
					tty += 2;
				}

				if (cbhbfilm.Checked)
				{
					tty += 4;
				}

				if (cbhbsport.Checked)
				{
					tty += 8;
				}

				if (cbhbgames.Checked)
				{
					tty += 16;
				}

				if (cbhbnature.Checked)
				{
					tty += 32;
				}

				if (cbhbtinker.Checked)
				{
					tty += 64;
				}

				if (cbhbfitness.Checked)
				{
					tty += 128;
				}

				if (cbhbscience.Checked)
				{
					tty += 256;
				}

				if (cbhbmusic.Checked)
				{
					tty += 512;
				}

				if (cbtrclub.Checked)
				{
					tty += 1024;
				}

				if (cbtradult.Checked)
				{
					tty += 2048;
				}

				if (cbtrredred.Checked)
				{
					tty += 4096;
				}

				if (cbtrblue.Checked)
				{
					tty += 8192;
				}

				if (cgtrwhite.Checked)
				{
					tty += 16384;
				}

				if (cbtrpern.Checked)
				{
					tty += 32768;
				}

				if (cbtrnude.Checked)
				{
					tty += 65536;
				}

				if (cbtrteen.Checked)
				{
					tty += 131072;
				}

				if (cbtrformal.Checked)
				{
					tty += 262144;
				}

				if (cbtrbeach.Checked)
				{
					tty += 524288;
				}

				if (cbtrfem.Checked)
				{
					tty += 1048576;
				}

				if (cbtrmale.Checked)
				{
					tty += 2097152;
				}

				if (cbtrpool.Checked)
				{
					tty += 4194304;
				}

				if (cbtrhidec.Checked)
				{
					tty += 8388608;
				}

				if (cbtrjungle.Checked)
				{
					tty += 16777216;
				}

				if (cbtrjflag1.Checked)
				{
					tty += 33554432;
				}

				if (cbtrjflag2.Checked)
				{
					tty += 67108864;
				}

				if (cbtrjflag3.Checked)
				{
					tty += 134217728;
				}

				if (cbtrjflag4.Checked)
				{
					tty += 268435456;
				}

				if (cbtrjflag5.Checked)
				{
					tty += 536870912;
				}

				cbtrmale.Enabled = !cbtrfem.Checked;
				cbtrfem.Enabled = !cbtrmale.Checked;
				wrapper.Unknown4 = tty;
				tbu4.Text = "0x" + Helper.HexString(wrapper.Unknown4);

				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void Openpntravel(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			try
			{
				gbunown.Visible = false;
				gbhobby.Visible = !gbhobby.Visible;
				gbtravel.Visible = gbhobby.Visible;
				//this.bthbytrvl.Enabled = false;
				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void ChangeData(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			try
			{
				wrapper.Unknown5 = Helper.SetLength(
					Helper.HexListToBytes(tbu5.Text),
					9
				);
				wrapper.Unknown6 = Helper.SetLength(
					Helper.HexListToBytes(tbu6.Text),
					9
				);
				wrapper.Followup = Helper.SetLength(
					Helper.HexListToBytes(tbData.Text),
					0
				);

				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void lb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			Ltxt wrp = wrapper;
			wrapper = null;

			if (lb.SelectedIndex < 0)
			{
				tbElevationAt.Text = "";
			}
			else
			{
				tbElevationAt.Text = wrp.Unknown1[lb.SelectedIndex].ToString();
			}

			wrapper = wrp;
		}

		private void tbElevationAt_TextChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			if (lb.SelectedIndex < 0)
			{
				return;
			}

			Ltxt wrp = wrapper;
			wrapper = null;

			try
			{
				wrp.Unknown1[lb.SelectedIndex] = Helper.StringToFloat(
					tbElevationAt.Text,
					wrp.Unknown1[lb.SelectedIndex]
				);
				int x,
					y;
				y = Convert.ToInt32(lb.SelectedIndex / wrp.LotSize.Height);
				x = lb.SelectedIndex - y * wrp.LotSize.Height;
				lb.Items[lb.SelectedIndex] =
					"(" + x + "," + y + ") " + wrp.Unknown1[lb.SelectedIndex];

				wrp.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				wrapper = wrp;
			}
		}

		private void lbApts_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			Ltxt wrp = wrapper;
			wrapper = null;

			if (lbApts.SelectedIndex < 0)
			{
				tbApartment.Text = tbSAFamily.Text = tbSAu2.Text = tbSAu3.Text = "";
				btnDelApt.Enabled = llFamily.Enabled = llSubLot.Enabled = false;
			}
			else
			{
				Ltxt.SubLot sl = wrp.SubLots[lbApts.SelectedIndex];
				tbApartment.Text = (string)lbApts.SelectedItem;
				tbSAFamily.Text = "0x" + Helper.HexString(sl.Family);
				tbSAu2.Text = "0x" + Helper.HexString(sl.Unknown2);
				tbSAu3.Text = "0x" + Helper.HexString(sl.Unknown3);
				btnDelApt.Enabled = llFamily.Enabled = llSubLot.Enabled = true;
			}

			wrapper = wrp;
		}

		private void SAChange(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			if (lbApts.SelectedIndex < 0)
			{
				return;
			}

			Ltxt wrp = wrapper;
			wrapper = null;

			try
			{
				Ltxt.SubLot sl = wrp.SubLots[lbApts.SelectedIndex];
				sl.ApartmentSublot = Helper.StringToUInt32(
					tbApartment.Text,
					sl.ApartmentSublot,
					16
				);
				sl.Family = Helper.StringToUInt32(tbSAFamily.Text, sl.Family, 16);
				sl.Unknown2 = Helper.StringToUInt32(tbSAu2.Text, sl.Unknown2, 16);
				sl.Unknown3 = Helper.StringToUInt32(tbSAu3.Text, sl.Unknown3, 16);
				lbApts.Items[lbApts.SelectedIndex] =
					"0x" + Helper.HexString(sl.ApartmentSublot);

				wrp.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				wrapper = wrp;
			}
		}

		private void lbu7_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			Ltxt wrp = wrapper;
			wrapper = null;

			if (lbu7.SelectedIndex < 0)
			{
				tbu7.Text = "";
			}
			else
			{
				tbu7.Text = (string)lbu7.SelectedItem;
			}

			wrapper = wrp;
		}

		private void tbu7_TextChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			if (lbu7.SelectedIndex < 0)
			{
				return;
			}

			Ltxt wrp = wrapper;
			wrapper = null;

			try
			{
				wrp.Unknown7[lbu7.SelectedIndex] = Helper.StringToUInt32(
					tbu7.Text,
					wrp.Unknown7[lbu7.SelectedIndex],
					16
				);
				lbu7.Items[lb.SelectedIndex] =
					"0x" + Helper.HexString(wrp.Unknown7[lb.SelectedIndex]);

				wrp.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				wrapper = wrp;
			}
		}

		private void ll_Click(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Collections.Generic.List<LinkLabel> lll =
				new System.Collections.Generic.List<LinkLabel>(
					new LinkLabel[] { llAptBase, llSubLot, llFamily }
				);

			uint type,
				inst;
			switch (lll.IndexOf((LinkLabel)sender))
			{
				case 0:
					type = 0x0BF999E7;
					inst = wrapper.ApartmentBase;
					break;
				case 1:
					type = 0x0BF999E7;
					inst = wrapper.SubLots[lbApts.SelectedIndex].ApartmentSublot;
					break;
				case 2:
					type = 0x46414D49;
					inst = wrapper.SubLots[lbApts.SelectedIndex].Family;
					break;
				default:
					return;
			}

			Interfaces.Files.IPackedFileDescriptor pfd = wrapper.Package.NewDescriptor(
				type,
				wrapper.FileDescriptor.SubType,
				wrapper.FileDescriptor.Group,
				inst
			);
			pfd = wrapper.Package.FindFile(pfd);
			if (pfd == null)
			{
				return;
			}

			RemoteControl.OpenPackedFile(pfd, wrapper.Package);
		}

		private void btnAddApt_Click(object sender, EventArgs e)
		{
			wrapper.SubLots.Add(new Ltxt.SubLot());
			lbApts.Items.Add(
				"0x"
					+ Helper.HexString(
						wrapper.SubLots[wrapper.SubLots.Count - 1].ApartmentSublot
					)
			);
			lbApts.SelectedIndex = wrapper.SubLots.Count - 1;

			wrapper.Changed = true;
		}

		private void btnDelApt_Click(object sender, EventArgs e)
		{
			int i = lbApts.SelectedIndex;

			lbApts.BeginUpdate();
			lbApts.SelectedIndex = -1;

			wrapper.SubLots.RemoveAt(i);
			lbApts.Items.RemoveAt(i);

			if (i > 0)
			{
				i--;
			}
			else if (lbApts.Items.Count == 0)
			{
				i = -1;
			}

			lbApts.SelectedIndex = i;
			lbApts.EndUpdate();

			wrapper.Changed = true;
		}

		private void tbApBase_TextChanged(object sender, EventArgs e)
		{
			if (wrapper == null)
			{
				return;
			}

			wrapper.ApartmentBase = Helper.StringToUInt32(
				tbApBase.Text,
				wrapper.ApartmentBase,
				16
			);
			llAptBase.Enabled = (wrapper.ApartmentBase != 0);
		}

		private void label25_Click(object sender, EventArgs e)
		{
			uint simmy = Helper.StringToUInt32(tbowner.Text, wrapper.OwnerInstance, 16);
			if (simmy == 0)
			{
				return;
			}

			if (FileTableBase.ProviderRegistry.SimDescriptionProvider.SimInstance[
					(ushort)simmy
				] is PackedFiles.Wrapper.ExtSDesc sdsc)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = sdsc.Package.NewDescriptor(
					0xAACE2EFB,
					sdsc.FileDescriptor.SubType,
					sdsc.FileDescriptor.Group,
					sdsc.FileDescriptor.Instance
				);
				pfd = sdsc.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, sdsc.Package);
			}
		}

		private void llunknone_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			gbunown.Visible = !gbunown.Visible;
		}
	}
}
