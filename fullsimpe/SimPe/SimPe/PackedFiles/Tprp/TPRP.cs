// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Tprp
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class TPRP : pjse.ExtendedWrapper<TPRPItem, TPRP>, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		/// <summary>
		/// Contains the Filename
		/// </summary>
		private byte[] filename = new byte[64];

		/// <summary>
		/// Header of the File
		/// </summary>
		private uint[] header = { (uint)FileTypes.TPRP, 0x0000004E, 0x00000000 }; // 'TPRP', version, 0

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
		/// Returns the Version
		/// </summary>
		public uint Version
		{
			get => header[1];
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
		public bool TextOnly => duff;

		public int ParamCount => duff ? 0 : paramCount;

		public int LocalCount => duff ? 0 : localCount;

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
			{
				Remove(this[false, paramCount - 1]);
			}

			while (
				localCount > 0 && this[true, localCount - 1].Label.Trim().Length == 0
			)
			{
				Remove(this[true, localCount - 1]);
			}

			internalchg = false;
		}

		public TPRPItem this[bool local, int index]
		{
			get
			{
				if (duff)
				{
					throw new InvalidOperationException();
				}

				if (local)
				{
					index += paramCount;
				}
				else if (index > paramCount)
				{
					throw new ArgumentOutOfRangeException();
				}

				return this[index];
			}
			set
			{
				if (local)
				{
					if (value is TPRPParamLabel)
					{
						throw new InvalidCastException();
					}

					index += paramCount;
				}
				else
				{
					if (value is TPRPLocalLabel)
					{
						throw new InvalidCastException();
					}

					if (index > paramCount)
					{
						throw new ArgumentOutOfRangeException();
					}
				}

				this[index] = value;
			}
		}

		public override void Add(TPRPItem item)
		{
			if (item.IsParamLabel)
			{
				paramCount++;
				Insert(paramCount - 1, item);
			}
			else
			{
				localCount++;
				Insert(paramCount + localCount - 1, item);
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
			return version == 0012 //0.00
				|| version == 0013;  //0.10
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new TPRPForm();
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
			{
				throw new InvalidOperationException("Cannot serialize a duff TPRP");
			}

			CleanUp();

			writer.Write(filename);
			writer.Write(header[0]);
			writer.Write(header[1]);
			writer.Write(header[2]);

			writer.Write(paramCount);
			writer.Write(localCount);

			foreach (TPRPItem item in items)
			{
				if (item is TPRPParamLabel)
				{
					item.Serialize(writer);
				}
			}

			foreach (TPRPItem item in items)
			{
				if (item is TPRPLocalLabel)
				{
					item.Serialize(writer);
				}
			}

			writer.Write(reserved);
			foreach (TPRPItem item in items)
			{
				if (item is TPRPParamLabel)
				{
					writer.Write(((TPRPParamLabel)item).PData);
				}
			}

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
			if (header[0] != (uint)FileTypes.TPRP)
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
				{
					items.Add(new TPRPParamLabel(this, reader));
				}

				for (int i = 0; i < localCount; i++)
				{
					items.Add(new TPRPLocalLabel(this, reader));
				}

				reserved = reader.ReadUInt32();
				foreach (TPRPItem item in items)
				{
					if (item is TPRPParamLabel)
					{
						((TPRPParamLabel)item).ReadPData(reader);
					}
				}

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

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.TPRP };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by AbstractWrapper
		protected override string GetResourceName(FileTypeInformation fti)
		{
			if (!Helper.FileFormat)
			{
				return base.GetResourceName(fti);
			}

			Interfaces.Files.IPackedFile pf = Package.Read(FileDescriptor);
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
			get => label;
			set
			{
				if (label != value)
				{
					label = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public bool IsParamLabel => !pORl;

		public bool IsLocalLabel => pORl;
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
			TPRPItem clone = (TPRPItem)MemberwiseClone();
			clone.label = (string)label.Clone();
			clone.pORl = pORl;
			clone.parent = parent;
			return clone;
		}

		/// <summary>
		/// Reads Data from the Stream
		/// </summary>
		/// <param name="reader"></param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			label = Helper.ToString(reader.ReadBytes(reader.ReadByte()));
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
			{
				writer.Write(c);
			}
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
		public byte PData { get; private set; } = 0x01;

		/// <summary>
		/// For the time being, I'm explicitly preventing this value being adjusted
		/// </summary>
		/// <param name="reader">Stream containing a byte to read</param>
		public void ReadPData(System.IO.BinaryReader reader)
		{
			PData = reader.ReadByte();
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
