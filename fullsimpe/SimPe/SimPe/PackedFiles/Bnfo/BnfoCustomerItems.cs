// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;

namespace SimPe.PackedFiles.Bnfo
{
	/// <summary>
	/// Collection of <see cref="BnfoCustomerItem"/> Objects
	/// </summary>
	public class BnfoCustomerItems : System.IDisposable, IEnumerable<BnfoCustomerItem>
	{
		private List<BnfoCustomerItem> list = new List<BnfoCustomerItem>();
		Bnfo parent;

		internal BnfoCustomerItems(Bnfo parent)
		{
			this.parent = parent;
		}

		public BnfoCustomerItem AddNew(ushort inst)
		{
			BnfoCustomerItem s = new BnfoCustomerItem(parent)
			{
				SimInstance = inst
			};

			Add(s);

			return s;
		}

		public void Add(BnfoCustomerItem item)
		{
			list.Add(item);
		}

		public void Remove(BnfoCustomerItem item)
		{
			list.Remove(item);
		}

		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}

		public void Clear()
		{
			list.Clear();
		}

		public bool Contains(BnfoCustomerItem item)
		{
			return list.Contains(item);
		}

		public BnfoCustomerItem this[int index]
		{
			get => list[index];
			set => list[index] = value;
		}

		public int Count => list.Count;

		public int Length => list.Count;

		public BnfoCustomerItems Clone()
		{
			return Clone(parent);
		}

		public BnfoCustomerItems Clone(Bnfo newparent)
		{
			BnfoCustomerItems ret = new BnfoCustomerItems(newparent);
			foreach (BnfoCustomerItem s in list)
			{
				ret.Add(s);
			}

			return ret;
		}

		public BnfoCustomerItem GetInstanceItem(ushort instance)
		{
			return GetInstanceItem(instance, false);
		}

		public BnfoCustomerItem GetInstanceItem(ushort instance, bool create)
		{
			foreach (BnfoCustomerItem s in list)
			{
				if (s.SimInstance == instance)
				{
					return s;
				}
			}

			return create ? AddNew(instance) : null;
		}

		#region IDisposable Member

		public void Dispose()
		{
			list?.Clear();

			list = null;
		}

		#endregion

		#region IEnumerable Member

		public IEnumerator<BnfoCustomerItem> GetEnumerator()
		{
			return ((IEnumerable<BnfoCustomerItem>)list).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)list).GetEnumerator();
		}

		#endregion
	}
}
