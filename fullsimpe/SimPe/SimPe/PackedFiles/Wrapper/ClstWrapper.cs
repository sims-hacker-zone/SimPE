// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class CompressedFileList
		: AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		/// <summary>
		/// Returns or Sets wether the type of the Index
		/// </summary>
		public Data.IndexTypes IndexType
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets the Constants
		/// </summary>
		public ClstItem[] Items
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		internal CompressedFileList()
			: base()
		{
			IndexType = Data.IndexTypes.ptShortFileIndex;
			Items = new ClstItem[0];
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="type">ize of the Package Index</param>
		public CompressedFileList(Data.IndexTypes type)
			: base()
		{
			IndexType = type;
			Items = new ClstItem[0];
		}

		/// <summary>
		/// Constructor, Initializes the Object with Data from the File
		/// </summary>
		/// <param name="type">ize of the Package Index</param>
		/// <param name="pfd"></param>
		/// <param name="package"></param>
		public CompressedFileList(IPackedFileDescriptor pfd, IPackageFile package)
			: base()
		{
			IndexType = package.Header.IndexType;
			Items = new ClstItem[0];
			ProcessData(pfd, package);
		}

		/// <summary>
		/// Returns the Number of the File matching the passed Descriptor
		/// </summary>
		/// <param name="pfd">A PackedFileDescriptor</param>
		/// <returns>-1 if none was foudn or the index number of the first matching file</returns>
		public int FindFile(IPackedFileDescriptor pfd)
		{
			if (Items == null)
			{
				return -1;
			}

			for (int i = 0; i < Items.Length; i++)
			{
				ClstItem lfi = Items[i];

				if (
					(lfi.Group == pfd.Group)
					&& (lfi.Instance == pfd.Instance)
					&& (
						(lfi.SubType == pfd.SubType)
						|| (IndexType == Data.IndexTypes.ptShortFileIndex)
					)
					&& (lfi.Type == pfd.Type)
				)
				{
					return i;
				}
			}

			return -1;
		}

		public void Clear()
		{
			Items = new ClstItem[0];
		}

		/// <summary>
		/// Adds a new File to the Items
		/// </summary>
		/// <param name="item">the new File</param>
		public void Add(ClstItem item)
		{
			ClstItem[] its = new ClstItem[Items.Length + 1];
			Items.CopyTo(its, 0);
			its[its.Length - 1] = item;

			Items = its;
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
			return new UserInterface.ClstForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Compressed File Directory Wrapper",
				"Quaxi",
				"This File contains a List of all compressed Files that are stored within this Package.",
				2,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.clst.png")
				)
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			IndexType = package.Header.IndexType;
			long count = IndexType == Data.IndexTypes.ptLongFileIndex ? reader.BaseStream.Length / 0x14 : reader.BaseStream.Length / 0x10;

			Items = new ClstItem[count];

			long pos = reader.BaseStream.Position;
			bool switch_t = false;
			for (int i = 0; i < count; i++)
			{
				ClstItem item = new ClstItem(IndexType);
				item.Unserialize(reader);

				if ((i == 2) && (!switch_t))
				{
					switch_t = true;
					if (
						Package.FindFile(
							item.Type,
							item.SubType,
							item.Group,
							item.Instance
						) == null
					)
					{
						i = 0;
						IndexType = IndexType == Data.IndexTypes.ptLongFileIndex
							? Data.IndexTypes.ptShortFileIndex
							: Data.IndexTypes.ptLongFileIndex;

						reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);
						item = new ClstItem(IndexType);
						item.Unserialize(reader);
					}
				}

				Items[i] = item;
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
			for (int i = 0; i < Items.Length; i++)
			{
				Items[i].Serialize(writer, IndexType);
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
		public byte[] FileSignature => new byte[] { };

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.CLST };

		#endregion
	}
}
