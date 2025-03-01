// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

namespace SimPe.PackedFiles.Ttab
{
	public class TtabItemMotiveTable : ICollection
	{
		#region Attributes
		private int[] counts = null;
		private TtabItemMotiveTableType type;
		private TtabItemMotiveGroupArrayList items = null;
		#endregion

		#region Accessor Methods
		public Ttab Wrapper => Parent?.Parent;
		public TtabItem Parent
		{
			get; set;
		}
		public TtabItemMotiveTableType Type
		{
			get => type;
			set
			{
				if (type != value)
				{
					type = value;
					Wrapper?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion


		public TtabItemMotiveTable(
			TtabItem parent,
			int[] counts,
			TtabItemMotiveTableType type
		)
		{
			Parent = parent;
			this.counts = counts;
			this.type = type;

			int nrGroups = counts != null ? counts.Length : type == TtabItemMotiveTableType.Human ? 5 : 8;

			items = new TtabItemMotiveGroupArrayList(new TtabItemMotiveGroup[nrGroups]);
			for (int i = 0; i < nrGroups; i++)
			{
				items[i] = new TtabItemMotiveGroup(
					this,
					counts != null ? counts[i] : -1,
					type
				);
			}
		}

		public TtabItemMotiveTable(
			TtabItem parent,
			int[] counts,
			TtabItemMotiveTableType type,
			System.IO.BinaryReader reader
		)
			: this(parent, counts, type)
		{
			Unserialize(reader);
		}

		public void CopyTo(TtabItemMotiveTable target)
		{
			if (target == null)
			{
				return;
			}

			for (int i = 0; i < target.items.Count && i < items.Count; i++)
			{
				target.items[i] = items[i].Clone();
			}

			for (int i = items.Count; i < target.items.Count; i++)
			{
				target.items[i] = items[0].Clone();
			}
		}

		private TtabItemMotiveTable Clone(TtabItem parent)
		{
			TtabItemMotiveTable clone = new TtabItemMotiveTable(parent, counts, type);
			CopyTo(clone);
			return clone;
		}

		private TtabItemMotiveTable Clone()
		{
			return Clone(Parent);
		}

		private void Unserialize(System.IO.BinaryReader reader)
		{
			int nrGroups = counts != null ? counts.Length : reader.ReadInt32();

			if (items.Capacity < nrGroups)
			{
				items = new TtabItemMotiveGroupArrayList(
					new TtabItemMotiveGroup[nrGroups]
				);
			}

			for (int i = 0; i < nrGroups; i++)
			{
				items[i] = new TtabItemMotiveGroup(
					this,
					counts != null ? counts[i] : 0,
					type,
					reader
				);
			}
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			int entries = Wrapper.Format < 0x54 ? items.Count : items.EntriesInUse;
			if (Wrapper.Format >= 0x54)
			{
				writer.Write(entries);
			}

			for (int i = 0; i < entries; i++)
			{
				items[i].Serialize(writer);
			}
		}

		#region TtabItemMotiveGroupArrayList
		private class TtabItemMotiveGroupArrayList : ArrayList
		{
			public TtabItemMotiveGroupArrayList()
				: base() { }

			public TtabItemMotiveGroupArrayList(TtabItemMotiveGroup[] c)
				: base(c) { }

			public TtabItemMotiveGroupArrayList(int capacity)
				: base(capacity) { }

			public new TtabItemMotiveGroup this[int index]
			{
				get => (TtabItemMotiveGroup)base[index];
				set => base[index] = value;
			}

			public TtabItemMotiveGroupArrayList Clone(TtabItemMotiveTable parent)
			{
				TtabItemMotiveGroupArrayList clone = new TtabItemMotiveGroupArrayList();
				foreach (TtabItemMotiveGroup item in this)
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
		#endregion

		#region ICollection Members
		public int Add(TtabItemMotiveGroup item)
		{
			//if (items.Count >= 0x08) // we don't really know...
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
			items.Clear();
			Wrapper?.OnWrapperChanged(this, new EventArgs());
		}

		public void Remove(TtabItemMotiveGroup item)
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

		public TtabItemMotiveGroup this[int index]
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

		public bool Contains(TtabItem item)
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
