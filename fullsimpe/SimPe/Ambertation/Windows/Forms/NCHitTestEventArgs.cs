// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public class NCHitTestEventArgs : NCMouseEventArgs
	{
		public enum Results
		{
			HTERROR = -2,
			HTTRANSPARENT,
			HTNOWHERE,
			HTCLIENT,
			HTCAPTION,
			HTSYSMENU,
			HTGROWBOX,
			HTMENU,
			HTHSCROLL,
			HTVSCROLL,
			HTMINBUTTON,
			HTMAXBUTTON,
			HTLEFT,
			HTRIGHT,
			HTTOP,
			HTTOPLEFT,
			HTTOPRIGHT,
			HTBOTTOM,
			HTBOTTOMLEFT,
			HTBOTTOMRIGHT,
			HTBORDER,
			HTOBJECT,
			HTCLOSE,
			HTHELP
		}

		private Results res;

		public Results Result
		{
			get
			{
				return res;
			}
			set
			{
				res = value;
			}
		}

		public NCHitTestEventArgs(Point scrpt, Point ctrlpt, Point absctrlpt, Point delta, IntPtr res, NCButtons mb)
			: base(res, scrpt, ctrlpt, absctrlpt, delta, mb)
		{
			this.res = (Results)res.ToInt32();
		}

		internal IntPtr GetResult()
		{
			return new IntPtr((int)Result);
		}

		public override string ToString()
		{
			return base.ToString() + " " + Result;
		}
	}
}
