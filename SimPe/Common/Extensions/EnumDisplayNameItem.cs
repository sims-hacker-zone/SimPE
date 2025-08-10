// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimPe.Common.Extensions;

public record EnumDisplayNameItem
{
	public Enum Item { get; set; }

	public string DisplayName { get; }

	public IEnumerable<EnumDisplayNameItem> Values { get; }
}

public record EnumDisplayNameItem<T> : EnumDisplayNameItem, IComparable<T> where T : struct, Enum
{
	private static readonly Hashtable valueCache = [];
	public new T Item { get; init; }

	private EnumDisplayNameItem()
	{
	}

	public EnumDisplayNameItem(T item)
	{
		Item = item;
	}

	private string Str => $"{Item.GetDisplayName()} (0x{Convert.ChangeType(Item, Item.GetTypeCode()):X})";

	public string EnumName => Item.ToString();

	public new string DisplayName => Item.GetDisplayName();

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

	public static bool operator ==(EnumDisplayNameItem<T>? a, T b)
	{
		return a.Item.Equals(b);
	}


	public static bool operator ==(EnumDisplayNameItem<T> a, T? b)
	{
		return a.Item.Equals(b);
	}

	public static bool operator !=(EnumDisplayNameItem<T> a, T b)
	{
		return !a.Item.Equals(b);
	}

	public static bool operator !=(EnumDisplayNameItem<T> a, T? b)
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

	public new IEnumerable<EnumDisplayNameItem<T>> Values => valueCache.ContainsKey(typeof(T))
		? (IEnumerable<EnumDisplayNameItem<T>>)valueCache[typeof(T)]
		: (IEnumerable<EnumDisplayNameItem<T>>)(valueCache[typeof(T)] = from item in Enum.GetValues<T>()
		                                                                select new EnumDisplayNameItem<T>
			                                                                { Item = item });
}
