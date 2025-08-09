// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.Famt;

namespace SimPe.Sims2.Models.Resource.Famt;

public partial class Famt(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private EnumDisplayNameItem<FamtVersion> version;

	[ObservableProperty] private ObservableCollection<FamtSim> sims = [];

	public UserControl Panel { get; set; }

	public string FriendlyName => "Family Ties";

	public static Famt Unserialize(BinaryReader reader, Resource file)
	{
		Famt famt = new(file)
		{
			Version = new((FamtVersion)reader.ReadUInt32())
		};
		if (famt.Version.Item != FamtVersion.Version1)
		{
			throw new InvalidDataException();
		}

		uint simCount = reader.ReadUInt32();
		for (int i = 0; i < simCount; i++)
		{
			famt.Sims.Add(FamtSim.Unserialize(reader, famt));
		}

		famt.Panel = new FamtPanel() { DataContext = famt };
		return famt;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write((uint)Version.Item);
		writer.Write(Sims.Count);
		foreach (FamtSim item in Sims)
		{
			item.Serialize(writer);
		}
	}
}
