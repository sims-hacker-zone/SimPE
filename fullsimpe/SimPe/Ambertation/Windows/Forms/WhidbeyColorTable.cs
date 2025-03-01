// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public class WhidbeyColorTable : IColorTable
	{
		public Color DockBorderColor => Color.FromArgb(172, 168, 153);

		public Color DockBackgroundColor => SystemColors.Control;

		public Color DockHintHightlightColor => SystemColors.MenuHighlight;

		public Color DockHintOverlayColor => Color.FromArgb(128, SystemColors.MenuHighlight);

		public Color DockButtonBorderColorOuter => Color.FromArgb(80, DockButtonHighlightBorderColorOuter);

		public Color DockButtonBorderColorInner => Color.Transparent;

		public Color DockButtonHighlightBorderColorOuter => Color.FromArgb(172, 168, 153);

		public Color DockButtonHighlightBorderColorInner => Color.Transparent;

		public Color DockButtonBarBackgroundTop => DockBackgroundColor;

		public Color DockButtonBarBackgroundBottom => DockBackgroundColor;

		public Color DockButtonBackgroundTop => Color.FromArgb(237, 236, 224);

		public Color DockButtonBackgroundBottom => DockButtonBackgroundTop;

		public Color DockButtonHighlightBackgroundTop => Color.FromArgb(252, 252, 254);

		public Color DockButtonHighlightBackgroundBottom => DockButtonHighlightBackgroundTop;

		public Color DockButtonTextColor => Color.FromArgb(113, 111, 100);

		public Color DockButtonHighlightTextColor => Color.Black;

		public Color DockCaptionColorTop => Color.FromArgb(192, 187, 175);

		public Color DockCaptionColorBottom => DockCaptionColorTop;

		public Color DockCaptionFocusColorTop => Color.FromArgb(59, 128, 237);

		public Color DockCaptionFocusColorBottom => Color.FromArgb(49, 106, 197);

		public Color DockCaptionTextColor => Color.Black;

		public Color DockCaptionFocusTextColor => Color.White;

		public Color DockGripColor => SystemColors.ControlLight;

		public Color DockReSizeBackgroundColor => Color.SteelBlue;

		public Color DockReSizeGripColor => Color.Navy;
	}
}
