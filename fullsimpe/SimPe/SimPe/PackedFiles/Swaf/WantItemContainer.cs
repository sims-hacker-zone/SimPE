// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.PackedFiles.Swaf
{
	/// <summary>
	/// Summary description for WantItemContainer.
	/// </summary>
	public class WantItemContainer
	{
		private uint guid;

		public List<WantItem> Items
		{
			get; set;
		} = new List<WantItem>();

		/// <summary>
		/// Returns Informations about the Selected want
		/// </summary>
		public WantInformation Information => WantInformation.LoadWant(guid);

		public Interfaces.IProviderRegistry Provider
		{
			get;
		}

		public WantItemContainer(Interfaces.IProviderRegistry provider)
		{
			Provider = provider;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			guid = reader.ReadUInt32();

			uint wantcount = reader.ReadUInt32();
			Items.Capacity = (int)wantcount;
			for (int i = 0; i < wantcount; i++)
			{
				WantItem want = new WantItem(Provider);
				want.Unserialize(reader);
				Items.Add(want);
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(guid);
			writer.Write((uint)Items.Count);

			foreach (WantItem want in Items)
			{
				want.Serialize(writer);
			}
		}

		public override string ToString()
		{
			return $"{Information.Name} (count={Items.Count})";
		}
	}
}
