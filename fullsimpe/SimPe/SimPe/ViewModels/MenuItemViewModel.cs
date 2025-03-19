// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Windows.Input;

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
	}
}
