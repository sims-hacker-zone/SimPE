// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Tatt
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Tatt : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension, IMultiplePackedFileWrapper, IEnumerable<TattItem>
	{
		#region Attributes
		/// <summary>
		/// The FileName
		/// </summary>

		public string FileName
		{
			get; set;
		} = "";

		private byte[] id = new byte[] { (byte)'T', (byte)'T', (byte)'A', (byte)'T' };

		/// <summary>
		/// The Version
		/// </summary>
		public uint Version
		{
			get; set;
		} = 0x4f;

		/// <summary>
		/// Reserved
		/// </summary>
		public uint Reserved
		{
			get; set;
		}

		private readonly List<TattItem> items = new List<TattItem>();
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public Tatt()
			: base()
		{
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
			return new TattUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Tatt Wrapper",
				"Quaxi",
				"Content of this File is unknown.",
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
			items.Clear();
			FileName = Helper.ToString(reader.ReadBytes(0x40));

			id = reader.ReadBytes(0x4);
			Version = reader.ReadUInt32();
			Reserved = reader.ReadUInt32();

			uint ct = reader.ReadUInt32();
			for (int i = 0; i < ct; i++)
			{
				TattItem ti = new TattItem();
				ti.Unserialize(reader);

				items.Add(ti);
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
			writer.Write(Helper.ToBytes(FileName, 0x40));

			writer.Write(id);
			writer.Write(Version);
			writer.Write(Reserved);

			writer.Write((uint)items.Count);
			foreach (TattItem ti in items)
			{
				ti.Serialize(writer);
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
		public uint[] AssignableTypes => new uint[]
				{
					0x54415454, //handles the TATT File
				};

		#endregion

		#region IMultiplePackedFileWrapper Member


		#endregion

		/// <summary>
		/// Number of stored Items
		/// </summary>
		public int Count => items.Count;

		public TattItem this[int index]
		{
			get => items[index];
			set => items[index] = value;
		}

		IEnumerator<TattItem> IEnumerable<TattItem>.GetEnumerator()
		{
			return items.GetEnumerator();
		}

		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}
	}
}
