// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Data;
using SimPe.Sims2.Views.Resource.Ttab;

namespace SimPe.Sims2.Models.Resource.Ttab;

public partial class Ttab(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private string resourceName;

	public static uint Header_0 => 0xFFFF_FFFF;

	[ObservableProperty] private uint version;

	[ObservableProperty] private uint unknown_00;

	[ObservableProperty] private ObservableCollection<TtabItem> items = [];

	public UserControl Panel { get; private set; }

	public string FriendlyName => ResourceName;

	public static Ttab Unserialize(BinaryReader reader, Resource file)
	{
		Ttab ttab = new(file)
		{
			ResourceName = Encoding.ASCII.GetString(reader.ReadBytes(64))
		};
		if (Header_0 != reader.ReadUInt32())
		{
			throw new InvalidDataException($"Invalid TTAB header!");
		}

		ttab.Version = reader.ReadUInt32();
		ttab.Unknown_00 = reader.ReadUInt32();

		ushort itemCount = reader.ReadUInt16();
		for (int i = 0; i < itemCount; i++)
		{
			ttab.Items.Add(TtabItem.Unserialize(reader, ttab));
		}

		ttab.Panel = new TtabPanel() { DataContext = ttab };

		return ttab;
	}

	public void Serialize(BinaryWriter writer)
	{
		byte[] buffer = Encoding.ASCII.GetBytes(ResourceName);
		Array.Resize(ref buffer, 64);
		writer.Write(buffer);
		writer.Write(Header_0);
		writer.Write(Version);
		writer.Write(Unknown_00);
		writer.Write((ushort)Items.Count);
		foreach (TtabItem item in Items)
		{
			item.Serialize(writer);
		}
	}
}
