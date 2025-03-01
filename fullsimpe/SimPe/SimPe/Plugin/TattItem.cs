// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class TattItem : System.IDisposable
	{
		#region Attributes
		uint guid;
		ushort[] items;
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public TattItem()
		{
			items = new ushort[0];
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			guid = reader.ReadUInt32();
			items = new ushort[reader.ReadUInt32()];
			for (int i = 0; i < items.Length; i++)
			{
				items[i] = reader.ReadUInt16();
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
		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(guid);
			writer.Write((uint)items.Length);
			for (int i = 0; i < items.Length; i++)
			{
				writer.Write(items[i]);
			}
		}

		#region IDisposable Member

		public void Dispose()
		{
			items = null;
		}

		#endregion

		public override string ToString()
		{
			string s = "0x" + Helper.HexString(guid) + ": ";
			foreach (ushort u in items)
			{
				s += Helper.HexString(u) + " ";
			}

			return s;
		}
	}
}
