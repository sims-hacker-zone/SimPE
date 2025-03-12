// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public interface IFontTable
	{
		Font ButtonFont { get; }
		Font ButtonHighlightFont { get; }
		Font CaptionFont { get; }
	}
}
