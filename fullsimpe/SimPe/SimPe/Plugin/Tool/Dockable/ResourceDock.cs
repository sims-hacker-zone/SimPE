// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Linq;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Extensions;
using Ambertation.Windows.Forms;

namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Zusammenfassung für ResourceDock.
	/// </summary>
	public class ResourceDock : Form
	{
		private DockManager manager;
		internal DockPanel dcWrapper;
		internal DockPanel dcResource;
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel1;
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel2;
		internal Panel pntypes;
		internal TextBox tbinstance;
		private Label label11;
		internal TextBox tbtype;
		private Label label8;
		private Label label9;
		private Label label10;
		internal TextBox tbgroup;
		internal ComboBox cbtypes;
		private Label label3;
		internal ComboBox cbComp;
		internal TextBox tbinstance2;
		internal Label lbName;
		private Label label1;
		private Label label2;
		private Label label5;
		internal Label lbAuthor;
		internal Label lbVersion;
		internal Label lbDesc;
		internal Label lbComp;
		internal DockPanel dcPackage;
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel3;
		internal PropertyGrid pgHead;
		private Label label4;
		internal ListView lv;
		private ColumnHeader clOffset;
		private ColumnHeader clSize;
		internal DockPanel dcConvert;
		private SteepValley.Windows.Forms.XPGradientPanel xpGradientPanel4;
		private SteepValley.Windows.Forms.XPCueBannerExtender xpCueBannerExtender1;
		private TextBox tbHex;
		private TextBox tbDec;
		internal DockPanel dcHex;
		internal HexViewControl hvc;
		private TextBox tbBin;
		internal Button button1;
		private HexEditControl hexEditControl1;
		private LinkLabel linkLabel1;
		internal PictureBox pb;
		private Panel panel1;
		private TextBox tbFloat;
		private DockContainer dockBottom;
		private System.ComponentModel.IContainer components;

		public ResourceDock()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			ThemeManager tm = ThemeManager.Global.CreateChild();
			tm.AddControl(xpGradientPanel1);
			tm.AddControl(xpGradientPanel2);
			tm.AddControl(xpGradientPanel3);
			tm.AddControl(xpGradientPanel4);

			lv.View = View.Details;
			cbtypes.Items.AddRange((from FileTypes type in Enum.GetValues(typeof(FileTypes))
									select type.ToFileTypeInformation()).Cast<object>().ToArray());

			cbtypes.Sorted = true;
			tbFloat.Width = tbBin.Width;
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			WhidbeyRenderer whidbeyRenderer2 =
				new WhidbeyRenderer();
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(
					typeof(ResourceDock)
				);
			manager = new DockManager();
			dockBottom = new DockContainer();
			dcConvert = new DockPanel();
			xpGradientPanel4 = new SteepValley.Windows.Forms.XPGradientPanel();
			tbFloat = new TextBox();
			tbBin = new TextBox();
			tbDec = new TextBox();
			tbHex = new TextBox();
			dcHex = new DockPanel();
			hvc = new HexViewControl();
			panel1 = new Panel();
			button1 = new Button();
			hexEditControl1 = new HexEditControl();
			dcResource = new DockPanel();
			xpGradientPanel1 = new SteepValley.Windows.Forms.XPGradientPanel();
			linkLabel1 = new LinkLabel();
			lbComp = new Label();
			cbComp = new ComboBox();
			pntypes = new Panel();
			tbinstance2 = new TextBox();
			tbinstance = new TextBox();
			label11 = new Label();
			tbtype = new TextBox();
			label8 = new Label();
			label9 = new Label();
			label10 = new Label();
			tbgroup = new TextBox();
			cbtypes = new ComboBox();
			dcPackage = new DockPanel();
			xpGradientPanel3 = new SteepValley.Windows.Forms.XPGradientPanel();
			lv = new ListView();
			clOffset = new ColumnHeader();
			clSize = new ColumnHeader();
			label4 = new Label();
			pgHead = new PropertyGrid();
			dcWrapper = new DockPanel();
			xpGradientPanel2 = new SteepValley.Windows.Forms.XPGradientPanel();
			lbName = new Label();
			pb = new PictureBox();
			lbDesc = new Label();
			lbVersion = new Label();
			lbAuthor = new Label();
			label5 = new Label();
			label2 = new Label();
			label1 = new Label();
			label3 = new Label();
			xpCueBannerExtender1 =
				new SteepValley.Windows.Forms.XPCueBannerExtender(components);
			manager.SuspendLayout();
			dockBottom.SuspendLayout();
			dcConvert.SuspendLayout();
			xpGradientPanel4.SuspendLayout();
			dcHex.SuspendLayout();
			panel1.SuspendLayout();
			dcResource.SuspendLayout();
			xpGradientPanel1.SuspendLayout();
			pntypes.SuspendLayout();
			dcPackage.SuspendLayout();
			xpGradientPanel3.SuspendLayout();
			dcWrapper.SuspendLayout();
			xpGradientPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pb).BeginInit();
			SuspendLayout();
			//
			// sandDockManager1
			//
			manager.Controls.Add(dockBottom);
			manager.DefaultSize = new System.Drawing.Size(100, 100);
			resources.ApplyResources(manager, "sandDockManager1");
			manager.DragBorder = true;
			manager.Manager = manager;
			manager.Name = "sandDockManager1";
			manager.NoCleanup = false;
			manager.Renderer = whidbeyRenderer2;
			manager.TabImage = null;
			manager.TabText = "";
			//
			// dockBottom
			//
			dockBottom.Controls.Add(dcPackage);
			dockBottom.Controls.Add(dcResource);
			dockBottom.Controls.Add(dcWrapper);
			dockBottom.Controls.Add(dcHex);
			dockBottom.Controls.Add(dcConvert);
			resources.ApplyResources(dockBottom, "dockBottom");
			dockBottom.DragBorder = true;
			dockBottom.Manager = manager;
			dockBottom.Name = "dockBottom";
			dockBottom.NoCleanup = false;
			dockBottom.TabImage = null;
			dockBottom.TabText = "";
			//
			// dcConvert
			//
			dcConvert.AllowClose = true;
			dcConvert.AllowDockBottom = true;
			dcConvert.AllowDockCenter = true;
			dcConvert.AllowDockLeft = true;
			dcConvert.AllowDockRight = true;
			dcConvert.AllowDockTop = true;
			dcConvert.AllowFloat = true;
			resources.ApplyResources(dcConvert, "dcConvert");
			dcConvert.CanUndock = true;
			dcConvert.Controls.Add(xpGradientPanel4);
			dcConvert.DockContainer = dockBottom;
			dcConvert.DragBorder = false;
			dcConvert.FloatingSize = new System.Drawing.Size(856, 382);
			dcConvert.Image =
				(System.Drawing.Image)resources.GetObject("dcConvert.Image")
			;
			dcConvert.Manager = manager;
			dcConvert.Name = "dcConvert";
			dcConvert.ShowCloseButton = true;
			dcConvert.ShowCollapseButton = true;
			dcConvert.TabImage =
				(System.Drawing.Image)resources.GetObject("dcConvert.TabImage")
			;
			dcConvert.TabText = "Converter";
			//
			// xpGradientPanel4
			//
			xpGradientPanel4.Controls.Add(tbFloat);
			xpGradientPanel4.Controls.Add(tbBin);
			xpGradientPanel4.Controls.Add(tbDec);
			xpGradientPanel4.Controls.Add(tbHex);
			resources.ApplyResources(xpGradientPanel4, "xpGradientPanel4");
			xpGradientPanel4.Name = "xpGradientPanel4";
			//
			// tbFloat
			//
			xpCueBannerExtender1.SetCueBannerText(tbFloat, "Float");
			resources.ApplyResources(tbFloat, "tbFloat");
			tbFloat.Name = "tbFloat";
			tbFloat.TextChanged += new EventHandler(FloatChanged);
			//
			// tbBin
			//
			xpCueBannerExtender1.SetCueBannerText(tbBin, "Binary");
			resources.ApplyResources(tbBin, "tbBin");
			tbBin.Name = "tbBin";
			tbBin.SizeChanged += new EventHandler(tbBin_SizeChanged);
			tbBin.TextChanged += new EventHandler(BinChanged);
			//
			// tbDec
			//
			xpCueBannerExtender1.SetCueBannerText(tbDec, "Decimal");
			resources.ApplyResources(tbDec, "tbDec");
			tbDec.Name = "tbDec";
			tbDec.TextChanged += new EventHandler(DecChanged);
			//
			// tbHex
			//
			xpCueBannerExtender1.SetCueBannerText(tbHex, "Hex.");
			resources.ApplyResources(tbHex, "tbHex");
			tbHex.Name = "tbHex";
			tbHex.TextChanged += new EventHandler(HexChanged);
			//
			// dcHex
			//
			dcHex.AllowClose = true;
			dcHex.AllowDockBottom = true;
			dcHex.AllowDockCenter = true;
			dcHex.AllowDockLeft = true;
			dcHex.AllowDockRight = true;
			dcHex.AllowDockTop = true;
			dcHex.AllowFloat = true;
			resources.ApplyResources(dcHex, "dcHex");
			dcHex.CanUndock = true;
			dcHex.Controls.Add(hvc);
			dcHex.Controls.Add(panel1);
			dcHex.Controls.Add(hexEditControl1);
			dcHex.DockContainer = dockBottom;
			dcHex.DragBorder = false;
			dcHex.FloatingSize = new System.Drawing.Size(856, 382);
			dcHex.Image =
				(System.Drawing.Image)resources.GetObject("dcHex.Image")
			;
			dcHex.Manager = manager;
			dcHex.Name = "dcHex";
			dcHex.ShowCloseButton = true;
			dcHex.ShowCollapseButton = true;
			dcHex.TabImage =
				(System.Drawing.Image)resources.GetObject("dcHex.TabImage")
			;
			dcHex.TabText = "Hex";
			dcHex.VisibleChanged += new EventHandler(
				dcHex_VisibleChanged
			);
			//
			// hvc
			//
			hvc.Blocks = 2;
			hvc.CharBoxWidth = 220;
			hvc.CurrentRow = 0;
			hvc.Data = new byte[0];
			resources.ApplyResources(hvc, "hvc");
			hvc.FocusedForeColor = System.Drawing.Color.FromArgb(
				(byte)96,
				(byte)0,
				(byte)0,
				(byte)0
			);
			hvc.GridColor = System.Drawing.Color.FromArgb(
				(byte)50,
				(byte)255,
				(byte)140,
				(byte)0
			);
			hvc.HeadColor = System.Drawing.Color.DarkOrange;
			hvc.HeadForeColor = System.Drawing.Color.SeaShell;
			hvc.HighlightColor = System.Drawing.Color.FromArgb(
				(byte)190,
				(byte)255,
				(byte)140,
				(byte)0
			);
			hvc.HighlightForeColor = System.Drawing.SystemColors.HighlightText;
			hvc.HighlightZeros = false;
			hvc.Name = "hvc";
			hvc.Offset = 0;
			hvc.OffsetBoxWidth = 83;
			hvc.SelectedByte = 0;
			hvc.SelectedChar = '\0';
			hvc.SelectedDouble = 0;
			hvc.SelectedFloat = 0F;
			hvc.SelectedInt = 0;
			hvc.SelectedLong = 0;
			hvc.SelectedShort = 0;
			hvc.SelectedUInt = 0u;
			hvc.SelectedULong = 0ul;
			hvc.SelectedUShort = 0;
			hvc.Selection = new byte[0];
			hvc.SelectionColor = System.Drawing.SystemColors.Highlight;
			hvc.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			hvc.ShowGrid = true;
			hvc.View = HexViewControl.ViewState.Hex;
			hvc.ZeroCellColor = System.Drawing.Color.FromArgb(
				(byte)150,
				(byte)158,
				(byte)210,
				(byte)49
			);
			//
			// panel1
			//
			panel1.BackColor = System.Drawing.SystemColors.Control;
			panel1.Controls.Add(button1);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			//
			// button1
			//
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			button1.Click += new EventHandler(button1_Click);
			//
			// hexEditControl1
			//
			resources.ApplyResources(hexEditControl1, "hexEditControl1");
			hexEditControl1.FlatStyle = FlatStyle.System;
			hexEditControl1.LabelFont = new System.Drawing.Font(
				"Tahoma",
				8.25F,
				System.Drawing.FontStyle.Italic,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			hexEditControl1.Name = "hexEditControl1";
			hexEditControl1.TabStop = false;
			hexEditControl1.TextBoxFont = new System.Drawing.Font(
				"Courier New",
				8.25F,
				System.Drawing.FontStyle.Regular,
				System.Drawing.GraphicsUnit.Point,
				0
			);
			hexEditControl1.Vertical = false;
			hexEditControl1.View =
				HexViewControl
				.ViewState
				.Hex;
			hexEditControl1.Viewer = hvc;
			//
			// dcResource
			//
			dcResource.AllowClose = true;
			dcResource.AllowDockBottom = true;
			dcResource.AllowDockCenter = true;
			dcResource.AllowDockLeft = true;
			dcResource.AllowDockRight = true;
			dcResource.AllowDockTop = true;
			dcResource.AllowFloat = true;
			resources.ApplyResources(dcResource, "dcResource");
			dcResource.CanUndock = true;
			dcResource.Controls.Add(xpGradientPanel1);
			dcResource.DockContainer = dockBottom;
			dcResource.DragBorder = false;
			dcResource.FloatingSize = new System.Drawing.Size(856, 382);
			dcResource.Image =
				(System.Drawing.Image)resources.GetObject("dcResource.Image")
			;
			dcResource.Manager = manager;
			dcResource.Name = "dcResource";
			dcResource.ShowCloseButton = true;
			dcResource.ShowCollapseButton = true;
			dcResource.TabImage =
				(System.Drawing.Image)resources.GetObject("dcResource.TabImage")
			;
			dcResource.TabText = "Resource";
			//
			// xpGradientPanel1
			//
			xpGradientPanel1.Controls.Add(linkLabel1);
			xpGradientPanel1.Controls.Add(lbComp);
			xpGradientPanel1.Controls.Add(cbComp);
			xpGradientPanel1.Controls.Add(pntypes);
			resources.ApplyResources(xpGradientPanel1, "xpGradientPanel1");
			xpGradientPanel1.Name = "xpGradientPanel1";
			//
			// linkLabel1
			//
			linkLabel1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(linkLabel1, "linkLabel1");
			linkLabel1.Name = "linkLabel1";
			linkLabel1.TabStop = true;
			linkLabel1.UseCompatibleTextRendering = true;
			linkLabel1.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					linkLabel1_LinkClicked
				);
			//
			// lbComp
			//
			lbComp.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(lbComp, "lbComp");
			lbComp.Name = "lbComp";
			//
			// cbComp
			//
			xpCueBannerExtender1.SetCueBannerText(cbComp, "");
			cbComp.DropDownStyle = ComboBoxStyle.DropDownList;
			resources.ApplyResources(cbComp, "cbComp");
			cbComp.Items.AddRange(
				new object[]
				{
					resources.GetString("cbComp.Items"),
					resources.GetString("cbComp.Items1"),
					resources.GetString("cbComp.Items2"),
				}
			);
			cbComp.Name = "cbComp";
			cbComp.SelectedIndexChanged += new EventHandler(
				cbComp_SelectedIndexChanged
			);
			//
			// pntypes
			//
			pntypes.BackColor = System.Drawing.Color.Transparent;
			pntypes.Controls.Add(tbinstance2);
			pntypes.Controls.Add(tbinstance);
			pntypes.Controls.Add(label11);
			pntypes.Controls.Add(tbtype);
			pntypes.Controls.Add(label8);
			pntypes.Controls.Add(label9);
			pntypes.Controls.Add(label10);
			pntypes.Controls.Add(tbgroup);
			pntypes.Controls.Add(cbtypes);
			resources.ApplyResources(pntypes, "pntypes");
			pntypes.Name = "pntypes";
			//
			// tbinstance2
			//
			xpCueBannerExtender1.SetCueBannerText(tbinstance2, "");
			resources.ApplyResources(tbinstance2, "tbinstance2");
			tbinstance2.Name = "tbinstance2";
			tbinstance2.Leave += new EventHandler(
				tbinstance2_TextChanged
			);
			tbinstance2.KeyUp += new KeyEventHandler(
				tbinstance2_KeyUp
			);
			tbinstance2.TextChanged += new EventHandler(TextChanged);
			//
			// tbinstance
			//
			xpCueBannerExtender1.SetCueBannerText(tbinstance, "");
			resources.ApplyResources(tbinstance, "tbinstance");
			tbinstance.Name = "tbinstance";
			tbinstance.Leave += new EventHandler(
				tbinstance_TextChanged
			);
			tbinstance.KeyUp += new KeyEventHandler(
				tbinstance_KeyUp
			);
			tbinstance.TextChanged += new EventHandler(TextChanged);
			//
			// label11
			//
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			//
			// tbtype
			//
			xpCueBannerExtender1.SetCueBannerText(tbtype, "");
			resources.ApplyResources(tbtype, "tbtype");
			tbtype.Name = "tbtype";
			tbtype.Leave += new EventHandler(tbtype_TextChanged2);
			tbtype.KeyUp += new KeyEventHandler(
				tbtype_KeyUp
			);
			tbtype.TextChanged += new EventHandler(tbtype_TextChanged);
			//
			// label8
			//
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
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
			// tbgroup
			//
			xpCueBannerExtender1.SetCueBannerText(tbgroup, "");
			resources.ApplyResources(tbgroup, "tbgroup");
			tbgroup.Name = "tbgroup";
			tbgroup.Leave += new EventHandler(tbgroup_TextChanged);
			tbgroup.KeyUp += new KeyEventHandler(
				tbgroup_KeyUp
			);
			tbgroup.TextChanged += new EventHandler(TextChanged);
			//
			// cbtypes
			//
			resources.ApplyResources(cbtypes, "cbtypes");
			xpCueBannerExtender1.SetCueBannerText(cbtypes, "");
			cbtypes.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbtypes.Name = "cbtypes";
			cbtypes.SelectedIndexChanged += new EventHandler(
				cbtypes_SelectedIndexChanged
			);
			//
			// dcPackage
			//
			dcPackage.AllowClose = true;
			dcPackage.AllowDockBottom = true;
			dcPackage.AllowDockCenter = true;
			dcPackage.AllowDockLeft = true;
			dcPackage.AllowDockRight = true;
			dcPackage.AllowDockTop = true;
			dcPackage.AllowFloat = true;
			resources.ApplyResources(dcPackage, "dcPackage");
			dcPackage.CanUndock = true;
			dcPackage.Controls.Add(xpGradientPanel3);
			dcPackage.DockContainer = dockBottom;
			dcPackage.DragBorder = false;
			dcPackage.FloatingSize = new System.Drawing.Size(856, 382);
			dcPackage.Image =
				(System.Drawing.Image)resources.GetObject("dcPackage.Image")
			;
			dcPackage.Manager = manager;
			dcPackage.Name = "dcPackage";
			dcPackage.ShowCloseButton = true;
			dcPackage.ShowCollapseButton = true;
			dcPackage.TabImage =
				(System.Drawing.Image)resources.GetObject("dcPackage.TabImage")
			;
			dcPackage.TabText = "Package ";
			//
			// xpGradientPanel3
			//
			xpGradientPanel3.Controls.Add(lv);
			xpGradientPanel3.Controls.Add(label4);
			xpGradientPanel3.Controls.Add(pgHead);
			resources.ApplyResources(xpGradientPanel3, "xpGradientPanel3");
			xpGradientPanel3.Name = "xpGradientPanel3";
			//
			// lv
			//
			resources.ApplyResources(lv, "lv");
			lv.Columns.AddRange(
				new ColumnHeader[] { clOffset, clSize }
			);
			lv.FullRowSelect = true;
			lv.GridLines = true;
			lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			lv.HideSelection = false;
			lv.Name = "lv";
			lv.UseCompatibleStateImageBehavior = false;

			//
			// clOffset
			//
			resources.ApplyResources(clOffset, "clOffset");
			//
			// clSize
			//
			resources.ApplyResources(clSize, "clSize");
			//
			// label4
			//
			label4.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// pgHead
			//
			resources.ApplyResources(pgHead, "pgHead");
			pgHead.LineColor = System.Drawing.SystemColors.ScrollBar;
			pgHead.Name = "pgHead";
			pgHead.PropertySort = PropertySort.Alphabetical;
			pgHead.ToolbarVisible = false;
			//
			// dcWrapper
			//
			dcWrapper.AllowClose = true;
			dcWrapper.AllowDockBottom = true;
			dcWrapper.AllowDockCenter = true;
			dcWrapper.AllowDockLeft = true;
			dcWrapper.AllowDockRight = true;
			dcWrapper.AllowDockTop = true;
			dcWrapper.AllowFloat = true;
			resources.ApplyResources(dcWrapper, "dcWrapper");
			dcWrapper.CanUndock = true;
			dcWrapper.Controls.Add(xpGradientPanel2);
			dcWrapper.DockContainer = dockBottom;
			dcWrapper.DragBorder = false;
			dcWrapper.FloatingSize = new System.Drawing.Size(856, 382);
			dcWrapper.Image =
				(System.Drawing.Image)resources.GetObject("dcWrapper.Image")
			;
			dcWrapper.Manager = manager;
			dcWrapper.Name = "dcWrapper";
			dcWrapper.ShowCloseButton = true;
			dcWrapper.ShowCollapseButton = true;
			dcWrapper.TabImage =
				(System.Drawing.Image)resources.GetObject("dcWrapper.TabImage")
			;
			dcWrapper.TabText = "Wrapper";
			//
			// xpGradientPanel2
			//
			xpGradientPanel2.Controls.Add(lbName);
			xpGradientPanel2.Controls.Add(pb);
			xpGradientPanel2.Controls.Add(lbDesc);
			xpGradientPanel2.Controls.Add(lbVersion);
			xpGradientPanel2.Controls.Add(lbAuthor);
			xpGradientPanel2.Controls.Add(label5);
			xpGradientPanel2.Controls.Add(label2);
			xpGradientPanel2.Controls.Add(label1);
			xpGradientPanel2.Controls.Add(label3);
			resources.ApplyResources(xpGradientPanel2, "xpGradientPanel2");
			xpGradientPanel2.Name = "xpGradientPanel2";
			//
			// lbName
			//
			resources.ApplyResources(lbName, "lbName");
			lbName.BackColor = System.Drawing.Color.Transparent;
			lbName.Name = "lbName";
			//
			// pb
			//
			pb.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(pb, "pb");
			pb.Name = "pb";
			pb.TabStop = false;
			//
			// lbDesc
			//
			resources.ApplyResources(lbDesc, "lbDesc");
			lbDesc.BackColor = System.Drawing.Color.Transparent;
			lbDesc.Name = "lbDesc";
			//
			// lbVersion
			//
			resources.ApplyResources(lbVersion, "lbVersion");
			lbVersion.BackColor = System.Drawing.Color.Transparent;
			lbVersion.Name = "lbVersion";
			//
			// lbAuthor
			//
			resources.ApplyResources(lbAuthor, "lbAuthor");
			lbAuthor.BackColor = System.Drawing.Color.Transparent;
			lbAuthor.Name = "lbAuthor";
			//
			// label5
			//
			label5.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// label2
			//
			label2.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// label1
			//
			label1.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// label3
			//
			label3.BackColor = System.Drawing.Color.Transparent;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// ResourceDock
			//
			resources.ApplyResources(this, "$this");
			Controls.Add(manager);
			Name = "ResourceDock";
			Load += new EventHandler(ResourceDock_Load);
			manager.ResumeLayout(false);
			dockBottom.ResumeLayout(false);
			dcConvert.ResumeLayout(false);
			xpGradientPanel4.ResumeLayout(false);
			xpGradientPanel4.PerformLayout();
			dcHex.ResumeLayout(false);
			panel1.ResumeLayout(false);
			dcResource.ResumeLayout(false);
			xpGradientPanel1.ResumeLayout(false);
			pntypes.ResumeLayout(false);
			pntypes.PerformLayout();
			dcPackage.ResumeLayout(false);
			xpGradientPanel3.ResumeLayout(false);
			dcWrapper.ResumeLayout(false);
			xpGradientPanel2.ResumeLayout(false);
			xpGradientPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pb).EndInit();
			ResumeLayout(false);
		}
		#endregion

		internal Events.ResourceEventArgs items;
		internal LoadedPackage guipackage;

		private void ResourceDock_Load(object sender, EventArgs e)
		{
		}

		private void cbtypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbtypes.Tag != null)
			{
				return;
			}

			tbtype.Text =
				"0x"
				+ Helper.HexString(
					(uint)((FileTypeInformation)cbtypes.Items[cbtypes.SelectedIndex]).Type
				);
			tbtype.Tag = true;
			tbtype_TextChanged2(tbtype, e);
		}

		private void tbtype_TextChanged(object sender, EventArgs e)
		{
			cbtypes.Tag = true;
			FileTypeInformation typeinfo = ((FileTypes)Helper.HexStringToUInt(tbtype.Text)).ToFileTypeInformation();

			int ct = 0;
			foreach (FileTypeInformation i in cbtypes.Items)
			{
				if (i == typeinfo)
				{
					cbtypes.SelectedIndex = ct;
					cbtypes.Tag = null;
					return;
				}
				ct++;
			}

			cbtypes.SelectedIndex = -1;
			cbtypes.Tag = null;
			TextChanged(sender, null);
		}

		private void tbtype_TextChanged2(object sender, EventArgs ea)
		{
			if (items == null || ((TextBox)sender).Tag == null)
			{
				return;
			} ((TextBox)sender).Tag = null;
			guipackage.PauseIndexChangedEvents();
			foreach (Events.ResourceContainer e in items)
			{
				if (!e.HasFileDescriptor)
				{
					continue;
				}

				try
				{
					e.Resource.FileDescriptor.Type = (Data.FileTypes)Convert.ToUInt32(tbtype.Text, 16);

					e.Resource.FileDescriptor.Changed = true;
				}
				catch { }
			}
			guipackage.PauseIndexChangedEvents();
			guipackage.RestartIndexChangedEvents();
		}

		private void tbgroup_TextChanged(object sender, EventArgs ea)
		{
			if (items == null || ((TextBox)sender).Tag == null)
			{
				return;
			} ((TextBox)sender).Tag = null;

			guipackage.PauseIndexChangedEvents();
			foreach (Events.ResourceContainer e in items)
			{
				if (!e.HasFileDescriptor)
				{
					continue;
				}

				try
				{
					e.Resource.FileDescriptor.Group = Convert.ToUInt32(
						tbgroup.Text,
						16
					);

					e.Resource.FileDescriptor.Changed = true;
				}
				catch { }
			}
			guipackage.PauseIndexChangedEvents();
			guipackage.RestartIndexChangedEvents();
		}

		private void tbinstance_TextChanged(object sender, EventArgs ea)
		{
			if (items == null || ((TextBox)sender).Tag == null)
			{
				return;
			} ((TextBox)sender).Tag = null;

			guipackage.PauseIndexChangedEvents();
			foreach (Events.ResourceContainer e in items)
			{
				if (!e.HasFileDescriptor)
				{
					continue;
				}

				try
				{
					e.Resource.FileDescriptor.Instance = Convert.ToUInt32(
						tbinstance.Text,
						16
					);

					e.Resource.FileDescriptor.Changed = true;
				}
				catch { }
			}

			guipackage.PauseIndexChangedEvents();
			guipackage.RestartIndexChangedEvents();
		}

		private void tbinstance2_TextChanged(object sender, EventArgs ea)
		{
			if (items == null || ((TextBox)sender).Tag == null)
			{
				return;
			} ((TextBox)sender).Tag = null;

			guipackage.PauseIndexChangedEvents();
			foreach (Events.ResourceContainer e in items)
			{
				if (!e.HasFileDescriptor)
				{
					continue;
				}

				try
				{
					e.Resource.FileDescriptor.SubType = Convert.ToUInt32(
						tbinstance2.Text,
						16
					);
					e.Resource.FileDescriptor.Changed = true;
				}
				catch { }
			}
			guipackage.PauseIndexChangedEvents();
			guipackage.RestartIndexChangedEvents();
		}

		private void cbComp_SelectedIndexChanged(object sender, EventArgs ea)
		{
			if (cbComp.SelectedIndex < 0)
			{
				return;
			}

			if (cbComp.SelectedIndex > 1)
			{
				return;
			}

			if (items == null)
			{
				return;
			}

			guipackage.PauseIndexChangedEvents();
			foreach (Events.ResourceContainer e in items)
			{
				if (!e.HasFileDescriptor)
				{
					continue;
				}

				try
				{
					e.Resource.FileDescriptor.MarkForReCompress =
						cbComp.SelectedIndex == 1
					;
					if (
						!e.Resource.FileDescriptor.MarkForReCompress
						&& e.Resource.FileDescriptor.WasCompressed
					)
					{
						e.Resource.FileDescriptor.UserData = e
							.Resource.Package.Read(e.Resource.FileDescriptor)
							.UncompressedData;
					}
					e.Resource.FileDescriptor.Changed = true;
				}
				catch { }
			}
			guipackage.PauseIndexChangedEvents();
			guipackage.RestartIndexChangedEvents();
		}

		private void tbtype_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				TextChanged(sender, null);
				tbtype_TextChanged2(sender, null);
			}
		}

		private void tbgroup_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				TextChanged(sender, null);
				tbgroup_TextChanged(sender, null);
			}
		}

		private void tbinstance_KeyUp(
			object sender,
			KeyEventArgs e
		)
		{
			if (e.KeyCode == Keys.Enter)
			{
				TextChanged(sender, null);
				tbinstance_TextChanged(sender, null);
			}
		}

		private void tbinstance2_KeyUp(
			object sender,
			KeyEventArgs e
		)
		{
			if (e.KeyCode == Keys.Enter)
			{
				TextChanged(sender, null);
				tbinstance2_TextChanged(sender, null);
			}
		}

		#region Hex <-> Dec Converter
		bool sysupdate = false;

		void SetConverted(object exclude, long val)
		{
			if (exclude != tbDec)
			{
				tbDec.Text = val.ToString();
			}

			if (exclude != tbHex)
			{
				tbHex.Text = Helper.HexString(val);
			}

			if (exclude != tbBin)
			{
				tbBin.Text = Convert.ToString(val, 2);
			};
			if (exclude != tbFloat)
			{
				tbFloat.Text = BitConverter
					.ToSingle(BitConverter.GetBytes((int)val), 0)
					.ToString();
			}
		}

		void ClearConverted(object exclude)
		{
			if (exclude != tbDec)
			{
				tbDec.Text = "";
			}

			if (exclude != tbHex)
			{
				tbHex.Text = "";
			}

			if (exclude != tbBin)
			{
				tbBin.Text = "";
			}

			if (exclude != tbFloat)
			{
				tbFloat.Text = "";
			}
		}

		private void FloatChanged(object sender, EventArgs e)
		{
			if (sysupdate)
			{
				return;
			}

			sysupdate = true;
			try
			{
				float f = Convert.ToSingle(tbFloat.Text);
				long val = BitConverter.ToInt32(BitConverter.GetBytes(f), 0);
				SetConverted(tbFloat, val);
			}
			catch
			{
				ClearConverted(tbFloat);
			}
			sysupdate = false;
		}

		private void BinChanged(object sender, EventArgs e)
		{
			if (sysupdate)
			{
				return;
			}

			sysupdate = true;
			try
			{
				long val = Convert.ToInt64(tbBin.Text.Replace(" ", ""), 2);
				SetConverted(tbBin, val);
			}
			catch
			{
				ClearConverted(tbBin);
			}
			sysupdate = false;
		}

		private void HexChanged(object sender, EventArgs e)
		{
			if (sysupdate)
			{
				return;
			}

			sysupdate = true;
			try
			{
				long val = Convert.ToInt64(tbHex.Text.Replace(" ", ""), 16);
				SetConverted(tbHex, val);
			}
			catch
			{
				ClearConverted(tbHex);
			}
			sysupdate = false;
		}

		private void DecChanged(object sender, EventArgs e)
		{
			if (sysupdate)
			{
				return;
			}

			sysupdate = true;
			try
			{
				long val = Convert.ToInt64(tbDec.Text);
				SetConverted(tbDec, val);
			}
			catch (Exception)
			{
				ClearConverted(tbDec);
			}
			sysupdate = false;
		}
		#endregion

		internal Interfaces.Files.IPackedFileDescriptor hexpfd;

		private new void TextChanged(object sender, EventArgs e)
		{
			if (items == null)
			{
				return;
			} ((TextBox)sender).Tag = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			hexpfd.UserData = hvc.Data;
		}

		private void dcHex_VisibleChanged(object sender, EventArgs e)
		{
			hvc.Visible = dcHex.Visible;
			hvc.Refresh(true);
		}

		private void linkLabel1_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs ev
		)
		{
			if (items == null)
			{
				return;
			}

			guipackage.PauseIndexChangedEvents();
			foreach (Events.ResourceContainer e in items)
			{
				if (!e.HasFileDescriptor)
				{
					continue;
				}

				try
				{
					e.Resource.FileDescriptor.Type = (Data.FileTypes)Convert.ToUInt32(tbtype.Text, 16);
					e.Resource.FileDescriptor.Group = Convert.ToUInt32(
						tbgroup.Text,
						16
					);
					e.Resource.FileDescriptor.Instance = Convert.ToUInt32(
						tbinstance.Text,
						16
					);
					e.Resource.FileDescriptor.SubType = Convert.ToUInt32(
						tbinstance2.Text,
						16
					);
					e.Resource.FileDescriptor.MarkForReCompress =
						cbComp.SelectedIndex == 1
						&& !e.Resource.FileDescriptor.WasCompressed
					;

					e.Resource.FileDescriptor.Changed = true;
				}
				catch { }
			}
			guipackage.RestartIndexChangedEvents();
		}

		private void tbBin_SizeChanged(object sender, EventArgs e)
		{
			tbFloat.Width = tbBin.Width;
		}
	}
}
