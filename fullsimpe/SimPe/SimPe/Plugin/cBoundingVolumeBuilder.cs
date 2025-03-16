// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cBoundingVolumeBuilder.
	/// </summary>
	public class BoundingVolumeBuilder : AbstractRcolBlock
	{
		#region Attributes
		GeometryBuilder gb;

		public byte[] Unknown1
		{
			get; set;
		}
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public BoundingVolumeBuilder(Rcol parent)
			: base(parent)
		{
			gb = new GeometryBuilder(null);
			BlockID = 0x1cfeceb8;

			Unknown1 = new byte[5];
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

			if (version >= 0x2)
			{
				Unknown1 = reader.ReadBytes(Unknown1.Length);
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
		public override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(version);

			writer.Write(gb.BlockName);
			writer.Write(gb.BlockID);
			gb.Serialize(writer);

			if (version >= 0x2)
			{
				writer.Write(Unknown1);
			}
		}
		#endregion

		#region IDisposable Member

		public override void Dispose()
		{
		}

		#endregion
	}
}
