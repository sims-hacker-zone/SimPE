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

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for WorkshopItems.
	/// </summary>
	public class WorkshopMMAT
	{
		/// <summary>
		/// Constructore
		/// </summary>
		/// <param name="subset">initial Name of the Subset</param>
		public WorkshopMMAT(string subset)
		{
			this.Subset = subset;
			this.MMATs = new SimPe.PackedFiles.Wrapper.Cpf[0];
			this.ObjectStateIndex = new uint[0];
		}

		/// <summary>
		/// Arbitary Data
		/// </summary>
		public object[] Tag
		{
			get; set;
		}

		/// <summary>
		/// Returns the Name of the Subset
		/// </summary>
		public string Subset { get; set; } = "";

		/// <summary>
		/// The stored MMATs
		/// </summary>
		public SimPe.PackedFiles.Wrapper.Cpf[] MMATs
		{
			get; private set;
		}

		/// <summary>
		/// adds the passed value if it doesn't already exist
		/// </summary>
		/// <param name="val">The value to add</param>
		public bool AddMMAT(SimPe.PackedFiles.Wrapper.Cpf mmat)
		{
			if (
				this.AddObjectStateIndex(mmat.GetItem("objectStateIndex").UIntegerValue)
			)
			{
				MMATs = (SimPe.PackedFiles.Wrapper.Cpf[])Helper.Add(MMATs, mmat);
				return true;
			}
			return false;
		}

		/// <summary>
		/// adds the passed value if it doesn't already exist
		/// </summary>
		/// <param name="val">The value to add</param>
		public bool AddObjectStateIndex(uint val)
		{
			bool check = false;
			foreach (uint i in ObjectStateIndex)
			{
				if (i == val)
				{
					check = true;
					break;
				}
			}

			if (!check)
				ObjectStateIndex = (uint[])Helper.Add(ObjectStateIndex, val);

			return !check;
		}

		/// <summary>
		/// Returns all known ObjectStateIndex for the current subset
		/// </summary>
		public uint[] ObjectStateIndex
		{
			get; private set;
		}

		public override string ToString()
		{
			return Subset + " (" + this.ObjectStateIndex.Length.ToString() + ")";
		}
	}
}
