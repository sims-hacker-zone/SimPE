// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	public abstract class DockPanelCaptionButton
	{
		private DockPanel parent;

		private CaptionButtonState state;

		private bool visible;

		protected IDockPanelRenderer Renderer => parent.Manager.Renderer.DockPanelRenderer;

		public DockPanel Parent => parent;

		public CaptionButtonState State => state;

		public bool Visible => visible;

		public Rectangle Bounds
		{
			get
			{
				Rectangle captionRect = Renderer.GetCaptionRect(parent);
				return GetBounds(captionRect);
			}
		}

		internal string ImageName => GetImageName();

		public DockPanelCaptionButton(DockPanel dp)
		{
			visible = true;
			parent = dp;
			state = CaptionButtonState.Normal;
		}

		internal bool SetState(CaptionButtonState st)
		{
			bool result = state != st;
			state = st;
			return result;
		}

		public void PerformClick()
		{
			OnClick();
		}

		protected abstract void OnClick();

		internal bool SetVisible(bool vis)
		{
			bool result = vis != visible;
			visible = vis;
			return result;
		}

		internal bool Hit(NCMouseEventArgs e)
		{
			return Bounds.Contains(e.ControlPosition);
		}

		internal void Render(NCPaintEventArgs e)
		{
			Renderer.RenderCaptionButton(parent, this, e);
		}

		protected abstract Rectangle GetBounds(Rectangle captionrect);

		protected abstract string GetImageName();
	}
}
