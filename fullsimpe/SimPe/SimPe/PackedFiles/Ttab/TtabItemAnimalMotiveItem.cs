// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimPe.PackedFiles.Ttab
{
	public class TtabItemAnimalMotiveItem : TtabItemMotiveItem, ICollection<TtabItemSingleMotiveItem>
	{
		#region Attributes
		private List<TtabItemSingleMotiveItem> items =
			new List<TtabItemSingleMotiveItem>();
		#endregion

		#region Accessor Methods
		// All covered by ICollection
		public TtabItemSingleMotiveItem this[int index] => items[index];
		#endregion

		public TtabItemAnimalMotiveItem(TtabItemMotiveGroup parent)
			: base(parent) { }

		public TtabItemAnimalMotiveItem(
			TtabItemMotiveGroup parent,
			System.IO.BinaryReader reader
		)
			: base(parent, reader) { }

		protected override void CopyTo(TtabItemMotiveItem target, bool doEvent)
		{
			if (!(target is TtabItemAnimalMotiveItem))
			{
				throw new ArgumentException("Argument must be of same type", "target");
			}

			((TtabItemAnimalMotiveItem)target).items = items.Select(item => item.Clone(target.Parent)).Cast<TtabItemSingleMotiveItem>().ToList();
			if (doEvent && target.Wrapper != null)
			{
				target.Wrapper.OnWrapperChanged(target, new EventArgs());
			}
		}

		public override TtabItemMotiveItem Clone(TtabItemMotiveGroup parent)
		{
			TtabItemAnimalMotiveItem clone = new TtabItemAnimalMotiveItem(parent);
			CopyTo(clone, false);
			return clone;
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			int count = reader.ReadInt32();
			items = new List<TtabItemSingleMotiveItem>();
			for (int i = 0; i < count; i++)
			{
				items.Add(new TtabItemSingleMotiveItem(parent, reader));
			}
		}

		internal override void Serialize(System.IO.BinaryWriter writer)
		{
			int entries = items.Select((item, i) => (item, i)).Where(item => item.item.InUse).Select(item => item.i).Last() + 1;
			writer.Write(entries);
			for (int i = 0; i < entries; i++)
			{
				items[i].Serialize(writer);
			}
		}

		public void Add(TtabItemSingleMotiveItem item)
		{
			((ICollection<TtabItemSingleMotiveItem>)items).Add(item);
		}

		public void Clear()
		{
			((ICollection<TtabItemSingleMotiveItem>)items).Clear();
		}

		public bool Contains(TtabItemSingleMotiveItem item)
		{
			return ((ICollection<TtabItemSingleMotiveItem>)items).Contains(item);
		}

		public void CopyTo(TtabItemSingleMotiveItem[] array, int arrayIndex)
		{
			((ICollection<TtabItemSingleMotiveItem>)items).CopyTo(array, arrayIndex);
		}

		public bool Remove(TtabItemSingleMotiveItem item)
		{
			return ((ICollection<TtabItemSingleMotiveItem>)items).Remove(item);
		}

		public IEnumerator<TtabItemSingleMotiveItem> GetEnumerator()
		{
			return ((IEnumerable<TtabItemSingleMotiveItem>)items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)items).GetEnumerator();
		}

		public override bool InUse => items.Any(item => item.InUse);

		public int Count => ((ICollection<TtabItemSingleMotiveItem>)items).Count;

		public bool IsReadOnly => ((ICollection<TtabItemSingleMotiveItem>)items).IsReadOnly;
	}
}
