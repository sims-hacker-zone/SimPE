/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;

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
	public class Trcn
		: pjse.ExtendedWrapper<
			TrcnItem,
			Trcn
		> //AbstractWrapper				//Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		/// <summary>
		/// Contains the Filename
		/// </summary>
		private byte[] filename = new byte[64];

		/// <summary>
		/// Header of the File
		/// </summary>
		private uint[] header = { 0x5452434E, 0x0000004E, 0x00000000 }; // 'TRCN', version, 0
		#endregion

		#region Accessor methods
		/// <summary>
		/// Returns the Filename
		/// </summary>
		public string FileName
		{
			get
			{
				return Helper.ToString(filename);
			}
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
		/// Returns the Version
		/// </summary>
		public uint Version
		{
			get
			{
				return header[1];
			}
			set
			{
				if (header[1] != value)
				{
					header[1] = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		private bool duff = false;
		public bool TextOnly => (duff || (header[1] != 0x1 && header[1] < 0x3f));
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Trcn()
			: base() { }

		public void CleanUp()
		{
			while (
				items.Count > 0 && items[items.Count - 1].ConstName.Trim().Length == 0
			)
			{
				items.RemoveAt(items.Count - 1);
			}
		}

		#region AbstractWrapper Member
		public override bool CheckVersion(uint version)
		{
			if (
				(version == 0012) //0.00
				|| (version == 0013) //0.10
			)
			{
				return true;
			}

			return false;
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.TrcnForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"PJSE TRCN Wrapper",
				"Peter L Jones",
				"BCON Label Editor",
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
			CleanUp();
			if (header[1] == 1)
			{
				header[1] = 0x3f; // upgrades version 1 to 0x3F on saving
			}

			writer.Write(filename);
			writer.Write(header[0]);
			writer.Write(header[1]);
			writer.Write(header[2]);

			writer.Write((uint)items.Count);

			foreach (TrcnItem item in items)
			{
				item.Serialize(writer);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			duff = false;
			items = new List<TrcnItem>();
			if (reader.BaseStream.Length < 80)
			{
				duff = true;
				return;
			}
			reader.BaseStream.Position = 0; // when importing labels the reader may not begin at the beginning so we force it
			filename = reader.ReadBytes(64);
			header = new uint[3];
			header[0] = reader.ReadUInt32(); // not used - Forced
			header[1] = reader.ReadUInt32(); // Version, the only bit we need. We force the rest
			header[2] = reader.ReadUInt32(); // not used - Forced

			header[0] = 0x5452434E;
			header[2] = 0;
			/* version 1 have the actual header[0] 8 bytes later than others
			 * the labels don't have the preceding byte for how many bytes
			 * so we must read version 1 differently
			 version 1 is upgraded to 0x3F on saving so it can be written the same*/
			reader.BaseStream.Seek(76, System.IO.SeekOrigin.Begin);

			if (TextOnly)
			{
				return;
			}

			uint itemCount = reader.ReadUInt32();
			if (itemCount >= 0x8000)
			{
				duff = true;
				return;
			}

			try
			{
				while (items.Count < itemCount)
				{
					items.Add(new TrcnItem(this, reader));
				}
			}
			catch
			{
				duff = true;
			}
		}

		#endregion

		public const uint Trcntype = 0x5452434E;

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[] { Trcntype };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by AbstractWrapper
		#endregion

		#region IPackedFileLoadExtension Members
		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!SimPe.Helper.FileFormat)
			{
				return base.GetResourceName(ta);
			}

			Interfaces.Files.IPackedFile pf = Package.Read(FileDescriptor);
			byte[] ab = pf.GetUncompressedData(0x48);
			return (ab.Length > 0x44 ? "0x" + Helper.HexString(ab[0x44]) + ": " : "")
				+ Helper.ToString(pf.GetUncompressedData(0x40));
		}
		#endregion

		public new void Add(TrcnItem item)
		{
			Add(item, 0x8000);
		}

		public new void Insert(int index, TrcnItem item)
		{
			Insert(index, item, 0x8000);
		}
	}

	/// <summary>
	/// An Item stored in a TRCN
	/// </summary>
	public class TrcnItem : pjse.ExtendedWrapperItem<Trcn, TrcnItem>
	{
		#region Attributes
		private uint used = 0x00000000;
		private uint constId = 0x00000000;
		private string constName = "";
		private string constDesc = "";
		private ushort defValue = 0;
		private ushort minValue = 0;
		private ushort maxValue = 0;
		#endregion

		#region Accessor methods
		public uint Used
		{
			get
			{
				return used;
			}
			set
			{
				if (used != value)
				{
					used = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public uint ConstId
		{
			get
			{
				return constId;
			}
			set
			{
				if (constId != value)
				{
					constId = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public string ConstName
		{
			get
			{
				return constName;
			}
			set
			{
				if (constName != value)
				{
					constName = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public string ConstDesc
		{
			get
			{
				return constDesc;
			}
			set
			{
				if (constDesc != value)
				{
					constDesc = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort DefValue
		{
			get
			{
				return defValue;
			}
			set
			{
				if (defValue != value)
				{
					defValue = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort MinValue
		{
			get
			{
				return minValue;
			}
			set
			{
				if (minValue != value)
				{
					minValue = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort MaxValue
		{
			get
			{
				return maxValue;
			}
			set
			{
				if (maxValue != value)
				{
					maxValue = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		public TrcnItem(Trcn parent)
		{
			this.parent = parent;
		}

		public TrcnItem(Trcn parent, System.IO.BinaryReader reader)
		{
			this.parent = parent;
			Unserialize(reader);
		}

		public TrcnItem Clone()
		{
			TrcnItem clone = new TrcnItem(this.parent);
			clone.used = this.used;
			clone.constId = this.constId;
			clone.constName = this.constName;
			clone.constDesc = this.constDesc;
			clone.defValue = this.defValue;
			clone.minValue = this.minValue;
			clone.maxValue = this.maxValue;
			return clone;
		}

		/// <summary>
		/// Reads Data from the Stream
		/// </summary>
		/// <param name="reader"></param>
		protected void Unserialize(System.IO.BinaryReader reader)
		{
			this.used = reader.ReadUInt32();
			this.constId = reader.ReadUInt32();
			if (parent.Version == 1) // I doubt version 1 actually exists but this reads the unreadable type as version 1
			{
				char b = reader.ReadChar();
				while (b != 0)
				{
					this.constName += b;
					b = reader.ReadChar();
				}
				byte bum = reader.ReadByte();
				while (
					bum != 0x64 && reader.BaseStream.Position < reader.BaseStream.Length
				) // 0x64 marks the end, may be problem if an unused att. has a value of 0x64
				{
					bum = reader.ReadByte();
				}
				bum = reader.ReadByte();
				this.constDesc = ""; // These attributes are unused.
				this.defValue = 0; // Was silly to throw so many
				this.minValue = 0; // constant labels away by trying
				this.maxValue = 100; // to glean these values!
			}
			else
			{
				this.constName = SimPe.Helper.ToString(
					reader.ReadBytes(reader.ReadByte())
				);
				if (parent.Version > 0x53)
				{
					this.constDesc = SimPe.Helper.ToString(
						reader.ReadBytes(reader.ReadByte())
					);
					this.defValue = reader.ReadByte();
				}
				else
				{
					this.constDesc = "";
					this.defValue = reader.ReadUInt16();
				}
				this.minValue = reader.ReadUInt16();
				this.maxValue = reader.ReadUInt16();
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
		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(this.used);
			writer.Write(this.constId);
			writer.Write((byte)this.constName.Length);
			writer.Write(SimPe.Helper.ToBytes(this.constName, this.constName.Length));
			if (parent.Version > 0x53)
			{
				writer.Write((byte)this.constDesc.Length);
				writer.Write(
					SimPe.Helper.ToBytes(this.constDesc, this.constDesc.Length)
				);
				writer.Write((byte)this.defValue);
			}
			else
			{
				writer.Write(this.defValue);
			}
			writer.Write(this.minValue);
			writer.Write(this.maxValue);
		}

		public override string ToString()
		{
			return constName;
		}

		public static implicit operator string(TrcnItem i)
		{
			return i.constName;
		}
	}
}
