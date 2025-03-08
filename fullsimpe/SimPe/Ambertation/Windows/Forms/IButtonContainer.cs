// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	public interface IButtonContainer
	{
		ButtonOrientation BestOrientation { get; }

		DockPanel Highlight { get; }

		DockButtonBar.DockPanelList GetButtons();

		Padding GetBorderSize(ButtonOrientation orient);
	}
}
