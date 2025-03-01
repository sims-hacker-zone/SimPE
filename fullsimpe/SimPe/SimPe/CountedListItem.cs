// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe
{
	/// <summary>
	/// Can be used as a Wrapper Class when adding unnamed Objects to a List
	/// </summary>
	public class CountedListItem : IDisposable
	{
		bool hex;

		/// <summary>
		/// Returns/Sets the stored Object
		/// </summary>
		public object Object
		{
			get; set;
		}

		int index;

		internal CountedListItem(int index, object obj, bool hex)
		{
			Object = obj;
			this.index = index;
			this.hex = hex;
		}

		public override string ToString()
		{
			return hex ? "0x" + index.ToString("X") + ": " + Object.ToString() : index.ToString() + ": " + Object.ToString();
		}

		/// <summary>
		/// Returns/Sets the lowest Number used for the Index
		/// </summary>
		public static int Offset { get; set; } = 0;

		/// <summary>
		/// Adds an Item to the given ComboBox
		/// </summary>
		/// <param name="cb">The ComboBox</param>
		/// <param name="obj">The Item you want to add</param>
		public static void Add(System.Windows.Forms.ComboBox cb, object obj)
		{
			cb.Items.Add(new CountedListItem(cb.Items.Count + Offset, obj, false));
		}

		/// <summary>
		/// Adds an Item to the given ListBox
		/// </summary>
		/// <param name="lb">The ListBox</param>
		/// <param name="obj">The Item you want to add</param>
		public static void Add(System.Windows.Forms.ListBox lb, object obj)
		{
			lb.Items.Add(new CountedListItem(lb.Items.Count + Offset, obj, false));
		}

		/// <summary>
		/// Adds an Item to the given ComboBox
		/// </summary>
		/// <param name="cb">The ComboBox</param>
		/// <param name="obj">The Item you want to add</param>
		public static void AddHex(System.Windows.Forms.ComboBox cb, object obj)
		{
			cb.Items.Add(new CountedListItem(cb.Items.Count + Offset, obj, true));
		}

		/// <summary>
		/// Adds an Item to the given ListBox
		/// </summary>
		/// <param name="lb">The ListBox</param>
		/// <param name="obj">The Item you want to add</param>
		public static void AddHex(System.Windows.Forms.ListBox lb, object obj)
		{
			lb.Items.Add(new CountedListItem(lb.Items.Count + Offset, obj, true));
		}

		#region IDisposable Member

		public void Dispose()
		{
			Object = null;
		}

		#endregion
	}
}
