// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Views.Resource.Bcon;

namespace SimPe.Sims2.Models.Resource.Bcon;

public partial class Bcon(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	private string resourceName;

	public string ResourceName
	{
		get => resourceName;
		set
		{
			if (SetProperty(ref resourceName, value))
			{
				OnPropertyChanged(FriendlyName);
			}
		}
	}

	[ObservableProperty] private byte flag;

	[ObservableProperty] private ObservableCollection<ushort> constants = [];

	public UserControl Panel { get; private set; }

	public string FriendlyName => ResourceName;

	public static Bcon Unserialize(BinaryReader reader, Resource file)
	{
		Bcon bcon = new(file)
		{
			ResourceName = Encoding.UTF8.GetString(reader.ReadBytes(64))
		};
		byte count = reader.ReadByte();
		bcon.Flag = reader.ReadByte();
		for (int i = 0; i < count; i++)
		{
			bcon.Constants.Add(reader.ReadUInt16());
		}

		bcon.Panel = new BconPanel() { DataContext = bcon };
		return bcon;
	}

	public void Serialize(BinaryWriter writer)
	{
		byte[] buffer = Encoding.UTF8.GetBytes(ResourceName);
		Array.Resize(ref buffer, 64);
		writer.Write(buffer);
		writer.Write(Constants.Count);
		writer.Write(Flag);
		foreach (ushort item in Constants)
		{
			writer.Write(item);
		}
	}
}
