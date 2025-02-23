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
	public class CregPackedFileWrapper        
		: AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
    {
        #region Boobs Attribute
        /// <summary>
		/// Contains the Data of the File
		/// </summary>
        private string gooival;
        private string crcval;
        private string versval;
        private int ves = 0;
        private int qnty = 0;
        private int[] gd1;
        private int[] gd2;
        private int[] gd3;
        private int[] gd4;
        private string[] content;

		/// <summary>
		/// Returns/Sets the Data of the File
        /// </summary>
        /// 
        public int[] GD1
        {
            get { return gd1; }
            set { gd1 = value; }
        }
        public int[] GD2
        {
            get { return gd2; }
            set { gd2 = value; }
        }
        public int[] GD3
        {
            get { return gd3; }
            set { gd3 = value; }
        }
        public int[] GD4
        {
            get { return gd4; }
            set { gd4 = value; }
        }
        public string[] Conent
        {
            get { return content; }
            set { content = value; }
        }

        public int Qunty
        {
            get { return qnty; }
            set { qnty = value; }
        }

        public int Vesion
        {
            get { return ves; }
            set { ves = value; }
        }
        public string GooiVal
        {
            get { return gooival; }
            set { gooival = value; }
        }
        public string CRCVal
        {
            get { return crcval; }
            set { crcval = value; }
        }
        public string VersVal
        {
            get { return versval; }
            set { versval = value; }
        }
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public CregPackedFileWrapper() : base()
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
			return new CregPackedFileUI();
		}
		/// <summary>
        /// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
            return new AbstractWrapperInfo(
                "Content Registry Wrapper",
                "Chris",
                "Used to Identify custom Content, and keep track of available Game Content",
                2,
                SimPe.GetIcon.Writable
                );
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
        {
                reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                ves = reader.ReadInt32();

                if (ves == 7) // new type
                {
                    for (int i = 0; i < 3; i++)
                    {
                        string s1 = reader.ReadString();
                        if (s1 == "GUID") gooival = reader.ReadString();
                        else if (s1 == "CRC") crcval = reader.ReadString();
                        else if (s1 == "Version") versval = reader.ReadString();
                    }
                }
                else if (ves == 3) // Olde Quaxi Type
                {
                    for (int i = 0; i < 3; i++)
                    {
                        string s1 = StreamHelper.ReadString(reader);
                        if (s1 == "GUID") gooival = StreamHelper.ReadString(reader);
                        else if (s1 == "CRC") crcval = StreamHelper.ReadString(reader);
                        else if (s1 == "Version") versval = StreamHelper.ReadString(reader);
                    }
                }
                else if (ves == 1) // Maxis proper file
                {
                    qnty = reader.ReadInt32();
                    Array.Resize<int>(ref gd1, qnty);
                    Array.Resize<int>(ref gd2, qnty);
                    Array.Resize<int>(ref gd3, qnty);
                    Array.Resize<int>(ref gd4, qnty);
                    Array.Resize<string>(ref content, qnty);
                    for (int i = 0; i < qnty; i++)
                    {
                        gd1[i] = reader.ReadInt32();
                        gd2[i] = reader.ReadInt32();
                        gd3[i] = reader.ReadInt32();
                        gd4[i] = reader.ReadInt32();
                        content[i] = StreamHelper.ReadString(reader);
                    }
                    SetContent();
                }
                else
                    SetContent();
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
            ves = 7;
            writer.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            writer.Write(ves);
            writer.Write("GUID");
            writer.Write(gooival);
            writer.Write("CRC");
            writer.Write(crcval);
            writer.Write("Version");
            writer.Write(versval);
		}

        internal void SetContent()
        {
            gooival = System.Guid.NewGuid().ToString().Replace("-", "");
            crcval = "00000000000000000000000000000000";
            versval = "01";
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
                uint[] types = { 0xCDB467B8 };
				return types;
			}
		}

        #endregion
    }
}
