// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	public class TransformNodeItem
	{
		public TransformNodeItem()
		{
			Unknown1 = 1;
			ChildNode = 0;
		}

		public ushort Unknown1
		{
			get; set;
		}
		public int ChildNode
		{
			get; set;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			Unknown1 = reader.ReadUInt16();
			ChildNode = reader.ReadInt32();
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
			writer.Write(Unknown1);
			writer.Write(ChildNode);
		}

		public override string ToString()
		{
			return "0x"
				+ Helper.HexString(Unknown1)
				+ " 0x"
				+ Helper.HexString((uint)ChildNode);
		}
	}
}
