// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

namespace SimPe.PackedFiles.Ttab
{
	public class TtabItemAnimalMotiveItem : TtabItemMotiveItem, ICollection
	{
		#region Attributes
		private TtabItemSingleMotiveItemArrayList items =
			new TtabItemSingleMotiveItemArrayList(new TtabItemSingleMotiveItem[0]);
		#endregion

		#region Accessor Methods
		// All covered by ICollection
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
			} ((TtabItemAnimalMotiveItem)target).items =
				items?.Clone((TtabItemAnimalMotiveItem)target);
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
			items = new TtabItemSingleMotiveItemArrayList(
				new TtabItemSingleMotiveItem[count]
			);
			for (int i = 0; i < count; i++)
			{
				items[i] = new TtabItemSingleMotiveItem(parent, reader);
			}
		}

		internal override void Serialize(System.IO.BinaryWriter writer)
		{
			int entries = items.EntriesInUse;
			writer.Write(entries);
			for (int i = 0; i < entries; i++)
			{
				items[i].Serialize(writer);
			}
		}

		public override bool InUse
		{
			get
			{
				foreach (TtabItemSingleMotiveItem i in items)
				{
					if (i.InUse)
					{
						return true;
					}
				}

				return false;
			}
		}

		private class TtabItemSingleMotiveItemArrayList : ArrayList
		{
			public TtabItemSingleMotiveItemArrayList()
				: base() { }

			public TtabItemSingleMotiveItemArrayList(TtabItemSingleMotiveItem[] c)
				: base(c) { }

			public TtabItemSingleMotiveItemArrayList(int capacity)
				: base(capacity) { }

			public new TtabItemSingleMotiveItem this[int index]
			{
				get => (TtabItemSingleMotiveItem)base[index];
				set => base[index] = value;
			}

			/// <summary>
			/// Creates a deep copy of the TtabItemMotiveItemArrayList
			/// </summary>
			public TtabItemSingleMotiveItemArrayList Clone(
				TtabItemAnimalMotiveItem parent
			)
			{
				TtabItemSingleMotiveItemArrayList clone =
					new TtabItemSingleMotiveItemArrayList();
				foreach (TtabItemSingleMotiveItem item in this)
				{
					clone.Add(item.Clone(parent.parent));
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
		public int Add(TtabItemSingleMotiveItem item)
		{
			item.Parent = parent;
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
				items[i] = new TtabItemSingleMotiveItem(parent);
			}

			Wrapper?.OnWrapperChanged(this, new EventArgs());
		}

		public void Remove(TtabItemSingleMotiveItem item)
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

		public TtabItemSingleMotiveItem this[int index]
		{
			get => items[index];
			set
			{
				if (items[index] != value)
				{
					items[index] = value;
					if (items[index] != null)
					{
						items[index].Parent = parent;
					}

					Wrapper?.OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public bool Contains(TtabItemSingleMotiveItem item)
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
