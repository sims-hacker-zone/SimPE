/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *   Copyright (C) 2008 Peter L Jones                                      *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;

using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	public enum LtxtVersion : ushort
	{
		Original = 0x000D,
		Business = 0x000E,
		Apartment = 0x0012,
	}

	public enum LtxtSubVersion : ushort
	{
		Original = 0x0006,
		Voyage = 0x0007,
		Freetime = 0x0008,
		Apartment = 0x000B,
	}

	public enum LotOrientation : byte
	{
		Below = 0,
		Left = 1,
		Above = 2,
		Right = 3,
	}

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Ltxt
		: AbstractWrapper //Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		public enum LotType : byte
		{
			Residential = 0x00,
			Community = 0x01,
			Dorm = 0x02,
			GreekHouse = 0x03,
			SecretSociety = 0x04,
			Hotel = 0x05,
			SecretHoliday = 0x06,
			Hobby = 0x07,
			ApartmentBase = 0x08,
			ApartmentSublot = 0x09,
			Witches = 0x0a,
			Unknown = 0xff,
		}

		public enum Rotation
		{
			toLeft = 0x00,
			toTop,
			toRight,
			toBottom,
		};

		public class SubLot
		{
			public uint ApartmentSublot
			{
				get; set;
			}

			public uint Family
			{
				get; set;
			}

			internal uint Unknown2
			{
				get; set;
			}

			internal uint Unknown3
			{
				get; set;
			}

			internal SubLot()
			{
			}

			internal SubLot(System.IO.BinaryReader reader)
			{
				Unserialize(reader);
			}

			private void Unserialize(System.IO.BinaryReader reader)
			{
				ApartmentSublot = reader.ReadUInt32();
				Family = reader.ReadUInt32();
				Unknown2 = reader.ReadUInt32();
				Unknown3 = reader.ReadUInt32();
			}

			internal void Serialize(System.IO.BinaryWriter writer)
			{
				writer.Write(ApartmentSublot);
				writer.Write(Family);
				writer.Write(Unknown2);
				writer.Write(Unknown3);
			}
		}

		#region Attributes
		ushort ver;
		ushort subver;
		Size sz;
		Rotation rotation;
		byte[] unknown_5; //if subver >= Apartment Life
		Point loc;
		byte[] unknown_6; //if subver >= Apartment Life (9 bytes)
		#endregion

		#region Accessor methods
		public LtxtVersion Version
		{
			get
			{
				return (LtxtVersion)ver;
			}
			set
			{
				ver = (ushort)value;
			}
		}
		internal LtxtSubVersion SubVersion
		{
			get
			{
				return (LtxtSubVersion)subver;
			}
			set
			{
				subver = (ushort)value;
			}
		}
		public Size LotSize
		{
			get
			{
				return sz;
			}
			set
			{
				sz = value;
			}
		}
		public LotType Type
		{
			get; set;
		}
		public byte LotRoads { get; set; } = (byte)0x00;
		public byte LotRotation
		{
			get
			{
				return (byte)rotation;
			}
			set
			{
				rotation = (Rotation)value;
			}
		}
		public uint Unknown0
		{
			get; set;
		} // Lot Flags, Use as Boolset
		public string LotName
		{
			get; set;
		}
		public string LotDesc
		{
			get; set;
		}
		internal List<float> Unknown1
		{
			get; private set;
		}
		internal Single Unknown3
		{
			get; set;
		}
		public uint Unknown4
		{
			get; set;
		} // Lot Hobby Flags, Use as Boolset
		internal byte[] Unknown5
		{
			get
			{
				return unknown_5;
			}
			set
			{
				unknown_5 = new byte[9];
				for (int i = 0; i < value.Length && i < unknown_5.Length; i++)
				{
					unknown_5[i] = value[i];
				}
			}
		}
		public uint LotClass
		{
			get; set;
		}
		internal byte Clset
		{
			get; set;
		}

		public Point LotPosition
		{
			get
			{
				return loc;
			}
			set
			{
				loc = value;
			}
		}
		public float LotElevation
		{
			get; set;
		}
		public uint LotInstance
		{
			get; set;
		}
		public LotOrientation Orientation
		{
			get; set;
		}
		public string Texture
		{
			get; set;
		}
		internal byte Unknown2
		{
			get; set;
		}
		public uint OwnerInstance
		{
			get; set;
		}
		public uint ApartmentBase
		{
			get; set;
		}
		internal byte[] Unknown6
		{
			get
			{
				return unknown_6;
			}
			set
			{
				unknown_6 = new byte[9];
				for (int i = 0; i < value.Length && i < unknown_6.Length; i++)
				{
					unknown_6[i] = value[i];
				}
			}
		}
		public List<SubLot> SubLots
		{
			get; private set;
		}
		public List<uint> Unknown7
		{
			get; private set;
		}
		internal byte[] Followup
		{
			get; set;
		}
		internal string appendage
		{
			get
			{
				if (Type == LotType.ApartmentBase)
				{
					return null;
				}

				Idno idno = Idno.FromPackage(Package);
				if (idno == null)
				{
					return "-load:\"Tutorial;" + LotName + "\"";
				}
				//if (idno == null) return null;
				if (idno.Type != NeighborhoodType.Normal)
				{
					return null;
				}

				string appen = "-load:\"";
				string[] parts = System
					.IO.Path.GetFileName(Package.FileName)
					.Split(new char[] { '_' }, 2);
				appen += parts[0] + ";" + LotName + "\"";
				return appen;
			}
		}

		#endregion

		public Interfaces.Providers.ILotItem LotDescription => FileTableBase.ProviderRegistry.LotProvider.FindLot(
					LotInstance
				);

		public Interfaces.IProviderRegistry Provider
		{
			get;
		}

		public Ltxt()
			: this(FileTableBase.ProviderRegistry) { }

		/// <summary>
		/// Constructor
		/// </summary>
		public Ltxt(Interfaces.IProviderRegistry provider)
			: base()
		{
			Provider = provider;

			Unknown1 = new List<float>();
			sz = new Size(1, 1);
			LotElevation = 0x439D;

			Followup = new byte[0];
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return true;
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new LtxtUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Lot Description Wrapper",
				"Quaxi",
				"This File contains the Description for a Lot.",
				9,
				Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.ltxt.png")
				)
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			ver = reader.ReadUInt16();
			subver = reader.ReadUInt16();
			sz.Width = reader.ReadInt32();
			sz.Height = reader.ReadInt32();
			Type = (LotType)reader.ReadByte();

			LotRoads = reader.ReadByte();
			rotation = (Rotation)reader.ReadByte();
			Unknown0 = reader.ReadUInt32(); // Lot Flags, Use as Boolset

			LotName = StreamHelper.ReadString(reader);
			LotDesc = StreamHelper.ReadString(reader);

			Unknown1 = new List<float>();
			int len = reader.ReadInt32();
			for (int i = 0; i < len; i++)
			{
				Unknown1.Add(reader.ReadSingle());
			}

			if (subver >= (UInt16)LtxtSubVersion.Voyage)
			{
				Unknown3 = reader.ReadSingle();
			}
			else
			{
				Unknown3 = 0;
			}

			if (subver >= (UInt16)LtxtSubVersion.Freetime)
			{
				Unknown4 = reader.ReadUInt32();
			}
			else
			{
				Unknown4 = 0; // Lot Hobby Flags, Use as Boolset
			}

			if (
				ver >= (UInt16)LtxtVersion.Apartment
				|| subver >= (UInt16)LtxtSubVersion.Apartment
			)
			{
				unknown_5 = reader.ReadBytes(9);
				LotClass = reader.ReadUInt32();
				Clset = reader.ReadByte();
			}
			else
			{
				unknown_5 = new byte[0];
				LotClass = 0;
				Clset = 0;
			}

			int y = reader.ReadInt32();
			int x = reader.ReadInt32();
			loc = new Point(x, y);

			LotElevation = reader.ReadSingle();
			LotInstance = reader.ReadUInt32();
			Orientation = (LotOrientation)reader.ReadByte();

			Texture = StreamHelper.ReadString(reader);

			Unknown2 = reader.ReadByte();

			if (ver >= (int)LtxtVersion.Business)
			{
				OwnerInstance = reader.ReadUInt32();
			}
			else
			{
				OwnerInstance = 0;
			}

			if (
				ver >= (UInt16)LtxtVersion.Apartment
				|| subver >= (UInt16)LtxtSubVersion.Apartment
			)
			{
				int count;

				ApartmentBase = reader.ReadUInt32();
				unknown_6 = reader.ReadBytes(9);

				SubLots = new List<SubLot>();
				count = reader.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					SubLots.Add(new SubLot(reader));
				}

				Unknown7 = new List<uint>();
				count = reader.ReadInt32();
				for (int i = 0; i < count; i++)
				{
					Unknown7.Add(reader.ReadUInt32());
				}
			}
			else
			{
				ApartmentBase = 0;
				unknown_6 = new byte[0];
				SubLots = new List<SubLot>();
				Unknown7 = new List<uint>();
			}

			Followup = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);
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
			writer.Write(ver);
			writer.Write(subver);
			writer.Write(sz.Width);
			writer.Write(sz.Height);
			writer.Write((byte)Type);

			writer.Write((byte)LotRoads);
			writer.Write((byte)rotation);
			writer.Write(Unknown0);

			StreamHelper.WriteString(writer, LotName);
			StreamHelper.WriteString(writer, LotDesc);

			writer.Write(Unknown1.Count);
			foreach (int i in Unknown1)
			{
				writer.Write(i);
			}

			if (subver >= (UInt16)LtxtSubVersion.Voyage)
			{
				writer.Write(Unknown3);
			}

			if (subver >= (UInt16)LtxtSubVersion.Freetime)
			{
				writer.Write(Unknown4);
			}

			if (
				ver >= (UInt16)LtxtVersion.Apartment
				|| subver >= (UInt16)LtxtSubVersion.Apartment
			)
			{
				writer.Write(unknown_5);
				writer.Write(LotClass);
				writer.Write(Clset);
			}

			writer.Write((int)loc.Y);
			writer.Write((int)loc.X);

			writer.Write(LotElevation);
			writer.Write(LotInstance);
			writer.Write((byte)Orientation);

			StreamHelper.WriteString(writer, Texture);

			writer.Write(Unknown2);

			if (ver >= (int)LtxtVersion.Business)
			{
				writer.Write(OwnerInstance);
			}

			if (
				ver >= (UInt16)LtxtVersion.Apartment
				|| subver >= (UInt16)LtxtSubVersion.Apartment
			)
			{
				writer.Write(ApartmentBase);
				writer.Write(unknown_6);

				writer.Write(SubLots.Count);
				for (int i = 0; i < SubLots.Count; i++)
				{
					SubLots[i].Serialize(writer);
				}

				writer.Write(Unknown7.Count);
				for (int i = 0; i < Unknown7.Count; i++)
				{
					writer.Write(Unknown7[i]);
				}
			}

			writer.Write(Followup);
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		public const uint Ltxttype = 0x0BF999E7;

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[] { Ltxttype };

		#endregion

		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!Processed)
			{
				ProcessData(FileDescriptor, Package);
			}

			return LotName;
		}
	}
}
