// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Rtex
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class RoadTexture
		: AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension,
			IMultiplePackedFileWrapper,
			IEnumerable
	{
		public enum RoadTextureType : byte
		{
			Materials = 0x1,
			Unknown = 0x2,
		}

		#region Attributes
		Hashtable values;

		public RoadTextureType Type
		{
			get; set;
		}

		public string FileName
		{
			get; set;
		}

		public uint Id
		{
			get; set;
		}

		public uint Unknown2
		{
			get; set;
		}

		public uint Unknown3
		{
			get; set;
		}

		#endregion



		/// <summary>
		/// Constructor
		/// </summary>
		public RoadTexture()
			: base()
		{
			values = new Hashtable();
			FileName = "";
			Type = RoadTextureType.Materials;
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return version == 0012 //0.10
				|| version == 0013; //0.12
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new RoadTextureControl();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Road Texture Wrapper",
				"Quaxi",
				"This Files describes the used Road Materials.",
				1,
				null
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			values.Clear();

			byte[] fname = reader.ReadBytes(0x40);
			FileName = Helper.ToString(fname);

			Id = reader.ReadUInt32();
			Unknown2 = reader.ReadUInt32();
			Unknown3 = reader.ReadUInt32();

			uint ct = reader.ReadUInt32();

			long pos = reader.BaseStream.Position;
			try
			{
				for (int i = 0; i < ct; i++)
				{
					string k = reader.ReadString();
					string v = reader.ReadString();
					values[k] = v;
				}

				Type = RoadTextureType.Materials;
			}
			catch
			{
				Type = RoadTextureType.Unknown;
				reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);

				for (int i = 0; i < ct; i++)
				{
					uint k = reader.ReadUInt32();
					uint v = reader.ReadUInt32();
					values[k] = v;
				}
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
		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			byte[] fname = Helper.ToBytes(FileName, 0x40);
			writer.Write(fname);

			writer.Write(Id);
			writer.Write(Unknown2);
			writer.Write(Unknown3);

			writer.Write((uint)values.Count);

			if (Type == RoadTextureType.Materials)
			{
				foreach (string k in values.Keys)
				{
					string v = (string)values[k];
					writer.Write(v);
					writer.Write(k);
				}
			}
			else
			{
				foreach (uint k in values.Keys)
				{
					uint v = (uint)values[k];
					writer.Write(v);
					writer.Write(k);
				}
			}
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.RTEX };

		#endregion

		#region IMultiplePackedFileWrapper Member

		public override object[] GetConstructorArguments()
		{
			return new object[0];
		}

		#endregion

		#region IEnumerable Member

		public object this[object key]
		{
			get => values[key];
			set => values[key] = value;
		}

		public IEnumerator GetEnumerator()
		{
			return values.Keys.GetEnumerator();
		}

		#endregion
	}
}
