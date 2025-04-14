// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Drawing;

namespace Ambertation.Windows.Forms
{
	public interface IRenderDockHints : IControlRenderer
	{
		Size HintSize { get; }
		Rectangle LeftRectangle { get; }
		Rectangle TopRectangle { get; }
		Rectangle RightRectangle { get; }
		Rectangle BottomRectangle { get; }
		Rectangle CenterRectangle { get; }
		void InitHints(bool l, bool t, bool r, bool b, bool c);
		void RenderHint(System.Drawing.Graphics g, bool l, bool t, bool r, bool b, bool c, SelectedHint sel);
	}
}
