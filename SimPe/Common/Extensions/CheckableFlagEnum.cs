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
	[ObservableProperty] private CheckableFlagEnum<T> parent;

	[ObservableProperty] private EnumDisplayNameItem<T> item;

	public bool Checked
	{
		get => Parent.Value.HasFlag(Item.Item);
		set
		{
			Parent.Value = value
				? (T)(object)((uint)(object)Parent.Value | (uint)(object)Item.Item)
				: (T)(object)((uint)(object)Parent.Value & ~(uint)(object)Item.Item);
			foreach (CheckableEnumValue<T> item in Parent.Values)
			{
				item.OnPropertyChanged(nameof(Checked));
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
			if (values == null)
			{
				values = new(from item in Enum.GetValues<T>()
					select new CheckableEnumValue<T> { Parent = this, Item = new(item) });
				foreach (CheckableEnumValue<T> item in values)
				{
					item.PropertyChanged += Value_PropertyChanged;
				}
			}

			return values;
		}
	}

	public void Value_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged(nameof(Values));
	}
}
