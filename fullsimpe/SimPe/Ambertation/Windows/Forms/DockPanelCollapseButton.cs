// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public class DockPanelCollapseButton : DockPanelCaptionButton
	{
		internal DockPanelCollapseButton(DockPanel dp)
			: base(dp)
		{
		}

		protected override Rectangle GetBounds(Rectangle captionrect)
		{
			return base.Renderer.GetCollapseButtonRect(base.Parent, captionrect);
		}

		protected override string GetImageName()
		{
			return "pinV";
		}

		protected override void OnClick()
		{
			base.Parent.Collapse();
		}
	}
}
