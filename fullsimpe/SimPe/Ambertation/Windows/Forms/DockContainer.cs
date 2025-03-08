// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Ambertation.Windows.Forms.Graph;

namespace Ambertation.Windows.Forms
{
	[Designer(typeof(DockContainerDesigner))]
	[ToolboxItem(false)]
	public class DockContainer : NCUserControl, IButtonContainer
	{
		public enum Status
		{
			Collapsed,
			Expanded,
			Collapsing,
			Expanding
		}

		protected struct ContainerInfo
		{
			public bool TopLevel;

			public bool DockInside;

			public DockStyle Dock;

			public Rectangle OverlayRectangle;

			public SelectedHint Hint;

			public DockContainer Parent;

			public DockContainer Seed;

			public int SeedIndex;

			public override string ToString()
			{
				return string.Concat("hint:", Hint, ", topl:", TopLevel, ", dockins:", DockInside, ", dock:", Dock, ", rect:", OverlayRectangle, ", sid=", SeedIndex, ", parent:", Parent);
			}
		}

		private bool canresize;

		private RubberBandHelper rbh;

		private int index;

		private Control parent;

		private Size lastfit;

		protected List<DockContainer> containers;

		protected DockButtonBar.DockPanelList panels;

		protected BaseDockManager manager;

		private DockContainer pc;

		private bool noclean;

		private bool nccleanint;

		private Size expsz;

		private bool useastar;

		private Status state;

		private Guid? guid = null;

		private DockPanel hldp;

		private int layoutct;

		private bool hidesinglebut;

		protected override CreateParams CreateParams => base.CreateParams;

		internal bool CanResize
		{
			get
			{
				return canresize;
			}
			set
			{
				if (value != canresize)
				{
					canresize = value;
					DoDockChanged();
				}
			}
		}

		public BaseDockManager Manager
		{
			get
			{
				return manager;
			}
			set
			{
				SetManager(value);
			}
		}

		public DockManager DockManager => manager as DockManager;

		protected DockContainer ParentContainer
		{
			get
			{
				return pc;
			}
			set
			{
				pc = value;
			}
		}

		public bool NoCleanup
		{
			get
			{
				if (!noclean)
				{
					return nccleanint;
				}

				return true;
			}
			set
			{
				noclean = value;
			}
		}

		public Size ExpandedSize => expsz;

		internal Point ScreenLocation
		{
			get
			{
				if (base.Parent != null)
				{
					return base.Parent.PointToScreen(base.Location);
				}

				return base.Location;
			}
		}

		internal Size ScreenSize => base.ClientSize;

		internal Rectangle ScreenBounds => new Rectangle(ScreenLocation, ScreenSize);

		protected bool IsManager => this is DockManager;

		protected int SubControls
		{
			get
			{
				int num = 0;
				foreach (Control control in base.Controls)
				{
					if (!(control is Splitter) && !(control is DockContainer))
					{
						num++;
					}
				}

				return num;
			}
		}

		protected bool IgnoreAsTarget
		{
			get
			{
				if (!base.Visible)
				{
					return !useastar;
				}

				return false;
			}
		}

		public Status CollapseState => state;

		public DockAnimationEventArgs.Alignment Alignment => GetAlignment();

		public int MinimumDockSize => 20;

		public bool Collapsed
		{
			get
			{
				if (state != 0)
				{
					return state == Status.Collapsing;
				}

				return true;
			}
		}

		public bool Expanded
		{
			get
			{
				if (state != Status.Expanding)
				{
					return state == Status.Expanded;
				}

				return true;
			}
		}

		public Guid Guid
		{
			get
			{
				if (!guid.HasValue)
				{
					GenGUID();
				}

				return guid.Value;
			}
		}

		public DockPanel Highlight => hldp;

		public ButtonOrientation BestOrientation => ButtonOrientation.Bottom;

		public virtual bool OneChild => panels.Count <= 1;

		[DefaultValue(true)]
		public bool HideSingleButton
		{
			get
			{
				return hidesinglebut;
			}
			set
			{
				if (hidesinglebut != value)
				{
					hidesinglebut = value;
					if (Highlight != null && OneChild)
					{
						Highlight.NCRefresh();
					}
				}
			}
		}

		[Browsable(false)]
		public Image TabImage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Browsable(false)]
		public string TabText
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		public event EventHandler PanelCollectionChanged;

		protected override void OnDockChanged(EventArgs e)
		{
			base.OnDockChanged(e);
			DoDockChanged();
			SetTopMostContainer();
		}

		private void SetTopMostContainer()
		{
			if (Dock == DockStyle.Fill && base.Parent as DockManager == Manager)
			{
				BringToFront();
			}
		}

		protected virtual void DoDockChanged()
		{
			if (Manager == null)
			{
				return;
			}

			base.ResizeBorder.SetAll(val: false);
			if (!canresize)
			{
				base.NonClientMargin = new Padding(0);
				return;
			}

			base.NonClientMargin = Manager.Renderer.DockPanelRenderer.GetGripSize(Dock);
			if (Dock == DockStyle.Right)
			{
				base.ResizeBorder.Left = true;
			}
			else if (Dock == DockStyle.Top)
			{
				base.ResizeBorder.Bottom = true;
			}
			else if (Dock == DockStyle.Left)
			{
				base.ResizeBorder.Right = true;
			}
			else if (Dock == DockStyle.Bottom)
			{
				base.ResizeBorder.Top = true;
			}
		}

		protected override void OnNcPaint(NCPaintEventArgs e)
		{
			base.OnNcPaint(e);
			if (!(Manager == null))
			{
				Manager.Renderer.DockPanelRenderer.RenderGrip(this, e, Manager.Renderer.DockPanelRenderer.GetGripRectangle(e, Dock));
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
		}

		protected virtual bool MyWndProc(ref Message m)
		{
			if (m.HWnd != base.Handle)
			{
				return true;
			}

			if (m.Msg != 5 && m.Msg != 532)
			{
				if (m.Msg == 561)
				{
					parent = base.Parent;
					if (Manager != null)
					{
						Manager.SuspendLayout();
					}

					if (base.Parent != null)
					{
						base.Parent.SuspendLayout();
					}

					if (base.Parent != null)
					{
						index = base.Parent.Controls.GetChildIndex(this);
					}

					BringToFront();
					lastfit = base.Size;
					rbh = new RubberBandHelper(this);
					_ = base.Bounds;
				}
				else if (m.Msg == 562)
				{
					if (rbh != null)
					{
						Dock = rbh.ContainerDock;
					}

					if (base.Parent != null)
					{
						base.Parent.Controls.SetChildIndex(this, index);
					}

					if (rbh != null)
					{
						rbh.Close();
					}

					rbh = null;
					if (parent != null)
					{
						parent.ResumeLayout();
					}

					if (Manager != null)
					{
						Manager.ResumeLayout();
					}

					Refresh();
				}
			}

			return true;
		}

		internal DockContainer(BaseDockManager manager)
		{
			layoutct = 0;
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: false);
			SetStyle(ControlStyles.UserPaint, value: true);
			containers = new List<DockContainer>();
			panels = new DockButtonBar.DockPanelList();
			canresize = true;
			hidesinglebut = true;
			noclean = false;
			nccleanint = false;
			useastar = false;
			state = Status.Expanded;
			SetManager(manager);
			base.NonClientMargin = new Padding(0);
			MinimumSize = DefaultSize;
		}

		~DockContainer()
		{
			if (manager != null)
			{
				manager.Renderer.DockPanelRenderer.FinishedAnimation -= DockPanelRenderer_FinishedAnimation;
			}
		}

		public DockContainer()
			: this(null)
		{
		}

		internal void SetManager(BaseDockManager manager)
		{
			this.manager = manager;
			if (manager != null)
			{
				manager.Renderer.DockPanelRenderer.FinishedAnimation += DockPanelRenderer_FinishedAnimation;
			}

			DoDockChanged();
		}

		internal void SetNoCleanUpIntern(bool val)
		{
			nccleanint = val;
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
		}

		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			pc = base.Parent as DockContainer;
			SetTopMostContainer();
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			if (e.Control == null)
			{
				return;
			}

			DockContainer dockContainer = e.Control as DockContainer;
			if (dockContainer != null)
			{
				containers.Add(dockContainer);
				dockContainer.ParentContainer = this;
				return;
			}

			DockPanel dockPanel = e.Control as DockPanel;
			if (dockPanel != null)
			{
				AddDockPanel(dockPanel);
			}
		}

		private void OnDockContainerAdded(DockContainer dc)
		{
			ListControls();
			dc.SetForceUseAsTarget(val: true);
			RearrangeControls();
			dc.SetForceUseAsTarget(val: false);
		}

		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			DockContainer dockContainer = e.Control as DockContainer;
			if (dockContainer != null)
			{
				containers.Remove(dockContainer);
				dockContainer.ParentContainer = null;
				return;
			}

			DockPanel dockPanel = e.Control as DockPanel;
			if (dockPanel != null)
			{
				RemoveDockPanel(dockPanel);
			}
		}

		private void AddDockPanel(DockPanel p)
		{
			panels.Add(p);
			p.SetParentInt(this);
			p.Dock = DockStyle.Fill;
			p.EnsureVisible();
			if (p.Manager == null)
			{
				p.Manager = Manager;
			}

			if (Manager != null)
			{
				Manager.CleanUp();
			}
			else
			{
				CleanUp();
			}

			if (Collapsed && DockManager != null)
			{
				DockManager.GetButtonBar(this)?.Add(this);
			}
			else if (Highlight != null)
			{
				Highlight.RefreshAll();
			}

			foreach (DockPanel panel in panels)
			{
				panel.OnPanelCollectionChanged(p, this, remove: false);
			}

			if (this.PanelCollectionChanged != null)
			{
				this.PanelCollectionChanged(this, new EventArgs());
			}
		}

		private void RemoveDockPanel(DockPanel p)
		{
			DockButtonBar dockButtonBar = null;
			if (Collapsed && DockManager != null)
			{
				dockButtonBar = DockManager.GetButtonBar(this);
				dockButtonBar?.SilentRemove(this);
			}

			p.SetParentInt(null);
			panels.Remove(p);
			if (Highlight == p && panels.Count > 0)
			{
				panels[0].EnsureVisible();
			}

			if (Manager != null)
			{
				Manager.CleanUp();
			}
			else
			{
				CleanUp();
			}

			if (dockButtonBar != null)
			{
				dockButtonBar.Add(this);
			}
			else if (Highlight != null)
			{
				Highlight.RefreshAll();
			}

			p.OnPanelCollectionChanged(p, this, remove: true);
			foreach (DockPanel panel in panels)
			{
				panel.OnPanelCollectionChanged(p, this, remove: true);
			}

			if (this.PanelCollectionChanged != null)
			{
				this.PanelCollectionChanged(this, new EventArgs());
			}
		}

		internal void ListControls()
		{
			for (int num = base.Controls.Count - 1; num >= 0; num--)
			{
				_ = base.Controls[num];
			}
		}

		public DockContainer CreateNewContainer()
		{
			DockContainer dockContainer = CreateNewContainer(-1, after: true, toplevel: true, DockStyle.None);
			dockContainer.Visible = true;
			return dockContainer;
		}

		public void SetDefaultSize()
		{
			base.Width = Manager.DefaultSize.Width;
			base.Height = Manager.DefaultSize.Height;
		}

		public void SetMinSize()
		{
			base.Width = Math.Max(base.Width, Manager.DefaultSize.Width);
			base.Height = Math.Max(base.Height, Manager.DefaultSize.Height);
		}

		protected virtual void SetNewContainerIndex(ref int index, ref bool after, ref bool toplevel, DockStyle dockstyle)
		{
			if (after && index >= 0)
			{
				index++;
			}
		}

		protected override void OnChangeUICues(UICuesEventArgs e)
		{
			base.OnChangeUICues(e);
		}

		public DockContainer CreateNewContainer(int index, bool after, bool toplevel, DockStyle dockstyle)
		{
			DockContainer dockContainer = new DockContainer(Manager);
			SetupContainer(index, after, toplevel, dockstyle, dockContainer);
			return dockContainer;
		}

		public void SetupContainer(int index, bool after, bool toplevel, DockStyle dockstyle, DockContainer dc)
		{
			SetNewContainerIndex(ref index, ref after, ref toplevel, dockstyle);
			dc.HideSingleButton = HideSingleButton;
			dc.Visible = false;
			dc.Dock = dockstyle;
			base.Controls.Add(dc);
			if (index >= 0 && index < base.Controls.Count && !toplevel)
			{
				base.Controls.SetChildIndex(dc, index);
			}

			dc.SetDefaultSize();
			OnDockContainerAdded(dc);
		}

		public DockButtonBar.DockPanelList GetDockedPanels()
		{
			return panels;
		}

		internal bool HintHitCheck(Point scrpt)
		{
			if (IgnoreAsTarget)
			{
				return false;
			}

			return Hit(scrpt);
		}

		internal bool Hit(Point scrpt)
		{
			Point screenLocation = ScreenLocation;
			if (scrpt.X > screenLocation.X && scrpt.X < screenLocation.X + base.Width && scrpt.Y > screenLocation.Y && scrpt.Y < screenLocation.Y + base.Height)
			{
				return true;
			}

			return false;
		}

		internal void AddDock(DockPanel child)
		{
			base.Controls.Add(child);
		}

		internal void RemoveDock(DockPanel child)
		{
			base.Controls.Remove(child);
		}

		internal virtual void TakeHint(DockHint hint)
		{
			Rectangle screenBounds = ScreenBounds;
			screenBounds = GetScreenDockAreaBounds();
			TakeHint(hint, screenBounds, this);
		}

		public Rectangle GetDockAreaBounds()
		{
			if (panels.Count > 0)
			{
				return panels[0].Bounds;
			}

			return CalculateDockAreaBounds();
		}

		public Rectangle GetScreenDockAreaBounds()
		{
			Rectangle screenBounds = ScreenBounds;
			return CalculateDockAreaBounds(screenBounds.Left, screenBounds.Top, screenBounds.Width, screenBounds.Height);
		}

		private Rectangle CalculateDockAreaBounds()
		{
			int width = base.Width;
			int height = base.Height;
			int left = base.Left;
			int top = base.Top;
			return CalculateDockAreaBounds(left, top, width, height);
		}

		private Rectangle CalculateDockAreaBounds(int left, int top, int wd, int hg)
		{
			foreach (DockContainer container in containers)
			{
				if (container.Dock == DockStyle.Left)
				{
					wd -= container.Width;
					left += container.Width;
				}
				else if (container.Dock == DockStyle.Top)
				{
					hg -= container.Height;
					top += container.Height;
				}
				else if (container.Dock == DockStyle.Right)
				{
					wd -= container.Width;
				}
				else if (container.Dock == DockStyle.Bottom)
				{
					hg -= container.Height;
				}
			}

			return new Rectangle(left, top, wd, hg);
		}

		internal void TakeHint(DockHint hint, Rectangle r, DockContainer d)
		{
			if (!(d == null))
			{
				hint.ParentContainer = d;
				hint.SetDesktopLocation(r.Left + (r.Width - hint.Width) / 2, r.Top + (r.Height - hint.Height) / 2);
				if (Manager.DockMode)
				{
					UpdateHintVisibility();
				}
			}
		}

		protected virtual DockContainer GetDockContainer(Point scrpt)
		{
			if (HintHitCheck(scrpt))
			{
				foreach (DockContainer container in containers)
				{
					DockContainer dockContainer = container.GetDockContainer(scrpt);
					if (dockContainer != null)
					{
						return dockContainer;
					}

					if (container.HintHitCheck(scrpt))
					{
						return container;
					}
				}

				return this;
			}

			return null;
		}

		protected virtual void OnTakeHint()
		{
		}

		protected virtual void UpdateHintVisibility()
		{
		}

		protected void MouseOverHint(DockHint sender, SelectedHint hint)
		{
			if (sender.Visible)
			{
				ContainerInfo nfo = default(ContainerInfo);
				nfo.Hint = hint;
				nfo.Parent = this;
				nfo.DockInside = false;
				nfo.TopLevel = false;
				if (sender.ParentContainer == null)
				{
					nfo.Seed = this;
					SetTargetContainerInfo(sender, ref nfo);
				}
				else
				{
					nfo.Seed = sender.ParentContainer;
					sender.ParentContainer.SetTargetContainerInfo(sender, ref nfo);
				}

				if (nfo.Hint == SelectedHint.Left)
				{
					nfo.Dock = DockStyle.Left;
				}
				else if (nfo.Hint == SelectedHint.Right)
				{
					nfo.Dock = DockStyle.Right;
				}
				else if (nfo.Hint == SelectedHint.Top)
				{
					nfo.Dock = DockStyle.Top;
				}
				else if (nfo.Hint == SelectedHint.Bottom)
				{
					nfo.Dock = DockStyle.Bottom;
				}
				else
				{
					nfo.Dock = DockStyle.Fill;
				}

				nfo.Parent.GetTargetRectangle(ref nfo);
				nfo.SeedIndex = nfo.Parent.Controls.IndexOf(nfo.Seed);
				OnMouseOverHint(sender, ref nfo);
			}
		}

		protected virtual void SetTargetContainerInfo(DockHint sender, ref ContainerInfo nfo)
		{
			SetContainerParent(ref nfo);
			if (Dock == DockStyle.Left)
			{
				if (nfo.Hint == SelectedHint.Right)
				{
					nfo.DockInside = true;
					nfo.Hint = SelectedHint.Left;
				}
			}
			else if (Dock == DockStyle.Right)
			{
				if (nfo.Hint == SelectedHint.Left)
				{
					nfo.DockInside = true;
					nfo.Hint = SelectedHint.Right;
				}
			}
			else if (Dock == DockStyle.Top)
			{
				if (nfo.Hint == SelectedHint.Bottom)
				{
					nfo.DockInside = true;
					nfo.Hint = SelectedHint.Top;
				}
			}
			else if (Dock == DockStyle.Bottom && nfo.Hint == SelectedHint.Top)
			{
				nfo.DockInside = true;
				nfo.Hint = SelectedHint.Bottom;
			}
		}

		private void SetContainerParent(ref ContainerInfo nfo)
		{
			nfo.Parent = this;
			if (Dock == DockStyle.Left || Dock == DockStyle.Right)
			{
				if ((nfo.Hint == SelectedHint.Left || nfo.Hint == SelectedHint.Right) && ParentContainer != null)
				{
					nfo.Parent = ParentContainer;
				}
			}
			else if ((Dock == DockStyle.Top || Dock == DockStyle.Bottom) && (nfo.Hint == SelectedHint.Top || nfo.Hint == SelectedHint.Bottom) && ParentContainer != null)
			{
				nfo.Parent = ParentContainer;
			}
		}

		protected virtual void GetTargetRectangle(ref ContainerInfo nfo)
		{
			Rectangle screenBounds = nfo.Parent.ScreenBounds;
			Rectangle screenDockAreaBounds = nfo.Seed.GetScreenDockAreaBounds();
			Size size = new Size(Math.Max(10, Math.Min(screenBounds.Width / 2, Manager.DefaultSize.Width)), Math.Max(10, Math.Min(screenBounds.Height / 2, Manager.DefaultSize.Height)));
			if (nfo.DockInside)
			{
				if (nfo.Hint == SelectedHint.Right)
				{
					nfo.OverlayRectangle = new Rectangle(screenDockAreaBounds.Left - size.Width, screenDockAreaBounds.Top, size.Width, screenDockAreaBounds.Height);
				}
				else if (nfo.Hint == SelectedHint.Left)
				{
					nfo.OverlayRectangle = new Rectangle(screenDockAreaBounds.Right, screenDockAreaBounds.Top, size.Width, screenDockAreaBounds.Height);
				}
				else if (nfo.Hint == SelectedHint.Bottom)
				{
					nfo.OverlayRectangle = new Rectangle(screenDockAreaBounds.Left, screenDockAreaBounds.Top - size.Height, screenDockAreaBounds.Width, size.Height);
				}
				else if (nfo.Hint == SelectedHint.Top)
				{
					nfo.OverlayRectangle = new Rectangle(screenDockAreaBounds.Left, screenDockAreaBounds.Bottom, screenDockAreaBounds.Width, size.Height);
				}
				else if (nfo.Hint == SelectedHint.Center && !IsManager)
				{
					nfo.OverlayRectangle = nfo.Parent.GetScreenDockAreaBounds();
				}
				else
				{
					nfo.OverlayRectangle = Rectangle.Empty;
				}
			}
			else if (nfo.Hint == SelectedHint.Left)
			{
				nfo.OverlayRectangle = new Rectangle(screenBounds.Left, screenDockAreaBounds.Top, size.Width, screenDockAreaBounds.Height);
			}
			else if (nfo.Hint == SelectedHint.Right)
			{
				nfo.OverlayRectangle = new Rectangle(screenBounds.Right - size.Width, screenDockAreaBounds.Top, size.Width, screenDockAreaBounds.Height);
			}
			else if (nfo.Hint == SelectedHint.Top)
			{
				nfo.OverlayRectangle = new Rectangle(screenDockAreaBounds.Left, screenBounds.Top, screenDockAreaBounds.Width, size.Height);
			}
			else if (nfo.Hint == SelectedHint.Bottom)
			{
				nfo.OverlayRectangle = new Rectangle(screenDockAreaBounds.Left, screenBounds.Bottom - size.Height, screenDockAreaBounds.Width, size.Height);
			}
			else if (nfo.Hint == SelectedHint.Center && !IsManager)
			{
				nfo.OverlayRectangle = nfo.Parent.GetScreenDockAreaBounds();
			}
			else
			{
				nfo.OverlayRectangle = Rectangle.Empty;
			}
		}

		protected virtual void OnMouseOverHint(DockHint sender, ref ContainerInfo nfo)
		{
		}

		protected virtual void RearrangeControls()
		{
		}

		protected virtual void CleanUp()
		{
			if (NoCleanup)
			{
				return;
			}

			for (int num = containers.Count - 1; num >= 0; num--)
			{
				DockContainer dockContainer = containers[num];
				dockContainer.CleanUp();
				if (dockContainer.SubControls == 0 && !dockContainer.NoCleanup)
				{
					dockContainer.Remove();
				}
			}
		}

		protected void Remove()
		{
			if (!(ParentContainer == null))
			{
				MoveChildDocksUp();
				if (!(ParentContainer == null))
				{
					ParentContainer.Controls.Remove(this);
				}
			}
		}

		protected void SetParent(DockContainer dc, int index)
		{
			base.Parent = dc;
			if (index >= 0)
			{
				dc.Controls.SetChildIndex(this, index);
			}
		}

		protected void MoveChildDocksUp()
		{
			MoveChildDocksUp(resize: false);
		}

		protected void MoveChildDocksUp(bool resize)
		{
			if (ParentContainer == null || this is DockManager)
			{
				return;
			}

			DockContainer dockContainer = null;
			for (int num = containers.Count - 1; num >= 0; num--)
			{
				DockContainer dockContainer2 = containers[num];
				if (dockContainer == null)
				{
					dockContainer = dockContainer2;
					DockStyle dock = dockContainer2.Dock;
					dockContainer2.Dock = DockStyle.None;
					dockContainer2.SetParent(ParentContainer, ParentContainer.Controls.IndexOf(this));
					if (Dock != DockStyle.Fill)
					{
						dockContainer2.Dock = Dock;
					}
					else
					{
						dockContainer2.Dock = dock;
					}
				}
				else
				{
					dockContainer2.SetParent(dockContainer, -1);
				}

				if (resize)
				{
					dockContainer2.SetMinSize();
				}
			}
		}

		protected void ShowDockPanel(DockPanel pn)
		{
			int num = -1;
			int num2 = 0;
			foreach (Control control in base.Controls)
			{
				DockPanel dockPanel = control as DockPanel;
				if (dockPanel != null && dockPanel.Dock == DockStyle.Fill && num == -1)
				{
					num = num2;
					break;
				}

				num2++;
			}

			if (num >= 0 && base.Controls.Contains(pn))
			{
				base.Controls.SetChildIndex(pn, num);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
		}

		protected override void WndProc(ref Message m)
		{
			if (MyWndProc(ref m) && (m.Msg != 15 || (CollapseState != Status.Collapsing && CollapseState != Status.Expanding)))
			{
				base.WndProc(ref m);
			}
		}

		internal void SetForceUseAsTarget(bool val)
		{
			useastar = val;
		}

		protected void ForcePanelRepaint()
		{
			DockButtonBar.DockPanelList dockedPanels = GetDockedPanels();
			foreach (DockPanel item in dockedPanels)
			{
				item.NCRefresh();
			}

			foreach (DockContainer container in containers)
			{
				container.ForcePanelRepaint();
			}
		}

		public void RepaintAll()
		{
			ForcePanelRepaint();
		}

		protected DockAnimationEventArgs.Alignment GetAlignment()
		{
			DockAnimationEventArgs.Alignment result = DockAnimationEventArgs.Alignment.Undefined;
			if (Dock == DockStyle.Left || Dock == DockStyle.Right)
			{
				result = DockAnimationEventArgs.Alignment.Vertical;
			}

			if (Dock == DockStyle.Top || Dock == DockStyle.Bottom)
			{
				result = DockAnimationEventArgs.Alignment.Horizontal;
			}

			return result;
		}

		public void Collapse()
		{
			Collapse(animated: true);
		}

		public virtual void Collapse(bool animated)
		{
			if (!Collapsed)
			{
				expsz = base.Size;
				DockAnimationEventArgs.Alignment alignment = GetAlignment();
				DockAnimationEventArgs e = new DockAnimationEventArgs(this, DockAnimationEventArgs.Type.Collapse, alignment);
				state = Status.Collapsing;
				if (Manager != null)
				{
					Manager.SuspendLayout();
				}

				DockPanelRenderer_FinishedAnimation(Manager.Renderer.DockPanelRenderer, e);
			}
		}

		public void Expand()
		{
			Expand(animated: true);
		}

		public virtual void Expand(bool animated)
		{
			if (!Expanded)
			{
				DockAnimationEventArgs.Alignment alignment = GetAlignment();
				DockAnimationEventArgs dockAnimationEventArgs = new DockAnimationEventArgs(this, DockAnimationEventArgs.Type.Expand, alignment);
				state = Status.Expanding;
				if (Manager != null)
				{
					Manager.SuspendLayout();
				}

				if (dockAnimationEventArgs.DockAlignment == DockAnimationEventArgs.Alignment.Horizontal)
				{
					base.Height = ExpandedSize.Height;
				}
				else if (dockAnimationEventArgs.DockAlignment == DockAnimationEventArgs.Alignment.Vertical)
				{
					base.Width = ExpandedSize.Width;
				}

				DockPanelRenderer_FinishedAnimation(Manager.Renderer.DockPanelRenderer, dockAnimationEventArgs);
			}
		}

		private void DockPanelRenderer_FinishedAnimation(IDockPanelRenderer sender, DockAnimationEventArgs e)
		{
			if (e.Container != this)
			{
				return;
			}

			if (e.AnimationType == DockAnimationEventArgs.Type.Collapse)
			{
				state = Status.Collapsed;
				base.Visible = false;
				MoveChildDocksUp(resize: true);
				if (DockManager != null)
				{
					DockManager.GetBestButtonBar(this).Add(this);
				}

				if (Manager != null)
				{
					Manager.RepaintAll();
				}
			}
			else if (e.AnimationType == DockAnimationEventArgs.Type.Expand)
			{
				state = Status.Expanded;
				if (DockManager != null)
				{
					DockManager.GetBestButtonBar(this).Remove(this);
				}

				base.Visible = true;
				if (Manager != null)
				{
					Manager.RepaintAll();
				}
			}

			if (Manager != null)
			{
				Manager.ResumeLayout();
			}
		}

		protected void GenGUID()
		{
			guid = Guid.NewGuid();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			DockContainer dockContainer = obj as DockContainer;
			if (dockContainer != null)
			{
				return Guid == dockContainer.Guid;
			}

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return Guid.GetHashCode();
		}

		public static bool operator ==(DockContainer a, DockContainer b)
		{
			bool flag = (object)a == null;
			bool flag2 = (object)b == null;
			if (flag)
			{
				return flag2;
			}

			if (flag2)
			{
				return false;
			}

			return a.Guid == b.Guid;
		}

		public static bool operator !=(DockContainer a, DockContainer b)
		{
			bool flag = (object)a == null;
			bool flag2 = (object)b == null;
			if (flag)
			{
				return !flag2;
			}

			if (flag2)
			{
				return true;
			}

			return a.Guid != b.Guid;
		}

		public void SetActiveDock(DockPanel dp)
		{
			if (hldp != dp)
			{
				if (hldp != null)
				{
					hldp.FireHighlightChanged(dp);
				}

				hldp = dp;
				ShowDockPanel(dp);
				if (hldp != null)
				{
					hldp.MakeVisibleByParentDockContainer();
					hldp.FireHighlightChanged(dp);
				}
			}
		}

		public DockButtonBar.DockPanelList GetButtons()
		{
			return GetDockedPanels();
		}

		public Padding GetBorderSize(ButtonOrientation orient)
		{
			return manager.Renderer.DockPanelRenderer.GetPanelBorderSize(this, null, orient);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			base.Name = "DockContainer";
			base.ResumeLayout(false);
		}

		public new void Update()
		{
			base.Update();
			CleanUp();
		}

		public new void SuspendLayout()
		{
			if (layoutct == 0)
			{
				base.SuspendLayout();
			}

			layoutct++;
		}

		public new void ResumeLayout()
		{
			layoutct--;
			if (layoutct == 0)
			{
				base.ResumeLayout();
				if (Highlight != null)
				{
					Highlight.EnsureVisible();
				}
			}
			else if (layoutct < 0)
			{
				layoutct = 0;
			}
		}

		public void ForceResumeLayout()
		{
			layoutct = 0;
			base.ResumeLayout();
		}

		public void SwapPanelsInButtonList(DockPanel pn1, DockPanel pn2)
		{
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < panels.Count; i++)
			{
				if (panels[i] == pn1)
				{
					num = i;
				}
				else if (panels[i] == pn2)
				{
					num2 = i;
				}
			}

			if (num >= 0 && num < panels.Count && num2 >= 0 && num2 < panels.Count)
			{
				panels.RemoveAt(num);
				panels.Insert(num, pn2);
				panels.RemoveAt(num2);
				panels.Insert(num2, pn1);
				if (Highlight != null)
				{
					Highlight.NCRefresh();
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		protected virtual void GetPanels(Dictionary<string, DockPanel> list)
		{
			foreach (DockPanel panel in panels)
			{
				if (panel.Name == "")
				{
					panel.Name = "myDockPanel_" + list.Count;
				}

				list[panel.Name] = panel;
			}

			foreach (DockContainer container in containers)
			{
				container.GetPanels(list);
			}
		}

		protected virtual void DoSerialize(BinaryWriter writer, ref int counter)
		{
			counter = FixName(counter);
			writer.Write(base.Name);
			if (base.Parent != null)
			{
				writer.Write(base.Parent.Name);
				writer.Write(base.Parent.Controls.GetChildIndex(this));
			}
			else
			{
				writer.Write("");
				writer.Write(0);
			}

			writer.Write((int)Dock);
			writer.Write(Collapsed);
			writer.Write(base.Width);
			writer.Write(base.Height);
			if (Highlight != null)
			{
				writer.Write(Highlight.Name);
			}
			else
			{
				writer.Write("");
			}

			writer.Write(containers.Count);
			foreach (DockContainer container in containers)
			{
				container.DoSerialize(writer, ref counter);
			}
		}

		private int FixName(int counter)
		{
			if (base.Name == "")
			{
				base.Name = "dc_" + counter + "_" + Guid.ToString();
				counter++;
			}

			return counter;
		}

		protected void PrepareDeserialize()
		{
			for (int num = panels.Count - 1; num >= 0; num--)
			{
				base.Controls.Remove(panels[num]);
			}

			for (int num2 = containers.Count - 1; num2 >= 0; num2--)
			{
				containers[num2].PrepareDeserialize();
			}

			for (int num3 = containers.Count - 1; num3 >= 0; num3--)
			{
				base.Controls.Remove(containers[num3]);
			}
		}

		protected void DoDeserialize(BinaryReader reader, Dictionary<string, DockManager.DockContainerDescriptor> docks, DockContainer parent)
		{
			string text = reader.ReadString();
			reader.ReadString();
			int num = reader.ReadInt32();
			DockStyle dock = (DockStyle)reader.ReadInt32();
			bool collapsed = reader.ReadBoolean();
			int width = reader.ReadInt32();
			int height = reader.ReadInt32();
			string highlightname = reader.ReadString();
			if (!(this is DockManager))
			{
				SetNoCleanUpIntern(val: true);
				base.Name = text;
				Dock = dock;
				base.Width = width;
				base.Height = height;
				base.Parent = parent;
			}

			docks[text] = new DockManager.DockContainerDescriptor(this, num, collapsed, highlightname);
			int num2 = reader.ReadInt32();
			for (int i = 0; i < num2; i++)
			{
				DockContainer dockContainer = CreateNewContainer();
				dockContainer.SetForceUseAsTarget(val: true);
				dockContainer.Visible = false;
				dockContainer.DoDeserialize(reader, docks, this);
			}
		}
	}
}
