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
			}
		}

		public async void OpenIn(object filepath)
		{
			IReadOnlyList<IStorageFile> filelist = await Parent.Parent.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
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
				SuggestedStartLocation = await Parent.Parent.StorageProvider.TryGetFolderFromPathAsync(filepath as string)
			});
			if (filelist.Any())
			{
				PackageFile openfile = Parent.LoadedPackages.FirstOrDefault(x => x.StorageFile.Path == filelist[0].Path);
				if (openfile != null)
				{
					Parent.LoadedPackage = openfile;
				}
				else
				{
					PackageFile file = await PackageFile.Open(filelist[0]);
					Parent.LoadedPackages.Add(file);
					Parent.LoadedPackage = file;
				}
				Parent.Configuration.RecentFiles.Insert(0, Uri.UnescapeDataString(filelist[0].Path.AbsolutePath));
				Parent.Configuration.RecentFiles = new(Parent.Configuration.RecentFiles.Take(15));
				await Parent.Configuration.Save();
			}
		}
	}
}
