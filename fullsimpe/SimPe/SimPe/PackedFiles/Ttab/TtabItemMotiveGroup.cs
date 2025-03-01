// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

namespace SimPe.PackedFiles.Ttab
{
	public class TtabItemMotiveGroup : ICollection
	{
		#region Attributes
		private int count;
		private TtabItemMotiveTableType type;
		private TtabItemMotiveItemArrayList items = null;
		#endregion

		#region Accessor Methods
		public Ttab Wrapper => Parent?.Wrapper;
		public TtabItemMotiveTable Parent
		{
			get; set;
		}
		#endregion

		public TtabItemMotiveGroup(
			TtabItemMotiveTable parent,
			int count,
			TtabItemMotiveTableType type
		)
		{
			Parent = parent;
			this.count = count;
			this.type = type;

			int nrItems = count != -1 ? count : 16;

			items = new TtabItemMotiveItemArrayList(
				new TtabItemMotiveItem[nrItems < 16 ? 16 : nrItems]
			);
			if (type == TtabItemMotiveTableType.Human)
			{
				for (int i = 0; i < nrItems; i++)
				{
					items[i] = new TtabItemSingleMotiveItem(this);
				}
			}
			else
			{
				for (int i = 0; i < nrItems; i++)
				{
					items[i] = new TtabItemAnimalMotiveItem(this);
				}
			}
		}

		public TtabItemMotiveGroup(
			TtabItemMotiveTable parent,
			int count,
			TtabItemMotiveTableType type,
			System.IO.BinaryReader reader
		)
			: this(parent, count, type)
		{
			Unserialize(reader);
		}

		private void CopyTo(TtabItemMotiveGroup target)
		{
			target.items = items?.Clone(target);
		}

		public TtabItemMotiveGroup Clone(TtabItemMotiveTable parent)
		{
			TtabItemMotiveGroup clone = new TtabItemMotiveGroup(parent, count, type);
			CopyTo(clone);
			return clone;
		}

		public TtabItemMotiveGroup Clone()
		{
			return Clone(Parent);
		}

		private void Unserialize(System.IO.BinaryReader reader)
		{
			int nrItems = Wrapper.Format < 0x54 ? count : reader.ReadInt32();

			if (type == TtabItemMotiveTableType.Human)
			{
				for (int i = 0; i < nrItems; i++)
				{
					items[i] = new TtabItemSingleMotiveItem(this, reader);
				}

				for (int i = nrItems; i < items.Count; i++)
				{
					items[i] = new TtabItemSingleMotiveItem(this);
				}
			}
			else
			{
				for (int i = 0; i < nrItems; i++)
				{
					items[i] = new TtabItemAnimalMotiveItem(this, reader);
				}

				for (int i = nrItems; i < items.Count; i++)
				{
					items[i] = new TtabItemAnimalMotiveItem(this);
				}
			}
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			int entries = items.EntriesInUse;
			if (Wrapper.Format >= 0x54)
			{
				writer.Write(entries);
			}

			for (int i = 0; i < entries; i++)
			{
				items[i].Serialize(writer);
			}
		}

		public bool InUse
		{
			get
			{
				foreach (TtabItemMotiveItem i in items)
				{
					if (i.InUse)
					{
						return true;
					}
				}

				return false;
			}
		}

		public int EntriesInUse => items.EntriesInUse;

		private class TtabItemMotiveItemArrayList : ArrayList
		{
			public TtabItemMotiveItemArrayList()
				: base() { }

			public TtabItemMotiveItemArrayList(TtabItemMotiveItem[] c)
				: base(c) { }

			public TtabItemMotiveItemArrayList(int capacity)
				: base(capacity) { }

			public new TtabItemMotiveItem this[int index]
			{
				get => (TtabItemMotiveItem)base[index];
				set => base[index] = value;
			}

			/// <summary>
			/// Creates a deep copy of the TtabItemMotiveItemArrayList
			/// </summary>
			public TtabItemMotiveItemArrayList Clone(TtabItemMotiveGroup parent)
			{
				TtabItemMotiveItemArrayList clone = new TtabItemMotiveItemArrayList();
				foreach (TtabItemMotiveItem item in this)
				{
					clone.Add(item.Clone(parent));
				}

				return clone;
			}

			public override object Clone()
			{
				return Clone(null);
			}

			public int EntriesInUse
			{
				get
				{
					for (int i = Count; i > 0; i--)
					{
						if (this[i - 1].InUse)
						{
							return i;
						}
					}

					return 0;
				}
			}
		}

		#region ICollection Members
		public int Add(TtabItemMotiveItem item)
		{
			//if (items.Count >= 0x10) // we don't really know...
			//return -1;

			item.Parent = this;
			int result = items.Add(item);
			if (result >= 0 && Wrapper != null)
			{
				Wrapper.OnWrapperChanged(this, new EventArgs());
			}

			return result;
		}

		public void Clear()
		{
			for (int i = 0; i < items.Count; i++)
			{
				items[i] =
					type == TtabItemMotiveTableType.Human
						? new TtabItemSingleMotiveItem(this)
						: (TtabItemMotiveItem)new TtabItemAnimalMotiveItem(this);
			}

			Wrapper?.OnWrapperChanged(this, new EventArgs());
		}

		public void Remove(TtabItemMotiveItem item)
		{
			RemoveAt(items.IndexOf(item));
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= items.Count)
			{
				return;
			}

			items.RemoveAt(index);
			Wrapper?.OnWrapperChanged(this, new EventArgs());
		}

		public TtabItemMotiveItem this[int index]
		{
			get => items[index];
			set
			{
				if (items[index] != value)
				{
					items[index] = value;
					if (items[index] != null)
					{
						items[index].Parent = this;
					}

					Wrapper?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public bool Contains(TtabItemMotiveItem item)
		{
			return items.Contains(item);
		}

		public int IndexOf(object item)
		{
			return items.IndexOf(item);
		}

		public void CopyTo(Array a, int i)
		{
			items.CopyTo(a, i);
		}

		public int Count => items.Count;

		public bool IsSynchronized => items.IsSynchronized;

		public object SyncRoot => items.SyncRoot;

		#region IEnumerable Members
		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		#endregion
		#endregion
	}
}
