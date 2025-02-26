/***************************************************************************
 *   Copyright (C) 2005,2008 by Peter L Jones                              *
 *   pljones@users.sf.net                                                  *
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Wrapper;
using SimPe.Plugin;

using Bhav = SimPe.PackedFiles.Wrapper.Bhav;

namespace pjse
{
	public abstract class ExtendedWrapper : AbstractWrapper, IMultiplePackedFileWrapper //Allow Multiple Instances
	{
		/// <summary>
		/// Indicates the data content of the wrapper (packed file) has changed
		/// </summary>
		public event EventHandler WrapperChanged;

		/// <summary>
		/// Indicates a wrapper routine is updating the wrapper and will generate the WrapperChanged event
		/// </summary>
		protected bool internalchg = false;

		public ExtendedWrapper()
			: base() { }

		public virtual void OnWrapperChanged(object sender, EventArgs e)
		{
			this.Changed = true;

			if (internalchg)
				return;
			if (WrapperChanged != null)
			{
				WrapperChanged(sender, e);
			}
		}

		/// <summary>
		/// This object's group
		/// </summary>
		public uint PrivateGroup
		{
			get
			{
				if (Context == Scope.Global || Context == Scope.SemiGlobal)
					return 0;

				return this.FileDescriptor.Group;
			}
		}

		/// <summary>
		/// The SemiGlobal group for this object
		/// </summary>
		public uint SemiGroup
		{
			get
			{
				if (Context == Scope.Global)
					return 0;

				Glob glob = BhavWiz.GlobByGroup(this.FileDescriptor.Group);
				return (
					glob != null ? glob.SemiGlobalGroup : this.FileDescriptor.Group
				);
			}
		}

		/// <summary>
		/// The Global group
		/// </summary>
		public uint GlobalGroup
		{
			get
			{
				return (uint)pjse.Group.Global;
			}
		}

		public Scope Context
		{
			get
			{
				if (
					(
						this is Bhav
						|| this is TPRP
						|| this is SimPe.PackedFiles.Wrapper.Bcon
						|| this is Trcn
					)
					&& this.FileDescriptor != null
				)
				{
					if (this.FileDescriptor.Instance < 0x1000)
						return Scope.Global;
					else if (this.FileDescriptor.Instance < 0x2000)
						return Scope.Private;
					else
						return Scope.SemiGlobal;
				}
				else
					return Scope.Private; // at least for now
			}
		}

		public uint GroupForScope(Scope s)
		{
			if (s == Scope.Global)
				return GlobalGroup;
			if (s == Scope.SemiGlobal)
				return SemiGroup;
			return PrivateGroup;
		}

		public uint GroupForContext
		{
			get
			{
				return GroupForScope(Context);
			}
		}

		public pjse.FileTable.Entry ResourceByInstance(uint type, uint instance)
		{
			return ResourceByInstance(type, instance, FileTable.Source.Any);
		}

		public pjse.FileTable.Entry ResourceByInstance(
			uint type,
			uint instance,
			FileTable.Source src
		)
		{
			uint group = PrivateGroup;
			if (
				type == SimPe.Data.MetaData.BHAV_FILE
				|| type == 0x42434F4E /*BCON*/
				|| type == 0x54505250 /*TPRP*/
				|| type == 0x5452434E /*TRCN*/
			)
			{
				if (instance < 0x1000)
					group = GlobalGroup;
				else if (instance >= 0x2000)
					group = SemiGroup;
			}

			pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
				type,
				group,
				instance,
				src
			];
			return (items == null || items.Length == 0) ? null : items[0];
		}

		public SimPe.Interfaces.Plugin.Internal.IPackedFileWrapper SiblingResource(
			uint type
		)
		{
			if (FileDescriptor == null)
				return null;

			pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
				type,
				FileDescriptor.Group,
				FileDescriptor.Instance
			];
			if (items == null || items.Length == 0)
				return null;

			SimPe.Interfaces.Plugin.Internal.IPackedFileWrapper wrp =
				SimPe.FileTable.WrapperRegistry.FindHandler(type);
			wrp.ProcessData(items[0].PFD, items[0].Package);

			return wrp;
		}
	}

	public abstract class ExtendedWrapper<T, U>
		: ExtendedWrapper,
			IList<T>,
			ICollection<T>,
			IEnumerable<T>,
			IList,
			ICollection,
			IEnumerable
		where T : ExtendedWrapperItem<U, T>
		where U : ExtendedWrapper
	{
		protected List<T> items = new List<T>();

		public T this[int index]
		{
			get
			{
				return items[index];
			}
			set
			{
				if (!items[index].Equals(value))
				{
					items[index] = value;
					OnWrapperChanged(items, new EventArgs());
				}
			}
		}

		protected void Add(T item, int limit)
		{
			if (items.Count >= limit)
				throw new InvalidOperationException();
			this.Add(item);
		}

		protected void Insert(int index, T item, int limit)
		{
			if (items.Count >= limit)
				throw new InvalidOperationException();
			items.Insert(index, item);
		}

		public void Move(int from, int to)
		{
			T item = items[from];
			bool savedstate = internalchg;
			internalchg = true;
			this.RemoveAt(from);
			this.Insert(to, item);
			internalchg = savedstate;
			OnWrapperChanged(items, new EventArgs());
		}

		#region ExtendedWrapper Members
		protected abstract override void Unserialize(System.IO.BinaryReader reader);
		protected abstract override IPackedFileUI CreateDefaultUIHandler();
		#endregion

		#region IList<T> Members

		public int IndexOf(T item)
		{
			return items.IndexOf(item);
		}

		#endregion

		#region ICollection<T> Members

		private static void setNullParent(T item)
		{
			item.Parent = default(U);
		}

		public static implicit operator U(ExtendedWrapper<T, U> from)
		{
			return (U)(ExtendedWrapper)from;
		}

		public virtual void Add(T item)
		{
			item.Parent = this;
			items.Add(item);
			OnWrapperChanged(items, new EventArgs());
		}

		public void AddRange(IEnumerable<T> collection)
		{
			items.AddRange(collection);
			OnWrapperChanged(items, new EventArgs());
		}

		public void Clear()
		{
			items.ForEach(setNullParent);
			items.Clear();
			OnWrapperChanged(items, new EventArgs());
		}

		public bool Contains(T item)
		{
			return items.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			items.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get
			{
				return items.Count;
			}
		}
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public void Insert(int index, T item)
		{
			item.Parent = this;
			items.Insert(index, item);
			OnWrapperChanged(items, new EventArgs());
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
			foreach (T item in collection)
				item.Parent = this;
			items.InsertRange(index, collection);
			OnWrapperChanged(items, new EventArgs());
		}

		public bool Remove(T item)
		{
			if (items.Remove(item))
			{
				setNullParent(item);
				OnWrapperChanged(items, new EventArgs());
				return true;
			}
			return false;
		}

		public int RemoveAll(Predicate<T> match)
		{
			foreach (T item in items)
				if (match(item))
					setNullParent(item);
			int i = items.RemoveAll(match);
			if (i > 0)
				OnWrapperChanged(items, new EventArgs());
			return i;
		}

		public void RemoveAt(int index)
		{
			Remove(items[index]);
		}

		public void RemoveRange(int index, int count)
		{
			for (int i = index; i < index + count; i++)
				setNullParent(items[i]);
			items.RemoveRange(index, count);
			OnWrapperChanged(items, new EventArgs());
		}

		public void Reverse()
		{
			items.Reverse();
			OnWrapperChanged(items, new EventArgs());
		}

		public void Reverse(int index, int count)
		{
			items.Reverse(index, count);
			OnWrapperChanged(items, new EventArgs());
		}

		public void Sort()
		{
			items.Sort();
			OnWrapperChanged(items, new EventArgs());
		}

		public void Sort(Comparison<T> comparison)
		{
			items.Sort(comparison);
			OnWrapperChanged(items, new EventArgs());
		}

		public void Sort(IComparer<T> comparer)
		{
			items.Sort(comparer);
			OnWrapperChanged(items, new EventArgs());
		}

		public void Sort(int index, int count, IComparer<T> comparer)
		{
			items.Sort(index, count, comparer);
			OnWrapperChanged(items, new EventArgs());
		}

		#endregion

		#region IEnumerable<T> Members

		public virtual IEnumerator<T> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		#endregion

		#region IList Members

		public int Add(object value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public bool Contains(object value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public int IndexOf(object value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void Insert(int index, object value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public bool IsFixedSize
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		public void Remove(object value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		object IList.this[int index]
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
			set
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		#endregion

		#region ICollection Members

		public void CopyTo(Array array, int index)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public bool IsSynchronized
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		public object SyncRoot
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}

		#endregion

		#region IEquatable<U> Members

		public virtual bool Equals(U other)
		{
			return ((object)this).Equals(other);
		}

		#endregion
	}

	public abstract class ExtendedWrapperItem<T, U> : IEquatable<U>
		where T : ExtendedWrapper
	{
		protected T parent = default(T);
		public T Parent
		{
			get
			{
				return parent;
			}
			set
			{
				if (parent != value)
					parent = value;
			}
		}

		#region IEquatable<U> Members
		public virtual bool Equals(U other)
		{
			return ((object)this).Equals(other);
		}
		#endregion
	}
}
