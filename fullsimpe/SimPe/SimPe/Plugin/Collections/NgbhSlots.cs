// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

namespace SimPe.Plugin.Collections
{
	/// <summary>
	/// Collection of <see cref="NgbhSlot"/> Objects
	/// </summary>
	public class NgbhSlots : System.IDisposable, IEnumerable
	{
		ArrayList list = new ArrayList();
		Ngbh parent;

		public Data.NeighborhoodSlots Type
		{
			get;
		}

		internal NgbhSlots(Ngbh parent, Data.NeighborhoodSlots type)
		{
			list = new ArrayList();
			this.parent = parent;
			Type = type;
		}

		public NgbhSlot AddNew(uint inst)
		{
			NgbhSlot s = new NgbhSlot(parent, Type)
			{
				SlotID = inst
			};

			Add(s);

			return s;
		}

		public void Add(NgbhSlot item)
		{
			list.Add(item);
			if (parent != null)
			{
				parent.Changed = true;
			}
		}

		public void Remove(NgbhSlot item)
		{
			list.Remove(item);
			if (parent != null)
			{
				parent.Changed = true;
			}
		}

		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
			if (parent != null)
			{
				parent.Changed = true;
			}
		}

		public void Clear()
		{
			list.Clear();
			if (parent != null)
			{
				parent.Changed = true;
			}
		}

		public bool Contains(NgbhSlot item)
		{
			return list.Contains(item);
		}

		public NgbhSlot this[int index]
		{
			get => list[index] as NgbhSlot;
			set
			{
				list[index] = value;
				if (parent != null)
				{
					parent.Changed = true;
				}
			}
		}

		public int Count => list.Count;

		public int Length => list.Count;

		public NgbhSlots Clone()
		{
			return Clone(parent);
		}

		public NgbhSlots Clone(Ngbh newparent)
		{
			NgbhSlots ret = new NgbhSlots(newparent, Type);
			foreach (NgbhSlot s in list)
			{
				ret.Add(s);
			}

			return ret;
		}

		/// <summary>
		/// Returns a List of all items stored for a Sim in the gven Slot
		/// </summary>
		/// <param name="slots">The Slots of a sertain Block</param>
		/// <param name="instance">Instance Number of a Sim</param>
		/// <returns>the Slot for the given Sim or null</returns>
		public NgbhSlot GetInstanceSlot(uint instance)
		{
			return GetInstanceSlot(instance, false);
		}

		/// <summary>
		/// Returns a List of all items stored for a Sim in the gven Slot
		/// </summary>
		/// <param name="slots">The Slots of a sertain Block</param>
		/// <param name="instance">Instance Number of a Sim</param>
		/// <returns>the Slot for the given Sim or null</returns>
		public NgbhSlot GetInstanceSlot(uint instance, bool create)
		{
			foreach (NgbhSlot s in list)
			{
				if (s.SlotID == instance)
				{
					return s;
				}
			}

			return create ? AddNew(instance) : null;
		}

		#region IDisposable Member

		public void Dispose()
		{
			list?.Clear();

			list = null;
		}

		#endregion

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion
	}
}
