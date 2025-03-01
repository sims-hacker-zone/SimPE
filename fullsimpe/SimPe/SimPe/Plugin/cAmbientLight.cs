// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
			BlockID = 0xc9c81b9b;
		}
	}
}
