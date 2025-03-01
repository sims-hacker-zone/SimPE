// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Windows.Forms
{
	public class ListViewDoubleBuffered : System.Windows.Forms.ListView
	{
		public ListViewDoubleBuffered()
			: base()
		{
			SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
		}
	}
}
