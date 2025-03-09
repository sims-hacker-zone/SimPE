// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;

namespace SimPe.PackedFiles.Famt
{

	/// <summary>
	/// Contains one FamilyTie
	/// </summary>
	public class FamilyTieItem : FamilyTieCommon
	{

		/// <summary>
		/// Creates a new FamilyTie
		/// </summary>
		/// <param name="type">The Type of the tie</param>
		/// <param name="siminstance">The instance of the Target sim</param>
		/// <param name="famt">The Parent Wrapper</param>
		public FamilyTieItem(
			MetaData.FamilyTieTypes type,
			ushort siminstance,
			Famt famt
		)
			: base(siminstance, famt)
		{
			Type = type;
		}

		/// <summary>
		/// Returns / Sets the Type of the Tie
		/// </summary>
		public MetaData.FamilyTieTypes Type
		{
			get; set;
		}

		/// <summary>
		/// Overrides the default ToString Method
		/// </summary>
		/// <returns>A String describing the Object</returns>
		public override string ToString()
		{
			return ((LocalizedFamilyTieTypes)Type).ToString() + ": " + base.ToString();
		}
	}
}
