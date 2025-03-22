// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Models.PackedFile;

namespace SimPe.ViewModels
{
	public partial class FindInFilesViewModel : ObservableObject
	{
		[ObservableProperty]
		private MainWindowViewModel parent;

		[ObservableProperty]
		private EnumDisplayNameItem<FileTypes> type = new(FileTypes.ALL_TYPES);

		[ObservableProperty]
		private uint group;

		[ObservableProperty]
		private uint instanceHigh;

		[ObservableProperty]
		private uint instance;

		[ObservableProperty]
		private ObservableCollection<PackedFile> foundFiles = [];

		[ObservableProperty]
		private FlatTreeDataGridSource<PackedFile> fileSource;

		public FindInFilesViewModel(MainWindowViewModel parent)
		{
			this.parent = parent;
			FileSource = new(FoundFiles);
			FileSource.Columns.AddRange([
				new TextColumn<PackedFile, string>("File name", x => x.Package.StorageFile.TryGetLocalPath()),
				new TextColumn<PackedFile, string>("Type", x => x.TypeInfo.ShortName),
				new TextColumn<PackedFile, string>("Group", x => $"0x{x.Group:X8}"),
				new TextColumn<PackedFile, string>("Instance (high)", x => $"0x{x.InstanceHigh:X8}"),
				new TextColumn<PackedFile, string>("Instance", x => $"0x{x.Instance:X8}"),
			]);
		}

	}
}
