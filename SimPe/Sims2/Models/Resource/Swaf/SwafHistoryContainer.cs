// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Resource.Swaf;

public partial class SwafHistoryContainer(Swaf parent) : ObservableObject
{
	[ObservableProperty] private Swaf parent = parent;

	[ObservableProperty] private uint key;

	[ObservableProperty] private ObservableCollection<SwafItem> items = [];

	public static SwafHistoryContainer Unserialize(BinaryReader reader, Swaf parent)
	{
		SwafHistoryContainer item = new(parent)
		{
			Key = reader.ReadUInt32(),
		};

		uint itemcount = reader.ReadUInt32();

		for (uint i = 0; i < itemcount; i++)
		{
			item.Items.Add(SwafItem.Unserialize(reader, parent, new(SwafItemType.History)));
		}

		foreach (SwafItem item1 in item.Items)
		{
			item1.PropertyChanged += item.Item_OnPropertyChanged;
		}

		return item;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Key);
		writer.Write(Items.Count);
		foreach (SwafItem item in Items)
		{
			item.Serialize(writer);
		}
	}

	public void Item_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged(nameof(Items));
	}

	public override string ToString()
	{
		return $"0x{Key:X8}";
	}
}
