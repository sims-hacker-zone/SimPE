// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	public class CinematicSceneItem
	{
		#region Attributes
		string description;
		byte unknown1;
		string name;
		int unknown2;
		short unknown3;
		string cinefile;
		string animfile;
		#endregion

		public CinematicSceneItem()
		{
			description = "";
			name = "";
			cinefile = "";
			animfile = "";
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			description = reader.ReadString();
			unknown1 = reader.ReadByte();
			name = reader.ReadString();
			unknown2 = reader.ReadInt32();
			unknown3 = reader.ReadInt16();
			cinefile = reader.ReadString();
			animfile = reader.ReadString();
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
			writer.Write(description);
			writer.Write(unknown1);
			writer.Write(name);
			writer.Write(unknown2);
			writer.Write(unknown3);
			writer.Write(cinefile);
			writer.Write(animfile);
		}
	}

	/// <summary>
	/// Summary description for cCinematicScene.
	/// </summary>
	public class CinematicScene : AbstractRcolBlock
	{
		#region Attributes

		string desc;
		CinematicSceneItem[] items;
		int unknown1;
		int unknown2;
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public CinematicScene(Rcol parent)
			: base(parent)
		{
			sgres = new SGResource(null);
			desc = "";

			items = new CinematicSceneItem[0];
			BlockID = 0x4D51F042;
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
			sgres.Unserialize(reader);
			sgres.BlockID = myid;

			desc = reader.ReadString();

			items = new CinematicSceneItem[reader.ReadInt32()];
			for (int i = 0; i < items.Length; i++)
			{
				items[i] = new CinematicSceneItem();
				items[i].Unserialize(reader);
			}

			unknown1 = reader.ReadInt32();
			unknown2 = reader.ReadInt32();
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

			writer.Write(sgres.BlockName);
			writer.Write(sgres.BlockID);
			sgres.Serialize(writer);

			writer.Write(desc);

			writer.Write(items.Length);
			for (int i = 0; i < items.Length; i++)
			{
				items[i].Serialize(writer);
			}

			writer.Write(unknown1);
			writer.Write(unknown2);
		}

		#endregion

		#region IDisposable Member

		public override void Dispose()
		{
		}

		#endregion
	}
}
