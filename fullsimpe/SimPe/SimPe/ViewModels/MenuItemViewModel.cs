// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Avalonia.Platform.Storage;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Package;

namespace SimPe.ViewModels
{
	public partial class MenuItemViewModel(MainWindowViewModel parent) : ObservableObject
	{
		[ObservableProperty]
		private MainWindowViewModel parent = parent;
		public string Header
		{
			get; set;
		}
		public ICommand Command
		{
			get; set;
		}
		public object CommandParameter
		{
			get; set;
		}
		public IList<MenuItemViewModel> Items
		{
			get; set;
		}

		[ObservableProperty]
		private bool enabled;

		public async void OpenRecent(object filepath)
		{
			Uri uri = new(filepath as string);
			Avalonia.Platform.Storage.IStorageFile file = await Program.mainWindow.StorageProvider.TryGetFileFromPathAsync(uri);
			if (file != null)
			{
				Parent.LoadedPackage = await PackageFile.Open(file);
				Parent.parent.Title = $"SimPe - {Uri.UnescapeDataString(file.Path.AbsolutePath)}";
			}
		}

		public async void OpenIn(object filepath)
		{
			IReadOnlyList<IStorageFile> filelist = await Parent.parent.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
			{
				AllowMultiple = false,
				Title = "Open Package File",
				FileTypeFilter = [
					new FilePickerFileType("Package") {
						Patterns = ["*.package"],
					},
					new FilePickerFileType("All Files") {
						Patterns = ["*.*"]
					}
				],
				SuggestedStartLocation = await Parent.parent.StorageProvider.TryGetFolderFromPathAsync(filepath as string)
			});
			if (filelist.Any())
			{
				string path = Uri.UnescapeDataString(filelist[0].Path.AbsolutePath);
				Parent.Configuration.RecentFiles.Insert(0, path);
				Parent.Configuration.RecentFiles = new(Parent.Configuration.RecentFiles.Take(15));
				Parent.LoadedPackage = await PackageFile.Open(filelist[0]);
				Parent.parent.Title = $"SimPe - {path}";
				await Parent.Configuration.Save();
			}
		}
	}
}
