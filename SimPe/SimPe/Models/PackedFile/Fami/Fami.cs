// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Fami;

namespace SimPe.Models.PackedFile.Fami
{
	public partial class Fami(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		public static ReadOnlySpan<byte> SIGNATURE => "IMAF"u8;
		private EnumDisplayNameItem<FamiVersion> version;
		public EnumDisplayNameItem<FamiVersion> Version
		{
			get => version;
			set
			{
				if (SetProperty(ref version, value))
				{
					OnPropertyChanged(nameof(IsUniOrHigher));
					OnPropertyChanged(nameof(IsBusinessOrHigher));
					OnPropertyChanged(nameof(IsPetsOrHigher));
					OnPropertyChanged(nameof(IsVoyageOrHigher));
					OnPropertyChanged(nameof(IsCastawayStoriesOrHigher));
					OnPropertyChanged(nameof(IsNotCastawayStoriesOrHigher));
					OnPropertyChanged(nameof(IsBetweenBusinessAndCastawayStories));
				}
			}
		}

		public bool IsUniOrHigher => Version >= FamiVersion.University;
		public bool IsBusinessOrHigher => Version >= FamiVersion.Business;
		public bool IsPetsOrHigher => Version >= FamiVersion.Pets;
		public bool IsVoyageOrHigher => Version >= FamiVersion.Voyage;
		public bool IsCastawayStoriesOrHigher => Version >= FamiVersion.CastawayStories;
		public bool IsNotCastawayStoriesOrHigher => !IsCastawayStoriesOrHigher;

		public bool IsBetweenBusinessAndCastawayStories => IsBusinessOrHigher && !IsCastawayStoriesOrHigher;

		[ObservableProperty]
		private uint unknown_00;

		[ObservableProperty]
		private uint lotInstance;

		[ObservableProperty]
		private uint currentLotInstance;

		[ObservableProperty]
		private uint vacationLotInstance;

		[ObservableProperty]
		private uint familyNameInstance;

		[ObservableProperty]
		private int money;

		[ObservableProperty]
		private uint familyFriends;

		[ObservableProperty]
		private FamiFlags flags;

		[ObservableProperty]
		private ObservableCollection<uint> members = [];

		[ObservableProperty]
		private uint albumGUID;

		[ObservableProperty]
		private uint subhoodNumber;

		[ObservableProperty]
		private int businessMoney;

		[ObservableProperty]
		private int castawayStoriesResources;

		[ObservableProperty]
		private int castawayStoriesFood;

		[ObservableProperty]
		private int castawayStoriesFoodDecay;

		public UserControl Panel
		{
			get;
			private set;
		}

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Fami fami = new(file);
			if (!SIGNATURE.SequenceEqual(reader.ReadBytes(4)))
			{
				throw new InvalidDataException();
			}
			fami.Version = new((FamiVersion)reader.ReadUInt32());
			fami.Unknown_00 = reader.ReadUInt32(); // Always 0x0000
			fami.LotInstance = reader.ReadUInt32();
			if (fami.IsBusinessOrHigher)
			{
				fami.CurrentLotInstance = reader.ReadUInt32();
			}

			if (fami.IsVoyageOrHigher)
			{
				fami.VacationLotInstance = reader.ReadUInt32();
			}

			if (fami.IsCastawayStoriesOrHigher)
			{
				fami.CastawayStoriesResources = reader.ReadInt32();
				fami.CastawayStoriesFood = reader.ReadInt32();
				fami.CastawayStoriesFoodDecay = reader.ReadInt32();
			}
			else
			{
				fami.FamilyNameInstance = reader.ReadUInt32();
				fami.Money = reader.ReadInt32();
			}

			fami.FamilyFriends = reader.ReadUInt32();
			fami.Flags = (FamiFlags)reader.ReadUInt32();

			uint count = reader.ReadUInt32();
			for (int i = 0; i < count; i++)
			{
				fami.Members.Add(reader.ReadUInt32());
			}

			fami.AlbumGUID = reader.ReadUInt32(); //relations??
			if (fami.IsUniOrHigher)
			{
				fami.SubhoodNumber = reader.ReadUInt32();
			}

			if (fami.IsCastawayStoriesOrHigher)
			{
				fami.CastawayStoriesResources = reader.ReadInt32();
				fami.CastawayStoriesFood = reader.ReadInt32();
				fami.CastawayStoriesFoodDecay = reader.ReadInt32();
			}
			else if (fami.IsBusinessOrHigher)
			{
				fami.BusinessMoney = reader.ReadInt32();
			}
			fami.Panel = new FamiPanel() { DataContext = fami };
			return fami;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(SIGNATURE);
			writer.Write((uint)Version.Item);
			writer.Write(Unknown_00);
			writer.Write(LotInstance);
			if (IsBusinessOrHigher)
			{
				writer.Write(CurrentLotInstance);
			}

			if (IsVoyageOrHigher)
			{
				writer.Write(VacationLotInstance);
			}

			if (IsCastawayStoriesOrHigher)
			{
				writer.Write(CastawayStoriesResources);
				writer.Write(CastawayStoriesFood);
				writer.Write(CastawayStoriesFoodDecay);
			}
			else
			{
				writer.Write(FamilyNameInstance);
				writer.Write(Money);
			}
			writer.Write(FamilyFriends);
			writer.Write((uint)Flags);

			writer.Write((uint)Members.Count);
			foreach (uint member in Members)
			{
				writer.Write(member);
			}

			writer.Write(AlbumGUID);

			if (IsUniOrHigher)
			{
				writer.Write(SubhoodNumber);
			}

			if (IsCastawayStoriesOrHigher)
			{
				writer.Write(CastawayStoriesResources);
				writer.Write(CastawayStoriesFood);
				writer.Write(CastawayStoriesFoodDecay);
			}
			else if (IsBusinessOrHigher)
			{
				writer.Write(BusinessMoney);
			}
		}
	}
}
