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
using System.Collections;
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
	public class TPRP
		: pjse.ExtendedWrapper<
			TPRPItem,
			TPRP
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
		private uint[] header = { 0x54505250, 0x0000004E, 0x00000000 }; // 'TPRP', version, 0

		/// <summary>
		/// Count of Param labels
		/// </summary>
		private int paramCount = 0;

		/// <summary>
		/// Count of Local labels
		/// </summary>
		private int localCount = 0;

		/// <summary>
		/// Unknown
		/// </summary>
		private uint reserved = 0;

		/// <summary>
		/// Contains 0x01 for each TPRPParamItem
		/// </summary>
		private byte[] paramData = new byte[0];

		/// <summary>
		/// Trailer of the File
		/// </summary>
		private uint[] trailer = { 0x00000005, 0x00000000 }; // Display code, null
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
		public bool TextOnly
		{
			get
			{
				return (duff);
			}
		}

		public int ParamCount
		{
			get
			{
				return duff ? 0 : paramCount;
			}
		}

		public int LocalCount
		{
			get
			{
				return duff ? 0 : localCount;
			}
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public TPRP()
			: base() { }

		public void CleanUp()
		{
			internalchg = true;
			while (
				paramCount > 0 && this[false, paramCount - 1].Label.Trim().Length == 0
			)
				Remove(this[false, paramCount - 1]);
			while (
				localCount > 0 && this[true, localCount - 1].Label.Trim().Length == 0
			)
				Remove(this[true, localCount - 1]);
			internalchg = false;
		}

		public TPRPItem this[bool local, int index]
		{
			get
			{
				if (duff)
					throw new InvalidOperationException();

				if (local)
					index += paramCount;
				else if (index > paramCount)
					throw new ArgumentOutOfRangeException();

				return this[index];
			}
			set
			{
				if (local)
				{
					if (value is TPRPParamLabel)
						throw new InvalidCastException();
					index += paramCount;
				}
				else
				{
					if (value is TPRPLocalLabel)
						throw new InvalidCastException();
					if (index > paramCount)
						throw new ArgumentOutOfRangeException();
				}

				this[index] = value;
			}
		}

		public override void Add(TPRPItem item)
		{
			if (item.IsParamLabel)
			{
				paramCount++;
				base.Insert(paramCount - 1, item);
			}
			else
			{
				localCount++;
				base.Insert(paramCount + localCount - 1, item);
			}
		}

		public new bool Remove(TPRPItem item)
		{
			if (item.IsParamLabel)
			{
				paramCount--;
				return base.Remove(item);
			}
			else
			{
				localCount--;
				return base.Remove(item);
			}
		}

		public new void Clear()
		{
			paramCount = localCount = 0;
			base.Clear();
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
			return new UserInterface.TPRPForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"PJSE TPRP Wrapper",
				"Peter L Jones",
				"TREE Label Editor",
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
			if (duff)
				throw new InvalidOperationException("Cannot serialize a duff TPRP");

			CleanUp();

			writer.Write(filename);
			writer.Write(header[0]);
			writer.Write(header[1]);
			writer.Write(header[2]);

			writer.Write(paramCount);
			writer.Write(localCount);

			foreach (TPRPItem item in items)
				if (item is TPRPParamLabel)
					item.Serialize(writer);
			foreach (TPRPItem item in items)
				if (item is TPRPLocalLabel)
					item.Serialize(writer);

			writer.Write(reserved);
			foreach (TPRPItem item in items)
				if (item is TPRPParamLabel)
					writer.Write(((TPRPParamLabel)item).PData);

			writer.Write(trailer[0]);
			writer.Write(trailer[1]);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			duff = false;
			items = null;

			filename = reader.ReadBytes(64);

			header = new uint[3];
			header[0] = reader.ReadUInt32();
			header[1] = reader.ReadUInt32();
			header[2] = reader.ReadUInt32();
			if (header[0] != 0x54505250)
			{
				duff = true;
				return;
			}

			try
			{
				paramCount = reader.ReadInt32();
				localCount = reader.ReadInt32();

				items = new List<TPRPItem>();
				for (int i = 0; i < paramCount; i++)
					items.Add(new TPRPParamLabel(this, reader));
				for (int i = 0; i < localCount; i++)
					items.Add(new TPRPLocalLabel(this, reader));

				reserved = reader.ReadUInt32();
				foreach (TPRPItem item in items)
					if (item is TPRPParamLabel)
						((TPRPParamLabel)item).ReadPData(reader);

				trailer = new uint[2];
				trailer[0] = reader.ReadUInt32();
				trailer[1] = reader.ReadUInt32();
			}
			catch
			{
				duff = true;
			}
		}

		#endregion

		public const uint TPRPtype = 0x54505250;

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes
		{
			get
			{
				return new uint[] { TPRPtype };
			}
		}

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature
		{
			get
			{
				return new byte[0];
			}
		}

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by AbstractWrapper
		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!SimPe.Helper.FileFormat)
				return base.GetResourceName(ta);
			SimPe.Interfaces.Files.IPackedFile pf = Package.Read(FileDescriptor);
			byte[] ab = pf.GetUncompressedData(0x48);
			return (ab.Length > 0x44 ? "0x" + Helper.HexString(ab[0x44]) + ": " : "")
				+ Helper.ToString(pf.GetUncompressedData(0x40));
		}
		#endregion
	}

	/// <summary>
	/// An Item stored in a TPRP
	/// </summary>
	public abstract class TPRPItem : pjse.ExtendedWrapperItem<TPRP, TPRPItem>
	{
		#region Attributes
		private string label = "";

		private bool pORl = false;
		#endregion

		#region Accessor methods
		public string Label
		{
			get
			{
				return label;
			}
			set
			{
				if (label != value)
				{
					label = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public bool IsParamLabel
		{
			get
			{
				return (pORl == false);
			}
		}

		public bool IsLocalLabel
		{
			get
			{
				return (pORl == true);
			}
		}
		#endregion

		public TPRPItem(TPRP parent, bool pORl)
		{
			this.parent = parent;
			this.pORl = pORl;
		}

		public TPRPItem(TPRP parent, bool pORl, System.IO.BinaryReader reader)
			: this(parent, pORl)
		{
			Unserialize(reader);
		}

		public TPRPItem Clone()
		{
			TPRPItem clone = (TPRPItem)base.MemberwiseClone();
			clone.label = (string)this.label.Clone();
			clone.pORl = this.pORl;
			clone.parent = this.parent;
			return clone;
		}

		/// <summary>
		/// Reads Data from the Stream
		/// </summary>
		/// <param name="reader"></param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			label = SimPe.Helper.ToString(reader.ReadBytes(reader.ReadByte()));
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
			writer.Write((byte)label.Length);
			foreach (char c in label)
				writer.Write(c);
		}

		public override string ToString()
		{
			return label;
		}

		public static implicit operator string(TPRPItem i)
		{
			return i.label;
		}
	}

	public class TPRPParamLabel : TPRPItem
	{
		private byte pData = 0x01;
		public byte PData
		{
			get
			{
				return pData;
			}
		}

		/// <summary>
		/// For the time being, I'm explicitly preventing this value being adjusted
		/// </summary>
		/// <param name="reader">Stream containing a byte to read</param>
		public void ReadPData(System.IO.BinaryReader reader)
		{
			pData = reader.ReadByte();
		}

		public TPRPParamLabel(TPRP parent)
			: base(parent, false) { }

		public TPRPParamLabel(TPRP parent, System.IO.BinaryReader reader)
			: base(parent, false, reader) { }
	}

	public class TPRPLocalLabel : TPRPItem
	{
		public TPRPLocalLabel(TPRP parent)
			: base(parent, true) { }

		public TPRPLocalLabel(TPRP parent, System.IO.BinaryReader reader)
			: base(parent, true, reader) { }
	}
}
