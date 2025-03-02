// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
			MMATs = new Cpf[0];
			ObjectStateIndex = new uint[0];
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
		public Cpf[] MMATs
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
				MMATs = (Cpf[])Helper.Add(MMATs, mmat);
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
				ObjectStateIndex = (uint[])Helper.Add(ObjectStateIndex, val);
			}

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
			return Subset + " (" + ObjectStateIndex.Length.ToString() + ")";
		}
	}
}
