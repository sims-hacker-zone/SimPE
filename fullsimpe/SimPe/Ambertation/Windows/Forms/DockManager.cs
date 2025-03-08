// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Ambertation.Windows.Forms.Graph;
using TD.SandDock;

namespace Ambertation.Windows.Forms
{
	[Designer(typeof(DockManagerDesigner))]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(DockManager), "Floaters.dockimg.png")]
	public class DockManager : BaseDockManager
	{
		public class DockContainerDescriptor
		{
			private DockContainer dc;

			private int index;

			private bool collapsed;

			private string hname;

			public DockContainer Container => dc;

			public int Index => index;

			public bool Collapsed => collapsed;

			public string HighlightName => hname;

			internal DockContainerDescriptor(DockContainer dc, int index, bool collapsed, string highlightname)
			{
				this.dc = dc;
				this.index = index;
				this.collapsed = collapsed;
				hname = highlightname;
			}
		}

		private const uint MAGIC = 4211087879u;

		private const uint VERSION = 6u;

		private List<ManagedLayeredForm> layers;

		private List<DockHint> hints;
		private bool didinit;

		private ContainerInfo last;

		private DockHint allleft;
		private DockHint allright;

		private DockHint alltop;

		private DockHint allbottom;

		private DockHint allcenter;

		private DockOverlay overlay;

		private Dictionary<DockStyle, DockButtonBar> colconts;

		private TextWriter writer;

		private Size defsz;

		private Control oldparent;

		public new Size DefaultSize
		{
			get
			{
				return defsz;
			}
			set
			{
				defsz = value;
			}
		}

		protected override bool MeAsCenterDock => true;

		public List<DockPanel> GetPanels()
		{
			Dictionary<string, DockPanel> dictionary = new Dictionary<string, DockPanel>();
			GetPanels(dictionary);
			List<DockPanel> list = new List<DockPanel>();
			foreach (DockPanel value in dictionary.Values)
			{
				list.Add(value);
			}

			return list;
		}

		protected override void GetPanels(Dictionary<string, DockPanel> list)
		{
			foreach (DockPanel floatingpanel in floatingpanels)
			{
				if (floatingpanel.Name == "")
				{
					floatingpanel.Name = "dp_" + list.Count + "_" + floatingpanel.Guid.ToString();
				}

				list[floatingpanel.Name] = floatingpanel;
			}

			base.GetPanels(list);
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(4211087879u);
			writer.Write(6u);
			Dictionary<string, DockPanel> dictionary = new Dictionary<string, DockPanel>();
			GetPanels(dictionary);
			int counter = 0;
			DoSerialize(writer, ref counter);
			writer.Write(dictionary.Count);
			foreach (DockPanel value in dictionary.Values)
			{
				writer.Write(value.Name);
				value.Serialize(writer);
			}
		}

		private void ReadException(BinaryReader reader, string msg)
		{
			throw new FileLoadException(msg);
		}

		public void Deserialize(BinaryReader reader)
		{
			uint num = reader.ReadUInt32();
			uint num2 = reader.ReadUInt32();
			if (num != 4211087879u)
			{
				ReadException(reader, "Not a DockLayout Resource (invalid MAGIC Code)");
			}

			if (num2 > 6)
			{
				ReadException(reader, "Not a DockLayout Resource (unknown Version)");
			}

			bool visible = base.Visible;
			SuspendLayout();
			base.Visible = false;
			Dictionary<string, DockPanel> list = new Dictionary<string, DockPanel>();
			Dictionary<string, DockPanel> dictionary = new Dictionary<string, DockPanel>();
			GetPanels(list);
			foreach (DockButtonBar value in colconts.Values)
			{
				value.Clear();
			}

			Dictionary<string, DockContainerDescriptor> docks = new Dictionary<string, DockContainerDescriptor>();
			DeserializeContainers(reader, docks);
			DeserializePanels(reader, list, dictionary, docks, num2);
			DeserializePass2(docks, dictionary);
			base.Visible = visible;
			ResumeLayout();
		}

		protected void DeserializeContainers(BinaryReader reader, Dictionary<string, DockContainerDescriptor> docks)
		{
			PrepareDeserialize();
			DoDeserialize(reader, docks, null);
		}

		private void DeserializePanels(BinaryReader reader, Dictionary<string, DockPanel> list, Dictionary<string, DockPanel> vlist, Dictionary<string, DockContainerDescriptor> docks, uint ver)
		{
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				string text = reader.ReadString();
				DockPanel dockPanel;
				if (!list.ContainsKey(text))
				{
					dockPanel = ManagerSingelton.Global.GetPanelWithName(text);
					if (dockPanel == null)
					{
						dockPanel = new DockPanel(this);
					}
				}
				else
				{
					dockPanel = list[text];
					list.Remove(text);
					vlist[text] = dockPanel;
				}

				dockPanel.Deserialize(reader, docks, ver);
			}

			CloseRemainingPanels(list);
		}

		private static void CloseRemainingPanels(Dictionary<string, DockPanel> list)
		{
			foreach (DockPanel value in list.Values)
			{
				value.Close();
			}
		}

		protected void DeserializePass2(Dictionary<string, DockContainerDescriptor> docks, Dictionary<string, DockPanel> list)
		{
			foreach (DockContainerDescriptor value in docks.Values)
			{
				if (!(value.Container is DockManager))
				{
					value.Container.Parent.Controls.SetChildIndex(value.Container, value.Index);
					if (value.Collapsed)
					{
						value.Container.Collapse(animated: false);
					}
					else
					{
						value.Container.Visible = true;
					}

					if (list.ContainsKey(value.HighlightName))
					{
						list[value.HighlightName].EnsureVisible();
					}

					value.Container.SetNoCleanUpIntern(val: false);
					value.Container.SetForceUseAsTarget(val: false);
				}
			}
		}

		~DockManager()
		{
		}

		public DockManager()
			: base(ManagerSingelton.Global.DockRenderer)
		{
			ManagerSingelton.Global.SetMainManager(this);
			didinit = false;
			last = default(ContainerInfo);
			manager = this;
			defsz = new Size(100, 100);
			layers = new List<ManagedLayeredForm>();
			hints = new List<DockHint>();
			overlay = new DockOverlay(this);
			overlay.Hide();
			allcenter = new DockHint(this);
			allcenter.Text = "Center hint";
			allleft = new DockHint(this, l: true, t: false, r: false, b: false, c: false);
			hints.Add(allleft);
			allleft.Text = "Left hint";
			alltop = new DockHint(this, l: false, t: true, r: false, b: false, c: false);
			hints.Add(alltop);
			alltop.Text = "Top hint";
			allright = new DockHint(this, l: false, t: false, r: true, b: false, c: false);
			hints.Add(allright);
			allright.Text = "Right hint";
			allbottom = new DockHint(this, l: false, t: false, r: false, b: true, c: false);
			hints.Add(allbottom);
			allbottom.Text = "Bottom hint";
			hints.Add(allcenter);
			ChangeHostControl();
			layers.Add(overlay);
			foreach (DockHint hint in hints)
			{
				layers.Add(hint);
				hint.Hover += base.MouseOverHint;
			}

			dockmode = false;
			colconts = new Dictionary<DockStyle, DockButtonBar>();
			BuildSpecialContainer(DockStyle.Left);
			BuildSpecialContainer(DockStyle.Top);
			BuildSpecialContainer(DockStyle.Right);
			BuildSpecialContainer(DockStyle.Bottom);
		}

		protected override void DoDockChanged()
		{
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (base.Visible && !didinit)
			{
				didinit = false;
			}
		}

		private void BuildSpecialContainer(DockStyle d)
		{
			colconts[d] = new DockButtonBar(this);
			colconts[d].BackColor = SystemColors.Control;
			colconts[d].Width = 20;
			colconts[d].Height = 20;
			colconts[d].Dock = d;
			colconts[d].Parent = this;
			colconts[d].Visible = false;
		}

		public void ForceCleanUp()
		{
			CleanUp();
			RepaintAll();
		}

		protected override void CleanUp()
		{
			base.CleanUp();
			TopmostCenter();
			ListControls();
		}

		protected override void RearrangeControls()
		{
			base.RearrangeControls();
			if (colconts.Count >= 4 && (base.Controls.GetChildIndex(colconts[DockStyle.Bottom]) > 3 || base.Controls.GetChildIndex(colconts[DockStyle.Right]) > 3 || base.Controls.GetChildIndex(colconts[DockStyle.Top]) > 3 || base.Controls.GetChildIndex(colconts[DockStyle.Left]) > 3))
			{
				colconts[DockStyle.Bottom].SendToBack();
				colconts[DockStyle.Right].SendToBack();
				colconts[DockStyle.Top].SendToBack();
				colconts[DockStyle.Left].SendToBack();
			}
		}

		internal void TopmostCenter()
		{
			List<DockContainer> list = new List<DockContainer>();
			foreach (DockContainer container in containers)
			{
				if (container.Dock == DockStyle.Fill)
				{
					list.Add(container);
				}
			}

			foreach (DockPanel panel in panels)
			{
				panel.BringToFront();
			}

			if (base.Highlight != null)
			{
				base.Highlight.BringToFront();
			}

			foreach (DockContainer item in list)
			{
				item.BringToFront();
			}
		}

		protected override void SetNewContainerIndex(ref int index, ref bool after, ref bool toplevel, DockStyle dockstyle)
		{
			base.SetNewContainerIndex(ref index, ref after, ref toplevel, dockstyle);
			if (index == -1)
			{
				index = 0;
				toplevel = false;
			}
		}

		protected void ShowOverlay(Rectangle rect)
		{
			overlay.Location = rect.Location;
			overlay.Size = rect.Size;
			overlay.Show();
			foreach (DockHint hint in hints)
			{
				if (hint.Visible)
				{
					hint.BringToFront();
				}
			}
		}

		protected void HideOverlay()
		{
			overlay.Hide();
		}

		private Point HostToScreen(int x, int y)
		{
			Point pt = new Point(x, y);
			return HostToScreen(pt);
		}

		private Point HostToScreen(Point pt)
		{
			return PointToScreen(pt);
		}

		protected override void SetTargetContainerInfo(DockHint sender, ref ContainerInfo nfo)
		{
			nfo.DockInside = false;
			nfo.Parent = this;
			nfo.TopLevel = sender != allcenter;
		}

		protected override void OnMouseOverHint(DockHint sender, ref ContainerInfo nfo)
		{
			base.OnMouseOverHint(sender, ref nfo);
			last = nfo;
			if (nfo.Hint == SelectedHint.None)
			{
				HideOverlay();
			}
			else
			{
				ShowOverlay(nfo.OverlayRectangle);
			}
		}

		protected void ChangeHostControl()
		{
			TakeHint(allcenter);
			SetMainHintLocation();
		}

		private void SetMainHintLocation()
		{
			Rectangle screenBounds = base.ScreenBounds;
			if (allleft != null && allright != null && alltop != null && allbottom != null)
			{
				allleft.SetDesktopLocation(screenBounds.Left + 8, screenBounds.Top + (screenBounds.Height - allleft.Height) / 2);
				alltop.SetDesktopLocation(screenBounds.Left + (screenBounds.Width - alltop.Width) / 2, screenBounds.Top + 8);
				allright.SetDesktopLocation(screenBounds.Left + screenBounds.Width - 8 - allright.Width, screenBounds.Top + (screenBounds.Height - allleft.Height) / 2);
				allbottom.SetDesktopLocation(screenBounds.Left + (screenBounds.Width - allbottom.Width) / 2, screenBounds.Top + screenBounds.Height - 8 - allbottom.Height);
			}
		}

		internal override void TakeHint(DockHint hint)
		{
			TakeHint(hint, base.ScreenBounds, null);
		}

		protected override void OnTakeHint()
		{
		}

		public new void Refresh()
		{
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			ChangeHostControl();
		}

		protected override void OnParentChanged(EventArgs e)
		{
			if (oldparent != null)
			{
				oldparent.LocationChanged -= oldparent_LocationChanged;
				oldparent.SizeChanged -= oldparent_LocationChanged;
				oldparent.Layout -= oldparent_Layout;
			}

			base.OnParentChanged(e);
			oldparent = base.Parent;
			if (oldparent != null)
			{
				oldparent.LocationChanged += oldparent_LocationChanged;
				oldparent.SizeChanged += oldparent_LocationChanged;
				oldparent.Layout += oldparent_Layout;
			}

			ChangeHostControl();
		}

		private void oldparent_Layout(object sender, LayoutEventArgs e)
		{
			ChangeHostControl();
		}

		protected void oldparent_LocationChanged(object sender, EventArgs e)
		{
			ChangeHostControl();
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			ChangeHostControl();
		}

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);
		}

		protected override void UpdateHintVisibility()
		{
			base.UpdateHintVisibility();
			foreach (DockHint hint in hints)
			{
				if (hint == allcenter)
				{
					hint.Show();
				}
				else if (!hint.Rectangle.IntersectsWith(allcenter.Rectangle))
				{
					hint.Show();
				}
				else
				{
					hint.Hide();
				}
			}
		}

		protected override DockContainer GetDockContainer(Point scrpt)
		{
			foreach (ManagedLayeredForm layer in layers)
			{
				bool hit = layer.Hit(scrpt);
				layer.MouseOver(layer.PointToClient(scrpt), hit);
			}

			return base.GetDockContainer(scrpt);
		}

		public DockButtonBar GetButtonBar(DockContainer dc)
		{
			foreach (DockButtonBar value in colconts.Values)
			{
				if (value.Contains(dc))
				{
					return value;
				}
			}

			return null;
		}

		public DockButtonBar GetBestButtonBar(DockContainer dc)
		{
			Control control = dc;
			Control control2 = control.Parent;
			while (control2 != null && !(control2 is DockManager))
			{
				control = control2;
				control2 = control.Parent;
			}

			if (control2 == null)
			{
				return colconts[DockStyle.Right];
			}

			if (control.Dock == DockStyle.Fill || control.Dock == DockStyle.None)
			{
				return colconts[DockStyle.Right];
			}

			return colconts[control.Dock];
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (!base.DesignMode)
			{
				CleanUp();
			}
		}

		public void DockPanel(DockPanel dp, DockStyle style)
		{
			DockPanelInt(dp, style);
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			DockPanel dockPanel = e.Control as DockPanel;
			if (dockPanel != null && e.Control.Dock == DockStyle.Fill)
			{
				TopmostCenter();
			}
		}

		internal override void MouseMoved(Point scrpt)
		{
			DockContainer dockContainer = GetDockContainer(scrpt);
			if (dockContainer != null)
			{
				TakeHint(allcenter, dockContainer.GetScreenDockAreaBounds(), dockContainer);
			}
			else
			{
				TakeHint(allcenter);
			}
		}

		internal override void StartDockMode(DockPanel dock)
		{
			if (!dockmode)
			{
				SetMainHintLocation();
				SuspendLayout();
				SetMainHintLocation();
				last = default(ContainerInfo);
				dockmode = true;
				TakeHint(allcenter);
				UpdateHintVisibility();
				CleanUp();
				ResumeLayout();
				OnStartDockMode(dock);
			}
		}

		protected virtual void OnStartDockMode(DockPanel dock)
		{
		}

		internal override void StopDockMode(DockPanel dock)
		{
			if (!dockmode)
			{
				return;
			}

			SuspendLayout();
			dock.SuspendLayout();
			dock.Visible = false;
			dockmode = false;
			foreach (ManagedLayeredForm layer in layers)
			{
				layer.Hide();
			}

			if (last.Hint != SelectedHint.None)
			{
				DockContainer dockContainer = null;
				if (last.Parent != null)
				{
					dockContainer = last.Seed;
					DockContainer dockContainer2 = dockContainer;
					dockContainer.SuspendLayout();
					if (last.Hint != SelectedHint.Center)
					{
						DockContainer dockContainer3;
						if (dock.FloatContainer)
						{
							dockContainer3 = dock.DockContainer;
							dockContainer2 = dockContainer3;
							dockContainer3.SuspendLayout();
							if (dockContainer3.Parent as DockContainer != last.Parent)
							{
								dockContainer3.Parent = last.Parent;
								last.Parent.SetupContainer(last.SeedIndex, !last.DockInside, last.TopLevel, last.Dock, dockContainer3);
							}
						}
						else
						{
							dockContainer3 = last.Parent.CreateNewContainer(last.SeedIndex, !last.DockInside, last.TopLevel, last.Dock);
							dockContainer2 = dockContainer3;
							dockContainer3.SuspendLayout();
						}

						if (!(last.Parent is DockManager))
						{
							dockContainer2.Width = Math.Max(20, Math.Min(DefaultSize.Width, last.Parent.Width / 2));
							dockContainer2.Height = Math.Max(20, Math.Min(DefaultSize.Height, last.Parent.Height / 2));
						}
						else
						{
							dockContainer2.Width = Math.Min(last.Parent.Width / 2, dock.Width);
							dockContainer2.Height = Math.Min(last.Parent.Height / 2, dock.Height);
						}

						dockContainer3.Visible = true;
						dockContainer3.ResumeLayout();
					}
					else if (dock.FloatContainer)
					{
						DockContainer dockContainer4 = dock.DockContainer;
						int count = dockContainer4.GetDockedPanels().Count;
						for (int num = count - 1; num >= 0; num--)
						{
							DockPanel dockPanel = dockContainer4.GetDockedPanels()[num];
							dockPanel.DockControl(dockContainer2);
							dockPanel.RefreshMargin();
						}
					}

					if (dock.DockContainer != dockContainer2)
					{
						dock.DockControl(dockContainer2);
					}

					dock.EnsureVisible();
					dock.RefreshAll();
				}

				CleanUp();
				if (dockContainer != null)
				{
					dockContainer.ResumeLayout();
				}
			}

			OnStopDockMode(dock);
			ResumeLayout();
			dock.Visible = true;
			dock.ResumeLayout();
			dock.NCRefresh();
		}

		protected virtual void OnStopDockMode(DockPanel dock)
		{
		}
	}
}

