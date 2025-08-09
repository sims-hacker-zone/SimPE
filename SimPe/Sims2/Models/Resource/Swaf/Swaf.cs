// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.Swaf;

namespace SimPe.Sims2.Models.Resource.Swaf;

public partial class Swaf(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	private EnumDisplayNameItem<SwafVersion> version;

	public EnumDisplayNameItem<SwafVersion> Version
	{
		get => version;
		set
		{
			if (SetProperty(ref version, value))
			{
				OnPropertyChanged(nameof(IsVersion5OrLater));
			}
		}
	}

	public bool IsVersion5OrLater => Version >= SwafVersion.Version5;

	[ObservableProperty] private ObservableCollection<SwafItem> lifetimeWants = [];
	[ObservableProperty] private uint maxWants;
	[ObservableProperty] private ObservableCollection<SwafItem> wants = [];
	[ObservableProperty] private uint maxFears;
	[ObservableProperty] private ObservableCollection<SwafItem> fears = [];
	[ObservableProperty] private uint unknown_00;
	[ObservableProperty] private uint unknown_01;
	[ObservableProperty] private uint unknown_02;
	[ObservableProperty] private ObservableCollection<SwafHistoryContainer> wantHistory = [];

	[ObservableProperty] private byte[] overhead;

	public UserControl Panel { get; private set; }

	public string FriendlyName => null;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		Swaf swaf = new(file)
		{
			Version = new((SwafVersion)reader.ReadUInt32())
		};
		if (swaf.IsVersion5OrLater)
		{
			uint ltwCount = reader.ReadUInt32();
			for (uint i = 0; i < ltwCount; i++)
			{
				swaf.LifetimeWants.Add(SwafItem.Unserialize(reader, swaf, new(SwafItemType.LifetimeWant)));
			}
		}

		swaf.MaxWants = swaf.IsVersion5OrLater ? reader.ReadUInt32() : 4;
		uint wantCount = reader.ReadUInt32();
		for (uint i = 0; i < wantCount; i++)
		{
			swaf.Wants.Add(SwafItem.Unserialize(reader, swaf, new(SwafItemType.Want)));
		}

		swaf.MaxFears = swaf.IsVersion5OrLater ? reader.ReadUInt32() : 3;
		uint fearCount = reader.ReadUInt32();
		for (uint i = 0; i < fearCount; i++)
		{
			swaf.Fears.Add(SwafItem.Unserialize(reader, swaf, new(SwafItemType.Fear)));
		}

		swaf.Unknown_00 = swaf.IsVersion5OrLater ? reader.ReadUInt32() : 0;
		swaf.Unknown_01 = reader.ReadUInt32();
		swaf.Unknown_02 = reader.ReadUInt32();

		uint historyCount = reader.ReadUInt32();
		for (int i = 0; i < historyCount; i++)
		{
			swaf.WantHistory.Add(SwafHistoryContainer.Unserialize(reader, swaf));
		}

		swaf.Overhead = reader.ReadBytes(
			(int)(reader.BaseStream.Length - reader.BaseStream.Position)
		);
		swaf.Panel = new SwafPanel() { DataContext = swaf };
		return swaf;
	}

	public void Serialize(BinaryWriter writer)
	{
	}
}
