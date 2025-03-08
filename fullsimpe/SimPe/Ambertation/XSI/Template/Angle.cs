// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.XSI.Template
{
	public sealed class Angle : ExtendedContainer
	{
		public enum Representations
		{
			Degrees,
			Radiants
		}

		private Representations r;

		public Representations Representation
		{
			get
			{
				return r;
			}
			set
			{
				r = value;
			}
		}

		public Angle(Container parent, string args)
			: base(parent, args)
		{
			r = Representations.Degrees;
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			r = (Representations)Line(0).GetFloat(0);
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			AddLiteral((int)r);
		}
	}
}
