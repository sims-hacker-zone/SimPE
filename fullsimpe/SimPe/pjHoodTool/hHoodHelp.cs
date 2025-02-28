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
#if NET1
			string relativePathToHelp = "pjHoodTool_NET1.plugin/pjHoodTool_Help";
#else
			string relativePathToHelp = "pjHoodTool.plugin/pjHoodTool_Help";
#endif
			SimPe.RemoteControl.ShowHelp(
				"file://"
					+ SimPe.Helper.SimPePluginPath
					+ "/"
					+ relativePathToHelp
					+ "/Contents.htm"
			);
		}

		public override string ToString()
		{
			return "Export Neighborhood data";
		}

		public System.Drawing.Image Icon => null;

		#endregion
	}
}
