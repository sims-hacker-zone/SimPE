// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Ttab
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Ttab : pjse.ExtendedWrapper<TtabItem, Ttab>, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		private byte[] filename = new byte[64];
		private uint[] header = { 0xffffffff, 0x00000054, 0x00000000 };
		private byte[] footer = new byte[0];
		#endregion

		#region Accessor methods
		public string FileName
		{
			get => Helper.ToString(filename);
			set
			{
				if (!Helper.ToString(filename).Equals(value))
				{
					filename = Helper.ToBytes(value, 0x40);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Format
		{
			get => header[1];
			set
			{
				if (header[1] != value)
				{
					header[1] = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		public uint Unknown
		{
			get => header[2];
			set
			{
				if (header[2] != value)
				{
					header[2] = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Ttab() : base() { }

		public Ttab(Interfaces.Providers.IOpcodeProvider prv) : base() { }

		public new void Add(TtabItem item)
		{
			Add(item, 0x8000);
		}

		public new void Insert(int index, TtabItem item)
		{
			Insert(index, item, 0x8000);
		}

		#region AbstractWrapper Member
		public override bool CheckVersion(uint version)
		{
			return version == 0012 //0.00
				|| version == 0013; //0.10
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new TtabForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			///
			/// TODO: Change the Description passed here
			///
			return new AbstractWrapperInfo(
				"PJSE TTAB Wrapper",
				"Peter L Jones",
				"Tree Table Editor",
				1
			);
		}

		private static bool isInuse(TtabItem item)
		{
			return item.InUse;
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
			writer.Write(filename);
			writer.Write(header[0]);
			writer.Write(header[1]);
			writer.Write(header[2]);

			List<TtabItem> inUse = items.FindAll(isInuse);
			writer.Write((ushort)inUse.Count);
			foreach (TtabItem item in inUse)
			{
				item.Serialize(writer);
			}

			writer.Write(footer);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(0x40);

			header = new uint[3];
			header[0] = reader.ReadUInt32();
			if (header[0] != 0xffffffff)
			{
				throw new Exception(
					"Unexpected data in TTAB header."
						+ "  Read 0x"
						+ Helper.HexString(header[0])
						+ "."
						+ "  Expected 0xFFFFFFFF."
				);
			}

			header[1] = reader.ReadUInt32();
			header[2] = reader.ReadUInt32();

			ushort itemCount = reader.ReadUInt16();
			items = new List<TtabItem>();
			while (items.Count < itemCount)
			{
				items.Add(new TtabItem(this, reader));
			}

			footer = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);
		}

		#endregion

		public const uint Ttabtype = 0x54544142;

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[] { Ttabtype };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by AbstractWrapper
		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!Helper.FileFormat)
			{
				return base.GetResourceName(ta);
			}

			Interfaces.Files.IPackedFile pf = Package.Read(FileDescriptor);
			byte[] ab = pf.GetUncompressedData(0x48);
			return (ab.Length > 0x44 ? "0x" + Helper.HexString(ab[0x44]) + ": " : "")
				+ Helper.ToString(pf.GetUncompressedData(0x40));
		}
		#endregion
	}
}
