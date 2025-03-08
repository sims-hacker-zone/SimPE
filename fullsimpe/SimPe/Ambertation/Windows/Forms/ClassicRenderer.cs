// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.Windows.Forms
{
	public class ClassicRenderer : BaseRenderer
	{
		public ClassicRenderer(IColorTable ct, IFontTable ft)
			: base(ct, ft)
		{
		}

		public ClassicRenderer(IColorTable ct)
			: this(ct, new ClassicFontTable())
		{
		}

		public ClassicRenderer()
			: this(new ClassicColorTable())
		{
		}

		protected override void CreateDockRenderer(out IRenderDockHints rnd)
		{
			rnd = new ClassicRenderDockHints(this);
		}

		protected override void CreateDockPanelRenderer(out IDockPanelRenderer rnd)
		{
			rnd = new ClassicRenderDockPanel(this);
		}
	}
}
