// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Linq;
using System.Reactive.Linq;

using Avalonia.Controls;
using Avalonia.Controls.Selection;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

using SimPe.Models;
using SimPe.Models.Package;
using SimPe.Models.PackedFile;
using SimPe.ViewModels;
using SimPe.Views.Tabs;
using SimPe.Views.Windows;

namespace SimPe
{
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
							AncestorType=typeof(MainWindow)
						}
					}
				}),
				new("Package Info", new PackageInfoTab()
				{
					[!DataContextProperty] = new Binding("DataContext.LoadedPackage")
					{
						RelativeSource = new(RelativeSourceMode.FindAncestor)
						{
							AncestorType=typeof(MainWindow)
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
							AncestorType=typeof(MainWindow)
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
							AncestorType=typeof(MainWindow)
						}
					}
				}),
			};
		}

		internal async void BtnOpen_Click(object sender, RoutedEventArgs e)
		{
			System.Collections.Generic.IReadOnlyList<IStorageFile> filelist = await GetTopLevel(this).StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
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
				]
			});
			if (filelist.Any())
			{
				string path = Uri.UnescapeDataString(filelist[0].Path.AbsolutePath);
				(DataContext as MainWindowViewModel).Configuration.RecentFiles.Insert(0, path);
				(DataContext as MainWindowViewModel).Configuration.RecentFiles = new((DataContext as MainWindowViewModel).Configuration.RecentFiles.Take(15));
				(DataContext as MainWindowViewModel).LoadedPackage = await PackageFile.Open(filelist[0]);
				Title = $"SimPe - {path}";
				await (DataContext as MainWindowViewModel).Configuration.Save();
			}
		}

		internal async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			await (DataContext as MainWindowViewModel).LoadConfiguration();
		}

		internal void BtnChunk_Click(object sender, RoutedEventArgs e)
		{
			Console.WriteLine($"Clicked: {sender}");
		}

		internal void TreeDataGrid_SelectionChanging(object sender, RoutedEventArgs e)
		{
			Console.WriteLine($"Selected {sender.GetType()}: {sender}");
		}

		internal void RowSelection_Changed(object sender, TreeSelectionModelSelectionChangedEventArgs<PackedFile> e)
		{
			e.SelectedItems[0]?.ReadContent();
		}

		internal void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
		{
			SettingsWindow w = new((DataContext as MainWindowViewModel).Configuration);
			w.Show(this);
		}
	}
}
