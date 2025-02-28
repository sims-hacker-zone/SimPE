// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace pj
{
	class BodyMeshHelp : IHelp
	{
		#region IHelp Members

		public void ShowHelp(SimPe.ShowHelpEventArgs e)
		{
#if NET1
			string relativePathToHelp =
				"pjBodyMeshTool_NET1.plugin/pjBodyMeshTool_Help";
#else
			string relativePathToHelp = "pjBodyMeshTool.plugin/pjBodyMeshTool_Help";
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
			return L.Get("pjBMTHelp");
		}

		public System.Drawing.Image Icon => null;

		#endregion
	}
}
