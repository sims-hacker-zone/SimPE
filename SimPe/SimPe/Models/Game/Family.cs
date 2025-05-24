// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;

using Avalonia.Media.Imaging;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Package;
using SimPe.Models.PackedFile.Fami;
using SimPe.Models.PackedFile.Picture;

namespace SimPe.Models.Game
{
	public partial class Family(PackageFile neighborhoodFile, Fami famiResource, Picture thumbnailResource) : ObservableObject
	{
		[ObservableProperty]
		private PackageFile neighborhoodFile = neighborhoodFile;

		[ObservableProperty]
		private ObservableCollection<Sim> familyMembers = [];

		public Fami FamiResource
		{
			get;
		} = famiResource;

		public Picture ThumbnailResource
		{
			get;
		} = thumbnailResource;

		public Bitmap Thumbnail => ThumbnailResource?.Image;

		public string Name => FamiResource.FamilyName;

		public uint FamilyInstance => FamiResource.File.Instance;

		public override string ToString()
		{
			return $"{Name} (0x{FamilyInstance:X4})";
		}
	}
}
