// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Linq;

using Avalonia.Platform.Storage;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.ViewModels;

namespace SimPe.Models.Configuration
{
	public partial class InstalledExpansionConfig : ObservableObject
	{
		[ObservableProperty]
		private EnumDisplayNameItem<PackageFolders> item;

		[ObservableProperty]
		private string path;

		public async void SetNewPath()
		{
			IStorageFolder baseGameFolder = Item < PackageFolders.SaveGameSims2
				? await Program.MainWindow.StorageProvider.TryGetFolderFromPathAsync(
					(Program.MainWindow.DataContext as MainWindowViewModel).Configuration.ExpansionInstallPaths
					.Where(x => x.Item == PackageFolders.BaseGame)
					.Select(x => x.Path)
					.FirstOrDefault(""))
				: await Program.MainWindow.StorageProvider.TryGetWellKnownFolderAsync(WellKnownFolder.Documents);
			IReadOnlyList<IStorageFolder> folder = await Program.MainWindow.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions { AllowMultiple = false, Title = $"Select installation folder of {Item}", SuggestedStartLocation = baseGameFolder });
			if (folder?.Any() == true)
			{
				Path = Uri.UnescapeDataString(folder[0].Path.AbsolutePath);
			}
		}
	}
}
