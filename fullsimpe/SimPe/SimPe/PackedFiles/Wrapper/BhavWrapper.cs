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
	/// More or less implements IList but is strongly typed
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Bhav
		: pjse.ExtendedWrapper<
			Instruction,
			Bhav
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
		/// Returns the Header
		/// </summary>
		public BhavHeader Header
		{
			get;
		}
		#endregion


		public Bhav()
			: base()
		{
			Header = new BhavHeader(this);
		}

		private void SortSwap(int a, int b)
		{
			Instruction i = this[a];
			this[a] = this[b];
			this[b] = i;

			foreach (Instruction item in this)
			{
				if (item.Target1 == a)
				{
					item.Target1 = (ushort)b;
				}
				else if (item.Target1 == b)
				{
					item.Target1 = (ushort)a;
				}

				if (item.Target2 == a)
				{
					item.Target2 = (ushort)b;
				}
				else if (item.Target2 == b)
				{
					item.Target2 = (ushort)a;
				}
			}
		}

		/// <summary>
		/// Moves an instruction from position 'from' to position 'to', renumbering Targets as required
		/// </summary>
		/// <param name="from">starting position</param>
		/// <param name="to">ending position</param>
		public new void Move(int from, int to)
		{
			if (from == to)
			{
				return;
			}

			if (from < 0 || from >= Count)
			{
				return;
			}

			if (to < 0 || to >= Count)
			{
				return;
			}

			while (from < to)
			{
				SortSwap(from, ++from);
			}

			while (from > to)
			{
				SortSwap(from, --from);
			}

			OnWrapperChanged(items, new EventArgs());
		}

		// only allow 32K or 128 lines
		public new void Add(Instruction item)
		{
			Add(item, Header.Format < 0x8007 ? 0x80 : 0x8000);
		}

		public new void Insert(int index, Instruction item)
		{
			bool savedstate = internalchg;
			internalchg = true;
			Add(item);
			internalchg = savedstate;
			Move(Count - 1, index);
		}

		public new bool Remove(Instruction item)
		{
			Move(IndexOf(item), Count - 1);
			return base.Remove(item);
		}

		public new void RemoveAt(int index)
		{
			Remove(this[index]);
		}

		public new void Sort()
		{
			int start = 0; // where we got to on True pass
			int startnext = 0; // where we got to on False pass

			bool savedstate = internalchg;
			bool somethingchanged = false;
			internalchg = true;
			while (start < items.Count)
			{
				for (int i = start; i < items.Count; i++)
				{
					start = i + 1;
					if (items[i].Target1 <= i || items[i].Target1 >= items.Count)
					{
						if (items[i].Target2 <= i || items[i].Target2 >= items.Count)
						{
							break;
						}

						Move(items[i].Target2, start);
						somethingchanged = true;

						continue;
					}
					if (items[i].Target1 != start)
					{
						Move(items[i].Target1, start);
						somethingchanged = true;
					}
				}
				if (start >= items.Count)
				{
					break;
				}

				for (int i = startnext; i < start; i++)
				{
					startnext = i + 1;
					if (items[i].Target2 < start || items[i].Target2 >= items.Count)
					{
						continue;
					}

					Move(items[i].Target2, start);
					somethingchanged = true;
					break;
				}
			}
			internalchg = savedstate;
			if (somethingchanged)
			{
				OnWrapperChanged(items, new EventArgs());
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
			return new UserInterface.BhavForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			///
			/// TODO: Change the Description passed here
			///
			return new AbstractWrapperInfo(
				"PJSE BHAV Wrapper",
				"Peter L Jones",
				"Advanced SimAntics Editor",
				3
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
			Header.InstructionCount = (ushort)items.Count; // oh please... because header doesn't have a parent (yet!)
			Header.Serialize(writer);
			foreach (Instruction i in items)
			{
				i.Serialize(writer);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(0x40);
			Header.Unserialize(reader);

			items = new List<Instruction>();
			while (items.Count < Header.InstructionCount)
			{
				items.Add(new Instruction(this, reader));
			}
		}

		#endregion

		public const uint Bhavtype = 0x42484156;

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[] { Bhavtype };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by AbstractWrapper
		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!Helper.FileFormat)
			{
				return base.GetResourceName(ta);
			}

			Interfaces.Files.IPackedFile pf = Package.Read(FileDescriptor);
			byte[] ab = pf.GetUncompressedData(0x42);
			return (
					ab.Length > 0x41
						? "0x"
							+ Helper.HexString(ab[0x41])
							+ Helper.HexString(ab[0x40])
							+ ": "
						: ""
				) + Helper.ToString(pf.GetUncompressedData(0x40));
		}
		#endregion
	}

	/// <summary>
	/// Class containing a BHAV Header
	/// </summary>
	public class BhavHeader
	{
		#region Attributes
		private Bhav wrapper;
		private ushort format = 0x8007;
		private ushort count = 0;
		private byte type = 0;
		private byte argc = 0;
		private byte locals = 0;
		private byte headerflag = 0;
		private uint treeversion = 0;
		private byte cacheflags = 0;
		#endregion

		#region Accessor methods
		public ushort Format
		{
			get => format;
			set
			{
				if (format != value)
				{
					format = value;
					wrapper.OnWrapperChanged(wrapper, new EventArgs());
				}
			}
		}

		public ushort InstructionCount
		{
			get => count;
			set
			{
				if (count != value)
				{
					count = value;
					wrapper.OnWrapperChanged(wrapper, new EventArgs());
				}
			}
		}

		public byte Type
		{
			get => type;
			set
			{
				if (type != value)
				{
					type = value;
					wrapper.OnWrapperChanged(wrapper, new EventArgs());
				}
			}
		}

		public byte ArgumentCount
		{
			get => argc;
			set
			{
				if (argc != value)
				{
					argc = value;
					wrapper.OnWrapperChanged(wrapper, new EventArgs());
				}
			}
		}

		public byte LocalVarCount
		{
			get => locals;
			set
			{
				if (locals != value)
				{
					locals = value;
					wrapper.OnWrapperChanged(wrapper, new EventArgs());
				}
			}
		}

		public byte HeaderFlag
		{
			get => headerflag;
			set
			{
				if (headerflag != value)
				{
					headerflag = value;
					wrapper.OnWrapperChanged(wrapper, new EventArgs());
				}
			}
		}

		public uint TreeVersion
		{
			get => treeversion;
			set
			{
				if (treeversion != value)
				{
					treeversion = value;
					wrapper.OnWrapperChanged(wrapper, new EventArgs());
				}
			}
		}

		public byte CacheFlags
		{
			get => cacheflags;
			set
			{
				if (cacheflags != value)
				{
					cacheflags = value;
					wrapper.OnWrapperChanged(wrapper, new EventArgs());
				}
			}
		}

		#endregion

		public BhavHeader(Bhav wrapper)
		{
			this.wrapper = wrapper;
		}

		/// <summary>
		/// Reads the Data from a Stream
		/// </summary>
		/// <param name="reader"></param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			format = reader.ReadUInt16(); //0x0040 - format
			count = reader.ReadUInt16(); //0x0042 - # of opcodes
			type = reader.ReadByte(); //0x0044 - tree type
			argc = reader.ReadByte(); //0x0045 - # of args
			locals = reader.ReadByte(); //0x0046 - # of locals
			headerflag = reader.ReadByte(); //0x0047 - header flag
			treeversion = reader.ReadUInt32(); //0x0048 - Tree version (4 bytes)
			if (format > 0x8008)
			{
				cacheflags = reader.ReadByte();
			}
			else
			{
				cacheflags = 0;
			}
		}

		/// <summary>
		/// Writes the Data to a Stream
		/// </summary>
		/// <param name="writer"></param>
		public void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(format);
			writer.Write(count);
			writer.Write(type);
			writer.Write(argc);
			writer.Write(locals);
			writer.Write(headerflag);
			writer.Write(treeversion);
			if (format == 0x8009)
			{
				writer.Write(cacheflags);
			}
		}
	}

	/// <summary>
	/// Class representing an Instruction
	/// </summary>
	public class Instruction : pjse.ExtendedWrapperItem<Bhav, Instruction>
	{
		#region Attributes
		private ushort opcode = 0;
		private ushort addr1 = 0;
		private ushort addr2 = 0;
		private byte nodeversion = 0;
		private static readonly byte[] nooperands =
		{
			0xff,
			0xff,
			0xff,
			0xff,
			0xff,
			0xff,
			0xff,
			0xff,
		};
		#endregion

		#region Accessor methods
		public ushort OpCode
		{
			get => opcode;
			set
			{
				if (opcode != value)
				{
					opcode = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort Target1
		{
			get => addr1;
			set
			{
				if (addr1 != value)
				{
					addr1 = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public ushort Target2
		{
			get => addr2;
			set
			{
				if (addr2 != value)
				{
					addr2 = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public byte NodeVersion
		{
			get => nodeversion;
			set
			{
				if (nodeversion != value)
				{
					nodeversion = value;
					parent.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public wrappedByteArray Operands { get; private set; } = null;

		public wrappedByteArray Reserved1 { get; private set; } = null;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Instruction(Bhav parent)
		{
			this.parent = parent;
			Operands = new wrappedByteArray(this, (byte[])nooperands.Clone());
			Reserved1 = new wrappedByteArray(this, new byte[8]);
		}

#if UNUSED
		/// <summary>
		/// Constructor
		/// </summary>
		internal Instruction(Bhav parent, ushort opcode)
			: this(parent)
		{
			this.opcode = opcode;
		}
#endif

#if UNUSED
		/// <summary>
		/// Constructor
		/// </summary>
		internal Instruction(
			Bhav parent,
			ushort opcode,
			ushort addr1,
			ushort addr2,
			byte nodeversion,
			byte[] operands,
			byte[] reserved_01
		)
		{
			this.parent = parent;
			this.opcode = opcode;
			this.addr1 = formatSpecificSetAddr(addr1);
			this.addr2 = formatSpecificSetAddr(addr2);
			this.nodeversion = nodeversion;
			this.operands = new wrappedByteArray(this, operands);
			this.reserved_01 = new wrappedByteArray(this, reserved_01);
		}
#endif

		/// <summary>
		/// Constructor
		/// </summary>
		internal Instruction(Bhav parent, System.IO.BinaryReader reader)
		{
			this.parent = parent;
			Unserialize(reader);
		}

		public Instruction Clone()
		{
			Instruction clone = new Instruction(parent)
			{
				opcode = opcode,
				addr1 = addr1,
				addr2 = addr2,
				nodeversion = nodeversion,
				Operands = Operands.Clone()
			};
			clone.Operands.Parent = clone;
			clone.Reserved1 = Reserved1.Clone();
			clone.Reserved1.Parent = clone;
			return clone;
		}

		private ushort formatSpecificSetAddr(ushort addr)
		{
			if (parent.Header.Format < 0x8007)
			{
				switch (addr)
				{
					case 0x00FD:
						return 0xFFFC; // error
					case 0x00FE:
						return 0xFFFD; // true
					case 0x00FF:
						return 0xFFFE; // false
					default:
						return addr;
				}
			}

			return addr;
		}

		/// <summary>
		/// Reads the Data from a Stream
		/// </summary>
		/// <param name="format"></param>
		/// <param name="reader"></param>
		private void Unserialize(System.IO.BinaryReader reader)
		{
			opcode = reader.ReadUInt16();
			if (parent.Header.Format < 0x8007)
			{
				addr1 = formatSpecificSetAddr(reader.ReadByte());
				addr2 = formatSpecificSetAddr(reader.ReadByte());
			}
			else
			{
				addr1 = formatSpecificSetAddr(reader.ReadUInt16());
				addr2 = formatSpecificSetAddr(reader.ReadUInt16());
			}

			if (parent.Header.Format < 0x8003)
			{
				nodeversion = 0;
				Operands = new wrappedByteArray(this, reader);
				Reserved1 = new wrappedByteArray(this, new byte[8]);
			}
			else if (parent.Header.Format < 0x8005)
			{
				nodeversion = 0;
				Operands = new wrappedByteArray(this, reader);
				Reserved1 = new wrappedByteArray(this, reader);
			}
			else
			{
				nodeversion = reader.ReadByte();
				Operands = new wrappedByteArray(this, reader);
				Reserved1 = new wrappedByteArray(this, reader);
			}
		}

		private ushort formatSpecificGetAddr(ushort target)
		{
			if (parent.Header.Format < 0x8007)
			{
				switch (target)
				{
					case 0xFFFC:
						return 0x00FD; // error
					case 0xFFFD:
						return 0x00FE; // true
					case 0xFFFE:
						return 0x00FF; // false
					default:
						return (ushort)(target & 0x00FF);
				}
			}

			return target;
		}

		/// <summary>
		/// Writes the Data to a Stream
		/// </summary>
		/// <param name="format"></param>
		/// <param name="writer"></param>
		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(opcode);
			if (parent.Header.Format < 0x8007)
			{
				writer.Write((byte)formatSpecificGetAddr(addr1));
				writer.Write((byte)formatSpecificGetAddr(addr2));
			}
			else
			{
				writer.Write(formatSpecificGetAddr(addr1));
				writer.Write(formatSpecificGetAddr(addr2));
			}

			if (parent.Header.Format < 0x8003)
			{
				Operands.Serialize(writer);
			}
			else if (parent.Header.Format < 0x8005)
			{
				Operands.Serialize(writer);
				;
				Reserved1.Serialize(writer);
			}
			else
			{
				writer.Write(nodeversion);
				Operands.Serialize(writer);
				Reserved1.Serialize(writer);
			}
		}
	}

	public class wrappedByteArray
	{
		private byte[] array;
		private Instruction parent;

		public wrappedByteArray(Instruction parent, byte[] array)
		{
			this.parent = parent;
			this.array = array;
		}

		public wrappedByteArray(Instruction parent, System.IO.BinaryReader reader)
		{
			this.parent = parent;
			array = new byte[8];
			Unserialize(reader);
		}

		public byte this[int index]
		{
			get => array[index];
			set
			{
				if (array[index] != value)
				{
					array[index] = value;
					if (parent != null)
					{
						parent.Parent.OnWrapperChanged(parent, new EventArgs());
					}
				}
			}
		}

		internal wrappedByteArray Clone()
		{
			return new wrappedByteArray(parent, (byte[])array.Clone());
		}

		public static implicit operator byte[](wrappedByteArray a)
		{
			return (byte[])a.array.Clone();
		}

		internal Instruction Parent
		{
			set => parent = value;
		}

		private void Unserialize(System.IO.BinaryReader reader)
		{
			array = reader.ReadBytes(8);
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(array);
		}
	}
}
