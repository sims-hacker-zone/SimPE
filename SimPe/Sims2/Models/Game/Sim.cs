// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Sims2.Data;
using SimPe.Sims2.Models.Package;
using SimPe.Sims2.Models.Resource.Cpf;
using SimPe.Sims2.Models.Resource.Picture;
using SimPe.Sims2.Models.Resource.Sdsc;
using SimPe.Sims2.Models.Resource.Srel;
using SimPe.Sims2.Models.Resource.Str;

namespace SimPe.Sims2.Models.Game;

public partial class Sim(PackageFile neighborhoodFile, PackageFile characterFile, uint simGuid, ushort simInstance)
	: ObservableObject
{
	[ObservableProperty] private uint simGuid = simGuid;

	[ObservableProperty] private ushort simInstance = simInstance;

	[ObservableProperty] private PackageFile characterFile = characterFile;

	[ObservableProperty] private PackageFile neighborhoodFile = neighborhoodFile;

	private Sdsc? simDescription;

	public Sdsc SimDescription => simDescription ??=
		NeighborhoodFile.FindFile(FileTypes.SDSC, 0xFFFFFFFF, 0, SimInstance)?.Wrapper.As<Sdsc>();

	public Cpf SimDNA => NeighborhoodFile.FindFile(FileTypes.SDNA, 0xFFFFFFFF, 0, SimInstance).Wrapper.As<Cpf>();

	private Str? nameResource;

	public Str NameResource => nameResource ??= Enumerable
	                                            .FirstOrDefault<Resource.Resource>(
		                                            CharacterFile.FindFiles(FileTypes.CTSS, 0xFFFFFFFF, 0, null))
	                                            .Wrapper
	                                            .As<Str>();

	public Bitmap Portrait => Enumerable
	                          .FirstOrDefault<Resource.Resource>(
		                          CharacterFile.FindFiles(FileTypes.IMG, 0xFFFFFFFF, 0, null),
		                          x => x.Instance < 0x100)?.Wrapper.As<Picture>().Image;

	public string FirstName => NameResource[Languages.English, 0].Title;

	public string LastName => NameResource[Languages.English, 2].Title;
	public string FullName => $"{FirstName} {LastName}";

	[ObservableProperty] private ObservableCollection<Srel> relationships = [];

	public override string ToString()
	{
		return $"{FullName} (0x{SimInstance:X4})";
	}
}
