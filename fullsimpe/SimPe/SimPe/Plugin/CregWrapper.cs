// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

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
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region Attribute
		/// <summary>
		/// Contains the Data of the File
		/// </summary>
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
			get => gd1;
			set => gd1 = value;
		}
		public int[] GD2
		{
			get => gd2;
			set => gd2 = value;
		}
		public int[] GD3
		{
			get => gd3;
			set => gd3 = value;
		}
		public int[] GD4
		{
			get => gd4;
			set => gd4 = value;
		}
		public string[] Conent
		{
			get => content;
			set => content = value;
		}

		public int Qunty { get; set; } = 0;

		public int Vesion { get; set; } = 0;
		public string GooiVal
		{
			get; set;
		}
		public string CRCVal
		{
			get; set;
		}
		public string VersVal
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public CregPackedFileWrapper()
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
				GetIcon.Writable
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
			Vesion = reader.ReadInt32();

			if (Vesion == 7) // new type
			{
				for (int i = 0; i < 3; i++)
				{
					string s1 = reader.ReadString();
					if (s1 == "GUID")
					{
						GooiVal = reader.ReadString();
					}
					else if (s1 == "CRC")
					{
						CRCVal = reader.ReadString();
					}
					else if (s1 == "Version")
					{
						VersVal = reader.ReadString();
					}
				}
			}
			else if (Vesion == 3) // Olde Quaxi Type
			{
				for (int i = 0; i < 3; i++)
				{
					string s1 = StreamHelper.ReadString(reader);
					if (s1 == "GUID")
					{
						GooiVal = StreamHelper.ReadString(reader);
					}
					else if (s1 == "CRC")
					{
						CRCVal = StreamHelper.ReadString(reader);
					}
					else if (s1 == "Version")
					{
						VersVal = StreamHelper.ReadString(reader);
					}
				}
			}
			else if (Vesion == 1) // Maxis proper file
			{
				Qunty = reader.ReadInt32();
				Array.Resize(ref gd1, Qunty);
				Array.Resize(ref gd2, Qunty);
				Array.Resize(ref gd3, Qunty);
				Array.Resize(ref gd4, Qunty);
				Array.Resize(ref content, Qunty);
				for (int i = 0; i < Qunty; i++)
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
			{
				SetContent();
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
			Vesion = 7;
			writer.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
			writer.Write(Vesion);
			writer.Write("GUID");
			writer.Write(GooiVal);
			writer.Write("CRC");
			writer.Write(CRCVal);
			writer.Write("Version");
			writer.Write(VersVal);
		}

		internal void SetContent()
		{
			GooiVal = Guid.NewGuid().ToString().Replace("-", "");
			CRCVal = "00000000000000000000000000000000";
			VersVal = "01";
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
				uint[] types = { 0xCDB467B8 };
				return types;
			}
		}

		#endregion
	}
}
