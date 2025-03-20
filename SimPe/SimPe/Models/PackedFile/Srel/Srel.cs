// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Srel;

namespace SimPe.Models.PackedFile.Srel
{
	public partial class Srel(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private uint version = 2;

		[ObservableProperty]
		private uint format;

		[ObservableProperty]
		private int dailyScore;

		[ObservableProperty]
		private SrelRelationshipFlags relationshipFlags;

		[ObservableProperty]
		private EnumDisplayNameItem<SrelRelationshipType> relationshipType;

		[ObservableProperty]
		private int lifetimeScore;

		[ObservableProperty]
		private EnumDisplayNameItem<SrelFamilyRelations> familyRelation;

		[ObservableProperty]
		private int attraction;

		[ObservableProperty]
		private bool bFF;

		public uint SourceSimInstance => (File.Instance >> 16) & 0xFFFF;

		public uint TargetSimInstance => File.Instance & 0xFFFF;

		public UserControl Panel
		{
			get;
			private set;
		}

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
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
				srel.RelationshipFlags = (SrelRelationshipFlags)reader.ReadUInt16();
				srel.RelationshipType = new((SrelRelationshipType)reader.ReadUInt16());
			}
			if (srel.Format >= 3)
			{
				srel.LifetimeScore = reader.ReadInt32();
			}
			uint format = srel.Format;
			if (srel.Format >= 4 && srel.RelationshipFlags.HasFlag(SrelRelationshipFlags.Family))
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
				writer.Write((ushort)RelationshipFlags);
				writer.Write((ushort)RelationshipType.Item);
			}
			if (Format >= 3)
			{
				writer.Write(LifetimeScore);
			}
			uint format = Format;
			if (Format >= 4 && RelationshipFlags.HasFlag(SrelRelationshipFlags.Family))
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
	}
}
