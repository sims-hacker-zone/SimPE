// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Idno;

namespace SimPe.Models.PackedFile.Idno
{
	public partial class Idno(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private NeighborhoodVersion version;

		[ObservableProperty]
		private string name;

		[ObservableProperty]
		private uint uid;

		[ObservableProperty]
		private NeighborhoodType type;

		[ObservableProperty]
		private string subhoodName;

		[ObservableProperty]
		private uint reserved_00;

		[ObservableProperty]
		private NeighborhoodEP requiredEP;

		[ObservableProperty]
		private NeighborhoodEP affiliatedEP;

		[ObservableProperty]
		private uint idFlags;

		[ObservableProperty]
		private NeighborhoodSeason firstSeason;


		[ObservableProperty]
		private NeighborhoodSeason secondSeason;


		[ObservableProperty]
		private NeighborhoodSeason thirdSeason;


		[ObservableProperty]
		private NeighborhoodSeason forthSeason;

		public UserControl Panel
		{
			get; private set;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write((uint)Version);
			writer.Write(Name.Length);
			writer.Write(Name.ToCharArray());
			writer.Write(Uid);
			if (Version >= NeighborhoodVersion.Sims2_University)
			{
				writer.Write((uint)Type);
				if (SubhoodName != null)
				{
					writer.Write(SubhoodName.Length);
					writer.Write(SubhoodName.ToCharArray());
				}
				else
				{
					writer.Write((uint)0);
				}

				if (Version >= NeighborhoodVersion.Sims2_Seasons)
				{
					writer.Write(Reserved_00);
					writer.Write((uint)RequiredEP);
					writer.Write((uint)AffiliatedEP);
					writer.Write(IdFlags);
					writer.Write((byte)FirstSeason);
					writer.Write((byte)SecondSeason);
					writer.Write((byte)ThirdSeason);
					writer.Write((byte)ForthSeason);
				}
			}
		}

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Idno idno = new(file)
			{
				Version = (NeighborhoodVersion)reader.ReadUInt32()
			};
			int nameLength = reader.ReadInt32();
			idno.Name = new(reader.ReadChars(nameLength));
			idno.Uid = reader.ReadUInt32();
			if (idno.Version >= NeighborhoodVersion.Sims2_University)
			{
				idno.Type = (NeighborhoodType)reader.ReadUInt32();
				int subnameLength = reader.ReadInt32();
				if (subnameLength > 0)
				{
					idno.SubhoodName = new(reader.ReadChars(subnameLength));
				}
				if (idno.Version >= NeighborhoodVersion.Sims2_Seasons)
				{
					idno.Reserved_00 = reader.ReadUInt32();
					idno.RequiredEP = (NeighborhoodEP)reader.ReadUInt32();
					idno.AffiliatedEP = (NeighborhoodEP)reader.ReadUInt32();
					idno.IdFlags = reader.ReadUInt32();
					idno.FirstSeason = (NeighborhoodSeason)reader.ReadByte();
					idno.SecondSeason = (NeighborhoodSeason)reader.ReadByte();
					idno.ThirdSeason = (NeighborhoodSeason)reader.ReadByte();
					idno.ForthSeason = (NeighborhoodSeason)reader.ReadByte();
				}
			}
			idno.Panel = new IdnoPanel(idno);
			return idno;
		}
	}
}
