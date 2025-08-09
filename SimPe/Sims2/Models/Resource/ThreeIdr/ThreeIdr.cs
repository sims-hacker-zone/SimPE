// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Data;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.ThreeIdr;

namespace SimPe.Sims2.Models.Resource.ThreeIdr;

public partial class ThreeIdr(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	public static byte[] SIGNATURE => [0xEF, 0xBE, 0xAD, 0xDE];

	[ObservableProperty] private EnumDisplayNameItem<IndexTypes> type;

	[ObservableProperty] private ObservableCollection<ThreeIdrItem> items = [];

	public UserControl Panel { get; private set; }

	public string FriendlyName => null;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		ThreeIdr threeIdr = new(file);
		if (!SIGNATURE.SequenceEqual(reader.ReadBytes(4)))
		{
			throw new InvalidDataException();
		}

		threeIdr.Type = new((IndexTypes)reader.ReadUInt32());
		uint recordCount = reader.ReadUInt32();
		for (uint i = 0; i < recordCount; i++)
		{
			threeIdr.Items.Add(ThreeIdrItem.Unserialize(reader, threeIdr));
		}

		foreach (ThreeIdrItem item in threeIdr.Items)
		{
			item.PropertyChanged += threeIdr.Item_OnPropertyChanged;
		}

		threeIdr.Panel = new ThreeIdrPanel() { DataContext = threeIdr };

		return threeIdr;
	}

	public void Item_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged(nameof(Items));
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(SIGNATURE);
		writer.Write((uint)Type.Item);
		writer.Write(Items.Count);
		foreach (ThreeIdrItem item in Items)
		{
			item.Serialize(writer);
		}
	}
}
