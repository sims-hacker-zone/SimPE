// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;

using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Package;
using SimPe.Models.PackedFile.Idno;

namespace SimPe.ViewModels.NeighborhoodBrowser
{
	public partial class NeighborhoodViewModel : ObservableObject
	{
		[ObservableProperty]
		private Bitmap thumbnail;

		[ObservableProperty]
		private string shortName;

		[ObservableProperty]
		private string displayName;

		[ObservableProperty]
		private string description;

		[ObservableProperty]
		private PackageFile packageFile;

		[ObservableProperty]
		private string filePath;

		[ObservableProperty]
		private Idno idno;

		[ObservableProperty]
		private ObservableCollection<NeighborhoodViewModel> subhoods = [];

		public override string ToString()
		{
			return $"{DisplayName} ({ShortName})";
		}
	}
}
