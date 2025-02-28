// SPDX-FileCopyrightText: © 2005 Ambertation and SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SimPe.Events;
using Ambertation.Windows.Forms;

namespace SimPe
{
    partial class MainForm
    {
        private ToolStripContainer tbContainer;
        private OpenFileDialog ofd;
        private SaveFileDialog sfd;
        private Panel GradientPanel1;
        private Panel GradientPanel2;
        private SteepValley.Windows.Forms.ThemedControls.XPTaskBox tbDefaultAction;
        private SteepValley.Windows.Forms.ThemedControls.XPTaskBox tbExtAction;
        private SteepValley.Windows.Forms.ThemedControls.XPTaskBox tbPlugAction;
        private ToolStrip toolBar1;
        private ToolStrip tbAction;
        private ToolStrip tbTools;
        private ToolStrip tbWindow;
        private ToolStripButton biNewDc;
        private ToolStripButton biOpen;
        private ToolStripButton biSave;
	    private ToolStripB
	{
		private ToolStripButton biNew;
		private ToolStripButton biReset;
		private ToolStripSeparator toolStripMenuItem1;
		private ToolStripSeparator toolStripMenuItem2;
		private ToolStripSeparator toolStripMenuItem3;
		private MenuStrip menuBar1;
		private ContextMenuStrip miAction;
		private ToolStripMenuItem miSaveAs;
		private ToolStripMenuItem miClose;
		private ToolStripMenuItem menuBarItem1;
		private ToolStripMenuItem menuBarItem5;
		private ToolStripMenuItem miRecent;
		private ToolStripMenuItem miObjects;
		private ToolStripMenuItem miExtra;
		private ToolStripMenuItem miTools;
		private ToolStripMenuItem miNewDc;
		private ToolStripMenuItem miMetaInfo;
		private ToolStripMenuItem miFileNames;
		private ToolStripMenuItem miExit;
		private ToolStripMenuItem miRunSims;
		private ToolStripMenuItem miWindow;
		private ToolStripMenuItem miSave;
		private ToolStripMenuItem miOpen;
		private ToolStripMenuItem miPref;
		private ToolStripMenuItem miNew;
		private ToolStripMenuItem miAbout;
		private ToolStripMenuItem miKBase;
		private ToolStripMenuItem miOpenIn;
		private ToolStripMenuItem miOpenSimsRes;
		private ToolStripMenuItem miOpenDownloads;
		private ToolStripMenuItem miSaveCopyAs;
		private ToolStripMenuItem mbiTopics;
		private ToolStripMenuItem miShowName;
		private ToolStripMenuItem miReloadL;
		private ToolStripMenuItem tsmiSaveProfile;
		private ToolStripMenuItem tsmiSavePrefs;
		private ToolStripMenuItem tsmiStopWaiting;
		private LinkLabel xpLinkedLabelIcon1;
		private LinkLabel xpLinkedLabelIcon2;
		private LinkLabel xpLinkedLabelIcon3;
		private Label label3;
		private Label label2;
		private Label label1;
		private Label label5;
		private TextBox tbInst;
		private TextBox tbGrp;
		private TextBox tbRcolName;
		private ComboBox cbsemig;
		private TD.SandDock.TabControl dc;
		private DockManager manager;
		private DockPanel dcPlugin;
		private DockPanel dcAction;
		private DockPanel dcFilter;
		private DockPanel dcResource;
		private DockContainer dockLeft;
		private DockContainer dockRight;
		private DockContainer dockBottom;
		private DockContainer dockCenter;
		private DockPanel dcResourceList;
		private SimPe.Windows.Forms.ResourceListViewExt lv;
		private SimPe.Windows.Forms.ResourceTreeViewExt tv;
		private SimPe.Windows.Forms.ResourceViewManager resourceViewManager1;
		private System.ComponentModel.IContainer components;
		internal WaitControl waitControl1;
		
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
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			{
				em.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
				{
					ager = new Ambertation.Windows.Forms.DockManager();
				}
			}
			this.miAction = new ContextMenuStrip(this.components);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		    this.tbPlugAction = new SteepValley.Windows.Forms.ThemedControls.XPTaskBox();
		{
			this.dcFilter = new Ambertation.Windows.Forms.DockPanel();
			this.GradientPanel1 = new Panel();
			this.label1 = new Label();
			this.label5 = new Label();
			this.cbsemig = new ComboBox();
			this.tbRcolName = new TextBox();
			this.tbInst = new TextBox();
			this.tbGrp = new TextBox();
			this.label3 = new Label();
			this.label2 = new Label();
			this.xpLinkedLabelIcon3 = new LinkLabel();
			this.xpLinkedLabelIcon2 = new LinkLabel();
			this.xpLinkedLabelIcon1 = new LinkLabel();
			this.dockBottom = new Ambertation.Windows.Forms.DockContainer();
			this.dcPlugin = new Ambertation.Windows.Forms.DockPanel();
			this.dc = new TD.SandDock.TabControl();
			this.toolBar1 = new ToolStrip();
			this.biNew = new ToolStripButton();
			this.biOpen = new ToolStripButton();
			this.biSave = new ToolStripButton();
			this.biSaveAs = new ToolStripButton();
			this.biClose = new ToolStripButton();
			this.biReset = new ToolStripButton();
			this.tbAction = new ToolStrip();
			this.tbWindow = new ToolStrip();
			this.tbTools = new ToolStrip();
			this.biNewDc = new ToolStripButton();
			this.dockCenter = new Ambertation.Windows.Forms.DockContainer();
			this.ofd = new OpenFileDialog();
			this.miNew = new ToolStripMenuItem();
			this.miOpen = new ToolStripMenuItem();
			this.miSave = new ToolStripMenuItem();
			this.miSaveAs = new ToolStripMenuItem();
			this.miClose = new ToolStripMenuItem();
			this.miNewDc = new ToolStripMenuItem();
			this.menuBar1 = new MenuStrip();
			this.menuBarItem1 = new ToolStripMenuItem();
			this.miOpenIn = new ToolStripMenuItem();
			this.miOpenSimsRes = new ToolStripMenuItem();
			this.miOpenDownloads = new ToolStripMenuItem();
			this.miShowName = new ToolStripMenuItem();
			this.miReloadL = new ToolStripMenuItem();
			this.miSaveCopyAs = new ToolStripMenuItem();
			this.miRecent = new ToolStripMenuItem();
			this.miObjects = new ToolStripMenuItem();
			this.toolStripMenuItem1 = new ToolStripSeparator();
			this.miExit = new ToolStripMenuItem();
			this.miTools = new ToolStripMenuItem();
			this.miExtra = new ToolStripMenuItem();
			this.miMetaInfo = new ToolStripMenuItem();
			this.miFileNames = new ToolStripMenuItem();
			this.miRunSims = new ToolStripMenuItem();
			this.toolStripMenuItem2 = new ToolStripSeparator();
			this.miPref = new ToolStripMenuItem();
			this.tsmiSaveProfile = new ToolStripMenuItem();
			this.tsmiSavePrefs = new ToolStripMenuItem();
			this.miWindow = new ToolStripMenuItem();
			this.menuBarItem5 = new ToolStripMenuItem();
			this.miKBase = new ToolStripMenuItem();
			this.mbiTopics = new ToolStripMenuItem();
			this.toolStripMenuItem3 = new ToolStripSeparator();
			this.miAbout = new ToolStripMenuItem();
			this.tsmiStopWaiting = new ToolStripMenuItem();
			this.sfd = new SaveFileDialog();
			this.waitControl1 = new SimPe.WaitControl();
			this.resourceViewManager1 = new SimPe.Windows.Forms.ResourceViewManager();
			this.tbContainer.ContentPanel.SuspendLayout();
			this.tbContainer.TopToolStripPanel.SuspendLayout();
			this.tbContainer.SuspendLayout();
			this.manager.SuspendLayout();
			this.dcResourceList.SuspendLayout();
			this.dockLeft.SuspendLayout();
			this.dcResource.SuspendLayout();
			this.dockRight.SuspendLayout();
			this.dcAction.SuspendLayout();
			this.GradientPanel2.SuspendLayout();
			this.dcFilter.SuspendLayout();
			this.GradientPanel1.SuspendLayout();
			this.dockBottom.SuspendLayout();
			this.dcPlugin.SuspendLayout();
			this.toolBar1.SuspendLayout();
			this.menuBar1.SuspendLayout();
			this.SuspendLayout();
			//
			// tbContainer
			//
			//
			// tbContainer.ContentPanel
			//
			this.tbContainer.ContentPanel.Controls.Add(this.manager);
			resources.ApplyResources(this.tbContainer.ContentPanel, "tbContainer.ContentPanel");
			resources.ApplyResources(this.tbContainer, "tbContainer");
			this.tbContainer.Name = "tbContainer";
			//
			// tbContainer.TopToolStripPanel
			//
			this.tbContainer.TopToolStripPanel.Controls.Add(this.toolBar1);
			this.tbContainer.TopToolStripPanel.Controls.Add(this.tbAction);
			this.tbContainer.TopToolStripPanel.Controls.Add(this.tbWindow);
			this.tbContainer.TopToolStripPanel.Controls.Add(this.tbTools);
			// 
			// tbContainer
			// 
			// 
			// tbContainer.ContentPanel
			// 
			this.manager.Controls.Add(this.dockBottom);
			this.manager.DefaultSize = new System.Drawing.Size(100, 100);
			resources.ApplyResources(this.manager, "manager");
			this.manager.DragBorder = true;
			// 
			// tbContainer.TopToolStripPanel
			// 
			this.manager.NoCleanup = true;
			this.manager.Renderer = whidbeyRenderer1;
			this.manager.TabImage = null;
			this.manager.TabText = "";
			// 
			// manager
			// 
			this.dcResourceList.AllowClose = true;
			this.dcResourceList.AllowCollapse = true;
			this.dcResourceList.AllowDockBottom = true;
			this.dcResourceList.AllowDockCenter = true;
			this.dcResourceList.AllowDockLeft = true;
			this.dcResourceList.AllowDockRight = true;
			this.dcResourceList.AllowDockTop = true;
			this.dcResourceList.AllowFloat = true;
			resources.ApplyResources(this.dcResourceList, "dcResourceList");
			this.dcResourceList.CanResize = true;
			this.dcResourceList.CanUndock = true;
			this.dcResourceList.Controls.Add(this.lv);
			this.dcResourceList.DockContainer = this.manager;
			this.dcResourceList.DragBorder = false;
			// 
			// dcResourceList
			// 
			this.dcResourceList.Name = "dcResourceList";
			this.dcResourceList.ShowCloseButton = true;
			this.dcResourceList.ShowCollapseButton = true;
			this.dcResourceList.TabImage = ((System.Drawing.Image)(resources.GetObject("dcResourceList.TabImage")));
			this.dcResourceList.TabText = "List";
			this.dcResourceList.UndockByCaptionThreshold = 150;
			//
			// lv
			//
			this.lv.AllowDrop = true;
			resources.ApplyResources(this.lv, "lv");
			this.lv.ContextMenuStrip = this.miAction;
			this.lv.Filter = null;
			this.lv.Name = "lv";
			this.lv.SortedColumn = SimPe.Windows.Forms.ResourceViewManager.SortColumn.Offset;
			this.lv.SelectionChanged += new System.EventHandler(this.lv_SelectionChanged);
			this.lv.ListViewKeyUp += new KeyEventHandler(this.ResourceListKeyUp);
			this.lv.SelectedResource += new SimPe.Windows.Forms.ResourceListViewExt.SelectResourceHandler(this.lv_SelectResource);
			this.lv.DragDrop += new DragEventHandler(this.DragDropFile);
			this.lv.KeyUp += new KeyEventHandler(this.ResourceListKeyUp);
			this.lv.DragEnter += new DragEventHandler(this.DragEnterFile);
			//
			// miAction
			// 
			// lv
			// 
			//
			// dockLeft
			//
			this.dockLeft.Controls.Add(this.dcResource);
			resources.ApplyResources(this.dockLeft, "dockLeft");
			this.dockLeft.DragBorder = true;
			this.dockLeft.Manager = this.manager;
			this.dockLeft.MinimumSize = new System.Drawing.Size(150, 150);
			this.dockLeft.Name = "dockLeft";
			this.dockLeft.NoCleanup = false;
			this.dockLeft.TabImage = null;
			this.dockLeft.TabText = "";
			// 
			// miAction
			// 
			this.dcResource.AllowClose = true;
			this.dcResource.AllowCollapse = true;
			// 
			// dockLeft
			// 
			this.dcResource.AllowDockRight = true;
			this.dcResource.AllowDockTop = true;
			this.dcResource.AllowFloat = true;
			resources.ApplyResources(this.dcResource, "dcResource");
			this.dcResource.CanResize = true;
			this.dcResource.CanUndock = true;
			this.dcResource.Controls.Add(this.tv);
			this.dcResource.DockContainer = this.dockLeft;
			this.dcResource.DragBorder = false;
			// 
			// dcResource
			// 
			this.dcResource.Name = "dcResource";
			this.dcResource.ShowCloseButton = true;
			this.dcResource.ShowCollapseButton = true;
			this.dcResource.TabImage = ((System.Drawing.Image)(resources.GetObject("dcResource.TabImage")));
			this.dcResource.TabText = "Resource Tree";
			this.dcResource.UndockByCaptionThreshold = 150;
			//
			// tv
			//
			this.tv.AllowDrop = true;
			resources.ApplyResources(this.tv, "tv");
			this.tv.Name = "tv";
			this.tv.DragDrop += new DragEventHandler(this.DragDropFile);
			this.tv.DragEnter += new DragEventHandler(this.DragEnterFile);
			//
			// dockRight
			//
			resources.ApplyResources(this.dockRight, "dockRight");
			this.dockRight.DragBorder = true;
			this.dockRight.Manager = this.manager;
			this.dockRight.MinimumSize = new System.Drawing.Size(150, 150);
			this.dockRight.Name = "dockRight";
			this.dockRight.NoCleanup = false;
			// 
			// tv
			// 
			// dcAction
			//
			this.dcAction.AllowClose = true;
			this.dcAction.AllowCollapse = true;
			this.dcAction.AllowDockBottom = true;
			// 
			// dockRight
			// 
			this.dcAction.AllowDockTop = true;
			this.dcAction.AllowFloat = true;
			resources.ApplyResources(this.dcAction, "dcAction");
			this.dcAction.CanResize = true;
			this.dcAction.CanUndock = true;
			this.dcAction.Controls.Add(this.GradientPanel2);
			this.dcAction.DragBorder = false;
			this.dcAction.FloatingSize = new System.Drawing.Size(255, 290);
			// 
			// dcAction
			// 
			this.dcAction.ShowCloseButton = true;
			this.dcAction.ShowCollapseButton = true;
			this.dcAction.TabImage = ((System.Drawing.Image)(resources.GetObject("dcAction.TabImage")));
			this.dcAction.TabText = "Resource Actions";
			this.dcAction.UndockByCaptionThreshold = 150;
			//
			// GradientPanel2
			//
			resources.ApplyResources(this.GradientPanel2, "GradientPanel2");
			this.GradientPanel2.BackColor = System.Drawing.Color.Transparent;
			this.GradientPanel2.Controls.Add(this.tbExtAction);
			this.GradientPanel2.Controls.Add(this.tbPlugAction);
			this.GradientPanel2.Controls.Add(this.tbDefaultAction);
			this.GradientPanel2.Name = "GradientPanel2";
			//
			// tbExtAction
			//
			this.tbExtAction.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.tbExtAction, "tbExtAction");
			this.tbExtAction.Name = "tbExtAction";
			//
			// tbPlugAction
			// 
			// GradientPanel2
			// 
			this.tbPlugAction.Name = "tbPlugAction";
			//
			// tbDefaultAction
			//
			this.tbDefaultAction.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(this.tbDefaultAction, "tbDefaultAction");
			// 
			// tbExtAction
			// 
			//
			this.dcFilter.AllowClose = true;
			this.dcFilter.AllowCollapse = true;
			// 
			// tbPlugAction
			// 
			this.dcFilter.AllowDockRight = true;
			this.dcFilter.AllowDockTop = true;
			this.dcFilter.AllowFloat = true;
			// 
			// tbDefaultAction
			// 
			this.dcFilter.Controls.Add(this.GradientPanel1);
			this.dcFilter.DockContainer = this.dockBottom;
			this.dcFilter.DragBorder = false;
			// 
			// dcFilter
			// 
			this.dcFilter.Name = "dcFilter";
			this.dcFilter.ShowCloseButton = true;
			this.dcFilter.ShowCollapseButton = true;
			this.dcFilter.TabImage = ((System.Drawing.Image)(resources.GetObject("dcFilter.TabImage")));
			this.dcFilter.TabText = "Filter Resources";
			this.dcFilter.UndockByCaptionThreshold = 150;
			this.dcFilter.SizeChanged += new System.EventHandler(this.dcFilter_SizeChanged);
			//
			// GradientPanel1
			//
			this.GradientPanel1.BackColor = System.Drawing.Color.Transparent;
			this.GradientPanel1.Controls.Add(this.label1);
			this.GradientPanel1.Controls.Add(this.label5);
			this.GradientPanel1.Controls.Add(this.cbsemig);
			this.GradientPanel1.Controls.Add(this.tbRcolName);
			this.GradientPanel1.Controls.Add(this.tbInst);
			this.GradientPanel1.Controls.Add(this.tbGrp);
			this.GradientPanel1.Controls.Add(this.label3);
			this.GradientPanel1.Controls.Add(this.label2);
			this.GradientPanel1.Controls.Add(this.xpLinkedLabelIcon3);
			this.GradientPanel1.Controls.Add(this.xpLinkedLabelIcon2);
			this.GradientPanel1.Controls.Add(this.xpLinkedLabelIcon1);
			resources.ApplyResources(this.GradientPanel1, "GradientPanel1");
			this.GradientPanel1.Name = "GradientPanel1";
			// 
			// GradientPanel1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label1.Name = "label1";
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label5.Name = "label5";
			//
			// cbsemig
			//
			// 
			// label1
			// 
			this.cbsemig.Name = "cbsemig";
			//
			// tbRcolName
			//
			// 
			// label5
			// 
			// tbInst
			//
			resources.ApplyResources(this.tbInst, "tbInst");
			this.tbInst.Name = "tbInst";
			// 
			// cbsemig
			// 
			resources.ApplyResources(this.tbGrp, "tbGrp");
			this.tbGrp.Name = "tbGrp";
			//
			// label3
			// 
			// tbRcolName
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Name = "label3";
			// 
			// tbInst
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.BackColor = System.Drawing.Color.Transparent;
			// 
			// tbGrp
			// 
			// xpLinkedLabelIcon3
			//
			// 
			// label3
			// 
			this.xpLinkedLabelIcon3.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(99)))), ((int)(((byte)(50)))));
			this.xpLinkedLabelIcon3.LinkArea = new LinkArea(0, 7);
			this.xpLinkedLabelIcon3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.xpLinkedLabelIcon3.Name = "xpLinkedLabelIcon3";
			// 
			// label2
			// 
			// xpLinkedLabelIcon2
			//
			this.xpLinkedLabelIcon2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			resources.ApplyResources(this.xpLinkedLabelIcon2, "xpLinkedLabelIcon2");
			// 
			// xpLinkedLabelIcon3
			// 
			this.xpLinkedLabelIcon2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.xpLinkedLabelIcon2.Name = "xpLinkedLabelIcon2";
			this.xpLinkedLabelIcon2.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
			this.xpLinkedLabelIcon2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.SetRcolNameFilter);
			//
			// xpLinkedLabelIcon1
			//
			this.xpLinkedLabelIcon1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			resources.ApplyResources(this.xpLinkedLabelIcon1, "xpLinkedLabelIcon1");
			// 
			// xpLinkedLabelIcon2
			// 
			this.xpLinkedLabelIcon1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.xpLinkedLabelIcon1.Name = "xpLinkedLabelIcon1";
			this.xpLinkedLabelIcon1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
			this.xpLinkedLabelIcon1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.SetFilter);
			//
			// dockBottom
			//
			this.dockBottom.Controls.Add(this.dcAction);
			this.dockBottom.Controls.Add(this.dcFilter);
			// 
			// xpLinkedLabelIcon1
			// 
			this.dockBottom.Manager = this.manager;
			this.dockBottom.MinimumSize = new System.Drawing.Size(150, 150);
			this.dockBottom.Name = "dockBottom";
			this.dockBottom.NoCleanup = false;
			this.dockBottom.TabImage = null;
			this.dockBottom.TabText = "";
			//
			// dcPlugin
			//
			// 
			// dockBottom
			// 
			this.dcPlugin.AllowDockCenter = true;
			this.dcPlugin.AllowDockLeft = true;
			this.dcPlugin.AllowDockRight = true;
			this.dcPlugin.AllowDockTop = true;
			this.dcPlugin.AllowFloat = true;
			resources.ApplyResources(this.dcPlugin, "dcPlugin");
			this.dcPlugin.CanResize = true;
			this.dcPlugin.CanUndock = true;
			this.dcPlugin.Controls.Add(this.dc);
			this.dcPlugin.DockContainer = this.dockBottom;
			this.dcPlugin.DragBorder = false;
			// 
			// dcPlugin
			// 
			this.dcPlugin.Name = "dcPlugin";
			this.dcPlugin.ShowCloseButton = true;
			this.dcPlugin.ShowCollapseButton = true;
			this.dcPlugin.TabImage = ((System.Drawing.Image)(resources.GetObject("dcPlugin.TabImage")));
			this.dcPlugin.TabText = "Plugin View";
			this.dcPlugin.UndockByCaptionThreshold = 150;
			//
			// dc
			//
			resources.ApplyResources(this.dc, "dc");
			this.dc.LayoutSystem = new TD.SandDock.SplitLayoutSystem(250, 400, Orientation.Horizontal, new TD.SandDock.LayoutSystemBase[] {
			((TD.SandDock.LayoutSystemBase)(new TD.SandDock.DocumentLayoutSystem(903, 373, new TD.SandDock.DockControl[0], null)))});
			this.dc.Name = "dc";
			this.dc.MouseUp += new MouseEventHandler(this.dc_MouseUp);
			//
			// toolBar1
			//
			resources.ApplyResources(this.toolBar1, "toolBar1");
			this.toolBar1.Items.AddRange(new ToolStripItem[] {
			this.biNew,
			this.biOpen,
			this.biSave,
			this.biSaveAs,
			// 
			// dc
			// 
			//
			// biNew
			//
			resources.ApplyResources(this.biNew, "biNew");
			this.biNew.Name = "biNew";
			// 
			// toolBar1
			// 
			//
			resources.ApplyResources(this.biOpen, "biOpen");
			this.biOpen.Name = "biOpen";
			this.biOpen.Click += new System.EventHandler(this.Activate_miOpen);
			//
			// biSave
			//
			resources.ApplyResources(this.biSave, "biSave");
			this.biSave.Name = "biSave";
			// 
			// biNew
			// 
			//
			resources.ApplyResources(this.biSaveAs, "biSaveAs");
			this.biSaveAs.Name = "biSaveAs";
			// 
			// biOpen
			// 
			//
			resources.ApplyResources(this.biClose, "biClose");
			this.biClose.Name = "biClose";
			// 
			// biSave
			// 
			//
			resources.ApplyResources(this.biReset, "biReset");
			this.biReset.Name = "biReset";
			// 
			// biSaveAs
			// 
			//
			resources.ApplyResources(this.tbAction, "tbAction");
			this.tbAction.Name = "tbAction";
			// 
			// biClose
			// 
			resources.ApplyResources(this.tbWindow, "tbWindow");
			this.tbWindow.Name = "tbWindow";
			//
			// 
			// biReset
			// 
			this.tbTools.Name = "tbTools";
			//
			// biNewDc
			// 
			// tbAction
			// 
			this.biNewDc.Click += new System.EventHandler(this.CreateNewDocumentContainer);
			//
			// 
			// tbWindow
			// 
			this.dockCenter.DragBorder = true;
			this.dockCenter.Manager = this.manager;
			// 
			// tbTools
			// 
			this.dockCenter.TabImage = null;
			this.dockCenter.TabText = "";
			// 
			// biNewDc
			// 
			resources.ApplyResources(this.ofd, "ofd");
			//
			// miNew
			// 
			// dockCenter
			// 
			this.miNew.Click += new System.EventHandler(this.Activate_miNew);
			//
			// miOpen
			//
			resources.ApplyResources(this.miOpen, "miOpen");
			this.miOpen.Name = "miOpen";
			this.miOpen.Click += new System.EventHandler(this.Activate_miOpen);
			//
			// 
			// ofd
			// 
			this.miSave.Name = "miSave";
			// 
			// miNew
			// 
			//
			resources.ApplyResources(this.miSaveAs, "miSaveAs");
			this.miSaveAs.Name = "miSaveAs";
			// 
			// miOpen
			// 
			//
			resources.ApplyResources(this.miClose, "miClose");
			this.miClose.Name = "miClose";
			// 
			// miSave
			// 
			//
			resources.ApplyResources(this.miNewDc, "miNewDc");
			this.miNewDc.Name = "miNewDc";
			// 
			// miSaveAs
			// 
			//
			this.menuBar1.Items.AddRange(new ToolStripItem[] {
			this.menuBarItem1,
			// 
			// miClose
			// 
			this.menuBarItem5});
			resources.ApplyResources(this.menuBar1, "menuBar1");
			this.menuBar1.Name = "menuBar1";
			// 
			// miNewDc
			// 
			this.menuBarItem1.DropDownItems.AddRange(new ToolStripItem[] {
			this.miNew,
			this.miOpen,
			// 
			// menuBar1
			// 
			this.miReloadL,
			this.miSave,
			this.miSaveAs,
			this.miSaveCopyAs,
			this.miClose,
			this.miRecent,
			this.toolStripMenuItem1,
			this.miExit});
			// 
			// menuBarItem1
			// 
			// miOpenIn
			//
			this.miOpenIn.DropDownItems.AddRange(new ToolStripItem[] {
			this.miOpenSimsRes,
			this.miOpenDownloads});
			this.miOpenIn.Name = "miOpenIn";
			resources.ApplyResources(this.miOpenIn, "miOpenIn");
			//
			// miOpenSimsRes
			//
			this.miOpenSimsRes.Name = "miOpenSimsRes";
			resources.ApplyResources(this.miOpenSimsRes, "miOpenSimsRes");
			this.miOpenSimsRes.Click += new System.EventHandler(this.Activate_miOpenSimsRes);
			//
			// miOpenDownloads
			//
			// 
			// miOpenIn
			// 
			//
			// miReloadL
			//
			resources.ApplyResources(this.miReloadL, "miReloadL");
			this.miReloadL.Name = "miReloadL";
			// 
			// miOpenSimsRes
			// 
			//
			resources.ApplyResources(this.miShowName, "miShowName");
			this.miShowName.Name = "miShowName";
			// 
			// miOpenDownloads
			// 
			//
			this.miSaveCopyAs.Name = "miSaveCopyAs";
			resources.ApplyResources(this.miSaveCopyAs, "miSaveCopyAs");
			// 
			// miReloadL
			// 
			//
			this.miObjects.Name = "miObjects";
			resources.ApplyResources(this.miObjects, "miObjects");
																					 // 
																					 // miShowName
																					 // 
			//
			this.miRecent.Name = "miRecent";
			resources.ApplyResources(this.miRecent, "miRecent");
			// 
			// miSaveCopyAs
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
			//
			// 
			// miObjects
			// 
			this.miExit.Name = "miExit";
			this.miExit.Click += new System.EventHandler(this.Activate_miExit);
			//
			// 
			// miRecent
			// 
			resources.ApplyResources(this.miTools, "miTools");
			//
			// 
			// toolStripMenuItem1
			// 
			this.miMetaInfo,
			this.miFileNames,
			// 
			// miExit
			// 
			this.tsmiSaveProfile,
			this.tsmiSavePrefs});
			this.miExtra.Name = "miExtra";
			// 
			// miTools
			// 
			//
			this.miMetaInfo.Name = "miMetaInfo";
			// 
			// miExtra
			// 
			// miFileNames
			//
			this.miFileNames.Checked = true;
			this.miFileNames.CheckState = CheckState.Checked;
			this.miFileNames.Name = "miFileNames";
			resources.ApplyResources(this.miFileNames, "miFileNames");
			this.miFileNames.Click += new System.EventHandler(this.Activate_miFileNames);
			//
			// miRunSims
			//
			// 
			// miMetaInfo
			// 
			//
			// toolStripMenuItem2
			//
			// 
			// miFileNames
			// 
			// miPref
			//
			resources.ApplyResources(this.miPref, "miPref");
			this.miPref.Name = "miPref";
			this.miPref.Click += new System.EventHandler(this.ShowPreferences);
			// 
			// miRunSims
			// 
			resources.ApplyResources(this.tsmiSaveProfile, "tsmiSaveProfile");
			this.tsmiSaveProfile.Name = "tsmiSaveProfile";
			this.tsmiSaveProfile.Click += new System.EventHandler(this.tsmiSaveProfile_Click);
			// 
			// toolStripMenuItem2
			// 
			resources.ApplyResources(this.tsmiSavePrefs, "tsmiSavePrefs");
			this.tsmiSavePrefs.Name = "tsmiSavePrefs";
			// 
			// miPref
			// 
			//
			this.miWindow.Name = "miWindow";
			resources.ApplyResources(this.miWindow, "miWindow");
			// 
			// tsmiSaveProfile
			// 
			this.menuBarItem5.DropDownItems.AddRange(new ToolStripItem[] {
			this.miKBase,
			this.mbiTopics,
			// 
			// tsmiSavePrefs
			// 
			this.menuBarItem5.Name = "menuBarItem5";
			resources.ApplyResources(this.menuBarItem5, "menuBarItem5");
			this.menuBarItem5.VisibleChanged += new System.EventHandler(this.menuBarItem5_VisibleChanged);
			// 
			// miWindow
			// 
			resources.ApplyResources(this.miKBase, "miKBase");
			this.miKBase.Name = "miKBase";
			// 
			// menuBarItem5
			// 
			//
			resources.ApplyResources(this.mbiTopics, "mbiTopics");
			this.mbiTopics.Name = "mbiTopics";
			//
			// toolStripMenuItem3
			//
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
			//
			// 
			// miKBase
			// 
			this.miAbout.Name = "miAbout";
			this.miAbout.Click += new System.EventHandler(this.Activate_miAbout);
			//
			// 
			// mbiTopics
			// 
			resources.ApplyResources(this.tsmiStopWaiting, "tsmiStopWaiting");
			this.tsmiStopWaiting.Click += new System.EventHandler(this.tsmiStopWaiting_Click);
			// 
			// toolStripMenuItem3
			// 
			resources.ApplyResources(this.sfd, "sfd");
			//
			// 
			// miAbout
			// 
			this.waitControl1.Image = null;
			this.waitControl1.MaxProgress = 1000;
			this.waitControl1.Message = "";
			// 
			// tsmiStopWaiting
			// 
			this.waitControl1.ShowProgress = false;
			this.waitControl1.ShowText = true;
			this.waitControl1.TabStop = false;
			// 
			// sfd
			// 
			//
			// 
			// waitControl1
			// 
			//
			// MainForm
			//
			// this.AutoScaleMode = AutoScaleMode.Inherit;
			this.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.tbContainer);
			this.Controls.Add(this.waitControl1);
			this.Controls.Add(this.menuBar1);
			this.MainMenuStrip = this.menuBar1;
			this.Name = "MainForm";
			// 
			// resourceViewManager1
			// 
			this.tbContainer.ContentPanel.ResumeLayout(false);
			this.tbContainer.TopToolStripPanel.ResumeLayout(false);
			this.tbContainer.TopToolStripPanel.PerformLayout();
			// 
			// MainForm
			// 
			// this.AutoScaleMode = AutoScaleMode.Inherit;
			this.dockLeft.ResumeLayout(false);
			this.dcResource.ResumeLayout(false);
			this.dockRight.ResumeLayout(false);
			this.dcAction.ResumeLayout(false);
			this.GradientPanel2.ResumeLayout(false);
			this.dcFilter.ResumeLayout(false);
			this.GradientPanel1.ResumeLayout(false);
			this.GradientPanel1.PerformLayout();
			this.dockBottom.ResumeLayout(false);
			this.dcPlugin.ResumeLayout(false);
			this.toolBar1.ResumeLayout(false);
			this.toolBar1.PerformLayout();
			this.menuBar1.ResumeLayout(false);
			this.menuBar1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			
			
			region
			
			
			