// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SimPe.Forms.MainUI.CustomControls;

namespace SimPe
{
	partial class OptionForm
	{
		private Panel ThemPanel;
		private Button button1;
		private CheckBox cbdebug;
		private CheckBox cbblur;
		private CheckBox cbsound;
		private Label label1;
		private ListBox lbext;
		private LinkLabel linkLabel1;
		private LinkLabel linkLabel2;
		private FolderBrowserDialog fbd;
		private Button button4;
		private TextBox tbdds;
		private Label label5;
		private OpenFileDialog ofd;
		private ToolTip toolTip1;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private CheckBox cbautobak;
		private CheckBox cbcache;
		private ComboBox cblang;
		private CheckBox cbow;
		private CheckBox cbsilent;
		private CheckBox cbwait;
		private Label label4;
		private Button button6;
		private TextBox tbthumb;
		private Label label8;
		private GroupBox groupBox3;
		private CheckBox cbshowobjd;
		private LinkLabel lldds2;
		private Label lldds;
		private LinkLabel lladd;
		private LinkLabel lldel;
		private LinkLabel lladddown;
		private CheckBox cbhidden;
		private CheckBox cbjointname;
		private Label label10;
		private TextBox tbscale;
		private GroupBox groupBox4;
		private CheckBox cbpkgmaint;
		private Panel hcFolders;
		private Panel hcSettings;
		private Panel hcTools;
		private Panel hcFileTable;
		private Panel hcSceneGraph;
		private Panel hcPlugins;
		private Panel hcIdent;
		private Panel hcCustom;
		private Panel hcCheck;
		private CheckBox cbmulti;
		private GroupBox groupBox5;
		private ComboBox cbThemes;
		private Button button7;
		private CheckBox cbSimple;
		private Panel cnt;
		private Button btpup;
		private Button btpdown;
		private GroupBox groupBox6;
		private CheckBox cbFirefox;
		private Button button8;
		private GroupBox groupBox7;
		private CheckBox cbDeep;
		private CheckBox cbAsync;
		private TextBox tbUsername;
		private Label label11;
		private TextBox tbPassword;
		private Button btcreateid;
		private TextBox tbUserid;
		private Label label7;
		private Label label12;
		private LinkLabel llchg;
		private CheckBox cbSimTemp;
		private CheckedListBox lbfolder;
		private Button btReload;
		private GroupBox groupBox8;
		private CheckBox cbIncCep;
		private GroupBox groupBox9;
		private LinkLabel linkLabel6;
		private Label label9;
		private ComboBox cbReport;
		private CheckBox cbLock;
		private MyPropertyGrid pgPaths;
		private CheckControl checkControl1;
		private ComboBox cbCustom;
		private PropertyGrid pgcustom;
		private CheckBox cbsplash;
		private GroupBox groupBox10;
		private CheckBox cbAsyncSort;
		private ComboBox cbRLExt;
		private ComboBox cbRLTGI;
		private ComboBox cbRLNames;
		private Label label17;
		private Label label16;
		private Label label15;
		private Panel panel1;
		private CheckBox cbexthemes;
		private LinkLabel lbAboot;
		private Button btNuffing;
		private Button btevryfing;
		private Panel hdFolders;
		private Panel hdFileTable;
		private Panel hdCheck;
		private Panel hdSettings;
		private Panel hdCustom;
		private Panel hdSceneGraph;
		private Panel hdPlugins;
		private Panel hdTools;
		private Panel hdIdent;
		private ToolStrip toolBar1;
		private ToolStripButton tbFolders;
		private ToolStripButton tbFileTable;
		private ToolStripButton tbCheck;
		private ToolStripButton tbSettings;
		private ToolStripButton tbCustom;
		private ToolStripButton tbSceneGraph;
		private ToolStripButton tbPlugins;
		private ToolStripButton tbTools;
		private ToolStripButton tbIdent;
		private CheckBox cbBigIcons;
		private CheckBox cbautostore;
		private CheckBox cbshowalls;
		private CheckBox cbtrimname;
		private Label lbBigIconNote;
		private GroupBox groupBox11;
		private CheckBox cbmoreskills;
		private CheckBox cbpetability;
		private System.ComponentModel.IContainer components;
		internal bool speady = false;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
			this.button1 = new System.Windows.Forms.Button();
			this.cbdebug = new System.Windows.Forms.CheckBox();
			this.cbblur = new System.Windows.Forms.CheckBox();
			this.cbsound = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbext = new System.Windows.Forms.ListBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.button4 = new System.Windows.Forms.Button();
			this.tbdds = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tbthumb = new System.Windows.Forms.TextBox();
			this.cbAsync = new System.Windows.Forms.CheckBox();
			this.cbhidden = new System.Windows.Forms.CheckBox();
			this.tbscale = new System.Windows.Forms.TextBox();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbBigIcons = new System.Windows.Forms.CheckBox();
			this.tbUserid = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cbautostore = new System.Windows.Forms.CheckBox();
			this.cbLock = new System.Windows.Forms.CheckBox();
			this.cbsplash = new System.Windows.Forms.CheckBox();
			this.lldds2 = new System.Windows.Forms.LinkLabel();
			this.lldds = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cbow = new System.Windows.Forms.CheckBox();
			this.cbshowobjd = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbReport = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbpkgmaint = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbautobak = new System.Windows.Forms.CheckBox();
			this.cbcache = new System.Windows.Forms.CheckBox();
			this.cblang = new System.Windows.Forms.ComboBox();
			this.cbsilent = new System.Windows.Forms.CheckBox();
			this.cbwait = new System.Windows.Forms.CheckBox();
			this.cbSimple = new System.Windows.Forms.CheckBox();
			this.cbmulti = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lladddown = new System.Windows.Forms.LinkLabel();
			this.lldel = new System.Windows.Forms.LinkLabel();
			this.lladd = new System.Windows.Forms.LinkLabel();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cbjointname = new System.Windows.Forms.CheckBox();
			this.hcFolders = new System.Windows.Forms.Panel();
			this.hdFolders = new Panel();
			this.pgPaths = new SimPe.OptionForm.MyPropertyGrid();
			this.hcSettings = new System.Windows.Forms.Panel();
			this.lbBigIconNote = new System.Windows.Forms.Label();
			this.hdSettings = new Panel();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cbFirefox = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cbexthemes = new System.Windows.Forms.CheckBox();
			this.cbThemes = new System.Windows.Forms.ComboBox();
			this.hcTools = new System.Windows.Forms.Panel();
			this.hdTools = new Panel();
			this.hcFileTable = new System.Windows.Forms.Panel();
			this.hdFileTable = new Panel();
			this.btReload = new System.Windows.Forms.Button();
			this.btevryfing = new System.Windows.Forms.Button();
			this.btNuffing = new System.Windows.Forms.Button();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.cbIncCep = new System.Windows.Forms.CheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.lbAboot = new System.Windows.Forms.LinkLabel();
			this.linkLabel6 = new System.Windows.Forms.LinkLabel();
			this.lbfolder = new System.Windows.Forms.CheckedListBox();
			this.llchg = new System.Windows.Forms.LinkLabel();
			this.hcSceneGraph = new System.Windows.Forms.Panel();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.cbmoreskills = new System.Windows.Forms.CheckBox();
			this.cbpetability = new System.Windows.Forms.CheckBox();
			this.hdSceneGraph = new Panel();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.cbAsyncSort = new System.Windows.Forms.CheckBox();
			this.cbRLExt = new System.Windows.Forms.ComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.cbRLTGI = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.cbRLNames = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.cbSimTemp = new System.Windows.Forms.CheckBox();
			this.cbDeep = new System.Windows.Forms.CheckBox();
			this.hcPlugins = new System.Windows.Forms.Panel();
			this.btpup = new System.Windows.Forms.Button();
			this.btpdown = new System.Windows.Forms.Button();
			this.cnt = new System.Windows.Forms.Panel();
			this.hdPlugins = new Panel();
			this.hcIdent = new System.Windows.Forms.Panel();
			this.hdIdent = new Panel();
			this.btcreateid = new System.Windows.Forms.Button();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.hcCheck = new System.Windows.Forms.Panel();
			this.hdCheck = new Panel();
			this.checkControl1 = new CheckControl();
			this.hcCustom = new System.Windows.Forms.Panel();
			this.cbCustom = new System.Windows.Forms.ComboBox();
			this.hdCustom = new Panel();
			this.pgcustom = new System.Windows.Forms.PropertyGrid();
			this.ThemPanel = new Panel();
			this.toolBar1 = new System.Windows.Forms.ToolStrip();
			this.tbFolders = new System.Windows.Forms.ToolStripButton();
			this.tbFileTable = new System.Windows.Forms.ToolStripButton();
			this.tbCheck = new System.Windows.Forms.ToolStripButton();
			this.tbSettings = new System.Windows.Forms.ToolStripButton();
			this.tbCustom = new System.Windows.Forms.ToolStripButton();
			this.tbSceneGraph = new System.Windows.Forms.ToolStripButton();
			this.tbPlugins = new System.Windows.Forms.ToolStripButton();
			this.tbTools = new System.Windows.Forms.ToolStripButton();
			this.tbIdent = new System.Windows.Forms.ToolStripButton();
			this.cbshowalls = new System.Windows.Forms.CheckBox();
			this.cbtrimname = new System.Windows.Forms.CheckBox();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.hcFolders.SuspendLayout();
			this.hcSettings.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.hcTools.SuspendLayout();
			this.hcFileTable.SuspendLayout();
			this.hdFileTable.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.hcSceneGraph.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.hcPlugins.SuspendLayout();
			this.hcIdent.SuspendLayout();
			this.hcCheck.SuspendLayout();
			this.hcCustom.SuspendLayout();
			this.ThemPanel.SuspendLayout();
			this.toolBar1.SuspendLayout();
			this.SuspendLayout();
			//
			// button1
			//
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.Click += new System.EventHandler(this.SaveOptionsClick);
			//
			// cbdebug
			//
			resources.ApplyResources(this.cbdebug, "cbdebug");
			this.cbdebug.Name = "cbdebug";
			//
			// cbblur
			//
			resources.ApplyResources(this.cbblur, "cbblur");
			this.cbblur.Name = "cbblur";
			this.cbblur.CheckedChanged += new System.EventHandler(this.cbblur_CheckedChanged);
			//
			// cbsound
			//
			resources.ApplyResources(this.cbsound, "cbsound");
			this.cbsound.Name = "cbsound";
			this.toolTip1.SetToolTip(this.cbsound, resources.GetString("cbsound.ToolTip"));
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// lbext
			//
			resources.ApplyResources(this.lbext, "lbext");
			this.lbext.Name = "lbext";
			//
			// linkLabel1
			//
			resources.ApplyResources(this.linkLabel1, "linkLabel1");
			this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabStop = true;
			this.linkLabel1.UseCompatibleTextRendering = true;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddExt);
			//
			// linkLabel2
			//
			resources.ApplyResources(this.linkLabel2, "linkLabel2");
			this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.TabStop = true;
			this.linkLabel2.UseCompatibleTextRendering = true;
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DeleteExt);
			//
			// button4
			//
			resources.ApplyResources(this.button4, "button4");
			this.button4.BackColor = System.Drawing.Color.Transparent;
			this.button4.Name = "button4";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			//
			// tbdds
			//
			resources.ApplyResources(this.tbdds, "tbdds");
			this.tbdds.Name = "tbdds";
			this.tbdds.TextChanged += new System.EventHandler(this.DDSChanged);
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Name = "label5";
			//
			// ofd
			//
			resources.ApplyResources(this.ofd, "ofd");
			//
			// tbthumb
			//
			resources.ApplyResources(this.tbthumb, "tbthumb");
			this.tbthumb.Name = "tbthumb";
			this.toolTip1.SetToolTip(this.tbthumb, resources.GetString("tbthumb.ToolTip"));
			//
			// cbAsync
			//
			resources.ApplyResources(this.cbAsync, "cbAsync");
			this.cbAsync.Name = "cbAsync";
			this.toolTip1.SetToolTip(this.cbAsync, resources.GetString("cbAsync.ToolTip"));
			//
			// cbhidden
			//
			resources.ApplyResources(this.cbhidden, "cbhidden");
			this.cbhidden.Name = "cbhidden";
			this.toolTip1.SetToolTip(this.cbhidden, resources.GetString("cbhidden.ToolTip"));
			this.cbhidden.CheckedChanged += new System.EventHandler(this.cbhidden_CheckedChanged);
			//
			// tbscale
			//
			resources.ApplyResources(this.tbscale, "tbscale");
			this.tbscale.Name = "tbscale";
			this.toolTip1.SetToolTip(this.tbscale, resources.GetString("tbscale.ToolTip"));
			//
			// button8
			//
			resources.ApplyResources(this.button8, "button8");
			this.button8.BackColor = System.Drawing.Color.Transparent;
			this.button8.Name = "button8";
			this.toolTip1.SetToolTip(this.button8, resources.GetString("button8.ToolTip"));
			this.button8.UseVisualStyleBackColor = false;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			//
			// button7
			//
			resources.ApplyResources(this.button7, "button7");
			this.button7.BackColor = System.Drawing.Color.Transparent;
			this.button7.Name = "button7";
			this.toolTip1.SetToolTip(this.button7, resources.GetString("button7.ToolTip"));
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += new System.EventHandler(this.ResetLayoutClick);
			//
			// panel1
			//
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
			//
			// cbBigIcons
			//
			resources.ApplyResources(this.cbBigIcons, "cbBigIcons");
			this.cbBigIcons.Name = "cbBigIcons";
			this.toolTip1.SetToolTip(this.cbBigIcons, resources.GetString("cbBigIcons.ToolTip"));
			this.cbBigIcons.UseVisualStyleBackColor = true;
			this.cbBigIcons.CheckedChanged += new System.EventHandler(this.cbBigIcons_CheckedChanged);
			//
			// tbUserid
			//
			resources.ApplyResources(this.tbUserid, "tbUserid");
			this.tbUserid.Name = "tbUserid";
			this.toolTip1.SetToolTip(this.tbUserid, resources.GetString("tbUserid.ToolTip"));
			//
			// label7
			//
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			this.toolTip1.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
			//
			// cbautostore
			//
			resources.ApplyResources(this.cbautostore, "cbautostore");
			this.cbautostore.BackColor = System.Drawing.Color.Transparent;
			this.cbautostore.Name = "cbautostore";
			this.cbautostore.UseVisualStyleBackColor = false;
			this.cbautostore.CheckedChanged += new System.EventHandler(this.cbautostore_CheckedChanged);
			//
			// cbLock
			//
			resources.ApplyResources(this.cbLock, "cbLock");
			this.cbLock.Name = "cbLock";
			this.cbLock.CheckedChanged += new System.EventHandler(this.cbLock_CheckedChanged);
			//
			// cbsplash
			//
			resources.ApplyResources(this.cbsplash, "cbsplash");
			this.cbsplash.Name = "cbsplash";
			//
			// lldds2
			//
			this.lldds2.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.lldds2, "lldds2");
			this.lldds2.ForeColor = System.Drawing.Color.Gray;
			this.lldds2.LinkColor = System.Drawing.Color.Red;
			this.lldds2.Name = "lldds2";
			this.lldds2.TabStop = true;
			this.lldds2.UseCompatibleTextRendering = true;
			this.lldds2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LoadDDS);
			//
			// lldds
			//
			this.lldds.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.lldds, "lldds");
			this.lldds.ForeColor = System.Drawing.Color.Gray;
			this.lldds.Name = "lldds";
			//
			// groupBox3
			//
			this.groupBox3.BackColor = System.Drawing.Color.Transparent;
			this.groupBox3.Controls.Add(this.cbtrimname);
			this.groupBox3.Controls.Add(this.cbshowalls);
			this.groupBox3.Controls.Add(this.cbow);
			this.groupBox3.Controls.Add(this.cbshowobjd);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.tbthumb);
			resources.ApplyResources(this.groupBox3, "groupBox3");
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.TabStop = false;
			//
			// cbow
			//
			resources.ApplyResources(this.cbow, "cbow");
			this.cbow.Name = "cbow";
			//
			// cbshowobjd
			//
			resources.ApplyResources(this.cbshowobjd, "cbshowobjd");
			this.cbshowobjd.Name = "cbshowobjd";
			//
			// label8
			//
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			//
			// button6
			//
			resources.ApplyResources(this.button6, "button6");
			this.button6.BackColor = System.Drawing.Color.Transparent;
			this.button6.Name = "button6";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new System.EventHandler(this.ClearCaches);
			//
			// groupBox2
			//
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.cbautostore);
			this.groupBox2.Controls.Add(this.cbBigIcons);
			this.groupBox2.Controls.Add(this.cbsplash);
			this.groupBox2.Controls.Add(this.cbLock);
			this.groupBox2.Controls.Add(this.cbReport);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.cbpkgmaint);
			this.groupBox2.Controls.Add(this.cbhidden);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.cbautobak);
			this.groupBox2.Controls.Add(this.cbcache);
			this.groupBox2.Controls.Add(this.cblang);
			this.groupBox2.Controls.Add(this.cbsilent);
			this.groupBox2.Controls.Add(this.cbwait);
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			//
			// cbReport
			//
			resources.ApplyResources(this.cbReport, "cbReport");
			this.cbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbReport.Name = "cbReport";
			//
			// label9
			//
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			//
			// cbpkgmaint
			//
			resources.ApplyResources(this.cbpkgmaint, "cbpkgmaint");
			this.cbpkgmaint.Name = "cbpkgmaint";
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// cbautobak
			//
			resources.ApplyResources(this.cbautobak, "cbautobak");
			this.cbautobak.Name = "cbautobak";
			this.cbautobak.CheckedChanged += new System.EventHandler(this.cbautobak_CheckedChanged);
			//
			// cbcache
			//
			resources.ApplyResources(this.cbcache, "cbcache");
			this.cbcache.Name = "cbcache";
			//
			// cblang
			//
			resources.ApplyResources(this.cblang, "cblang");
			this.cblang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cblang.Name = "cblang";
			//
			// cbsilent
			//
			resources.ApplyResources(this.cbsilent, "cbsilent");
			this.cbsilent.Name = "cbsilent";
			//
			// cbwait
			//
			resources.ApplyResources(this.cbwait, "cbwait");
			this.cbwait.Name = "cbwait";
			//
			// cbSimple
			//
			resources.ApplyResources(this.cbSimple, "cbSimple");
			this.cbSimple.Name = "cbSimple";
			//
			// cbmulti
			//
			resources.ApplyResources(this.cbmulti, "cbmulti");
			this.cbmulti.Name = "cbmulti";
			this.cbmulti.CheckedChanged += new System.EventHandler(this.cbmulti_CheckedChanged);
			//
			// groupBox1
			//
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.cbdebug);
			this.groupBox1.Controls.Add(this.cbblur);
			this.groupBox1.Controls.Add(this.cbsound);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			//
			// lladddown
			//
			resources.ApplyResources(this.lladddown, "lladddown");
			this.lladddown.Name = "lladddown";
			this.lladddown.TabStop = true;
			this.lladddown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lladddown_LinkClicked);
			//
			// lldel
			//
			resources.ApplyResources(this.lldel, "lldel");
			this.lldel.Name = "lldel";
			this.lldel.TabStop = true;
			this.lldel.UseCompatibleTextRendering = true;
			this.lldel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lldel_LinkClicked);
			//
			// lladd
			//
			resources.ApplyResources(this.lladd, "lladd");
			this.lladd.Name = "lladd";
			this.lladd.TabStop = true;
			this.lladd.UseCompatibleTextRendering = true;
			this.lladd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lladd_LinkClicked);
			//
			// groupBox4
			//
			resources.ApplyResources(this.groupBox4, "groupBox4");
			this.groupBox4.BackColor = System.Drawing.Color.Transparent;
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.tbscale);
			this.groupBox4.Controls.Add(this.cbjointname);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.TabStop = false;
			//
			// label10
			//
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			//
			// cbjointname
			//
			resources.ApplyResources(this.cbjointname, "cbjointname");
			this.cbjointname.Name = "cbjointname";
			//
			// hcFolders
			//
			this.hcFolders.Controls.Add(this.hdFolders);
			this.hcFolders.Controls.Add(this.pgPaths);
			resources.ApplyResources(this.hcFolders, "hcFolders");
			this.hcFolders.Name = "hcFolders";
			//
			// hdFolders
			//
			resources.ApplyResources(this.hdFolders, "hdFolders");
			this.hdFolders.Name = "hdFolders";
			//
			// pgPaths
			//
			this.pgPaths.CommandsBackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(this.pgPaths, "pgPaths");
			this.pgPaths.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pgPaths.Name = "pgPaths";
			this.pgPaths.ToolbarVisible = false;
			//
			// hcSettings
			//
			this.hcSettings.Controls.Add(this.lbBigIconNote);
			this.hcSettings.Controls.Add(this.hdSettings);
			this.hcSettings.Controls.Add(this.button8);
			this.hcSettings.Controls.Add(this.groupBox6);
			this.hcSettings.Controls.Add(this.groupBox5);
			this.hcSettings.Controls.Add(this.button6);
			this.hcSettings.Controls.Add(this.groupBox2);
			this.hcSettings.Controls.Add(this.groupBox1);
			this.hcSettings.Controls.Add(this.groupBox3);
			this.hcSettings.Controls.Add(this.button7);
			this.hcSettings.Controls.Add(this.button4);
			this.hcSettings.Controls.Add(this.tbdds);
			this.hcSettings.Controls.Add(this.label5);
			this.hcSettings.Controls.Add(this.lldds2);
			this.hcSettings.Controls.Add(this.lldds);
			resources.ApplyResources(this.hcSettings, "hcSettings");
			this.hcSettings.Name = "hcSettings";
			//
			// lbBigIconNote
			//
			resources.ApplyResources(this.lbBigIconNote, "lbBigIconNote");
			this.lbBigIconNote.Name = "lbBigIconNote";
			//
			// hdSettings
			//
			resources.ApplyResources(this.hdSettings, "hdSettings");
			this.hdSettings.Name = "hdSettings";
			//
			// groupBox6
			//
			resources.ApplyResources(this.groupBox6, "groupBox6");
			this.groupBox6.BackColor = System.Drawing.Color.Transparent;
			this.groupBox6.Controls.Add(this.cbFirefox);
			this.groupBox6.Controls.Add(this.cbSimple);
			this.groupBox6.Controls.Add(this.cbmulti);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.TabStop = false;
			//
			// cbFirefox
			//
			resources.ApplyResources(this.cbFirefox, "cbFirefox");
			this.cbFirefox.Name = "cbFirefox";
			//
			// groupBox5
			//
			resources.ApplyResources(this.groupBox5, "groupBox5");
			this.groupBox5.BackColor = System.Drawing.Color.Transparent;
			this.groupBox5.Controls.Add(this.cbexthemes);
			this.groupBox5.Controls.Add(this.cbThemes);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.TabStop = false;
			//
			// cbexthemes
			//
			resources.ApplyResources(this.cbexthemes, "cbexthemes");
			this.cbexthemes.Name = "cbexthemes";
			this.cbexthemes.UseVisualStyleBackColor = true;
			this.cbexthemes.CheckedChanged += new System.EventHandler(this.cbexthemes_CheckedChanged);
			//
			// cbThemes
			//
			resources.ApplyResources(this.cbThemes, "cbThemes");
			this.cbThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbThemes.Name = "cbThemes";
			this.cbThemes.SelectedIndexChanged += new System.EventHandler(this.ChangedThemeHandler);
			//
			// hcTools
			//
			this.hcTools.Controls.Add(this.hdTools);
			this.hcTools.Controls.Add(this.lbext);
			this.hcTools.Controls.Add(this.linkLabel1);
			this.hcTools.Controls.Add(this.linkLabel2);
			this.hcTools.Controls.Add(this.label1);
			resources.ApplyResources(this.hcTools, "hcTools");
			this.hcTools.Name = "hcTools";
			//
			// hdTools
			//
			resources.ApplyResources(this.hdTools, "hdTools");
			this.hdTools.Name = "hdTools";
			//
			// hcFileTable
			//
			this.hcFileTable.Controls.Add(this.hdFileTable);
			this.hcFileTable.Controls.Add(this.btevryfing);
			this.hcFileTable.Controls.Add(this.btNuffing);
			this.hcFileTable.Controls.Add(this.groupBox8);
			this.hcFileTable.Controls.Add(this.groupBox9);
			resources.ApplyResources(this.hcFileTable, "hcFileTable");
			this.hcFileTable.Name = "hcFileTable";
			//
			// hdFileTable
			//
			this.hdFileTable.Controls.Add(this.btReload);
			resources.ApplyResources(this.hdFileTable, "hdFileTable");
			this.hdFileTable.Name = "hdFileTable";
			//
			// btReload
			//
			this.btReload.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.btReload, "btReload");
			this.btReload.Name = "btReload";
			this.btReload.UseVisualStyleBackColor = false;
			this.btReload.Click += new System.EventHandler(this.btReload_Click);
			//
			// btevryfing
			//
			this.btevryfing.BackColor = System.Drawing.Color.Transparent;
			this.btevryfing.ForeColor = System.Drawing.Color.DarkBlue;
			resources.ApplyResources(this.btevryfing, "btevryfing");
			this.btevryfing.Name = "btevryfing";
			this.btevryfing.UseVisualStyleBackColor = false;
			this.btevryfing.Click += new System.EventHandler(this.btevryfing_Click);
			//
			// btNuffing
			//
			this.btNuffing.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.btNuffing, "btNuffing");
			this.btNuffing.ForeColor = System.Drawing.Color.DarkBlue;
			this.btNuffing.Name = "btNuffing";
			this.btNuffing.UseVisualStyleBackColor = false;
			this.btNuffing.Click += new System.EventHandler(this.btNuffing_Click);
			//
			// groupBox8
			//
			this.groupBox8.BackColor = System.Drawing.Color.Transparent;
			this.groupBox8.Controls.Add(this.cbIncCep);
			resources.ApplyResources(this.groupBox8, "groupBox8");
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.TabStop = false;
			//
			// cbIncCep
			//
			resources.ApplyResources(this.cbIncCep, "cbIncCep");
			this.cbIncCep.Name = "cbIncCep";
			this.cbIncCep.CheckedChanged += new System.EventHandler(this.cbIncNightlife_CheckedChanged);
			//
			// groupBox9
			//
			this.groupBox9.BackColor = System.Drawing.Color.Transparent;
			this.groupBox9.Controls.Add(this.lbAboot);
			this.groupBox9.Controls.Add(this.linkLabel6);
			this.groupBox9.Controls.Add(this.lldel);
			this.groupBox9.Controls.Add(this.lladddown);
			this.groupBox9.Controls.Add(this.lbfolder);
			this.groupBox9.Controls.Add(this.llchg);
			this.groupBox9.Controls.Add(this.lladd);
			resources.ApplyResources(this.groupBox9, "groupBox9");
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.TabStop = false;
			//
			// lbAboot
			//
			resources.ApplyResources(this.lbAboot, "lbAboot");
			this.lbAboot.LinkColor = System.Drawing.Color.DarkBlue;
			this.lbAboot.Name = "lbAboot";
			this.lbAboot.TabStop = true;
			this.lbAboot.UseCompatibleTextRendering = true;
			this.lbAboot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAboot_LinkClicked);
			//
			// linkLabel6
			//
			resources.ApplyResources(this.linkLabel6, "linkLabel6");
			this.linkLabel6.Name = "linkLabel6";
			this.linkLabel6.TabStop = true;
			this.linkLabel6.UseCompatibleTextRendering = true;
			this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel6_LinkClicked);
			//
			// lbfolder
			//
			resources.ApplyResources(this.lbfolder, "lbfolder");
			this.lbfolder.CheckOnClick = true;
			this.lbfolder.Name = "lbfolder";
			this.lbfolder.SelectedIndexChanged += new System.EventHandler(this.lbfolder_SelectedIndexChanged);
			this.lbfolder.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbfolder_ItemCheck);
			//
			// llchg
			//
			resources.ApplyResources(this.llchg, "llchg");
			this.llchg.Name = "llchg";
			this.llchg.TabStop = true;
			this.llchg.UseCompatibleTextRendering = true;
			this.llchg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llchg_LinkClicked);
			//
			// hcSceneGraph
			//
			this.hcSceneGraph.Controls.Add(this.groupBox11);
			this.hcSceneGraph.Controls.Add(this.hdSceneGraph);
			this.hcSceneGraph.Controls.Add(this.groupBox10);
			this.hcSceneGraph.Controls.Add(this.groupBox7);
			this.hcSceneGraph.Controls.Add(this.groupBox4);
			resources.ApplyResources(this.hcSceneGraph, "hcSceneGraph");
			this.hcSceneGraph.Name = "hcSceneGraph";
			//
			// groupBox11
			//
			this.groupBox11.Controls.Add(this.cbmoreskills);
			this.groupBox11.Controls.Add(this.cbpetability);
			resources.ApplyResources(this.groupBox11, "groupBox11");
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.TabStop = false;
			//
			// cbpetability
			//
			resources.ApplyResources(this.cbpetability, "cbpetability");
			this.cbpetability.Name = "cbpetability";
			this.cbpetability.UseVisualStyleBackColor = true;
			this.cbpetability.CheckedChanged += new System.EventHandler(this.cbpetability_CheckedChanged);
			//
			// cbmoreskills
			//
			resources.ApplyResources(this.cbmoreskills, "cbmoreskills");
			this.cbmoreskills.Name = "cbmoreskills";
			this.cbmoreskills.UseVisualStyleBackColor = true;
			this.cbmoreskills.CheckedChanged += new System.EventHandler(this.cbmoreskills_CheckedChanged);
			//
			// hdSceneGraph
			//
			resources.ApplyResources(this.hdSceneGraph, "hdSceneGraph");
			this.hdSceneGraph.Name = "hdSceneGraph";
			//
			// groupBox10
			//
			resources.ApplyResources(this.groupBox10, "groupBox10");
			this.groupBox10.BackColor = System.Drawing.Color.Transparent;
			this.groupBox10.Controls.Add(this.cbAsyncSort);
			this.groupBox10.Controls.Add(this.cbRLExt);
			this.groupBox10.Controls.Add(this.cbAsync);
			this.groupBox10.Controls.Add(this.label17);
			this.groupBox10.Controls.Add(this.cbRLTGI);
			this.groupBox10.Controls.Add(this.label16);
			this.groupBox10.Controls.Add(this.cbRLNames);
			this.groupBox10.Controls.Add(this.label15);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.TabStop = false;
			//
			// cbAsyncSort
			//
			resources.ApplyResources(this.cbAsyncSort, "cbAsyncSort");
			this.cbAsyncSort.Name = "cbAsyncSort";
			//
			// cbRLExt
			//
			this.cbRLExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(this.cbRLExt, "cbRLExt");
			this.cbRLExt.Name = "cbRLExt";
			//
			// label17
			//
			resources.ApplyResources(this.label17, "label17");
			this.label17.Name = "label17";
			//
			// cbRLTGI
			//
			this.cbRLTGI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(this.cbRLTGI, "cbRLTGI");
			this.cbRLTGI.Name = "cbRLTGI";
			//
			// label16
			//
			resources.ApplyResources(this.label16, "label16");
			this.label16.Name = "label16";
			//
			// cbRLNames
			//
			this.cbRLNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(this.cbRLNames, "cbRLNames");
			this.cbRLNames.Name = "cbRLNames";
			//
			// label15
			//
			resources.ApplyResources(this.label15, "label15");
			this.label15.Name = "label15";
			//
			// groupBox7
			//
			resources.ApplyResources(this.groupBox7, "groupBox7");
			this.groupBox7.BackColor = System.Drawing.Color.Transparent;
			this.groupBox7.Controls.Add(this.cbSimTemp);
			this.groupBox7.Controls.Add(this.cbDeep);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.TabStop = false;
			//
			// cbSimTemp
			//
			resources.ApplyResources(this.cbSimTemp, "cbSimTemp");
			this.cbSimTemp.Name = "cbSimTemp";
			//
			// cbDeep
			//
			resources.ApplyResources(this.cbDeep, "cbDeep");
			this.cbDeep.Name = "cbDeep";
			this.cbDeep.CheckedChanged += new System.EventHandler(this.cbDeep_CheckedChanged);
			//
			// hcPlugins
			//
			this.hcPlugins.BackColor = System.Drawing.Color.Transparent;
			this.hcPlugins.Controls.Add(this.btpup);
			this.hcPlugins.Controls.Add(this.btpdown);
			this.hcPlugins.Controls.Add(this.cnt);
			this.hcPlugins.Controls.Add(this.hdPlugins);
			resources.ApplyResources(this.hcPlugins, "hcPlugins");
			this.hcPlugins.Name = "hcPlugins";
			//
			// btpup
			//
			resources.ApplyResources(this.btpup, "btpup");
			this.btpup.BackColor = System.Drawing.Color.Transparent;
			this.btpup.Name = "btpup";
			this.btpup.UseVisualStyleBackColor = false;
			this.btpup.Click += new System.EventHandler(this.btpup_Click);
			//
			// btpdown
			//
			resources.ApplyResources(this.btpdown, "btpdown");
			this.btpdown.BackColor = System.Drawing.Color.Transparent;
			this.btpdown.Name = "btpdown";
			this.btpdown.UseVisualStyleBackColor = false;
			this.btpdown.Click += new System.EventHandler(this.btpdown_Click);
			//
			// cnt
			//
			resources.ApplyResources(this.cnt, "cnt");
			this.cnt.BackColor = System.Drawing.Color.Transparent;
			this.cnt.Name = "cnt";
			//
			// hdPlugins
			//
			resources.ApplyResources(this.hdPlugins, "hdPlugins");
			this.hdPlugins.Name = "hdPlugins";
			//
			// hcIdent
			//
			this.hcIdent.Controls.Add(this.hdIdent);
			this.hcIdent.Controls.Add(this.btcreateid);
			this.hcIdent.Controls.Add(this.tbUserid);
			this.hcIdent.Controls.Add(this.label7);
			this.hcIdent.Controls.Add(this.tbPassword);
			this.hcIdent.Controls.Add(this.label12);
			this.hcIdent.Controls.Add(this.tbUsername);
			this.hcIdent.Controls.Add(this.label11);
			resources.ApplyResources(this.hcIdent, "hcIdent");
			this.hcIdent.Name = "hcIdent";
			//
			// hdIdent
			//
			resources.ApplyResources(this.hdIdent, "hdIdent");
			this.hdIdent.Name = "hdIdent";
			//
			// btcreateid
			//
			resources.ApplyResources(this.btcreateid, "btcreateid");
			this.btcreateid.Name = "btcreateid";
			this.btcreateid.UseVisualStyleBackColor = true;
			this.btcreateid.Click += new System.EventHandler(this.btcreateid_Click);
			//
			// tbPassword
			//
			resources.ApplyResources(this.tbPassword, "tbPassword");
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Leave += new System.EventHandler(this.tbPassword_Leave);
			//
			// label12
			//
			this.label12.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			//
			// tbUsername
			//
			resources.ApplyResources(this.tbUsername, "tbUsername");
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Leave += new System.EventHandler(this.tbPassword_Leave);
			//
			// label11
			//
			this.label11.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			//
			// hcCheck
			//
			this.hcCheck.Controls.Add(this.hdCheck);
			this.hcCheck.Controls.Add(this.checkControl1);
			resources.ApplyResources(this.hcCheck, "hcCheck");
			this.hcCheck.Name = "hcCheck";
			//
			// hdCheck
			//
			resources.ApplyResources(this.hdCheck, "hdCheck");
			this.hdCheck.Name = "hdCheck";
			//
			// checkControl1
			//
			this.checkControl1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.checkControl1, "checkControl1");
			this.checkControl1.Name = "checkControl1";
			this.checkControl1.FixedFileTable += new System.EventHandler(this.checkControl1_FixedFileTable);
			//
			// hcCustom
			//
			this.hcCustom.Controls.Add(this.cbCustom);
			this.hcCustom.Controls.Add(this.hdCustom);
			this.hcCustom.Controls.Add(this.pgcustom);
			resources.ApplyResources(this.hcCustom, "hcCustom");
			this.hcCustom.Name = "hcCustom";
			//
			// cbCustom
			//
			resources.ApplyResources(this.cbCustom, "cbCustom");
			this.cbCustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCustom.Name = "cbCustom";
			this.cbCustom.SelectedIndexChanged += new System.EventHandler(this.cbCustom_SelectedIndexChanged);
			//
			// hdCustom
			//
			resources.ApplyResources(this.hdCustom, "hdCustom");
			this.hdCustom.Name = "hdCustom";
			//
			// pgcustom
			//
			resources.ApplyResources(this.pgcustom, "pgcustom");
			this.pgcustom.CommandsBackColor = System.Drawing.SystemColors.Window;
			this.pgcustom.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.pgcustom.Name = "pgcustom";
			//
			// ThemPanel
			//
			resources.ApplyResources(this.ThemPanel, "ThemPanel");
			this.ThemPanel.BackColor = System.Drawing.Color.Transparent;
			this.ThemPanel.Controls.Add(this.toolBar1);
			this.ThemPanel.Controls.Add(this.button1);
			this.ThemPanel.Controls.Add(this.hcFolders);
			this.ThemPanel.Controls.Add(this.panel1);
			this.ThemPanel.Controls.Add(this.hcFileTable);
			this.ThemPanel.Controls.Add(this.hcCheck);
			this.ThemPanel.Controls.Add(this.hcSettings);
			this.ThemPanel.Controls.Add(this.hcSceneGraph);
			this.ThemPanel.Controls.Add(this.hcCustom);
			this.ThemPanel.Controls.Add(this.hcPlugins);
			this.ThemPanel.Controls.Add(this.hcTools);
			this.ThemPanel.Controls.Add(this.hcIdent);
			this.ThemPanel.Name = "ThemPanel";
			//
			// toolBar1
			//
			resources.ApplyResources(this.toolBar1, "toolBar1");
			this.toolBar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBar1.ImageScalingSize = new System.Drawing.Size(44, 44);
			this.toolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tbFolders,
			this.tbFileTable,
			this.tbCheck,
			this.tbSettings,
			this.tbCustom,
			this.tbSceneGraph,
			this.tbPlugins,
			this.tbTools,
			this.tbIdent});
			this.toolBar1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.toolBar1.MaximumSize = new System.Drawing.Size(101, 0);
			this.toolBar1.Name = "toolBar1";
			//
			// tbFolders
			//
			this.tbFolders.Checked = true;
			this.tbFolders.CheckState = System.Windows.Forms.CheckState.Checked;
			resources.ApplyResources(this.tbFolders, "tbFolders");
			this.tbFolders.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
			this.tbFolders.Name = "tbFolders";
			this.tbFolders.Click += new System.EventHandler(this.ChoosePage);
			//
			// tbFileTable
			//
			resources.ApplyResources(this.tbFileTable, "tbFileTable");
			this.tbFileTable.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
			this.tbFileTable.Name = "tbFileTable";
			this.tbFileTable.Click += new System.EventHandler(this.ChoosePage);
			//
			// tbCheck
			//
			resources.ApplyResources(this.tbCheck, "tbCheck");
			this.tbCheck.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
			this.tbCheck.Name = "tbCheck";
			this.tbCheck.Click += new System.EventHandler(this.ChoosePage);
			//
			// tbSettings
			//
			resources.ApplyResources(this.tbSettings, "tbSettings");
			this.tbSettings.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
			this.tbSettings.Name = "tbSettings";
			this.tbSettings.Click += new System.EventHandler(this.ChoosePage);
			//
			// tbCustom
			//
			resources.ApplyResources(this.tbCustom, "tbCustom");
			this.tbCustom.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
			this.tbCustom.Name = "tbCustom";
			this.tbCustom.Click += new System.EventHandler(this.ChoosePage);
			//
			// tbSceneGraph
			//
			resources.ApplyResources(this.tbSceneGraph, "tbSceneGraph");
			this.tbSceneGraph.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
			this.tbSceneGraph.Name = "tbSceneGraph";
			this.tbSceneGraph.Click += new System.EventHandler(this.ChoosePage);
			//
			// tbPlugins
			//
			resources.ApplyResources(this.tbPlugins, "tbPlugins");
			this.tbPlugins.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
			this.tbPlugins.Name = "tbPlugins";
			this.tbPlugins.Click += new System.EventHandler(this.ChoosePage);
			//
			// tbTools
			//
			resources.ApplyResources(this.tbTools, "tbTools");
			this.tbTools.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
			this.tbTools.Name = "tbTools";
			this.tbTools.Click += new System.EventHandler(this.ChoosePage);
			//
			// tbIdent
			//
			resources.ApplyResources(this.tbIdent, "tbIdent");
			this.tbIdent.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
			this.tbIdent.Name = "tbIdent";
			this.tbIdent.Click += new System.EventHandler(this.ChoosePage);
			//
			// cbtrimname
			//
			resources.ApplyResources(this.cbtrimname, "cbtrimname");
			this.cbtrimname.Name = "cbtrimname";
			this.cbtrimname.CheckedChanged += new System.EventHandler(this.cbtrimname_CheckedChanged);
			//
			// cbshowalls
			//
			resources.ApplyResources(this.cbshowalls, "cbshowalls");
			this.cbshowalls.Name = "cbshowalls";
			this.cbshowalls.CheckedChanged += new System.EventHandler(this.cbshowalls_CheckedChanged);
			//
			// OptionForm
			//
			resources.ApplyResources(this, "$this");
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.ThemPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionForm";
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.hcFolders.ResumeLayout(false);
			this.hcSettings.ResumeLayout(false);
			this.hcSettings.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.hcTools.ResumeLayout(false);
			this.hcTools.PerformLayout();
			this.hcFileTable.ResumeLayout(false);
			this.hdFileTable.ResumeLayout(false);
			this.hdFileTable.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.hcSceneGraph.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.hcPlugins.ResumeLayout(false);
			this.hcIdent.ResumeLayout(false);
			this.hcIdent.PerformLayout();
			this.hcCheck.ResumeLayout(false);
			this.hcCustom.ResumeLayout(false);
			this.ThemPanel.ResumeLayout(false);
			this.ThemPanel.PerformLayout();
			this.toolBar1.ResumeLayout(false);
			this.toolBar1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
