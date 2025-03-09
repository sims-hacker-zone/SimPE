// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Init
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class InventItemPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region InvItem Attribute
		/// <summary>
		/// Contains the Data of the File
		/// </summary>
		private uint guide;
		private uint guidnx;

		/// <summary>
		/// Returns if Hub Bug was found
		/// </summary>
		public string DispLabel
		{
			get; set;
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public InventItemPackedFileWrapper()
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
			return new InventItemPackedFileUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Inventory Item Wrapper",
				"Chris",
				"Reads the Inventory Items",
				2,
				GetIcon.ReadOnly
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			if (!pjse.GUIDIndex.TheGUIDIndex.IsLoaded)
			{
				pjse.GUIDIndex.TheGUIDIndex.Load(pjse.GUIDIndex.DefaultGUIDFile);
			}

			reader.BaseStream.Seek(16, System.IO.SeekOrigin.Begin); // Begin at first GUID
			guide = reader.ReadUInt32();
			DispLabel =
				"GUID 0x"
				+ Helper.HexString(guide)
				+ "  "
				+ pjse.GUIDIndex.TheGUIDIndex[guide];
			guidnx = reader.ReadUInt32();
			if (guidnx != guide)
			{
				DispLabel +=
					"\n Contains\n GUID 0x"
					+ Helper.HexString(guidnx)
					+ "  "
					+ pjse.GUIDIndex.TheGUIDIndex[guidnx];

				while (reader.BaseStream.Position < reader.BaseStream.Length)
				{
					guidnx = reader.ReadUInt32();
					if (guidnx != guide)
					{
						DispLabel +=
							"\n GUID 0x"
							+ Helper.HexString(guidnx)
							+ "  "
							+ pjse.GUIDIndex.TheGUIDIndex[guidnx];
					}
					else
					{
						break;
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
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.INIT };

		#endregion
	}
}
