// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Plugin.Anim;

namespace SimPe.Plugin
{
	/// <summary>
	/// Used to display the MeshBlock Listing
	/// </summary>
	class ListedMeshBlocks
	{
		public ListedMeshBlocks(AnimationMeshBlock amb)
		{
			ANIMBlock = amb;
			CRES = amb.FindDefiningCRES();
			if (CRES != null)
			{
				GMDC = amb.FindUsedGMDC(CRES);
			}
		}

		public AnimationMeshBlock ANIMBlock
		{
			get;
		}

		public GenericRcol CRES
		{
			get;
		}

		public GenericRcol GMDC
		{
			get;
		}

		public override string ToString()
		{
			string s = ANIMBlock.ToString();
			if (CRES == null)
			{
				s += "[No CRES found]";
			}
			else if (GMDC == null)
			{
				s += "[No GMDC found]";
			}

			return s;
		}
	}
}
