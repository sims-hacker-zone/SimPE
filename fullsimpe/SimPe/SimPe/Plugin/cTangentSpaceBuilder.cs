// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for cTangentSpaceBuilder.
	/// </summary>
	public class TangentSpaceBuilder : AbstractRcolBlock
	{
		#region Attributes
		GeometryBuilder gb;

		public int Unknown1
		{
			get; set;
		}
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public TangentSpaceBuilder(Rcol parent)
			: base(parent)
		{
			gb = new GeometryBuilder(null);
			BlockID = 0x5d054225;
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

			Unknown1 = reader.ReadInt32();
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

			writer.Write(Unknown1);
		}
		#endregion


		#region IDisposable Member

		public override void Dispose()
		{
		}

		#endregion
	}
}
