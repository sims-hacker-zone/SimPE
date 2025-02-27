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
	public class WinfoPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region Attribute
		/// <summary>
		/// Contains the Data of the File
		/// </summary>
		public uint weaversion;
		private int westlength;
		public uint unkn1; // this is always 1 higher than unkn2, or next season. the climate controller doesn't need this value but seems to set it
		public uint unkn2;
		public uint unkn3;
		public uint unkn4;
		public uint unkn5;
		public uint unkn6;
		public uint unkn7;
		public uint unkn8;
		public int wetemperature;
		public uint unkn9;
		public uint unkn0;

		/// <summary>
		/// Returns/Sets the Data of the File
		/// </summary>
		public string Weaname
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public WinfoPackedFileWrapper()
			: base()
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
			return new WinfoPackedFileUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Weather Info Wrapper",
				"Chris",
				"To aid unravelling Weather Info files",
				2,
				SimPe.GetIcon.Butterfly
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
			weaversion = reader.ReadUInt32();
			if (weaversion != 3)
			{
				Weaname = "Unknown Version!";
				return;
			}
			westlength = reader.ReadInt32();
			Weaname = "";
			if (westlength > 0)
			{
				for (int i = 0; i < westlength; i++)
				{
					char b = reader.ReadChar();
					Weaname += b;
				}
				reader.BaseStream.Seek(8 + westlength, System.IO.SeekOrigin.Begin); // reset locataion, some languages screw it up
			}
			unkn1 = reader.ReadUInt32();
			unkn2 = reader.ReadUInt32();
			unkn3 = reader.ReadUInt32();
			unkn4 = reader.ReadUInt32();
			unkn5 = reader.ReadUInt32();
			unkn6 = reader.ReadUInt32();
			unkn7 = reader.ReadUInt32();
			unkn8 = reader.ReadUInt32();
			wetemperature = reader.ReadInt32();
			unkn9 = reader.ReadUInt32();
			unkn0 = reader.ReadUInt32();
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
			writer.Write(weaversion);
			westlength = Weaname.Length;
			writer.Write(westlength);
			if (Weaname != null)
			{
				foreach (char c in Weaname)
				{
					writer.Write(c);
				}
			}

			writer.Write(unkn1);
			writer.Write(unkn2);
			writer.Write(unkn3);
			writer.Write(unkn4);
			writer.Write(unkn5);
			writer.Write(unkn6);
			writer.Write(unkn7);
			writer.Write(unkn8);
			writer.Write(wetemperature);
			writer.Write(unkn9);
			writer.Write(unkn0);
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
				uint[] types = { 0xB21BE28B }; //Weather Info
				return types;
			}
		}

		#endregion
	}
}
