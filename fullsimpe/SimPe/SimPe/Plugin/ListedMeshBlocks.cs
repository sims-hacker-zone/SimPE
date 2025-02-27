/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;

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
			this.ANIMBlock = amb;
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

		public SimPe.Plugin.GenericRcol CRES
		{
			get;
		}

		public SimPe.Plugin.GenericRcol GMDC
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
