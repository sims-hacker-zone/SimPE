// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;

namespace SimPe.Plugin.Collections
{
	/// <summary>
	/// Collection of <see cref="BnfoCustomerItem"/> Objects
	/// </summary>
	public class BnfoCustomerItems : System.IDisposable, IEnumerable<Bnfo.BnfoCustomerItem>
	{
		private List<Bnfo.BnfoCustomerItem> list = new List<Bnfo.BnfoCustomerItem>();
		Bnfo.Bnfo parent;

		internal BnfoCustomerItems(Bnfo.Bnfo parent)
		{
			this.parent = parent;
		}

		public Bnfo.BnfoCustomerItem AddNew(ushort inst)
		{
			Bnfo.BnfoCustomerItem s = new Bnfo.BnfoCustomerItem(parent)
			{
				SimInstance = inst
			};

			Add(s);

			return s;
		}

		public void Add(Bnfo.BnfoCustomerItem item)
		{
			list.Add(item);
		}

		public void Remove(Bnfo.BnfoCustomerItem item)
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

		public bool Contains(Bnfo.BnfoCustomerItem item)
		{
			return list.Contains(item);
		}

		public Bnfo.BnfoCustomerItem this[int index]
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

		public BnfoCustomerItems Clone(Bnfo.Bnfo newparent)
		{
			BnfoCustomerItems ret = new BnfoCustomerItems(newparent);
			foreach (Bnfo.BnfoCustomerItem s in list)
			{
				ret.Add(s);
			}

			return ret;
		}

		public Bnfo.BnfoCustomerItem GetInstanceItem(ushort instance)
		{
			return GetInstanceItem(instance, false);
		}

		public Bnfo.BnfoCustomerItem GetInstanceItem(ushort instance, bool create)
		{
			foreach (Bnfo.BnfoCustomerItem s in list)
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

		public IEnumerator<Bnfo.BnfoCustomerItem> GetEnumerator()
		{
			return ((IEnumerable<Bnfo.BnfoCustomerItem>)list).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)list).GetEnumerator();
		}

		#endregion
	}
}
