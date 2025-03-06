// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;

using SimPe.Data;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Glob;
using SimPe.PackedFiles.Wrapper;

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
			Changed = true;

			if (internalchg)
			{
				return;
			}

			if (WrapperChanged != null)
			{
				WrapperChanged(sender, e);
			}
		}

		/// <summary>
		/// This object's group
		/// </summary>
		public uint PrivateGroup => Context == Scope.Global || Context == Scope.SemiGlobal ? 0 : FileDescriptor.Group;

		/// <summary>
		/// The SemiGlobal group for this object
		/// </summary>
		public uint SemiGroup
		{
			get
			{
				if (Context == Scope.Global)
				{
					return 0;
				}

				Glob glob = BhavWiz.GlobByGroup(FileDescriptor.Group);
				return
					glob != null ? glob.SemiGlobalGroup : FileDescriptor.Group
				;
			}
		}

		/// <summary>
		/// The Global group
		/// </summary>
		public uint GlobalGroup => (uint)Group.Global;

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
					&& FileDescriptor != null
				)
				{
					return FileDescriptor.Instance < 0x1000 ? Scope.Global : FileDescriptor.Instance < 0x2000 ? Scope.Private : Scope.SemiGlobal;
				}
				else
				{
					return Scope.Private; // at least for now
				}
			}
		}

		public uint GroupForScope(Scope s)
		{
			switch (s)
			{
				case Scope.Global:
					return GlobalGroup;
				case Scope.SemiGlobal:
					return SemiGroup;
				default:
					return PrivateGroup;
			}
		}

		public uint GroupForContext => GroupForScope(Context);

		public FileTable.Entry ResourceByInstance(FileTypes type, uint instance)
		{
			return ResourceByInstance(type, instance, FileTable.Source.Any);
		}

		public FileTable.Entry ResourceByInstance(
			FileTypes type,
			uint instance,
			FileTable.Source src
		)
		{
			uint group = PrivateGroup;
			if (
				type == FileTypes.BHAV
				|| type == FileTypes.BCON
				|| type == FileTypes.TPRP
				|| type == FileTypes.TRCN
			)
			{
				if (instance < 0x1000)
				{
					group = GlobalGroup;
				}
				else if (instance >= 0x2000)
				{
					group = SemiGroup;
				}
			}

			FileTable.Entry[] items = FileTable.GFT[
				type,
				group,
				instance,
				src
			];
			return (items == null || items.Length == 0) ? null : items[0];
		}

		public SimPe.Interfaces.Plugin.Internal.IPackedFileWrapper SiblingResource(
			FileTypes type
		)
		{
			if (FileDescriptor == null)
			{
				return null;
			}

			FileTable.Entry[] items = FileTable.GFT[
				type,
				FileDescriptor.Group,
				FileDescriptor.Instance
			];
			if (items == null || items.Length == 0)
			{
				return null;
			}

			SimPe.Interfaces.Plugin.Internal.IPackedFileWrapper wrp =
				SimPe.FileTableBase.WrapperRegistry.FindHandler(type);
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
			get => items[index];
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
			{
				throw new InvalidOperationException();
			}

			Add(item);
		}

		protected void Insert(int index, T item, int limit)
		{
			if (items.Count >= limit)
			{
				throw new InvalidOperationException();
			}

			items.Insert(index, item);
		}

		public void Move(int from, int to)
		{
			T item = items[from];
			bool savedstate = internalchg;
			internalchg = true;
			RemoveAt(from);
			Insert(to, item);
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
			item.Parent = default;
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

		public int Count => items.Count;
		public bool IsReadOnly => false;

		public void Insert(int index, T item)
		{
			item.Parent = this;
			items.Insert(index, item);
			OnWrapperChanged(items, new EventArgs());
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
			foreach (T item in collection)
			{
				item.Parent = this;
			}

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
			{
				if (match(item))
				{
					setNullParent(item);
				}
			}

			int i = items.RemoveAll(match);
			if (i > 0)
			{
				OnWrapperChanged(items, new EventArgs());
			}

			return i;
		}

		public void RemoveAt(int index)
		{
			Remove(items[index]);
		}

		public void RemoveRange(int index, int count)
		{
			for (int i = index; i < index + count; i++)
			{
				setNullParent(items[i]);
			}

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

		public bool IsFixedSize => throw new Exception("The method or operation is not implemented.");

		public void Remove(object value)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		object IList.this[int index]
		{
			get => throw new Exception("The method or operation is not implemented.");
			set => throw new Exception("The method or operation is not implemented.");
		}

		#endregion

		#region ICollection Members

		public void CopyTo(Array array, int index)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public bool IsSynchronized => throw new Exception("The method or operation is not implemented.");

		public object SyncRoot => throw new Exception("The method or operation is not implemented.");

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
		protected T parent = default;
		public T Parent
		{
			get => parent;
			set
			{
				if (parent != value)
				{
					parent = value;
				}
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
