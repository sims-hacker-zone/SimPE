// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Interfaces.Wrapper;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	public class GroupCacheItem : IGroupCacheItem
	{
		#region Attributes
		string flname;

		/// <summary>
		/// Returns the FileName for this Item
		/// </summary>
		public string FileName
		{
			get => flname.Trim().ToLower();
			set => flname = value.Trim().ToLower();
		}

		uint unknown1;

		/// <summary>
		/// Returns the Group that was assigned by the Game
		/// </summary>
		public uint LocalGroup
		{
			get; set;
		}
		uint[] unknown2;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public GroupCacheItem()
			: base()
		{
			flname = "";
			unknown2 = new uint[0];
		}

		#region AbstractWrapper Member
		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			int ct = reader.ReadInt32();
			flname = "";
			/*char[] cs = reader.ReadChars(ct);
			for (int i=0; i<cs.Length; i++) flname += cs[i];		*/
			byte[] bs = reader.ReadBytes(ct);
			flname = Helper.ToString(bs);
			unknown1 = reader.ReadUInt32();
			LocalGroup = reader.ReadUInt32();
			unknown2 = new uint[reader.ReadUInt32()];
			for (int i = 0; i < unknown2.Length; i++)
			{
				unknown2[i] = reader.ReadUInt32();
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
			int ct = flname.Length;
			byte[] bs = Helper.ToBytes(flname, 0);
			writer.Write(bs.Length);
			writer.Write(bs);
			writer.Write(unknown1);
			writer.Write(LocalGroup);
			for (int i = 0; i < unknown2.Length; i++)
			{
				writer.Write(unknown2[i]);
			}
		}
		#endregion

		public override string ToString()
		{
			string n = FileName;
			n += " => 0x";
			n += Helper.HexString(unknown1) + ":0x" + Helper.HexString(LocalGroup);
			n += " (";
			for (int i = 0; i < unknown2.Length; i++)
			{
				if (i != 0)
				{
					n += ", ";
				}

				n += Helper.HexString(unknown2[i]);
			}
			n += " )";
			return n;
		}
	}

	/// <summary>
	/// Typesave ArrayList for StrIte Objects
	/// </summary>
	public class GroupCacheItems : ArrayList
	{
		public new GroupCacheItem this[int index]
		{
			get => (GroupCacheItem)base[index];
			set => base[index] = value;
		}

		public GroupCacheItem this[uint index]
		{
			get => (GroupCacheItem)base[(int)index];
			set => base[(int)index] = value;
		}

		public int Add(GroupCacheItem item)
		{
			return base.Add(item);
		}

		public void Insert(int index, GroupCacheItem item)
		{
			base.Insert(index, item);
		}

		public void Remove(GroupCacheItem item)
		{
			base.Remove(item);
		}

		public bool Contains(GroupCacheItem item)
		{
			return base.Contains(item);
		}

		public int Length => Count;

		public override object Clone()
		{
			GroupCacheItems list = new GroupCacheItems();
			foreach (GroupCacheItem item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
}
