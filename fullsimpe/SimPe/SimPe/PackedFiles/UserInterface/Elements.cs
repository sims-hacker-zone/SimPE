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
	internal class Elements : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.PictureBox pb;
		internal System.Windows.Forms.Panel JpegPanel;
		internal System.Windows.Forms.Panel xmlPanel;
		private System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.RichTextBox rtb;
		private System.ComponentModel.IContainer components;
		internal System.Windows.Forms.TextBox tbsimid;
		private System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Panel objdPanel;
		internal System.Windows.Forms.TextBox tbsimname;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		internal System.Windows.Forms.Panel famiPanel;
		internal System.Windows.Forms.TextBox tblotinst;
		internal System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button llFamiDeleteSim;
		private System.Windows.Forms.Button llFamiAddSim;
		internal System.Windows.Forms.Button btOpenHistory;
		internal System.Windows.Forms.PictureBox pbImage;
		internal System.Windows.Forms.ComboBox cbsims;
		internal System.Windows.Forms.ListBox lbmembers;
		internal System.Windows.Forms.TextBox tbname;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox tbfamily;
		internal System.Windows.Forms.TextBox tbmoney;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbnotiss;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TabPage tabPage3;
		internal System.Windows.Forms.Panel realPanel;
		private System.Windows.Forms.Panel panel7;
		internal System.Windows.Forms.TextBox tblongterm;
		internal System.Windows.Forms.TextBox tbshortterm;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.GroupBox gbrelation;
		internal System.Windows.Forms.CheckBox cbmarried;
		internal System.Windows.Forms.CheckBox cbengaged;
		internal System.Windows.Forms.CheckBox cbsteady;
		internal System.Windows.Forms.CheckBox cblove;
		internal System.Windows.Forms.CheckBox cbcrush;
		internal System.Windows.Forms.CheckBox cbenemy;
		internal System.Windows.Forms.CheckBox cbbuddie;
		internal System.Windows.Forms.CheckBox cbfriend;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Panel panel8;
		internal System.Windows.Forms.Panel familytiePanel;
		internal System.Windows.Forms.ComboBox cbtiesims;
		private System.Windows.Forms.GroupBox gbties;
		internal System.Windows.Forms.ComboBox cbtietype;
		internal System.Windows.Forms.Button btdeletetie;
		internal System.Windows.Forms.Button btaddtie;
		internal System.Windows.Forms.ListBox lbties;
		internal System.Windows.Forms.ComboBox cballtieablesims;
		private System.Windows.Forms.LinkLabel llcommitties;
		internal System.Windows.Forms.Button btnewtie;
		internal System.Windows.Forms.TextBox tblottype;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.GroupBox gbelements;
		internal System.Windows.Forms.Panel pnelements;
		internal System.Windows.Forms.Label lbtypename;
		internal System.Windows.Forms.CheckBox cbfamily;
		internal System.Windows.Forms.CheckBox cbbest;
		internal System.Windows.Forms.ComboBox cbfamtype;
		private System.Windows.Forms.Label label91;
		internal System.Windows.Forms.TextBox tbflag;
		internal System.Windows.Forms.TextBox tbalbum;
		private System.Windows.Forms.Label label93;
		internal System.Windows.Forms.TextBox tborgguid;
		internal System.Windows.Forms.TextBox tbproxguid;
		private System.Windows.Forms.Label label97;
		internal System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox cbphone;
		private System.Windows.Forms.CheckBox cbbaby;
		private System.Windows.Forms.CheckBox cbcomputer;
		private System.Windows.Forms.CheckBox cblot;
		private System.Windows.Forms.CheckBox cbupdate;
		internal System.Windows.Forms.TextBox tbsubhood;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Button btPicExport;
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
		private System.Windows.Forms.Panel panel6;

		internal SimPe.Interfaces.Plugin.IFileWrapperSaveExtension wrapper = null;

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
			this.JpegPanel = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btPicExport = new System.Windows.Forms.Button();
			this.pb = new System.Windows.Forms.PictureBox();
			this.xmlPanel = new System.Windows.Forms.Panel();
			this.rtb = new System.Windows.Forms.RichTextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.objdPanel = new System.Windows.Forms.Panel();
			this.cbupdate = new System.Windows.Forms.CheckBox();
			this.label63 = new System.Windows.Forms.Label();
			this.tbproxguid = new System.Windows.Forms.TextBox();
			this.label97 = new System.Windows.Forms.Label();
			this.tborgguid = new System.Windows.Forms.TextBox();
			this.lbtypename = new System.Windows.Forms.Label();
			this.gbelements = new System.Windows.Forms.GroupBox();
			this.pnelements = new System.Windows.Forms.Panel();
			this.tblottype = new System.Windows.Forms.TextBox();
			this.label65 = new System.Windows.Forms.Label();
			this.tbsimname = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbsimid = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.familytiePanel = new System.Windows.Forms.Panel();
			this.gbties = new System.Windows.Forms.GroupBox();
			this.btnewtie = new System.Windows.Forms.Button();
			this.cballtieablesims = new System.Windows.Forms.ComboBox();
			this.cbtietype = new System.Windows.Forms.ComboBox();
			this.lbties = new System.Windows.Forms.ListBox();
			this.btdeletetie = new System.Windows.Forms.Button();
			this.btaddtie = new System.Windows.Forms.Button();
			this.llcommitties = new System.Windows.Forms.LinkLabel();
			this.cbtiesims = new System.Windows.Forms.ComboBox();
			this.label64 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.famiPanel = new System.Windows.Forms.Panel();
			this.tbbmoney = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.tbblot = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.gbCastaway = new System.Windows.Forms.GroupBox();
			this.tbcaunk = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbcares = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbcafood1 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbvac = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbsubhood = new System.Windows.Forms.TextBox();
			this.label89 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbcomputer = new System.Windows.Forms.CheckBox();
			this.cblot = new System.Windows.Forms.CheckBox();
			this.cbbaby = new System.Windows.Forms.CheckBox();
			this.cbphone = new System.Windows.Forms.CheckBox();
			this.tbflag = new System.Windows.Forms.TextBox();
			this.tbalbum = new System.Windows.Forms.TextBox();
			this.label93 = new System.Windows.Forms.Label();
			this.tblotinst = new System.Windows.Forms.TextBox();
			this.llFamiDeleteSim = new System.Windows.Forms.Button();
			this.llFamiAddSim = new System.Windows.Forms.Button();
			this.btOpenHistory = new System.Windows.Forms.Button();
			this.pbImage = new System.Windows.Forms.PictureBox();
			this.cbsims = new System.Windows.Forms.ComboBox();
			this.lbmembers = new System.Windows.Forms.ListBox();
			this.tbname = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbfamily = new System.Windows.Forms.TextBox();
			this.tbmoney = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lbnotiss = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label15 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.realPanel = new System.Windows.Forms.Panel();
			this.label91 = new System.Windows.Forms.Label();
			this.cbfamtype = new System.Windows.Forms.ComboBox();
			this.gbrelation = new System.Windows.Forms.GroupBox();
			this.cbBFF = new System.Windows.Forms.CheckBox();
			this.cbsecret = new System.Windows.Forms.CheckBox();
			this.cbplatonic = new System.Windows.Forms.CheckBox();
			this.cbbest = new System.Windows.Forms.CheckBox();
			this.cbfamily = new System.Windows.Forms.CheckBox();
			this.cbmarried = new System.Windows.Forms.CheckBox();
			this.cbengaged = new System.Windows.Forms.CheckBox();
			this.cbsteady = new System.Windows.Forms.CheckBox();
			this.cblove = new System.Windows.Forms.CheckBox();
			this.cbcrush = new System.Windows.Forms.CheckBox();
			this.cbbuddie = new System.Windows.Forms.CheckBox();
			this.cbfriend = new System.Windows.Forms.CheckBox();
			this.cbenemy = new System.Windows.Forms.CheckBox();
			this.tblongterm = new System.Windows.Forms.TextBox();
			this.tbshortterm = new System.Windows.Forms.TextBox();
			this.label57 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
			this.btPicExport.Click += new System.EventHandler(this.btPicExport_Click);
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
			this.cbupdate.CheckState = System.Windows.Forms.CheckState.Checked;
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
			this.gbties.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbties.Name = "gbties";
			this.gbties.TabStop = false;
			//
			// btnewtie
			//
			resources.ApplyResources(this.btnewtie, "btnewtie");
			this.btnewtie.Name = "btnewtie";
			this.btnewtie.Click += new System.EventHandler(this.AddSimToTiesClick);
			//
			// cballtieablesims
			//
			resources.ApplyResources(this.cballtieablesims, "cballtieablesims");
			this.cballtieablesims.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cballtieablesims.Name = "cballtieablesims";
			this.cballtieablesims.SelectedIndexChanged += new System.EventHandler(
				this.AllTieableSimsIndexChanged
			);
			//
			// cbtietype
			//
			this.cbtietype.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			resources.ApplyResources(this.cbtietype, "cbtietype");
			this.cbtietype.Name = "cbtietype";
			//
			// lbties
			//
			resources.ApplyResources(this.lbties, "lbties");
			this.lbties.Name = "lbties";
			this.lbties.SelectedIndexChanged += new System.EventHandler(
				this.TieIndexChanged
			);
			//
			// btdeletetie
			//
			resources.ApplyResources(this.btdeletetie, "btdeletetie");
			this.btdeletetie.Name = "btdeletetie";
			this.btdeletetie.Click += new System.EventHandler(this.DeleteTieClick);
			//
			// btaddtie
			//
			resources.ApplyResources(this.btaddtie, "btaddtie");
			this.btaddtie.Name = "btaddtie";
			this.btaddtie.Click += new System.EventHandler(this.AddTieClick);
			//
			// llcommitties
			//
			resources.ApplyResources(this.llcommitties, "llcommitties");
			this.llcommitties.Name = "llcommitties";
			this.llcommitties.TabStop = true;
			this.llcommitties.UseCompatibleTextRendering = true;
			this.llcommitties.LinkClicked +=
				new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
					this.CommitSimTieClicked
				);
			//
			// cbtiesims
			//
			resources.ApplyResources(this.cbtiesims, "cbtiesims");
			this.cbtiesims.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbtiesims.Name = "cbtiesims";
			this.cbtiesims.SelectedIndexChanged += new System.EventHandler(
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
			this.tbbmoney.TextChanged += new System.EventHandler(this.ChangedBMoney);
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
			this.tbcaunk.TextChanged += new System.EventHandler(this.ChangedBMoney);
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
			this.tbcafood1.TextChanged += new System.EventHandler(this.ChangedMoney);
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
			this.cbcomputer.CheckedChanged += new System.EventHandler(this.ChangeFlags);
			//
			// cblot
			//
			resources.ApplyResources(this.cblot, "cblot");
			this.cblot.Name = "cblot";
			this.cblot.CheckedChanged += new System.EventHandler(this.ChangeFlags);
			//
			// cbbaby
			//
			resources.ApplyResources(this.cbbaby, "cbbaby");
			this.cbbaby.Name = "cbbaby";
			this.cbbaby.CheckedChanged += new System.EventHandler(this.ChangeFlags);
			//
			// cbphone
			//
			resources.ApplyResources(this.cbphone, "cbphone");
			this.cbphone.Name = "cbphone";
			this.cbphone.CheckedChanged += new System.EventHandler(this.ChangeFlags);
			//
			// tbflag
			//
			resources.ApplyResources(this.tbflag, "tbflag");
			this.tbflag.Name = "tbflag";
			this.tbflag.TextChanged += new System.EventHandler(this.FlagChanged);
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
			this.llFamiDeleteSim.Click += new System.EventHandler(
				this.FamiDeleteSimClick
			);
			//
			// llFamiAddSim
			//
			resources.ApplyResources(this.llFamiAddSim, "llFamiAddSim");
			this.llFamiAddSim.Name = "llFamiAddSim";
			this.llFamiAddSim.Click += new System.EventHandler(this.FamiSimAddClick);
			//
			// btOpenHistory
			//
			resources.ApplyResources(this.btOpenHistory, "btOpenHistory");
			this.btOpenHistory.Name = "btOpenHistory";
			this.btOpenHistory.Click += new System.EventHandler(this.FamiOpenHistory);
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
			this.cbsims.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(this.cbsims, "cbsims");
			this.cbsims.Name = "cbsims";
			this.cbsims.SelectedIndexChanged += new System.EventHandler(
				this.SimSelectionChange
			);
			//
			// lbmembers
			//
			resources.ApplyResources(this.lbmembers, "lbmembers");
			this.lbmembers.Name = "lbmembers";
			this.lbmembers.SelectedIndexChanged += new System.EventHandler(
				this.FamiMemberSelectionClick
			);
			this.lbmembers.DoubleClick += new System.EventHandler(
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
			this.tbmoney.TextChanged += new System.EventHandler(this.ChangedMoney);
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
			this.label15.Click += new System.EventHandler(this.label15_Click);
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
			this.cbfamtype.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
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

		private void CommitFamiClick(object sender, System.EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					SimPe.PackedFiles.Wrapper.Fami fami = (Wrapper.Fami)wrapper;
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
						members[i] = ((SimPe.Interfaces.IAlias)lbmembers.Items[i]).Id;
						SimPe.PackedFiles.Wrapper.SDesc sdesc = fami.GetDescriptionFile(
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

		private void lbmembers_DoubleClick(object sender, System.EventArgs e)
		{
			if (lbmembers.SelectedIndex >= 0)
			{
				SimPe.PackedFiles.Wrapper.Fami fami = (Wrapper.Fami)wrapper;
				Data.Alias a = (Data.Alias)lbmembers.SelectedItem;
				SimPe.PackedFiles.Wrapper.SDesc sdsc = fami.GetDescriptionFile(a.Id);
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
				SimPe.RemoteControl.OpenPackedFile(pfd, sdsc.Package);
			}
		}

		private void CommitXmlClick(object sender, System.EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					SimPe.PackedFiles.Wrapper.Xml xml = (Wrapper.Xml)wrapper;

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

		private void FamiSimAddClick(object sender, System.EventArgs e)
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
							System.Windows.Forms.MessageBoxButtons.OKCancel
						) == System.Windows.Forms.DialogResult.Cancel
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

		private void SimSelectionChange(object sender, System.EventArgs e)
		{
			this.llFamiAddSim.Enabled = (
				(((ComboBox)sender).SelectedIndex >= 0)
				&& (((ComboBox)sender).Items.Count > 0)
			);
		}

		private void FamiMemberSelectionClick(object sender, System.EventArgs e)
		{
			this.llFamiDeleteSim.Enabled = (((ListBox)sender).SelectedIndex >= 0);
			this.llFamiDeleteSim.Invalidate();
			this.llFamiDeleteSim.Update();
		}

		private void FamiDeleteSimClick(object sender, System.EventArgs e)
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
		private void FamiOpenHistory(object sender, System.EventArgs e)
		{
			try
			{
				SimPe.PackedFiles.Wrapper.Fami fami = (Wrapper.Fami)wrapper;
				Interfaces.Files.IPackedFileDescriptor pfd = fami.Package.NewDescriptor(
					0x46414D68,
					fami.FileDescriptor.SubType,
					fami.FileDescriptor.Group,
					fami.FileDescriptor.Instance
				);
				pfd = fami.Package.FindFile(pfd);
				SimPe.RemoteControl.OpenPackedFile(pfd, fami.Package);
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
		private void FamilyTieSimIndexChanged(object sender, System.EventArgs e)
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

		private void AllTieableSimsIndexChanged(object sender, System.EventArgs e)
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

		private void DeleteTieClick(object sender, System.EventArgs e)
		{
			this.btaddtie.Enabled = false;
			if (this.lbties.SelectedIndex < 0)
			{
				return;
			}

			lbties.Items.Remove(lbties.Items[lbties.SelectedIndex]);
		}

		private void AddTieClick(object sender, System.EventArgs e)
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
				SimPe.PackedFiles.Wrapper.FamilyTies famt = (Wrapper.FamilyTies)wrapper;
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
			System.Windows.Forms.LinkLabelLinkClickedEventArgs e
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
					SimPe.PackedFiles.Wrapper.FamilyTies famt =
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

		private void TieIndexChanged(object sender, System.EventArgs e)
		{
			this.btdeletetie.Enabled = false;
			if (this.lbties.SelectedIndex < 0)
			{
				return;
			}

			this.btdeletetie.Enabled = true;
		}

		private void CommitTieClick(object sender, System.EventArgs e)
		{
			CommitSimTieClicked(null, null);
			if (wrapper != null)
			{
				try
				{
					SimPe.PackedFiles.Wrapper.FamilyTies famt =
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

		private void AddSimToTiesClick(object sender, System.EventArgs e)
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

		private void RelationshipFileCommit(object sender, System.EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					SimPe.PackedFiles.Wrapper.SRel srel = (Wrapper.SRel)wrapper;
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

		private void CommitObjdClicked(object sender, System.EventArgs e)
		{
			if (wrapper != null)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					SimPe.PackedFiles.Wrapper.Objd objd = (Wrapper.Objd)wrapper;

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
		private void FlagChanged(object sender, System.EventArgs e)
		{
			if (tbflag.Tag != null)
			{
				return;
			}

			tbflag.Tag = true;
			try
			{
				uint flag = Convert.ToUInt32(tbflag.Text, 16);
				SimPe.PackedFiles.Wrapper.FamiFlags flags =
					new SimPe.PackedFiles.Wrapper.FamiFlags((ushort)flag);

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

		private void ChangeFlags(object sender, System.EventArgs e)
		{
			if (tbflag.Tag != null)
			{
				return;
			}

			tbflag.Tag = true;
			try
			{
				uint flag = Convert.ToUInt32(tbflag.Text, 16) & 0xffff0000;

				SimPe.PackedFiles.Wrapper.FamiFlags flags =
					new SimPe.PackedFiles.Wrapper.FamiFlags(0);

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

		internal SimPe.Interfaces.Plugin.IFileWrapper picwrapper;

		private void btPicExport_Click(object sender, System.EventArgs e)
		{
			SimPe.PackedFiles.Wrapper.Picture wrp =
				(SimPe.PackedFiles.Wrapper.Picture)picwrapper;
			System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
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
				SimPe.PackedFiles.Wrapper.Fami fami = (Wrapper.Fami)wrapper;
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
				SimPe.RemoteControl.OpenPackedFile(pfd, fami.Package);
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
			SimPe.PackedFiles.Wrapper.Fami fami = (Wrapper.Fami)wrapper;
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
			SimPe.PackedFiles.Wrapper.Fami fami = (Wrapper.Fami)wrapper;
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
