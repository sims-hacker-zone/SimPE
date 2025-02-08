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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for LtxtForm.
	/// </summary>
	public class LtxtForm : System.Windows.Forms.Form
	{
		#region Form controls
		internal System.Windows.Forms.Panel ltxtPanel;
		private System.Windows.Forms.Panel panel2;
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
			this.cborient.ResourceManager = SimPe.Localization.Manager;
			this.cborient.Enum = typeof(Plugin.LotOrientation);

			if (!Helper.WindowsRegistry.UseBigIcons)
			{
				this.pb.Size = new System.Drawing.Size(124, 108);
				this.pb.Location = new System.Drawing.Point(25, 56);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LtxtForm));
			this.ltxtPanel = new System.Windows.Forms.Panel();
			this.lbPlayim = new System.Windows.Forms.Label();
			this.gbApart = new System.Windows.Forms.GroupBox();
			this.label22 = new System.Windows.Forms.Label();
			this.gbApartment = new System.Windows.Forms.GroupBox();
			this.llFamily = new System.Windows.Forms.LinkLabel();
			this.tbApartment = new System.Windows.Forms.TextBox();
			this.tbSAu2 = new System.Windows.Forms.TextBox();
			this.llSubLot = new System.Windows.Forms.LinkLabel();
			this.label31 = new System.Windows.Forms.Label();
			this.tbSAu3 = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.tbSAFamily = new System.Windows.Forms.TextBox();
			this.lbApts = new System.Windows.Forms.ListBox();
			this.tbApBase = new System.Windows.Forms.TextBox();
			this.llAptBase = new System.Windows.Forms.LinkLabel();
			this.btnDelApt = new System.Windows.Forms.Button();
			this.btnAddApt = new System.Windows.Forms.Button();
			this.tbdesc = new System.Windows.Forms.TextBox();
			this.gbtravel = new System.Windows.Forms.GroupBox();
			this.cbtrjflag5 = new System.Windows.Forms.CheckBox();
			this.cbtrjflag4 = new System.Windows.Forms.CheckBox();
			this.cbtrjflag3 = new System.Windows.Forms.CheckBox();
			this.cbtrjflag2 = new System.Windows.Forms.CheckBox();
			this.cbtrjflag1 = new System.Windows.Forms.CheckBox();
			this.cbtrjungle = new System.Windows.Forms.CheckBox();
			this.cbtrhidec = new System.Windows.Forms.CheckBox();
			this.cbtrpool = new System.Windows.Forms.CheckBox();
			this.cbtrmale = new System.Windows.Forms.CheckBox();
			this.cbtrfem = new System.Windows.Forms.CheckBox();
			this.cbtrbeach = new System.Windows.Forms.CheckBox();
			this.cbtrformal = new System.Windows.Forms.CheckBox();
			this.cbtrteen = new System.Windows.Forms.CheckBox();
			this.cbtrnude = new System.Windows.Forms.CheckBox();
			this.cbtrpern = new System.Windows.Forms.CheckBox();
			this.cgtrwhite = new System.Windows.Forms.CheckBox();
			this.cbtrblue = new System.Windows.Forms.CheckBox();
			this.cbtrredred = new System.Windows.Forms.CheckBox();
			this.cbtradult = new System.Windows.Forms.CheckBox();
			this.cbtrclub = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tblotname = new System.Windows.Forms.TextBox();
			this.gbhobby = new System.Windows.Forms.GroupBox();
			this.cbhbmusic = new System.Windows.Forms.CheckBox();
			this.cbhbsport = new System.Windows.Forms.CheckBox();
			this.cbhbscience = new System.Windows.Forms.CheckBox();
			this.cbhbfitness = new System.Windows.Forms.CheckBox();
			this.cbhbtinker = new System.Windows.Forms.CheckBox();
			this.cbhbnature = new System.Windows.Forms.CheckBox();
			this.cbhbgames = new System.Windows.Forms.CheckBox();
			this.cbhbfilm = new System.Windows.Forms.CheckBox();
			this.cbhbart = new System.Windows.Forms.CheckBox();
			this.cbhbcook = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.llunknone = new System.Windows.Forms.LinkLabel();
			this.gbFlagg = new System.Windows.Forms.GroupBox();
			this.tbu0 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.cbBeachy = new System.Windows.Forms.CheckBox();
			this.cbhidim = new System.Windows.Forms.CheckBox();
			this.gbunown = new System.Windows.Forms.GroupBox();
			this.tbu2 = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.lbu7 = new System.Windows.Forms.ListBox();
			this.tbu3 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.tbData = new System.Windows.Forms.TextBox();
			this.tbu7 = new System.Windows.Forms.TextBox();
			this.tbu5 = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.tbu6 = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.gbclarse = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.cbLotClas = new System.Windows.Forms.ComboBox();
			this.tbcset = new System.Windows.Forms.TextBox();
			this.tblotclass = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lb = new System.Windows.Forms.ListBox();
			this.tbElevationAt = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.tbowner = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.bthbytrvl = new System.Windows.Forms.Button();
			this.tbinst = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbu4 = new System.Windows.Forms.TextBox();
			this.cborient = new Ambertation.Windows.Forms.EnumComboBox();
			this.tbTexture = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbwd = new System.Windows.Forms.TextBox();
			this.tbrotation = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbhg = new System.Windows.Forms.TextBox();
			this.tbRoads = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tbver = new System.Windows.Forms.TextBox();
			this.tbtop = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbsubver = new System.Windows.Forms.TextBox();
			this.tbleft = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbz = new System.Windows.Forms.TextBox();
			this.cbtype = new System.Windows.Forms.ComboBox();
			this.tbtype = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pb = new System.Windows.Forms.PictureBox();
			this.ltxtPanel.SuspendLayout();
			this.gbApart.SuspendLayout();
			this.gbApartment.SuspendLayout();
			this.gbtravel.SuspendLayout();
			this.gbhobby.SuspendLayout();
			this.gbFlagg.SuspendLayout();
			this.gbunown.SuspendLayout();
			this.gbclarse.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.SuspendLayout();
			// 
			// ltxtPanel
			// 
			resources.ApplyResources(this.ltxtPanel, "ltxtPanel");
			this.ltxtPanel.BackColor = System.Drawing.Color.Transparent;
			this.ltxtPanel.Controls.Add(this.lbPlayim);
			this.ltxtPanel.Controls.Add(this.gbApart);
			this.ltxtPanel.Controls.Add(this.tbdesc);
			this.ltxtPanel.Controls.Add(this.gbtravel);
			this.ltxtPanel.Controls.Add(this.label5);
			this.ltxtPanel.Controls.Add(this.tblotname);
			this.ltxtPanel.Controls.Add(this.gbhobby);
			this.ltxtPanel.Controls.Add(this.label4);
			this.ltxtPanel.Controls.Add(this.llunknone);
			this.ltxtPanel.Controls.Add(this.gbFlagg);
			this.ltxtPanel.Controls.Add(this.gbunown);
			this.ltxtPanel.Controls.Add(this.gbclarse);
			this.ltxtPanel.Controls.Add(this.label7);
			this.ltxtPanel.Controls.Add(this.lb);
			this.ltxtPanel.Controls.Add(this.tbElevationAt);
			this.ltxtPanel.Controls.Add(this.label25);
			this.ltxtPanel.Controls.Add(this.tbowner);
			this.ltxtPanel.Controls.Add(this.label15);
			this.ltxtPanel.Controls.Add(this.label8);
			this.ltxtPanel.Controls.Add(this.bthbytrvl);
			this.ltxtPanel.Controls.Add(this.tbinst);
			this.ltxtPanel.Controls.Add(this.label14);
			this.ltxtPanel.Controls.Add(this.tbu4);
			this.ltxtPanel.Controls.Add(this.cborient);
			this.ltxtPanel.Controls.Add(this.tbTexture);
			this.ltxtPanel.Controls.Add(this.label2);
			this.ltxtPanel.Controls.Add(this.label6);
			this.ltxtPanel.Controls.Add(this.label3);
			this.ltxtPanel.Controls.Add(this.tbwd);
			this.ltxtPanel.Controls.Add(this.tbrotation);
			this.ltxtPanel.Controls.Add(this.label9);
			this.ltxtPanel.Controls.Add(this.label10);
			this.ltxtPanel.Controls.Add(this.tbhg);
			this.ltxtPanel.Controls.Add(this.tbRoads);
			this.ltxtPanel.Controls.Add(this.label12);
			this.ltxtPanel.Controls.Add(this.tbver);
			this.ltxtPanel.Controls.Add(this.tbtop);
			this.ltxtPanel.Controls.Add(this.label13);
			this.ltxtPanel.Controls.Add(this.tbsubver);
			this.ltxtPanel.Controls.Add(this.tbleft);
			this.ltxtPanel.Controls.Add(this.label20);
			this.ltxtPanel.Controls.Add(this.label1);
			this.ltxtPanel.Controls.Add(this.tbz);
			this.ltxtPanel.Controls.Add(this.cbtype);
			this.ltxtPanel.Controls.Add(this.tbtype);
			this.ltxtPanel.Controls.Add(this.panel2);
			this.ltxtPanel.Controls.Add(this.pb);
			this.ltxtPanel.Name = "ltxtPanel";
			// 
			// lbPlayim
			// 
			resources.ApplyResources(this.lbPlayim, "lbPlayim");
			this.lbPlayim.ForeColor = System.Drawing.Color.Blue;
			this.lbPlayim.Name = "lbPlayim";
			// 
			// gbApart
			// 
			this.gbApart.Controls.Add(this.label22);
			this.gbApart.Controls.Add(this.gbApartment);
			this.gbApart.Controls.Add(this.lbApts);
			this.gbApart.Controls.Add(this.tbApBase);
			this.gbApart.Controls.Add(this.llAptBase);
			this.gbApart.Controls.Add(this.btnDelApt);
			this.gbApart.Controls.Add(this.btnAddApt);
			resources.ApplyResources(this.gbApart, "gbApart");
			this.gbApart.Name = "gbApart";
			this.gbApart.TabStop = false;
			// 
			// label22
			// 
			resources.ApplyResources(this.label22, "label22");
			this.label22.Name = "label22";
			// 
			// gbApartment
			// 
			resources.ApplyResources(this.gbApartment, "gbApartment");
			this.gbApartment.Controls.Add(this.llFamily);
			this.gbApartment.Controls.Add(this.tbApartment);
			this.gbApartment.Controls.Add(this.tbSAu2);
			this.gbApartment.Controls.Add(this.llSubLot);
			this.gbApartment.Controls.Add(this.label31);
			this.gbApartment.Controls.Add(this.tbSAu3);
			this.gbApartment.Controls.Add(this.label30);
			this.gbApartment.Controls.Add(this.tbSAFamily);
			this.gbApartment.Name = "gbApartment";
			this.gbApartment.TabStop = false;
			// 
			// llFamily
			// 
			resources.ApplyResources(this.llFamily, "llFamily");
			this.llFamily.Name = "llFamily";
			this.llFamily.TabStop = true;
			this.llFamily.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_Click);
			// 
			// tbApartment
			// 
			resources.ApplyResources(this.tbApartment, "tbApartment");
			this.tbApartment.Name = "tbApartment";
			this.tbApartment.TextChanged += new System.EventHandler(this.SAChange);
			// 
			// tbSAu2
			// 
			resources.ApplyResources(this.tbSAu2, "tbSAu2");
			this.tbSAu2.Name = "tbSAu2";
			this.tbSAu2.TextChanged += new System.EventHandler(this.SAChange);
			// 
			// llSubLot
			// 
			resources.ApplyResources(this.llSubLot, "llSubLot");
			this.llSubLot.Name = "llSubLot";
			this.llSubLot.TabStop = true;
			this.llSubLot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_Click);
			// 
			// label31
			// 
			resources.ApplyResources(this.label31, "label31");
			this.label31.Name = "label31";
			// 
			// tbSAu3
			// 
			resources.ApplyResources(this.tbSAu3, "tbSAu3");
			this.tbSAu3.Name = "tbSAu3";
			this.tbSAu3.TextChanged += new System.EventHandler(this.SAChange);
			// 
			// label30
			// 
			resources.ApplyResources(this.label30, "label30");
			this.label30.Name = "label30";
			// 
			// tbSAFamily
			// 
			resources.ApplyResources(this.tbSAFamily, "tbSAFamily");
			this.tbSAFamily.Name = "tbSAFamily";
			this.tbSAFamily.TextChanged += new System.EventHandler(this.SAChange);
			// 
			// lbApts
			// 
			resources.ApplyResources(this.lbApts, "lbApts");
			this.lbApts.Items.AddRange(new object[] {
			resources.GetString("lbApts.Items"),
			resources.GetString("lbApts.Items1"),
			resources.GetString("lbApts.Items2"),
			resources.GetString("lbApts.Items3")});
			this.lbApts.MinimumSize = new System.Drawing.Size(0, 44);
			this.lbApts.MultiColumn = true;
			this.lbApts.Name = "lbApts";
			this.lbApts.SelectedIndexChanged += new System.EventHandler(this.lbApts_SelectedIndexChanged);
			// 
			// tbApBase
			// 
			resources.ApplyResources(this.tbApBase, "tbApBase");
			this.tbApBase.Name = "tbApBase";
			this.tbApBase.TextChanged += new System.EventHandler(this.tbApBase_TextChanged);
			// 
			// llAptBase
			// 
			resources.ApplyResources(this.llAptBase, "llAptBase");
			this.llAptBase.Name = "llAptBase";
			this.llAptBase.TabStop = true;
			this.llAptBase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_Click);
			// 
			// btnDelApt
			// 
			resources.ApplyResources(this.btnDelApt, "btnDelApt");
			this.btnDelApt.Name = "btnDelApt";
			this.btnDelApt.UseVisualStyleBackColor = true;
			this.btnDelApt.Click += new System.EventHandler(this.btnDelApt_Click);
			// 
			// btnAddApt
			// 
			resources.ApplyResources(this.btnAddApt, "btnAddApt");
			this.btnAddApt.Name = "btnAddApt";
			this.btnAddApt.UseVisualStyleBackColor = true;
			this.btnAddApt.Click += new System.EventHandler(this.btnAddApt_Click);
			// 
			// tbdesc
			// 
			resources.ApplyResources(this.tbdesc, "tbdesc");
			this.tbdesc.Name = "tbdesc";
			this.tbdesc.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// gbtravel
			// 
			this.gbtravel.BackColor = System.Drawing.Color.Transparent;
			this.gbtravel.Controls.Add(this.cbtrjflag5);
			this.gbtravel.Controls.Add(this.cbtrjflag4);
			this.gbtravel.Controls.Add(this.cbtrjflag3);
			this.gbtravel.Controls.Add(this.cbtrjflag2);
			this.gbtravel.Controls.Add(this.cbtrjflag1);
			this.gbtravel.Controls.Add(this.cbtrjungle);
			this.gbtravel.Controls.Add(this.cbtrhidec);
			this.gbtravel.Controls.Add(this.cbtrpool);
			this.gbtravel.Controls.Add(this.cbtrmale);
			this.gbtravel.Controls.Add(this.cbtrfem);
			this.gbtravel.Controls.Add(this.cbtrbeach);
			this.gbtravel.Controls.Add(this.cbtrformal);
			this.gbtravel.Controls.Add(this.cbtrteen);
			this.gbtravel.Controls.Add(this.cbtrnude);
			this.gbtravel.Controls.Add(this.cbtrpern);
			this.gbtravel.Controls.Add(this.cgtrwhite);
			this.gbtravel.Controls.Add(this.cbtrblue);
			this.gbtravel.Controls.Add(this.cbtrredred);
			this.gbtravel.Controls.Add(this.cbtradult);
			this.gbtravel.Controls.Add(this.cbtrclub);
			resources.ApplyResources(this.gbtravel, "gbtravel");
			this.gbtravel.Name = "gbtravel";
			this.gbtravel.TabStop = false;
			// 
			// cbtrjflag5
			// 
			resources.ApplyResources(this.cbtrjflag5, "cbtrjflag5");
			this.cbtrjflag5.Name = "cbtrjflag5";
			this.cbtrjflag5.UseVisualStyleBackColor = true;
			this.cbtrjflag5.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrjflag4
			// 
			resources.ApplyResources(this.cbtrjflag4, "cbtrjflag4");
			this.cbtrjflag4.Name = "cbtrjflag4";
			this.cbtrjflag4.UseVisualStyleBackColor = true;
			this.cbtrjflag4.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrjflag3
			// 
			resources.ApplyResources(this.cbtrjflag3, "cbtrjflag3");
			this.cbtrjflag3.Name = "cbtrjflag3";
			this.cbtrjflag3.UseVisualStyleBackColor = true;
			this.cbtrjflag3.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrjflag2
			// 
			resources.ApplyResources(this.cbtrjflag2, "cbtrjflag2");
			this.cbtrjflag2.Name = "cbtrjflag2";
			this.cbtrjflag2.UseVisualStyleBackColor = true;
			this.cbtrjflag2.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrjflag1
			// 
			resources.ApplyResources(this.cbtrjflag1, "cbtrjflag1");
			this.cbtrjflag1.Name = "cbtrjflag1";
			this.cbtrjflag1.UseVisualStyleBackColor = true;
			this.cbtrjflag1.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrjungle
			// 
			resources.ApplyResources(this.cbtrjungle, "cbtrjungle");
			this.cbtrjungle.Name = "cbtrjungle";
			this.cbtrjungle.UseVisualStyleBackColor = true;
			this.cbtrjungle.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrhidec
			// 
			resources.ApplyResources(this.cbtrhidec, "cbtrhidec");
			this.cbtrhidec.Name = "cbtrhidec";
			this.cbtrhidec.UseVisualStyleBackColor = true;
			this.cbtrhidec.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrpool
			// 
			resources.ApplyResources(this.cbtrpool, "cbtrpool");
			this.cbtrpool.Name = "cbtrpool";
			this.cbtrpool.UseVisualStyleBackColor = true;
			this.cbtrpool.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrmale
			// 
			resources.ApplyResources(this.cbtrmale, "cbtrmale");
			this.cbtrmale.Name = "cbtrmale";
			this.cbtrmale.UseVisualStyleBackColor = true;
			this.cbtrmale.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrfem
			// 
			resources.ApplyResources(this.cbtrfem, "cbtrfem");
			this.cbtrfem.Name = "cbtrfem";
			this.cbtrfem.UseVisualStyleBackColor = true;
			this.cbtrfem.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrbeach
			// 
			resources.ApplyResources(this.cbtrbeach, "cbtrbeach");
			this.cbtrbeach.Name = "cbtrbeach";
			this.cbtrbeach.UseVisualStyleBackColor = true;
			this.cbtrbeach.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrformal
			// 
			resources.ApplyResources(this.cbtrformal, "cbtrformal");
			this.cbtrformal.Name = "cbtrformal";
			this.cbtrformal.UseVisualStyleBackColor = true;
			this.cbtrformal.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrteen
			// 
			resources.ApplyResources(this.cbtrteen, "cbtrteen");
			this.cbtrteen.Name = "cbtrteen";
			this.cbtrteen.UseVisualStyleBackColor = true;
			this.cbtrteen.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrnude
			// 
			resources.ApplyResources(this.cbtrnude, "cbtrnude");
			this.cbtrnude.Name = "cbtrnude";
			this.cbtrnude.UseVisualStyleBackColor = true;
			this.cbtrnude.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrpern
			// 
			resources.ApplyResources(this.cbtrpern, "cbtrpern");
			this.cbtrpern.Name = "cbtrpern";
			this.cbtrpern.UseVisualStyleBackColor = true;
			this.cbtrpern.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cgtrwhite
			// 
			resources.ApplyResources(this.cgtrwhite, "cgtrwhite");
			this.cgtrwhite.Name = "cgtrwhite";
			this.cgtrwhite.UseVisualStyleBackColor = true;
			this.cgtrwhite.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrblue
			// 
			resources.ApplyResources(this.cbtrblue, "cbtrblue");
			this.cbtrblue.Name = "cbtrblue";
			this.cbtrblue.UseVisualStyleBackColor = true;
			this.cbtrblue.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrredred
			// 
			resources.ApplyResources(this.cbtrredred, "cbtrredred");
			this.cbtrredred.Name = "cbtrredred";
			this.cbtrredred.UseVisualStyleBackColor = true;
			this.cbtrredred.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtradult
			// 
			resources.ApplyResources(this.cbtradult, "cbtradult");
			this.cbtradult.Name = "cbtradult";
			this.cbtradult.UseVisualStyleBackColor = true;
			this.cbtradult.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbtrclub
			// 
			resources.ApplyResources(this.cbtrclub, "cbtrclub");
			this.cbtrclub.Name = "cbtrclub";
			this.cbtrclub.UseVisualStyleBackColor = true;
			this.cbtrclub.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// tblotname
			// 
			resources.ApplyResources(this.tblotname, "tblotname");
			this.tblotname.Name = "tblotname";
			this.tblotname.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// gbhobby
			// 
			this.gbhobby.BackColor = System.Drawing.Color.Transparent;
			this.gbhobby.Controls.Add(this.cbhbmusic);
			this.gbhobby.Controls.Add(this.cbhbsport);
			this.gbhobby.Controls.Add(this.cbhbscience);
			this.gbhobby.Controls.Add(this.cbhbfitness);
			this.gbhobby.Controls.Add(this.cbhbtinker);
			this.gbhobby.Controls.Add(this.cbhbnature);
			this.gbhobby.Controls.Add(this.cbhbgames);
			this.gbhobby.Controls.Add(this.cbhbfilm);
			this.gbhobby.Controls.Add(this.cbhbart);
			this.gbhobby.Controls.Add(this.cbhbcook);
			resources.ApplyResources(this.gbhobby, "gbhobby");
			this.gbhobby.Name = "gbhobby";
			this.gbhobby.TabStop = false;
			// 
			// cbhbmusic
			// 
			resources.ApplyResources(this.cbhbmusic, "cbhbmusic");
			this.cbhbmusic.Name = "cbhbmusic";
			this.cbhbmusic.UseVisualStyleBackColor = true;
			this.cbhbmusic.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbhbsport
			// 
			resources.ApplyResources(this.cbhbsport, "cbhbsport");
			this.cbhbsport.Name = "cbhbsport";
			this.cbhbsport.UseVisualStyleBackColor = true;
			this.cbhbsport.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbhbscience
			// 
			resources.ApplyResources(this.cbhbscience, "cbhbscience");
			this.cbhbscience.Name = "cbhbscience";
			this.cbhbscience.UseVisualStyleBackColor = true;
			this.cbhbscience.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbhbfitness
			// 
			resources.ApplyResources(this.cbhbfitness, "cbhbfitness");
			this.cbhbfitness.Name = "cbhbfitness";
			this.cbhbfitness.UseVisualStyleBackColor = true;
			this.cbhbfitness.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbhbtinker
			// 
			resources.ApplyResources(this.cbhbtinker, "cbhbtinker");
			this.cbhbtinker.Name = "cbhbtinker";
			this.cbhbtinker.UseVisualStyleBackColor = true;
			this.cbhbtinker.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbhbnature
			// 
			resources.ApplyResources(this.cbhbnature, "cbhbnature");
			this.cbhbnature.Name = "cbhbnature";
			this.cbhbnature.UseVisualStyleBackColor = true;
			this.cbhbnature.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbhbgames
			// 
			resources.ApplyResources(this.cbhbgames, "cbhbgames");
			this.cbhbgames.Name = "cbhbgames";
			this.cbhbgames.UseVisualStyleBackColor = true;
			this.cbhbgames.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbhbfilm
			// 
			resources.ApplyResources(this.cbhbfilm, "cbhbfilm");
			this.cbhbfilm.Name = "cbhbfilm";
			this.cbhbfilm.UseVisualStyleBackColor = true;
			this.cbhbfilm.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbhbart
			// 
			resources.ApplyResources(this.cbhbart, "cbhbart");
			this.cbhbart.Name = "cbhbart";
			this.cbhbart.UseVisualStyleBackColor = true;
			this.cbhbart.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// cbhbcook
			// 
			resources.ApplyResources(this.cbhbcook, "cbhbcook");
			this.cbhbcook.Name = "cbhbcook";
			this.cbhbcook.UseVisualStyleBackColor = true;
			this.cbhbcook.CheckedChanged += new System.EventHandler(this.hobbytravel_CheckedChanged);
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// llunknone
			// 
			resources.ApplyResources(this.llunknone, "llunknone");
			this.llunknone.Name = "llunknone";
			this.llunknone.TabStop = true;
			this.llunknone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llunknone_LinkClicked);
			// 
			// gbFlagg
			// 
			this.gbFlagg.Controls.Add(this.tbu0);
			this.gbFlagg.Controls.Add(this.label21);
			this.gbFlagg.Controls.Add(this.cbBeachy);
			this.gbFlagg.Controls.Add(this.cbhidim);
			resources.ApplyResources(this.gbFlagg, "gbFlagg");
			this.gbFlagg.Name = "gbFlagg";
			this.gbFlagg.TabStop = false;
			// 
			// tbu0
			// 
			resources.ApplyResources(this.tbu0, "tbu0");
			this.tbu0.Name = "tbu0";
			this.tbu0.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label21
			// 
			resources.ApplyResources(this.label21, "label21");
			this.label21.Name = "label21";
			// 
			// cbBeachy
			// 
			resources.ApplyResources(this.cbBeachy, "cbBeachy");
			this.cbBeachy.Name = "cbBeachy";
			this.cbBeachy.UseVisualStyleBackColor = true;
			this.cbBeachy.CheckedChanged += new System.EventHandler(this.cbhidim_CheckedChanged);
			// 
			// cbhidim
			// 
			resources.ApplyResources(this.cbhidim, "cbhidim");
			this.cbhidim.Name = "cbhidim";
			this.cbhidim.UseVisualStyleBackColor = true;
			this.cbhidim.CheckedChanged += new System.EventHandler(this.cbhidim_CheckedChanged);
			// 
			// gbunown
			// 
			resources.ApplyResources(this.gbunown, "gbunown");
			this.gbunown.Controls.Add(this.tbu2);
			this.gbunown.Controls.Add(this.label18);
			this.gbunown.Controls.Add(this.label32);
			this.gbunown.Controls.Add(this.label19);
			this.gbunown.Controls.Add(this.lbu7);
			this.gbunown.Controls.Add(this.tbu3);
			this.gbunown.Controls.Add(this.label16);
			this.gbunown.Controls.Add(this.tbData);
			this.gbunown.Controls.Add(this.tbu7);
			this.gbunown.Controls.Add(this.tbu5);
			this.gbunown.Controls.Add(this.label24);
			this.gbunown.Controls.Add(this.tbu6);
			this.gbunown.Controls.Add(this.label23);
			this.gbunown.Name = "gbunown";
			this.gbunown.TabStop = false;
			// 
			// tbu2
			// 
			resources.ApplyResources(this.tbu2, "tbu2");
			this.tbu2.Name = "tbu2";
			this.tbu2.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label18
			// 
			resources.ApplyResources(this.label18, "label18");
			this.label18.Name = "label18";
			// 
			// label32
			// 
			resources.ApplyResources(this.label32, "label32");
			this.label32.Name = "label32";
			// 
			// label19
			// 
			resources.ApplyResources(this.label19, "label19");
			this.label19.Name = "label19";
			// 
			// lbu7
			// 
			resources.ApplyResources(this.lbu7, "lbu7");
			this.lbu7.Items.AddRange(new object[] {
			resources.GetString("lbu7.Items"),
			resources.GetString("lbu7.Items1"),
			resources.GetString("lbu7.Items2"),
			resources.GetString("lbu7.Items3"),
			resources.GetString("lbu7.Items4"),
			resources.GetString("lbu7.Items5"),
			resources.GetString("lbu7.Items6"),
			resources.GetString("lbu7.Items7")});
			this.lbu7.MinimumSize = new System.Drawing.Size(0, 44);
			this.lbu7.MultiColumn = true;
			this.lbu7.Name = "lbu7";
			this.lbu7.SelectedIndexChanged += new System.EventHandler(this.lbu7_SelectedIndexChanged);
			// 
			// tbu3
			// 
			resources.ApplyResources(this.tbu3, "tbu3");
			this.tbu3.Name = "tbu3";
			this.tbu3.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label16
			// 
			resources.ApplyResources(this.label16, "label16");
			this.label16.Name = "label16";
			// 
			// tbData
			// 
			resources.ApplyResources(this.tbData, "tbData");
			this.tbData.Name = "tbData";
			this.tbData.TextChanged += new System.EventHandler(this.ChangeData);
			// 
			// tbu7
			// 
			resources.ApplyResources(this.tbu7, "tbu7");
			this.tbu7.Name = "tbu7";
			this.tbu7.TextChanged += new System.EventHandler(this.tbu7_TextChanged);
			// 
			// tbu5
			// 
			resources.ApplyResources(this.tbu5, "tbu5");
			this.tbu5.Name = "tbu5";
			this.tbu5.TextChanged += new System.EventHandler(this.ChangeData);
			// 
			// label24
			// 
			resources.ApplyResources(this.label24, "label24");
			this.label24.Name = "label24";
			// 
			// tbu6
			// 
			resources.ApplyResources(this.tbu6, "tbu6");
			this.tbu6.Name = "tbu6";
			this.tbu6.TextChanged += new System.EventHandler(this.ChangeData);
			// 
			// label23
			// 
			resources.ApplyResources(this.label23, "label23");
			this.label23.Name = "label23";
			// 
			// gbclarse
			// 
			this.gbclarse.Controls.Add(this.label11);
			this.gbclarse.Controls.Add(this.cbLotClas);
			this.gbclarse.Controls.Add(this.tbcset);
			this.gbclarse.Controls.Add(this.tblotclass);
			this.gbclarse.Controls.Add(this.label17);
			resources.ApplyResources(this.gbclarse, "gbclarse");
			this.gbclarse.Name = "gbclarse";
			this.gbclarse.TabStop = false;
			// 
			// label11
			// 
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// cbLotClas
			// 
			resources.ApplyResources(this.cbLotClas, "cbLotClas");
			this.cbLotClas.FormattingEnabled = true;
			this.cbLotClas.Items.AddRange(new object[] {
			resources.GetString("cbLotClas.Items"),
			resources.GetString("cbLotClas.Items1"),
			resources.GetString("cbLotClas.Items2"),
			resources.GetString("cbLotClas.Items3")});
			this.cbLotClas.Name = "cbLotClas";
			this.cbLotClas.SelectedIndexChanged += new System.EventHandler(this.cbhidim_CheckedChanged);
			// 
			// tbcset
			// 
			resources.ApplyResources(this.tbcset, "tbcset");
			this.tbcset.Name = "tbcset";
			// 
			// tblotclass
			// 
			resources.ApplyResources(this.tblotclass, "tblotclass");
			this.tblotclass.Name = "tblotclass";
			// 
			// label17
			// 
			resources.ApplyResources(this.label17, "label17");
			this.label17.Name = "label17";
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// lb
			// 
			resources.ApplyResources(this.lb, "lb");
			this.lb.Items.AddRange(new object[] {
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
			resources.GetString("lb.Items44")});
			this.lb.MultiColumn = true;
			this.lb.Name = "lb";
			this.lb.SelectedIndexChanged += new System.EventHandler(this.lb_SelectedIndexChanged);
			// 
			// tbElevationAt
			// 
			resources.ApplyResources(this.tbElevationAt, "tbElevationAt");
			this.tbElevationAt.Name = "tbElevationAt";
			this.tbElevationAt.TextChanged += new System.EventHandler(this.tbElevationAt_TextChanged);
			// 
			// label25
			// 
			resources.ApplyResources(this.label25, "label25");
			this.label25.Name = "label25";
			this.label25.DoubleClick += new System.EventHandler(this.label25_Click);
			// 
			// tbowner
			// 
			resources.ApplyResources(this.tbowner, "tbowner");
			this.tbowner.Name = "tbowner";
			this.tbowner.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label15
			// 
			resources.ApplyResources(this.label15, "label15");
			this.label15.Name = "label15";
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// bthbytrvl
			// 
			resources.ApplyResources(this.bthbytrvl, "bthbytrvl");
			this.bthbytrvl.Name = "bthbytrvl";
			this.bthbytrvl.UseVisualStyleBackColor = true;
			this.bthbytrvl.Click += new System.EventHandler(this.Openpntravel);
			// 
			// tbinst
			// 
			resources.ApplyResources(this.tbinst, "tbinst");
			this.tbinst.Name = "tbinst";
			this.tbinst.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label14
			// 
			resources.ApplyResources(this.label14, "label14");
			this.label14.Name = "label14";
			// 
			// tbu4
			// 
			resources.ApplyResources(this.tbu4, "tbu4");
			this.tbu4.Name = "tbu4";
			this.tbu4.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// cborient
			// 
			this.cborient.Enum = null;
			resources.ApplyResources(this.cborient, "cborient");
			this.cborient.Name = "cborient";
			this.cborient.ResourceManager = null;
			this.cborient.SelectedIndexChanged += new System.EventHandler(this.CommonChange);
			// 
			// tbTexture
			// 
			resources.ApplyResources(this.tbTexture, "tbTexture");
			this.tbTexture.Name = "tbTexture";
			this.tbTexture.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// tbwd
			// 
			resources.ApplyResources(this.tbwd, "tbwd");
			this.tbwd.Name = "tbwd";
			this.tbwd.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// tbrotation
			// 
			resources.ApplyResources(this.tbrotation, "tbrotation");
			this.tbrotation.Name = "tbrotation";
			this.tbrotation.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// label10
			// 
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			// 
			// tbhg
			// 
			resources.ApplyResources(this.tbhg, "tbhg");
			this.tbhg.Name = "tbhg";
			this.tbhg.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// tbRoads
			// 
			resources.ApplyResources(this.tbRoads, "tbRoads");
			this.tbRoads.Name = "tbRoads";
			this.tbRoads.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label12
			// 
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			// 
			// tbver
			// 
			this.tbver.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(this.tbver, "tbver");
			this.tbver.Name = "tbver";
			this.tbver.ReadOnly = true;
			// 
			// tbtop
			// 
			resources.ApplyResources(this.tbtop, "tbtop");
			this.tbtop.Name = "tbtop";
			this.tbtop.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label13
			// 
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			// 
			// tbsubver
			// 
			this.tbsubver.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(this.tbsubver, "tbsubver");
			this.tbsubver.Name = "tbsubver";
			this.tbsubver.ReadOnly = true;
			// 
			// tbleft
			// 
			resources.ApplyResources(this.tbleft, "tbleft");
			this.tbleft.Name = "tbleft";
			this.tbleft.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// label20
			// 
			resources.ApplyResources(this.label20, "label20");
			this.label20.Name = "label20";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// tbz
			// 
			resources.ApplyResources(this.tbz, "tbz");
			this.tbz.Name = "tbz";
			this.tbz.TextChanged += new System.EventHandler(this.CommonChange);
			// 
			// cbtype
			// 
			resources.ApplyResources(this.cbtype, "cbtype");
			this.cbtype.Name = "cbtype";
			this.cbtype.SelectedIndexChanged += new System.EventHandler(this.SelectType);
			// 
			// tbtype
			// 
			this.tbtype.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(this.tbtype, "tbtype");
			this.tbtype.Name = "tbtype";
			this.tbtype.ReadOnly = true;
			// 
			// panel2
			// 
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Name = "panel2";
			// 
			// pb
			// 
			resources.ApplyResources(this.pb, "pb");
			this.pb.Name = "pb";
			this.pb.TabStop = false;
			// 
			// LtxtForm
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.ltxtPanel);
			this.Name = "LtxtForm";
			this.ltxtPanel.ResumeLayout(false);
			this.ltxtPanel.PerformLayout();
			this.gbApart.ResumeLayout(false);
			this.gbApart.PerformLayout();
			this.gbApartment.ResumeLayout(false);
			this.gbApartment.PerformLayout();
			this.gbtravel.ResumeLayout(false);
			this.gbtravel.PerformLayout();
			this.gbhobby.ResumeLayout(false);
			this.gbhobby.PerformLayout();
			this.gbFlagg.ResumeLayout(false);
			this.gbFlagg.PerformLayout();
			this.gbunown.ResumeLayout(false);
			this.gbunown.PerformLayout();
			this.gbclarse.ResumeLayout(false);
			this.gbclarse.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		internal Ltxt wrapper;

		private void SelectType(object sender, System.EventArgs e)
		{
			if (wrapper == null) return;
			if (Enum.IsDefined(typeof(Ltxt.LotType), cbtype.SelectedItem))
				wrapper.Type = (Ltxt.LotType)cbtype.SelectedItem;
			else
				wrapper.Type = Ltxt.LotType.Unknown;
			tbtype.Text = "0x" + Helper.HexString((byte)wrapper.Type);
			btnAddApt.Enabled = btnDelApt.Enabled = (wrapper.Type == Ltxt.LotType.ApartmentBase);
			cbtrclub.Enabled = cbtrhidec.Enabled = gbhobby.Enabled = (wrapper.Type == Ltxt.LotType.Hobby);
			if (wrapper.SubVersion >= LtxtSubVersion.Freetime)
				bthbytrvl.Enabled = (wrapper.Type == Ltxt.LotType.Hobby);
			if (wrapper.Type == Ltxt.LotType.ApartmentBase || wrapper.Type == Ltxt.LotType.ApartmentSublot)
			{
				gbApart.Visible = true;
				gbunown.Location = new System.Drawing.Point(116, 408);
				llunknone.Location = new System.Drawing.Point(41, 408);
				gbhobby.Location = new System.Drawing.Point(30, 408);
				gbtravel.Location = new System.Drawing.Point(372, 408);
			}
			else
			{
				gbApart.Visible = false;
				gbunown.Location = new System.Drawing.Point(116, 333);
				llunknone.Location = new System.Drawing.Point(41, 333);
				gbhobby.Location = new System.Drawing.Point(30, 333);
				gbtravel.Location = new System.Drawing.Point(372, 333);
			}

			wrapper.Changed = true;
		}

		private void Commit(object sender, System.EventArgs e)
		{
			if (wrapper == null) return;
			try
			{
				wrapper.SynchronizeUserData();
				MessageBox.Show(Localization.Manager.GetString("commited"));
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(Localization.Manager.GetString("errwritingfile"), ex);
			}
		}

		private void CommonChange(object sender, System.EventArgs e)
		{
			if (wrapper == null) return;
			try
			{
				wrapper.LotRoads = Convert.ToByte(this.tbRoads.Text, 16);

				wrapper.LotSize = new Size(
					Helper.StringToInt32(tbwd.Text, wrapper.LotSize.Width, 10),
					Helper.StringToInt32(tbhg.Text, wrapper.LotSize.Height, 10));
				wrapper.LotPosition = new Point(
					Helper.StringToInt32(tbleft.Text, wrapper.LotPosition.X, 10),
					Helper.StringToInt32(tbtop.Text, wrapper.LotPosition.Y, 10));
				wrapper.LotElevation = Helper.StringToFloat(tbz.Text, wrapper.LotElevation);

				wrapper.Orientation = (LotOrientation)cborient.SelectedValue;
				wrapper.LotRotation = Convert.ToByte(this.tbrotation.Text, 16);
				wrapper.Unknown0 = Helper.StringToUInt32(tbu0.Text, wrapper.Unknown0, 16);
				Boolset bby = wrapper.Unknown0;
				this.cbhidim.Checked = bby[4];
				this.cbBeachy.Checked = bby[7];
				if (wrapper.Version >= LtxtVersion.Apartment || wrapper.SubVersion >= LtxtSubVersion.Apartment)
				{
					this.cbLotClas.Enabled = true;
					if (bby[12]) this.cbLotClas.SelectedIndex = 1;
					else if (bby[13]) this.cbLotClas.SelectedIndex = 2;
					else if (bby[14]) this.cbLotClas.SelectedIndex = 3;
					else this.cbLotClas.SelectedIndex = 0;
				}
				else
				{
					this.cbLotClas.SelectedIndex = 0;
					this.cbLotClas.Enabled = false;
				}

				wrapper.LotName = tblotname.Text;
				wrapper.Texture = tbTexture.Text;
				wrapper.LotDesc = tbdesc.Text;

				wrapper.LotInstance = Helper.StringToUInt32(tbinst.Text, wrapper.LotInstance, 16);
				wrapper.Unknown3 = Helper.StringToFloat(tbu3.Text, wrapper.Unknown3);
				wrapper.Unknown4 = Helper.StringToUInt32(tbu4.Text, wrapper.Unknown4, 16);
				wrapper.LotClass = Helper.StringToUInt32(tblotclass.Text, wrapper.LotClass, 16);
				Boolset tty = wrapper.Unknown4;

				this.cbtrjflag5.Checked = tty[30];
				this.cbtrjflag4.Checked = tty[28];
				this.cbtrjflag3.Checked = tty[27];
				this.cbtrjflag2.Checked = tty[26];
				this.cbtrjflag1.Checked = tty[25];
				this.cbtrjungle.Checked = tty[24];
				this.cbtrhidec.Checked = tty[23];
				this.cbtrpool.Checked = tty[22];
				this.cbtrmale.Checked = tty[21];
				this.cbtrfem.Checked = tty[20];
				this.cbtrbeach.Checked = tty[19];
				this.cbtrformal.Checked = tty[18];
				this.cbtrteen.Checked = tty[17];
				this.cbtrnude.Checked = tty[16];
				this.cbtrpern.Checked = tty[15];
				this.cgtrwhite.Checked = tty[14];
				this.cbtrblue.Checked = tty[13];
				this.cbtrredred.Checked = tty[12];
				this.cbtradult.Checked = tty[11];
				this.cbtrclub.Checked = tty[10];
				this.cbhbmusic.Checked = tty[9];
				this.cbhbscience.Checked = tty[8];
				this.cbhbfitness.Checked = tty[7];
				this.cbhbtinker.Checked = tty[6];
				this.cbhbnature.Checked = tty[5];
				this.cbhbgames.Checked = tty[4];
				this.cbhbsport.Checked = tty[3];
				this.cbhbfilm.Checked = tty[2];
				this.cbhbart.Checked = tty[1];
				this.cbhbcook.Checked = tty[0];

				wrapper.Unknown2 = (byte)Helper.StringToUInt16(tbu2.Text, wrapper.Unknown2, 16);
				wrapper.OwnerInstance = Helper.StringToUInt32(tbowner.Text, wrapper.OwnerInstance, 16);

				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void cbhidim_CheckedChanged(object sender, System.EventArgs e)
		{
			if (wrapper == null) return;
			try
			{
				Boolset bby = wrapper.Unknown0;
				bby[4] = this.cbhidim.Checked;
				bby[7] = this.cbBeachy.Checked;
				if (wrapper.Version >= LtxtVersion.Apartment || wrapper.SubVersion >= LtxtSubVersion.Apartment)
				{
					bby[12] = (this.cbLotClas.SelectedIndex == 1);
					bby[13] = (this.cbLotClas.SelectedIndex == 2);
					bby[14] = (this.cbLotClas.SelectedIndex == 3);
				}
				wrapper.Unknown0 = bby;
				this.tbu0.Text = "0x" + Helper.HexString(wrapper.Unknown0);
				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void hobbytravel_CheckedChanged(object sender, System.EventArgs e)
		{
			if (wrapper == null) return;
			try
			{
				uint tty = 0;
				if (this.cbhbcook.Checked) tty += 1;
				if (this.cbhbart.Checked) tty += 2;
				if (this.cbhbfilm.Checked) tty += 4;
				if (this.cbhbsport.Checked) tty += 8;
				if (this.cbhbgames.Checked) tty += 16;
				if (this.cbhbnature.Checked) tty += 32;
				if (this.cbhbtinker.Checked) tty += 64;
				if (this.cbhbfitness.Checked) tty += 128;
				if (this.cbhbscience.Checked) tty += 256;
				if (this.cbhbmusic.Checked) tty += 512;
				if (this.cbtrclub.Checked) tty += 1024;
				if (this.cbtradult.Checked) tty += 2048;
				if (this.cbtrredred.Checked) tty += 4096;
				if (this.cbtrblue.Checked) tty += 8192;
				if (this.cgtrwhite.Checked) tty += 16384;
				if (this.cbtrpern.Checked) tty += 32768;
				if (this.cbtrnude.Checked) tty += 65536;
				if (this.cbtrteen.Checked) tty += 131072;
				if (this.cbtrformal.Checked) tty += 262144;
				if (this.cbtrbeach.Checked) tty += 524288;
				if (this.cbtrfem.Checked) tty += 1048576;
				if (this.cbtrmale.Checked) tty += 2097152;
				if (this.cbtrpool.Checked) tty += 4194304;
				if (this.cbtrhidec.Checked) tty += 8388608;
				if (this.cbtrjungle.Checked) tty += 16777216;
				if (this.cbtrjflag1.Checked) tty += 33554432;
				if (this.cbtrjflag2.Checked) tty += 67108864;
				if (this.cbtrjflag3.Checked) tty += 134217728;
				if (this.cbtrjflag4.Checked) tty += 268435456;
				if (this.cbtrjflag5.Checked) tty += 536870912;
				this.cbtrmale.Enabled = !this.cbtrfem.Checked;
				this.cbtrfem.Enabled = !this.cbtrmale.Checked;
				wrapper.Unknown4 = tty;
				this.tbu4.Text = "0x" + Helper.HexString(wrapper.Unknown4);

				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void Openpntravel(object sender, System.EventArgs e)
		{
			if (wrapper == null) return;
			try
			{
				this.gbunown.Visible = false;
				this.gbhobby.Visible = !this.gbhobby.Visible;
				this.gbtravel.Visible = this.gbhobby.Visible;
				//this.bthbytrvl.Enabled = false;
				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void ChangeData(object sender, System.EventArgs e)
		{
			if (wrapper == null) return;
			try
			{
				wrapper.Unknown5 = Helper.SetLength(Helper.HexListToBytes(this.tbu5.Text), 9);
				wrapper.Unknown6 = Helper.SetLength(Helper.HexListToBytes(this.tbu6.Text), 9);
				wrapper.Followup = Helper.SetLength(Helper.HexListToBytes(this.tbData.Text), 0);

				wrapper.Changed = true;
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
		}

		private void lb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (wrapper == null) return;
			Ltxt wrp = wrapper;
			wrapper = null;

			if (lb.SelectedIndex < 0)
				tbElevationAt.Text = "";
			else
				tbElevationAt.Text = wrp.Unknown1[lb.SelectedIndex].ToString();

			wrapper = wrp;
		}

		private void tbElevationAt_TextChanged(object sender, EventArgs e)
		{
			if (wrapper == null) return;
			if (lb.SelectedIndex < 0) return;

			Ltxt wrp = wrapper;
			wrapper = null;

			try
			{
				wrp.Unknown1[lb.SelectedIndex] = Helper.StringToFloat(tbElevationAt.Text, wrp.Unknown1[lb.SelectedIndex]);
				int x, y;
				y = Convert.ToInt32(lb.SelectedIndex / wrp.LotSize.Height);
				x = lb.SelectedIndex - y * wrp.LotSize.Height;
				lb.Items[lb.SelectedIndex] = "(" + x + "," + y + ") " + wrp.Unknown1[lb.SelectedIndex];

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
			if (wrapper == null) return;
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
			if (wrapper == null) return;
			if (lbApts.SelectedIndex < 0) return;

			Ltxt wrp = wrapper;
			wrapper = null;

			try
			{
				Ltxt.SubLot sl = wrp.SubLots[lbApts.SelectedIndex];
				sl.ApartmentSublot = Helper.StringToUInt32(tbApartment.Text, sl.ApartmentSublot, 16);
				sl.Family = Helper.StringToUInt32(tbSAFamily.Text, sl.Family, 16);
				sl.Unknown2 = Helper.StringToUInt32(tbSAu2.Text, sl.Unknown2, 16);
				sl.Unknown3 = Helper.StringToUInt32(tbSAu3.Text, sl.Unknown3, 16);
				lbApts.Items[lbApts.SelectedIndex] = "0x" + Helper.HexString(sl.ApartmentSublot);

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
			if (wrapper == null) return;
			Ltxt wrp = wrapper;
			wrapper = null;

			if (lbu7.SelectedIndex < 0)
				tbu7.Text = "";
			else
				tbu7.Text = (string)lbu7.SelectedItem;

			wrapper = wrp;
		}

		private void tbu7_TextChanged(object sender, EventArgs e)
		{
			if (wrapper == null) return;
			if (lbu7.SelectedIndex < 0) return;

			Ltxt wrp = wrapper;
			wrapper = null;

			try
			{
				wrp.Unknown7[lbu7.SelectedIndex] = Helper.StringToUInt32(tbu7.Text, wrp.Unknown7[lbu7.SelectedIndex], 16);
				lbu7.Items[lb.SelectedIndex] = "0x" + Helper.HexString(wrp.Unknown7[lb.SelectedIndex]);

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
				new System.Collections.Generic.List<LinkLabel>(new LinkLabel[] { llAptBase, llSubLot, llFamily, });

			uint type, inst;
			switch (lll.IndexOf((LinkLabel)sender))
			{
				case 0:
					type = (uint)0x0BF999E7;
					inst = wrapper.ApartmentBase;
					break;
				case 1:
					type = (uint)0x0BF999E7;
					inst = wrapper.SubLots[lbApts.SelectedIndex].ApartmentSublot;
					break;
				case 2:
					type = (uint)0x46414D49;
					inst = wrapper.SubLots[lbApts.SelectedIndex].Family;
					break;
				default:
					return;
			}

			Interfaces.Files.IPackedFileDescriptor pfd =
				wrapper.Package.NewDescriptor(type, wrapper.FileDescriptor.SubType, wrapper.FileDescriptor.Group, inst);
			pfd = wrapper.Package.FindFile(pfd);
			if (pfd == null) return;

			SimPe.RemoteControl.OpenPackedFile(pfd, wrapper.Package);
		}

		private void btnAddApt_Click(object sender, EventArgs e)
		{
			wrapper.SubLots.Add(new Ltxt.SubLot());
			lbApts.Items.Add("0x" + Helper.HexString(wrapper.SubLots[wrapper.SubLots.Count - 1].ApartmentSublot));
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

			if (i > 0) i--;
			else if (lbApts.Items.Count == 0) i = -1;

			lbApts.SelectedIndex = i;
			lbApts.EndUpdate();

			wrapper.Changed = true;
		}

		private void tbApBase_TextChanged(object sender, EventArgs e)
		{
			if (wrapper == null) return;
			wrapper.ApartmentBase = Helper.StringToUInt32(tbApBase.Text, wrapper.ApartmentBase, 16);
			llAptBase.Enabled = (wrapper.ApartmentBase != 0);
		}

		private void label25_Click(object sender, EventArgs e)
		{
			uint simmy = Helper.StringToUInt32(tbowner.Text, wrapper.OwnerInstance, 16);
			if (simmy == 0) return;
			SimPe.PackedFiles.Wrapper.ExtSDesc sdsc = FileTable.ProviderRegistry.SimDescriptionProvider.SimInstance[(ushort)simmy] as SimPe.PackedFiles.Wrapper.ExtSDesc;
			if (sdsc != null)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = sdsc.Package.NewDescriptor(0xAACE2EFB, sdsc.FileDescriptor.SubType, sdsc.FileDescriptor.Group, sdsc.FileDescriptor.Instance);
				pfd = sdsc.Package.FindFile(pfd);
				SimPe.RemoteControl.OpenPackedFile(pfd, sdsc.Package);
			}
		}

		private void llunknone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.gbunown.Visible = !this.gbunown.Visible;
		}
	}
}
