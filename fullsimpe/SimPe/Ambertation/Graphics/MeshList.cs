// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;

namespace Ambertation.Graphics
{
	public class MeshList : IEnumerable, IDisposable
	{
		private ArrayList list = new ArrayList();

		public MeshBox this[int index]
		{
			get
			{
				return (MeshBox)list[index];
			}
			set
			{
				OnRemove((MeshBox)list[index]);
				list[index] = value;
				OnAdd(value);
			}
		}

		public int Count => list.Count;

		public MeshList()
		{
			list = new ArrayList();
		}

		public void Add(MeshBox m)
		{
			OnAdd(m);
			list.Add(m);
		}

		public void Insert(int index, MeshBox m)
		{
			OnAdd(m);
			list.Insert(index, m);
		}

		public void AddRange(MeshBox[] m)
		{
			foreach (MeshBox m2 in m)
			{
				Add(m2);
			}
		}

		public void AddRange(MeshList m)
		{
			foreach (MeshBox item in (IEnumerable)m)
			{
				Add(item);
			}
		}

		protected virtual void OnRemove(MeshBox m)
		{
		}

		protected virtual void OnAdd(MeshBox m)
		{
		}

		public void Remove(MeshBox m)
		{
			OnRemove(m);
			list.Remove(m);
		}

		public void RemoveAt(int index)
		{
			try
			{
				MeshBox m = this[index];
				Remove(m);
			}
			catch
			{
			}
		}

		public void Clear()
		{
			Clear(dispose: false);
		}

		public void Clear(bool dispose)
		{
			if (dispose)
			{
				for (int i = 0; i < list.Count; i++)
				{
					this[i].Dispose();
				}
			}

			list.Clear();
		}

		public bool Contains(MeshBox m)
		{
			return list.Contains(m);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		public virtual void Dispose()
		{
			if (list != null)
			{
				Clear(dispose: true);
			}
		}
	}
}
