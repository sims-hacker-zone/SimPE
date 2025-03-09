// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Data;
using SimPe.PackedFiles.Sdsc;

namespace SimPe.PackedFiles.Famt
{
	/// <summary>
	/// A Sim that is stored within a FamilyTie File
	/// </summary>
	public class FamilyTieSim : FamilyTieCommon
	{

		/// <summary>
		/// Constructor for a new participation sim
		/// </summary>
		/// <param name="siminstance">Instance of the Sim</param>
		/// <param name="ties">the ties he perticipates in</param>
		/// <param name="famt">The Parent Wrapper</param>
		public FamilyTieSim(
			ushort siminstance,
			List<FamilyTieItem> ties,
			Famt famt
		)
			: base(siminstance, famt)
		{
			Ties = ties;
			BlockDelimiter = 0x00000001;
		}

		/// <summary>
		/// Returns / Sets the ties he perticipates in
		/// </summary>
		public List<FamilyTieItem> Ties
		{
			get; set;
		}

		/// <summary>
		/// Returns / Sets the Block Delimiter
		/// </summary>
		internal int BlockDelimiter
		{
			get; set;
		}

		/// <summary>
		/// Returns the avaqilable <see cref="FamilyTieItem"/> for the passed Sim
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns>null or the <see cref="FamilyTieItem"/> for that Sim</returns>
		public FamilyTieItem FindTie(SDesc sdsc)
		{
			if (sdsc == null)
			{
				return null;
			}

			foreach (FamilyTieItem s in Ties)
			{
				if (s.Instance == sdsc.Instance)
				{
					return s;
				}
			}

			return null;
		}

		/// <summary>
		/// Returns the available <see cref="FamilyTieItem"/> for the Sim, or creates a new One
		/// </summary>
		/// <param name="sdsc"></param>
		/// <returns>the <see cref="FamilyTieItem"/> for the passed Sim</returns>
		public FamilyTieItem CreateTie(SDesc sdsc, MetaData.FamilyTieTypes type)
		{
			FamilyTieItem s = FindTie(sdsc);
			if (s == null)
			{
				s = new FamilyTieItem(type, sdsc.Instance, famt);
				Ties.Add(s);
			}
			s.Type = type;
			return s;
		}

		/// <summary>
		/// Remove the passed Family Tie
		/// </summary>
		/// <param name="fti"></param>
		/// <returns>true, if the Tie was removed</returns>
		public bool RemoveTie(FamilyTieItem fti)
		{
			int len = Ties.Count;
			Ties.Remove(fti);
			return Ties.Count < len;
		}
	}
}
