// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Wlay
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class WallLayerPackedFileWrapper
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		#region Attribute
		/// <summary>
		/// Contains the Data of the File
		/// </summary>
		private uint[] bindex;
		public uint[] bwallid;
		public ushort[] lpaint;
		public ushort[] rpaint;

		/// <summary>
		/// Returns/Sets the Data of the File
		/// </summary>
		public int ItemCount
		{
			get; private set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public WallLayerPackedFileWrapper()
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
			return new WallLayerPackedFileUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Wall Layer Wrapper",
				"Chris",
				"To View the Wall Layer",
				69,
				GetIcon.GameTip
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			reader.BaseStream.Seek(83, System.IO.SeekOrigin.Begin);

			ItemCount = reader.ReadInt32();
			Array.Resize(ref bindex, ItemCount);
			Array.Resize(ref bwallid, ItemCount);
			Array.Resize(ref lpaint, ItemCount);
			Array.Resize(ref rpaint, ItemCount);
			for (int i = 0; i < ItemCount; i++)
			{
				bindex[i] = reader.ReadUInt32();
				bwallid[i] = reader.ReadUInt32();
				lpaint[i] = reader.ReadUInt16();
				rpaint[i] = reader.ReadUInt16();
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
			for (int j = 0; j < 64; j++)
			{
				writer.Write((byte)0);
			}
			writer.Write((uint)FileTypes.WLAY);
			writer.Write(1);
			writer.Write("cWallLayer");
			writer.Write(ItemCount);
			for (int i = 0; i < ItemCount; i++)
			{
				writer.Write(bindex[i]);
				writer.Write(bwallid[i]);
				writer.Write(lpaint[i]);
				writer.Write(rpaint[i]);
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
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.WLAY };

		#endregion
	}
}
