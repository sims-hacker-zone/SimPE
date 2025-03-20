// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;

namespace SimPe.Models.Package
{
	public partial class PackageHeader : ObservableObject
	{
		[ObservableProperty]
		private byte[] magic = "DBPF"u8.ToArray();

		public string MagicString => Encoding.ASCII.GetString(Magic);

		[ObservableProperty]
		private uint majorVersion;

		[ObservableProperty]
		private uint minorVersion;

		public Version Version => new((int)MajorVersion, (int)MinorVersion);

		[ObservableProperty]
		private byte[] reserved_00 = new byte[12];

		[ObservableProperty]
		private uint created;

		[ObservableProperty]
		private uint modified;

		[ObservableProperty]
		private PackageHeaderIndex index;

		[ObservableProperty]
		private PackageHeaderHole hole;

		[ObservableProperty]
		private IndexTypes indexType;

		/// <summary>
		/// The EP icon to show (for Lots)
		/// </summary>
		[ObservableProperty]
		private short epIcon;

		/// <summary>
		/// Whether the EP Icon should be shown
		/// </summary>
		[ObservableProperty]
		private short showIcon;

		[ObservableProperty]
		private byte[] reserved_02 = new byte[28];

		public static PackageHeader Unserialize(BinaryReader reader)
		{
			PackageHeader header = new()
			{
				Magic = reader.ReadBytes(4)
			};
			if (!header.Magic.SequenceEqual("DBPF"u8.ToArray()))
			{
				throw new InvalidDataException("The package header must start with \"DBPF\"");
			}
			header.MajorVersion = reader.ReadUInt32();
			if (header.MajorVersion > 1)
			{
				throw new InvalidDataException("Only DBPF version 1 is supported!");
			}
			header.MinorVersion = reader.ReadUInt32();
			header.Reserved_00 = reader.ReadBytes(12);
			header.Created = reader.ReadUInt32();
			header.Modified = reader.ReadUInt32();
			header.Index = PackageHeaderIndex.Unserialize(reader);
			header.Hole = PackageHeaderHole.Unserialize(reader);
			if (header.Version >= new Version(1, 1))
			{
				header.IndexType = (IndexTypes)reader.ReadUInt32();
			}
			header.EpIcon = reader.ReadInt16();
			header.ShowIcon = reader.ReadInt16();
			header.Reserved_02 = reader.ReadBytes(28);
			return header;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(Magic);
			writer.Write(MajorVersion);
			writer.Write(MinorVersion);
			writer.Write(Reserved_00);
			writer.Write(Created);
			writer.Write(Modified);
			Index.Serialize(writer);
			Hole.Serialize(writer);
			if (Version >= new Version(1, 1))
			{
				writer.Write((uint)IndexType);
			}
			writer.Write(EpIcon);
			writer.Write(ShowIcon);
			writer.Write(Reserved_02);
		}
	}
}
