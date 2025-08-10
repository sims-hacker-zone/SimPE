// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Common.Extensions;

public partial class CheckableEnumValue<T> : ObservableObject where T : struct, Enum
{
	[ObservableProperty] private CheckableFlagEnum<T>? parent;

	[ObservableProperty] private EnumDisplayNameItem<T>? item;

	public bool Checked
	{
		get => Item is not null && (Parent?.Value.HasFlag(Item.Item) ?? false);
		set
		{
			if (Parent == null)
			{
				return;
			}

			if (Item is not null)
			{
				Parent.Value = value
					? (T)(object)((uint)(object)Parent.Value | (uint)(object)Item.Item)
					: (T)(object)((uint)(object)Parent.Value & ~(uint)(object)Item.Item);
			}

			foreach (CheckableEnumValue<T> valueItem in Parent.Values)
			{
				valueItem.OnPropertyChanged();
			}
		}
	}
}

public partial class CheckableFlagEnum<T>(T value) : ObservableObject where T : struct, Enum
{
	[ObservableProperty] private T value = value;

	private ObservableCollection<CheckableEnumValue<T>>? values;

	public ObservableCollection<CheckableEnumValue<T>> Values
	{
		get
		{
			if (values != null)
			{
				return values;
			}

			values = new(from item in Enum.GetValues<T>()
			             select new CheckableEnumValue<T> { Parent = this, Item = new(item) });
			foreach (CheckableEnumValue<T> item in values)
			{
				item.PropertyChanged += Value_PropertyChanged;
			}

			return values;
		}
	}

	private void Value_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged(nameof(Values));
	}
}
