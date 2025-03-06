// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Forms.MainUI;
using SimPe.PackedFiles.Fami;
using SimPe.PackedFiles.Wrapper.Supporting;

using Message = SimPe.Forms.MainUI.Message;

namespace SimPe.PackedFiles.UserInterface
{
	/// <summary>
	/// Summary description for Elements.
	/// </summary>
	internal class Elements : Form
	{
		private Panel panel2;
		internal PictureBox pb;
		internal Panel JpegPanel;
		internal Panel xmlPanel;
		private Panel panel3;
		internal RichTextBox rtb;
		private System.ComponentModel.IContainer components;
		internal TextBox tbsimid;
		private Label label8;
		internal Panel objdPanel;
		internal TextBox tbsimname;
		private Label label9;
		private TabControl tabControl1;
		private TabPage tabPage1;
		internal Panel famiPanel;
		internal TextBox tblotinst;
		internal Label label15;
		private Button llFamiDeleteSim;
		private Button llFamiAddSim;
		internal Button btOpenHistory;
		internal PictureBox pbImage;
		internal ComboBox cbsims;
		internal ListBox lbmembers;
		internal TextBox tbname;
		private Label label6;
		internal TextBox tbfamily;
		internal TextBox tbmoney;
		private Label label5;
		private Label lbnotiss;
		private Label label4;
		internal Label label3;
		internal Panel panel4;
		private TabPage tabPage3;
		internal Panel realPanel;
		private Panel panel7;
		internal TextBox tblongterm;
		internal TextBox tbshortterm;
		private Label label57;
		private Label label58;
		private GroupBox gbrelation;
		internal CheckBox cbmarried;
		internal CheckBox cbengaged;
		internal CheckBox cbsteady;
		internal CheckBox cblove;
		internal CheckBox cbcrush;
		internal CheckBox cbenemy;
		internal CheckBox cbbuddie;
		internal CheckBox cbfriend;
		private TabPage tabPage4;
		private Label label64;
		private Panel panel8;
		internal Panel familytiePanel;
		internal ComboBox cbtiesims;
		private GroupBox gbties;
		internal ComboBox cbtietype;
		internal Button btdeletetie;
		internal Button btaddtie;
		internal ListBox lbties;
		internal ComboBox cballtieablesims;
		private LinkLabel llcommitties;
		internal Button btnewtie;
		internal TextBox tblottype;
		private Label label65;
		private GroupBox gbelements;
		internal Panel pnelements;
		internal Label lbtypename;
		internal CheckBox cbfamily;
		internal CheckBox cbbest;
		internal ComboBox cbfamtype;
		private Label label91;
		internal TextBox tbflag;
		internal TextBox tbalbum;
		private Label label93;
		internal TextBox tborgguid;
		internal TextBox tbproxguid;
		private Label label97;
		internal ToolTip toolTip1;
		private Label label63;
		private GroupBox groupBox4;
		private CheckBox cbphone;
		private CheckBox cbbaby;
		private CheckBox cbcomputer;
		private CheckBox cblot;
		private CheckBox cbupdate;
		internal TextBox tbsubhood;
		private Label label89;
		private Button btPicExport;
		internal TextBox tbvac;
		internal Label label7;
		internal GroupBox gbCastaway;
		internal TextBox tbcaunk;
		private Label label13;
		internal TextBox tbcares;
		private Label label11;
		internal TextBox tbcafood1;
		private Label label10;
		internal TextBox tbblot;
		internal Label label14;
		internal TextBox tbbmoney;
		internal Label label16;
		internal CheckBox cbplatonic;
		internal CheckBox cbBFF;
		internal CheckBox cbsecret;
		private Panel panel6;

		internal Interfaces.Plugin.IFileWrapperSaveExtension wrapper = null;

		public Elements()
		{
			//
			// Required designer variable.
			//

			InitializeComponent();
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				tbname.Font = new System.Drawing.Font(
					tbname.Font.FontFamily,
					12F
				);
				cbsims.Font = new System.Drawing.Font(
					cbsims.Font.FontFamily,
					12F
				);
				lbmembers.Font = new System.Drawing.Font("Verdana", 12F);
				lbmembers.Location = new System.Drawing.Point(16, 200);
				lbmembers.Size = new System.Drawing.Size(
					356,
					lbmembers.Size.Height
				);
				pbImage.Size = new System.Drawing.Size(168, 168);
				pbImage.Location = new System.Drawing.Point(2, 26);
				rtb.Font = new System.Drawing.Font("Verdana", 12F);
			}
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(Elements));
			JpegPanel = new Panel();
			panel2 = new Panel();
			btPicExport = new Button();
			pb = new PictureBox();
			xmlPanel = new Panel();
			rtb = new RichTextBox();
			panel3 = new Panel();
			objdPanel = new Panel();
			cbupdate = new CheckBox();
			label63 = new Label();
			tbproxguid = new TextBox();
			label97 = new Label();
			tborgguid = new TextBox();
			lbtypename = new Label();
			gbelements = new GroupBox();
			pnelements = new Panel();
			tblottype = new TextBox();
			label65 = new Label();
			tbsimname = new TextBox();
			label9 = new Label();
			tbsimid = new TextBox();
			label8 = new Label();
			panel6 = new Panel();
			tabControl1 = new TabControl();
			tabPage4 = new TabPage();
			familytiePanel = new Panel();
			gbties = new GroupBox();
			btnewtie = new Button();
			cballtieablesims = new ComboBox();
			cbtietype = new ComboBox();
			lbties = new ListBox();
			btdeletetie = new Button();
			btaddtie = new Button();
			llcommitties = new LinkLabel();
			cbtiesims = new ComboBox();
			label64 = new Label();
			panel8 = new Panel();
			tabPage1 = new TabPage();
			famiPanel = new Panel();
			tbbmoney = new TextBox();
			label16 = new Label();
			tbblot = new TextBox();
			label14 = new Label();
			gbCastaway = new GroupBox();
			tbcaunk = new TextBox();
			label13 = new Label();
			tbcares = new TextBox();
			label11 = new Label();
			tbcafood1 = new TextBox();
			label10 = new Label();
			tbvac = new TextBox();
			label7 = new Label();
			tbsubhood = new TextBox();
			label89 = new Label();
			groupBox4 = new GroupBox();
			cbcomputer = new CheckBox();
			cblot = new CheckBox();
			cbbaby = new CheckBox();
			cbphone = new CheckBox();
			tbflag = new TextBox();
			tbalbum = new TextBox();
			label93 = new Label();
			tblotinst = new TextBox();
			llFamiDeleteSim = new Button();
			llFamiAddSim = new Button();
			btOpenHistory = new Button();
			pbImage = new PictureBox();
			cbsims = new ComboBox();
			lbmembers = new ListBox();
			tbname = new TextBox();
			label6 = new Label();
			tbfamily = new TextBox();
			tbmoney = new TextBox();
			label5 = new Label();
			lbnotiss = new Label();
			label4 = new Label();
			label3 = new Label();
			panel4 = new Panel();
			label15 = new Label();
			tabPage3 = new TabPage();
			realPanel = new Panel();
			label91 = new Label();
			cbfamtype = new ComboBox();
			gbrelation = new GroupBox();
			cbBFF = new CheckBox();
			cbsecret = new CheckBox();
			cbplatonic = new CheckBox();
			cbbest = new CheckBox();
			cbfamily = new CheckBox();
			cbmarried = new CheckBox();
			cbengaged = new CheckBox();
			cbsteady = new CheckBox();
			cblove = new CheckBox();
			cbcrush = new CheckBox();
			cbbuddie = new CheckBox();
			cbfriend = new CheckBox();
			cbenemy = new CheckBox();
			tblongterm = new TextBox();
			tbshortterm = new TextBox();
			label57 = new Label();
			label58 = new Label();
			panel7 = new Panel();
			toolTip1 = new ToolTip(components);
			JpegPanel.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			xmlPanel.SuspendLayout();
			objdPanel.SuspendLayout();
			gbelements.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage4.SuspendLayout();
			familytiePanel.SuspendLayout();
			gbties.SuspendLayout();
			tabPage1.SuspendLayout();
			famiPanel.SuspendLayout();
			gbCastaway.SuspendLayout();
			groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
			tabPage3.SuspendLayout();
			realPanel.SuspendLayout();
			gbrelation.SuspendLayout();
			SuspendLayout();
			//
			// JpegPanel
			//
			JpegPanel.BackColor = System.Drawing.Color.Transparent;
			JpegPanel.Controls.Add(panel2);
			JpegPanel.Controls.Add(pb);
			//this.JpegPanel.EndColour = System.Drawing.SystemColors.Control;
			resources.ApplyResources(JpegPanel, "JpegPanel");
			//this.JpegPanel.MiddleColour = System.Drawing.SystemColors.Control;
			JpegPanel.Name = "JpegPanel";
			//this.JpegPanel.StartColour = System.Drawing.SystemColors.Control;
			//
			// panel2
			//
			resources.ApplyResources(panel2, "panel2");
			panel2.Controls.Add(btPicExport);
			panel2.Name = "panel2";
			//
			// btPicExport
			//
			resources.ApplyResources(btPicExport, "btPicExport");
			btPicExport.BackColor = System.Drawing.SystemColors.Control;
			btPicExport.ForeColor = System.Drawing.SystemColors.ControlText;
			btPicExport.Name = "btPicExport";
			btPicExport.UseVisualStyleBackColor = false;
			btPicExport.Click += new EventHandler(btPicExport_Click);
			//
			// pb
			//
			resources.ApplyResources(pb, "pb");
			pb.BackColor = System.Drawing.Color.Transparent;
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// xmlPanel
			//
			xmlPanel.Controls.Add(rtb);
			xmlPanel.Controls.Add(panel3);
			resources.ApplyResources(xmlPanel, "xmlPanel");
			xmlPanel.Name = "xmlPanel";
			//
			// rtb
			//
			resources.ApplyResources(rtb, "rtb");
			rtb.Name = "rtb";
			//
			// panel3
			//
			resources.ApplyResources(panel3, "panel3");
			//this.panel3.CanCommit = true;
			panel3.Name = "panel3";
			//this.panel3.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CommitXmlClick);
			//
			// objdPanel
			//
			objdPanel.Controls.Add(cbupdate);
			objdPanel.Controls.Add(label63);
			objdPanel.Controls.Add(tbproxguid);
			objdPanel.Controls.Add(label97);
			objdPanel.Controls.Add(tborgguid);
			objdPanel.Controls.Add(lbtypename);
			objdPanel.Controls.Add(gbelements);
			objdPanel.Controls.Add(tblottype);
			objdPanel.Controls.Add(label65);
			objdPanel.Controls.Add(tbsimname);
			objdPanel.Controls.Add(label9);
			objdPanel.Controls.Add(tbsimid);
			objdPanel.Controls.Add(label8);
			objdPanel.Controls.Add(panel6);
			resources.ApplyResources(objdPanel, "objdPanel");
			objdPanel.Name = "objdPanel";
			//
			// cbupdate
			//
			cbupdate.BackColor = System.Drawing.Color.Transparent;
			cbupdate.Checked = true;
			cbupdate.CheckState = CheckState.Checked;
			resources.ApplyResources(cbupdate, "cbupdate");
			cbupdate.Name = "cbupdate";
			cbupdate.UseVisualStyleBackColor = false;
			//
			// label63
			//
			resources.ApplyResources(label63, "label63");
			label63.BackColor = System.Drawing.Color.Transparent;
			label63.Name = "label63";
			//
			// tbproxguid
			//
			resources.ApplyResources(tbproxguid, "tbproxguid");
			tbproxguid.Name = "tbproxguid";
			toolTip1.SetToolTip(
				tbproxguid,
				resources.GetString("tbproxguid.ToolTip")
			);
			//
			// label97
			//
			resources.ApplyResources(label97, "label97");
			label97.BackColor = System.Drawing.Color.Transparent;
			label97.Name = "label97";
			//
			// tborgguid
			//
			resources.ApplyResources(tborgguid, "tborgguid");
			tborgguid.Name = "tborgguid";
			toolTip1.SetToolTip(
				tborgguid,
				resources.GetString("tborgguid.ToolTip")
			);
			//
			// lbtypename
			//
			resources.ApplyResources(lbtypename, "lbtypename");
			lbtypename.BackColor = System.Drawing.Color.Transparent;
			lbtypename.Name = "lbtypename";
			//
			// gbelements
			//
			resources.ApplyResources(gbelements, "gbelements");
			gbelements.BackColor = System.Drawing.Color.Transparent;
			gbelements.Controls.Add(pnelements);
			gbelements.Name = "gbelements";
			gbelements.TabStop = false;
			//
			// pnelements
			//
			resources.ApplyResources(pnelements, "pnelements");
			pnelements.Name = "pnelements";
			//
			// tblottype
			//
			resources.ApplyResources(tblottype, "tblottype");
			tblottype.Name = "tblottype";
			//
			// label65
			//
			resources.ApplyResources(label65, "label65");
			label65.BackColor = System.Drawing.Color.Transparent;
			label65.Name = "label65";
			//
			// tbsimname
			//
			resources.ApplyResources(tbsimname, "tbsimname");
			tbsimname.Name = "tbsimname";
			//
			// label9
			//
			resources.ApplyResources(label9, "label9");
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Name = "label9";
			//
			// tbsimid
			//
			resources.ApplyResources(tbsimid, "tbsimid");
			tbsimid.Name = "tbsimid";
			toolTip1.SetToolTip(
				tbsimid,
				resources.GetString("tbsimid.ToolTip")
			);
			//
			// label8
			//
			resources.ApplyResources(label8, "label8");
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Name = "label8";
			//
			// panel6
			//
			resources.ApplyResources(panel6, "panel6");
			//this.panel6.CanCommit = true;
			panel6.Name = "panel6";
			//this.panel6.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CommitObjdClicked);
			//
			// tabControl1
			//
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage3);
			resources.ApplyResources(tabControl1, "tabControl1");
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			//
			// tabPage4
			//
			tabPage4.Controls.Add(familytiePanel);
			resources.ApplyResources(tabPage4, "tabPage4");
			tabPage4.Name = "tabPage4";
			//
			// familytiePanel
			//
			resources.ApplyResources(familytiePanel, "familytiePanel");
			familytiePanel.Controls.Add(gbties);
			familytiePanel.Controls.Add(cbtiesims);
			familytiePanel.Controls.Add(label64);
			familytiePanel.Controls.Add(panel8);
			familytiePanel.Name = "familytiePanel";
			//
			// gbties
			//
			resources.ApplyResources(gbties, "gbties");
			gbties.Controls.Add(btnewtie);
			gbties.Controls.Add(cballtieablesims);
			gbties.Controls.Add(cbtietype);
			gbties.Controls.Add(lbties);
			gbties.Controls.Add(btdeletetie);
			gbties.Controls.Add(btaddtie);
			gbties.Controls.Add(llcommitties);
			gbties.FlatStyle = FlatStyle.System;
			gbties.Name = "gbties";
			gbties.TabStop = false;
			//
			// btnewtie
			//
			resources.ApplyResources(btnewtie, "btnewtie");
			btnewtie.Name = "btnewtie";
			btnewtie.Click += new EventHandler(AddSimToTiesClick);
			//
			// cballtieablesims
			//
			resources.ApplyResources(cballtieablesims, "cballtieablesims");
			cballtieablesims.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cballtieablesims.Name = "cballtieablesims";
			cballtieablesims.SelectedIndexChanged += new EventHandler(
				AllTieableSimsIndexChanged
			);
			//
			// cbtietype
			//
			cbtietype.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			resources.ApplyResources(cbtietype, "cbtietype");
			cbtietype.Name = "cbtietype";
			//
			// lbties
			//
			resources.ApplyResources(lbties, "lbties");
			lbties.Name = "lbties";
			lbties.SelectedIndexChanged += new EventHandler(
				TieIndexChanged
			);
			//
			// btdeletetie
			//
			resources.ApplyResources(btdeletetie, "btdeletetie");
			btdeletetie.Name = "btdeletetie";
			btdeletetie.Click += new EventHandler(DeleteTieClick);
			//
			// btaddtie
			//
			resources.ApplyResources(btaddtie, "btaddtie");
			btaddtie.Name = "btaddtie";
			btaddtie.Click += new EventHandler(AddTieClick);
			//
			// llcommitties
			//
			resources.ApplyResources(llcommitties, "llcommitties");
			llcommitties.Name = "llcommitties";
			llcommitties.TabStop = true;
			llcommitties.UseCompatibleTextRendering = true;
			llcommitties.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					CommitSimTieClicked
				);
			//
			// cbtiesims
			//
			resources.ApplyResources(cbtiesims, "cbtiesims");
			cbtiesims.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbtiesims.Name = "cbtiesims";
			cbtiesims.SelectedIndexChanged += new EventHandler(
				FamilyTieSimIndexChanged
			);
			//
			// label64
			//
			resources.ApplyResources(label64, "label64");
			label64.Name = "label64";
			//
			// panel8
			//
			resources.ApplyResources(panel8, "panel8");
			//this.panel8.CanCommit = true;
			panel8.Name = "panel8";
			//this.panel8.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CommitTieClick);
			//
			// tabPage1
			//
			tabPage1.Controls.Add(famiPanel);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			//
			// famiPanel
			//
			resources.ApplyResources(famiPanel, "famiPanel");
			famiPanel.BackColor = System.Drawing.Color.Transparent;
			//this.famiPanel.BackgroundImageLocation = new System.Drawing.Point(744, 24);
			//this.famiPanel.BackgroundImageZoomToFit = true;
			famiPanel.Controls.Add(tbbmoney);
			famiPanel.Controls.Add(label16);
			famiPanel.Controls.Add(tbblot);
			famiPanel.Controls.Add(label14);
			famiPanel.Controls.Add(gbCastaway);
			famiPanel.Controls.Add(tbvac);
			famiPanel.Controls.Add(label7);
			famiPanel.Controls.Add(tbsubhood);
			famiPanel.Controls.Add(label89);
			famiPanel.Controls.Add(groupBox4);
			famiPanel.Controls.Add(tbalbum);
			famiPanel.Controls.Add(label93);
			famiPanel.Controls.Add(tblotinst);
			famiPanel.Controls.Add(llFamiDeleteSim);
			famiPanel.Controls.Add(llFamiAddSim);
			famiPanel.Controls.Add(btOpenHistory);
			famiPanel.Controls.Add(pbImage);
			famiPanel.Controls.Add(cbsims);
			famiPanel.Controls.Add(lbmembers);
			famiPanel.Controls.Add(tbname);
			famiPanel.Controls.Add(label6);
			famiPanel.Controls.Add(tbfamily);
			famiPanel.Controls.Add(tbmoney);
			famiPanel.Controls.Add(lbnotiss);
			famiPanel.Controls.Add(label5);
			famiPanel.Controls.Add(label4);
			famiPanel.Controls.Add(label3);
			famiPanel.Controls.Add(panel4);
			famiPanel.Controls.Add(label15);
			//this.famiPanel.EndColour = System.Drawing.SystemColors.Control;
			//this.famiPanel.MiddleColour = System.Drawing.SystemColors.Control;
			famiPanel.Name = "famiPanel";
			//this.famiPanel.StartColour = System.Drawing.SystemColors.Control;
			//
			// tbbmoney
			//
			resources.ApplyResources(tbbmoney, "tbbmoney");
			tbbmoney.Name = "tbbmoney";
			tbbmoney.TextChanged += new EventHandler(ChangedBMoney);
			//
			// label16
			//
			resources.ApplyResources(label16, "label16");
			label16.BackColor = System.Drawing.Color.Transparent;
			label16.Name = "label16";
			//
			// tbblot
			//
			resources.ApplyResources(tbblot, "tbblot");
			tbblot.Name = "tbblot";
			//
			// label14
			//
			resources.ApplyResources(label14, "label14");
			label14.BackColor = System.Drawing.Color.Transparent;
			label14.Name = "label14";
			//
			// gbCastaway
			//
			resources.ApplyResources(gbCastaway, "gbCastaway");
			gbCastaway.BackColor = System.Drawing.Color.Transparent;
			gbCastaway.Controls.Add(tbcaunk);
			gbCastaway.Controls.Add(label13);
			gbCastaway.Controls.Add(tbcares);
			gbCastaway.Controls.Add(label11);
			gbCastaway.Controls.Add(tbcafood1);
			gbCastaway.Controls.Add(label10);
			gbCastaway.Name = "gbCastaway";
			gbCastaway.TabStop = false;
			//
			// tbcaunk
			//
			resources.ApplyResources(tbcaunk, "tbcaunk");
			tbcaunk.Name = "tbcaunk";
			tbcaunk.TextChanged += new EventHandler(ChangedBMoney);
			//
			// label13
			//
			resources.ApplyResources(label13, "label13");
			label13.Name = "label13";
			//
			// tbcares
			//
			resources.ApplyResources(tbcares, "tbcares");
			tbcares.Name = "tbcares";
			//
			// label11
			//
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			//
			// tbcafood1
			//
			resources.ApplyResources(tbcafood1, "tbcafood1");
			tbcafood1.Name = "tbcafood1";
			tbcafood1.TextChanged += new EventHandler(ChangedMoney);
			//
			// label10
			//
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			//
			// tbvac
			//
			resources.ApplyResources(tbvac, "tbvac");
			tbvac.Name = "tbvac";
			//
			// label7
			//
			resources.ApplyResources(label7, "label7");
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Name = "label7";
			//
			// tbsubhood
			//
			resources.ApplyResources(tbsubhood, "tbsubhood");
			tbsubhood.Name = "tbsubhood";
			//
			// label89
			//
			resources.ApplyResources(label89, "label89");
			label89.BackColor = System.Drawing.Color.Transparent;
			label89.Name = "label89";
			//
			// groupBox4
			//
			resources.ApplyResources(groupBox4, "groupBox4");
			groupBox4.BackColor = System.Drawing.Color.Transparent;
			groupBox4.Controls.Add(cbcomputer);
			groupBox4.Controls.Add(cblot);
			groupBox4.Controls.Add(cbbaby);
			groupBox4.Controls.Add(cbphone);
			groupBox4.Controls.Add(tbflag);
			groupBox4.Name = "groupBox4";
			groupBox4.TabStop = false;
			//
			// cbcomputer
			//
			resources.ApplyResources(cbcomputer, "cbcomputer");
			cbcomputer.Name = "cbcomputer";
			cbcomputer.CheckedChanged += new EventHandler(ChangeFlags);
			//
			// cblot
			//
			resources.ApplyResources(cblot, "cblot");
			cblot.Name = "cblot";
			cblot.CheckedChanged += new EventHandler(ChangeFlags);
			//
			// cbbaby
			//
			resources.ApplyResources(cbbaby, "cbbaby");
			cbbaby.Name = "cbbaby";
			cbbaby.CheckedChanged += new EventHandler(ChangeFlags);
			//
			// cbphone
			//
			resources.ApplyResources(cbphone, "cbphone");
			cbphone.Name = "cbphone";
			cbphone.CheckedChanged += new EventHandler(ChangeFlags);
			//
			// tbflag
			//
			resources.ApplyResources(tbflag, "tbflag");
			tbflag.Name = "tbflag";
			tbflag.TextChanged += new EventHandler(FlagChanged);
			//
			// tbalbum
			//
			resources.ApplyResources(tbalbum, "tbalbum");
			tbalbum.Name = "tbalbum";
			//
			// label93
			//
			resources.ApplyResources(label93, "label93");
			label93.BackColor = System.Drawing.Color.Transparent;
			label93.Name = "label93";
			//
			// tblotinst
			//
			resources.ApplyResources(tblotinst, "tblotinst");
			tblotinst.Name = "tblotinst";
			//
			// llFamiDeleteSim
			//
			resources.ApplyResources(llFamiDeleteSim, "llFamiDeleteSim");
			llFamiDeleteSim.Name = "llFamiDeleteSim";
			llFamiDeleteSim.Click += new EventHandler(
				FamiDeleteSimClick
			);
			//
			// llFamiAddSim
			//
			resources.ApplyResources(llFamiAddSim, "llFamiAddSim");
			llFamiAddSim.Name = "llFamiAddSim";
			llFamiAddSim.Click += new EventHandler(FamiSimAddClick);
			//
			// btOpenHistory
			//
			resources.ApplyResources(btOpenHistory, "btOpenHistory");
			btOpenHistory.Name = "btOpenHistory";
			btOpenHistory.Click += new EventHandler(FamiOpenHistory);
			//
			// pbImage
			//
			pbImage.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(pbImage, "pbImage");
			pbImage.Name = "pbImage";
			pbImage.TabStop = false;
			//
			// cbsims
			//
			cbsims.DropDownStyle = ComboBoxStyle.DropDownList;
			resources.ApplyResources(cbsims, "cbsims");
			cbsims.Name = "cbsims";
			cbsims.SelectedIndexChanged += new EventHandler(
				SimSelectionChange
			);
			//
			// lbmembers
			//
			resources.ApplyResources(lbmembers, "lbmembers");
			lbmembers.Name = "lbmembers";
			lbmembers.SelectedIndexChanged += new EventHandler(
				FamiMemberSelectionClick
			);
			lbmembers.DoubleClick += new EventHandler(
				lbmembers_DoubleClick
			);
			//
			// tbname
			//
			resources.ApplyResources(tbname, "tbname");
			tbname.Name = "tbname";
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Name = "label6";
			//
			// tbfamily
			//
			resources.ApplyResources(tbfamily, "tbfamily");
			tbfamily.Name = "tbfamily";
			//
			// tbmoney
			//
			resources.ApplyResources(tbmoney, "tbmoney");
			tbmoney.Name = "tbmoney";
			tbmoney.TextChanged += new EventHandler(ChangedMoney);
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.Name = "label5";
			//
			// lbnotiss
			//
			resources.ApplyResources(lbnotiss, "lbnotiss");
			lbnotiss.BackColor = System.Drawing.Color.Transparent;
			lbnotiss.Name = "lbnotiss";
			lbnotiss.ForeColor = System.Drawing.Color.Gray;
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Name = "label4";
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Name = "label3";
			//
			// panel4
			//
			resources.ApplyResources(panel4, "panel4");
			//this.panel4.CanCommit = true;
			panel4.Name = "panel4";
			//this.panel4.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CommitFamiClick);
			//
			// label15
			//
			resources.ApplyResources(label15, "label15");
			label15.BackColor = System.Drawing.Color.Transparent;
			label15.Name = "label15";
			label15.Click += new EventHandler(label15_Click);
			//
			// tabPage3
			//
			tabPage3.Controls.Add(objdPanel);
			tabPage3.Controls.Add(realPanel);
			tabPage3.Controls.Add(JpegPanel);
			tabPage3.Controls.Add(xmlPanel);
			resources.ApplyResources(tabPage3, "tabPage3");
			tabPage3.Name = "tabPage3";
			//
			// realPanel
			//
			realPanel.Controls.Add(label91);
			realPanel.Controls.Add(cbfamtype);
			realPanel.Controls.Add(gbrelation);
			realPanel.Controls.Add(tblongterm);
			realPanel.Controls.Add(tbshortterm);
			realPanel.Controls.Add(label57);
			realPanel.Controls.Add(label58);
			realPanel.Controls.Add(panel7);
			resources.ApplyResources(realPanel, "realPanel");
			realPanel.Name = "realPanel";
			//
			// label91
			//
			resources.ApplyResources(label91, "label91");
			label91.BackColor = System.Drawing.Color.Transparent;
			label91.Name = "label91";
			//
			// cbfamtype
			//
			cbfamtype.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			resources.ApplyResources(cbfamtype, "cbfamtype");
			cbfamtype.Name = "cbfamtype";
			//
			// gbrelation
			//
			gbrelation.BackColor = System.Drawing.Color.Transparent;
			gbrelation.Controls.Add(cbBFF);
			gbrelation.Controls.Add(cbsecret);
			gbrelation.Controls.Add(cbplatonic);
			gbrelation.Controls.Add(cbbest);
			gbrelation.Controls.Add(cbfamily);
			gbrelation.Controls.Add(cbmarried);
			gbrelation.Controls.Add(cbengaged);
			gbrelation.Controls.Add(cbsteady);
			gbrelation.Controls.Add(cblove);
			gbrelation.Controls.Add(cbcrush);
			gbrelation.Controls.Add(cbbuddie);
			gbrelation.Controls.Add(cbfriend);
			gbrelation.Controls.Add(cbenemy);
			resources.ApplyResources(gbrelation, "gbrelation");
			gbrelation.Name = "gbrelation";
			gbrelation.TabStop = false;
			//
			// cbBFF
			//
			resources.ApplyResources(cbBFF, "cbBFF");
			cbBFF.Name = "cbBFF";
			//
			// cbsecret
			//
			resources.ApplyResources(cbsecret, "cbsecret");
			cbsecret.Name = "cbsecret";
			//
			// cbplatonic
			//
			resources.ApplyResources(cbplatonic, "cbplatonic");
			cbplatonic.Name = "cbplatonic";
			//
			// cbbest
			//
			resources.ApplyResources(cbbest, "cbbest");
			cbbest.Name = "cbbest";
			//
			// cbfamily
			//
			resources.ApplyResources(cbfamily, "cbfamily");
			cbfamily.Name = "cbfamily";
			//
			// cbmarried
			//
			resources.ApplyResources(cbmarried, "cbmarried");
			cbmarried.Name = "cbmarried";
			//
			// cbengaged
			//
			resources.ApplyResources(cbengaged, "cbengaged");
			cbengaged.Name = "cbengaged";
			//
			// cbsteady
			//
			resources.ApplyResources(cbsteady, "cbsteady");
			cbsteady.Name = "cbsteady";
			//
			// cblove
			//
			resources.ApplyResources(cblove, "cblove");
			cblove.Name = "cblove";
			//
			// cbcrush
			//
			resources.ApplyResources(cbcrush, "cbcrush");
			cbcrush.Name = "cbcrush";
			//
			// cbbuddie
			//
			resources.ApplyResources(cbbuddie, "cbbuddie");
			cbbuddie.Name = "cbbuddie";
			//
			// cbfriend
			//
			resources.ApplyResources(cbfriend, "cbfriend");
			cbfriend.Name = "cbfriend";
			//
			// cbenemy
			//
			resources.ApplyResources(cbenemy, "cbenemy");
			cbenemy.Name = "cbenemy";
			//
			// tblongterm
			//
			resources.ApplyResources(tblongterm, "tblongterm");
			tblongterm.Name = "tblongterm";
			//
			// tbshortterm
			//
			resources.ApplyResources(tbshortterm, "tbshortterm");
			tbshortterm.Name = "tbshortterm";
			//
			// label57
			//
			resources.ApplyResources(label57, "label57");
			label57.BackColor = System.Drawing.Color.Transparent;
			label57.Name = "label57";
			//
			// label58
			//
			resources.ApplyResources(label58, "label58");
			label58.BackColor = System.Drawing.Color.Transparent;
			label58.Name = "label58";
			//
			// panel7
			//
			resources.ApplyResources(panel7, "panel7");
			//this.panel7.CanCommit = true;
			panel7.Name = "panel7";
			//this.panel7.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.RelationshipFileCommit);
			//
			// Elements
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(tabControl1);
			Name = "Elements";
			JpegPanel.ResumeLayout(false);
			JpegPanel.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			xmlPanel.ResumeLayout(false);
			objdPanel.ResumeLayout(false);
			objdPanel.PerformLayout();
			gbelements.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage4.ResumeLayout(false);
			familytiePanel.ResumeLayout(false);
			familytiePanel.PerformLayout();
			gbties.ResumeLayout(false);
			gbties.PerformLayout();
			tabPage1.ResumeLayout(false);
			famiPanel.ResumeLayout(false);
			famiPanel.PerformLayout();
			gbCastaway.ResumeLayout(false);
			gbCastaway.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
			tabPage3.ResumeLayout(false);
			realPanel.ResumeLayout(false);
			realPanel.PerformLayout();
			gbrelation.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		private void CommitFamiClick(object sender, EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					Cursor = Cursors.WaitCursor;
					Fami.Fami fami = (Fami.Fami)wrapper;
					fami.Money = Convert.ToInt32(tbmoney.Text);
					fami.Friends = Convert.ToUInt32(tbfamily.Text);
					fami.Flags = (FamiFlags)Convert.ToUInt32(tbflag.Text, 16);
					fami.AlbumGUID = Convert.ToUInt32(tbalbum.Text, 16);
					fami.SubHoodNumber = Convert.ToUInt32(tbsubhood.Text, 16);
					fami.VacationLotInstance = Helper.StringToUInt32(
						tbvac.Text,
						fami.VacationLotInstance,
						16
					);
					fami.CurrentlyOnLotInstance = Helper.StringToUInt32(
						tbblot.Text,
						fami.CurrentlyOnLotInstance,
						16
					);
					fami.BusinessMoney = Helper.StringToInt32(
						tbbmoney.Text,
						fami.BusinessMoney,
						10
					);

					fami.CastAwayFood = Helper.StringToInt32(
						tbcafood1.Text,
						fami.CastAwayFood,
						10
					);
					fami.CastAwayResources = Helper.StringToInt32(
						tbcares.Text,
						fami.CastAwayResources,
						10
					);
					fami.CastAwayFoodDecay = Helper.StringToInt32(
						tbcaunk.Text,
						fami.CastAwayFoodDecay,
						16
					);

					uint[] members = new uint[lbmembers.Items.Count];
					fami.Members.Clear();
					foreach (Interfaces.IAlias member in lbmembers.Items)
					{
						fami.Members.Add(member.Id);
						Wrapper.SDesc sdesc = fami.GetDescriptionFile(member.Id);
						sdesc.FamilyInstance = (ushort)fami.FileDescriptor.Instance;
						sdesc.SynchronizeUserData();
					}
					fami.LotInstance = tblotinst.Text != "Sim Bin" ? Convert.ToUInt32(tblotinst.Text, 16) : 0;
					//name was changed
					if (tbname.Text != fami.Name)
					{
						fami.Name = tbname.Text;
					}

					wrapper.SynchronizeUserData();
					MessageBox.Show(Localization.Manager.GetString("commited"));
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("cantcommitfamily"),
						ex
					);
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void lbmembers_DoubleClick(object sender, EventArgs e)
		{
			if (lbmembers.SelectedIndex >= 0)
			{
				Fami.Fami fami = (Fami.Fami)wrapper;
				Data.Alias a = (Data.Alias)lbmembers.SelectedItem;
				Wrapper.SDesc sdsc = fami.GetDescriptionFile(a.Id);
				if (sdsc == null)
				{
					return;
				}

				Interfaces.Files.IPackedFileDescriptor pfd = sdsc.Package.NewDescriptor(
					FileTypes.SDSC,
					sdsc.FileDescriptor.SubType,
					sdsc.FileDescriptor.Group,
					sdsc.FileDescriptor.Instance
				);
				pfd = sdsc.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, sdsc.Package);
			}
		}

		private void CommitXmlClick(object sender, EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					Xml.Xml xml = (Xml.Xml)wrapper;

					xml.Text = "";
					foreach (string clit in rtb.Lines)
					{
						xml.Text += clit + "\r\n"; // RichTextBox converts line breaks to seperate arrays, we need to put the line breaks back (CJH)
					}
					// xml.Text = rtb.Text;
					wrapper.SynchronizeUserData();
					MessageBox.Show(Localization.Manager.GetString("commited"));
				}
				catch (Exception) { }
			}
		}

		bool warnim = false;

		private void FamiSimAddClick(object sender, EventArgs e)
		{
			if (cbsims.SelectedIndex >= 0)
			{
				if (wrapper.FileDescriptor.Instance == 0 && !warnim)
				{
					warnim = true;
					if (
						Message.Show(
							"This family should have no-one in it, adding sims here may cause problems in your game later.\r\n\r\n"
								+ "The game sees sims with a family value of 0 as not being in a family at all so it will never move the sim out."
								+ " If the sim is moved to another family the sim will be in two families at once.",
							"Not A Good Idea!",
							MessageBoxButtons.OKCancel
						) == DialogResult.Cancel
					)
					{
						return;
					}
				}
				if (!lbmembers.Items.Contains(cbsims.Items[cbsims.SelectedIndex]))
				{
					lbmembers.Items.Add(cbsims.Items[cbsims.SelectedIndex]);
				}
			}
		}

		private void SimSelectionChange(object sender, EventArgs e)
		{
			llFamiAddSim.Enabled =
				(((ComboBox)sender).SelectedIndex >= 0)
				&& (((ComboBox)sender).Items.Count > 0)
			;
		}

		private void FamiMemberSelectionClick(object sender, EventArgs e)
		{
			llFamiDeleteSim.Enabled = ((ListBox)sender).SelectedIndex >= 0;
			llFamiDeleteSim.Invalidate();
			llFamiDeleteSim.Update();
		}

		private void FamiDeleteSimClick(object sender, EventArgs e)
		{
			if (lbmembers.SelectedIndex >= 0)
			{
				lbmembers.Items.Remove(lbmembers.Items[lbmembers.SelectedIndex]);
			}
		}

		/* I don't fink this is used
		private void FileNameMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (((Label)sender).Tag != null)
					Clipboard.SetDataObject(((Label)sender).Tag, true);
			}
		}
		*/
		private void FamiOpenHistory(object sender, EventArgs e)
		{
			try
			{
				Fami.Fami fami = (Fami.Fami)wrapper;
				Interfaces.Files.IPackedFileDescriptor pfd = fami.Package.NewDescriptor(
					FileTypes.FAMH,
					fami.FileDescriptor.SubType,
					fami.FileDescriptor.Group,
					fami.FileDescriptor.Instance
				);
				pfd = fami.Package.FindFile(pfd);
				RemoteControl.OpenPackedFile(pfd, fami.Package);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		/* What ProgressBar?
		#region FAMi ProgressBar Handling
		internal void ProgressBarMaximize(Control parent)
		{
			foreach (Control c in parent.Controls)
			{
				if (c.GetType() == typeof(ProgressBar))
				{
					ProgressBar pb = ((ProgressBar)c);
					if (pb.Maximum < 1000) pb.Value = pb.Maximum;
					else pb.Value = pb.Maximum - 1;
				}
			}
			ProgressBarUpdate(parent);
		}

		internal void ProgressBarUpdate(Control parent)
		{
			foreach (Control c in parent.Controls)
			{
				if (c.GetType().Name == "ProgressBar") ProgressBarUpdate((ProgressBar)c, null);
			}
		}

		private void ProgressBarUpdate(ProgressBar pb, System.Windows.Forms.MouseEventArgs e)
		{
			if (e != null) pb.Value = Math.Max(pb.Minimum, Math.Min(pb.Maximum, Convert.ToInt32(Math.Round(((double)e.X / (double)pb.Width) * pb.Maximum))));
			foreach (Control c in pb.Parent.Controls)
			{
				if (c.GetType().Name == "TextBox")
				{
					TextBox tb = (TextBox)c;
					if (tb.Name == pb.Name.Replace("pb", "tb"))
					{
						if (pb.Tag != null) c.Text = (pb.Value - (int)pb.Tag).ToString();
						else c.Text = pb.Value.ToString();
					}
				}
			}
		}

		private void ProgressBarMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ProgressBar pb = (ProgressBar)sender;
			//pb.Tag = null;
			ProgressBarUpdate(pb, e);
		}

		private void ProgressBarMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ProgressBar pb = (ProgressBar)sender;
			//pb.Tag = true;
			ProgressBarUpdate(pb, e);
		}

		private void ProgressBarMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ProgressBar pb = (ProgressBar)sender;
			if (e.Button == MouseButtons.Left)
			{
				ProgressBarUpdate(pb, e);
			}

		}

		protected void GetAssignedProgressbar(TextBox tb)
		{
			foreach (Control c in tb.Parent.Controls)
			{
				if (c.GetType().Name == "ProgressBar")
				{
					ProgressBar pb = (ProgressBar)c;
					if (tb.Name == pb.Name.Replace("pb", "tb"))
					{
						tb.Tag = pb;
						break;
					}
				}
			}
		}

		private void ProgressBarTextChanged(object sender, System.EventArgs e)
		{
			TextBox tb = (TextBox)sender;
			ProgressBar pb = null;
			if (tb.Tag == null) GetAssignedProgressbar(tb);
			if (tb.Tag == null) return;

			pb = (ProgressBar)tb.Tag;
			try
			{
				if (pb.Tag != null) pb.Value = Math.Max(0, Math.Min(pb.Maximum, Convert.ToInt16(tb.Text) + (int)pb.Tag));
				else pb.Value = Math.Max(0, Math.Min(pb.Maximum, Convert.ToInt16(tb.Text)));
			}
			catch (Exception) { }
		}

		private void ProgressBarTextLeave(object sender, System.EventArgs e)
		{
			if (sender.GetType() != typeof(TextBox)) return;
			TextBox tb = (TextBox)sender;
			ProgressBar pb = null;
			if (tb.Tag == null) GetAssignedProgressbar(tb);
			if (tb.Tag == null) return;

			pb = (ProgressBar)tb.Tag;
			try
			{
				if (pb.Tag != null) tb.Text = (pb.Value - (int)pb.Tag).ToString();
				else tb.Text = pb.Value.ToString();
			}
			catch (Exception) { }
		}
		#endregion
		*/
		#region Family Ties
		private void FamilyTieSimIndexChanged(object sender, EventArgs e)
		{
			btdeletetie.Enabled = false;
			if (cbtiesims.SelectedIndex < 0)
			{
				return;
			}

			FamilyTieSim sim = (FamilyTieSim)cbtiesims.Items[cbtiesims.SelectedIndex];

			lbties.Items.Clear();
			foreach (FamilyTieItem tie in sim.Ties)
			{
				lbties.Items.Add(tie);
			}
		}

		private void AllTieableSimsIndexChanged(object sender, EventArgs e)
		{
			btaddtie.Enabled = false;
			btnewtie.Enabled = false;
			if (cballtieablesims.SelectedIndex < 0)
			{
				return;
			}

			btnewtie.Enabled = true;
			if (cbtiesims.SelectedIndex < 0)
			{
				return;
			}

			btaddtie.Enabled = true;
		}

		private void DeleteTieClick(object sender, EventArgs e)
		{
			btaddtie.Enabled = false;
			if (lbties.SelectedIndex < 0)
			{
				return;
			}

			lbties.Items.Remove(lbties.Items[lbties.SelectedIndex]);
		}

		private void AddTieClick(object sender, EventArgs e)
		{
			if (cballtieablesims.SelectedIndex < 0)
			{
				return;
			}

			if (cbtietype.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				Wrapper.FamilyTies famt = (Wrapper.FamilyTies)wrapper;
				Data.MetaData.FamilyTieTypes ftt = (Data.LocalizedFamilyTieTypes)
					cbtietype.Items[cbtietype.SelectedIndex];
				FamilyTieSim fts = (FamilyTieSim)
					cballtieablesims.Items[cballtieablesims.SelectedIndex];
				FamilyTieItem tie = new FamilyTieItem(ftt, fts.Instance, famt);
				lbties.Items.Add(tie);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(
					Localization.Manager.GetString("cantaddtie"),
					ex
				);
			}
		}

		private void CommitSimTieClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (cbtiesims.SelectedIndex < 0)
			{
				return;
			}

			if (wrapper != null)
			{
				try
				{
					((FamilyTieSim)
						cbtiesims.Items[cbtiesims.SelectedIndex]).Ties = lbties.Items.Cast<FamilyTieItem>().ToList();
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("cantcommitfamt"),
						ex
					);
				}
			}
		}

		private void TieIndexChanged(object sender, EventArgs e)
		{
			btdeletetie.Enabled = false;
			if (lbties.SelectedIndex < 0)
			{
				return;
			}

			btdeletetie.Enabled = true;
		}

		private void CommitTieClick(object sender, EventArgs e)
		{
			CommitSimTieClicked(null, null);
			if (wrapper != null)
			{
				try
				{
					Wrapper.FamilyTies famt =
						(Wrapper.FamilyTies)wrapper;

					FamilyTieSim[] sims = new FamilyTieSim[cbtiesims.Items.Count];
					for (int i = 0; i < sims.Length; i++)
					{
						sims[i] = (FamilyTieSim)cbtiesims.Items[i];
					}
					famt.Sims = sims;

					famt.SynchronizeUserData();
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("cantcommittie"),
						ex
					);
				}
			}
		}

		private void AddSimToTiesClick(object sender, EventArgs e)
		{
			if (cballtieablesims.SelectedIndex < 0)
			{
				return;
			}

			FamilyTieSim sim = (FamilyTieSim)
				cballtieablesims.Items[cballtieablesims.SelectedIndex];
			sim.Ties = new List<FamilyTieItem>();

			//check if the tie exists
			bool exists = false;
			foreach (FamilyTieSim exsim in cbtiesims.Items)
			{
				if (exsim.Instance == sim.Instance)
				{
					exists = true;
					break;
				}
			} //foreach

			if (!exists)
			{
				cbtiesims.Items.Add(sim);
			}
		}
		#endregion

		#region Relationships

		private void RelationshipFileCommit(object sender, EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					Wrapper.SRel srel = (Wrapper.SRel)wrapper;
					srel.Shortterm = Convert.ToInt32(tbshortterm.Text);
					srel.Longterm = Convert.ToInt32(tblongterm.Text);

					List<CheckBox> ltcb = new List<CheckBox>(
						new CheckBox[]
						{
							cbcrush,
							cblove,
							cbengaged,
							cbmarried,
							cbfriend,
							cbbuddie,
							cbsteady,
							cbenemy,
							null,
							null,
							null,
							null,
							null,
							null,
							cbfamily,
							cbbest,
							cbBFF,
							null,
							cbplatonic,
							cbsecret,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
							null,
						}
					);

					Boolset bs1 = srel.RelationState.Value;
					Boolset bs2 = srel.RelationState2.Value;
					for (int i = 0; i < ltcb.Count; i++)
					{
						if (ltcb[i] != null)
						{
							ltcb[i].Checked = (i < 16 ? bs1 : bs2)[i & 0x0f];
						}
					}

					srel.RelationState.Value = bs1;
					srel.RelationState2.Value = bs2;

					if (cbfamtype.SelectedIndex > 0)
					{
						srel.FamilyRelation = (Data.LocalizedRelationshipTypes)
							cbfamtype.Items[cbfamtype.SelectedIndex];
					}

					wrapper.SynchronizeUserData();
					MessageBox.Show(Localization.Manager.GetString("commited"));
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						"Unable to Save Relationship Information!",
						ex
					);
				}
			}
		}
		#endregion

		private void CommitObjdClicked(object sender, EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					Cursor = Cursors.WaitCursor;
					Wrapper.Objd objd = (Wrapper.Objd)wrapper;

					foreach (Control c in pnelements.Controls)
					{
						if (c.GetType() == typeof(TextBox))
						{
							TextBox tb = (TextBox)c;
							if (tb.Tag != null)
							{
								string name = (string)tb.Tag;
								Wrapper.ObjdItem item = (Wrapper.ObjdItem)
									objd.Attributes[name];
								item.val = Convert.ToUInt16(tb.Text, 16);
								objd.Attributes[name] = item;
							}
						}
					}

					objd.Type = (ushort)Helper.HexStringToUInt(tblottype.Text);
					objd.Guid = Helper.HexStringToUInt(tbsimid.Text);
					objd.FileName = tbsimname.Text;
					objd.OriginalGuid =
						Helper.HexStringToUInt(tborgguid.Text);
					objd.ProxyGuid = Helper.HexStringToUInt(tbproxguid.Text);

					objd.SynchronizeUserData();
					MessageBox.Show(Localization.Manager.GetString("commited"));
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(
						Localization.Manager.GetString("cantcommitobjd"),
						ex
					);
				}
			}
		}

		/* I don't fink this is used
		internal bool simnamechanged;
		private void SimNameChanged(object sender, System.EventArgs e)
		{
			simnamechanged = true;
		}
		*/
		private void FlagChanged(object sender, EventArgs e)
		{
			if (tbflag.Tag != null)
			{
				return;
			}

			tbflag.Tag = true;
			try
			{
				FamiFlags flag = (FamiFlags)Convert.ToUInt32(tbflag.Text, 16);

				cbphone.Checked = flag.HasFlag(FamiFlags.HasPhone);
				cbcomputer.Checked = flag.HasFlag(FamiFlags.HasComputer);
				cbbaby.Checked = flag.HasFlag(FamiFlags.HasBaby);
				cblot.Checked = flag.HasFlag(FamiFlags.NewLot);
			}
			catch (Exception) { }
			finally
			{
				tbflag.Tag = null;
			}
		}

		private void ChangeFlags(object sender, EventArgs e)
		{
			if (tbflag.Tag != null)
			{
				return;
			}

			tbflag.Tag = true;
			try
			{
				FamiFlags flag = (FamiFlags)Convert.ToUInt32(tbflag.Text, 16);
				if (cbphone.Checked)
				{
					flag |= FamiFlags.HasPhone;
				}
				else
				{
					flag &= ~FamiFlags.HasPhone;
				}
				if (cbcomputer.Checked)
				{
					flag |= FamiFlags.HasComputer;
				}
				else
				{
					flag &= ~FamiFlags.HasComputer;
				}
				if (cbbaby.Checked)
				{
					flag |= FamiFlags.HasBaby;
				}
				else
				{
					flag &= ~FamiFlags.HasBaby;
				}
				if (cblot.Checked)
				{
					flag |= FamiFlags.NewLot;
				}
				else
				{
					flag &= ~FamiFlags.NewLot;
				}
				tbflag.Text = "0x" + Helper.HexString((uint)flag);
			}
			catch (Exception) { }
			finally
			{
				tbflag.Tag = null;
			}
		}

		internal Interfaces.Plugin.IFileWrapper picwrapper;

		private void btPicExport_Click(object sender, EventArgs e)
		{
			Picture.Picture wrp =
				(Picture.Picture)picwrapper;
			SaveFileDialog sfd = new SaveFileDialog
			{
				Filter = "Image (*.png) | *.png"
			};

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					wrp.Image.Save(
						sfd.FileName,
						System.Drawing.Imaging.ImageFormat.Png
					);
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
			}
		}

		private void label15_Click(object sender, EventArgs e)
		{
			try
			{
				Fami.Fami fami = (Fami.Fami)wrapper;
				if (fami.LotInstance == 0)
				{
					return;
				}

				Interfaces.Files.IPackedFileDescriptor pfd = fami.Package.NewDescriptor(
					FileTypes.LTXT,
					0,
					0xFFFFFFFF,
					fami.LotInstance
				);
				pfd = fami.Package.FindFile(pfd);
				// if (pfd != null)
				RemoteControl.OpenPackedFile(pfd, fami.Package);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
			}
		}

		bool intern = false;

		private void ChangedMoney(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}
			intern = true;
			Fami.Fami fami = (Fami.Fami)wrapper;
			TextBox tb = (TextBox)sender;
			if (tb == tbmoney)
			{
				fami.Money = Helper.StringToInt32(tb.Text, fami.Money, 10);
			}
			else if (tb == tbcafood1)
			{
				fami.CastAwayFood = Helper.StringToInt32(tb.Text, fami.CastAwayFood, 10);
			}

			intern = false;
		}

		private void ChangedBMoney(object sender, EventArgs e)
		{
			if (intern)
			{
				return;
			}

			intern = true;
			Fami.Fami fami = (Fami.Fami)wrapper;
			TextBox tb = (TextBox)sender;
			if (tb == tbbmoney)
			{
				fami.BusinessMoney = Helper.StringToInt32(tb.Text, fami.BusinessMoney, 10);
			}
			else if (tb == tbcaunk)
			{
				fami.CastAwayFoodDecay = Helper.StringToInt32(tb.Text, fami.CastAwayFoodDecay, 10);
			}

			intern = false;
		}
	}
}
