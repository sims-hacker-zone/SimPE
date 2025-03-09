// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Objd
{
	public enum ShelveDimension : uint
	{
		Big = 0x0,
		Medium = 0x1,
		Small = 0x2,
		Unknown2 = 0x64,
		Unknown1 = 0x96,
		Multitile = 0xffff00fe,
		Indetermined = 0xffff00ff,
	}

	/// <summary>
	/// Represents a PackedFile in SDsc Format
	/// </summary>
	public class ExtObjd
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension,
			IMultiplePackedFileWrapper
	{
		#region Attributes
		/// <summary>
		///the stored Filename
		/// </summary>
		private byte[] filename = new byte[0x40];
		private byte[] filename2 = new byte[0];
		static ObjdPropertyParser tpp;
		#endregion

		#region Accessor methods
		/// <summary>
		/// Returns/Sets the Name of a Sim
		/// </summary>
		public string FileName
		{
			get => Helper.ToString(filename);
			set => filename = Helper.SetLength(Helper.ToBytes(value, 64), 64);
		}

		/// <summary>
		/// Returs / Sets the stored Data
		/// </summary>
		public short[] Data { get; set; } = new short[0xdc];

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint Guid
		{
			get; set;
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint ProxyGuid
		{
			get; set;
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint OriginalGuid
		{
			get; set;
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint DiagonalGuid
		{
			get; set;
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint GridAlignedGuid
		{
			get; set;
		}

		/// <summary>
		/// returns the dimension of an Object on the Shelve
		/// </summary>
		public ShelveDimension ShelveDimension
		{
			get
			{
				if (Data.Length > 0x004F)
				{
					short v = Data[0x004F];
					return v != 0x64 && v != 0x96 && v != 0 && v != 1 && v != 2 ? ShelveDimension.Indetermined : (ShelveDimension)v;
				}
				return 0;
			}
			set
			{
				if (Data.Length > 0x004F)
				{
					Data[0x004F] = (short)value;
				}
			}
		}

		/// <summary>
		/// returns the Instance of the assigned Catalog Description
		/// </summary>
		public ushort CTSSInstance
		{
			get => Data.Length > 0x29 ? (ushort)Data[0x29] : (ushort)0;
			set
			{
				if (Data.Length > 0x29)
				{
					Data[0x29] = (short)value;
				}
			}
		}

		/// <summary>
		/// Retursn / Sets the Type of an Object
		/// </summary>
		public ObjectTypes Type
		{
			get => Data.Length > 0x09 ? (ObjectTypes)Data[0x09] : ObjectTypes.Normal;
			set
			{
				if (Data.Length > 0x09)
				{
					Data[0x09] = (short)value;
				}
			}
		}

		/// <summary>
		/// Returns the Catalogue Use Flags
		/// </summary>
		public ObjCatalogueUse CatalogueUse { get; set; } = new ObjCatalogueUse(0);

		/// <summary>
		/// Returns the Room Sort Flags
		/// </summary>
		public ObjRoomSort RoomSort { get; set; } = new ObjRoomSort(0);

		public ComRoomSort CommSort { get; set; } = new ComRoomSort(0);

		/// <summary>
		/// Returns the Function Sort Flags
		/// </summary>
		public ObjFunctionSort FunctionSort { get; set; } = new ObjFunctionSort(0);

		/// <summary>
		/// Returns the Function Sort Flags
		/// </summary>
		public ObjBuildType BuildType { get; set; } = new ObjBuildType(0);

		/// <summary>
		/// Returns the Ep Required Flags1
		/// </summary>
		public Epsreq1 EpRequired1 { get; set; } = new Epsreq1(0);

		/// <summary>
		/// Returns the Ep Required Flags2
		/// </summary>
		public Epsreq2 EpRequired2 { get; set; } = new Epsreq2(0);

		public BuildFunctionSubSort BuildSubSort
		{
			get
			{
				uint val = (uint)(
					Data[0x4a] & 0xffff | (BuildType.Value & 0xfffff) << 16
				);
				return (BuildFunctionSubSort)val;
			}
			set
			{
				uint val = (uint)value;
				BuildType.Value = (ushort)(val >> 16 & 0xfffff);
				Data[0x4a] = (short)(val & 0xffff);
			}
		}

		public ObjFunctionSubSort FunctionSubSort
		{
			get
			{
				uint val = (uint)(Data[0x5e] & 0xff | (FunctionSort.Value & 0xfff) << 8);
				return (ObjFunctionSubSort)val;
			}
			set
			{
				uint val = (uint)value;
				FunctionSort.Value = (ushort)(val >> 8 & 0xfff);
				Data[0x5e] = (short)(val & 0xff);
			}
		}

		public void UpdateFlags()
		{
			CatalogueUse = new ObjCatalogueUse(Data[0x11]);
			if (Data.Length > 0x45)
			{
				RoomSort = new ObjRoomSort(Data[0x27]);
				FunctionSort = new ObjFunctionSort(Data[0x28]);
				BuildType = new ObjBuildType(Data[0x45]);
				EpRequired1 = new Epsreq1(Data[0x40]);
				EpRequired2 = new Epsreq2(Data[0x41]);
			}
			if (Data.Length > 0x64)
			{
				CommSort = new ComRoomSort(Data[0x64]);
			}
		}

		public short Price
		{
			get => Data[0x12];
			set => Data[0x12] = value;
		}

		public short Version => Data[0x00];

		/// <summary>
		/// Returns the Length of the File
		/// </summary>
		protected int Length => Data.Length * 2 + 0x40;

		public ObjdHealth Ok
		{
			get; private set;
		}

		/// <summary>
		/// Return a PropertyParser, that enumerates all known Properties as <see cref="Ambertation.PropertyDescription"/> Objects
		/// </summary>
		public static ObjdPropertyParser PropertyParser
		{
			get
			{
				if (tpp == null)
				{
					tpp = new ObjdPropertyParser(
						System.IO.Path.Combine(
							Helper.SimPeDataPath,
							"objddefinition.xml"
						)
					);
				}

				return tpp;
			}
		}

		internal uint createguid =>
				// TODO
				//string gooee = "";
				//uint gid;
				//SimPe.Interfaces.Files.IPackedFileDescriptor[] nrfile = package.FindFiles(FileTypes.NREF);
				//foreach (Interfaces.Files.IPackedFileDescriptor pfd in nrfile)
				//{
				//    if (pfd.Group == this.FileDescriptor.Group)
				//    {
				//        SimPe.PackedFiles.Wrapper.Nref nref = new SimPe.PackedFiles.Wrapper.Nref();
				//        nref.ProcessData(pfd, package);
				//        gooee = nref.FileName + Helper.WindowsRegistry.CachedUserId.ToString() + Convert.ToString(this.FileDescriptor.Instance);
				//        gid = Hashes.GetCrc32(gooee);
				//        while (SimPe.Plugin.Subhoods.GuidExists(gid))
				//        {
				//            gooee += "0";
				//            gid = Hashes.GetCrc32(gooee);
				//        }
				//        return gid;
				//    }
				//}
				0;

		#endregion

		/// <summary>
		/// Deprecated constructor, use zero-arg version
		/// </summary>
		/// <param name="o">Must be null</param>
		[Obsolete("Use zero-argument constructor", false)]
		public ExtObjd(object o)
			: this()
		{
			if (o != null)
			{
				throw new ArgumentException();
			}
		}

		public ExtObjd()
			: base()
		{
			Type = ObjectTypes.Normal;
		}

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new ExtObjdForm();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Extended OBJD Wrapper",
				"Quaxi, Peter L Jones",
				"This file is used to set up the basic catalogue properties of an Object. "
					+ "It also contains the unique ID for the Object (or part of the Object).",
				7,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.objd.png")
				)
			);
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			const int MAX_VALUES = 0x6c;
			Data[0x11] = (short)CatalogueUse.Value;
			if (Data.Length > 0x27)
			{
				Data[0x27] = (short)RoomSort.Value;
				Data[0x28] = (short)FunctionSort.Value;
			}
			if (Data.Length > 0x41)
			{
				Data[0x40] = (short)EpRequired1.Value;
				Data[0x41] = (short)EpRequired2.Value;
			}
			if (Data.Length > 0x64)
			{
				Data[0x64] = (short)CommSort.Value;
			}

			writer.Write(filename);
			int ct = 0;
			foreach (short s in Data)
			{
				writer.Write(s);
				ct++;
				if (ct >= MAX_VALUES)
				{
					break;
				}
			}

			while (ct < MAX_VALUES)
			{
				writer.Write((short)0);
			}

			string flname = FileName;
			byte[] name = Helper.ToBytes(flname, 0);
			writer.Write((uint)name.Length);
			writer.Write(name);

			//write some special Fields
			if (Length > 0x5c + 4)
			{
				writer.BaseStream.Seek(0x5c, System.IO.SeekOrigin.Begin);
				writer.Write(Guid);
			}

			if (Length > 0x6A + 8)
			{
				writer.BaseStream.Seek(0x6A, System.IO.SeekOrigin.Begin);
				writer.Write(DiagonalGuid);
				writer.Write(GridAlignedGuid);
			}

			if (Length > 0x7a + 4)
			{
				writer.BaseStream.Seek(0x7a, System.IO.SeekOrigin.Begin);
				writer.Write(ProxyGuid);
			}

			if (Length > 0xcc + 4)
			{
				writer.BaseStream.Seek(0xcc, System.IO.SeekOrigin.Begin);
				writer.Write(OriginalGuid);
			}
			//if (free>0) writer.Write(new byte[free]);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Ok = ObjdHealth.Ok;
			try
			{
				UnserializeNew(reader);
			}
			catch
			{
				Ok = ObjdHealth.Unreadable;
				reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
				UnserializeOld(reader);
			}

			//read some special Data
			if (Length > 0x5c + 4)
			{
				reader.BaseStream.Seek(0x5c, System.IO.SeekOrigin.Begin);
				Guid = reader.ReadUInt32();
			}

			if (Length > 0x6A + 8)
			{
				reader.BaseStream.Seek(0x6A, System.IO.SeekOrigin.Begin);
				DiagonalGuid = reader.ReadUInt32();
				GridAlignedGuid = reader.ReadUInt32();
			}

			if (Length > 0x7a + 4)
			{
				reader.BaseStream.Seek(0x7a, System.IO.SeekOrigin.Begin);
				ProxyGuid = reader.ReadUInt32();
			}

			if (Length > 0xcc + 4)
			{
				reader.BaseStream.Seek(0xcc, System.IO.SeekOrigin.Begin);
				OriginalGuid = reader.ReadUInt32();
			}

			UpdateFlags();
		}

		protected void UnserializeNew(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(0x40);
			int count = (int)((reader.BaseStream.Length - 0x40) / 2);
			count = 0x6c;
			Data = new short[count];
			for (int i = 0; i < count; i++)
			{
				Data[i] = reader.ReadInt16();
			}

			int sz = reader.ReadInt32();
			filename2 = reader.ReadBytes(sz);

			if (Helper.ToString(filename2) != FileName)
			{
				Ok = ObjdHealth.FilenameMismatch;
			}

			if (reader.BaseStream.Position != reader.BaseStream.Length)
			{
				Ok = ObjdHealth.OverLength;
			}
		}

		protected void UnserializeOld(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(0x40);
			int count = (int)((reader.BaseStream.Length - 0x40) / 2);
			Data = new short[count];
			for (int i = 0; i < count; i++)
			{
				try
				{
					Data[i] = reader.ReadInt16();
				}
				catch (System.IO.EndOfStreamException ex)
				{
					throw new System.IO.EndOfStreamException(
						"Reading Error in OBJd at " + i.ToString() + ".",
						ex
					);
				}
			}
		}

		#endregion

		#region IFileWrapper Member
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.OBJD };

		public byte[] FileSignature => new byte[] { };

		public override string Description => "FileName="
					+ FileName
					+ ",GUID=0x"
					+ Helper.HexString(Guid)
					+ ",Type="
					+ Type.ToString();

		#endregion

		#region IMultiplePackedFileWrapper Member

		public override object[] GetConstructorArguments()
		{
			return new object[0];
		}

		#endregion
	}

	#region ObjdHealth
	/// <summary>
	/// This is used to determine the Health of a OBJd File
	/// </summary>
	public enum ObjdHealth : byte
	{
		Ok,
		Unreadable,
		FilenameMismatch,
		OverLength,
	}

	#endregion

	#region Catalogue Use
	public class ObjCatalogueUse : FlagBase
	{
		public ObjCatalogueUse(short flags)
			: base((ushort)flags) { }

		public ObjCatalogueUse(object o)
			: base(o) { }

		public bool AdultsOnly
		{
			get => GetBit((byte)ObjCatalogueUseBits.Adults);
			set => SetBit((byte)ObjCatalogueUseBits.Adults, value);
		}

		public bool ChildrenOnly
		{
			get => GetBit((byte)ObjCatalogueUseBits.Children);
			set => SetBit((byte)ObjCatalogueUseBits.Children, value);
		}

		public bool GroupActivity
		{
			get => GetBit((byte)ObjCatalogueUseBits.Group);
			set => SetBit((byte)ObjCatalogueUseBits.Group, value);
		}

		public bool TeensOnly
		{
			get => GetBit((byte)ObjCatalogueUseBits.Teens);
			set => SetBit((byte)ObjCatalogueUseBits.Teens, value);
		}

		public bool EldersOnly
		{
			get => GetBit((byte)ObjCatalogueUseBits.Elders);
			set => SetBit((byte)ObjCatalogueUseBits.Elders, value);
		}

		public bool ToddlersOnly
		{
			get => GetBit((byte)ObjCatalogueUseBits.Toddlers);
			set => SetBit((byte)ObjCatalogueUseBits.Toddlers, value);
		}
	}
	#endregion

	#region Room Sort
	public class ObjRoomSort : FlagBase
	{
		public ObjRoomSort(short flags)
			: base((ushort)flags) { }

		public ObjRoomSort(object o)
			: base(o) { }

		public bool InBathroom
		{
			get => GetBit((byte)ObjRoomSortBits.Bathroom);
			set => SetBit((byte)ObjRoomSortBits.Bathroom, value);
		}

		public bool InBedroom
		{
			get => GetBit((byte)ObjRoomSortBits.Bedroom);
			set => SetBit((byte)ObjRoomSortBits.Bedroom, value);
		}

		public bool InDiningRoom
		{
			get => GetBit((byte)ObjRoomSortBits.DiningRoom);
			set => SetBit((byte)ObjRoomSortBits.DiningRoom, value);
		}

		public bool InKitchen
		{
			get => GetBit((byte)ObjRoomSortBits.Kitchen);
			set => SetBit((byte)ObjRoomSortBits.Kitchen, value);
		}

		public bool InLivingRoom
		{
			get => GetBit((byte)ObjRoomSortBits.LivingRoom);
			set => SetBit((byte)ObjRoomSortBits.LivingRoom, value);
		}

		public bool InMisc
		{
			get => GetBit((byte)ObjRoomSortBits.Misc);
			set => SetBit((byte)ObjRoomSortBits.Misc, value);
		}

		public bool InOutside
		{
			get => GetBit((byte)ObjRoomSortBits.Outside);
			set => SetBit((byte)ObjRoomSortBits.Outside, value);
		}

		public bool InStudy
		{
			get => GetBit((byte)ObjRoomSortBits.Study);
			set => SetBit((byte)ObjRoomSortBits.Study, value);
		}

		public bool InKids
		{
			get => GetBit((byte)ObjRoomSortBits.Kids);
			set => SetBit((byte)ObjRoomSortBits.Kids, value);
		}
	}
	#endregion

	#region Comm Room Sort
	public class ComRoomSort : FlagBase
	{
		public ComRoomSort(short flags)
			: base((ushort)flags) { }

		public ComRoomSort(object o)
			: base(o) { }

		public bool InDining
		{
			get => GetBit((byte)CommRoomSortBits.Dining);
			set => SetBit((byte)CommRoomSortBits.Dining, value);
		}

		public bool InShopping
		{
			get => GetBit((byte)CommRoomSortBits.Shopping);
			set => SetBit((byte)CommRoomSortBits.Shopping, value);
		}

		public bool InOutdoors
		{
			get => GetBit((byte)CommRoomSortBits.Outdoor);
			set => SetBit((byte)CommRoomSortBits.Outdoor, value);
		}

		public bool InStreet
		{
			get => GetBit((byte)CommRoomSortBits.Street);
			set => SetBit((byte)CommRoomSortBits.Street, value);
		}

		public bool InMiscel
		{
			get => GetBit((byte)CommRoomSortBits.Misc);
			set => SetBit((byte)CommRoomSortBits.Misc, value);
		}
	}
	#endregion

	#region Function Sort
	public class ObjFunctionSort : FlagBase
	{
		public ObjFunctionSort(short flags)
			: base((ushort)flags) { }

		public ObjFunctionSort(object o)
			: base(o) { }

		public bool InAppliances
		{
			get => GetBit((byte)ObjFunctionSortBits.Appliances);
			set => SetBit((byte)ObjFunctionSortBits.Appliances, value);
		}

		public bool InDecorative
		{
			get => GetBit((byte)ObjFunctionSortBits.Decorative);
			set => SetBit((byte)ObjFunctionSortBits.Decorative, value);
		}

		public bool InElectronics
		{
			get => GetBit((byte)ObjFunctionSortBits.Electronics);
			set => SetBit((byte)ObjFunctionSortBits.Electronics, value);
		}

		public bool InGeneral
		{
			get => GetBit((byte)ObjFunctionSortBits.General);
			set => SetBit((byte)ObjFunctionSortBits.General, value);
		}

		public bool InLighting
		{
			get => GetBit((byte)ObjFunctionSortBits.Lighting);
			set => SetBit((byte)ObjFunctionSortBits.Lighting, value);
		}

		public bool InPlumbing
		{
			get => GetBit((byte)ObjFunctionSortBits.Plumbing);
			set => SetBit((byte)ObjFunctionSortBits.Plumbing, value);
		}

		public bool InSeating
		{
			get => GetBit((byte)ObjFunctionSortBits.Seating);
			set => SetBit((byte)ObjFunctionSortBits.Seating, value);
		}

		public bool InSurfaces
		{
			get => GetBit((byte)ObjFunctionSortBits.Surfaces);
			set => SetBit((byte)ObjFunctionSortBits.Surfaces, value);
		}

		public bool InHobbies
		{
			get => GetBit((byte)ObjFunctionSortBits.Hobbies);
			set => SetBit((byte)ObjFunctionSortBits.Hobbies, value);
		}

		public bool InAspirationRewards
		{
			get => GetBit((byte)ObjFunctionSortBits.AspirationRewards);
			set => SetBit((byte)ObjFunctionSortBits.AspirationRewards, value);
		}

		public bool InCareerRewards
		{
			get => GetBit((byte)ObjFunctionSortBits.CareerRewards);
			set => SetBit((byte)ObjFunctionSortBits.CareerRewards, value);
		}
	}
	#endregion

	#region Build mode type
	public class ObjBuildType : FlagBase
	{
		public ObjBuildType(short flags)
			: base((ushort)flags) { }

		public ObjBuildType(object o)
			: base(o) { }

		public bool InGeneral
		{
			get => GetBit((byte)ObjBuildTypeBits.General);
			set => SetBit((byte)ObjBuildTypeBits.General, value);
		}

		public bool InUnknown
		{
			get => GetBit((byte)ObjBuildTypeBits.unknown);
			set => SetBit((byte)ObjBuildTypeBits.unknown, value);
		}

		public bool InGarden
		{
			get => GetBit((byte)ObjBuildTypeBits.Garden);
			set => SetBit((byte)ObjBuildTypeBits.Garden, value);
		}

		public bool InOpenings
		{
			get => GetBit((byte)ObjBuildTypeBits.Openings);
			set => SetBit((byte)ObjBuildTypeBits.Openings, value);
		}
	}
	#endregion

	#region EP Flags 1
	public class Epsreq1 : FlagBase
	{
		public Epsreq1(short flags)
			: base((ushort)flags) { }

		public Epsreq1(object o)
			: base(o) { }

		public bool Basegame
		{
			get => GetBit((byte)NeighborhoodEP.BaseGame);
			set => SetBit((byte)NeighborhoodEP.BaseGame, value);
		}

		public bool University
		{
			get => GetBit((byte)NeighborhoodEP.University);
			set => SetBit((byte)NeighborhoodEP.University, value);
		}

		public bool Nightlife
		{
			get => GetBit((byte)NeighborhoodEP.Nightlife);
			set => SetBit((byte)NeighborhoodEP.Nightlife, value);
		}

		public bool Business
		{
			get => GetBit((byte)NeighborhoodEP.Business);
			set => SetBit((byte)NeighborhoodEP.Business, value);
		}

		public bool FamilyFun
		{
			get => GetBit((byte)NeighborhoodEP.FamilyFun);
			set => SetBit((byte)NeighborhoodEP.FamilyFun, value);
		}

		public bool GlamourLife
		{
			get => GetBit((byte)NeighborhoodEP.GlamourLife);
			set => SetBit((byte)NeighborhoodEP.GlamourLife, value);
		}

		public bool Pets
		{
			get => GetBit((byte)NeighborhoodEP.Pets);
			set => SetBit((byte)NeighborhoodEP.Pets, value);
		}

		public bool Seasons
		{
			get => GetBit((byte)NeighborhoodEP.Seasons);
			set => SetBit((byte)NeighborhoodEP.Seasons, value);
		}

		public bool Celebration
		{
			get => GetBit((byte)NeighborhoodEP.Celebration);
			set => SetBit((byte)NeighborhoodEP.Celebration, value);
		}

		public bool Fashion
		{
			get => GetBit((byte)NeighborhoodEP.Fashion);
			set => SetBit((byte)NeighborhoodEP.Fashion, value);
		}

		public bool BonVoyage
		{
			get => GetBit((byte)NeighborhoodEP.BonVoyage);
			set => SetBit((byte)NeighborhoodEP.BonVoyage, value);
		}

		public bool TeenStyle
		{
			get => GetBit((byte)NeighborhoodEP.TeenStyle);
			set => SetBit((byte)NeighborhoodEP.TeenStyle, value);
		}

		public bool StoreEdition_old
		{
			get => GetBit((byte)NeighborhoodEP.StoreEdition_old);
			set => SetBit((byte)NeighborhoodEP.StoreEdition_old, value);
		}

		public bool Freetime
		{
			get => GetBit((byte)NeighborhoodEP.Freetime);
			set => SetBit((byte)NeighborhoodEP.Freetime, value);
		}

		public bool KitchenBath
		{
			get => GetBit((byte)NeighborhoodEP.KitchenBath);
			set => SetBit((byte)NeighborhoodEP.KitchenBath, value);
		}

		public bool IkeaHome
		{
			get => GetBit((byte)NeighborhoodEP.IkeaHome);
			set => SetBit((byte)NeighborhoodEP.IkeaHome, value);
		}
	}
	#endregion

	#region EP Flags 2
	public class Epsreq2 : FlagBase
	{
		public Epsreq2(short flags)
			: base((ushort)flags) { }

		public Epsreq2(object o)
			: base(o) { }

		public bool ApartmentLife
		{
			get => GetBit(0);
			set => SetBit(0, value);
		}

		public bool MansionGarden
		{
			get => GetBit(1);
			set => SetBit(1, value);
		}

		public bool StoreEdition
		{
			get => GetBit(0xf);
			set => SetBit(0xf, value);
		}
	}
	#endregion
}
