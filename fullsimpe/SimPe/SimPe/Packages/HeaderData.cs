// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;
using System.IO;

namespace SimPe.Packages
{
	/// <summary>
	/// Structural Data of a .package Header
	/// </summary>
	public class HeaderData : Interfaces.Files.IPackageHeader, IDisposable
	{
		/// <summary>
		/// Constructor for the class
		/// </summary>
		internal HeaderData()
		{
			LockIndexDuringLoad = false;
			index = new HeaderIndex(this);
			hole = new HeaderHole();
			id = new char[4];
			reserved_00 = new int[3];
			reserved_02 = new int[7];

			id[0] = 'D';
			id[1] = 'B';
			id[2] = 'P';
			id[3] = 'F';

			majorversion = 1;
			minorversion = 1;
			index.Type = 7;

			epicon = 0;
			showicon = 0;

			IndexType = Data.IndexTypes.ptLongFileIndex;
		}

		/// <summary>
		/// Identifier of the File
		/// </summary>
		internal char[] id;

		/// <summary>
		/// Returns the Identifier of the File
		/// </summary>
		/// <remarks>This value should be DBPF</remarks>
		[Description("Package Identifier"), DefaultValue("DBPF")]
		public string Identifier
		{
			get
			{
				string ret = "";
				foreach (char c in id)
				{
					ret += c;
				}

				return ret;
			}
		}

		/// <summary>
		/// The Icon to display (for lot packages)
		/// </summary>
		internal short epicon;

		[
			Description("The Icon to display for this Package"),
			Category("Icon"),
			DefaultValue(0)
		]
		public short Epicon
		{
			get => epicon;
			set => epicon = value;
		}

		/// <summary>
		/// Should the defined Icon be shown : 1 is true (for lot packages)
		/// </summary>
		internal short showicon;

		[
			Description("Should an Icon display for this Package"),
			Category("Icon"),
			DefaultValue(0)
		]
		public short Showicon
		{
			get => showicon;
			set => showicon = value;
		}

		/// <summary>
		/// The Major Version (part before the .) of the Package File Format
		/// </summary>
		internal int majorversion;

		/// <summary>
		/// Returns the Major Version of The Packages FileFormat
		/// </summary>
		/// <remarks>This value should be 1</remarks>
		[
			Description("Major Version Number of this Package"),
			Category("Version"),
			DefaultValue(1)
		]
		public int MajorVersion => majorversion;

		/// <summary>
		/// The Minor Version (part after the .) of the Package File Format
		/// </summary>
		internal int minorversion;

		/// <summary>
		/// Returns the Minor Version of The Packages FileFormat
		/// </summary>
		/// <remarks>This value should be 0 or 1</remarks>
		[
			Description("Minor Version Number of this Package"),
			Category("Version"),
			DefaultValue(1)
		]
		public int MinorVersion => minorversion;

		/// <summary>
		/// Returns the Overall Version of this Package
		/// </summary>
		[
			Description("Overall Versionnumber of this Package"),
			Category("Version"),
			DefaultValue(4294967297)
		]
		public long Version => (long)((ulong)MajorVersion << 0x20) | (uint)MinorVersion;

		/// <summary>
		/// 3 dwords of reserved Data
		/// </summary>
#if DEBUG
		public int[] reserved_00;
#else
		internal Int32[] reserved_00;
#endif

		/// <summary>
		/// Createion Date of the File
		/// </summary>
#if DEBUG
		public uint created;

		[
			Description("Creation Date of the Package"),
			Category("Debug"),
			ReadOnly(true)
		]
#else
		public uint Ident
		{
			get
			{
				return Created;
			}
		}
		internal uint created;

		[
			DescriptionAttribute("Creation Date of the Package"),
			CategoryAttribute("Debug"),
			Browsable(false)
		]
#endif
		public uint Created
		{
			get => created;
			set => created = value;
		}

		/// <summary>
		/// Modification Date of the File
		/// </summary>
#if DEBUG
		public int modified;

		[
			Description("Modification Date of the Package"),
			Category("Debug")
		]
		public int Modified => modified;
#else
		internal Int32 modified;
#endif

		/// <summary>
		/// holds Index Informations stored in the Header
		/// </summary>
		internal HeaderIndex index;

		/// <summary>
		/// Returns Index Informations stored in the Header
		/// </summary>
		[Browsable(false)]
		public Interfaces.Files.IPackageHeaderIndex Index => index;

		/// <summary>
		/// Holds Hole Index Informations stored in the Header
		/// </summary>
		internal HeaderHole hole;

		/// <summary>
		/// Returns Hole Index Informations stored in the Header
		/// </summary>
		[Browsable(false)]
		public Interfaces.Files.IPackageHeaderHoleIndex HoleIndex => hole;

		/// <summary>
		/// Returns or Sets the Type of the Package
		/// </summary>
		[
			Description(
				"The Indextype used in the Package. ptLongFileIndex allows the use of the \"Instance (high)\" Value."
			),
			DefaultValue(Data.IndexTypes.ptLongFileIndex)
		]
		public Data.IndexTypes IndexType
		{
			get; set;
		}

		/// <summary>
		/// 7 dwords of reserved Data - was 8 but have lost one for Icon in lot files
		/// </summary>
#if DEBUG
		public int[] reserved_02;

		[Description("Reserved Values"), Category("Debug")]
		public int[] Reserved => reserved_02;
#else
		internal Int32[] reserved_02;
#endif

		/// <summary>
		/// true if the version is greater or equal than 1.1
		/// </summary>
		[Browsable(false)]
		public bool IsVersion0101 => Version >= 0x100000001; //((majorversion>1) || ((majorversion==1) && (minorversion>=1)));

		internal bool LockIndexDuringLoad
		{
			get; set;
		}

		#region File Processing Methods
		static string spore =
			"\r\n\r\nSimPe is a package editor for Sims2 packages only.";

		/// <summary>
		/// Initializes the Structure from a BinaryReader
		/// </summary>
		/// <param name="reader">The Reader representing the Package File</param>
		/// <remarks>Reader must be on the correct Position since no Positioning is performed</remarks>
		internal void Load(BinaryReader reader)
		{
			//this.id = new char[4];
			for (uint i = 0; i < id.Length; i++)
			{
				id[i] = reader.ReadChar();
			}

			if (!Helper.AnyPackage && Identifier != "DBPF")
			{
				throw new InvalidOperationException(
					"SimPe does not support this type of file." + spore
				);
			}

			majorversion = reader.ReadInt32();
			if (!Helper.AnyPackage && majorversion > 1)
			{
				throw new InvalidOperationException(
					"SimPe does not support this version of DBPF file." + spore
				);
			}

			minorversion = reader.ReadInt32();

			//this.reserved_00 = new Int32[3];
			for (uint i = 0; i < reserved_00.Length; i++)
			{
				reserved_00[i] = reader.ReadInt32();
			}

			created = reader.ReadUInt32();
			modified = reader.ReadInt32();

			index.type = reader.ReadInt32();
			if (!LockIndexDuringLoad)
			{
				index.count = reader.ReadInt32();
				index.offset = reader.ReadUInt32();
				index.size = reader.ReadInt32();
			}
			else
			{
				reader.ReadInt32();
				reader.ReadInt32();
				reader.ReadInt32(); //count, offset, size
			}

			hole.count = reader.ReadInt32();
			hole.offset = reader.ReadUInt32();
			hole.size = reader.ReadInt32();

			if (IsVersion0101)
			{
				IndexType = (Data.IndexTypes)reader.ReadUInt32();
			}

			epicon = reader.ReadInt16();
			showicon = reader.ReadInt16();

			//this.reserved_02 = new Int32[8];
			for (uint i = 0; i < reserved_02.Length; i++)
			{
				reserved_02[i] = reader.ReadInt32();
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="writer"></param>
		/// <remarks>Writer must be on the correct Position since no Positioning is performed</remarks>
		internal void Save(BinaryWriter writer)
		{
			for (uint i = 0; i < id.Length; i++)
			{
				writer.Write(id[i]);
			}

			writer.Write(majorversion);
			writer.Write(minorversion);

			for (uint i = 0; i < reserved_00.Length; i++)
			{
				writer.Write(reserved_00[i]);
			}

			writer.Write(created);
			writer.Write(modified);

			writer.Write(index.type);
			writer.Write(index.count);
			writer.Write(index.offset);
			writer.Write(index.size);

			writer.Write(hole.count);
			writer.Write(hole.offset);
			writer.Write(hole.size);

			if (IsVersion0101)
			{
				writer.Write((uint)IndexType);
			}

			writer.Write(epicon);
			writer.Write(showicon);

			for (uint i = 0; i < reserved_02.Length; i++)
			{
				writer.Write(reserved_02[i]);
			}
		}
		#endregion

		#region IDisposable Member

		public void Dispose()
		{
			hole = null;
			index = null;
			reserved_00 = null;
			reserved_02 = null;
			id = null;
		}

		#endregion

		public object Clone()
		{
			HeaderData iph = new HeaderData
			{
				created = created,
				id = id,
				IndexType = IndexType,
				majorversion = majorversion,
				minorversion = minorversion,
				modified = modified,

				reserved_00 = reserved_00,
				reserved_02 = reserved_02,

				epicon = epicon,
				showicon = showicon
			};
			return iph;
		}
	}
}
