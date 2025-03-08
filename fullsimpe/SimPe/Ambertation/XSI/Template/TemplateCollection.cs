// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.ComponentModel;

namespace Ambertation.XSI.Template
{
	public class TemplateCollection : IEnumerable, IDisposable
	{
		protected ArrayList childs;

		protected Container parent;

		[Browsable(false)]
		public Container Parent => parent;

		[Category("Basic")]
		public int Count => childs.Count;

		public ITemplate this[int index] => (ITemplate)childs[index];

		public ITemplate this[string name]
		{
			get
			{
				int item = GetItem(name, 0);
				if (item == -1)
				{
					return null;
				}

				return this[item];
			}
		}

		public ITemplate this[Type t]
		{
			get
			{
				int item = GetItem(t, 0);
				if (item == -1)
				{
					return null;
				}

				return this[item];
			}
		}

		public TemplateCollection(Container parent)
		{
			childs = new ArrayList();
			this.parent = parent;
		}

		internal void Add(ITemplate pd)
		{
			childs.Add(pd);
		}

		public bool Contains(ITemplate pd)
		{
			return childs.Contains(pd);
		}

		public void Remove(ITemplate pd)
		{
			childs.Remove(pd);
		}

		public void Clear(bool rec)
		{
			if (rec)
			{
				foreach (ITemplate child in childs)
				{
					if (child is Container)
					{
						((Container)child).Clear(rec);
					}
				}
			}

			childs.Clear();
		}

		public int GetItem(string name, int start)
		{
			for (int i = start; i < Count; i++)
			{
				if (this[i].Name == name)
				{
					return i;
				}
			}

			return -1;
		}

		public int GetItem(Type t, int start)
		{
			for (int i = start; i < Count; i++)
			{
				if ((object)this[i].GetType() == t)
				{
					return i;
				}
			}

			return -1;
		}

		public virtual void Dispose()
		{
			if (childs != null)
			{
				childs.Clear();
			}

			childs = null;
		}

		public IEnumerator GetEnumerator()
		{
			return childs.GetEnumerator();
		}

		public override string ToString()
		{
			return GetType().Name + " (" + Count + ")";
		}

		public virtual Container CreateChild(string name)
		{
			ITemplate template = TemplateRegistry.Global.ActivateTemplateClass(parent, name);
			if (template != null)
			{
				Add(template);
			}

			return template as Container;
		}
	}
}
