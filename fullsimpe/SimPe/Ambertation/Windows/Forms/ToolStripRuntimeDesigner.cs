// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	public class ToolStripRuntimeDesigner
	{
		public static void Add(ToolStrip ts)
		{
			List<ToolStripButton> list = new List<ToolStripButton>();
			int top = 0;
			foreach (ToolStripItem item3 in ts.Items)
			{
				ToolStripButton item2 = new ToolStripButtonExt(item3, ref top);
				list.Add(item2);
			}

			foreach (ToolStripButton item4 in list)
			{
				ts.Items.Add(item4);
			}
		}

		protected static void Add(ToolStripPanel pn, ContextMenuStrip men)
		{
			foreach (Control control in pn.Controls)
			{
				if (control is ToolStrip toolStrip)
				{
					ToolStripButton value = new MenuStripButtonExt(toolStrip);
					men.Items.Add(value);
					if (toolStrip != null)
					{
						Add(toolStrip);
					}
				}
			}

			pn.ContextMenuStrip = men;
		}

		public static void Add(ToolStripContainer cnt)
		{
			ContextMenuStrip men = new ContextMenuStrip();
			Add(cnt.TopToolStripPanel, men);
			Add(cnt.LeftToolStripPanel, men);
			Add(cnt.BottomToolStripPanel, men);
			Add(cnt.RightToolStripPanel, men);
		}

		public static void LineUpToolBars(ToolStripContainer cnt)
		{
			LineUpToolBars(cnt.TopToolStripPanel, horz: true);
			LineUpToolBars(cnt.LeftToolStripPanel, horz: false);
			LineUpToolBars(cnt.BottomToolStripPanel, horz: true);
			LineUpToolBars(cnt.RightToolStripPanel, horz: false);
		}

		public static void LineUpToolBars(ToolStripPanel pn, bool horz)
		{
			int left = 0;
			int top = 0;
			foreach (Control control in pn.Controls)
			{
				if (control is ToolStrip toolStrip)
				{
					toolStrip.Left = left;
					toolStrip.Top = top;
					if (horz)
					{
						left = toolStrip.Left + toolStrip.Width + 1;
					}
					else
					{
						top = toolStrip.Top + toolStrip.Height + 1;
					}
				}
			}
		}
	}
}
