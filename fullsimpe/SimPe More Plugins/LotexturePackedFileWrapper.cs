using System;
using SimPe.Interfaces.Plugin;

namespace SimPe.Plugin
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads 
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class LotexturePackedFileWrapper        
		: AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
    {
        #region Boobs Attribute
        /// <summary>
		/// Contains the Data of the File
		/// </summary>
        private string hoodtexture;
        public int itemnum;
        public int visitnum;
        public string[] texchure;
        public uint[] remeberid;
        public uint[] badgesid;
        private int virsion;
        private int badges;
        private int nuffing;
        private int orfset;
        private ushort generalp;
        private int dataqnt;
        private uint tipe = 0x4B58975B;
        private byte[] filename;

		/// <summary>
		/// Returns/Sets the Data of the File
		/// </summary>
        public string Hoodtexture
        {
            get { return hoodtexture; }
            set { hoodtexture = value; }
        }
        public int Itemnumber
        {
            get { return itemnum; }
        }
        public int Badges
        {
            get { return badges; }
        }
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public LotexturePackedFileWrapper() : base()
		{
			///
			/// Add your Contructor Stuff here (if needed)
			///
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
			return new LotexturePackedFileUI();
		}
		/// <summary>
        /// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
            return new AbstractWrapperInfo(
                "Misc Lot Resource Wrapper",
                "Chris",
                "To view lot terrain textures, individual sim memories and Nid remapping",
                3,
                SimPe.GetIcon.ReadOnly
                );
		}

		/// <summary
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
        {
            itemnum = -1; // Set as Unknown version
            badges = 0;
            hoodtexture = "";
            if (this.FileDescriptor.Type == 0x4B58975B) // Lot Texture
            {
                filename = reader.ReadBytes(64);
                tipe = reader.ReadUInt32();
                virsion = reader.ReadInt32();
                badges = reader.ReadInt32();
                dataqnt = reader.ReadInt32();
                //reader.BaseStream.Seek(0x50, System.IO.SeekOrigin.Begin);
                hoodtexture = reader.ReadString();
                itemnum = reader.ReadInt32();
                Array.Resize<string>(ref texchure, itemnum);
                if (itemnum > 0)
                {
                    for (int i = 0; i < itemnum; i++)
                    {
                        texchure[i] = reader.ReadString();
                    }
                }
            }
            else if (this.FileDescriptor.Type == 0xCDB8BDC4) //Sim Memory
            {
                virsion = reader.ReadInt32();
                if (virsion == 0x000000CB) dataqnt = 10; // Seasons or above
                else if (virsion == 0x000000C2) dataqnt = 8; // Business
                else if (virsion == 0x000000BE) dataqnt = 6; // Nightlife
                else if (virsion == 0x0000006F || virsion == 0x00000070) dataqnt = 2; // Base Game and Uni
                else return; // Castaway doesn't use lot catalog so this shouldn't exist
                if (virsion >= 0x000000BE) nuffing = reader.ReadInt32(); else nuffing = 0;
                badges = reader.ReadInt32();
                if (badges > 0)
                {
                    Array.Resize<uint>(ref badgesid, badges);
                    for (int k = 0; k < badges; k++)
                    {
                        badgesid[k] = reader.ReadUInt32();
                        reader.BaseStream.Seek(dataqnt, System.IO.SeekOrigin.Current);
                        orfset = reader.ReadInt32(); // data beyond dataqnt
                        for (int l = 0; l < orfset; l++)
                        {
                            generalp = reader.ReadUInt16();
                        }
                    }
                }
                itemnum = reader.ReadInt32();
                Array.Resize<uint>(ref remeberid, itemnum);
                for (int i = 0; i < itemnum; i++)
                {
                    remeberid[i] = reader.ReadUInt32();
                    reader.BaseStream.Seek(dataqnt, System.IO.SeekOrigin.Current);
                    orfset = reader.ReadInt32(); // data beyond dataqnt
                    for (int j = 0; j < orfset; j++)
                    {
                        generalp = reader.ReadUInt16();
                    }
                }
                bool dided = false;
                PackedFiles.Wrapper.ExtSDesc sdesc = new SimPe.PackedFiles.Wrapper.ExtSDesc();
                SimPe.Interfaces.Files.IPackedFileDescriptor[] files = package.FindFiles(SimPe.Data.MetaData.SIM_DESCRIPTION_FILE);
                foreach (SimPe.Interfaces.Files.IPackedFileDescriptor pfd in files)
                {
                    sdesc.ProcessData(pfd, package);
                    if (sdesc.Instance == this.FileDescriptor.Instance)
                    {
                        hoodtexture = sdesc.SimName;
                        dided = true;
                    }
                }
                if (!dided) hoodtexture = SimPe.Localization.GetString("Unknown");
            }
            else if (this.FileDescriptor.Type == 0x2DB5C0F4) // Nid Map
            {
                virsion = reader.ReadInt32(); // version
                dataqnt = reader.ReadInt32(); // number of family sims
                for (int j = 0; j < dataqnt; j++) // 1 byte per family nid
                {
                    nuffing = reader.ReadInt32();
                }
                visitnum = reader.ReadInt32(); // How many visitors
                for (int l = 0; l < visitnum; l++) // 1 byte per Visitor nid
                {
                    nuffing = reader.ReadInt32();
                }
                itemnum = reader.ReadInt32(); // Total Sims
                Array.Resize<uint>(ref remeberid, itemnum);
                Array.Resize<uint>(ref badgesid, itemnum);
                Array.Resize<string>(ref texchure, itemnum);
                for (int i = 0; i < itemnum; i++)
                {
                    remeberid[i] = reader.ReadUInt32(); // Nid
                    badgesid[i] = reader.ReadUInt32();  // Instance - GUID
                    SimPe.Interfaces.Files.IPackedFileDescriptor pfd = package.FindFile(Data.MetaData.SIM_DESCRIPTION_FILE, 0, 0xFFFFFFFF, badgesid[i]);
                    if (pfd == null)
                    {
                        if (pjse.GUIDIndex.TheGUIDIndex[badgesid[i]] != null)
                            texchure[i] = pjse.GUIDIndex.TheGUIDIndex[badgesid[i]];
                        else
                            texchure[i] = SimPe.Localization.GetString("Unknown");
                    }
                    else
                    {
                        PackedFiles.Wrapper.ExtSDesc sdesc = new SimPe.PackedFiles.Wrapper.ExtSDesc();
                        sdesc.ProcessData(pfd, package);
                        texchure[i] = sdesc.SimName;
                    }
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
            if (this.FileDescriptor.Type == 0x4B58975B) // Lot Texture
            {
                writer.Write(filename);
                writer.Write(tipe);
                writer.Write(virsion);
                writer.Write(badges);
                writer.Write(dataqnt);
                writer.Write(hoodtexture);
                writer.Write(itemnum);
                if (itemnum > 0)
                {
                    for (int i = 0; i < itemnum; i++)
                    {
                        writer.Write(texchure[i]);
                    }
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
		public byte[] FileSignature
		{
			get
			{
				/// 
				/// Add the Signature Array if needed
				/// 
				return new byte[0];
			}
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
                uint[] types =
                    {
                        0x4B58975B, // Lot Texture
                        0xCDB8BDC4, //Sim Memory
                        0x2DB5C0F4  // Nid Map
                        };  
				return types;
			}
		}

        #endregion

        protected override string GetResourceName(SimPe.Data.TypeAlias ta)
        {
            if (this.FileDescriptor.Type == 0xCDB8BDC4)
            {
                PackedFiles.Wrapper.ExtSDesc sdsc = FileTable.ProviderRegistry.SimDescriptionProvider.FindSim((ushort)this.FileDescriptor.Instance) as PackedFiles.Wrapper.ExtSDesc;
                if (sdsc == null)
                    return base.GetResourceName(ta);
                else
                    return sdsc.SimName + " Memories";
            }
            else
                return base.GetResourceName(ta);
        }
    }
}
