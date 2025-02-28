// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace pj
{
	class hObjKeyHelp : IHelp
	{
		#region IHelp Members

		public void ShowHelp(SimPe.ShowHelpEventArgs e)
		{
#if NET1
			string relativePathToHelp = "pjObjKeyTool_NET1.plugin/pjObjKeyTool_Help";
#else
			string relativePathToHelp = "pjObjKeyTool.plugin/pjObjKeyTool_Help";
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
			return L.Get("pjObjKeyHelp");
		}

		public System.Drawing.Image Icon => null;

		#endregion
	}
}
