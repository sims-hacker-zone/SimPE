// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.XSI.Template
{
	public sealed class Null : ArgumentContainer
	{
		public string NullName
		{
			get
			{
				return base.Argument1;
			}
			set
			{
				base.Argument1 = value;
			}
		}

		public Null(Container parent, string args)
			: base(parent, args)
		{
		}

		protected override void ResetArgs()
		{
			base.ResetArgs("");
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			Clear(rec: false);
		}
	}
}
