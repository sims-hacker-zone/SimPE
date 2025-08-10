// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using SimPe.Common.Extensions;
using SimPe.Sims1.Models.Configuration;
using SimPe.Sims1.Data;
using InstalledGame = SimPe.Sims1.Models.Configuration.InstalledGame;
using InstallPath = SimPe.Sims1.Models.Configuration.InstallPath;

namespace SimPe.Sims1.Views.Configuration;

public partial class ConfigurationControl : UserControl
{
	public ConfigurationControl()
	{
		DataContext = Models.Configuration.Configuration.Config;
		InitializeComponent();
	}

	private void AddGame_OnClick(object? sender, RoutedEventArgs e)
	{
		(DataContext as Sims1Config)?.InstalledGames.Add(new()
		{
			Type = new(GameTypes.Sims1),
			Paths = [new InstallPath { Item = new(GameFolders.BaseGame) }]
		});
	}

	private void RemoveGame_OnClick(object? sender, RoutedEventArgs e)
	{
		if (GameList.SelectedItem is InstalledGame game)
		{
			(DataContext as Sims1Config)?.InstalledGames.Remove(game);
		}
	}

	private void GameType_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
	}

	private async void SetNewPath_OnClick(object? sender, RoutedEventArgs e)
	{
		if (sender is not Button { DataContext: InstallPath path })
		{
			return;
		}

		IReadOnlyList<IStorageFolder> folder = await Program.MainWindow.StorageProvider.OpenFolderPickerAsync(
			new()
			{
				AllowMultiple = false, Title = $"Select installation folder of {path.Item}",
			});
		if (folder.Any())
		{
			path.Path = Uri.UnescapeDataString(folder[0].Path.AbsolutePath);
		}
	}
}
