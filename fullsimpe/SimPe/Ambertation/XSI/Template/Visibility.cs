// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.XSI.Template
{
	public sealed class Visibility : ExtendedContainer
	{
		public enum States
		{
			NotVisible,
			Visible
		}

		private States v;

		public States State
		{
			get
			{
				return v;
			}
			set
			{
				v = value;
			}
		}

		public Visibility(Container parent, string args)
			: base(parent, args)
		{
			v = States.Visible;
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			v = (States)Line(0).GetFloat(0);
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
			AddLiteral((int)v);
		}
	}
}
