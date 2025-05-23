// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Package;
using SimPe.Models.PackedFile.Cpf;
using SimPe.Models.PackedFile.Sdsc;
using SimPe.Models.PackedFile.Srel;
using SimPe.Models.PackedFile.Str;

namespace SimPe.Models.Game
{
	public partial class Sim(PackageFile neighborhoodFile, PackageFile characterFile, uint simGuid, ushort simInstance) : ObservableObject
	{

		[ObservableProperty]
		private uint simGuid = simGuid;

		[ObservableProperty]
		private ushort simInstance = simInstance;

		[ObservableProperty]
		private PackageFile characterFile = characterFile;

		[ObservableProperty]
		private PackageFile neighborhoodFile = neighborhoodFile;

		private Sdsc simDescription;

		public Sdsc SimDescription => simDescription ??= NeighborhoodFile.FindFile(Data.FileTypes.SDSC, 0xFFFFFFFF, 0, SimInstance).Wrapper.As<Sdsc>();

		public Cpf SimDNA => NeighborhoodFile.FindFile(Data.FileTypes.SDNA, 0xFFFFFFFF, 0, SimInstance).Wrapper.As<Cpf>();

		public string FirstName => CharacterFile.FindFile(Data.FileTypes.CTSS, 0xFFFFFFFF, 0, 0x7D0).Wrapper.As<Str>()[Data.Languages.English, 0].Title;

		public string LastName => CharacterFile.FindFile(Data.FileTypes.CTSS, 0xFFFFFFFF, 0, 0x7D0).Wrapper.As<Str>()[Data.Languages.English, 2].Title;
		public string FullName => $"{FirstName} {LastName}";

		[ObservableProperty]
		private ObservableCollection<Srel> relationships = [];

		public override string ToString()
		{
			return $"{FullName} (0x{SimInstance:X4})";
		}

	}
}
