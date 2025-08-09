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
using SimPe.Common.Extensions;
using SimPe.Sims2.Data;
using SimPe.Sims2.Models.Resource;

namespace SimPe.ViewModels;

public partial class FindInFilesViewModel : ObservableObject
{
	[ObservableProperty] private MainWindowViewModel parent;

	[ObservableProperty] private EnumDisplayNameItem<FileTypes> type = new(FileTypes.ALL_TYPES);

	[ObservableProperty] private uint group;

	[ObservableProperty] private uint instanceHigh;

	[ObservableProperty] private uint instance;

	[ObservableProperty] private ObservableCollection<Resource> foundFiles = [];

	[ObservableProperty] private FlatTreeDataGridSource<Resource> fileSource;

	public FindInFilesViewModel(MainWindowViewModel parent)
	{
		this.parent = parent;
		FileSource = new(FoundFiles);
		FileSource.Columns.AddRange([
			new TextColumn<Resource, string>("File name", x => x.File.StorageFile.TryGetLocalPath()),
			new TextColumn<Resource, string>("Type", x => x.TypeInfo.ShortName),
			new TextColumn<Resource, string>("Group", x => $"0x{x.Group:X8}"),
			new TextColumn<Resource, string>("Instance (high)", x => $"0x{x.InstanceHigh:X8}"),
			new TextColumn<Resource, string>("Instance", x => $"0x{x.Instance:X8}"),
		]);
	}
}
