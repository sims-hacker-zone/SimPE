// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.ThreeIdr
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class ThreeIdr
		: AbstractWrapper //Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		/// <summary>
		/// ID of the File
		/// </summary>
		private uint id = 0xDEADBEEF;

		/// <summary>
		/// Type of the File
		/// </summary>
		private Data.MetaData.IndexTypes type = Data.MetaData.IndexTypes.ptLongFileIndex;

		/// <summary>
		/// List of Stored References
		/// </summary>
		public Interfaces.Files.IPackedFileDescriptor[] Items
		{
			get; set;
		} = new Interfaces.Files.IPackedFileDescriptor[0];

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public ThreeIdr() : base() { }

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return version == 0009 //0.00
				|| version == 0010; //0.10
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new ThreeIdrUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"3D Reference File Wrapper",
				"Quaxi",
				"This File contains References to 3D Elements (from the Scenegraph) of a Sim, Skin or Clothing.",
				5,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.3didr.png")
				)
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			id = reader.ReadUInt32();
			type = (Data.MetaData.IndexTypes)reader.ReadUInt32();

			Items = new Interfaces.Files.IPackedFileDescriptor[reader.ReadUInt32()];

			for (int i = 0; i < Items.Length; i++)
			{
				ThreeIdrItem pfd = new ThreeIdrItem(this)
				{
					Type = reader.ReadUInt32(),
					Group = reader.ReadUInt32(),
					Instance = reader.ReadUInt32()
				};
				if (type == Data.MetaData.IndexTypes.ptLongFileIndex)
				{
					pfd.SubType = reader.ReadUInt32();
				}

				/*Interfaces.Files.IPackedFileDescriptor ppfd = Package.FindFile(pfd.Type, pfd.SubType, pfd.Group, pfd.Instance);
				if (ppfd!=null) items[i]=ppfd;
				else*/
				Items[i] = pfd;
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
			writer.Write(id);
			writer.Write((uint)type);
			writer.Write((uint)Items.Length);

			for (int i = 0; i < Items.Length; i++)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = Items[i];

				writer.Write(pfd.Type);
				writer.Write(pfd.Group);
				writer.Write(pfd.Instance);
				if (type == Data.MetaData.IndexTypes.ptLongFileIndex)
				{
					writer.Write(pfd.SubType);
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
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[]
				{
					0xAC506764, //handles the 3IDR File
				};

		#endregion
	}
}
