// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SimPe.Views.Windows;

public partial class SettingsWindow : Window
{
	public SettingsWindow()
	{
		InitializeComponent();
	}

	private async void SaveConfig_Click(object? sender, RoutedEventArgs e)
	{
		await Common.Configuration.Configuration.Save();
		await Sims1.Models.Configuration.Configuration.Save();
		await Sims2.Models.Configuration.Configuration.Save();
	}
}
