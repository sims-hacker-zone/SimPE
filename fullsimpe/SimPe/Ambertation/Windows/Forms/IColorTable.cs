// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public interface IColorTable
	{
		Color DockBorderColor { get; }

		Color DockBackgroundColor { get; }

		Color DockHintHightlightColor { get; }

		Color DockHintOverlayColor { get; }

		Color DockButtonBarBackgroundTop { get; }

		Color DockButtonBarBackgroundBottom { get; }

		Color DockButtonBorderColorOuter { get; }

		Color DockButtonBorderColorInner { get; }

		Color DockButtonHighlightBorderColorOuter { get; }

		Color DockButtonHighlightBorderColorInner { get; }

		Color DockButtonBackgroundTop { get; }

		Color DockButtonBackgroundBottom { get; }

		Color DockButtonHighlightBackgroundTop { get; }

		Color DockButtonHighlightBackgroundBottom { get; }

		Color DockButtonTextColor { get; }

		Color DockButtonHighlightTextColor { get; }

		Color DockCaptionColorTop { get; }

		Color DockCaptionFocusColorTop { get; }

		Color DockCaptionColorBottom { get; }

		Color DockCaptionFocusColorBottom { get; }

		Color DockCaptionTextColor { get; }

		Color DockCaptionFocusTextColor { get; }

		Color DockGripColor { get; }

		Color DockReSizeBackgroundColor { get; }

		Color DockReSizeGripColor { get; }
	}
}
