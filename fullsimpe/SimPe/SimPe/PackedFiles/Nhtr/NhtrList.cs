// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections;

using SimPe.Plugin;

namespace SimPe.PackedFiles.Nhtr
{
	public enum NhtrListType : byte
	{
		Trees = 0,
		Roads = 1,
		Bridges = 2,
		Decorations = 3,
	}

	/// <summary>
	/// Summary description for TileItem.
	/// </summary>
	public class NhtrList : IEnumerable
	{
		/*static int[] LENGTHS = new int[] {37, 123, 164, 37};*/

		ushort unknown;
		Nhtr parent;
		NhtrListType type;
		ArrayList list;

		internal NhtrList(Nhtr parent, NhtrListType type)
		{
			this.parent = parent;
			this.type = type;
			list = new ArrayList();

			unknown = type == NhtrListType.Trees || type == NhtrListType.Decorations ? (ushort)8 : (ushort)3;
		}

		public NhtrItem AddNew()
		{
			NhtrItem item;
			if (type == NhtrListType.Decorations)
			{
				item = new NhtrDecorationItem(this);
			}
			else if (type == NhtrListType.Trees)
			{
				item = new NhtrTreeItem(this);
			}
			else if (type == NhtrListType.Roads)
			{
				item = new NhtrRoadItem(this);
			}
			else if (type == NhtrListType.Bridges)
			{
				item = new NhtrBridgeItem(this);
			}
			else
			{
				return null;
			}

			Add(item);
			return item;
		}

		public void Add(NhtrItem item)
		{
			list.Add(item);
		}

		public void Remove(NhtrItem item)
		{
			list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		public int Count => list.Count;

		public NhtrItem this[int index] => list[index] as NhtrItem;

		internal virtual void Unserialize(System.IO.BinaryReader reader)
		{
			unknown = reader.ReadUInt16();
			int ct = reader.ReadInt32();
			list.Clear();
			for (int i = 0; i < ct; i++)
			{
				NhtrItem item = AddNew();
				item.Unserialize(reader);
			}
		}

		internal virtual void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(unknown);
			writer.Write(list.Count);
			foreach (NhtrItem i in list)
			{
				i.Serialize(writer);
			}
		}

		public override string ToString()
		{
			return type.ToString()
				+ ": "
				+ list.Count
				+ " items [0x"
				+ unknown.ToString()
				+ "]";
		}

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion
	}
}
