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
using System.Collections;

using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Wrapper;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// Known Types for Slot Items
	/// </summary>
	public enum SlotItemType : ushort
	{
		Container = 0,
		Location = 1,
		Unknown = 2,
		Routing = 3,
		Target = 4,
	}

	/// <summary>
	/// contains a Slot Item
	/// </summary>
	public class SlotItem
	{
		#region Attributes
		public SlotItemType Type
		{
			get; set;
		}

		#endregion
		public Slot Parent
		{
			get; private set;
		}

		public float UnknownFloat1
		{
			get; set;
		}

		public float UnknownFloat2
		{
			get; set;
		}

		public float UnknownFloat3
		{
			get; set;
		}

		public float UnknownFloat4
		{
			get; set;
		}

		public float UnknownFloat5
		{
			get; set;
		}

		public float UnknownFloat6
		{
			get; set;
		}

		public float UnknownFloat7
		{
			get; set;
		}

		public float UnknownFloat8
		{
			get; set;
		}

		public int UnknownInt1
		{
			get; set;
		}

		public int UnknownInt2
		{
			get; set;
		}

		public int UnknownInt3
		{
			get; set;
		}

		public int UnknownInt4
		{
			get; set;
		}

		public int UnknownInt5
		{
			get; set;
		}

		public int UnknownInt6
		{
			get; set;
		}

		public int UnknownInt7
		{
			get; set;
		}

		public int UnknownInt8
		{
			get; set;
		}

		public int UnknownInt9
		{
			get; set;
		}

		public int UnknownInt10
		{
			get; set;
		}

		public short UnknownShort1
		{
			get; set;
		}

		public short UnknownShort2
		{
			get; set;
		}

		public short UnknownShort3
		{
			get; set;
		}

		public SlotItem(Slot parent)
		{
			this.Parent = parent;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			Type = (SlotItemType)reader.ReadUInt16();

			UnknownFloat1 = reader.ReadSingle();
			UnknownFloat2 = reader.ReadSingle();
			UnknownFloat3 = reader.ReadSingle();

			UnknownInt1 = reader.ReadInt32();
			UnknownInt2 = reader.ReadInt32();
			UnknownInt3 = reader.ReadInt32();
			UnknownInt4 = reader.ReadInt32();
			UnknownInt5 = reader.ReadInt32();

			if (Parent.Version >= 5)
			{
				UnknownFloat4 = reader.ReadSingle();
				UnknownFloat5 = reader.ReadSingle();
				UnknownFloat6 = reader.ReadSingle();

				UnknownInt6 = reader.ReadInt32();
			}

			if (Parent.Version >= 6)
			{
				UnknownShort1 = reader.ReadInt16();
				UnknownShort2 = reader.ReadInt16();
			}

			if (Parent.Version >= 7)
				UnknownFloat7 = reader.ReadSingle();
			if (Parent.Version >= 8)
				UnknownInt7 = reader.ReadInt32();
			if (Parent.Version >= 9)
				UnknownInt8 = reader.ReadInt32();
			if (Parent.Version == 10)
				UnknownShort3 = reader.ReadInt16(); // this is in test, before making full use of I need to test, test and fucking test
			if (Parent.Version >= 0x10)
				UnknownFloat8 = reader.ReadSingle();

			if (Parent.Version >= 0x40)
			{
				UnknownInt9 = reader.ReadInt32();
				UnknownInt10 = reader.ReadInt32();
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
		internal void Serialize(System.IO.BinaryWriter writer, Slot parent)
		{
			this.Parent = parent;
			writer.Write((ushort)Type);

			writer.Write(UnknownFloat1);
			writer.Write(UnknownFloat2);
			writer.Write(UnknownFloat3);

			writer.Write(UnknownInt1);
			writer.Write(UnknownInt2);
			writer.Write(UnknownInt3);
			writer.Write(UnknownInt4);
			writer.Write(UnknownInt5);

			if (parent.Version >= 5)
			{
				writer.Write(UnknownFloat4);
				writer.Write(UnknownFloat5);
				writer.Write(UnknownFloat6);

				writer.Write(UnknownInt6);
			}

			if (parent.Version >= 6)
			{
				writer.Write(UnknownShort1);
				writer.Write(UnknownShort2);
			}

			if (parent.Version >= 7)
				writer.Write(UnknownFloat7);
			if (parent.Version >= 8)
				writer.Write(UnknownInt7);
			if (parent.Version >= 9)
				writer.Write(UnknownInt8);
			if (parent.Version == 10)
				writer.Write(UnknownShort3);
			if (parent.Version >= 0x10)
				writer.Write(UnknownFloat8);

			if (parent.Version >= 0x40)
			{
				writer.Write(UnknownInt9);
				writer.Write(UnknownInt10);
			}
		}

		public override string ToString()
		{
			return Type.ToString();
		}
	}

	/// <summary>
	/// Typesave ArrayList for StrIte Objects
	/// </summary>
	public class SlotItems : ArrayList
	{
		public new SlotItem this[int index]
		{
			get
			{
				return ((SlotItem)base[index]);
			}
			set
			{
				base[index] = value;
			}
		}

		public SlotItem this[uint index]
		{
			get
			{
				return ((SlotItem)base[(int)index]);
			}
			set
			{
				base[(int)index] = value;
			}
		}

		public int Add(SlotItem item)
		{
			return base.Add(item);
		}

		public void Insert(int index, SlotItem item)
		{
			base.Insert(index, item);
		}

		public void Remove(SlotItem item)
		{
			base.Remove(item);
		}

		public bool Contains(SlotItem item)
		{
			return base.Contains(item);
		}

		public int Length => this.Count;

		public override object Clone()
		{
			SlotItems list = new SlotItems();
			foreach (SlotItem item in this)
				list.Add(item);

			return list;
		}
	}
}
