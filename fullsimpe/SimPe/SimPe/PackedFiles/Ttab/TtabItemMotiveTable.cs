// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimPe.PackedFiles.Ttab
{
	public class TtabItemMotiveTable : ICollection<TtabItemMotiveGroup>
	{
		#region Attributes
		private int[] counts = null;
		private TtabItemMotiveTableType type;
		private List<TtabItemMotiveGroup> items = new List<TtabItemMotiveGroup>();
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

		public int Count => ((ICollection<TtabItemMotiveGroup>)items).Count;

		public bool IsReadOnly => ((ICollection<TtabItemMotiveGroup>)items).IsReadOnly;
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

			for (int i = 0; i < nrGroups; i++)
			{
				items.Add(new TtabItemMotiveGroup(
					this,
					counts != null ? counts[i] : -1,
					type
				));
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
				target.items.Add(items[i].Clone());
			}

			// for (int i = items.Count; i < target.items.Count; i++)
			// {
			// 	target.items.Add(items[0].Clone());
			// }
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
			items.Clear();
			int nrGroups = counts != null ? counts.Length : reader.ReadInt32();

			for (int i = 0; i < nrGroups; i++)
			{
				items.Add(new TtabItemMotiveGroup(
					this,
					counts != null ? counts[i] : 0,
					type,
					reader
				));
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

		public TtabItemMotiveGroup this[int index] => items[index];

		public void Add(TtabItemMotiveGroup item)
		{
			((ICollection<TtabItemMotiveGroup>)items).Add(item);
		}

		public void Clear()
		{
			((ICollection<TtabItemMotiveGroup>)items).Clear();
		}

		public bool Contains(TtabItemMotiveGroup item)
		{
			return ((ICollection<TtabItemMotiveGroup>)items).Contains(item);
		}

		public void CopyTo(TtabItemMotiveGroup[] array, int arrayIndex)
		{
			((ICollection<TtabItemMotiveGroup>)items).CopyTo(array, arrayIndex);
		}

		public bool Remove(TtabItemMotiveGroup item)
		{
			return ((ICollection<TtabItemMotiveGroup>)items).Remove(item);
		}

		public IEnumerator<TtabItemMotiveGroup> GetEnumerator()
		{
			return ((IEnumerable<TtabItemMotiveGroup>)items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)items).GetEnumerator();
		}
	}
}
