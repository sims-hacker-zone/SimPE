// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.Windows.Forms
{
	public class WhidbeyRenderer : BaseRenderer
	{
		public WhidbeyRenderer(IColorTable ct, IFontTable ft)
			: base(ct, ft)
		{
		}

		public WhidbeyRenderer(IColorTable ct)
			: this(ct, new WhidbeyFontTable())
		{
		}

		public WhidbeyRenderer()
			: this(new WhidbeyColorTable())
		{
		}

		protected override void CreateDockRenderer(out IRenderDockHints rnd)
		{
			rnd = new WhidbeyRenderDockHints(this);
		}

		protected override void CreateDockPanelRenderer(out IDockPanelRenderer rnd)
		{
			rnd = new WhidbeyRenderDockPanel(this);
		}
	}
}
