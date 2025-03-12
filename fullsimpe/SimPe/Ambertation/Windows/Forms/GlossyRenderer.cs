// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Ambertation.Renderer;
using IColorTable = Ambertation.Windows.Forms.IColorTable;
using GlossyColorTable = Ambertation.Windows.Forms.GlossyColorTable;

namespace Ambertation.Windows.Forms
{
	public class GlossyRenderer : BaseRenderer
	{
		public GlossyRenderer(IColorTable ct, IFontTable ft)
			: base(ct, ft)
		{
		}

		public GlossyRenderer(IColorTable ct)
			: this(ct, new GlossyFontTable())
		{
		}

		public GlossyRenderer()
			: this(new GlossyColorTable())
		{
		}

		protected override void CreateDockRenderer(out IRenderDockHints rnd)
		{
			rnd = new GlossyRenderDockHints(this);
		}

		protected override void CreateDockPanelRenderer(out IDockPanelRenderer rnd)
		{
			rnd = new GlossyRenderDockPanel(this);
		}
	}
}
