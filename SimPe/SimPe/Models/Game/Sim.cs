// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.Linq;

using Avalonia.Media.Imaging;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Package;
using SimPe.Models.PackedFile.Cpf;
using SimPe.Models.PackedFile.Picture;
using SimPe.Models.PackedFile.Sdsc;
using SimPe.Models.PackedFile.Srel;
using SimPe.Models.PackedFile.Str;

using Tmds.DBus.Protocol;

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

		private Str nameResource;

		public Str NameResource => nameResource ??= CharacterFile.FindFiles(Data.FileTypes.CTSS, 0xFFFFFFFF, 0, null).FirstOrDefault().Wrapper.As<Str>();

		public Bitmap Portrait => CharacterFile.FindFiles(Data.FileTypes.IMG, 0xFFFFFFFF, 0, null).FirstOrDefault(x => x.Instance < 0x100)?.Wrapper.As<Picture>().Image;

		public string FirstName => NameResource[Data.Languages.English, 0].Title;

		public string LastName => NameResource[Data.Languages.English, 2].Title;
		public string FullName => $"{FirstName} {LastName}";

		[ObservableProperty]
		private ObservableCollection<Srel> relationships = [];

		public override string ToString()
		{
			return $"{FullName} (0x{SimInstance:X4})";
		}

	}
}
