// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;

namespace Ambertation.Collections
{
	public class DoubleCollection : IDisposable, IEnumerable
	{
		private ArrayList list;

		public int Count => list.Count;

		public double this[int index]
		{
			get
			{
				return (double)list[index];
			}
			set
			{
				list[index] = value;
			}
		}

		public DoubleCollection()
		{
			list = new ArrayList();
		}

		public void Add(double pd)
		{
			list.Add(pd);
		}

		public bool Contains(double pd)
		{
			return list.Contains(pd);
		}

		public void Remove(double pd)
		{
			list.Remove(pd);
		}

		public void Clear()
		{
			list.Clear();
		}

		public virtual void Dispose()
		{
			if (list != null)
			{
				list.Clear();
			}

			list = null;
		}

		public IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		public override string ToString()
		{
			return GetType().Name + " (" + Count + ")";
		}
	}
}
