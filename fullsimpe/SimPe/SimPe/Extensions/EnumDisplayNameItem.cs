// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Linq;

namespace SimPe.Extensions
{
	public record EnumDisplayNameItem<T> : IComparable<T> where T : struct, Enum
	{
		public T Item
		{
			get;
			set;
		}

		public EnumDisplayNameItem()
		{
		}

		public EnumDisplayNameItem(T item)
		{
			Item = item;
		}

		public string Str => $"{Item.GetDisplayName()} (0x{Convert.ChangeType(Item, Item.GetTypeCode()):X})";

		public override string ToString()
		{
			return Str;
		}

		public override int GetHashCode()
		{
			return Item.GetHashCode();
		}

		public int CompareTo(T other)
		{
			return Item.CompareTo(other);
		}

		public static bool operator ==(EnumDisplayNameItem<T> a, T b)
		{
			return a.Item.Equals(b);
		}

		public static bool operator !=(EnumDisplayNameItem<T> a, T b)
		{
			return !a.Item.Equals(b);
		}

		public static bool operator >=(EnumDisplayNameItem<T> a, T b)
		{
			return a.Item.CompareTo(b) >= 0;
		}

		public static bool operator <=(EnumDisplayNameItem<T> a, T b)
		{
			return a.Item.CompareTo(b) <= 0;
		}

		public static bool operator >(EnumDisplayNameItem<T> a, T b)
		{
			return a.Item.CompareTo(b) > 0;
		}

		public static bool operator <(EnumDisplayNameItem<T> a, T b)
		{
			return a.Item.CompareTo(b) < 0;
		}

		public IEnumerable<EnumDisplayNameItem<T>> Values => from item in Enum.GetValues<T>()
															 select new EnumDisplayNameItem<T> { Item = item };

		public static IEnumerable<EnumDisplayNameItem<T>> GetValues()
		{
			return from item in Enum.GetValues<T>()
				   select new EnumDisplayNameItem<T> { Item = item };
		}
	}
}
