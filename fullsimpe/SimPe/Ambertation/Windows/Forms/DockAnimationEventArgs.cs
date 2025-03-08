// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.Windows.Forms
{
	public class DockAnimationEventArgs
	{
		public enum Alignment
		{
			Horizontal,
			Vertical,
			Undefined
		}

		public enum Type
		{
			Collapse,
			Expand
		}

		private DockContainer dc;

		private Type tp;

		private Alignment a;

		public DockContainer Container => dc;

		public Type AnimationType => tp;

		public Alignment DockAlignment => a;

		public DockAnimationEventArgs(DockContainer dc, Type tp, Alignment a)
		{
			this.dc = dc;
			this.tp = tp;
			this.a = a;
		}

		public override string ToString()
		{
			return string.Concat("type:", tp, ", align:", a, ", name:", dc.Name);
		}
	}
}
