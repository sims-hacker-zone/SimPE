// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Bcon
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Bcon
		: pjse.ExtendedWrapper<BconItem, Bcon>, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		/// <summary>
		/// Contains the Filename
		/// </summary>
		private byte[] filename = new byte[64];

		/// <summary>
		/// Just A Flag
		/// </summary>
		private bool flag = false;
		#endregion

		#region Accessor methods
		/// <summary>
		/// Returns the Filename
		/// </summary>
		public string FileName
		{
			get => Helper.ToString(filename);
			set
			{
				if (!Helper.ToString(filename).Equals(value))
				{
					filename = Helper.ToBytes(value, 0x40);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		/// Returns /Sets the Flag
		/// </summary>
		public bool Flag
		{
			get => flag;
			set
			{
				if (flag != value)
				{
					flag = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Bcon()
			: base() { }

		#region AbstractWrapper Member
		public override bool CheckVersion(uint version)
		{
			return version == 0012 //0.00
				|| version == 0013; //0.10
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new BconForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"PJSE BCON Wrapper",
				"Peter L Jones",
				"BCON Value Editor",
				1
			);
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
			writer.Write(filename);
			int countflag = items.Count | (flag ? 0x8000 : 0x0000);
			writer.Write((ushort)countflag);

			foreach (short v in items)
			{
				writer.Write(v);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(64);
			ushort countflag = reader.ReadUInt16();
			flag = (countflag & 0x8000) != 0;
			int length = countflag & 0x7fff;

			items = new List<BconItem>();
			while (items.Count < length)
			{
				items.Add(reader.ReadInt16());
			}
		}

		#endregion

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.BCON };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		public new void Add(BconItem item)
		{
			Add(item, 0x8000);
		}

		public new void Insert(int index, BconItem item)
		{
			Insert(index, item, 0x8000);
		}
	}
}
