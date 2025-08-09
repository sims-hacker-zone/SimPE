// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Selection;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using SimPe.Sims2.Data;
using SimPe.Common.Extensions;
using SimPe.Common.Models;
using SimPe.Sims2.Models.Package;
using SimPe.Sims2.Models.Resource;
using SimPe.ViewModels;
using SimPe.Sims2.ViewModels.NeighborhoodBrowser;
using SimPe.Views.Tabs;
using SimPe.Views.Windows;
using SimPe.Sims2.Views.Windows;
using SimPe.Common.Models.Interfaces;
using SimPe.ViewModels.ResourceTree;

namespace SimPe;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		DataContext = new MainWindowViewModel(this);
		InfoTabs.DataContext = new TabItemViewModel[]
		{
			new("Resource Info", new ResourceInfoTab()
			{
				[!DataContextProperty] = new Binding("SelectedItem.FileSource.RowSelection.SelectedItem")
				{
					ElementName = "ResourceTreeView",
					NameScope = new(this.FindNameScope()),
					RelativeSource = new(RelativeSourceMode.FindAncestor)
					{
						AncestorType = typeof(MainWindow)
					}
				}
			}),
			new("Package Info", new PackageInfoTab()
			{
				[!DataContextProperty] = new Binding("DataContext.LoadedFile")
				{
					RelativeSource = new(RelativeSourceMode.FindAncestor)
					{
						AncestorType = typeof(MainWindow)
					}
				}
			}),
			new("Hex Viewer", new HexViewerTab()
			{
				[!DataContextProperty] = new Binding("SelectedItem.FileSource.RowSelection.SelectedItem")
				{
					ElementName = "ResourceTreeView",
					NameScope = new(this.FindNameScope()),
					RelativeSource = new(RelativeSourceMode.FindAncestor)
					{
						AncestorType = typeof(MainWindow)
					}
				}
			}),
			new("Wrapper View", new WrapperTab()
			{
				[!DataContextProperty] = new Binding("SelectedItem.FileSource.RowSelection.SelectedItem")
				{
					ElementName = "ResourceTreeView",
					NameScope = new(this.FindNameScope()),
					RelativeSource = new(RelativeSourceMode.FindAncestor)
					{
						AncestorType = typeof(MainWindow)
					}
				}
			}),
		};
	}

	internal async void BtnOpen_Click(object sender, RoutedEventArgs e)
	{
		System.Collections.Generic.IReadOnlyList<IStorageFile> fileList = await GetTopLevel(this).StorageProvider
			.OpenFilePickerAsync(new()
			{
				AllowMultiple = false,
				Title = "Open Package File",
				FileTypeFilter =
				[
					.. Common.Models.FileLoader.FileTypeFullFilter,
					new("All Files")
					{
						Patterns = ["*.*"]
					}
				]
			});
		if (!fileList.Any()) return;
		await FileLoader.OpenFile(fileList[0]);
		(DataContext as MainWindowViewModel).ResourceTree.Clear();
		(DataContext as MainWindowViewModel).ResourceTree.Add(
			new(FileLoader.Instance.OpenedFile,
				DataContext as MainWindowViewModel));
		Common.Configuration.Configuration.Config.RecentFiles = new(
			Common.Configuration.Configuration.Config.RecentFiles.Count > 14
				? [fileList[0].Path.AbsolutePath, ..Common.Configuration.Configuration.Config.RecentFiles.Take(14)]
				: [fileList[0].Path.AbsolutePath, ..Common.Configuration.Configuration.Config.RecentFiles]);
	}

	internal async void Window_Loaded(object sender, RoutedEventArgs e)
	{
		await Common.Configuration.Configuration.Load();
		await Sims2.Models.Configuration.Configuration.Load();
		//await (DataContext as MainWindowViewModel).LoadConfiguration();
		// foreach (EnumDisplayNameItem<PackageFolders> item in new EnumDisplayNameItem<PackageFolders>(PackageFolders.BaseGame).Values)
		// {
		// 	bool enabled = false;
		// 	IStorageFolder folder;
		// 	InstalledExpansionConfig installfolder = (DataContext as MainWindowViewModel).Configuration.ExpansionInstallPaths.FirstOrDefault(x => x.Item == item);
		// 	if (installfolder != null)
		// 	{
		// 		folder = item.Item >= PackageFolders.SaveGameSims2
		// 			? await StorageProvider.TryGetFolderFromPathAsync(installfolder.Path)
		// 			: await StorageProvider.TryGetFolderFromPathAsync(Path.Combine(installfolder.Path, "TSData", "Res"));
		// 		if (folder != null)
		// 		{
		// 			enabled = true;
		// 			(DataContext as MainWindowViewModel).OpenInMenuItems.Add(new MenuItemViewModel(DataContext as MainWindowViewModel)
		// 			{
		// 				Header = $"{item.Str}{(item.Item < PackageFolders.SaveGameSims2 ? ": TSData/Res" : "")}...",
		// 				CommandParameter = Uri.UnescapeDataString(folder.Path.AbsolutePath),
		// 				Enabled = true
		// 			});
		// 		}
		// 	}
		// 	if (!enabled)
		// 	{
		// 		(DataContext as MainWindowViewModel).OpenInMenuItems.Add(new MenuItemViewModel(DataContext as MainWindowViewModel)
		// 		{
		// 			Header = $"{item.Str}{(item.Item < PackageFolders.SaveGameSims2 ? ": TSData/Res" : "")}...",
		// 			Enabled = false
		// 		});
		// 	}
		// }
	}

	internal void BtnChunk_Click(object sender, RoutedEventArgs e)
	{
		Console.WriteLine($"Clicked: {sender}");
	}

	internal void RowSelection_Changed(object sender, TreeSelectionModelSelectionChangedEventArgs<IResource> e)
	{
		e.SelectedItems[0]?.ReadContent();
	}

	internal void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
	{
		SettingsWindow w = new();
		w.Show(this);
	}

	internal void NeighborhoodBrowserOpen_Click(object sender, RoutedEventArgs e)
	{
		new NeighborhoodBrowser
		{
			DataContext = DataContext as MainWindowViewModel
		}.Show(this);
	}

	internal async void Window_Closing(object sender, WindowClosingEventArgs e)
	{
		//await (DataContext as MainWindowViewModel).Configuration.Save();
	}

	internal void FindInFiles_Click(object sender, RoutedEventArgs e)
	{
		new FindInFiles { DataContext = new FindInFilesViewModel(DataContext as MainWindowViewModel) }.Show();
	}

	private async void SaveAs_OnClick(object? sender, RoutedEventArgs e)
	{
		if (FileLoader.Instance.OpenedFile == null) return;
		IStorageFile? file = await GetTopLevel(this).StorageProvider.SaveFilePickerAsync(new()
		{
			Title = "Save as...",
			ShowOverwritePrompt = true,
			SuggestedStartLocation = await FileLoader.Instance.OpenedFile.StorageFile.GetParentAsync(),
			SuggestedFileName = FileLoader.Instance.OpenedFile.StorageFile.Name,
			FileTypeChoices =
			[
				new($"*.{FileLoader.Instance.OpenedFile.StorageFile.Name.Split('.').Last()}")
				{
					Patterns = [$"*.{FileLoader.Instance.OpenedFile.StorageFile.Name.Split('.').Last()}"]
				}
			]
		});
		if (file != null)
		{
			await FileLoader.Instance.OpenedFile.Save(file);
		}
	}

	private void Exit_OnClick(object? sender, RoutedEventArgs e)
	{
		Close();
	}
}
