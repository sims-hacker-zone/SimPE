// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Drawing;

using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Ltxt
{

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public partial class Ltxt : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{

		#region Attributes
		byte[] unknown_5; //if subver >= Apartment Life
		Point loc;
		byte[] unknown_6; //if subver >= Apartment Life (9 bytes)
		#endregion

		#region Properties
		public LtxtVersion Version
		{
			get; set;
		}
		public LtxtSubVersion SubVersion
		{
			get; set;
		}
		public Size LotSize { get; set; } = new Size(1, 1);
		public LotType Type
		{
			get; set;
		}
		public byte LotRoads { get; set; } = 0x00;
		public Rotation LotRotation
		{
			get; set;
		}
		public LotFlags LotFlags
		{
			get; set;
		}
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
		} = new List<float>();
		internal float Unknown3
		{
			get; set;
		}
		public LotHobbyFlags LotHobbyFlags
		{
			get; set;
		}
		internal byte[] Unknown5
		{
			get => unknown_5;
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
			get => loc;
			set => loc = value;
		}
		public float LotElevation
		{
			get; set;
		} = 0x439D;
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
			get => unknown_6;
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
		} = new byte[0];
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
		public Ltxt(Interfaces.IProviderRegistry provider) : base()
		{
			Provider = provider;
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
			Version = (LtxtVersion)reader.ReadUInt16();
			SubVersion = (LtxtSubVersion)reader.ReadUInt16();
			LotSize = new Size
			{
				Width = reader.ReadInt32(),
				Height = reader.ReadInt32()
			};
			Type = (LotType)reader.ReadByte();

			LotRoads = reader.ReadByte();
			LotRotation = (Rotation)reader.ReadByte();
			LotFlags = (LotFlags)reader.ReadUInt32();

			LotName = StreamHelper.ReadString(reader);
			LotDesc = StreamHelper.ReadString(reader);

			Unknown1 = new List<float>();
			int len = reader.ReadInt32();
			for (int i = 0; i < len; i++)
			{
				Unknown1.Add(reader.ReadSingle());
			}

			Unknown3 = SubVersion >= LtxtSubVersion.Voyage ? reader.ReadSingle() : 0;

			if (SubVersion >= LtxtSubVersion.Freetime)
			{
				LotHobbyFlags = (LotHobbyFlags)reader.ReadUInt32();
			}
			else
			{
				LotHobbyFlags = 0; // Lot Hobby Flags, Use as Boolset
			}

			if (
				Version >= LtxtVersion.Apartment
				|| SubVersion >= LtxtSubVersion.Apartment
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

			OwnerInstance = Version >= LtxtVersion.Business ? reader.ReadUInt32() : 0;

			if (
				Version >= LtxtVersion.Apartment
				|| SubVersion >= LtxtSubVersion.Apartment
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
			writer.Write((ushort)Version);
			writer.Write((ushort)SubVersion);
			writer.Write(LotSize.Width);
			writer.Write(LotSize.Height);
			writer.Write((byte)Type);

			writer.Write(LotRoads);
			writer.Write((byte)LotRotation);
			writer.Write((uint)LotFlags);

			StreamHelper.WriteString(writer, LotName);
			StreamHelper.WriteString(writer, LotDesc);

			writer.Write(Unknown1.Count);
			foreach (int i in Unknown1)
			{
				writer.Write(i);
			}

			if (SubVersion >= LtxtSubVersion.Voyage)
			{
				writer.Write(Unknown3);
			}

			if (SubVersion >= LtxtSubVersion.Freetime)
			{
				writer.Write((uint)LotHobbyFlags);
			}

			if (
				Version >= LtxtVersion.Apartment
				|| SubVersion >= LtxtSubVersion.Apartment
			)
			{
				writer.Write(unknown_5);
				writer.Write(LotClass);
				writer.Write(Clset);
			}

			writer.Write(loc.Y);
			writer.Write(loc.X);

			writer.Write(LotElevation);
			writer.Write(LotInstance);
			writer.Write((byte)Orientation);

			StreamHelper.WriteString(writer, Texture);

			writer.Write(Unknown2);

			if (Version >= LtxtVersion.Business)
			{
				writer.Write(OwnerInstance);
			}

			if (
				Version >= LtxtVersion.Apartment
				|| SubVersion >= LtxtSubVersion.Apartment
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
