// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public class NCPaintEventArgs : EventArgs
	{
		private Rectangle clientRect;

		private Rectangle windowRect;

		private Region paintRegion;

		private System.Drawing.Graphics gr;

		public System.Drawing.Graphics Graphics => gr;

		public Rectangle ClientRectangle => clientRect;

		public Rectangle WindowRectangle => windowRect;

		public Region PaintRegion => paintRegion;

		public NCPaintEventArgs(System.Drawing.Graphics g, Rectangle cr, Rectangle wr, Region pr)
		{
			gr = g;
			clientRect = cr;
			windowRect = wr;
			paintRegion = pr;
		}
	}
}
