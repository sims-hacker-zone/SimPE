// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Nref
{
	/// <summary>
	/// The Name Reference Files
	/// </summary>
	public class Nref : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension, IMultiplePackedFileWrapper
	{
		byte[] data;

		/// <summary>
		/// The Filename stored in the NREF File
		/// </summary>
		public string FileName
		{
			get => Helper.ToString(data);
			set => data = Helper.ToBytes(value);
		}

		public uint Group => Hashes.GroupHash(FileName);

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo("Name Reference Wrapper", "Quaxi", "---", 3);
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new NrefUI();
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			data = reader.ReadBytes((int)reader.BaseStream.Length);
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
			writer.Write(data);
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member

		public override string Description => "Name=" + FileName + ", Group=0x" + Helper.HexString(Group);

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.NREF };

		#endregion

		#region IMultiplePackedFileWrapper
		public override object[] GetConstructorArguments()
		{
			return new object[0];
		}
		#endregion
	}
}
