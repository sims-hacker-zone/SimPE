// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.PackedFiles.Cpf;

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
			Subset = subset;
			MMATs = new List<Cpf>();
			ObjectStateIndex = new List<uint>();
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
		public List<Cpf> MMATs
		{
			get; private set;
		}

		/// <summary>
		/// adds the passed value if it doesn't already exist
		/// </summary>
		/// <param name="val">The value to add</param>
		public bool AddMMAT(Cpf mmat)
		{
			if (
				AddObjectStateIndex(mmat.GetItem("objectStateIndex").UIntegerValue)
			)
			{
				MMATs.Add(mmat);
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
			{
				ObjectStateIndex.Add(val);
			}

			return !check;
		}

		/// <summary>
		/// Returns all known ObjectStateIndex for the current subset
		/// </summary>
		public List<uint> ObjectStateIndex
		{
			get; private set;
		}

		public override string ToString()
		{
			return Subset + " (" + ObjectStateIndex.Count.ToString() + ")";
		}
	}
}
