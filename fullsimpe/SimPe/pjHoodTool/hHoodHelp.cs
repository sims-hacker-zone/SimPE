// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace pjHoodTool
{
	class hHoodHelp : IHelp
	{
		#region IHelp Members

		public void ShowHelp(SimPe.ShowHelpEventArgs e)
		{
		}

		public override string ToString()
		{
			return "Export Neighborhood data";
		}

		public System.Drawing.Image Icon => null;

		#endregion
	}
}
