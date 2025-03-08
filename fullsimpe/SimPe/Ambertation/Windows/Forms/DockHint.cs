// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public class DockHint : ManagedLayeredForm
	{
		internal delegate void HoverEvent(DockHint sender, SelectedHint hint);

		private DockContainer parent;

		private bool center;

		private bool left;

		private bool right;

		private bool top;

		private bool bottom;

		private SelectedHint wassel;

		internal DockContainer ParentContainer
		{
			get
			{
				return parent;
			}
			set
			{
				parent = value;
			}
		}

		internal bool CenterIndicator
		{
			get
			{
				return center;
			}
			set
			{
				center = value;
			}
		}

		internal bool LeftIndicator
		{
			get
			{
				return left;
			}
			set
			{
				left = value;
			}
		}

		internal bool RightIndicator
		{
			get
			{
				return right;
			}
			set
			{
				right = value;
			}
		}

		internal bool TopIndicator
		{
			get
			{
				return top;
			}
			set
			{
				top = value;
			}
		}

		internal bool BottomIndicator
		{
			get
			{
				return bottom;
			}
			set
			{
				bottom = value;
			}
		}

		internal Rectangle Rectangle => base.DesktopBounds;

		internal event EventHandler HoverLeft;

		internal event EventHandler HoverTop;

		internal event EventHandler HoverRight;

		internal event EventHandler HoverBottom;

		internal event EventHandler HoverCenter;

		internal event EventHandler HoverNone;

		internal event HoverEvent Hover;

		internal DockHint(DockManager manager)
			: this(manager, l: true, t: true, r: true, b: true, c: true)
		{
		}

		internal DockHint(DockManager manager, bool l, bool t, bool r, bool b)
			: this(manager, l, t, r, b, c: true)
		{
		}

		internal DockHint(DockManager manager, bool l, bool t, bool r, bool b, bool c)
			: base(manager)
		{
			base.Size = base.Manager.Renderer.DockRenderer.HintSize;
			base.Manager.Renderer.DockRenderer.InitHints(l, t, r, b, c);
			parent = null;
			center = c;
			left = l;
			top = t;
			right = r;
			bottom = b;
			wassel = SelectedHint.Left;
			Init(BuildHints(SelectedHint.None));
			Hide();
			Text = "Dock Hint";
		}

		internal override void MouseOver(Point pt, bool hit)
		{
			base.MouseOver(pt, hit);
			UpdateCanvas(pt, hit);
		}

		protected virtual void DoRenderHints(SelectedHint sel)
		{
			Bitmap bitmap = BuildHints(sel);
			SelectBitmap(bitmap);
			wassel = sel;
		}

		private Bitmap BuildHints(SelectedHint sel)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
			base.Manager.Renderer.DockRenderer.RenderHint(graphics, LeftIndicator, TopIndicator, RightIndicator, BottomIndicator, CenterIndicator, sel);
			if (sel == SelectedHint.None && this.HoverNone != null)
			{
				this.HoverNone(this, new EventArgs());
			}
			else if (sel == SelectedHint.Left && this.HoverLeft != null)
			{
				this.HoverLeft(this, new EventArgs());
			}
			else if (sel == SelectedHint.Top && this.HoverTop != null)
			{
				this.HoverTop(this, new EventArgs());
			}
			else if (sel == SelectedHint.Right && this.HoverRight != null)
			{
				this.HoverRight(this, new EventArgs());
			}
			else if (sel == SelectedHint.Bottom && this.HoverBottom != null)
			{
				this.HoverBottom(this, new EventArgs());
			}
			else if (sel == SelectedHint.Center && this.HoverCenter != null)
			{
				this.HoverCenter(this, new EventArgs());
			}

			if (this.Hover != null)
			{
				this.Hover(this, sel);
			}

			graphics.Dispose();
			return bitmap;
		}

		private void UpdateCanvas(Point pt, bool hit)
		{
			if (hit)
			{
				SelectedHint selectedHint = GetSelectedHint(pt);
				if (base.Visible && selectedHint != wassel)
				{
					DoRenderHints(selectedHint);
				}
			}
			else if (wassel != SelectedHint.None)
			{
				DoRenderHints(SelectedHint.None);
			}
		}

		private SelectedHint GetSelectedHint(Point pt)
		{
			SelectedHint result = SelectedHint.None;
			if (CenterIndicator && base.Manager.Renderer.DockRenderer.CenterRectangle.Contains(pt))
			{
				result = SelectedHint.Center;
			}
			else if (LeftIndicator && base.Manager.Renderer.DockRenderer.LeftRectangle.Contains(pt))
			{
				result = SelectedHint.Left;
			}
			else if (TopIndicator && base.Manager.Renderer.DockRenderer.TopRectangle.Contains(pt))
			{
				result = SelectedHint.Top;
			}
			else if (RightIndicator && base.Manager.Renderer.DockRenderer.RightRectangle.Contains(pt))
			{
				result = SelectedHint.Right;
			}
			else if (BottomIndicator && base.Manager.Renderer.DockRenderer.BottomRectangle.Contains(pt))
			{
				result = SelectedHint.Bottom;
			}

			return result;
		}
	}
}
