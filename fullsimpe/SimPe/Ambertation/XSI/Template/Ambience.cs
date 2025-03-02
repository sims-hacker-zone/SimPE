// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace Ambertation.XSI.Template
{
	public sealed class Ambience : ColorContainer
	{
		private Color cl;

		public Color Color
		{
			get
			{
				return cl;
			}
			set
			{
				cl = value;
			}
		}

		public Ambience(Container parent, string args)
			: base(parent, args)
		{
			cl = Color.FromArgb(16, 16, 16);
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			int startline = 0;
			cl = ReadColor(ref startline, inclalpha: false);
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			WriteColor(inclalpha: false, cl);
		}
	}
}
