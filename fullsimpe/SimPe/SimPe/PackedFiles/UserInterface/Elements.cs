/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
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
using System.Collections.Generic;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper.Supporting;

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
				this.tbname.Font = new System.Drawing.Font(
					this.tbname.Font.FontFamily,
					12F
				);
				this.cbsims.Font = new System.Drawing.Font(
					this.cbsims.Font.FontFamily,
					12F
				);
				this.lbmembers.Font = new System.Drawing.Font("Verdana", 12F);
				this.lbmembers.Location = new System.Drawing.Point(16, 200);
				this.lbmembers.Size = new System.Drawing.Size(
					356,
					this.lbmembers.Size.Height
				);
				this.pbImage.Size = new System.Drawing.Size(168, 168);
				this.pbImage.Location = new System.Drawing.Point(2, 26);
				this.rtb.Font = new System.Drawing.Font("Verdana", 12F);
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(Elements));
			this.JpegPanel = new Panel();
			this.panel2 = new Panel();
			this.btPicExport = new Button();
			this.pb = new PictureBox();
			this.xmlPanel = new Panel();
			this.rtb = new RichTextBox();
			this.panel3 = new Panel();
			this.objdPanel = new Panel();
			this.cbupdate = new CheckBox();
			this.label63 = new Label();
			this.tbproxguid = new TextBox();
			this.label97 = new Label();
			this.tborgguid = new TextBox();
			this.lbtypename = new Label();
			this.gbelements = new GroupBox();
			this.pnelements = new Panel();
			this.tblottype = new TextBox();
			this.label65 = new Label();
			this.tbsimname = new TextBox();
			this.label9 = new Label();
			this.tbsimid = new TextBox();
			this.label8 = new Label();
			this.panel6 = new Panel();
			this.tabControl1 = new TabControl();
			this.tabPage4 = new TabPage();
			this.familytiePanel = new Panel();
			this.gbties = new GroupBox();
			this.btnewtie = new Button();
			this.cballtieablesims = new ComboBox();
			this.cbtietype = new ComboBox();
			this.lbties = new ListBox();
			this.btdeletetie = new Button();
			this.btaddtie = new Button();
			this.llcommitties = new LinkLabel();
			this.cbtiesims = new ComboBox();
			this.label64 = new Label();
			this.panel8 = new Panel();
			this.tabPage1 = new TabPage();
			this.famiPanel = new Panel();
			this.tbbmoney = new TextBox();
			this.label16 = new Label();
			this.tbblot = new TextBox();
			this.label14 = new Label();
			this.gbCastaway = new GroupBox();
			this.tbcaunk = new TextBox();
			this.label13 = new Label();
			this.tbcares = new TextBox();
			this.label11 = new Label();
			this.tbcafood1 = new TextBox();
			this.label10 = new Label();
			this.tbvac = new TextBox();
			this.label7 = new Label();
			this.tbsubhood = new TextBox();
			this.label89 = new Label();
			this.groupBox4 = new GroupBox();
			this.cbcomputer = new CheckBox();
			this.cblot = new CheckBox();
			this.cbbaby = new CheckBox();
			this.cbphone = new CheckBox();
			this.tbflag = new TextBox();
			this.tbalbum = new TextBox();
			this.label93 = new Label();
			this.tblotinst = new TextBox();
			this.llFamiDeleteSim = new Button();
			this.llFamiAddSim = new Button();
			this.btOpenHistory = new Button();
			this.pbImage = new PictureBox();
			this.cbsims = new ComboBox();
			this.lbmembers = new ListBox();
			this.tbname = new TextBox();
			this.label6 = new Label();
			this.tbfamily = new TextBox();
			this.tbmoney = new TextBox();
			this.label5 = new Label();
			this.lbnotiss = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.panel4 = new Panel();
			this.label15 = new Label();
			this.tabPage3 = new TabPage();
			this.realPanel = new Panel();
			this.label91 = new Label();
			this.cbfamtype = new ComboBox();
			this.gbrelation = new GroupBox();
			this.cbBFF = new CheckBox();
			this.cbsecret = new CheckBox();
			this.cbplatonic = new CheckBox();
			this.cbbest = new CheckBox();
			this.cbfamily = new CheckBox();
			this.cbmarried = new CheckBox();
			this.cbengaged = new CheckBox();
			this.cbsteady = new CheckBox();
			this.cblove = new CheckBox();
			this.cbcrush = new CheckBox();
			this.cbbuddie = new CheckBox();
			this.cbfriend = new CheckBox();
			this.cbenemy = new CheckBox();
			this.tblongterm = new TextBox();
			this.tbshortterm = new TextBox();
			this.label57 = new Label();
			this.label58 = new Label();
			this.panel7 = new Panel();
			this.toolTip1 = new ToolTip(this.components);
			this.JpegPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
			this.xmlPanel.SuspendLayout();
			this.objdPanel.SuspendLayout();
			this.gbelements.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.familytiePanel.SuspendLayout();
			this.gbties.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.famiPanel.SuspendLayout();
			this.gbCastaway.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.realPanel.SuspendLayout();
			this.gbrelation.SuspendLayout();
			this.SuspendLayout();
			//
			// JpegPanel
			//
			this.JpegPanel.BackColor = System.Drawing.Color.Transparent;
			this.JpegPanel.Controls.Add(this.panel2);
			this.JpegPanel.Controls.Add(this.pb);
			//this.JpegPanel.EndColour = System.Drawing.SystemColors.Control;
			resources.ApplyResources(this.JpegPanel, "JpegPanel");
			//this.JpegPanel.MiddleColour = System.Drawing.SystemColors.Control;
			this.JpegPanel.Name = "JpegPanel";
			//this.JpegPanel.StartColour = System.Drawing.SystemColors.Control;
			//
			// panel2
			//
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Controls.Add(this.btPicExport);
			this.panel2.Name = "panel2";
			//
			// btPicExport
			//
			resources.ApplyResources(this.btPicExport, "btPicExport");
			this.btPicExport.BackColor = System.Drawing.SystemColors.Control;
			this.btPicExport.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btPicExport.Name = "btPicExport";
			this.btPicExport.UseVisualStyleBackColor = false;
			this.btPicExport.Click += new EventHandler(this.btPicExport_Click);
			//
			// pb
			//
			resources.ApplyResources(this.pb, "pb");
			this.pb.BackColor = System.Drawing.Color.Transparent;
			this.pb.Name = "pb";
			this.pb.TabStop = false;
			//
			// xmlPanel
			//
			this.xmlPanel.Controls.Add(this.rtb);
			this.xmlPanel.Controls.Add(this.panel3);
			resources.ApplyResources(this.xmlPanel, "xmlPanel");
			this.xmlPanel.Name = "xmlPanel";
			//
			// rtb
			//
			resources.ApplyResources(this.rtb, "rtb");
			this.rtb.Name = "rtb";
			//
			// panel3
			//
			resources.ApplyResources(this.panel3, "panel3");
			//this.panel3.CanCommit = true;
			this.panel3.Name = "panel3";
			//this.panel3.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CommitXmlClick);
			//
			// objdPanel
			//
			this.objdPanel.Controls.Add(this.cbupdate);
			this.objdPanel.Controls.Add(this.label63);
			this.objdPanel.Controls.Add(this.tbproxguid);
			this.objdPanel.Controls.Add(this.label97);
			this.objdPanel.Controls.Add(this.tborgguid);
			this.objdPanel.Controls.Add(this.lbtypename);
			this.objdPanel.Controls.Add(this.gbelements);
			this.objdPanel.Controls.Add(this.tblottype);
			this.objdPanel.Controls.Add(this.label65);
			this.objdPanel.Controls.Add(this.tbsimname);
			this.objdPanel.Controls.Add(this.label9);
			this.objdPanel.Controls.Add(this.tbsimid);
			this.objdPanel.Controls.Add(this.label8);
			this.objdPanel.Controls.Add(this.panel6);
			resources.ApplyResources(this.objdPanel, "objdPanel");
			this.objdPanel.Name = "objdPanel";
			//
			// cbupdate
			//
			this.cbupdate.BackColor = System.Drawing.Color.Transparent;
			this.cbupdate.Checked = true;
			this.cbupdate.CheckState = CheckState.Checked;
			resources.ApplyResources(this.cbupdate, "cbupdate");
			this.cbupdate.Name = "cbupdate";
			this.cbupdate.UseVisualStyleBackColor = false;
			//
			// label63
			//
			resources.ApplyResources(this.label63, "label63");
			this.label63.BackColor = System.Drawing.Color.Transparent;
			this.label63.Name = "label63";
			//
			// tbproxguid
			//
			resources.ApplyResources(this.tbproxguid, "tbproxguid");
			this.tbproxguid.Name = "tbproxguid";
			this.toolTip1.SetToolTip(
				this.tbproxguid,
				resources.GetString("tbproxguid.ToolTip")
			);
			//
			// label97
			//
			resources.ApplyResources(this.label97, "label97");
			this.label97.BackColor = System.Drawing.Color.Transparent;
			this.label97.Name = "label97";
			//
			// tborgguid
			//
			resources.ApplyResources(this.tborgguid, "tborgguid");
			this.tborgguid.Name = "tborgguid";
			this.toolTip1.SetToolTip(
				this.tborgguid,
				resources.GetString("tborgguid.ToolTip")
			);
			//
			// lbtypename
			//
			resources.ApplyResources(this.lbtypename, "lbtypename");
			this.lbtypename.BackColor = System.Drawing.Color.Transparent;
			this.lbtypename.Name = "lbtypename";
			//
			// gbelements
			//
			resources.ApplyResources(this.gbelements, "gbelements");
			this.gbelements.BackColor = System.Drawing.Color.Transparent;
			this.gbelements.Controls.Add(this.pnelements);
			this.gbelements.Name = "gbelements";
			this.gbelements.TabStop = false;
			//
			// pnelements
			//
			resources.ApplyResources(this.pnelements, "pnelements");
			this.pnelements.Name = "pnelements";
			//
			// tblottype
			//
			resources.ApplyResources(this.tblottype, "tblottype");
			this.tblottype.Name = "tblottype";
			//
			// label65
			//
			resources.ApplyResources(this.label65, "label65");
			this.label65.BackColor = System.Drawing.Color.Transparent;
			this.label65.Name = "label65";
			//
			// tbsimname
			//
			resources.ApplyResources(this.tbsimname, "tbsimname");
			this.tbsimname.Name = "tbsimname";
			//
			// label9
			//
			resources.ApplyResources(this.label9, "label9");
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Name = "label9";
			//
			// tbsimid
			//
			resources.ApplyResources(this.tbsimid, "tbsimid");
			this.tbsimid.Name = "tbsimid";
			this.toolTip1.SetToolTip(
				this.tbsimid,
				resources.GetString("tbsimid.ToolTip")
			);
			//
			// label8
			//
			resources.ApplyResources(this.label8, "label8");
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Name = "label8";
			//
			// panel6
			//
			resources.ApplyResources(this.panel6, "panel6");
			//this.panel6.CanCommit = true;
			this.panel6.Name = "panel6";
			//this.panel6.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CommitObjdClicked);
			//
			// tabControl1
			//
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			//
			// tabPage4
			//
			this.tabPage4.Controls.Add(this.familytiePanel);
			resources.ApplyResources(this.tabPage4, "tabPage4");
			this.tabPage4.Name = "tabPage4";
			//
			// familytiePanel
			//
			resources.ApplyResources(this.familytiePanel, "familytiePanel");
			this.familytiePanel.Controls.Add(this.gbties);
			this.familytiePanel.Controls.Add(this.cbtiesims);
			this.familytiePanel.Controls.Add(this.label64);
			this.familytiePanel.Controls.Add(this.panel8);
			this.familytiePanel.Name = "familytiePanel";
			//
			// gbties
			//
			resources.ApplyResources(this.gbties, "gbties");
			this.gbties.Controls.Add(this.btnewtie);
			this.gbties.Controls.Add(this.cballtieablesims);
			this.gbties.Controls.Add(this.cbtietype);
			this.gbties.Controls.Add(this.lbties);
			this.gbties.Controls.Add(this.btdeletetie);
			this.gbties.Controls.Add(this.btaddtie);
			this.gbties.Controls.Add(this.llcommitties);
			this.gbties.FlatStyle = FlatStyle.System;
			this.gbties.Name = "gbties";
			this.gbties.TabStop = false;
			//
			// btnewtie
			//
			resources.ApplyResources(this.btnewtie, "btnewtie");
			this.btnewtie.Name = "btnewtie";
			this.btnewtie.Click += new EventHandler(this.AddSimToTiesClick);
			//
			// cballtieablesims
			//
			resources.ApplyResources(this.cballtieablesims, "cballtieablesims");
			this.cballtieablesims.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cballtieablesims.Name = "cballtieablesims";
			this.cballtieablesims.SelectedIndexChanged += new EventHandler(
				this.AllTieableSimsIndexChanged
			);
			//
			// cbtietype
			//
			this.cbtietype.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			resources.ApplyResources(this.cbtietype, "cbtietype");
			this.cbtietype.Name = "cbtietype";
			//
			// lbties
			//
			resources.ApplyResources(this.lbties, "lbties");
			this.lbties.Name = "lbties";
			this.lbties.SelectedIndexChanged += new EventHandler(
				this.TieIndexChanged
			);
			//
			// btdeletetie
			//
			resources.ApplyResources(this.btdeletetie, "btdeletetie");
			this.btdeletetie.Name = "btdeletetie";
			this.btdeletetie.Click += new EventHandler(this.DeleteTieClick);
			//
			// btaddtie
			//
			resources.ApplyResources(this.btaddtie, "btaddtie");
			this.btaddtie.Name = "btaddtie";
			this.btaddtie.Click += new EventHandler(this.AddTieClick);
			//
			// llcommitties
			//
			resources.ApplyResources(this.llcommitties, "llcommitties");
			this.llcommitties.Name = "llcommitties";
			this.llcommitties.TabStop = true;
			this.llcommitties.UseCompatibleTextRendering = true;
			this.llcommitties.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					this.CommitSimTieClicked
				);
			//
			// cbtiesims
			//
			resources.ApplyResources(this.cbtiesims, "cbtiesims");
			this.cbtiesims.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			this.cbtiesims.Name = "cbtiesims";
			this.cbtiesims.SelectedIndexChanged += new EventHandler(
				this.FamilyTieSimIndexChanged
			);
			//
			// label64
			//
			resources.ApplyResources(this.label64, "label64");
			this.label64.Name = "label64";
			//
			// panel8
			//
			resources.ApplyResources(this.panel8, "panel8");
			//this.panel8.CanCommit = true;
			this.panel8.Name = "panel8";
			//this.panel8.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CommitTieClick);
			//
			// tabPage1
			//
			this.tabPage1.Controls.Add(this.famiPanel);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			//
			// famiPanel
			//
			resources.ApplyResources(this.famiPanel, "famiPanel");
			this.famiPanel.BackColor = System.Drawing.Color.Transparent;
			//this.famiPanel.BackgroundImageLocation = new System.Drawing.Point(744, 24);
			//this.famiPanel.BackgroundImageZoomToFit = true;
			this.famiPanel.Controls.Add(this.tbbmoney);
			this.famiPanel.Controls.Add(this.label16);
			this.famiPanel.Controls.Add(this.tbblot);
			this.famiPanel.Controls.Add(this.label14);
			this.famiPanel.Controls.Add(this.gbCastaway);
			this.famiPanel.Controls.Add(this.tbvac);
			this.famiPanel.Controls.Add(this.label7);
			this.famiPanel.Controls.Add(this.tbsubhood);
			this.famiPanel.Controls.Add(this.label89);
			this.famiPanel.Controls.Add(this.groupBox4);
			this.famiPanel.Controls.Add(this.tbalbum);
			this.famiPanel.Controls.Add(this.label93);
			this.famiPanel.Controls.Add(this.tblotinst);
			this.famiPanel.Controls.Add(this.llFamiDeleteSim);
			this.famiPanel.Controls.Add(this.llFamiAddSim);
			this.famiPanel.Controls.Add(this.btOpenHistory);
			this.famiPanel.Controls.Add(this.pbImage);
			this.famiPanel.Controls.Add(this.cbsims);
			this.famiPanel.Controls.Add(this.lbmembers);
			this.famiPanel.Controls.Add(this.tbname);
			this.famiPanel.Controls.Add(this.label6);
			this.famiPanel.Controls.Add(this.tbfamily);
			this.famiPanel.Controls.Add(this.tbmoney);
			this.famiPanel.Controls.Add(this.lbnotiss);
			this.famiPanel.Controls.Add(this.label5);
			this.famiPanel.Controls.Add(this.label4);
			this.famiPanel.Controls.Add(this.label3);
			this.famiPanel.Controls.Add(this.panel4);
			this.famiPanel.Controls.Add(this.label15);
			//this.famiPanel.EndColour = System.Drawing.SystemColors.Control;
			//this.famiPanel.MiddleColour = System.Drawing.SystemColors.Control;
			this.famiPanel.Name = "famiPanel";
			//this.famiPanel.StartColour = System.Drawing.SystemColors.Control;
			//
			// tbbmoney
			//
			resources.ApplyResources(this.tbbmoney, "tbbmoney");
			this.tbbmoney.Name = "tbbmoney";
			this.tbbmoney.TextChanged += new EventHandler(this.ChangedBMoney);
			//
			// label16
			//
			resources.ApplyResources(this.label16, "label16");
			this.label16.BackColor = System.Drawing.Color.Transparent;
			this.label16.Name = "label16";
			//
			// tbblot
			//
			resources.ApplyResources(this.tbblot, "tbblot");
			this.tbblot.Name = "tbblot";
			//
			// label14
			//
			resources.ApplyResources(this.label14, "label14");
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.Name = "label14";
			//
			// gbCastaway
			//
			resources.ApplyResources(this.gbCastaway, "gbCastaway");
			this.gbCastaway.BackColor = System.Drawing.Color.Transparent;
			this.gbCastaway.Controls.Add(this.tbcaunk);
			this.gbCastaway.Controls.Add(this.label13);
			this.gbCastaway.Controls.Add(this.tbcares);
			this.gbCastaway.Controls.Add(this.label11);
			this.gbCastaway.Controls.Add(this.tbcafood1);
			this.gbCastaway.Controls.Add(this.label10);
			this.gbCastaway.Name = "gbCastaway";
			this.gbCastaway.TabStop = false;
			//
			// tbcaunk
			//
			resources.ApplyResources(this.tbcaunk, "tbcaunk");
			this.tbcaunk.Name = "tbcaunk";
			this.tbcaunk.TextChanged += new EventHandler(this.ChangedBMoney);
			//
			// label13
			//
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			//
			// tbcares
			//
			resources.ApplyResources(this.tbcares, "tbcares");
			this.tbcares.Name = "tbcares";
			//
			// label11
			//
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			//
			// tbcafood1
			//
			resources.ApplyResources(this.tbcafood1, "tbcafood1");
			this.tbcafood1.Name = "tbcafood1";
			this.tbcafood1.TextChanged += new EventHandler(this.ChangedMoney);
			//
			// label10
			//
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			//
			// tbvac
			//
			resources.ApplyResources(this.tbvac, "tbvac");
			this.tbvac.Name = "tbvac";
			//
			// label7
			//
			resources.ApplyResources(this.label7, "label7");
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Name = "label7";
			//
			// tbsubhood
			//
			resources.ApplyResources(this.tbsubhood, "tbsubhood");
			this.tbsubhood.Name = "tbsubhood";
			//
			// label89
			//
			resources.ApplyResources(this.label89, "label89");
			this.label89.BackColor = System.Drawing.Color.Transparent;
			this.label89.Name = "label89";
			//
			// groupBox4
			//
			resources.ApplyResources(this.groupBox4, "groupBox4");
			this.groupBox4.BackColor = System.Drawing.Color.Transparent;
			this.groupBox4.Controls.Add(this.cbcomputer);
			this.groupBox4.Controls.Add(this.cblot);
			this.groupBox4.Controls.Add(this.cbbaby);
			this.groupBox4.Controls.Add(this.cbphone);
			this.groupBox4.Controls.Add(this.tbflag);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.TabStop = false;
			//
			// cbcomputer
			//
			resources.ApplyResources(this.cbcomputer, "cbcomputer");
			this.cbcomputer.Name = "cbcomputer";
			this.cbcomputer.CheckedChanged += new EventHandler(this.ChangeFlags);
			//
			// cblot
			//
			resources.ApplyResources(this.cblot, "cblot");
			this.cblot.Name = "cblot";
			this.cblot.CheckedChanged += new EventHandler(this.ChangeFlags);
			//
			// cbbaby
			//
			resources.ApplyResources(this.cbbaby, "cbbaby");
			this.cbbaby.Name = "cbbaby";
			this.cbbaby.CheckedChanged += new EventHandler(this.ChangeFlags);
			//
			// cbphone
			//
			resources.ApplyResources(this.cbphone, "cbphone");
			this.cbphone.Name = "cbphone";
			this.cbphone.CheckedChanged += new EventHandler(this.ChangeFlags);
			//
			// tbflag
			//
			resources.ApplyResources(this.tbflag, "tbflag");
			this.tbflag.Name = "tbflag";
			this.tbflag.TextChanged += new EventHandler(this.FlagChanged);
			//
			// tbalbum
			//
			resources.ApplyResources(this.tbalbum, "tbalbum");
			this.tbalbum.Name = "tbalbum";
			//
			// label93
			//
			resources.ApplyResources(this.label93, "label93");
			this.label93.BackColor = System.Drawing.Color.Transparent;
			this.label93.Name = "label93";
			//
			// tblotinst
			//
			resources.ApplyResources(this.tblotinst, "tblotinst");
			this.tblotinst.Name = "tblotinst";
			//
			// llFamiDeleteSim
			//
			resources.ApplyResources(this.llFamiDeleteSim, "llFamiDeleteSim");
			this.llFamiDeleteSim.Name = "llFamiDeleteSim";
			this.llFamiDeleteSim.Click += new EventHandler(
				this.FamiDeleteSimClick
			);
			//
			// llFamiAddSim
			//
			resources.ApplyResources(this.llFamiAddSim, "llFamiAddSim");
			this.llFamiAddSim.Name = "llFamiAddSim";
			this.llFamiAddSim.Click += new EventHandler(this.FamiSimAddClick);
			//
			// btOpenHistory
			//
			resources.ApplyResources(this.btOpenHistory, "btOpenHistory");
			this.btOpenHistory.Name = "btOpenHistory";
			this.btOpenHistory.Click += new EventHandler(this.FamiOpenHistory);
			//
			// pbImage
			//
			this.pbImage.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.pbImage, "pbImage");
			this.pbImage.Name = "pbImage";
			this.pbImage.TabStop = false;
			//
			// cbsims
			//
			this.cbsims.DropDownStyle = ComboBoxStyle.DropDownList;
			resources.ApplyResources(this.cbsims, "cbsims");
			this.cbsims.Name = "cbsims";
			this.cbsims.SelectedIndexChanged += new EventHandler(
				this.SimSelectionChange
			);
			//
			// lbmembers
			//
			resources.ApplyResources(this.lbmembers, "lbmembers");
			this.lbmembers.Name = "lbmembers";
			this.lbmembers.SelectedIndexChanged += new EventHandler(
				this.FamiMemberSelectionClick
			);
			this.lbmembers.DoubleClick += new EventHandler(
				this.lbmembers_DoubleClick
			);
			//
			// tbname
			//
			resources.ApplyResources(this.tbname, "tbname");
			this.tbname.Name = "tbname";
			//
			// label6
			//
			resources.ApplyResources(this.label6, "label6");
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Name = "label6";
			//
			// tbfamily
			//
			resources.ApplyResources(this.tbfamily, "tbfamily");
			this.tbfamily.Name = "tbfamily";
			//
			// tbmoney
			//
			resources.ApplyResources(this.tbmoney, "tbmoney");
			this.tbmoney.Name = "tbmoney";
			this.tbmoney.TextChanged += new EventHandler(this.ChangedMoney);
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Name = "label5";
			//
			// lbnotiss
			//
			resources.ApplyResources(this.lbnotiss, "lbnotiss");
			this.lbnotiss.BackColor = System.Drawing.Color.Transparent;
			this.lbnotiss.Name = "lbnotiss";
			this.lbnotiss.ForeColor = System.Drawing.Color.Gray;
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Name = "label4";
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Name = "label3";
			//
			// panel4
			//
			resources.ApplyResources(this.panel4, "panel4");
			//this.panel4.CanCommit = true;
			this.panel4.Name = "panel4";
			//this.panel4.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.CommitFamiClick);
			//
			// label15
			//
			resources.ApplyResources(this.label15, "label15");
			this.label15.BackColor = System.Drawing.Color.Transparent;
			this.label15.Name = "label15";
			this.label15.Click += new EventHandler(this.label15_Click);
			//
			// tabPage3
			//
			this.tabPage3.Controls.Add(this.objdPanel);
			this.tabPage3.Controls.Add(this.realPanel);
			this.tabPage3.Controls.Add(this.JpegPanel);
			this.tabPage3.Controls.Add(this.xmlPanel);
			resources.ApplyResources(this.tabPage3, "tabPage3");
			this.tabPage3.Name = "tabPage3";
			//
			// realPanel
			//
			this.realPanel.Controls.Add(this.label91);
			this.realPanel.Controls.Add(this.cbfamtype);
			this.realPanel.Controls.Add(this.gbrelation);
			this.realPanel.Controls.Add(this.tblongterm);
			this.realPanel.Controls.Add(this.tbshortterm);
			this.realPanel.Controls.Add(this.label57);
			this.realPanel.Controls.Add(this.label58);
			this.realPanel.Controls.Add(this.panel7);
			resources.ApplyResources(this.realPanel, "realPanel");
			this.realPanel.Name = "realPanel";
			//
			// label91
			//
			resources.ApplyResources(this.label91, "label91");
			this.label91.BackColor = System.Drawing.Color.Transparent;
			this.label91.Name = "label91";
			//
			// cbfamtype
			//
			this.cbfamtype.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			resources.ApplyResources(this.cbfamtype, "cbfamtype");
			this.cbfamtype.Name = "cbfamtype";
			//
			// gbrelation
			//
			this.gbrelation.BackColor = System.Drawing.Color.Transparent;
			this.gbrelation.Controls.Add(this.cbBFF);
			this.gbrelation.Controls.Add(this.cbsecret);
			this.gbrelation.Controls.Add(this.cbplatonic);
			this.gbrelation.Controls.Add(this.cbbest);
			this.gbrelation.Controls.Add(this.cbfamily);
			this.gbrelation.Controls.Add(this.cbmarried);
			this.gbrelation.Controls.Add(this.cbengaged);
			this.gbrelation.Controls.Add(this.cbsteady);
			this.gbrelation.Controls.Add(this.cblove);
			this.gbrelation.Controls.Add(this.cbcrush);
			this.gbrelation.Controls.Add(this.cbbuddie);
			this.gbrelation.Controls.Add(this.cbfriend);
			this.gbrelation.Controls.Add(this.cbenemy);
			resources.ApplyResources(this.gbrelation, "gbrelation");
			this.gbrelation.Name = "gbrelation";
			this.gbrelation.TabStop = false;
			//
			// cbBFF
			//
			resources.ApplyResources(this.cbBFF, "cbBFF");
			this.cbBFF.Name = "cbBFF";
			//
			// cbsecret
			//
			resources.ApplyResources(this.cbsecret, "cbsecret");
			this.cbsecret.Name = "cbsecret";
			//
			// cbplatonic
			//
			resources.ApplyResources(this.cbplatonic, "cbplatonic");
			this.cbplatonic.Name = "cbplatonic";
			//
			// cbbest
			//
			resources.ApplyResources(this.cbbest, "cbbest");
			this.cbbest.Name = "cbbest";
			//
			// cbfamily
			//
			resources.ApplyResources(this.cbfamily, "cbfamily");
			this.cbfamily.Name = "cbfamily";
			//
			// cbmarried
			//
			resources.ApplyResources(this.cbmarried, "cbmarried");
			this.cbmarried.Name = "cbmarried";
			//
			// cbengaged
			//
			resources.ApplyResources(this.cbengaged, "cbengaged");
			this.cbengaged.Name = "cbengaged";
			//
			// cbsteady
			//
			resources.ApplyResources(this.cbsteady, "cbsteady");
			this.cbsteady.Name = "cbsteady";
			//
			// cblove
			//
			resources.ApplyResources(this.cblove, "cblove");
			this.cblove.Name = "cblove";
			//
			// cbcrush
			//
			resources.ApplyResources(this.cbcrush, "cbcrush");
			this.cbcrush.Name = "cbcrush";
			//
			// cbbuddie
			//
			resources.ApplyResources(this.cbbuddie, "cbbuddie");
			this.cbbuddie.Name = "cbbuddie";
			//
			// cbfriend
			//
			resources.ApplyResources(this.cbfriend, "cbfriend");
			this.cbfriend.Name = "cbfriend";
			//
			// cbenemy
			//
			resources.ApplyResources(this.cbenemy, "cbenemy");
			this.cbenemy.Name = "cbenemy";
			//
			// tblongterm
			//
			resources.ApplyResources(this.tblongterm, "tblongterm");
			this.tblongterm.Name = "tblongterm";
			//
			// tbshortterm
			//
			resources.ApplyResources(this.tbshortterm, "tbshortterm");
			this.tbshortterm.Name = "tbshortterm";
			//
			// label57
			//
			resources.ApplyResources(this.label57, "label57");
			this.label57.BackColor = System.Drawing.Color.Transparent;
			this.label57.Name = "label57";
			//
			// label58
			//
			resources.ApplyResources(this.label58, "label58");
			this.label58.BackColor = System.Drawing.Color.Transparent;
			this.label58.Name = "label58";
			//
			// panel7
			//
			resources.ApplyResources(this.panel7, "panel7");
			//this.panel7.CanCommit = true;
			this.panel7.Name = "panel7";
			//this.panel7.OnCommit += new System.Windows.Forms.Panel.EventHandler(this.RelationshipFileCommit);
			//
			// Elements
			//
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.tabControl1);
			this.Name = "Elements";
			this.JpegPanel.ResumeLayout(false);
			this.JpegPanel.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
			this.xmlPanel.ResumeLayout(false);
			this.objdPanel.ResumeLayout(false);
			this.objdPanel.PerformLayout();
			this.gbelements.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.familytiePanel.ResumeLayout(false);
			this.familytiePanel.PerformLayout();
			this.gbties.ResumeLayout(false);
			this.gbties.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.famiPanel.ResumeLayout(false);
			this.famiPanel.PerformLayout();
			this.gbCastaway.ResumeLayout(false);
			this.gbCastaway.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.realPanel.ResumeLayout(false);
			this.realPanel.PerformLayout();
			this.gbrelation.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void CommitFamiClick(object sender, EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					Wrapper.Fami fami = (Wrapper.Fami)wrapper;
					fami.Money = Convert.ToInt32(tbmoney.Text);
					fami.Friends = Convert.ToUInt32(tbfamily.Text);
					fami.Flags = Convert.ToUInt32(tbflag.Text, 16);
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
						this.tbbmoney.Text,
						fami.BusinessMoney,
						10
					);

					fami.CastAwayFood = Helper.StringToInt32(
						this.tbcafood1.Text,
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
					for (int i = 0; i < members.Length; i++)
					{
						members[i] = ((Interfaces.IAlias)lbmembers.Items[i]).Id;
						Wrapper.SDesc sdesc = fami.GetDescriptionFile(
							members[i]
						);
						sdesc.FamilyInstance = (ushort)fami.FileDescriptor.Instance;
						sdesc.SynchronizeUserData();
					}
					fami.Members = members;
					if (this.tblotinst.Text != "Sim Bin")
					{
						fami.LotInstance = Convert.ToUInt32(this.tblotinst.Text, 16);
					}
					else
					{
						fami.LotInstance = 0;
					}
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
					this.Cursor = Cursors.Default;
				}
			}
		}

		private void lbmembers_DoubleClick(object sender, EventArgs e)
		{
			if (lbmembers.SelectedIndex >= 0)
			{
				Wrapper.Fami fami = (Wrapper.Fami)wrapper;
				Data.Alias a = (Data.Alias)lbmembers.SelectedItem;
				Wrapper.SDesc sdsc = fami.GetDescriptionFile(a.Id);
				if (sdsc == null)
				{
					return;
				}

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

		private void CommitXmlClick(object sender, EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					Wrapper.Xml xml = (Wrapper.Xml)wrapper;

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
				if (!this.lbmembers.Items.Contains(cbsims.Items[cbsims.SelectedIndex]))
				{
					this.lbmembers.Items.Add(cbsims.Items[cbsims.SelectedIndex]);
				}
			}
		}

		private void SimSelectionChange(object sender, EventArgs e)
		{
			this.llFamiAddSim.Enabled = (
				(((ComboBox)sender).SelectedIndex >= 0)
				&& (((ComboBox)sender).Items.Count > 0)
			);
		}

		private void FamiMemberSelectionClick(object sender, EventArgs e)
		{
			this.llFamiDeleteSim.Enabled = (((ListBox)sender).SelectedIndex >= 0);
			this.llFamiDeleteSim.Invalidate();
			this.llFamiDeleteSim.Update();
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
				Wrapper.Fami fami = (Wrapper.Fami)wrapper;
				Interfaces.Files.IPackedFileDescriptor pfd = fami.Package.NewDescriptor(
					0x46414D68,
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
			this.btdeletetie.Enabled = false;
			if (this.cbtiesims.SelectedIndex < 0)
			{
				return;
			}

			FamilyTieSim sim = (FamilyTieSim)cbtiesims.Items[cbtiesims.SelectedIndex];

			this.lbties.Items.Clear();
			foreach (FamilyTieItem tie in sim.Ties)
			{
				lbties.Items.Add(tie);
			}
		}

		private void AllTieableSimsIndexChanged(object sender, EventArgs e)
		{
			this.btaddtie.Enabled = false;
			this.btnewtie.Enabled = false;
			if (this.cballtieablesims.SelectedIndex < 0)
			{
				return;
			}

			this.btnewtie.Enabled = true;
			if (this.cbtiesims.SelectedIndex < 0)
			{
				return;
			}

			this.btaddtie.Enabled = true;
		}

		private void DeleteTieClick(object sender, EventArgs e)
		{
			this.btaddtie.Enabled = false;
			if (this.lbties.SelectedIndex < 0)
			{
				return;
			}

			lbties.Items.Remove(lbties.Items[lbties.SelectedIndex]);
		}

		private void AddTieClick(object sender, EventArgs e)
		{
			if (this.cballtieablesims.SelectedIndex < 0)
			{
				return;
			}

			if (this.cbtietype.SelectedIndex < 0)
			{
				return;
			}

			try
			{
				Wrapper.FamilyTies famt = (Wrapper.FamilyTies)wrapper;
				Data.MetaData.FamilyTieTypes ftt = (Data.LocalizedFamilyTieTypes)
					this.cbtietype.Items[cbtietype.SelectedIndex];
				FamilyTieSim fts = (FamilyTieSim)
					this.cballtieablesims.Items[cballtieablesims.SelectedIndex];
				FamilyTieItem tie = new FamilyTieItem(ftt, fts.Instance, famt);
				this.lbties.Items.Add(tie);
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
			if (this.cbtiesims.SelectedIndex < 0)
			{
				return;
			}

			if (wrapper != null)
			{
				try
				{
					Wrapper.FamilyTies famt =
						(Wrapper.FamilyTies)wrapper;

					FamilyTieSim fts = (FamilyTieSim)
						cbtiesims.Items[cbtiesims.SelectedIndex];
					FamilyTieItem[] ftis = new FamilyTieItem[lbties.Items.Count];
					for (int i = 0; i < lbties.Items.Count; i++)
					{
						ftis[i] = (FamilyTieItem)lbties.Items[i];
					}
					fts.Ties = ftis;
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
			this.btdeletetie.Enabled = false;
			if (this.lbties.SelectedIndex < 0)
			{
				return;
			}

			this.btdeletetie.Enabled = true;
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
			if (this.cballtieablesims.SelectedIndex < 0)
			{
				return;
			}

			FamilyTieSim sim = (FamilyTieSim)
				this.cballtieablesims.Items[cballtieablesims.SelectedIndex];
			sim.Ties = new FamilyTieItem[0];

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
							ltcb[i].Checked = ((Boolset)(i < 16 ? bs1 : bs2))[i & 0x0f];
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
					this.Cursor = Cursors.WaitCursor;
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
					objd.Guid = (uint)Helper.HexStringToUInt(tbsimid.Text);
					objd.FileName = tbsimname.Text;
					objd.OriginalGuid = (uint)
						Helper.HexStringToUInt(this.tborgguid.Text);
					objd.ProxyGuid = (uint)Helper.HexStringToUInt(this.tbproxguid.Text);

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
				uint flag = Convert.ToUInt32(tbflag.Text, 16);
				Wrapper.FamiFlags flags =
					new Wrapper.FamiFlags((ushort)flag);

				this.cbphone.Checked = flags.HasPhone;
				this.cbcomputer.Checked = flags.HasComputer;
				this.cbbaby.Checked = flags.HasBaby;
				this.cblot.Checked = flags.NewLot;
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
				uint flag = Convert.ToUInt32(tbflag.Text, 16) & 0xffff0000;

				Wrapper.FamiFlags flags =
					new Wrapper.FamiFlags(0);

				flags.HasPhone = this.cbphone.Checked;
				flags.HasComputer = this.cbcomputer.Checked;
				flags.HasBaby = this.cbbaby.Checked;
				flags.NewLot = this.cblot.Checked;

				flag = flag | flags.Value;
				tbflag.Text = "0x" + Helper.HexString(flag);
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
			Wrapper.Picture wrp =
				(Wrapper.Picture)picwrapper;
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Image (*.png) | *.png";

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
				Wrapper.Fami fami = (Wrapper.Fami)wrapper;
				if (fami.LotInstance == 0)
				{
					return;
				}

				Interfaces.Files.IPackedFileDescriptor pfd = fami.Package.NewDescriptor(
					0x0BF999E7,
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
			Wrapper.Fami fami = (Wrapper.Fami)wrapper;
			TextBox tb = (TextBox)sender;
			fami.Money = Helper.StringToInt32(tb.Text, fami.Money, 10);
			fami.CastAwayFood = fami.Money;

			if (tb != tbmoney)
			{
				tbmoney.Text = fami.Money.ToString();
			}

			if (tb != tbcafood1)
			{
				tbcafood1.Text = fami.CastAwayFood.ToString();
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
			Wrapper.Fami fami = (Wrapper.Fami)wrapper;
			TextBox tb = (TextBox)sender;
			fami.BusinessMoney = Helper.StringToInt32(tb.Text, fami.BusinessMoney, 10);
			fami.CastAwayFoodDecay = fami.BusinessMoney;

			if (tb != tbbmoney)
			{
				tbbmoney.Text = fami.BusinessMoney.ToString();
			}

			if (tb != tbcaunk)
			{
				tbcaunk.Text = fami.CastAwayFoodDecay.ToString();
			}

			intern = false;
		}
	}
}
