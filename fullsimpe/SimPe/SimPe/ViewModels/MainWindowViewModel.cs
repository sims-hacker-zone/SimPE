// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using SimPe.Models.Configuration;
using SimPe.Models.Package;
using SimPe.ViewModels.ResourceTree;

namespace SimPe.ViewModels
{
	public class MainWindowViewModel(MainWindow parent) : INotifyPropertyChanged
	{
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
		public Configuration Configuration { get; private set; } = new();

		public IReadOnlyList<MenuItemViewModel> RecentFilesMenuItems => (from item in Configuration.RecentFiles.Select((item, i) => (item, i)) select new MenuItemViewModel(this) { Header = $"_{item.i}: {(item.item.Length > 50 ? "..." + item.item[^50..] : item.item)}", CommandParameter = item.item }).ToList();

		public ObservableCollection<ResourceTreeViewModel> ResourceTree { get; set; } = [];

		private PackageFile loadedPackage;

		public PackageFile LoadedPackage
		{
			get => loadedPackage;
			set
			{
				loadedPackage = value;
				ResourceTree.Clear();
				ResourceTree.Add(new(loadedPackage, this));
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(LoadedPackage)));
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ResourceTree)));
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(RecentFilesMenuItems)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public async Task LoadConfiguration()
		{
			Configuration = await Configuration.Load();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RecentFilesMenuItems)));
		}
	}
}
