// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

namespace SimPe.Plugin.Collections
{
	/// <summary>
	/// Collection of <see cref="NgbhItem"/> Objects
	/// </summary>
	public class NgbhItems : System.IDisposable, IEnumerable
	{
		ArrayList list = new ArrayList();
		Ngbh ngbh;
		public NgbhSlotList Parent
		{
			get;
		}

		internal NgbhItems(NgbhSlotList parent)
		{
			Parent = parent;
			if (parent != null)
			{
				ngbh = parent.Parent;
			}

			list = new ArrayList();
		}

		public NgbhItem AddNew()
		{
			NgbhItem item = new NgbhItem(Parent);
			Add(item);
			return item;
		}

		public NgbhItem InsertNew(int index)
		{
			NgbhItem item = new NgbhItem(Parent);
			Insert(index, item);
			return item;
		}

		public NgbhItem AddNew(SimMemoryType type)
		{
			NgbhItem item = new NgbhItem(Parent, type);
			Add(item);
			return item;
		}

		public NgbhItem InsertNew(int index, SimMemoryType type)
		{
			NgbhItem item = new NgbhItem(Parent, type);
			Insert(index, item);
			return item;
		}

		public void Add(NgbhItem item)
		{
			list.Add(item);
			if (ngbh != null)
			{
				ngbh.Changed = true;
			}
		}

		public void Insert(int index, NgbhItem item)
		{
			list.Insert(index, item);
			if (ngbh != null)
			{
				ngbh.Changed = true;
			}
		}

		public void Remove(NgbhItem item)
		{
			list.Remove(item);
			if (ngbh != null)
			{
				ngbh.Changed = true;
			}
		}

		public void Remove(NgbhItem[] items)
		{
			foreach (NgbhItem item in items)
			{
				Remove(item);
			}

			if (ngbh != null)
			{
				ngbh.Changed = true;
			}
		}

		public void Remove(NgbhItems items)
		{
			foreach (NgbhItem item in items)
			{
				Remove(item);
			}

			if (ngbh != null)
			{
				ngbh.Changed = true;
			}
		}

		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
			if (ngbh != null)
			{
				ngbh.Changed = true;
			}
		}

		public void Clear()
		{
			list.Clear();
			if (ngbh != null)
			{
				ngbh.Changed = true;
			}
		}

		public bool Contains(NgbhItem item)
		{
			return list.Contains(item);
		}

		public void Swap(int i1, int i2)
		{
			if (i1 < 0 || i2 < 0 || i1 >= list.Count || i2 >= list.Count)
			{
				return;
			}

			(list[i2], list[i1]) = (list[i1], list[i2]);

			if (ngbh != null)
			{
				ngbh.Changed = true;
			}
		}

		public NgbhItem this[int index]
		{
			get => list[index] as NgbhItem;
			set
			{
				list[index] = value;
				if (ngbh != null)
				{
					ngbh.Changed = true;
				}
			}
		}

		public int Count => list.Count;

		public int Length => list.Count;

		public NgbhItems Clone()
		{
			return Clone(Parent);
		}

		public NgbhItems Clone(NgbhSlotList newparent)
		{
			NgbhItems ret = new NgbhItems(newparent);
			foreach (NgbhItem i in list)
			{
				ret.Add(i);
			}

			return ret;
		}

		public const uint MIN_INVENTORY_NUMBER = 1000;

		internal uint GetMaxInventoryNumber()
		{
			uint nr = MIN_INVENTORY_NUMBER - 1;
			foreach (NgbhItem i in list)
			{
				if (i.InventoryNumber > nr)
				{
					nr = i.InventoryNumber;
				}
			}

			return nr;
		}

		public NgbhItem FindItemByGuid(uint guid)
		{
			foreach (NgbhItem i in list)
			{
				if (i.Guid == guid)
				{
					return i;
				}
			}

			return null;
		}

		public int CountItemsByGuid(uint guid)
		{
			int j = 0;
			foreach (NgbhItem i in list)
			{
				if (i.Guid == guid && !i.IsGossip)
				{
					j++;
				}
			}

			return j;
		}

		#region IDisposable Member

		public void Dispose()
		{
			list?.Clear();

			list = null;
		}

		#endregion

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion
	}
}
