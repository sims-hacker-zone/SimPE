// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Interfaces.Files;

namespace SimPe.Collections
{
	/// <summary>
	/// Typesave ArrayList for IPackedFileDescriptor Objects
	/// </summary>
	public class PackedFileDescriptors : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new IPackedFileDescriptor this[int index]
		{
			get => (IPackedFileDescriptor)base[index];
			set => base[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public IPackedFileDescriptor this[uint index]
		{
			get => (IPackedFileDescriptor)base[(int)index];
			set => base[(int)index] = value;
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		public int Add(IPackedFileDescriptor item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, IPackedFileDescriptor item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(IPackedFileDescriptor item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(IPackedFileDescriptor item)
		{
			if (item == null)
			{
				return false;
			}

			foreach (IPackedFileDescriptor pfd in this)
			{
				if (item.SameAs(pfd))
				{
					return true;
				}
			}

			return false;
			//return base.Contains(item);
		}

		/// <summary>
		/// Number of stored Elements
		/// </summary>
		public int Length => Count;

		/// <summary>
		/// Create a clone of this Object
		/// </summary>
		/// <returns>The clone</returns>
		public override object Clone()
		{
			PackedFileDescriptors list = new PackedFileDescriptors();
			foreach (IPackedFileDescriptor item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
}
