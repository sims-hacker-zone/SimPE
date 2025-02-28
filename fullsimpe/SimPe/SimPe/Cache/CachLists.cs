// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

namespace SimPe.Cache
{
	/// <summary>
	/// Typesave ArrayList for ICacheItem Objects
	/// </summary>
	public class CacheItems : ArrayList
	{
		public new ICacheItem this[int index]
		{
			get => (ICacheItem)base[index];
			set => base[index] = value;
		}

		public ICacheItem this[uint index]
		{
			get => (ICacheItem)base[(int)index];
			set => base[(int)index] = value;
		}

		public int Add(ICacheItem item)
		{
			return base.Add(item);
		}

		public void Insert(int index, ICacheItem item)
		{
			base.Insert(index, item);
		}

		public void Remove(ICacheItem item)
		{
			base.Remove(item);
		}

		public bool Contains(ICacheItem item)
		{
			return base.Contains(item);
		}

		public int Length => Count;

		public override object Clone()
		{
			CacheItems list = new CacheItems();
			foreach (ICacheItem item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}

	/// <summary>
	/// Typesave ArrayList for CacheContainer Objects
	/// </summary>
	public class CacheContainers : ArrayList
	{
		public new CacheContainer this[int index]
		{
			get => (CacheContainer)base[index];
			set => base[index] = value;
		}

		public CacheContainer this[uint index]
		{
			get => (CacheContainer)base[(int)index];
			set => base[(int)index] = value;
		}

		public int Add(CacheContainer item)
		{
			return base.Add(item);
		}

		public void Insert(int index, CacheContainer item)
		{
			base.Insert(index, item);
		}

		public void Remove(CacheContainer item)
		{
			base.Remove(item);
		}

		public bool Contains(CacheContainer item)
		{
			return base.Contains(item);
		}

		public int Length => Count;

		public override object Clone()
		{
			CacheContainers list = new CacheContainers();
			foreach (CacheContainer item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
}
