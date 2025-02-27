/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;

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
		: AbstractWrapper //Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		/// <summary>
		/// Returns or Sets wether the type of the Index
		/// </summary>
		public Data.MetaData.IndexTypes IndexType
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
			IndexType = Data.MetaData.IndexTypes.ptShortFileIndex;
			Items = new ClstItem[0];
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="type">ize of the Package Index</param>
		public CompressedFileList(Data.MetaData.IndexTypes type)
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
						|| (IndexType == Data.MetaData.IndexTypes.ptShortFileIndex)
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
			long count = 0;
			if (IndexType == Data.MetaData.IndexTypes.ptLongFileIndex)
			{
				count = reader.BaseStream.Length / 0x14;
			}
			else
			{
				count = reader.BaseStream.Length / 0x10;
			}

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
						if (IndexType == Data.MetaData.IndexTypes.ptLongFileIndex)
						{
							IndexType = Data.MetaData.IndexTypes.ptShortFileIndex;
						}
						else
						{
							IndexType = Data.MetaData.IndexTypes.ptLongFileIndex;
						}

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
		public byte[] FileSignature
		{
			get
			{
				Byte[] sig = { };
				return sig;
			}
		}

		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
				uint[] types =
				{
					0xE86B1EEF, //clst
				};

				return types;
			}
		}

		#endregion
	}
}
