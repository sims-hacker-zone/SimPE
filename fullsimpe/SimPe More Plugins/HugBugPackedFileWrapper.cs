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
	public class HugBugPackedFileWrapper        
		: AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
    {
        #region Huggy Attribute
        /// <summary>
		/// Contains the Data of the File
		/// </summary>
        private bool corrpt;
        private bool isboobs;
        private bool customcrap;
        private UInt32 guide;
        private UInt32 fbguid;
        private UInt32 Bugga = 0x6DB7E00F;
        private string namer;
        private ushort tipe;
        public int isz;
        public string[] objekts = new string[5000];

		/// <summary>
		/// Returns if Hub Bug was found
		/// </summary>
        public bool IsCorrupt
        {
            get { return corrpt; }
            set { corrpt = value; }
        }

        /// <summary>
        /// Returns if sims were found
        /// </summary>
        public bool IsSims
        {
            get { return isboobs; }
            set { isboobs = value; }
        }

        /// <summary>
        /// Returns if Custom Crap is found
        /// </summary>
        public bool HasCustom
        {
            get { return customcrap; }
            set { customcrap = value; }
        }
		#endregion

        public static String FormatGUID(UInt32 guid, UInt32 origuid, ushort tpe, string naem)
        {
            string retst = "GUID 0x" + SimPe.Helper.HexString(guid);
            String objName = pjse.GUIDIndex.TheGUIDIndex[guid];
            if (guid == origuid)
            {
                if (objName != null && objName.Length > 0)
                    retst += "  (\"" + objName + "\")";
                else
                    if (tpe == 2) retst += "  (\"" + naem + "\")";
                    else retst += "  (\"" + naem + "**\")";
            }
            else
            {
                if (objName != null && objName.Length > 0)
                    retst += " -FALLBACK 0x" + SimPe.Helper.HexString(origuid) + "  (\"" + objName + "\")";
                else
                    if (tpe == 2) retst += " -FALLBACK 0x" + SimPe.Helper.HexString(origuid) + "  (\"" + naem + "\")";
                    else retst += " -FALLBACK 0x" + SimPe.Helper.HexString(origuid) + "  (\"" + naem + "**\")";
            }
            if (tpe == 2) retst += " -(Type: " + Convert.ToString(tpe) + " a Sim!)\n";
            else retst += " -(Type: " + Convert.ToString(tpe) + ")\n";

            return retst;
        }

		/// <summary>
		/// Constructor
		/// </summary>
		public HugBugPackedFileWrapper() : base()
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
			return new HugBugPackedFileUI();
		}
		/// <summary>
        /// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
                return new AbstractWrapperInfo(
                    "Lot Objects Wrapper",
                    "Chris",
                    "Reads the Lot Objects componant in a lot. Will test for the Super Duper Hug",
                    2,
                    SimPe.GetIcon.ReadOnly
                    );
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
        {
            if (!pjse.GUIDIndex.TheGUIDIndex.IsLoaded) pjse.GUIDIndex.TheGUIDIndex.Load(pjse.GUIDIndex.DefaultGUIDFile);
            
            if (isz > 0)
                Array.Clear(objekts, 0, objekts.Length); // These bloody arrays have to be cleared of any previous load
            reader.BaseStream.Seek(76, System.IO.SeekOrigin.Begin); // Begin at first GUID
            /*
            int zie = 0;
            while (reader.BaseStream.Position < reader.BaseStream.Length) // to help prevent trying to read past the end
            {
                guide = reader.ReadUInt32();
                if (guide != 0)
                {
                    reader.BaseStream.Seek(24, System.IO.SeekOrigin.Current);
                    namer = reader.ReadString();
                    reader.BaseStream.Seek(8, System.IO.SeekOrigin.Current);
                    zie++; //count the number of items. Now can resize the array
                }
            }
            reader.BaseStream.Seek(76, System.IO.SeekOrigin.Begin); // Begin at first GUID
            */
            corrpt = false;
            isboobs = false;
            customcrap = false;
            isz = 0; //clear any previous load
            while (reader.BaseStream.Position < reader.BaseStream.Length) // to help prevent trying to read past the end
            {
                guide = reader.ReadUInt32();
                if (guide != 0) //a GUID of 0x0000 is at the end.
                {
                    reader.BaseStream.Seek(22, System.IO.SeekOrigin.Current); // items have 22 bits of 'I don't know what' here
                    tipe = reader.ReadUInt16(); // object Type
                    namer = reader.ReadString(); // internal name, usually from the OBDJ not the catalogue
                    if (namer == "") namer = SimPe.Localization.GetString("Unknown"); // multi tile items have no name, would be a problem if it's not in the pjse GUID list
                    reader.BaseStream.Seek(4, System.IO.SeekOrigin.Current); // 4 bit byte usually empty but not on multi tile items
                    fbguid = reader.ReadUInt32(); // Fall Back GUID, this is the item a user will get if they don't have the item
                    if (guide == Bugga || fbguid == Bugga) corrpt = true; // Hug Bug exists
                    if (tipe == 2) isboobs = true; // Sim(s) exist
                    objekts[isz] = FormatGUID(guide, fbguid, tipe, namer); // public, format the string to appear in the window
                    if (objekts[isz].Contains("**")) customcrap = true; // public, CC crap exists
                    isz++; // public, counts the number of items
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
                uint[] types = { 0x6F626A74 }; // Object (this is where the Hug Bug Lives)
				return types;
			}
		}

        #endregion
    }
}
