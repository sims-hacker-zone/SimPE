// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cCompactorBuilder.
	/// </summary>
	public class CompactorBuilder : AbstractRcolBlock
	{
		#region Attributes
		GeometryBuilder gb;
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public CompactorBuilder(Rcol parent)
			: base(parent)
		{
			gb = new GeometryBuilder(null);
			BlockID = 0xdcdda078;
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			version = reader.ReadUInt32();

			string name = reader.ReadString();
			uint myid = reader.ReadUInt32();
			gb.Unserialize(reader);
			gb.BlockID = myid;
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(version);

			writer.Write(gb.BlockName);
			writer.Write(gb.BlockID);
			gb.Serialize(writer);
		}
		#endregion

		#region IDisposable Member

		public override void Dispose()
		{
		}

		#endregion
	}
}
