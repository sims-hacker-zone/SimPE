// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	[ToolboxItem(false)]
	[Designer(typeof(DockPanelDesigner))]
	public class DockPanel : NCUserControl
	{
		private struct LastOpenState
		{
			public DockContainer Container;

			public Point Pos;

			public bool Floating;
		}

		public delegate void ClosingHandler(object sender, DockPanelClosingEvent e);

		public class DockPanelClosingEvent : EventArgs
		{
			private DockPanel dp;

			private bool cancel;

			public bool Cancel
			{
				get
				{
					return cancel;
				}
				set
				{
					cancel = value;
				}
			}

			public DockPanelClosingEvent(DockPanel dp)
			{
				this.dp = dp;
				cancel = false;
			}
		}

		public delegate void HighlightChangeEvent(DockPanel sender, HighlightChangeEventArgs e);

		public class HighlightChangeEventArgs : EventArgs
		{
			private DockPanel newhl;

			private DockPanel cur;

			public DockPanel NewHighlight => newhl;

			public bool GotHighlight => newhl == cur;

			internal HighlightChangeEventArgs(DockPanel cur, DockPanel newhl)
			{
				this.newhl = newhl;
				this.cur = cur;
			}
		}

		private IContainer components;

		private List<DockPanelCaptionButton> cbuttons;

		private DockPanelCollapseButton collapse;

		private DockPanelCloseButton close;

		private int undockthreshold;

		private string text;

		private string btext;

		private Image img;

		private BaseDockManager manager;

		private bool canundock;

		private NCMouseEventArgs startevent;

		private LastOpenState last;

		private DockPanelButtonManager buttonData;

		private bool seperateindockbar;

		private Guid? guid = null;

		public int UndockByCaptionThreshold
		{
			get
			{
				return undockthreshold;
			}
			set
			{
				undockthreshold = value;
			}
		}

		public new string Text
		{
			get
			{
				return CaptionText;
			}
			set
			{
				CaptionText = value;
			}
		}

		[Localizable(true)]
		public string CaptionText
		{
			get
			{
				return text;
			}
			set
			{
				if (text != value)
				{
					text = value;
					if (btext == "")
					{
						btext = text;
					}

					NCRefresh();
				}
			}
		}

		[Localizable(true)]
		public virtual string ButtonText
		{
			get
			{
				return btext;
			}
			set
			{
				if (btext != value)
				{
					btext = value;
					NCRefresh();
				}
			}
		}

		public Image Image
		{
			get
			{
				return img;
			}
			set
			{
				if (img != value)
				{
					img = value;
					if (img == null)
					{
						SetDefaultImage();
					}

					NCRefresh();
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

		public bool CanUndock
		{
			get
			{
				return canundock;
			}
			set
			{
				canundock = value;
			}
		}

		public bool CanResize
		{
			get
			{
				if (DockContainer == null)
				{
					return false;
				}

				return DockContainer.CanResize;
			}
			set
			{
				if (DockContainer != null)
				{
					DockContainer.CanResize = value;
				}
			}
		}

		public ButtonOrientation BestOrientation
		{
			get
			{
				if (DockContainer != null)
				{
					return DockContainer.BestOrientation;
				}

				return ButtonOrientation.Bottom;
			}
		}

		public DockContainer DockContainer
		{
			get
			{
				return Parent as DockContainer;
			}
			set
			{
				if (value != Parent as DockContainer)
				{
					DockControl(value);
				}
			}
		}

		public bool Floating => base.ParentForm is DockPanelFloatingForm;

		internal DockPanelFloatingForm FloatForm => base.ParentForm as DockPanelFloatingForm;

		public bool FloatContainer
		{
			get
			{
				if (FloatForm == null)
				{
					return false;
				}

				return FloatForm.HasContainer;
			}
		}

		public new Control Parent
		{
			get
			{
				return base.Parent;
			}
			set
			{
				throw new Exception("Do not set a DockPanel's Parent manually!");
			}
		}

		protected DockPanelButtonManager ButtonData => buttonData;

		internal bool SeperateInDockBar
		{
			get
			{
				return seperateindockbar;
			}
			set
			{
				seperateindockbar = value;
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

		public virtual bool ShowCloseButton
		{
			get
			{
				return close.Visible;
			}
			set
			{
				if (close.SetVisible(value))
				{
					NCRefresh();
				}
			}
		}

		public virtual bool ShowCollapseButton
		{
			get
			{
				return collapse.Visible;
			}
			set
			{
				if (collapse.SetVisible(value))
				{
					NCRefresh();
				}
			}
		}

		internal CaptionState CaptionState
		{
			get
			{
				bool flag = HasFocus();
				if (DockContainer != null)
				{
					flag |= DockContainer.Focused;
				}

				if (flag)
				{
					return CaptionState.Focused;
				}

				return CaptionState.Normal;
			}
		}

		public virtual bool OnlyChild
		{
			get
			{
				if (DockContainer == null)
				{
					return true;
				}

				return DockContainer.OneChild;
			}
		}

		public bool Collapsed
		{
			get
			{
				if (Floating)
				{
					return false;
				}

				if (DockContainer == null)
				{
					return false;
				}

				return DockContainer.Collapsed;
			}
		}

		[Browsable(false)]
		public Image TabImage
		{
			get
			{
				return Image;
			}
			set
			{
				Image = value;
			}
		}

		[Browsable(false)]
		public string TabText
		{
			get
			{
				return ButtonText;
			}
			set
			{
				ButtonText = value;
			}
		}

		[Browsable(false)]
		public bool AllowFloat
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		[Browsable(false)]
		public bool AllowDockBottom
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		[Browsable(false)]
		public bool AllowDockLeft
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		[Browsable(false)]
		public bool AllowDockRight
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		[Browsable(false)]
		public bool AllowDockTop
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		[Browsable(false)]
		public bool AllowDockCenter
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		[Browsable(false)]
		public bool AllowClose
		{
			get
			{
				return ShowCloseButton;
			}
			set
			{
				ShowCloseButton = value;
			}
		}

		[Browsable(false)]
		public bool AllowCollapse
		{
			get
			{
				return ShowCollapseButton;
			}
			set
			{
				ShowCollapseButton = value;
			}
		}

		[Browsable(false)]
		public bool IsDocked => DockContainer != null;

		[Browsable(false)]
		public bool IsFloating => Floating;

		[Browsable(false)]
		public bool IsOpen
		{
			get
			{
				if (!IsFloating)
				{
					return IsDocked;
				}

				return true;
			}
		}

		public Size FloatingSize
		{
			get
			{
				return base.Size;
			}
			set
			{
			}
		}

		public event EventHandler StartedFloating;

		public event EventHandler Closed;

		public event EventHandler Opened;

		public event EventHandler OpenedStateChanged;

		public event ClosingHandler Closing;

		public event HighlightChangeEvent HighlightChange;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}

		public DockPanel(BaseDockManager manager)
		{
			ManagerSingelton.Global.AddPanel(this);
			last.Container = null;
			last.Pos = Point.Empty;
			last.Floating = false;
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.ContainerControl, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			seperateindockbar = false;
			canundock = true;
			SetManager(manager);
			base.DragBorder = false;
			base.ResizeBorder.Left = false;
			base.ResizeBorder.Right = false;
			base.ResizeBorder.Top = false;
			base.ResizeBorder.Bottom = false;
			InitializeComponent();
			SetupCaptionButtons();
			SetDefaultImage();
			text = base.Name;
			btext = "";
			base.Visible = false;
			undockthreshold = 150;
		}

		public DockPanel()
			: this(null)
		{
		}

		~DockPanel()
		{
			ManagerSingelton.Global.RemovePanel(this);
		}

		internal void SetManager(BaseDockManager manager)
		{
			this.manager = manager;
			SetNonClientMargin();
		}

		private void SetupCaptionButtons()
		{
			cbuttons = new List<DockPanelCaptionButton>();
			collapse = new DockPanelCollapseButton(this);
			cbuttons.Add(collapse);
			close = new DockPanelCloseButton(this);
			cbuttons.Add(close);
		}

		private void SetDefaultImage()
		{
			Stream manifestResourceStream = GetType().Assembly.GetManifestResourceStream("Ambertation.Windows.Forms.dockimg.png");
			if (manifestResourceStream != null)
			{
				img = Image.FromStream(manifestResourceStream);
			}
			else
			{
				img = new Bitmap(16, 16);
			}
		}

		public Size GetButtonSize()
		{
			return Manager.Renderer.DockPanelRenderer.GetButtonSize(this);
		}

		protected bool MouseOnSelector(Point mouse)
		{
			bool flag = false;
			if (canundock)
			{
				flag = Manager.Renderer.DockPanelRenderer.GetCaptionRect(this).Contains(mouse);
			}

			if (ButtonData != null && !flag)
			{
				DockPanel hitPanel = ButtonData.GetHitPanel(mouse);
				flag = hitPanel == this;
			}

			return flag;
		}

		internal void CallNcMouseChanged(NCMouseEventArgs e)
		{
			OnNcMouseChanged(e);
		}

		protected override void OnNcMouseChanged(NCMouseEventArgs e)
		{
			if (ManagerSingelton.Global.HasDragPanelForMouseMove)
			{
				DockPanel hitPanel = ButtonData.GetHitPanel(e.ControlPosition);
				if (hitPanel != this && hitPanel != null && DockContainer != null)
				{
					DockContainer.SwapPanelsInButtonList(this, hitPanel);
				}

				return;
			}

			base.OnNcMouseChanged(e);
			bool flag = false;
			foreach (DockPanelCaptionButton cbutton in cbuttons)
			{
				flag = ((!cbutton.Hit(e)) ? (flag | cbutton.SetState(CaptionButtonState.Normal)) : ((!e.MouseButtons.Left) ? (flag | cbutton.SetState(CaptionButtonState.Highlight)) : (flag | cbutton.SetState(CaptionButtonState.Selected))));
			}

			if (flag)
			{
				NCRefresh();
			}

			if (!e.MouseButtons.Left || e.InitialResult != NCHitTestEventArgs.Results.HTBORDER || (Math.Abs(e.Delta.X) < 2 && Math.Abs(e.Delta.Y) < 2))
			{
				return;
			}

			bool flag2 = MouseOnSelector(e.ControlPosition);
			if (flag2)
			{
				if (Manager.Renderer.DockPanelRenderer.GetButtonsRectangle(BestOrientation, new NCPaintEventArgs(null, base.ClientRectangle, base.Bounds, null), DockContainer).Contains(e.ControlPosition))
				{
					flag2 = false;
					ManagerSingelton.Global.SetDragPanelOnMouseMove(this, e);
				}

				int num = Math.Min(base.Width / 2, undockthreshold);
				if (startevent == null)
				{
					flag2 = false;
				}
				else if (Math.Abs(e.ScreenPosition.X - startevent.ScreenPosition.X) < num && Math.Abs(e.ScreenPosition.Y - startevent.ScreenPosition.Y) < num)
				{
					flag2 = false;
				}

				if (flag2)
				{
					StartDockModeFloat(e);
				}
			}
		}

		protected override void OnNcClick(NCMouseEventArgs e)
		{
			base.OnNcClick(e);
			if (DockContainer != null && DockContainer.CollapseState != DockContainer.Status.Expanded)
			{
				return;
			}

			foreach (DockPanelCaptionButton cbutton in cbuttons)
			{
				if (cbutton.Hit(e))
				{
					cbutton.PerformClick();
					break;
				}
			}
		}

		protected override void OnNcHitTest(NCHitTestEventArgs e)
		{
			base.OnNcHitTest(e);
		}

		internal void CallNcMouseDown(NCMouseEventArgs e)
		{
			OnNcMouseDown(e);
		}

		protected override void OnNcMouseDown(NCMouseEventArgs e)
		{
			base.OnNcMouseUp(e);
			startevent = e;
			if (MouseOnSelector(e.ControlPosition) && e.MouseButtons.Left)
			{
				EnsureVisible();
				Focus();
				Manager.RepaintAll();
			}

			DockPanel hitPanel = ButtonData.GetHitPanel(e.ControlPosition);
			if (hitPanel != null && e.MouseButtons.Left)
			{
				if (hitPanel.DockContainer != null)
				{
					hitPanel.DockContainer.Focus();
				}

				hitPanel.EnsureVisible();
			}
		}

		public void EnsureVisible()
		{
			if (DockContainer != null)
			{
				DockContainer.SetActiveDock(this);
			}
		}

		internal void MakeVisibleByParentDockContainer()
		{
			Focus();
			NCRefresh();
			if (FloatForm != null)
			{
				FloatForm.Text = CaptionText;
			}

			base.Visible = true;
		}

		public void InvalidateWindow()
		{
			DoInvalidateWindow();
		}

		internal void StartDockModeFloat(NCMouseEventArgs e)
		{
			if (CanUndock && !Floating)
			{
				_ = DockContainer;
				Point screenPosition = e.ScreenPosition;
				bool container = false;
				if (Manager != null && DockContainer != null && Manager.Renderer.DockPanelRenderer.GetCaptionRect(this).Contains(e.ControlPosition))
				{
					container = !DockContainer.OneChild;
				}

				DockPanelFloatingForm dockPanelFloatingForm = LetFloat(screenPosition, container) as DockPanelFloatingForm;
				Manager.StartDockMode(this);
				dockPanelFloatingForm.Show();
				dockPanelFloatingForm.StartFloatingBlocked(this);
			}
		}

		internal void Float(Point pos)
		{
			DockPanelFloatingForm dockPanelFloatingForm = LetFloat(pos, container: false) as DockPanelFloatingForm;
			dockPanelFloatingForm.Text = CaptionText;
			dockPanelFloatingForm.Show();
		}

		internal void Float()
		{
			Point pos = PointToScreen(new Point(0, 0));
			Float(pos);
		}

		protected Form LetFloat(Point pos, bool container)
		{
			if (Floating)
			{
				return FloatForm;
			}

			DockPanelFloatingForm dockPanelFloatingForm = new DockPanelFloatingForm(this);
			dockPanelFloatingForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			dockPanelFloatingForm.StartPosition = FormStartPosition.Manual;
			dockPanelFloatingForm.ShowInTaskbar = false;
			dockPanelFloatingForm.Width = base.Width + 2 * SystemInformation.FrameBorderSize.Width;
			dockPanelFloatingForm.Height = base.Height + SystemInformation.ToolWindowCaptionHeight + 2 * SystemInformation.FrameBorderSize.Height;
			dockPanelFloatingForm.Left = pos.X;
			dockPanelFloatingForm.Top = pos.Y;
			dockPanelFloatingForm.BringToFront();
			DockContainer dockContainer = DockContainer;
			if (container && DockContainer != null)
			{
				DockContainer.Parent = dockPanelFloatingForm;
				DockContainer.Dock = DockStyle.Fill;
				dockPanelFloatingForm.DragContainerAlong(DockContainer);
				NCRefresh();
			}
			else
			{
				if (dockContainer != null)
				{
					dockContainer.RemoveDock(this);
				}

				base.Parent = dockPanelFloatingForm;
				base.Visible = true;
				Dock = DockStyle.Fill;
			}

			SetNonClientMargin();
			ResetNCMouseState();
			if (this.StartedFloating != null)
			{
				this.StartedFloating(this, new EventArgs());
			}

			if (Manager != null)
			{
				Manager.NotifyFloating(this);
			}

			return dockPanelFloatingForm;
		}

		internal void DockControl(DockContainer parent)
		{
			if (!(parent == DockContainer))
			{
				if (Parent is DockPanelFloatingForm dockPanelFloatingForm)
				{
					base.Parent = null;
					dockPanelFloatingForm.Close();
					dockPanelFloatingForm.Dispose();
				}

				SetNonClientMargin();
				parent.AddDock(this);
				parent.RepaintAll();
			}
		}

		private void SetNonClientMargin()
		{
			if (manager != null)
			{
				base.NonClientMargin = manager.Renderer.DockPanelRenderer.GetPanelBorderSize(DockContainer, this, BestOrientation);
			}
		}

		internal void UnFloat(DockPanelFloatingForm f)
		{
			Manager.StopDockMode(this);
			Refresh();
		}

		public void Open()
		{
			DockStyle best = DockStyle.Bottom;
			if (base.Height > base.Width)
			{
				best = DockStyle.Right;
			}

			Open(best);
		}

		public void Open(DockStyle best)
		{
			if (last.Floating)
			{
				Float(last.Pos);
				if (this.Opened != null)
				{
					this.Opened(this, new EventArgs());
				}

				return;
			}

			if (last.Container != null)
			{
				if (last.Container.Parent != null)
				{
					last.Container.AddDock(this);
					EnsureVisible();
					if (this.Opened != null)
					{
						this.Opened(this, new EventArgs());
					}

					return;
				}

				if (Manager != null)
				{
					Manager.DockPanelInt(this, last.Container.Dock);
					if (this.Opened != null)
					{
						this.Opened(this, new EventArgs());
					}

					return;
				}
			}
			else
			{
				if (Manager != null)
				{
					Manager.DockPanelInt(this, best);
					if (this.Opened != null)
					{
						this.Opened(this, new EventArgs());
					}

					return;
				}

				if (ManagerSingelton.Global.MainDockManager != null)
				{
					ManagerSingelton.Global.MainDockManager.DockPanel(this, best);
					if (this.Opened != null)
					{
						this.Opened(this, new EventArgs());
					}

					return;
				}
			}

			Float(last.Pos);
			if (this.Opened != null)
			{
				this.Opened(this, new EventArgs());
			}
		}

		public void Close()
		{
			Close(fromform: false, intern: false);
		}

		internal void CloseIntern()
		{
			Close(fromform: false, intern: true);
		}

		internal void CloseFromForm()
		{
			Close(fromform: true, intern: false);
		}

		protected void Close(bool fromform, bool intern)
		{
			DockPanelClosingEvent dockPanelClosingEvent = new DockPanelClosingEvent(this);
			if (this.Closing != null && !intern)
			{
				this.Closing(this, dockPanelClosingEvent);
			}

			if (dockPanelClosingEvent.Cancel)
			{
				return;
			}

			DockPanelFloatingForm floatForm = FloatForm;
			last.Floating = Floating;
			last.Container = DockContainer;
			last.Pos = base.Location;
			if (last.Container != null)
			{
				last.Container.RemoveDock(this);
				if (last.Container.Highlight != null)
				{
					last.Container.Highlight.NCRefresh();
				}

				Manager.Update();
			}

			if (floatForm != null)
			{
				if (!fromform)
				{
					floatForm.Close();
				}

				last.Pos = floatForm.Location;
			}

			base.Parent = null;
			if (this.Closed != null && !intern)
			{
				this.Closed(this, new EventArgs());
			}
		}

		internal void SetParentInt(Control p)
		{
			SetParent(p);
		}

		protected void SetParent(Control p)
		{
			base.Parent = p;
		}

		public void Collapse()
		{
			if (DockContainer != null)
			{
				DockContainer.Collapse();
			}
		}

		public void Collapse(bool anim)
		{
			if (DockContainer != null)
			{
				DockContainer.Collapse(anim);
			}
		}

		public void Expand()
		{
			if (DockContainer != null)
			{
				DockContainer.Expand();
			}
		}

		public void Expand(bool anim)
		{
			if (DockContainer != null)
			{
				DockContainer.Expand(anim);
			}
		}

		protected override void OnNcPaint(NCPaintEventArgs e)
		{
			if (!(Manager != null))
			{
				return;
			}

			e.Graphics.FillRegion(new SolidBrush(manager.Renderer.ColorTable.DockBackgroundColor), e.PaintRegion);
			buttonData = Manager.Renderer.DockPanelRenderer.ConstructButtonData(DockContainer, e);
			if (!Floating || FloatContainer)
			{
				if (DockContainer != null)
				{
					if (!OnlyChild || !DockContainer.HideSingleButton)
					{
						Manager.Renderer.DockPanelRenderer.RenderButtonBackground(this, e);
						buttonData.Render(renderbackgroundbar: true);
					}
				}
				else
				{
					Manager.Renderer.DockPanelRenderer.RenderButtonBackground(this, e);
					buttonData.Render(renderbackgroundbar: true);
				}
			}

			if (Floating)
			{
				return;
			}

			Manager.Renderer.DockPanelRenderer.RenderCaption(this, e);
			foreach (DockPanelCaptionButton cbutton in cbuttons)
			{
				cbutton.Render(e);
			}

			Manager.Renderer.DockPanelRenderer.RenderBorder(this, e);
		}

		protected override void OnBufferedPaint(PaintEventArgs e)
		{
			base.OnBufferedPaint(e);
		}

		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (this.OpenedStateChanged != null)
			{
				this.OpenedStateChanged(this, new EventArgs());
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (this.OpenedStateChanged != null)
			{
				this.OpenedStateChanged(this, new EventArgs());
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (CaptionText != null && ButtonText != null)
			{
				NCRefresh(force: true);
			}
		}

		internal void FireHighlightChanged(DockPanel dp)
		{
			if (dp == this)
			{
				base.Visible = true;
				NCRefresh();
			}
			else
			{
				base.Visible = false;
			}

			if (this.HighlightChange != null)
			{
				this.HighlightChange(this, new HighlightChangeEventArgs(this, dp));
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

		public static bool operator ==(DockPanel a, DockPanel b)
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

		public static bool operator !=(DockPanel a, DockPanel b)
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

		protected bool HasFocus()
		{
			if (Focused)
			{
				return true;
			}

			foreach (Control control in base.Controls)
			{
				if (control.Focused)
				{
					return true;
				}
			}

			return false;
		}

		internal void OnPanelCollectionChanged(DockPanel newdp, DockContainer cnt, bool remove)
		{
			if (remove && OnlyChild)
			{
				SetNonClientMargin();
				RefreshAll();
			}
			else if (!remove && !OnlyChild)
			{
				SetNonClientMargin();
				RefreshAll();
			}
		}

		public virtual void RefreshMargin()
		{
			SetNonClientMargin();
		}

		public override void RefreshAll()
		{
			RefreshMargin();
			base.RefreshAll();
		}

		public void OpenFloating()
		{
			Float(last.Pos);
			if (this.Opened != null)
			{
				this.Opened(this, new EventArgs());
			}
		}

		internal void Serialize(BinaryWriter writer)
		{
			DoSerialize(writer);
		}

		protected virtual void DoSerialize(BinaryWriter writer)
		{
			writer.Write(last.Pos.X);
			writer.Write(last.Pos.Y);
			writer.Write(last.Floating);
			if (last.Container != null)
			{
				writer.Write(last.Container.Name);
			}
			else
			{
				writer.Write("");
			}

			writer.Write(base.Visible);
			writer.Write(Collapsed);
			writer.Write(IsOpen);
			writer.Write(base.Width);
			writer.Write(base.Height);
			if (Floating)
			{
				writer.Write(base.ParentForm.Left);
				writer.Write(base.ParentForm.Top);
			}
			else
			{
				writer.Write(base.Left);
				writer.Write(base.Top);
			}

			if (Parent != null)
			{
				writer.Write(Parent.Name);
				writer.Write(Parent.Controls.GetChildIndex(this));
			}
			else
			{
				writer.Write("");
				writer.Write(0);
			}
		}

		internal void Deserialize(BinaryReader reader, Dictionary<string, DockManager.DockContainerDescriptor> docks, uint ver)
		{
			DoDeserialize(reader, docks, ver);
		}

		protected virtual void DoDeserialize(BinaryReader reader, Dictionary<string, DockManager.DockContainerDescriptor> docks, uint ver)
		{
			LastOpenState lastOpenState = default(LastOpenState);
			if (ver >= 6)
			{
				int x = reader.ReadInt32();
				int y = reader.ReadInt32();
				lastOpenState.Pos = new Point(x, y);
				lastOpenState.Floating = reader.ReadBoolean();
				string key = reader.ReadString();
				if (docks.ContainsKey(key))
				{
					lastOpenState.Container = docks[key].Container;
				}
			}

			base.Visible = reader.ReadBoolean();
			reader.ReadBoolean();
			bool flag = reader.ReadBoolean();
			base.Width = reader.ReadInt32();
			base.Height = reader.ReadInt32();
			int x2 = reader.ReadInt32();
			int y2 = reader.ReadInt32();
			string key2 = reader.ReadString();
			reader.ReadInt32();
			if (docks.ContainsKey(key2))
			{
				Close();
				last = lastOpenState;
				last.Container = docks[key2].Container;
				if (flag)
				{
					Open();
				}
			}
			else
			{
				last = lastOpenState;
				base.Visible = true;
				if (flag)
				{
					Float(new Point(x2, y2));
				}
			}
		}
	}
}
