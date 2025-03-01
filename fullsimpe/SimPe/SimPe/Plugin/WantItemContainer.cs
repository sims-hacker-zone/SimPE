// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for WantItemContainer.
	/// </summary>
	public class WantItemContainer
	{
		uint guid;

		public WantItem[] Items
		{
			get; set;
		}

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
			Items = new WantItem[0];
			Provider = provider;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			guid = reader.ReadUInt32();
			Items = new WantItem[reader.ReadUInt32()];

			for (int i = 0; i < Items.Length; i++)
			{
				Items[i] = new WantItem(Provider);
				Items[i].Unserialize(reader);
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
			writer.Write((uint)Items.Length);

			for (int i = 0; i < Items.Length; i++)
			{
				Items[i].Serialize(writer);
			}
		}

		public override string ToString()
		{
			return Information.Name + " (count=" + Items.Length.ToString() + ")";
		}
	}
}
