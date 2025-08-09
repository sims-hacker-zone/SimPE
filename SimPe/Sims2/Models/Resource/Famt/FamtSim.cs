// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Resource.Famt;

public partial class FamtSim(Famt parent) : ObservableObject
{
	[ObservableProperty] private Famt parent = parent;

	[ObservableProperty] private ushort simInstance;

	[ObservableProperty] private uint tieVersion;

	[ObservableProperty] private ObservableCollection<FamtTie> ties = [];

	public static FamtSim Unserialize(BinaryReader reader, Famt parent)
	{
		FamtSim sim = new(parent)
		{
			SimInstance = reader.ReadUInt16(),
			TieVersion = reader.ReadUInt32()
		};
		uint tieCount = reader.ReadUInt32();
		for (uint i = 0; i < tieCount; i++)
		{
			sim.Ties.Add(FamtTie.Unserialize(reader, sim));
		}

		foreach (FamtTie item in sim.Ties)
		{
			item.PropertyChanged += sim.Item_PropertyChanged;
		}

		return sim;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(SimInstance);
		writer.Write(TieVersion);
		writer.Write(Ties.Count);
		foreach (FamtTie item in Ties)
		{
			item.Serialize(writer);
		}
	}

	public void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged();
	}

	public override string ToString()
	{
		return $"0x{SimInstance:X8}: {Ties.Count} ties";
	}
}
