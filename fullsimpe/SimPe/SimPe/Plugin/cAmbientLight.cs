// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for StandardLightBase.
	/// </summary>
	public class AmbientLight : DirectionalLight
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public AmbientLight(Rcol parent)
			: base(parent)
		{
			version = 1;
			BlockID = (uint)FileTypes.LDIR;
		}
	}
}
