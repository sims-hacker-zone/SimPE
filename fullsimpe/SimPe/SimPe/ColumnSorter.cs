// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Windows.Forms;

namespace SimPe
{
	/// <summary>
	/// ListView Column Sorter
	/// </summary>
	public class ColumnSorter : IComparer
	{
		public ColumnSorter()
		{
			cc = 0;
			so = SortOrder.Ascending;
		}

		int cc;
		SortOrder so;

		/// <summary>
		/// The Currently active Column
		/// </summary>
		public int CurrentColumn
		{
			get => cc;
			set
			{
				if (cc != value)
				{
					cc = value;
					if (Changed != null)
					{
						Changed(this, new EventArgs());
					}
				}
			}
		}

		/// <summary>
		/// The Sort Order
		/// </summary>
		public SortOrder Sorting
		{
			get => so;
			set
			{
				if (so != value)
				{
					so = value;
					if (Changed != null)
					{
						Changed(this, new EventArgs());
					}
				}
			}
		}

		public event EventHandler Changed;

		/// <summary>
		/// The Compare Function to use
		/// </summary>
		/// <param name="x">fisrt ListViewItem</param>
		/// <param name="y">second ListViewItem</param>
		/// <returns>0 if the ListViewItem match</returns>
		public int Compare(object x, object y)
		{
			ListViewItem rowA = (ListViewItem)x;
			ListViewItem rowB = (ListViewItem)y;

			return Sorting == SortOrder.Ascending
				? string.Compare(
					rowA.SubItems[CurrentColumn].Text,
					rowB.SubItems[CurrentColumn].Text
				)
				: string.Compare(
					rowB.SubItems[CurrentColumn].Text,
					rowA.SubItems[CurrentColumn].Text
				);
		}
	}

	/// <summary>
	/// ListView Column Sorter
	/// </summary>
	public class ColumnsSorter : IComparer
	{
		/// <summary>
		/// The Currently active Column
		/// </summary>
		public int[] ColumnOrder
		{
			get; set;
		}

		/// <summary>
		/// The Sort Order
		/// </summary>
		public SortOrder Sorting = SortOrder.Ascending;

		public ColumnsSorter()
			: this(new int[0]) { }

		public ColumnsSorter(int[] columns)
		{
			ColumnOrder = columns;
		}

		/// <summary>
		/// The Compare Function to use
		/// </summary>
		/// <param name="x">fisrt ListViewItem</param>
		/// <param name="y">second ListViewItem</param>
		/// <returns>0 if the ListViewItem match</returns>
		public int Compare(object x, object y)
		{
			ListViewItem rowA = (ListViewItem)x;
			ListViewItem rowB = (ListViewItem)y;

			if (Sorting != SortOrder.Ascending)
			{
				rowB = (ListViewItem)x;
				rowA = (ListViewItem)y;
			}

			for (int cc = 0; cc < ColumnOrder.Length; cc++)
			{
				int cmp = string.Compare(
					rowA.SubItems[ColumnOrder[cc]].Text,
					rowB.SubItems[ColumnOrder[cc]].Text
				);
				if (cmp != 0)
				{
					return cmp;
				}
			}

			return 0;
		}
	}
}
