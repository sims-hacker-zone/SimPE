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
		}

		public override string ToString()
		{
			return L.Get("pjBMTHelp");
		}

		public System.Drawing.Image Icon => null;

		#endregion
	}
}
