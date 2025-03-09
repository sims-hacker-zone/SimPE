// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;
using SimPe.Extensions;

namespace SimPe.PackedFiles.Clst
{
	/// <summary>
	/// An Item stored in a CPF File
	/// </summary>
	public class ClstItem
	{
		IndexTypes format;

		/// <summary>
		/// Constructor
		/// </summary>
		public ClstItem(IndexTypes format)
			: this(null, format) { }

		/// <summary>
		/// Constructor
		/// </summary>
		public ClstItem(
			Interfaces.Files.IPackedFileDescriptor pfd,
			IndexTypes format
		)
		{
			this.format = format;
			if (pfd != null)
			{
				Type = pfd.Type;
				Instance = pfd.Instance;
				SubType = pfd.SubType;
				Group = pfd.Group;
			}
		}

		/// <summary>
		/// Returns the Type of the referenced File
		/// </summary>
		public FileTypes Type
		{
			get; set;
		}

		/// <summary>
		/// Returns the Name of the represented Type
		/// </summary>
		public FileTypeInformation TypeName => Type.ToFileTypeInformation();

		/// <summary>
		/// Returns the Group the referenced file is assigned to
		/// </summary>
		public uint Group
		{
			get; set;
		}

		/// <summary>
		/// Returns the Instance Data
		/// </summary>
		public uint Instance
		{
			get; set;
		}

		/// <summary>
		/// Returns an yet unknown Type
		/// </summary>
		/// <remarks>Only in Version 1.1 of package Files</remarks>
		public uint SubType
		{
			get; set;
		}

		/// <summary>
		/// Returns the (real) uncompressed Size of the File
		/// </summary>
		public uint UncompressedSize
		{
			get; set;
		}

		public override int GetHashCode()
		{
			return (int)((uint)Type | Instance) - (int)((uint)Type & Instance);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (obj is ClstItem)
			{
				ClstItem ci = (ClstItem)obj;
				return
					ci.Group == Group
					&& ci.Instance == Instance
					&& ci.Type == Type
					&& (
						ci.SubType == SubType
						|| ci.format == IndexTypes.ptShortFileIndex
						|| format == IndexTypes.ptShortFileIndex
					)
				;
			}
			else
			{
				return obj is Interfaces.Files.IPackedFileDescriptor ci
					? ci.Group == Group
									&& ci.Instance == Instance
									&& ci.Type == Type
									&& (
										ci.SubType == SubType
										|| format == IndexTypes.ptShortFileIndex
									)
					: base.Equals(obj);
			}
		}

		public override string ToString()
		{
			string name = TypeName + ": 0x" + Helper.HexString(Type);
			if (format == IndexTypes.ptLongFileIndex)
			{
				name += " - 0x" + Helper.HexString(SubType);
			}

			name +=
				" - 0x"
				+ Helper.HexString(Group)
				+ " - 0x"
				+ Helper.HexString(Instance);

			name += " = 0x" + Helper.HexString(UncompressedSize) + " byte";
			return name;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			Type = (FileTypes)reader.ReadUInt32();
			Group = reader.ReadUInt32();
			Instance = reader.ReadUInt32();
			SubType = format == IndexTypes.ptLongFileIndex ? reader.ReadUInt32() : 0;

			UncompressedSize = reader.ReadUInt32();
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void Serialize(
			System.IO.BinaryWriter writer,
			IndexTypes format
		)
		{
			this.format = format;

			writer.Write((uint)Type);
			writer.Write(Group);
			writer.Write(Instance);
			if (format == IndexTypes.ptLongFileIndex)
			{
				writer.Write(SubType);
			}

			writer.Write(UncompressedSize);
		}
	}
}
