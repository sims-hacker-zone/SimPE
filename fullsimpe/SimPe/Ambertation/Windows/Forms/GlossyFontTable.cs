// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public class GlossyFontTable : BaseFontTable
	{
		private Font fontbld;

		public override Font ButtonHighlightFont => fontbld;

		public GlossyFontTable()
		{
			fontbld = new Font(base.DefaultFont.FontFamily, base.DefaultFont.Size, FontStyle.Bold);
		}
	}
}
