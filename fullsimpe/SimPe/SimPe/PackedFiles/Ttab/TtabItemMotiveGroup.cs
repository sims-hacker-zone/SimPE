// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimPe.PackedFiles.Ttab
{
	public class TtabItemMotiveGroup : ICollection<TtabItemMotiveItem>
	{
		#region Attributes
		private int count;
		private TtabItemMotiveTableType type;
		private List<TtabItemMotiveItem> items = new List<TtabItemMotiveItem>();
		#endregion

		#region Accessor Methods
		public TtabItemMotiveItem this[int index] => items[index];
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

			items.Clear();
			if (type == TtabItemMotiveTableType.Human)
			{
				for (int i = 0; i < nrItems; i++)
				{
					items.Add(new TtabItemSingleMotiveItem(this));
				}
				for (int i = nrItems; i < 16; i++)
				{
					items.Add(new TtabItemSingleMotiveItem(this));
				}
			}
			else
			{
				for (int i = 0; i < nrItems; i++)
				{
					items.Add(new TtabItemAnimalMotiveItem(this));
				}
				for (int i = nrItems; i < 16; i++)
				{
					items.Add(new TtabItemAnimalMotiveItem(this));
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
			target.items = items?.Select(item => item.Clone(target)).ToList();
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
			items.Clear();
			int nrItems = Wrapper.Format < 0x54 ? count : reader.ReadInt32();

			if (type == TtabItemMotiveTableType.Human)
			{
				for (int i = 0; i < nrItems; i++)
				{
					items.Add(new TtabItemSingleMotiveItem(this, reader));
				}

				for (int i = nrItems; i < 16; i++)
				{
					items.Add(new TtabItemSingleMotiveItem(this));
				}
			}
			else
			{
				for (int i = 0; i < nrItems; i++)
				{
					items.Add(new TtabItemAnimalMotiveItem(this, reader));
				}

				for (int i = nrItems; i < 16; i++)
				{
					items.Add(new TtabItemAnimalMotiveItem(this));
				}
			}
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			int entries = items.Count;
			if (Wrapper.Format >= 0x54)
			{
				writer.Write(entries);
			}

			for (int i = 0; i < entries; i++)
			{
				items[i].Serialize(writer);
			}
		}

		public void Add(TtabItemMotiveItem item)
		{
			((ICollection<TtabItemMotiveItem>)items).Add(item);
		}

		public void Clear()
		{
			((ICollection<TtabItemMotiveItem>)items).Clear();
		}

		public bool Contains(TtabItemMotiveItem item)
		{
			return ((ICollection<TtabItemMotiveItem>)items).Contains(item);
		}

		public void CopyTo(TtabItemMotiveItem[] array, int arrayIndex)
		{
			((ICollection<TtabItemMotiveItem>)items).CopyTo(array, arrayIndex);
		}

		public bool Remove(TtabItemMotiveItem item)
		{
			return ((ICollection<TtabItemMotiveItem>)items).Remove(item);
		}

		public IEnumerator<TtabItemMotiveItem> GetEnumerator()
		{
			return ((IEnumerable<TtabItemMotiveItem>)items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)items).GetEnumerator();
		}

		public bool InUse => items.Any(item => item.InUse);

		public int EntriesInUse => items.Select((item, i) => (item, i)).Where(item => item.item.InUse).Select(item => item.i).LastOrDefault();

		public int Count => ((ICollection<TtabItemMotiveItem>)items).Count;

		public bool IsReadOnly => ((ICollection<TtabItemMotiveItem>)items).IsReadOnly;
	}
}
