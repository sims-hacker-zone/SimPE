// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.Bhav;

namespace SimPe.Sims2.Models.Resource.Bhav;

public partial class Bhav(Resource resource) : ObservableObject, IWrapper
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

	[ObservableProperty] private ushort version;

	[ObservableProperty] private byte treeType;

	[ObservableProperty] private byte parameterCount;

	[ObservableProperty] private byte localVarCount;

	[ObservableProperty] private byte headerFlag;

	[ObservableProperty] private int treeVersion;

	[ObservableProperty] private ObservableCollection<BhavInstruction> instructions = [];

	[ObservableProperty] private byte cacheFlags;


	public UserControl Panel { get; private set; }

	public string FriendlyName => ResourceName;

	public static Bhav Unserialize(BinaryReader reader, Resource file)
	{
		Bhav bhav = new(file)
		{
			ResourceName = Encoding.UTF8.GetString(reader.ReadBytes(64)),
			Version = reader.ReadUInt16()
		};
		ushort instructionCount = reader.ReadUInt16();
		bhav.TreeType = reader.ReadByte();
		bhav.ParameterCount = reader.ReadByte();
		bhav.LocalVarCount = reader.ReadByte();
		bhav.HeaderFlag = reader.ReadByte();
		bhav.TreeVersion = reader.ReadInt32();
		if (bhav.Version >= 0x8009)
		{
			bhav.CacheFlags = reader.ReadByte();
		}

		for (int i = 0; i < instructionCount; i++)
		{
			bhav.Instructions.Add(BhavInstruction.Unserialize(reader, bhav));
		}

		foreach (BhavInstruction item in bhav.Instructions)
		{
			item.PropertyChanged += bhav.Item_PropertyChanged;
		}

		bhav.Panel = new BhavPanel() { DataContext = bhav };
		return bhav;
	}

	public void Serialize(BinaryWriter writer)
	{
		byte[] buffer = Encoding.UTF8.GetBytes(ResourceName);
		Array.Resize(ref buffer, 64);
		writer.Write(buffer);
		writer.Write(Version);
		writer.Write((ushort)Instructions.Count);
		writer.Write(TreeType);
		writer.Write(ParameterCount);
		writer.Write(LocalVarCount);
		writer.Write(HeaderFlag);
		writer.Write(TreeVersion);
		foreach (BhavInstruction item in Instructions)
		{
			item.Serialize(writer);
		}

		if (Version >= 0x8009)
		{
			writer.Write(CacheFlags);
		}
	}

	public void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged();
	}
}
