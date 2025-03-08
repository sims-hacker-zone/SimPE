// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;

using SimPe.Geometry;

namespace Ambertation.Geometry.Collections
{
	public class Vector3iCollection : IDisposable, IElementCollection, IEnumerable
	{
		private ArrayList list;

		public int Count => list.Count;

		public Vector3i this[int index]
		{
			get
			{
				return (Vector3i)list[index];
			}
			set
			{
				list[index] = value;
			}
		}

		public short[] ToArrayOfShort()
		{
			short[] array = new short[Count * 3];
			int num = 0;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Vector3i vector3i = (Vector3i)enumerator.Current;
					array[num++] = (short)vector3i.X;
					array[num++] = (short)vector3i.Y;
					array[num++] = (short)vector3i.Z;
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

			return array;
		}

		public Vector3iCollection()
		{
			list = new ArrayList();
		}

		public void Add(int x, int y, int z)
		{
			Add(new Vector3i(x, y, z));
		}

		public void Add(object o)
		{
			if (!(o is Vector3i))
			{
				throw new GeometryException("This collection takes only Instances of the class Ambertation.Vector3i.");
			}

			Add((Vector3i)o);
		}

		public void Add(Vector3i v)
		{
			list.Add(v);
		}

		public bool Contains(Vector3i v)
		{
			return list.Contains(v);
		}

		public int ContainsAt(Vector3i v)
		{
			return ContainsAt(v, 0);
		}

		public int ContainsAt(Vector3i v, int start)
		{
			for (int i = start; i < Count; i++)
			{
				if (v.Equals(this[i]))
				{
					return i;
				}
			}

			return -1;
		}

		public void Remove(Vector3i v)
		{
			list.Remove(v);
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

			return (Vector3i)list[index];
		}

		public void SetItem(int index, object o)
		{
			if (index >= 0 && index < Count)
			{
				if (!(o is Vector3i))
				{
					throw new Exception("This collection takes only Instances of the class Ambertation.Vector3i.");
				}

				list[index] = o as Vector3i;
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

		public void CopyTo(Vector3iCollection v, bool clear)
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
