// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public class ClassicColorTable : IColorTable
	{
		public Color DockBorderColor => SystemColors.ActiveBorder;

		public Color DockBackgroundColor => SystemColors.Control;

		public Color DockHintHightlightColor => SystemColors.MenuHighlight;

		public Color DockHintOverlayColor => Color.FromArgb(128, Color.White);

		public Color DockButtonBorderColorOuter => SystemColors.InactiveBorder;

		public Color DockButtonBorderColorInner => Color.Transparent;

		public Color DockButtonHighlightBorderColorOuter => SystemColors.ActiveBorder;

		public Color DockButtonHighlightBorderColorInner => Color.Transparent;

		public Color DockButtonBarBackgroundTop => SystemColors.ControlDarkDark;

		public Color DockButtonBarBackgroundBottom => DockButtonBarBackgroundTop;

		public Color DockButtonBackgroundTop => SystemColors.Control;

		public Color DockButtonBackgroundBottom => DockButtonBackgroundTop;

		public Color DockButtonHighlightBackgroundTop => SystemColors.ControlLightLight;

		public Color DockButtonHighlightBackgroundBottom => DockButtonHighlightBackgroundTop;

		public Color DockButtonTextColor => SystemColors.GrayText;

		public Color DockButtonHighlightTextColor => SystemColors.ControlText;

		public Color DockCaptionColorTop => SystemColors.InactiveCaption;

		public Color DockCaptionColorBottom => DockCaptionColorTop;

		public Color DockCaptionFocusColorTop => SystemColors.ActiveCaption;

		public Color DockCaptionFocusColorBottom => DockCaptionFocusColorTop;

		public Color DockCaptionTextColor => SystemColors.InactiveCaptionText;

		public Color DockCaptionFocusTextColor => SystemColors.ActiveCaptionText;

		public Color DockGripColor => SystemColors.ControlDark;

		public Color DockReSizeBackgroundColor => SystemColors.AppWorkspace;

		public Color DockReSizeGripColor => SystemColors.ButtonShadow;
	}
}
