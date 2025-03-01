// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

namespace Ambertation.Windows.Forms
{
	/// <summary>
	/// This Class determins a Highlighted Section
	/// </summary>
	public class Highlight
	{
		int start,
			len,
			max;

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="start"></param>
		/// <param name="len"></param>
		/// <param name="max"></param>
		public Highlight(int start, int len, int max)
		{
			Maximum = max;
			this.len = len;
			Start = start;
		}

		/// <summary>
		/// Returns or Sets the start of the Highlight
		/// </summary>
		public int Start
		{
			get => start;
			set
			{
				start = Math.Min(max - 1, Math.Max(0, value));
				Length = len;
			}
		}

		/// <summary>
		/// Returns or Sets the length of the Highlight
		/// </summary>
		public int Length
		{
			get => len;
			set => len = Math.Max(0, Math.Min(max - start, value));
		}

		/// <summary>
		/// Returns the Last selected Position
		/// </summary>
		public int End => start + len - 1;

		/// <summary>
		/// Changes the allowed Maximum
		/// </summary>
		internal int Maximum
		{
			set
			{
				if (max != value)
				{
					max = value;
					len = 0;
					start = 0;
				}
			}
		}

		/// <summary>
		/// true if the Offset is within this Highlight
		/// </summary>
		/// <param name="offset"></param>
		/// <returns></returns>
		public bool Contains(int offset)
		{
			return offset >= Start && offset <= End;
		}
	}
}

namespace Ambertation.Collections
{
	/// <summary>
	/// Typesave ArrayList for Highlight Objects
	/// </summary>
	public class Highlights : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new Windows.Forms.Highlight this[int index]
		{
			get => (Windows.Forms.Highlight)base[index];
			set => base[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public Windows.Forms.Highlight this[uint index]
		{
			get => (Windows.Forms.Highlight)base[(int)index];
			set => base[(int)index] = value;
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		internal int Add(Windows.Forms.Highlight item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		internal void Insert(int index, Windows.Forms.Highlight item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		internal void Remove(Windows.Forms.Highlight item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(Windows.Forms.Highlight item)
		{
			return base.Contains(item);
		}

		/// <summary>
		/// Number of stored Elements
		/// </summary>
		public int Length => Count;

		/// <summary>
		/// Create a clone of this Object
		/// </summary>
		/// <returns>The clone</returns>
		internal new object Clone()
		{
			Highlights list = new Highlights();
			foreach (Windows.Forms.Highlight item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
}
