// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public class NCMouseEventArgs : EventArgs
	{
		private Point spt;

		private Point crpt;

		private Point ctrlpt;

		private Point delta;

		private NCButtons mb;

		private NCHitTestEventArgs.Results ires;

		public NCButtons MouseButtons => mb;

		public Point Delta => delta;

		public Point ScreenPosition => spt;

		public Point ControlPosition => ctrlpt;

		public Point ClientRectanglePosition => crpt;

		public NCHitTestEventArgs.Results InitialResult => ires;

		public NCMouseEventArgs(IntPtr res, Point scrpt, Point ctrlpt, Point absctrlpt, Point delta, NCButtons mb)
		{
			spt = scrpt;
			crpt = ctrlpt;
			this.ctrlpt = absctrlpt;
			this.delta = delta;
			this.mb = mb;
			ires = (NCHitTestEventArgs.Results)res.ToInt32();
		}

		public override string ToString()
		{
			return string.Concat(ScreenPosition, " ", ControlPosition, " ", ClientRectanglePosition, " ", MouseButtons, " ", Delta, " ", InitialResult);
		}
	}
}
