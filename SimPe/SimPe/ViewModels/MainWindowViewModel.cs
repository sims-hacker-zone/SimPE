// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Avalonia.Platform.Storage;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Configuration;
using SimPe.Models.Package;
using SimPe.ViewModels.ResourceTree;

namespace SimPe.ViewModels
{
	public partial class MainWindowViewModel(MainWindow parent) : ObservableObject
	{
		[ObservableProperty]
		internal MainWindow parent = parent;
		public ObservableCollection<TabItemViewModel> Tabs
		{
			get; set;
		}
		public IReadOnlyList<MenuItemViewModel> MenuItems
		{
			get; set;
		} = [];

		public ObservableCollection<MenuItemViewModel> OpenInMenuItems
		{
			get; set;
		} = [];

		[ObservableProperty]
		private Configuration configuration = new();

		public IReadOnlyList<MenuItemViewModel> RecentFilesMenuItems => (from item in Configuration.RecentFiles.Select((item, i) => (item, i)) select new MenuItemViewModel(this) { Header = $"_{item.i}: {(item.item.Length > 50 ? "..." + item.item[^50..] : item.item)}", CommandParameter = item.item }).ToList();

		public ObservableCollection<ResourceTreeViewModel> ResourceTree { get; set; } = [];

		[ObservableProperty]
		private ObservableCollection<PackageFile> loadedPackages = [];

		private PackageFile loadedPackage;

		public PackageFile LoadedPackage
		{
			get => loadedPackage;
			set
			{
				loadedPackage = value;
				ResourceTree.Clear();
				ResourceTree.Add(new(loadedPackage, this));
				OnPropertyChanged(nameof(LoadedPackage));
				OnPropertyChanged(nameof(ResourceTree));
				OnPropertyChanged(nameof(RecentFilesMenuItems));
				Parent.Title = $"SimPe - {Uri.UnescapeDataString(loadedPackage.StorageFile.Path.AbsolutePath)}";
			}
		}

		public async Task<PackageFile> GetOrLoadPackage(string path)
		{
			Uri uri = new(path);
			PackageFile openfile = LoadedPackages.FirstOrDefault(x => x.StorageFile.Path == uri);
			if (openfile == null)
			{
				openfile = await PackageFile.Open(await Parent.StorageProvider.TryGetFileFromPathAsync(uri));
				if (openfile != null)
				{
					LoadedPackages.Add(openfile);
				}
			}
			return openfile;
		}

		public async Task<PackageFile> GetOrLoadPackage(IStorageFile file)
		{
			PackageFile openfile = LoadedPackages.FirstOrDefault(x => x.StorageFile == file);
			if (openfile == null)
			{
				openfile = await PackageFile.Open(file);
				if (openfile != null)
				{
					LoadedPackages.Add(openfile);
				}
			}
			return openfile;
		}

		public async Task LoadConfiguration()
		{
			Configuration = await Configuration.Load();
			OnPropertyChanged(nameof(RecentFilesMenuItems));
		}
	}
}
