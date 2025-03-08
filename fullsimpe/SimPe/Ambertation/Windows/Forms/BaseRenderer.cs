// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public abstract class BaseRenderer
	{
		private IColorTable table;

		private IFontTable fnt;

		private IRenderDockHints dock;

		private IDockPanelRenderer panel;

		public IColorTable ColorTable => table;

		public IFontTable FontTable => fnt;

		public IRenderDockHints DockRenderer
		{
			get
			{
				if (dock == null)
				{
					CreateDockRenderer(out dock);
				}

				return dock;
			}
		}

		public IDockPanelRenderer DockPanelRenderer
		{
			get
			{
				if (panel == null)
				{
					CreateDockPanelRenderer(out panel);
				}

				return panel;
			}
		}

		public BaseRenderer(IColorTable ct, IFontTable fnt)
		{
			table = ct;
			this.fnt = fnt;
		}

		protected abstract void CreateDockRenderer(out IRenderDockHints rnd);

		protected abstract void CreateDockPanelRenderer(out IDockPanelRenderer rnd);

		private byte Interpolate(byte cl1, byte cl2, float val)
		{
			return (byte)Math.Min(255f, Math.Max(0f, (float)(int)cl2 * val + (float)(int)cl1 * (1f - val)));
		}

		public Color Interpolate(Color cl1, Color cl2, float val)
		{
			return Color.FromArgb(Interpolate(cl1.R, cl2.R, val), Interpolate(cl1.G, cl2.G, val), Interpolate(cl1.B, cl2.B, val));
		}
	}
}
