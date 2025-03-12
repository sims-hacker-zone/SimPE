// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;

namespace Ambertation.Geometry.Collections
{
	public class IndexedWeightCollection : IDisposable, IElementCollection, IEnumerable
	{
		private ArrayList list;

		public int Count => list.Count;

		public IndexedWeight this[int index] => (IndexedWeight)list[index];

		public IndexedWeightCollection()
		{
			list = new ArrayList();
		}

		public void Add(object o)
		{
			if (!(o is IndexedWeight))
			{
				throw new GeometryException("This collection takes only Instances of the class Ambertation.IndexedWeight.");
			}

			Add((IndexedWeight)o);
		}

		public void Add(IndexedWeight pd)
		{
			list.Add(pd);
		}

		public bool Contains(IndexedWeight pd)
		{
			return list.Contains(pd);
		}

		public void Remove(IndexedWeight pd)
		{
			list.Remove(pd);
		}

		public void Clear()
		{
			list.Clear();
		}

		public object GetItem(int index)
		{
			if (index < 0 || index >= Count)
			{
				return null;
			}

			return (IndexedWeight)list[index];
		}

		public void SetItem(int index, object o)
		{
			if (index >= 0 && index < Count)
			{
				if (!(o is IndexedWeight))
				{
					throw new Exception("This collection takes only Instances of the class Ambertation.IndexedWeight.");
				}

				list[index] = o as IndexedWeight;
			}
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

		public void CopyTo(IndexedWeightCollection v, bool clear)
		{
			if (clear)
			{
				v.Clear();
			}

			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					v.Add(current);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}
}
