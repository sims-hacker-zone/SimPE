/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
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
using System.Collections;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	public enum ShelveDimension : uint
	{
		Big = 0x0,
		Medium = 0x1,
		Small = 0x2,
		Unknown2 = 0x64,
		Unknown1 = 0x96,
		Multitile = 0xffff00fe,
		Indetermined = 0xffff00ff
	}
	/// <summary>
	/// Represents a PackedFile in SDsc Format
	/// </summary>
	public class ExtObjd : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension, IMultiplePackedFileWrapper
	{
		#region Attributes
		/// <summary>
		///the stored Filename
		/// </summary>
        private byte[] filename = new byte[0x40];
		private byte[] filename2 = new byte[0];

		/// <summary>
		/// The Type of this File
		/// </summary>
		private short[] data = new short[0xdc];

        uint guid, proxyguid, originalguid, diagonalguid, gridalignguid;

		ObjRoomSort rsort = new ObjRoomSort(0);
        ObjFunctionSort fsort = new ObjFunctionSort(0);
        ObjBuildType btype = new ObjBuildType(0);
        ObjCatalogueUse usort = new ObjCatalogueUse(0);
        ComRoomSort csort = new ComRoomSort(0);
        Epsreq1 epone = new Epsreq1(0);
        Epsreq2 eptwo = new Epsreq2(0);


		ObjdHealth ok;
		static SimPe.PackedFiles.Wrapper.ObjdPropertyParser tpp;
		#endregion

		#region Accessor methods
		/// <summary>
		/// Returns/Sets the Name of a Sim
		/// </summary>
		public string FileName
		{
			get
			{
				return Helper.ToString(filename);
			}
			set
			{
				filename = Helper.SetLength(Helper.ToBytes(value, 64), 64);
			}
		}

		/// <summary>
		/// Returs / Sets the stored Data
		/// </summary>
		public short[] Data
		{
			get { return data; }
			set { data = value; }
		}


		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint Guid
		{
			get { return guid; }
			set { guid = value; }
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint ProxyGuid
		{
			get { return proxyguid; }
			set { proxyguid = value; }
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint OriginalGuid
		{
			get { return originalguid; }
			set { originalguid = value; }
		}

        /// <summary>
        /// Returns the GUID of the Object
        /// </summary>
        public uint DiagonalGuid
        {
            get { return diagonalguid; }
            set { diagonalguid = value; }
        }

        /// <summary>
        /// Returns the GUID of the Object
        /// </summary>
        public uint GridAlignedGuid
        {
            get { return gridalignguid; }
            set { gridalignguid = value; }
        }


		/// <summary>
		/// returns the dimension of an Object on the Shelve
		/// </summary>
		public ShelveDimension ShelveDimension
		{
			get
			{
				if (data.Length>0x004F)
				{

					short v = data[0x004F];
					if (v!= 0x64 && v!=0x96 && v!=0 && v!=1 && v!=2) return ShelveDimension.Indetermined;
					return (ShelveDimension)v;
				}
				return 0;
			}
			set
			{
				if (data.Length>0x004F) data[0x004F] = (short)value;
			}
		}

		/// <summary>
		/// returns the Instance of the assigned Catalog Description
		/// </summary>
		public ushort CTSSInstance
		{
			get
			{
				if (data.Length>0x29) return (ushort)data[0x29];
				return 0;
			}
			set
			{
				if (data.Length>0x29) data[0x29] = (short)value;
			}
		}

		/// <summary>
		/// Retursn / Sets the Type of an Object
		/// </summary>
		public SimPe.Data.ObjectTypes Type
		{
			get {
				if (data.Length>0x09) return (SimPe.Data.ObjectTypes)data[0x09];
				return SimPe.Data.ObjectTypes.Normal;
			}
			set {
				if (data.Length>0x09) data[0x09] = (short)value;
			}
        }

        /// <summary>
        /// Returns the Catalogue Use Flags
        /// </summary>
        public ObjCatalogueUse CatalogueUse
        {
            get { return usort; }
            set { usort = value; }
        }

		/// <summary>
		/// Returns the Room Sort Flags
		/// </summary>
		public ObjRoomSort RoomSort
		{
			get { return rsort; }
			set { rsort = value; }
		}

        public ComRoomSort CommSort
        {
            get { return csort; }
            set { csort = value; }
        }

		/// <summary>
		/// Returns the Function Sort Flags
		/// </summary>
		public ObjFunctionSort FunctionSort
		{
			get { return fsort; }
			set { fsort = value; }
        }

        /// <summary>
        /// Returns the Function Sort Flags
        /// </summary>
        public ObjBuildType BuildType
        {
            get { return btype; }
            set { btype = value; }
        }        

        /// <summary>
        /// Returns the Ep Required Flags1
        /// </summary>
        public Epsreq1 EpRequired1
        {
            get { return epone; }
            set { epone = value; }
        }
        /// <summary>
        /// Returns the Ep Required Flags2
        /// </summary>
        public Epsreq2 EpRequired2
        {
            get { return eptwo; }
            set { eptwo = value; }
        }

        public Data.BuildFunctionSubSort BuildSubSort
        {
            get
            {
                uint val = (uint)((data[0x4a] & 0xffff) | ((btype.Value & 0xfffff) << 16));
                return (Data.BuildFunctionSubSort)val;
            }
            set
            {
                uint val = (uint)value;
                btype.Value = (ushort)((val >> 16) & 0xfffff);
                data[0x4a] = (short)(val & 0xffff);
            }
        }

		public Data.ObjFunctionSubSort FunctionSubSort
		{
			get
			{
				uint val = (uint)((data[0x5e]&0xff) | ((fsort.Value&0xfff)<<8));
				return (Data.ObjFunctionSubSort)val;
			}
			set
			{
				uint val = (uint)value;
				fsort.Value = (ushort)((val >> 8) & 0xfff);
				data[0x5e] = (short)(val & 0xff);
			}
		}

		public void UpdateFlags()
		{
            this.usort = new ObjCatalogueUse(data[0x11]);
			if (data.Length>0x45)
			{
				this.rsort = new ObjRoomSort(data[0x27]);
                this.fsort = new ObjFunctionSort(data[0x28]);
                this.btype = new ObjBuildType(data[0x45]);
                this.epone = new Epsreq1(data[0x40]);
                this.eptwo = new Epsreq2(data[0x41]);
			}
            if (data.Length > 0x64)
                this.csort = new ComRoomSort(data[0x64]);
		}

		public short Price
		{
			get {return data[0x12];}
			set {data[0x12] = value; }
        }

        public short Version
        {
            get { return data[0x00]; }
        }

		/// <summary>
		/// Returns the Length of the File
		/// </summary>
		protected int Length
		{
			get { return (int)(data.Length*2 + 0x40); }
		}

		public ObjdHealth Ok
		{
			get {return ok; }
		}


		/// <summary>
		/// Return a PropertyParser, that enumerates all known Properties as <see cref="Ambertation.PropertyDescription"/> Objects
		/// </summary>
		public static SimPe.PackedFiles.Wrapper.ObjdPropertyParser PropertyParser
		{
			get
			{
				if (tpp==null)
					tpp = new SimPe.PackedFiles.Wrapper.ObjdPropertyParser(System.IO.Path.Combine(Helper.SimPeDataPath, "objddefinition.xml"));
				return tpp;
			}
		}

        internal uint createguid
        {
            get
            {
                // TODO
                //string gooee = "";
                //uint gid;
                //SimPe.Interfaces.Files.IPackedFileDescriptor[] nrfile = package.FindFiles(0x4E524546);
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
                return 0;
            }
        }

		#endregion

        /// <summary>
        /// Deprecated constructor, use zero-arg version
        /// </summary>
        /// <param name="o">Must be null</param>
        [Obsolete("Use zero-argument constructor", false)]
        public ExtObjd(object o) : this() { if (o != null) { throw new ArgumentException(); } }

        public ExtObjd() : base()
		{
			Type = SimPe.Data.ObjectTypes.Normal;
		}


		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new SimPe.PackedFiles.UserInterface.ExtObjdForm();
		}

		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Extended OBJD Wrapper",
				"Quaxi, Peter L Jones",
				"This file is used to set up the basic catalogue properties of an Object. " +
					"It also contains the unique ID for the Object (or part of the Object).",
				7,
				System.Drawing.Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("SimPe.PackedFiles.Handlers.objd.png"))
				);
		}
		protected override void Serialize(System.IO.BinaryWriter writer)
		{
            const int MAX_VALUES = 0x6c;
            data[0x11] = (short)this.usort.Value;
			if (data.Length>0x27)
			{
				data[0x27] = (short)this.rsort.Value;
				data[0x28] = (short)this.fsort.Value;
            }
            if (data.Length > 0x41)
            {
                data[0x40] = (short)this.epone.Value;
                data[0x41] = (short)this.eptwo.Value;
            }
            if (data.Length > 0x64)
                data[0x64] = (short)this.csort.Value;

			writer.Write(filename);
			int ct =0;
			foreach (short s in data)
			{
				writer.Write(s);
				ct++;
				if (ct>=MAX_VALUES) break;
			}

			while (ct<MAX_VALUES) writer.Write((short)0);

			string flname = this.FileName;
			byte[] name = Helper.ToBytes(flname, 0);
			writer.Write((uint)name.Length);
			writer.Write(name);

			//write some special Fields
			if (Length>0x5c+4)
			{
				writer.BaseStream.Seek(0x5c, System.IO.SeekOrigin.Begin);
				writer.Write(guid);
            }

            if (Length > 0x6A + 8)
            {
                writer.BaseStream.Seek(0x6A, System.IO.SeekOrigin.Begin);
                writer.Write(diagonalguid);
                writer.Write(gridalignguid);
            }

			if (Length>0x7a+4)
			{
				writer.BaseStream.Seek(0x7a, System.IO.SeekOrigin.Begin);
				writer.Write(proxyguid);
			}

			if (Length>0xcc+4)
			{
				writer.BaseStream.Seek(0xcc, System.IO.SeekOrigin.Begin);
				writer.Write(originalguid);
			}
			//if (free>0) writer.Write(new byte[free]);
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
            ok = ObjdHealth.Ok;
			try
			{
				UnserializeNew(reader);
			}
			catch {
				ok = ObjdHealth.Unreadable;
				reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
				UnserializeOld(reader);
			}

			//read some special Data
			if (Length>0x5c+4)
			{
				reader.BaseStream.Seek(0x5c, System.IO.SeekOrigin.Begin);
				guid = reader.ReadUInt32();
			}

            if (Length > 0x6A + 8)
            {
                reader.BaseStream.Seek(0x6A, System.IO.SeekOrigin.Begin);
                diagonalguid = reader.ReadUInt32();
                gridalignguid = reader.ReadUInt32();
            }

			if (Length>0x7a+4)
			{
				reader.BaseStream.Seek(0x7a, System.IO.SeekOrigin.Begin);
				proxyguid = reader.ReadUInt32();
			}

			if (Length>0xcc+4)
			{
				reader.BaseStream.Seek(0xcc, System.IO.SeekOrigin.Begin);
				originalguid = reader.ReadUInt32();
			}


			UpdateFlags();
		}

		protected void UnserializeNew(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(0x40);
			int count = (int)((reader.BaseStream.Length - 0x40) / 2);
			count = 0x6c;
			data = new short[count];
			for (int i=0; i<count; i++) data[i] = reader.ReadInt16();

			int sz = reader.ReadInt32();
			filename2 = reader.ReadBytes(sz);

			if (Helper.ToString(filename2) != this.FileName)
                ok = ObjdHealth.FilenameMismatch;

			if (reader.BaseStream.Position != reader.BaseStream.Length)
				ok = ObjdHealth.OverLength;
		}

		protected void UnserializeOld(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(0x40);
			int count = (int)((reader.BaseStream.Length - 0x40) / 2);
			data = new short[count];
			for (int i=0; i<count; i++)
			{
				try
				{
					data[i] = reader.ReadInt16();
				}
				catch (System.IO.EndOfStreamException ex)
				{
					throw new System.IO.EndOfStreamException("Reading Error in OBJd at "+i.ToString()+".", ex);
				}
			}
		}

		#endregion

		#region IFileWrapper Member
		public uint[] AssignableTypes
		{
			get
			{
				uint[] Types = {
								   0x4F424A44
							   };
				return Types;
			}
		}

		public Byte[] FileSignature
		{
			get
			{
				Byte[] sig = {
							 };
				return sig;
			}
		}

		public override string Description
		{
			get
			{
				return "FileName="+this.FileName+",GUID=0x"+Helper.HexString(this.Guid)+",Type="+this.Type.ToString();
			}
		}

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
		OverLength
	}

    #endregion

    #region Catalogue Use
    public class ObjCatalogueUse : FlagBase
    {
        public ObjCatalogueUse(short flags) : base((ushort)flags) { }
        public ObjCatalogueUse(object o) : base(o) { }

        public bool AdultsOnly
        {
            get { return GetBit((byte)Data.ObjCatalogueUseBits.Adults); }
            set { SetBit((byte)Data.ObjCatalogueUseBits.Adults, value); }
        }

        public bool ChildrenOnly
        {
            get { return GetBit((byte)Data.ObjCatalogueUseBits.Children); }
            set { SetBit((byte)Data.ObjCatalogueUseBits.Children, value); }
        }

        public bool GroupActivity
        {
            get { return GetBit((byte)Data.ObjCatalogueUseBits.Group); }
            set { SetBit((byte)Data.ObjCatalogueUseBits.Group, value); }
        }

        public bool TeensOnly
        {
            get { return GetBit((byte)Data.ObjCatalogueUseBits.Teens); }
            set { SetBit((byte)Data.ObjCatalogueUseBits.Teens, value); }
        }

        public bool EldersOnly
        {
            get { return GetBit((byte)Data.ObjCatalogueUseBits.Elders); }
            set { SetBit((byte)Data.ObjCatalogueUseBits.Elders, value); }
        }

        public bool ToddlersOnly
        {
            get { return GetBit((byte)Data.ObjCatalogueUseBits.Toddlers); }
            set { SetBit((byte)Data.ObjCatalogueUseBits.Toddlers, value); }
        }
    }
    #endregion

	#region Room Sort
	public class ObjRoomSort : FlagBase
	{
		public ObjRoomSort(short flags) : base((ushort)flags) {}
		public ObjRoomSort(object o) : base(o) {}

		public bool InBathroom
		{
			get { return GetBit((byte)Data.ObjRoomSortBits.Bathroom); }
			set { SetBit((byte)Data.ObjRoomSortBits.Bathroom, value); }
		}

		public bool InBedroom
		{
			get { return GetBit((byte)Data.ObjRoomSortBits.Bedroom); }
			set { SetBit((byte)Data.ObjRoomSortBits.Bedroom, value); }
		}

		public bool InDiningRoom
		{
			get { return GetBit((byte)Data.ObjRoomSortBits.DiningRoom); }
			set { SetBit((byte)Data.ObjRoomSortBits.DiningRoom, value); }
		}

		public bool InKitchen
		{
			get { return GetBit((byte)Data.ObjRoomSortBits.Kitchen); }
			set { SetBit((byte)Data.ObjRoomSortBits.Kitchen, value); }
		}

		public bool InLivingRoom
		{
			get { return GetBit((byte)Data.ObjRoomSortBits.LivingRoom); }
			set { SetBit((byte)Data.ObjRoomSortBits.LivingRoom, value); }
		}

		public bool InMisc
		{
			get { return GetBit((byte)Data.ObjRoomSortBits.Misc); }
			set { SetBit((byte)Data.ObjRoomSortBits.Misc, value); }
		}

		public bool InOutside
		{
			get { return GetBit((byte)Data.ObjRoomSortBits.Outside); }
			set { SetBit((byte)Data.ObjRoomSortBits.Outside, value); }
		}

		public bool InStudy
		{
			get { return GetBit((byte)Data.ObjRoomSortBits.Study); }
			set { SetBit((byte)Data.ObjRoomSortBits.Study, value); }
		}

		public bool InKids
		{
			get { return GetBit((byte)Data.ObjRoomSortBits.Kids); }
			set { SetBit((byte)Data.ObjRoomSortBits.Kids, value); }
		}
	}
    #endregion

    #region Comm Room Sort
    public class ComRoomSort : FlagBase
    {
        public ComRoomSort(short flags) : base((ushort)flags) { }
        public ComRoomSort(object o) : base(o) { }

        public bool InDining
        {
            get { return GetBit((byte)Data.CommRoomSortBits.Dining); }
            set { SetBit((byte)Data.CommRoomSortBits.Dining, value); }
        }

        public bool InShopping
        {
            get { return GetBit((byte)Data.CommRoomSortBits.Shopping); }
            set { SetBit((byte)Data.CommRoomSortBits.Shopping, value); }
        }

        public bool InOutdoors
        {
            get { return GetBit((byte)Data.CommRoomSortBits.Outdoor); }
            set { SetBit((byte)Data.CommRoomSortBits.Outdoor, value); }
        }

        public bool InStreet
        {
            get { return GetBit((byte)Data.CommRoomSortBits.Street); }
            set { SetBit((byte)Data.CommRoomSortBits.Street, value); }
        }

        public bool InMiscel
        {
            get { return GetBit((byte)Data.CommRoomSortBits.Misc); }
            set { SetBit((byte)Data.CommRoomSortBits.Misc, value); }
        }
    }
    #endregion

	#region Function Sort
	public class ObjFunctionSort : FlagBase
	{
		public ObjFunctionSort(short flags) : base((ushort)flags) {}
		public ObjFunctionSort(object o) : base(o) {}

		public bool InAppliances
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.Appliances); }
			set { SetBit((byte)Data.ObjFunctionSortBits.Appliances, value); }
		}

		public bool InDecorative
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.Decorative); }
			set { SetBit((byte)Data.ObjFunctionSortBits.Decorative, value); }
		}

		public bool InElectronics
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.Electronics); }
			set { SetBit((byte)Data.ObjFunctionSortBits.Electronics, value); }
		}

		public bool InGeneral
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.General); }
			set { SetBit((byte)Data.ObjFunctionSortBits.General, value); }
		}

		public bool InLighting
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.Lighting); }
			set { SetBit((byte)Data.ObjFunctionSortBits.Lighting, value); }
		}

		public bool InPlumbing
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.Plumbing); }
			set { SetBit((byte)Data.ObjFunctionSortBits.Plumbing, value); }
		}

		public bool InSeating
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.Seating); }
			set { SetBit((byte)Data.ObjFunctionSortBits.Seating, value); }
		}

		public bool InSurfaces
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.Surfaces); }
			set { SetBit((byte)Data.ObjFunctionSortBits.Surfaces, value); }
		}

		public bool InHobbies
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.Hobbies); }
			set { SetBit((byte)Data.ObjFunctionSortBits.Hobbies, value); }
		}

		public bool InAspirationRewards
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.AspirationRewards); }
			set { SetBit((byte)Data.ObjFunctionSortBits.AspirationRewards, value); }
		}

		public bool InCareerRewards
		{
			get { return GetBit((byte)Data.ObjFunctionSortBits.CareerRewards); }
			set { SetBit((byte)Data.ObjFunctionSortBits.CareerRewards, value); }
		}
	}
    #endregion

    #region Build mode type
    public class ObjBuildType : FlagBase
    {
        public ObjBuildType(short flags) : base((ushort)flags) { }
        public ObjBuildType(object o) : base(o) { }

        public bool InGeneral
        {
            get { return GetBit((byte)Data.ObjBuildTypeBits.General); }
            set { SetBit((byte)Data.ObjBuildTypeBits.General, value); }
        }

        public bool InUnknown
        {
            get { return GetBit((byte)Data.ObjBuildTypeBits.unknown); }
            set { SetBit((byte)Data.ObjBuildTypeBits.unknown, value); }
        }

        public bool InGarden
        {
            get { return GetBit((byte)Data.ObjBuildTypeBits.Garden); }
            set { SetBit((byte)Data.ObjBuildTypeBits.Garden, value); }
        }

        public bool InOpenings
        {
            get { return GetBit((byte)Data.ObjBuildTypeBits.Openings); }
            set { SetBit((byte)Data.ObjBuildTypeBits.Openings, value); }
        }
    }
    #endregion

    #region EP Flags 1
    public class Epsreq1 : FlagBase
    {
        public Epsreq1(short flags) : base((ushort)flags) { }
        public Epsreq1(object o) : base(o) { }

        public bool Basegame
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.BaseGame); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.BaseGame, value); }
        }

        public bool University
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.University); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.University, value); }
        }

        public bool Nightlife
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.Nightlife); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.Nightlife, value); }
        }

        public bool Business
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.Business); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.Business, value); }
        }

        public bool FamilyFun
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.FamilyFun); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.FamilyFun, value); }
        }

        public bool GlamourLife
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.GlamourLife); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.GlamourLife, value); }
        }

        public bool Pets
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.Pets); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.Pets, value); }
        }

        public bool Seasons
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.Seasons); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.Seasons, value); }
        }

        public bool Celebration
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.Celebration); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.Celebration, value); }
        }

        public bool Fashion
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.Fashion); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.Fashion, value); }
        }

        public bool BonVoyage
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.BonVoyage); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.BonVoyage, value); }
        }

        public bool TeenStyle
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.TeenStyle); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.TeenStyle, value); }
        }

        public bool StoreEdition_old
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.StoreEdition_old); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.StoreEdition_old, value); }
        }

        public bool Freetime
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.Freetime); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.Freetime, value); }
        }

        public bool KitchenBath
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.KitchenBath); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.KitchenBath, value); }
        }

        public bool IkeaHome
        {
            get { return GetBit((byte)Data.MetaData.NeighbourhoodEP.IkeaHome); }
            set { SetBit((byte)Data.MetaData.NeighbourhoodEP.IkeaHome, value); }
        }
    }
    #endregion

    #region EP Flags 2
    public class Epsreq2 : FlagBase
    {
        public Epsreq2(short flags) : base((ushort)flags) { }
        public Epsreq2(object o) : base(o) { }

        public bool ApartmentLife
        {
            get { return GetBit((byte)0); }
            set { SetBit((byte)0, value); }
        }

        public bool MansionGarden
        {
            get { return GetBit((byte)1); }
            set { SetBit((byte)1, value); }
        }

        public bool StoreEdition
        {
            get { return GetBit((byte)0xf); }
            set { SetBit((byte)0xf, value); }
        }
    }
    #endregion
}
