// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.ComponentModel;
using System.IO;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.Srel;

namespace SimPe.Sims2.Models.Resource.Srel;

public partial class Srel(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private uint version = 2;

	[ObservableProperty] private uint format;

	[ObservableProperty] private int dailyScore;

	[ObservableProperty] private CheckableFlagEnum<SrelRelationshipFlags> relationshipFlags;

	[ObservableProperty] private EnumDisplayNameItem<SrelRelationshipType> relationshipType;

	[ObservableProperty] private int lifetimeScore;

	[ObservableProperty] private EnumDisplayNameItem<SrelFamilyRelations> familyRelation;

	[ObservableProperty] private int attraction;

	[ObservableProperty] private bool bFF;

	public uint SourceSimInstance => ((Resource as Resource).Instance >> 16) & 0xFFFF;

	public uint TargetSimInstance => (Resource as Resource).Instance & 0xFFFF;

	public UserControl Panel { get; private set; }

	public string FriendlyName => null;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		Srel srel = new(file);
		srel.Version = reader.ReadUInt32();
		srel.Format = reader.ReadUInt32();
		if (srel.Format >= 1)
		{
			srel.DailyScore = reader.ReadInt32();
		}

		if (srel.Format >= 2)
		{
			srel.RelationshipFlags = new((SrelRelationshipFlags)reader.ReadUInt16());
			srel.RelationshipFlags.PropertyChanged += srel.Data_OnPropertyChanged;
			srel.RelationshipType = new((SrelRelationshipType)reader.ReadUInt16());
		}

		if (srel.Format >= 3)
		{
			srel.LifetimeScore = reader.ReadInt32();
		}

		uint format = srel.Format;
		if (srel.Format >= 4 && srel.RelationshipFlags.Value.HasFlag(SrelRelationshipFlags.Family))
		{
			srel.FamilyRelation = new((SrelFamilyRelations)reader.ReadUInt32());
			format--;
		}

		if (format >= 4)
		{
			reader.ReadUInt32();
		}

		if (format >= 5)
		{
			reader.ReadUInt32();
		}

		if (format >= 6)
		{
			reader.ReadUInt32();
		}

		if (format >= 7)
		{
			reader.ReadUInt32();
		}

		if (format >= 8)
		{
			srel.Attraction = reader.ReadInt32();
		}

		if (format >= 9)
		{
			srel.BFF = reader.ReadBoolean();
		}

		srel.Panel = new SrelPanel() { DataContext = srel };

		return srel;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Version);
		writer.Write(Format);
		if (Format >= 1)
		{
			writer.Write(DailyScore);
		}

		if (Format >= 2)
		{
			writer.Write((ushort)RelationshipFlags.Value);
			writer.Write((ushort)RelationshipType.Item);
		}

		if (Format >= 3)
		{
			writer.Write(LifetimeScore);
		}

		uint format = Format;
		if (Format >= 4 && RelationshipFlags.Value.HasFlag(SrelRelationshipFlags.Family))
		{
			writer.Write((uint)FamilyRelation.Item);
			format--;
		}

		if (format >= 4)
		{
			writer.Write((uint)0);
		}

		if (format >= 5)
		{
			writer.Write((uint)0);
		}

		if (format >= 6)
		{
			writer.Write((uint)0);
		}

		if (format >= 7)
		{
			writer.Write((uint)0);
		}

		if (format >= 8)
		{
			writer.Write(Attraction);
		}

		if (format >= 9)
		{
			writer.Write(BFF ? 1 : (uint)0);
		}
	}

	public void Data_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged();
	}
}
