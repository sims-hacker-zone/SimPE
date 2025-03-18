// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Idno;

namespace SimPe.Models.PackedFile.Idno
{
	public partial class Idno(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		private EnumDisplayNameItem<NeighborhoodVersion> version;

		public EnumDisplayNameItem<NeighborhoodVersion> Version
		{
			get => version;
			set
			{
				if (SetProperty(ref version, value))
				{
					OnPropertyChanged(nameof(IsUniOrLater));
					OnPropertyChanged(nameof(IsSeasonsOrLater));
				}
			}
		}

		[ObservableProperty]
		private string name;

		[ObservableProperty]
		private uint uid;

		[ObservableProperty]
		private EnumDisplayNameItem<NeighborhoodType> type;

		[ObservableProperty]
		private string subhoodName;

		[ObservableProperty]
		private uint reserved_00;

		[ObservableProperty]
		private EnumDisplayNameItem<NeighborhoodEP> requiredEP;

		[ObservableProperty]
		private EnumDisplayNameItem<NeighborhoodEP> affiliatedEP;

		[ObservableProperty]
		private uint idFlags;

		[ObservableProperty]
		private EnumDisplayNameItem<NeighborhoodSeason> firstSeason;


		[ObservableProperty]
		private EnumDisplayNameItem<NeighborhoodSeason> secondSeason;


		[ObservableProperty]
		private EnumDisplayNameItem<NeighborhoodSeason> thirdSeason;


		[ObservableProperty]
		private EnumDisplayNameItem<NeighborhoodSeason> forthSeason;

		public bool IsUniOrLater => Version >= NeighborhoodVersion.Sims2_University;
		public bool IsSeasonsOrLater => Version >= NeighborhoodVersion.Sims2_Seasons;

		public UserControl Panel
		{
			get; private set;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write((uint)Version.Item);
			writer.Write(Name.Length);
			writer.Write(Name.ToCharArray());
			writer.Write(Uid);
			if (IsUniOrLater)
			{
				writer.Write((uint)Type.Item);
				if (SubhoodName != null)
				{
					writer.Write(SubhoodName.Length);
					writer.Write(SubhoodName.ToCharArray());
				}
				else
				{
					writer.Write((uint)0);
				}

				if (IsSeasonsOrLater)
				{
					writer.Write(Reserved_00);
					writer.Write((uint)RequiredEP.Item);
					writer.Write((uint)AffiliatedEP.Item);
					writer.Write(IdFlags);
					writer.Write((byte)FirstSeason.Item);
					writer.Write((byte)SecondSeason.Item);
					writer.Write((byte)ThirdSeason.Item);
					writer.Write((byte)ForthSeason.Item);
				}
			}
		}

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Idno idno = new(file)
			{
				Version = new((NeighborhoodVersion)reader.ReadUInt32())
			};
			int nameLength = reader.ReadInt32();
			idno.Name = Encoding.ASCII.GetString(reader.ReadBytes(nameLength));
			idno.Uid = reader.ReadUInt32();
			if (idno.IsUniOrLater)
			{
				idno.Type = new((NeighborhoodType)reader.ReadUInt32());
				int subnameLength = reader.ReadInt32();
				if (subnameLength > 0)
				{
					idno.SubhoodName = Encoding.ASCII.GetString(reader.ReadBytes(subnameLength));
				}
				else
				{
					idno.SubhoodName = "";
				}
				if (idno.IsSeasonsOrLater)
				{
					idno.Reserved_00 = reader.ReadUInt32();
					idno.RequiredEP = new((NeighborhoodEP)reader.ReadUInt32());
					idno.AffiliatedEP = new((NeighborhoodEP)reader.ReadUInt32());
					idno.IdFlags = reader.ReadUInt32();
					idno.FirstSeason = new((NeighborhoodSeason)reader.ReadByte());
					idno.SecondSeason = new((NeighborhoodSeason)reader.ReadByte());
					idno.ThirdSeason = new((NeighborhoodSeason)reader.ReadByte());
					idno.ForthSeason = new((NeighborhoodSeason)reader.ReadByte());
				}
			}
			idno.Panel = new IdnoPanel(idno);
			return idno;
		}
	}
}
