// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.Wrapper.Supporting
{
	/// <summary>
	/// Summary description for SimRelations.
	/// </summary>
	public class SimRelations
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="rels">(2 Items) inbound and outbound Relationship</param>
		internal SimRelations(SRel[] rels)
		{
			this.rels = rels;
		}

		/// <summary>
		/// Returns/Sets the nametag
		/// </summary>
		public string NameTag { get; set; } = null;

		/// <summary>
		/// Returns the nametag if available
		/// </summary>
		/// <returns>A String Describing the Object</returns>
		public override string ToString()
		{
			return NameTag ?? base.ToString();
		}

		/// <summary>
		/// inbound(1) and outbound(0) relationshios
		/// </summary>
		SRel[] rels;

		/// <summary>
		/// The relation of your Sim zo another
		/// </summary>
		public SRel OutboundRelation => rels[0];

		/// <summary>
		/// The relation of another Sim to your Sim
		/// </summary>
		public SRel InboundRelation => rels[1];

		/// <summary>
		/// Commits the Data
		/// </summary>
		public void SynchronizeUserData()
		{
			if (rels != null)
			{
				rels[0]?.SynchronizeUserData();

				rels[1]?.SynchronizeUserData();
			}
		}
	}
}
