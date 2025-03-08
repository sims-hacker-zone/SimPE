// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambertation.Windows.Forms
{
	public class GlossyColorTable : IColorTable
	{
		public Color DockBorderColor => Color.FromArgb(172, 168, 153);

		public Color DockBackgroundColor => SystemColors.Control;

		public Color DockHintHightlightColor => SystemColors.MenuHighlight;

		public Color DockHintOverlayColor => Color.FromArgb(128, SystemColors.MenuHighlight);

		public Color DockButtonBorderColorOuter => Color.FromArgb(96, DockButtonHighlightBorderColorOuter);

		public Color DockButtonBorderColorInner => Color.FromArgb(64, Color.White);

		public Color DockButtonHighlightBorderColorOuter => Color.FromArgb(160, 172, 168, 153);

		public Color DockButtonHighlightBorderColorInner => Color.FromArgb(160, Color.White);

		public Color DockButtonBarBackgroundTop => Color.FromArgb(238, 238, 238);

		public Color DockButtonBarBackgroundBottom => Color.FromArgb(255, 255, 255);

		public Color DockButtonBackgroundTop => Color.FromArgb(255, 255, 255);

		public Color DockButtonBackgroundBottom => Color.FromArgb(233, 233, 233);

		public Color DockButtonHighlightBackgroundTop => Color.FromArgb(245, 245, 245);

		public Color DockButtonHighlightBackgroundBottom => Color.FromArgb(234, 234, 234);

		public Color DockButtonTextColor => Color.FromArgb(113, 111, 100);

		public Color DockButtonHighlightTextColor => Color.Black;

		public Color DockCaptionColorTop => Color.FromArgb(211, 211, 215);

		public Color DockCaptionColorBottom => Color.FromArgb(208, 208, 212);

		public Color DockCaptionFocusColorTop => Color.FromArgb(86, 93, 97);

		public Color DockCaptionFocusColorBottom => Color.FromArgb(79, 85, 89);

		public Color DockCaptionTextColor => Color.Black;

		public Color DockCaptionFocusTextColor => Color.White;

		public Color DockGripColor => SystemColors.ControlLight;

		public Color DockReSizeBackgroundColor => Color.FromArgb(112, 114, 134);

		public Color DockReSizeGripColor => Color.FromArgb(62, 63, 74);
	}
}
