// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Text;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Glob
{

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Glob : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		/// <summary>
		/// Returns the Filename
		/// </summary>
		public string FileName
		{
			get;
			set;
		}

		/// <summary>
		/// Whether the length field of the semiglobal name is missing
		/// </summary>
		public bool Faulty { get; set; } = false;
		/// <summary>
		/// Whether the file has additional unused data
		/// </summary>
		public bool Bloaty { get; set; } = false;

		/// <summary>
		/// The semiglobal name
		/// </summary>
		public string SemiGlobalName
		{
			get; set;
		}

		/// <summary>
		/// Return the Group for the current SemiGlobal Name
		/// </summary>
		public uint SemiGlobalGroup => Hashes.GroupHash(SemiGlobalName);
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Glob()
			: base()
		{
		}

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new GlobUI();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo("Global Data Wrapper", "Quaxi", "---", 4);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Faulty = Bloaty = false;
			FileName = Encoding.ASCII.GetString(reader.ReadBytes(64)).TrimEnd(new char[] { '\0' });
			byte len = reader.ReadByte();
			if ((byte)(reader.BaseStream.Length - reader.BaseStream.Position) < len) // some early files ommit len so the first letter is read as len
			{
				Faulty = true;
				reader.BaseStream.Seek(-1, System.IO.SeekOrigin.Current);
				len = (byte)(reader.BaseStream.Length - reader.BaseStream.Position);
			}
			else if (
				(byte)(reader.BaseStream.Length - reader.BaseStream.Position) > len
			) // some early files contain a whole bunch of extra junk at the end
			{
				Bloaty = true;
			}

			SemiGlobalName = Encoding.ASCII.GetString(reader.ReadBytes(len)).Trim();
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
			byte[] filename = new byte[64];
			Encoding.ASCII.GetBytes(FileName, 0, 64, filename, 0);
			writer.Write(filename);
			writer.Write(SemiGlobalName.Length);
			byte[] semiglobal = new byte[SemiGlobalName.Length];
			Encoding.ASCII.GetBytes(SemiGlobalName, 0, 64, semiglobal, 0);
			writer.Write(semiglobal);
		}
		#endregion

		#region IFileWrapper Member
		public override string Description => $"SemiGlobalName={SemiGlobalName}, Group=0x{Helper.HexString(SemiGlobalGroup)}";

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[] { 0x474C4F42 }; //handles the GLOB File
		#endregion
	}
}
