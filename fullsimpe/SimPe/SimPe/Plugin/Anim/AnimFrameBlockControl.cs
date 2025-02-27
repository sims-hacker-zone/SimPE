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
using System.Windows.Forms;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Summary description for AnimFrameBlockControl.
	/// </summary>
	public class AnimFrameBlockControl : UserControl
	{
		private TreeView tv;
		private Splitter splitter1;
		private Panel panel2;
		private AnimAxisTransformControl pn1;
		private AnimAxisTransformControl pn2;
		private AnimAxisTransformControl pn3;
		private Panel pnSplit1;
		private Panel pnSplit2;
		private Panel panel1;
		private Panel panel3;
		private Panel panel4;
		private LinkLabel llClear;
		private LinkLabel llAdd;
		private Panel panel5;
		private Panel panel6;
		private TextBox tbTimeCode;
		private Label lbTimeCode;
		private LinkLabel llRefresh;
		private LinkLabel llClone;
		private ContextMenu contextMenu1;
		private MenuItem miExp;
		private MenuItem miClp;
		private MenuItem miSlp;
		private MenuItem miRem;
		private TextBox tbDuration;
		private TextBox tbName;
		private Label lbDuration;
		private Label lbName;
		private MenuItem miSort;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AnimFrameBlockControl()
		{
			SetStyle(
				ControlStyles.SupportsTransparentBackColor
					| ControlStyles.AllPaintingInWmPaint
					|
					//ControlStyles.Opaque |
					ControlStyles.UserPaint
					| ControlStyles.ResizeRedraw
					| ControlStyles.DoubleBuffer,
				true
			);

			// Required designer variable.
			InitializeComponent();
			panel1.BackColor = splitter1.BackColor;
			panel3.BackColor = splitter1.BackColor;
			panel6.BackColor = splitter1.BackColor;
			if (Helper.WindowsRegistry.UseBigIcons)
			{
				tv.Font = new System.Drawing.Font("Verdana", 12F);
			}

			Clear();
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
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(AnimFrameBlockControl));
			tv = new TreeView();
			contextMenu1 = new ContextMenu();
			miSlp = new MenuItem();
			miClp = new MenuItem();
			miExp = new MenuItem();
			miRem = new MenuItem();
			miSort = new MenuItem();
			splitter1 = new Splitter();
			panel2 = new Panel();
			pn3 = new AnimAxisTransformControl();
			pnSplit2 = new Panel();
			panel3 = new Panel();
			pn2 = new AnimAxisTransformControl();
			pnSplit1 = new Panel();
			panel1 = new Panel();
			pn1 = new AnimAxisTransformControl();
			panel5 = new Panel();
			panel6 = new Panel();
			panel4 = new Panel();
			tbName = new TextBox();
			lbName = new Label();
			lbDuration = new Label();
			tbDuration = new TextBox();
			llClone = new LinkLabel();
			llRefresh = new LinkLabel();
			lbTimeCode = new Label();
			tbTimeCode = new TextBox();
			llAdd = new LinkLabel();
			llClear = new LinkLabel();
			panel2.SuspendLayout();
			pnSplit2.SuspendLayout();
			pnSplit1.SuspendLayout();
			panel5.SuspendLayout();
			panel4.SuspendLayout();
			SuspendLayout();
			//
			// tv
			//
			tv.AccessibleDescription = resources.GetString(
				"tv.AccessibleDescription"
			);
			tv.AccessibleName = resources.GetString("tv.AccessibleName");
			tv.Anchor = (
				(AnchorStyles)(resources.GetObject("tv.Anchor"))
			);
			tv.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tv.BackgroundImage"))
			);
			tv.BorderStyle = BorderStyle.None;
			tv.ContextMenu = contextMenu1;
			tv.Dock = (
				(DockStyle)(resources.GetObject("tv.Dock"))
			);
			tv.Enabled = ((bool)(resources.GetObject("tv.Enabled")));
			tv.Font = ((System.Drawing.Font)(resources.GetObject("tv.Font")));
			tv.HideSelection = false;
			tv.ImageIndex = ((int)(resources.GetObject("tv.ImageIndex")));
			tv.ImeMode = (
				(ImeMode)(resources.GetObject("tv.ImeMode"))
			);
			tv.Indent = ((int)(resources.GetObject("tv.Indent")));
			tv.ItemHeight = ((int)(resources.GetObject("tv.ItemHeight")));
			tv.Location = (
				(System.Drawing.Point)(resources.GetObject("tv.Location"))
			);
			tv.Name = "tv";
			tv.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tv.RightToLeft")
				)
			);
			tv.SelectedImageIndex = (
				(int)(resources.GetObject("tv.SelectedImageIndex"))
			);
			tv.Size = ((System.Drawing.Size)(resources.GetObject("tv.Size")));
			tv.TabIndex = ((int)(resources.GetObject("tv.TabIndex")));
			tv.Text = resources.GetString("tv.Text");
			tv.Visible = ((bool)(resources.GetObject("tv.Visible")));
			tv.AfterSelect += new TreeViewEventHandler(
				tv_AfterSelect
			);
			//
			// contextMenu1
			//
			contextMenu1.MenuItems.AddRange(
				new MenuItem[]
				{
					miExp,
					miRem,
					miSort,
					miClp,
					miSlp,
				}
			);
			contextMenu1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("contextMenu1.RightToLeft")
				)
			);
			//
			// miExp
			//
			miExp.Enabled = ((bool)(resources.GetObject("miExp.Enabled")));
			miExp.Index = 0;
			miExp.Shortcut = (
				(Shortcut)(resources.GetObject("miExp.Shortcut"))
			);
			miExp.ShowShortcut = (
				(bool)(resources.GetObject("miExp.ShowShortcut"))
			);
			miExp.Text = resources.GetString("miExp.Text");
			miExp.Visible = ((bool)(resources.GetObject("miExp.Visible")));
			miExp.Click += new System.EventHandler(menuItem2_Click);
			//
			// miRem
			//
			miRem.Enabled = ((bool)(resources.GetObject("miRem.Enabled")));
			miRem.Index = 1;
			miRem.Shortcut = (
				(Shortcut)(resources.GetObject("miRem.Shortcut"))
			);
			miRem.ShowShortcut = (
				(bool)(resources.GetObject("miRem.ShowShortcut"))
			);
			miRem.Text = resources.GetString("miRem.Text");
			miRem.Visible = ((bool)(resources.GetObject("miRem.Visible")));
			miRem.Click += new System.EventHandler(menuItem1_Click);
			//
			// miSort
			//
			miSort.Enabled = ((bool)(resources.GetObject("miSort.Enabled")));
			miSort.Index = 2;
			miSort.Shortcut = (
				(Shortcut)(resources.GetObject("miSort.Shortcut"))
			);
			miSort.ShowShortcut = (
				(bool)(resources.GetObject("miSort.ShowShortcut"))
			);
			miSort.Text = resources.GetString("miSort.Text");
			miSort.Visible = ((bool)(resources.GetObject("miSort.Visible")));
			miSort.Click += new System.EventHandler(SortClick);
			//
			// miClp
			//
			miClp.Enabled = ((bool)(resources.GetObject("miClp.Enabled")));
			miClp.Index = 3;
			miClp.Shortcut = (
				(Shortcut)(resources.GetObject("miClp.Shortcut"))
			);
			miClp.ShowShortcut = (
				(bool)(resources.GetObject("miClp.ShowShortcut"))
			);
			miClp.Text = resources.GetString("miClp.Text");
			miClp.Visible = ((bool)(resources.GetObject("miClp.Visible")));
			miClp.Click += new System.EventHandler(menuItem4_Click);
			//
			// miSlp
			//
			miSlp.Enabled = ((bool)(resources.GetObject("miSlp.Enabled")));
			miSlp.Index = 3;
			miSlp.Shortcut = (
				(Shortcut)(resources.GetObject("miSlp.Shortcut"))
			);
			miSlp.ShowShortcut = (
				(bool)(resources.GetObject("miSlp.ShowShortcut"))
			);
			miSlp.Text = resources.GetString("miSlp.Text");
			miSlp.Visible = ((bool)(resources.GetObject("miSlp.Visible")));
			miSlp.Click += new System.EventHandler(menuItem3_Click);
			//
			// splitter1
			//
			splitter1.AccessibleDescription = resources.GetString(
				"splitter1.AccessibleDescription"
			);
			splitter1.AccessibleName = resources.GetString(
				"splitter1.AccessibleName"
			);
			splitter1.Anchor = (
				(AnchorStyles)(
					resources.GetObject("splitter1.Anchor")
				)
			);
			splitter1.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("splitter1.BackgroundImage"))
			);
			splitter1.Dock = (
				(DockStyle)(resources.GetObject("splitter1.Dock"))
			);
			splitter1.Enabled = ((bool)(resources.GetObject("splitter1.Enabled")));
			splitter1.Font = (
				(System.Drawing.Font)(resources.GetObject("splitter1.Font"))
			);
			splitter1.ImeMode = (
				(ImeMode)(resources.GetObject("splitter1.ImeMode"))
			);
			splitter1.Location = (
				(System.Drawing.Point)(resources.GetObject("splitter1.Location"))
			);
			splitter1.MinExtra = (
				(int)(resources.GetObject("splitter1.MinExtra"))
			);
			splitter1.MinSize = ((int)(resources.GetObject("splitter1.MinSize")));
			splitter1.Name = "splitter1";
			splitter1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("splitter1.RightToLeft")
				)
			);
			splitter1.Size = (
				(System.Drawing.Size)(resources.GetObject("splitter1.Size"))
			);
			splitter1.TabIndex = (
				(int)(resources.GetObject("splitter1.TabIndex"))
			);
			splitter1.TabStop = false;
			splitter1.Visible = ((bool)(resources.GetObject("splitter1.Visible")));
			//
			// panel2
			//
			panel2.AccessibleDescription = resources.GetString(
				"panel2.AccessibleDescription"
			);
			panel2.AccessibleName = resources.GetString("panel2.AccessibleName");
			panel2.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel2.Anchor")
				)
			);
			panel2.AutoScroll = ((bool)(resources.GetObject("panel2.AutoScroll")));
			panel2.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("panel2.AutoScrollMargin"))
			);
			panel2.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("panel2.AutoScrollMinSize"))
			);
			panel2.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage"))
			);
			panel2.Controls.Add(pn3);
			panel2.Controls.Add(pnSplit2);
			panel2.Controls.Add(pn2);
			panel2.Controls.Add(pnSplit1);
			panel2.Controls.Add(pn1);
			panel2.Controls.Add(panel5);
			panel2.Controls.Add(panel4);
			panel2.Dock = (
				(DockStyle)(resources.GetObject("panel2.Dock"))
			);
			panel2.DockPadding.Left = 8;
			panel2.DockPadding.Right = 8;
			panel2.Enabled = ((bool)(resources.GetObject("panel2.Enabled")));
			panel2.Font = (
				(System.Drawing.Font)(resources.GetObject("panel2.Font"))
			);
			panel2.ImeMode = (
				(ImeMode)(resources.GetObject("panel2.ImeMode"))
			);
			panel2.Location = (
				(System.Drawing.Point)(resources.GetObject("panel2.Location"))
			);
			panel2.Name = "panel2";
			panel2.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel2.RightToLeft")
				)
			);
			panel2.Size = (
				(System.Drawing.Size)(resources.GetObject("panel2.Size"))
			);
			panel2.TabIndex = ((int)(resources.GetObject("panel2.TabIndex")));
			panel2.Text = resources.GetString("panel2.Text");
			panel2.Visible = ((bool)(resources.GetObject("panel2.Visible")));
			//
			// pn3
			//
			pn3.AccessibleDescription = resources.GetString(
				"pn3.AccessibleDescription"
			);
			pn3.AccessibleName = resources.GetString("pn3.AccessibleName");
			pn3.Anchor = (
				(AnchorStyles)(resources.GetObject("pn3.Anchor"))
			);
			pn3.AutoScroll = ((bool)(resources.GetObject("pn3.AutoScroll")));
			pn3.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("pn3.AutoScrollMargin"))
			);
			pn3.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("pn3.AutoScrollMinSize"))
			);
			pn3.AxisTransform = null;
			pn3.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pn3.BackgroundImage"))
			);
			pn3.CanCreate = false;
			pn3.Dock = (
				(DockStyle)(resources.GetObject("pn3.Dock"))
			);
			pn3.Enabled = ((bool)(resources.GetObject("pn3.Enabled")));
			pn3.Font = ((System.Drawing.Font)(resources.GetObject("pn3.Font")));
			pn3.ImeMode = (
				(ImeMode)(resources.GetObject("pn3.ImeMode"))
			);
			pn3.Location = (
				(System.Drawing.Point)(resources.GetObject("pn3.Location"))
			);
			pn3.Name = "pn3";
			pn3.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("pn3.RightToLeft")
				)
			);
			pn3.Size = ((System.Drawing.Size)(resources.GetObject("pn3.Size")));
			pn3.TabIndex = ((int)(resources.GetObject("pn3.TabIndex")));
			pn3.Visible = ((bool)(resources.GetObject("pn3.Visible")));
			pn3.Deleted += new System.EventHandler(pn1_Deleted);
			pn3.Changed += new System.EventHandler(pn1_Changed);
			pn3.VisibleChanged += new System.EventHandler(pn3_VisibleChanged);
			pn3.CreateClicked += new System.EventHandler(pn3_CreateClicked);
			//
			// pnSplit2
			//
			pnSplit2.AccessibleDescription = resources.GetString(
				"pnSplit2.AccessibleDescription"
			);
			pnSplit2.AccessibleName = resources.GetString(
				"pnSplit2.AccessibleName"
			);
			pnSplit2.Anchor = (
				(AnchorStyles)(
					resources.GetObject("pnSplit2.Anchor")
				)
			);
			pnSplit2.AutoScroll = (
				(bool)(resources.GetObject("pnSplit2.AutoScroll"))
			);
			pnSplit2.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("pnSplit2.AutoScrollMargin"))
			);
			pnSplit2.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("pnSplit2.AutoScrollMinSize"))
			);
			pnSplit2.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pnSplit2.BackgroundImage"))
			);
			pnSplit2.Controls.Add(panel3);
			pnSplit2.Dock = (
				(DockStyle)(resources.GetObject("pnSplit2.Dock"))
			);
			pnSplit2.Enabled = ((bool)(resources.GetObject("pnSplit2.Enabled")));
			pnSplit2.Font = (
				(System.Drawing.Font)(resources.GetObject("pnSplit2.Font"))
			);
			pnSplit2.ImeMode = (
				(ImeMode)(resources.GetObject("pnSplit2.ImeMode"))
			);
			pnSplit2.Location = (
				(System.Drawing.Point)(resources.GetObject("pnSplit2.Location"))
			);
			pnSplit2.Name = "pnSplit2";
			pnSplit2.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("pnSplit2.RightToLeft")
				)
			);
			pnSplit2.Size = (
				(System.Drawing.Size)(resources.GetObject("pnSplit2.Size"))
			);
			pnSplit2.TabIndex = ((int)(resources.GetObject("pnSplit2.TabIndex")));
			pnSplit2.Text = resources.GetString("pnSplit2.Text");
			pnSplit2.Visible = ((bool)(resources.GetObject("pnSplit2.Visible")));
			//
			// panel3
			//
			panel3.AccessibleDescription = resources.GetString(
				"panel3.AccessibleDescription"
			);
			panel3.AccessibleName = resources.GetString("panel3.AccessibleName");
			panel3.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel3.Anchor")
				)
			);
			panel3.AutoScroll = ((bool)(resources.GetObject("panel3.AutoScroll")));
			panel3.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("panel3.AutoScrollMargin"))
			);
			panel3.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("panel3.AutoScrollMinSize"))
			);
			panel3.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage"))
			);
			panel3.Dock = (
				(DockStyle)(resources.GetObject("panel3.Dock"))
			);
			panel3.Enabled = ((bool)(resources.GetObject("panel3.Enabled")));
			panel3.Font = (
				(System.Drawing.Font)(resources.GetObject("panel3.Font"))
			);
			panel3.ImeMode = (
				(ImeMode)(resources.GetObject("panel3.ImeMode"))
			);
			panel3.Location = (
				(System.Drawing.Point)(resources.GetObject("panel3.Location"))
			);
			panel3.Name = "panel3";
			panel3.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel3.RightToLeft")
				)
			);
			panel3.Size = (
				(System.Drawing.Size)(resources.GetObject("panel3.Size"))
			);
			panel3.TabIndex = ((int)(resources.GetObject("panel3.TabIndex")));
			panel3.Text = resources.GetString("panel3.Text");
			panel3.Visible = ((bool)(resources.GetObject("panel3.Visible")));
			//
			// pn2
			//
			pn2.AccessibleDescription = resources.GetString(
				"pn2.AccessibleDescription"
			);
			pn2.AccessibleName = resources.GetString("pn2.AccessibleName");
			pn2.Anchor = (
				(AnchorStyles)(resources.GetObject("pn2.Anchor"))
			);
			pn2.AutoScroll = ((bool)(resources.GetObject("pn2.AutoScroll")));
			pn2.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("pn2.AutoScrollMargin"))
			);
			pn2.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("pn2.AutoScrollMinSize"))
			);
			pn2.AxisTransform = null;
			pn2.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pn2.BackgroundImage"))
			);
			pn2.CanCreate = false;
			pn2.Dock = (
				(DockStyle)(resources.GetObject("pn2.Dock"))
			);
			pn2.Enabled = ((bool)(resources.GetObject("pn2.Enabled")));
			pn2.Font = ((System.Drawing.Font)(resources.GetObject("pn2.Font")));
			pn2.ImeMode = (
				(ImeMode)(resources.GetObject("pn2.ImeMode"))
			);
			pn2.Location = (
				(System.Drawing.Point)(resources.GetObject("pn2.Location"))
			);
			pn2.Name = "pn2";
			pn2.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("pn2.RightToLeft")
				)
			);
			pn2.Size = ((System.Drawing.Size)(resources.GetObject("pn2.Size")));
			pn2.TabIndex = ((int)(resources.GetObject("pn2.TabIndex")));
			pn2.Visible = ((bool)(resources.GetObject("pn2.Visible")));
			pn2.Deleted += new System.EventHandler(pn1_Deleted);
			pn2.Changed += new System.EventHandler(pn1_Changed);
			pn2.VisibleChanged += new System.EventHandler(pn2_VisibleChanged);
			pn2.CreateClicked += new System.EventHandler(pn2_CreateClicked);
			//
			// pnSplit1
			//
			pnSplit1.AccessibleDescription = resources.GetString(
				"pnSplit1.AccessibleDescription"
			);
			pnSplit1.AccessibleName = resources.GetString(
				"pnSplit1.AccessibleName"
			);
			pnSplit1.Anchor = (
				(AnchorStyles)(
					resources.GetObject("pnSplit1.Anchor")
				)
			);
			pnSplit1.AutoScroll = (
				(bool)(resources.GetObject("pnSplit1.AutoScroll"))
			);
			pnSplit1.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("pnSplit1.AutoScrollMargin"))
			);
			pnSplit1.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("pnSplit1.AutoScrollMinSize"))
			);
			pnSplit1.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pnSplit1.BackgroundImage"))
			);
			pnSplit1.Controls.Add(panel1);
			pnSplit1.Dock = (
				(DockStyle)(resources.GetObject("pnSplit1.Dock"))
			);
			pnSplit1.Enabled = ((bool)(resources.GetObject("pnSplit1.Enabled")));
			pnSplit1.Font = (
				(System.Drawing.Font)(resources.GetObject("pnSplit1.Font"))
			);
			pnSplit1.ImeMode = (
				(ImeMode)(resources.GetObject("pnSplit1.ImeMode"))
			);
			pnSplit1.Location = (
				(System.Drawing.Point)(resources.GetObject("pnSplit1.Location"))
			);
			pnSplit1.Name = "pnSplit1";
			pnSplit1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("pnSplit1.RightToLeft")
				)
			);
			pnSplit1.Size = (
				(System.Drawing.Size)(resources.GetObject("pnSplit1.Size"))
			);
			pnSplit1.TabIndex = ((int)(resources.GetObject("pnSplit1.TabIndex")));
			pnSplit1.Text = resources.GetString("pnSplit1.Text");
			pnSplit1.Visible = ((bool)(resources.GetObject("pnSplit1.Visible")));
			//
			// panel1
			//
			panel1.AccessibleDescription = resources.GetString(
				"panel1.AccessibleDescription"
			);
			panel1.AccessibleName = resources.GetString("panel1.AccessibleName");
			panel1.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel1.Anchor")
				)
			);
			panel1.AutoScroll = ((bool)(resources.GetObject("panel1.AutoScroll")));
			panel1.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("panel1.AutoScrollMargin"))
			);
			panel1.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("panel1.AutoScrollMinSize"))
			);
			panel1.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage"))
			);
			panel1.Dock = (
				(DockStyle)(resources.GetObject("panel1.Dock"))
			);
			panel1.Enabled = ((bool)(resources.GetObject("panel1.Enabled")));
			panel1.Font = (
				(System.Drawing.Font)(resources.GetObject("panel1.Font"))
			);
			panel1.ImeMode = (
				(ImeMode)(resources.GetObject("panel1.ImeMode"))
			);
			panel1.Location = (
				(System.Drawing.Point)(resources.GetObject("panel1.Location"))
			);
			panel1.Name = "panel1";
			panel1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel1.RightToLeft")
				)
			);
			panel1.Size = (
				(System.Drawing.Size)(resources.GetObject("panel1.Size"))
			);
			panel1.TabIndex = ((int)(resources.GetObject("panel1.TabIndex")));
			panel1.Text = resources.GetString("panel1.Text");
			panel1.Visible = ((bool)(resources.GetObject("panel1.Visible")));
			//
			// pn1
			//
			pn1.AccessibleDescription = resources.GetString(
				"pn1.AccessibleDescription"
			);
			pn1.AccessibleName = resources.GetString("pn1.AccessibleName");
			pn1.Anchor = (
				(AnchorStyles)(resources.GetObject("pn1.Anchor"))
			);
			pn1.AutoScroll = ((bool)(resources.GetObject("pn1.AutoScroll")));
			pn1.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("pn1.AutoScrollMargin"))
			);
			pn1.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("pn1.AutoScrollMinSize"))
			);
			pn1.AxisTransform = null;
			pn1.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("pn1.BackgroundImage"))
			);
			pn1.CanCreate = false;
			pn1.Dock = (
				(DockStyle)(resources.GetObject("pn1.Dock"))
			);
			pn1.Enabled = ((bool)(resources.GetObject("pn1.Enabled")));
			pn1.Font = ((System.Drawing.Font)(resources.GetObject("pn1.Font")));
			pn1.ImeMode = (
				(ImeMode)(resources.GetObject("pn1.ImeMode"))
			);
			pn1.Location = (
				(System.Drawing.Point)(resources.GetObject("pn1.Location"))
			);
			pn1.Name = "pn1";
			pn1.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("pn1.RightToLeft")
				)
			);
			pn1.Size = ((System.Drawing.Size)(resources.GetObject("pn1.Size")));
			pn1.TabIndex = ((int)(resources.GetObject("pn1.TabIndex")));
			pn1.Visible = ((bool)(resources.GetObject("pn1.Visible")));
			pn1.Deleted += new System.EventHandler(pn1_Deleted);
			pn1.Changed += new System.EventHandler(pn1_Changed);
			pn1.CreateClicked += new System.EventHandler(pn1_CreateClicked);
			//
			// panel5
			//
			panel5.AccessibleDescription = resources.GetString(
				"panel5.AccessibleDescription"
			);
			panel5.AccessibleName = resources.GetString("panel5.AccessibleName");
			panel5.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel5.Anchor")
				)
			);
			panel5.AutoScroll = ((bool)(resources.GetObject("panel5.AutoScroll")));
			panel5.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("panel5.AutoScrollMargin"))
			);
			panel5.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("panel5.AutoScrollMinSize"))
			);
			panel5.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage"))
			);
			panel5.Controls.Add(panel6);
			panel5.Dock = (
				(DockStyle)(resources.GetObject("panel5.Dock"))
			);
			panel5.Enabled = ((bool)(resources.GetObject("panel5.Enabled")));
			panel5.Font = (
				(System.Drawing.Font)(resources.GetObject("panel5.Font"))
			);
			panel5.ImeMode = (
				(ImeMode)(resources.GetObject("panel5.ImeMode"))
			);
			panel5.Location = (
				(System.Drawing.Point)(resources.GetObject("panel5.Location"))
			);
			panel5.Name = "panel5";
			panel5.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel5.RightToLeft")
				)
			);
			panel5.Size = (
				(System.Drawing.Size)(resources.GetObject("panel5.Size"))
			);
			panel5.TabIndex = ((int)(resources.GetObject("panel5.TabIndex")));
			panel5.Text = resources.GetString("panel5.Text");
			panel5.Visible = ((bool)(resources.GetObject("panel5.Visible")));
			//
			// panel6
			//
			panel6.AccessibleDescription = resources.GetString(
				"panel6.AccessibleDescription"
			);
			panel6.AccessibleName = resources.GetString("panel6.AccessibleName");
			panel6.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel6.Anchor")
				)
			);
			panel6.AutoScroll = ((bool)(resources.GetObject("panel6.AutoScroll")));
			panel6.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("panel6.AutoScrollMargin"))
			);
			panel6.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("panel6.AutoScrollMinSize"))
			);
			panel6.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage"))
			);
			panel6.Dock = (
				(DockStyle)(resources.GetObject("panel6.Dock"))
			);
			panel6.Enabled = ((bool)(resources.GetObject("panel6.Enabled")));
			panel6.Font = (
				(System.Drawing.Font)(resources.GetObject("panel6.Font"))
			);
			panel6.ImeMode = (
				(ImeMode)(resources.GetObject("panel6.ImeMode"))
			);
			panel6.Location = (
				(System.Drawing.Point)(resources.GetObject("panel6.Location"))
			);
			panel6.Name = "panel6";
			panel6.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel6.RightToLeft")
				)
			);
			panel6.Size = (
				(System.Drawing.Size)(resources.GetObject("panel6.Size"))
			);
			panel6.TabIndex = ((int)(resources.GetObject("panel6.TabIndex")));
			panel6.Text = resources.GetString("panel6.Text");
			panel6.Visible = ((bool)(resources.GetObject("panel6.Visible")));
			//
			// panel4
			//
			panel4.AccessibleDescription = resources.GetString(
				"panel4.AccessibleDescription"
			);
			panel4.AccessibleName = resources.GetString("panel4.AccessibleName");
			panel4.Anchor = (
				(AnchorStyles)(
					resources.GetObject("panel4.Anchor")
				)
			);
			panel4.AutoScroll = ((bool)(resources.GetObject("panel4.AutoScroll")));
			panel4.AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("panel4.AutoScrollMargin"))
			);
			panel4.AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("panel4.AutoScrollMinSize"))
			);
			panel4.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage"))
			);
			panel4.Controls.Add(tbName);
			panel4.Controls.Add(lbName);
			panel4.Controls.Add(lbDuration);
			panel4.Controls.Add(tbDuration);
			panel4.Controls.Add(llClone);
			panel4.Controls.Add(llRefresh);
			panel4.Controls.Add(lbTimeCode);
			panel4.Controls.Add(tbTimeCode);
			panel4.Controls.Add(llAdd);
			panel4.Controls.Add(llClear);
			panel4.Dock = (
				(DockStyle)(resources.GetObject("panel4.Dock"))
			);
			panel4.Enabled = ((bool)(resources.GetObject("panel4.Enabled")));
			panel4.Font = (
				(System.Drawing.Font)(resources.GetObject("panel4.Font"))
			);
			panel4.ImeMode = (
				(ImeMode)(resources.GetObject("panel4.ImeMode"))
			);
			panel4.Location = (
				(System.Drawing.Point)(resources.GetObject("panel4.Location"))
			);
			panel4.Name = "panel4";
			panel4.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("panel4.RightToLeft")
				)
			);
			panel4.Size = (
				(System.Drawing.Size)(resources.GetObject("panel4.Size"))
			);
			panel4.TabIndex = ((int)(resources.GetObject("panel4.TabIndex")));
			panel4.Text = resources.GetString("panel4.Text");
			panel4.Visible = ((bool)(resources.GetObject("panel4.Visible")));
			//
			// tbName
			//
			tbName.AccessibleDescription = resources.GetString(
				"tbName.AccessibleDescription"
			);
			tbName.AccessibleName = resources.GetString("tbName.AccessibleName");
			tbName.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbName.Anchor")
				)
			);
			tbName.AutoSize = ((bool)(resources.GetObject("tbName.AutoSize")));
			tbName.BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("tbName.BackgroundImage"))
			);
			tbName.Dock = (
				(DockStyle)(resources.GetObject("tbName.Dock"))
			);
			tbName.Enabled = ((bool)(resources.GetObject("tbName.Enabled")));
			tbName.Font = (
				(System.Drawing.Font)(resources.GetObject("tbName.Font"))
			);
			tbName.ImeMode = (
				(ImeMode)(resources.GetObject("tbName.ImeMode"))
			);
			tbName.Location = (
				(System.Drawing.Point)(resources.GetObject("tbName.Location"))
			);
			tbName.MaxLength = ((int)(resources.GetObject("tbName.MaxLength")));
			tbName.Multiline = ((bool)(resources.GetObject("tbName.Multiline")));
			tbName.Name = "tbName";
			tbName.PasswordChar = (
				(char)(resources.GetObject("tbName.PasswordChar"))
			);
			tbName.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbName.RightToLeft")
				)
			);
			tbName.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbName.ScrollBars")
				)
			);
			tbName.Size = (
				(System.Drawing.Size)(resources.GetObject("tbName.Size"))
			);
			tbName.TabIndex = ((int)(resources.GetObject("tbName.TabIndex")));
			tbName.Text = resources.GetString("tbName.Text");
			tbName.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbName.TextAlign")
				)
			);
			tbName.Visible = ((bool)(resources.GetObject("tbName.Visible")));
			tbName.WordWrap = ((bool)(resources.GetObject("tbName.WordWrap")));
			tbName.TextChanged += new System.EventHandler(tbName_TextChanged);
			//
			// lbName
			//
			lbName.AccessibleDescription = resources.GetString(
				"lbName.AccessibleDescription"
			);
			lbName.AccessibleName = resources.GetString("lbName.AccessibleName");
			lbName.Anchor = (
				(AnchorStyles)(
					resources.GetObject("lbName.Anchor")
				)
			);
			lbName.AutoSize = ((bool)(resources.GetObject("lbName.AutoSize")));
			lbName.Dock = (
				(DockStyle)(resources.GetObject("lbName.Dock"))
			);
			lbName.Enabled = ((bool)(resources.GetObject("lbName.Enabled")));
			lbName.Font = (
				(System.Drawing.Font)(resources.GetObject("lbName.Font"))
			);
			lbName.Image = (
				(System.Drawing.Image)(resources.GetObject("lbName.Image"))
			);
			lbName.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("lbName.ImageAlign")
				)
			);
			lbName.ImageIndex = ((int)(resources.GetObject("lbName.ImageIndex")));
			lbName.ImeMode = (
				(ImeMode)(resources.GetObject("lbName.ImeMode"))
			);
			lbName.Location = (
				(System.Drawing.Point)(resources.GetObject("lbName.Location"))
			);
			lbName.Name = "lbName";
			lbName.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("lbName.RightToLeft")
				)
			);
			lbName.Size = (
				(System.Drawing.Size)(resources.GetObject("lbName.Size"))
			);
			lbName.TabIndex = ((int)(resources.GetObject("lbName.TabIndex")));
			lbName.Text = resources.GetString("lbName.Text");
			lbName.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("lbName.TextAlign")
				)
			);
			lbName.Visible = ((bool)(resources.GetObject("lbName.Visible")));
			//
			// lbDuration
			//
			lbDuration.AccessibleDescription = resources.GetString(
				"lbDuration.AccessibleDescription"
			);
			lbDuration.AccessibleName = resources.GetString(
				"lbDuration.AccessibleName"
			);
			lbDuration.Anchor = (
				(AnchorStyles)(
					resources.GetObject("lbDuration.Anchor")
				)
			);
			lbDuration.AutoSize = (
				(bool)(resources.GetObject("lbDuration.AutoSize"))
			);
			lbDuration.Dock = (
				(DockStyle)(resources.GetObject("lbDuration.Dock"))
			);
			lbDuration.Enabled = (
				(bool)(resources.GetObject("lbDuration.Enabled"))
			);
			lbDuration.Font = (
				(System.Drawing.Font)(resources.GetObject("lbDuration.Font"))
			);
			lbDuration.Image = (
				(System.Drawing.Image)(resources.GetObject("lbDuration.Image"))
			);
			lbDuration.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("lbDuration.ImageAlign")
				)
			);
			lbDuration.ImageIndex = (
				(int)(resources.GetObject("lbDuration.ImageIndex"))
			);
			lbDuration.ImeMode = (
				(ImeMode)(
					resources.GetObject("lbDuration.ImeMode")
				)
			);
			lbDuration.Location = (
				(System.Drawing.Point)(resources.GetObject("lbDuration.Location"))
			);
			lbDuration.Name = "lbDuration";
			lbDuration.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("lbDuration.RightToLeft")
				)
			);
			lbDuration.Size = (
				(System.Drawing.Size)(resources.GetObject("lbDuration.Size"))
			);
			lbDuration.TabIndex = (
				(int)(resources.GetObject("lbDuration.TabIndex"))
			);
			lbDuration.Text = resources.GetString("lbDuration.Text");
			lbDuration.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("lbDuration.TextAlign")
				)
			);
			lbDuration.Visible = (
				(bool)(resources.GetObject("lbDuration.Visible"))
			);
			//
			// tbDuration
			//
			tbDuration.AccessibleDescription = resources.GetString(
				"tbDuration.AccessibleDescription"
			);
			tbDuration.AccessibleName = resources.GetString(
				"tbDuration.AccessibleName"
			);
			tbDuration.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbDuration.Anchor")
				)
			);
			tbDuration.AutoSize = (
				(bool)(resources.GetObject("tbDuration.AutoSize"))
			);
			tbDuration.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("tbDuration.BackgroundImage")
				)
			);
			tbDuration.Dock = (
				(DockStyle)(resources.GetObject("tbDuration.Dock"))
			);
			tbDuration.Enabled = (
				(bool)(resources.GetObject("tbDuration.Enabled"))
			);
			tbDuration.Font = (
				(System.Drawing.Font)(resources.GetObject("tbDuration.Font"))
			);
			tbDuration.ImeMode = (
				(ImeMode)(
					resources.GetObject("tbDuration.ImeMode")
				)
			);
			tbDuration.Location = (
				(System.Drawing.Point)(resources.GetObject("tbDuration.Location"))
			);
			tbDuration.MaxLength = (
				(int)(resources.GetObject("tbDuration.MaxLength"))
			);
			tbDuration.Multiline = (
				(bool)(resources.GetObject("tbDuration.Multiline"))
			);
			tbDuration.Name = "tbDuration";
			tbDuration.PasswordChar = (
				(char)(resources.GetObject("tbDuration.PasswordChar"))
			);
			tbDuration.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbDuration.RightToLeft")
				)
			);
			tbDuration.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbDuration.ScrollBars")
				)
			);
			tbDuration.Size = (
				(System.Drawing.Size)(resources.GetObject("tbDuration.Size"))
			);
			tbDuration.TabIndex = (
				(int)(resources.GetObject("tbDuration.TabIndex"))
			);
			tbDuration.Text = resources.GetString("tbDuration.Text");
			tbDuration.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbDuration.TextAlign")
				)
			);
			tbDuration.Visible = (
				(bool)(resources.GetObject("tbDuration.Visible"))
			);
			tbDuration.WordWrap = (
				(bool)(resources.GetObject("tbDuration.WordWrap"))
			);
			tbDuration.TextChanged += new System.EventHandler(
				tbDuration_TextChanged
			);
			//
			// llClone
			//
			llClone.AccessibleDescription = resources.GetString(
				"llClone.AccessibleDescription"
			);
			llClone.AccessibleName = resources.GetString("llClone.AccessibleName");
			llClone.Anchor = (
				(AnchorStyles)(
					resources.GetObject("llClone.Anchor")
				)
			);
			llClone.AutoSize = ((bool)(resources.GetObject("llClone.AutoSize")));
			llClone.Dock = (
				(DockStyle)(resources.GetObject("llClone.Dock"))
			);
			llClone.Enabled = ((bool)(resources.GetObject("llClone.Enabled")));
			llClone.Font = (
				(System.Drawing.Font)(resources.GetObject("llClone.Font"))
			);
			llClone.Image = (
				(System.Drawing.Image)(resources.GetObject("llClone.Image"))
			);
			llClone.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llClone.ImageAlign")
				)
			);
			llClone.ImageIndex = (
				(int)(resources.GetObject("llClone.ImageIndex"))
			);
			llClone.ImeMode = (
				(ImeMode)(resources.GetObject("llClone.ImeMode"))
			);
			llClone.LinkArea = (
				(LinkArea)(resources.GetObject("llClone.LinkArea"))
			);
			llClone.Location = (
				(System.Drawing.Point)(resources.GetObject("llClone.Location"))
			);
			llClone.Name = "llClone";
			llClone.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("llClone.RightToLeft")
				)
			);
			llClone.Size = (
				(System.Drawing.Size)(resources.GetObject("llClone.Size"))
			);
			llClone.TabIndex = ((int)(resources.GetObject("llClone.TabIndex")));
			llClone.TabStop = true;
			llClone.Text = resources.GetString("llClone.Text");
			llClone.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llClone.TextAlign")
				)
			);
			llClone.Visible = ((bool)(resources.GetObject("llClone.Visible")));
			llClone.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llClone_LinkClicked
				);
			//
			// llRefresh
			//
			llRefresh.AccessibleDescription = resources.GetString(
				"llRefresh.AccessibleDescription"
			);
			llRefresh.AccessibleName = resources.GetString(
				"llRefresh.AccessibleName"
			);
			llRefresh.Anchor = (
				(AnchorStyles)(
					resources.GetObject("llRefresh.Anchor")
				)
			);
			llRefresh.AutoSize = (
				(bool)(resources.GetObject("llRefresh.AutoSize"))
			);
			llRefresh.Dock = (
				(DockStyle)(resources.GetObject("llRefresh.Dock"))
			);
			llRefresh.Enabled = ((bool)(resources.GetObject("llRefresh.Enabled")));
			llRefresh.Font = (
				(System.Drawing.Font)(resources.GetObject("llRefresh.Font"))
			);
			llRefresh.Image = (
				(System.Drawing.Image)(resources.GetObject("llRefresh.Image"))
			);
			llRefresh.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llRefresh.ImageAlign")
				)
			);
			llRefresh.ImageIndex = (
				(int)(resources.GetObject("llRefresh.ImageIndex"))
			);
			llRefresh.ImeMode = (
				(ImeMode)(resources.GetObject("llRefresh.ImeMode"))
			);
			llRefresh.LinkArea = (
				(LinkArea)(
					resources.GetObject("llRefresh.LinkArea")
				)
			);
			llRefresh.Location = (
				(System.Drawing.Point)(resources.GetObject("llRefresh.Location"))
			);
			llRefresh.Name = "llRefresh";
			llRefresh.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("llRefresh.RightToLeft")
				)
			);
			llRefresh.Size = (
				(System.Drawing.Size)(resources.GetObject("llRefresh.Size"))
			);
			llRefresh.TabIndex = (
				(int)(resources.GetObject("llRefresh.TabIndex"))
			);
			llRefresh.TabStop = true;
			llRefresh.Text = resources.GetString("llRefresh.Text");
			llRefresh.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llRefresh.TextAlign")
				)
			);
			llRefresh.Visible = ((bool)(resources.GetObject("llRefresh.Visible")));
			llRefresh.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llRefresh_LinkClicked
				);
			//
			// lbTimeCode
			//
			lbTimeCode.AccessibleDescription = resources.GetString(
				"lbTimeCode.AccessibleDescription"
			);
			lbTimeCode.AccessibleName = resources.GetString(
				"lbTimeCode.AccessibleName"
			);
			lbTimeCode.Anchor = (
				(AnchorStyles)(
					resources.GetObject("lbTimeCode.Anchor")
				)
			);
			lbTimeCode.AutoSize = (
				(bool)(resources.GetObject("lbTimeCode.AutoSize"))
			);
			lbTimeCode.Dock = (
				(DockStyle)(resources.GetObject("lbTimeCode.Dock"))
			);
			lbTimeCode.Enabled = (
				(bool)(resources.GetObject("lbTimeCode.Enabled"))
			);
			lbTimeCode.Font = (
				(System.Drawing.Font)(resources.GetObject("lbTimeCode.Font"))
			);
			lbTimeCode.Image = (
				(System.Drawing.Image)(resources.GetObject("lbTimeCode.Image"))
			);
			lbTimeCode.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("lbTimeCode.ImageAlign")
				)
			);
			lbTimeCode.ImageIndex = (
				(int)(resources.GetObject("lbTimeCode.ImageIndex"))
			);
			lbTimeCode.ImeMode = (
				(ImeMode)(
					resources.GetObject("lbTimeCode.ImeMode")
				)
			);
			lbTimeCode.Location = (
				(System.Drawing.Point)(resources.GetObject("lbTimeCode.Location"))
			);
			lbTimeCode.Name = "lbTimeCode";
			lbTimeCode.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("lbTimeCode.RightToLeft")
				)
			);
			lbTimeCode.Size = (
				(System.Drawing.Size)(resources.GetObject("lbTimeCode.Size"))
			);
			lbTimeCode.TabIndex = (
				(int)(resources.GetObject("lbTimeCode.TabIndex"))
			);
			lbTimeCode.Text = resources.GetString("lbTimeCode.Text");
			lbTimeCode.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("lbTimeCode.TextAlign")
				)
			);
			lbTimeCode.Visible = (
				(bool)(resources.GetObject("lbTimeCode.Visible"))
			);
			//
			// tbTimeCode
			//
			tbTimeCode.AccessibleDescription = resources.GetString(
				"tbTimeCode.AccessibleDescription"
			);
			tbTimeCode.AccessibleName = resources.GetString(
				"tbTimeCode.AccessibleName"
			);
			tbTimeCode.Anchor = (
				(AnchorStyles)(
					resources.GetObject("tbTimeCode.Anchor")
				)
			);
			tbTimeCode.AutoSize = (
				(bool)(resources.GetObject("tbTimeCode.AutoSize"))
			);
			tbTimeCode.BackgroundImage = (
				(System.Drawing.Image)(
					resources.GetObject("tbTimeCode.BackgroundImage")
				)
			);
			tbTimeCode.Dock = (
				(DockStyle)(resources.GetObject("tbTimeCode.Dock"))
			);
			tbTimeCode.Enabled = (
				(bool)(resources.GetObject("tbTimeCode.Enabled"))
			);
			tbTimeCode.Font = (
				(System.Drawing.Font)(resources.GetObject("tbTimeCode.Font"))
			);
			tbTimeCode.ImeMode = (
				(ImeMode)(
					resources.GetObject("tbTimeCode.ImeMode")
				)
			);
			tbTimeCode.Location = (
				(System.Drawing.Point)(resources.GetObject("tbTimeCode.Location"))
			);
			tbTimeCode.MaxLength = (
				(int)(resources.GetObject("tbTimeCode.MaxLength"))
			);
			tbTimeCode.Multiline = (
				(bool)(resources.GetObject("tbTimeCode.Multiline"))
			);
			tbTimeCode.Name = "tbTimeCode";
			tbTimeCode.PasswordChar = (
				(char)(resources.GetObject("tbTimeCode.PasswordChar"))
			);
			tbTimeCode.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("tbTimeCode.RightToLeft")
				)
			);
			tbTimeCode.ScrollBars = (
				(ScrollBars)(
					resources.GetObject("tbTimeCode.ScrollBars")
				)
			);
			tbTimeCode.Size = (
				(System.Drawing.Size)(resources.GetObject("tbTimeCode.Size"))
			);
			tbTimeCode.TabIndex = (
				(int)(resources.GetObject("tbTimeCode.TabIndex"))
			);
			tbTimeCode.Text = resources.GetString("tbTimeCode.Text");
			tbTimeCode.TextAlign = (
				(HorizontalAlignment)(
					resources.GetObject("tbTimeCode.TextAlign")
				)
			);
			tbTimeCode.Visible = (
				(bool)(resources.GetObject("tbTimeCode.Visible"))
			);
			tbTimeCode.WordWrap = (
				(bool)(resources.GetObject("tbTimeCode.WordWrap"))
			);
			tbTimeCode.TextChanged += new System.EventHandler(
				tbTimeCode_TextChanged_1
			);
			tbTimeCode.KeyUp += new KeyEventHandler(
				tbTimeCode_KeyUp
			);
			//
			// llAdd
			//
			llAdd.AccessibleDescription = resources.GetString(
				"llAdd.AccessibleDescription"
			);
			llAdd.AccessibleName = resources.GetString("llAdd.AccessibleName");
			llAdd.Anchor = (
				(AnchorStyles)(resources.GetObject("llAdd.Anchor"))
			);
			llAdd.AutoSize = ((bool)(resources.GetObject("llAdd.AutoSize")));
			llAdd.Dock = (
				(DockStyle)(resources.GetObject("llAdd.Dock"))
			);
			llAdd.Enabled = ((bool)(resources.GetObject("llAdd.Enabled")));
			llAdd.Font = (
				(System.Drawing.Font)(resources.GetObject("llAdd.Font"))
			);
			llAdd.Image = (
				(System.Drawing.Image)(resources.GetObject("llAdd.Image"))
			);
			llAdd.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llAdd.ImageAlign")
				)
			);
			llAdd.ImageIndex = ((int)(resources.GetObject("llAdd.ImageIndex")));
			llAdd.ImeMode = (
				(ImeMode)(resources.GetObject("llAdd.ImeMode"))
			);
			llAdd.LinkArea = (
				(LinkArea)(resources.GetObject("llAdd.LinkArea"))
			);
			llAdd.Location = (
				(System.Drawing.Point)(resources.GetObject("llAdd.Location"))
			);
			llAdd.Name = "llAdd";
			llAdd.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("llAdd.RightToLeft")
				)
			);
			llAdd.Size = (
				(System.Drawing.Size)(resources.GetObject("llAdd.Size"))
			);
			llAdd.TabIndex = ((int)(resources.GetObject("llAdd.TabIndex")));
			llAdd.TabStop = true;
			llAdd.Text = resources.GetString("llAdd.Text");
			llAdd.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llAdd.TextAlign")
				)
			);
			llAdd.Visible = ((bool)(resources.GetObject("llAdd.Visible")));
			llAdd.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llAdd_LinkClicked
				);
			//
			// llClear
			//
			llClear.AccessibleDescription = resources.GetString(
				"llClear.AccessibleDescription"
			);
			llClear.AccessibleName = resources.GetString("llClear.AccessibleName");
			llClear.Anchor = (
				(AnchorStyles)(
					resources.GetObject("llClear.Anchor")
				)
			);
			llClear.AutoSize = ((bool)(resources.GetObject("llClear.AutoSize")));
			llClear.Dock = (
				(DockStyle)(resources.GetObject("llClear.Dock"))
			);
			llClear.Enabled = ((bool)(resources.GetObject("llClear.Enabled")));
			llClear.Font = (
				(System.Drawing.Font)(resources.GetObject("llClear.Font"))
			);
			llClear.Image = (
				(System.Drawing.Image)(resources.GetObject("llClear.Image"))
			);
			llClear.ImageAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llClear.ImageAlign")
				)
			);
			llClear.ImageIndex = (
				(int)(resources.GetObject("llClear.ImageIndex"))
			);
			llClear.ImeMode = (
				(ImeMode)(resources.GetObject("llClear.ImeMode"))
			);
			llClear.LinkArea = (
				(LinkArea)(resources.GetObject("llClear.LinkArea"))
			);
			llClear.Location = (
				(System.Drawing.Point)(resources.GetObject("llClear.Location"))
			);
			llClear.Name = "llClear";
			llClear.RightToLeft = (
				(RightToLeft)(
					resources.GetObject("llClear.RightToLeft")
				)
			);
			llClear.Size = (
				(System.Drawing.Size)(resources.GetObject("llClear.Size"))
			);
			llClear.TabIndex = ((int)(resources.GetObject("llClear.TabIndex")));
			llClear.TabStop = true;
			llClear.Text = resources.GetString("llClear.Text");
			llClear.TextAlign = (
				(System.Drawing.ContentAlignment)(
					resources.GetObject("llClear.TextAlign")
				)
			);
			llClear.Visible = ((bool)(resources.GetObject("llClear.Visible")));
			llClear.LinkClicked +=
				new LinkLabelLinkClickedEventHandler(
					llClear_LinkClicked
				);
			//
			// AnimFrameBlockControl
			//
			AccessibleDescription = resources.GetString(
				"$this.AccessibleDescription"
			);
			AccessibleName = resources.GetString("$this.AccessibleName");
			AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			AutoScrollMargin = (
				(System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin"))
			);
			AutoScrollMinSize = (
				(System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize"))
			);
			BackgroundImage = (
				(System.Drawing.Image)(resources.GetObject("$this.BackgroundImage"))
			);
			Controls.Add(tv);
			Controls.Add(splitter1);
			Controls.Add(panel2);
			Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			ImeMode = (
				(ImeMode)(resources.GetObject("$this.ImeMode"))
			);
			Location = (
				(System.Drawing.Point)(resources.GetObject("$this.Location"))
			);
			Name = "AnimFrameBlockControl";
			RightToLeft = (
				(RightToLeft)(
					resources.GetObject("$this.RightToLeft")
				)
			);
			Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			panel2.ResumeLayout(false);
			pnSplit2.ResumeLayout(false);
			pnSplit1.ResumeLayout(false);
			panel5.ResumeLayout(false);
			panel4.ResumeLayout(false);
			ResumeLayout(false);
		}
		#endregion

		#region Public Properties
		AnimationFrameBlock afb;
		public AnimationFrameBlock FrameBlock
		{
			get => afb;
			set
			{
				afb = value;
				RefreshData();
			}
		}
		#endregion

		void Enable(bool enabled)
		{
			tbDuration.Enabled = enabled;
			lbDuration.Enabled = enabled;
			tbName.Enabled = enabled;
			lbName.Enabled = enabled;

			miRem.Enabled = enabled;
			miExp.Enabled = enabled;
			miSort.Enabled = enabled;
			miSlp.Enabled = miClp.Enabled = enabled;
			llAdd.Enabled = enabled;
			llClear.Enabled = enabled;
		}

		public void Clear()
		{
			intern = true;
			tv.Nodes.Clear();

			intern = true;
			llClone.Enabled = false;

			Enable(false);
			tbTimeCode.Enabled = false;
			lbTimeCode.Enabled = tbTimeCode.Enabled;
			tbName.Text = "";
			tbTimeCode.Text = "0";
			tbDuration.Text = "0";
			intern = false;
		}

		public void RefreshData()
		{
			Clear();

			if (afb != null)
			{
				intern = true;
				Enable(true);
				tbName.Text = afb.Name;
				tbDuration.Text = afb.Duration.ToString();

				AddFrames(afb.Frames, "");
				intern = false;
			}
		}

		protected void AddFrames(AnimationFrame[] fr, string prefix)
		{
			foreach (AnimationFrame af in fr)
			{
				AddFrames(af, prefix);
			}
		}

		protected void AddFrames(AnimationFrame af, string prefix)
		{
			int ct = 0;
			foreach (AnimationAxisTransform aat in af.Blocks)
			{
				if (aat != null)
				{
					ct++;
				}
			}

			TreeNode tn = new TreeNode(
				prefix
					+ "tc="
					+ af.TimeCode.ToString()
					+ ", comp="
					+ ct
					+ ", "
					+ af.Type.ToString()
			)
			{
				Tag = af
			};

			AddFrame(tn, af.XBlock, "X: ");
			AddFrame(tn, af.YBlock, "Y: ");
			AddFrame(tn, af.ZBlock, "Z: ");

			tv.Nodes.Add(tn);
		}

		protected void AddFrame(
			TreeNode parent,
			AnimationAxisTransform aat,
			string prefix
		)
		{
			if (parent == null)
			{
				return;
			}

			if (aat == null)
			{
				return;
			}

			TreeNode tn = new TreeNode(prefix + aat.ToString())
			{
				Tag = aat
			};

			parent.Nodes.Add(tn);
		}

		bool intern;

		private void tv_AfterSelect(
			object sender,
			TreeViewEventArgs e
		)
		{
			pn1.AxisTransform = null;
			pn2.Visible = false;
			pn3.Visible = false;
			pn2.AxisTransform = null;
			pn3.AxisTransform = null;
			panel2.AutoScroll = false;
			pn1.CanCreate = false;
			tbTimeCode.Enabled = false;
			lbTimeCode.Enabled = tbTimeCode.Enabled;
			llClone.Enabled = false;
			if (e == null)
			{
				return;
			}

			if (e.Node == null)
			{
				return;
			}

			if (e.Node.Tag == null)
			{
				return;
			}

			if (e.Node.Tag is AnimationAxisTransform)
			{
				pn1.AxisTransform = (AnimationAxisTransform)e.Node.Tag;

				pn1.Tag = e.Node;
			}
			else if (e.Node.Tag is AnimationFrame)
			{
				llClone.Enabled = true;
				pn3.Visible = true;
				pn2.Visible = true;

				panel2.AutoScroll = true;
				pn1.CanCreate = true;
				pn2.CanCreate = true;
				pn3.CanCreate = true;

				AnimAxisTransformControl[] aatcs = new AnimAxisTransformControl[3];
				aatcs[0] = pn1;
				aatcs[1] = pn2;
				aatcs[2] = pn3;

				foreach (TreeNode n in e.Node.Nodes)
				{
					int ct = 0;
					if (n.Text[0] == 'X')
					{
						ct = 0;
					}
					else if (n.Text[0] == 'Y')
					{
						ct = 1;
					}
					else if (n.Text[0] == 'Z')
					{
						ct = 2;
					}
					else
					{
						continue;
					}

					aatcs[ct].AxisTransform = (AnimationAxisTransform)n.Tag;
					aatcs[ct].Tag = n;

					if (!tbTimeCode.Enabled)
					{
						intern = true;
						tbTimeCode.Enabled = true;
						lbTimeCode.Enabled = tbTimeCode.Enabled;
						if (aatcs[ct].AxisTransform != null)
						{
							tbTimeCode.Text = aatcs[ct]
								.AxisTransform.TimeCode.ToString();
						}

						intern = false;
					}
				}
			}
		}

		private void pn3_VisibleChanged(object sender, System.EventArgs e)
		{
			pnSplit2.Visible = pn3.Visible;
		}

		private void pn2_VisibleChanged(object sender, System.EventArgs e)
		{
			pnSplit1.Visible = pn2.Visible;
		}

		private void pn1_Deleted(object sender, System.EventArgs e)
		{
			if (!(sender is AnimAxisTransformControl))
			{
				return;
			}

			AnimAxisTransformControl s = (AnimAxisTransformControl)sender;
			TreeNode n = (TreeNode)s.Tag;

			n.Parent.Nodes.Remove(n);
			if (Changed != null)
			{
				Changed(this, new System.EventArgs());
			}
		}

		private void pn1_Changed(object sender, System.EventArgs e)
		{
			if (!(sender is AnimAxisTransformControl))
			{
				return;
			}

			AnimAxisTransformControl s = (AnimAxisTransformControl)sender;
			TreeNode n = (TreeNode)s.Tag;

			if (n != null && s.AxisTransform != null)
			{
				n.Text = n.Text.Substring(0, 3) + s.AxisTransform.ToString();
				if (Changed != null)
				{
					Changed(this, new System.EventArgs());
				}
			}
		}

		private void llClear_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			afb.ClearFrames();
			tv.Nodes.Clear();

			if (Changed != null)
			{
				Changed(this, new System.EventArgs());
			}
		}

		private void llAdd_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (afb.AxisCount == 0)
			{
				afb.CreateBaseAxisSet();
			}

			afb.ChangeTokenType(AnimationTokenType.TwoByte, AnimationTokenType.SixByte);
			afb.AddFrame((short)(afb.GetDuration() + 1), 0, 0, 0, false);
			afb.SortByTimeCode();
			AddFrames(afb.Frames[afb.FrameCount - 1], "");

			if (Changed != null)
			{
				Changed(this, new System.EventArgs());
			}
		}

		private void pn1_CreateClicked(object sender, System.EventArgs e)
		{
			if (tv.SelectedNode == null)
			{
				return;
			}

			if (!(tv.SelectedNode.Tag is AnimationFrame))
			{
				return;
			}

			AnimationFrame af = (AnimationFrame)tv.SelectedNode.Tag;
			while (afb.AxisSet.Length < 1)
			{
				afb.AddNewAxis();
			}

			AnimationAxisTransform aat = afb.AxisSet[0]
				.Add(af.TimeCode, 0, 0, 0, af.Linear);
			af.XBlock = afb.AxisSet[0].GetLast();
			AddFrame(tv.SelectedNode, aat, "X: ");

			tv_AfterSelect(
				tv,
				new TreeViewEventArgs(tv.SelectedNode, TreeViewAction.ByMouse)
			);
		}

		private void pn2_CreateClicked(object sender, System.EventArgs e)
		{
			if (tv.SelectedNode == null)
			{
				return;
			}

			if (!(tv.SelectedNode.Tag is AnimationFrame))
			{
				return;
			}

			AnimationFrame af = (AnimationFrame)tv.SelectedNode.Tag;
			while (afb.AxisSet.Length < 2)
			{
				afb.AddNewAxis();
			}

			AnimationAxisTransform aat = afb.AxisSet[1]
				.Add(af.TimeCode, 0, 0, 0, af.Linear);
			af.YBlock = afb.AxisSet[1].GetLast();
			AddFrame(tv.SelectedNode, aat, "Y: ");

			tv_AfterSelect(
				tv,
				new TreeViewEventArgs(tv.SelectedNode, TreeViewAction.ByMouse)
			);
		}

		private void pn3_CreateClicked(object sender, System.EventArgs e)
		{
			if (tv.SelectedNode == null)
			{
				return;
			}

			if (!(tv.SelectedNode.Tag is AnimationFrame))
			{
				return;
			}

			AnimationFrame af = (AnimationFrame)tv.SelectedNode.Tag;
			while (afb.AxisSet.Length < 3)
			{
				afb.AddNewAxis();
			}

			if (afb.AxisSet[2].Type == AnimationTokenType.TwoByte)
			{
				afb.AxisSet[2].Type = AnimationTokenType.SixByte;
			}

			AnimationAxisTransform aat = afb.AxisSet[2]
				.Add(af.TimeCode, 0, 0, 0, af.Linear);
			af.ZBlock = afb.AxisSet[2].GetLast();
			AddFrame(tv.SelectedNode, aat, "Z: ");

			tv_AfterSelect(
				tv,
				new TreeViewEventArgs(tv.SelectedNode, TreeViewAction.ByMouse)
			);
		}

		private void tbTimeCode_TextChanged(object sender, System.EventArgs e)
		{
			if (tv.SelectedNode == null)
			{
				return;
			}

			if (!(tv.SelectedNode.Tag is AnimationFrame))
			{
				return;
			}

			if (intern)
			{
				return;
			}

			intern = true;
			try
			{
				short val = Helper.StringToInt16(tbTimeCode.Text, 0, 10);

				AnimationFrame af = (AnimationFrame)tv.SelectedNode.Tag;
				if (af.XBlock != null)
				{
					af.XBlock.TimeCode = val;
				}

				if (af.YBlock != null)
				{
					af.YBlock.TimeCode = val;
				}

				if (af.ZBlock != null)
				{
					af.ZBlock.TimeCode = val;
				}

				tv_AfterSelect(
					tv,
					new TreeViewEventArgs(tv.SelectedNode, TreeViewAction.ByMouse)
				);
				pn1_Changed(pn1, null);
				pn1_Changed(pn2, null);
				pn1_Changed(pn3, null);
			}
			finally
			{
				intern = false;
			}
		}

		private void tbTimeCode_KeyUp(
			object sender,
			KeyEventArgs e
		)
		{
			if (e.KeyCode == Keys.Enter)
			{
				tbTimeCode_TextChanged(sender, null);
			}
		}

		private void llRefresh_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			RefreshData();
		}

		private void llClone_LinkClicked(
			object sender,
			LinkLabelLinkClickedEventArgs e
		)
		{
			if (tv.SelectedNode == null)
			{
				return;
			}

			if (!(tv.SelectedNode.Tag is AnimationFrame))
			{
				return;
			}

			AnimationFrame af = (AnimationFrame)tv.SelectedNode.Tag;
			afb.ChangeTokenType(AnimationTokenType.TwoByte, AnimationTokenType.SixByte);
			afb.AddFrame((short)(afb.GetDuration() + 1), af.X, af.Y, af.Z, af.Linear);
			AddFrames(afb.Frames[afb.FrameCount - 1], "");

			if (Changed != null)
			{
				Changed(this, new System.EventArgs());
			}
		}

		private void tbTimeCode_TextChanged_1(object sender, System.EventArgs e)
		{
			if (tv.SelectedNode == null)
			{
				return;
			}

			if (!(tv.SelectedNode.Tag is AnimationFrame))
			{
				return;
			}

			if (intern)
			{
				return;
			}

			intern = true;
			try
			{
				short val = Helper.StringToInt16(tbTimeCode.Text, 0, 10);

				AnimationFrame af = (AnimationFrame)tv.SelectedNode.Tag;
				if (af.XBlock != null)
				{
					af.XBlock.TimeCode = val;
				}

				if (af.YBlock != null)
				{
					af.YBlock.TimeCode = val;
				}

				if (af.ZBlock != null)
				{
					af.ZBlock.TimeCode = val;
				}

				pn1_Changed(pn1, null);
				pn1_Changed(pn2, null);
				pn1_Changed(pn3, null);

				afb.SortByTimeCode();
			}
			finally
			{
				intern = false;
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			string Clap = afb.Name + "\r\n";
			foreach (TreeNode tn in tv.Nodes)
			{
				Clap += tn.ToString().Replace("TreeNode: tc=", "time code= ") + "\r\n";
				foreach (TreeNode sn in tn.Nodes)
				{
					Clap += sn.ToString().Replace("TreeNode:", "  ") + "\r\n";
				}
				Clap += "\r\n";
			}
			Clipboard.SetDataObject(Clap, true);
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			string Clap = afb.Name + "\r\n";
			float f;
			float f1;
			float f2;
			foreach (AnimationFrame af in afb.Frames)
			{
				Clap +=
					"time code= "
					+ af.TimeCode.ToString()
					+ ", "
					+ af.Type.ToString()
					+ "\r\n";
				if (af.XBlock != null)
				{
					f = af.XBlock.GetCompressedFloat(af.XBlock.Parameter);
					if (afb.TransformationType == FrameType.Rotation)
					{
						f = (float)Geometry.Quaternion.RadToDeg(f);
					}

					if (f == 0)
					{
						Clap += "   X: 0";
					}
					else
					{
						Clap += "   X: " + f.ToString("N8");
					}

					f1 = af.XBlock.GetCompressedFloat(af.XBlock.Unknown1);
					if (f1 == 0)
					{
						Clap += "; 0";
					}
					else
					{
						Clap += "; " + f1.ToString("N8");
					}

					f2 = af.XBlock.GetCompressedFloat(af.XBlock.Unknown2);
					if (f2 == 0)
					{
						Clap += "; 0";
					}
					else
					{
						Clap += "; " + f2.ToString("N8");
					}

					if (af.XBlock.Linear)
					{
						Clap += " (linear)";
					}

					if (af.XBlock.ParentLocked)
					{
						Clap += " (locked)";
					}

					Clap += "\r\n";
				}
				if (af.YBlock != null)
				{
					f = af.YBlock.GetCompressedFloat(af.YBlock.Parameter);
					if (afb.TransformationType == FrameType.Rotation)
					{
						f = (float)Geometry.Quaternion.RadToDeg(f);
					}

					if (f == 0)
					{
						Clap += "   Y: 0";
					}
					else
					{
						Clap += "   Y: " + f.ToString("N8");
					}

					f1 = af.YBlock.GetCompressedFloat(af.YBlock.Unknown1);
					if (f1 == 0)
					{
						Clap += "; 0";
					}
					else
					{
						Clap += "; " + f1.ToString("N8");
					}

					f2 = af.YBlock.GetCompressedFloat(af.YBlock.Unknown2);
					if (f2 == 0)
					{
						Clap += "; 0";
					}
					else
					{
						Clap += "; " + f2.ToString("N8");
					}

					if (af.YBlock.Linear)
					{
						Clap += " (linear)";
					}

					if (af.YBlock.ParentLocked)
					{
						Clap += " (locked)";
					}

					Clap += "\r\n";
				}
				if (af.ZBlock != null)
				{
					f = af.ZBlock.GetCompressedFloat(af.ZBlock.Parameter);
					if (afb.TransformationType == FrameType.Rotation)
					{
						f = (float)Geometry.Quaternion.RadToDeg(f);
					}

					if (f == 0)
					{
						Clap += "   Z: 0";
					}
					else
					{
						Clap += "   Z: " + f.ToString("N8");
					}

					f1 = af.ZBlock.GetCompressedFloat(af.ZBlock.Unknown1);
					if (f1 == 0)
					{
						Clap += "; 0";
					}
					else
					{
						Clap += "; " + f1.ToString("N8");
					}

					f2 = af.ZBlock.GetCompressedFloat(af.ZBlock.Unknown2);
					if (f2 == 0)
					{
						Clap += "; 0";
					}
					else
					{
						Clap += "; " + f2.ToString("N8");
					}

					if (af.ZBlock.Linear)
					{
						Clap += " (linear)";
					}

					if (af.ZBlock.ParentLocked)
					{
						Clap += " (locked)";
					}

					Clap += "\r\n";
				}
				Clap += "\r\n";
			}
			Clipboard.SetDataObject(Clap, true);
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			foreach (TreeNode tn in tv.Nodes)
			{
				tn.ExpandAll();
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			if (afb != null)
			{
				afb.RemoveUnneededFrames();
				RefreshData();

				if (Changed != null)
				{
					Changed(this, new System.EventArgs());
				}
			}
		}

		private void tbDuration_TextChanged(object sender, System.EventArgs e)
		{
			if (afb == null || intern)
			{
				return;
			}

			afb.Duration = Helper.StringToInt16(tbDuration.Text, afb.Duration, 10);
			if (afb.Parent != null)
			{
				if (afb.Parent.Parent != null)
				{
					afb.Parent.Parent.Changed = true;
				}
			}
		}

		private void tbName_TextChanged(object sender, System.EventArgs e)
		{
			if (afb == null || intern)
			{
				return;
			}

			afb.Name = tbName.Text;
			if (afb.Parent != null)
			{
				if (afb.Parent.Parent != null)
				{
					afb.Parent.Parent.Changed = true;
				}
			}
		}

		private void SortClick(object sender, System.EventArgs e)
		{
			if (afb != null)
			{
				afb.SortByTimeCode();
				RefreshData();
			}
		}

		#region Events
		public event System.EventHandler Changed;
		#endregion
	}
}
