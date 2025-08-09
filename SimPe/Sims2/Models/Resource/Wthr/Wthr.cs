// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Sims2.Data;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.Wthr;

namespace SimPe.Sims2.Models.Resource.Wthr;

public partial class Wthr(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private string name;

	[ObservableProperty] private EnumDisplayNameItem<NeighborhoodSeason> nextSeason;

	[ObservableProperty] private EnumDisplayNameItem<NeighborhoodSeason> currentSeason;

	[ObservableProperty] private uint daysLeftInSeason;

	[ObservableProperty] private uint additionalSeasonDays;

	[ObservableProperty] private EnumDisplayNameItem<WthrType> precipitationType;

	[ObservableProperty] private EnumDisplayNameItem<WthrLevel> precipitationLevel;

	[ObservableProperty] private EnumDisplayNameItem<WthrLevel> accumulationLevel;

	[ObservableProperty] private EnumDisplayNameItem<WthrType> accumulationType;

	[ObservableProperty] private int temperature;

	[ObservableProperty] private EnumDisplayNameItem<WthrSkyClarity> skyClarity;

	[ObservableProperty] private EnumDisplayNameItem<WthrFrozenState> pondFrozenState;

	public UserControl Panel { get; set; }

	public string FriendlyName => Name;

	public static Wthr Unserialize(BinaryReader reader, Resource file)
	{
		Wthr wthr = new(file);
		if (reader.ReadUInt32() != 3)
		{
			throw new InvalidDataException();
		}

		int nameLen = reader.ReadInt32();
		wthr.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLen));
		wthr.NextSeason = new((NeighborhoodSeason)reader.ReadUInt32());
		wthr.CurrentSeason = new((NeighborhoodSeason)reader.ReadUInt32());
		wthr.DaysLeftInSeason = reader.ReadUInt32();
		wthr.AdditionalSeasonDays = reader.ReadUInt32();
		wthr.PrecipitationType = new((WthrType)reader.ReadUInt32());
		wthr.PrecipitationLevel = new((WthrLevel)reader.ReadUInt32());
		wthr.AccumulationLevel = new((WthrLevel)reader.ReadUInt32());
		wthr.AccumulationType = new((WthrType)reader.ReadUInt32());
		wthr.Temperature = reader.ReadInt32();
		wthr.SkyClarity = new((WthrSkyClarity)reader.ReadUInt32());
		wthr.PondFrozenState = new((WthrFrozenState)reader.ReadUInt32());
		wthr.Panel = new WthrPanel() { DataContext = wthr };
		return wthr;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write((uint)3);
		writer.Write(Encoding.UTF8.GetByteCount(Name));
		writer.Write(Encoding.UTF8.GetBytes(Name));
		writer.Write((uint)NextSeason.Item);
		writer.Write((uint)CurrentSeason.Item);
		writer.Write(DaysLeftInSeason);
		writer.Write(AdditionalSeasonDays);
		writer.Write((uint)PrecipitationType.Item);
		writer.Write((uint)PrecipitationLevel.Item);
		writer.Write((uint)AccumulationLevel.Item);
		writer.Write((uint)AccumulationType.Item);
		writer.Write(Temperature);
		writer.Write((uint)SkyClarity.Item);
		writer.Write((uint)PondFrozenState.Item);
	}
}
