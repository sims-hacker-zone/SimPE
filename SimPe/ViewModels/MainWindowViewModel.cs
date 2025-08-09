// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models;
using SimPe.Common.Models.Interfaces;
using SimPe.ViewModels.ResourceTree;

namespace SimPe.ViewModels;

public partial class MainWindowViewModel(MainWindow parent) : ObservableObject
{
	[ObservableProperty] internal MainWindow parent = parent;
	public ObservableCollection<TabItemViewModel> Tabs { get; set; }
	public IReadOnlyList<MenuItemViewModel> MenuItems { get; set; } = [];

	public ObservableCollection<MenuItemViewModel> OpenInMenuItems { get; set; } = [];

	public static FileLoader FileLoader => FileLoader.Instance;

	// [ObservableProperty]
	// private Configuration configuration = new();

	// public IReadOnlyList<MenuItemViewModel> RecentFilesMenuItems => (from item in Configuration.RecentFiles.Select((item, i) => (item, i)) select new MenuItemViewModel(this) { Header = $"_{item.i}: {(item.item.Length > 50 ? "..." + item.item[^50..] : item.item)}", CommandParameter = item.item }).ToList();

	public ObservableCollection<ResourceTreeViewModel> ResourceTree { get; set; } = [];
}
