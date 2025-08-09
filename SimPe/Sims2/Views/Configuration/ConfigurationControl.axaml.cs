// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using CommunityToolkit.HighPerformance.Enumerables;
using SimPe.Common.Extensions;
using SimPe.Sims2.Data;
using SimPe.Sims2.Models.Configuration;
using SimPe.ViewModels;

namespace SimPe.Sims2.Views.Configuration;

public partial class ConfigurationControl : UserControl
{
	public ConfigurationControl()
	{
		DataContext = Models.Configuration.Configuration.Config;
		InitializeComponent();
	}

	private void AddGame_OnClick(object? sender, RoutedEventArgs e)
	{
		(DataContext as Sims2Config)?.InstalledGames.Add(new());
	}

	private void RemoveGame_OnClick(object? sender, RoutedEventArgs e)
	{
		if (GameList.SelectedItem is InstalledGame game)
		{
			(DataContext as Sims2Config)?.InstalledGames.Remove(game);
		}
	}

	private void GameType_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (GameList.SelectedItem is not InstalledGame game) return;
		if ((EnumDisplayNameItem<GameTypes>)(sender as ComboBox).SelectedItem == GameTypes.Sims2)
		{
			foreach (EnumDisplayNameItem<PackageFolders> value in new EnumDisplayNameItem<PackageFolders>(PackageFolders
				         .BaseGame).Values)
			{
				if (game.Paths.All(x => x.Item != value))
				{
					game.Paths.Add(new()
					{
						Item = value,
						Path = ""
					});
				}
			}

			game.Paths = new(game.Paths.OrderBy(x => x.Item.Item));
		}
		else
		{
			game.Paths = new(game.Paths.Where((path =>
				path.Item == PackageFolders.BaseGame || path.Item == PackageFolders.SaveGame)));
			foreach (EnumDisplayNameItem<PackageFolders> value in new List<EnumDisplayNameItem<PackageFolders>>(
			         [
				         new(PackageFolders.BaseGame),
				         new(PackageFolders.SaveGame)
			         ]).Where(value => !(GameList.SelectedItem as InstalledGame).Paths.Any(x => x.Item == value)))
			{
				game.Paths.Add(new()
				{
					Item = value,
					Path = ""
				});
			}
		}
	}

	private async void SetNewPath_OnClick(object? sender, RoutedEventArgs e)
	{
		if (sender is Button { DataContext: InstallPath path })
		{
			IStorageFolder baseGameFolder = path.Item < PackageFolders.SaveGame
				? await Program.MainWindow.StorageProvider.TryGetFolderFromPathAsync(
					(GameList.SelectedItem as InstalledGame).Paths
					.Where(x => x.Item == PackageFolders.BaseGame)
					.Select(x => x.Path)
					.FirstOrDefault(""))
				: await Program.MainWindow.StorageProvider.TryGetWellKnownFolderAsync(WellKnownFolder.Documents);
			IReadOnlyList<IStorageFolder> folder = await Program.MainWindow.StorageProvider.OpenFolderPickerAsync(
				new FolderPickerOpenOptions
				{
					AllowMultiple = false, Title = $"Select installation folder of {path.Item}",
					SuggestedStartLocation = baseGameFolder
				});
			if (folder?.Any() == true)
			{
				path.Path = Uri.UnescapeDataString(folder[0].Path.AbsolutePath);
			}
		}
	}
}
