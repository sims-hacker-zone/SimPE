// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Models.Package;
using SimPe.Models.PackedFile;

namespace SimPe.ViewModels.ResourceTree
{
	public partial class ResourceTreeTypeViewModel : INotifyPropertyChanged
	{
		internal ResourceTreeViewModel parent;
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly PackageFile packageFile;

		private readonly FileTypes type;

		public ObservableCollection<PackedFile> Files
		{
			get; private set;
		}

		public FlatTreeDataGridSource<PackedFile> FileSource
		{
			get; set;
		}

		public bool HasWrapper => Wrappers.Unserializers.ContainsKey(type);

		public string Caption => $"{type.ToFileTypeInformation().LongName} ({type.ToFileTypeInformation().ShortName}) ({Files.Count})";

		public ResourceTreeTypeViewModel(PackageFile packageFile, FileTypes type, ResourceTreeViewModel parent)
		{
			this.packageFile = packageFile;
			this.type = type;
			this.parent = parent;
			Files = new(packageFile.FileIndex.Where(item => item.Type == type));
			FileSource = new(Files);
			FileSource.Columns.AddRange([
				new TextColumn<PackedFile, string>("Name", x => x.DisplayName),
				new TextColumn<PackedFile, string>("Type", x => $"{x.TypeInfo.ShortName} (0x{(uint)x.Type:X8})"),
				new TextColumn<PackedFile, string>("Group", x => $"0x{x.Group:X8}"),
				new TextColumn<PackedFile, string>("Instance (high)", x => $"0x{x.InstanceHigh:X8}"),
				new TextColumn<PackedFile, string>("Instance", x => $"0x{x.Instance:X8}"),
				new TextColumn<PackedFile, int>("Size", x => x.Size),
				new TextColumn<PackedFile, string>("Uncompressed size", x => $"{(x.UncompressedSize == 0 ? "" : x.UncompressedSize)}"),
			]);
			FileSource.RowSelection.SelectionChanged += parent.parent.Parent.RowSelection_Changed;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Files)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileSource)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Caption)));
		}
	}
}
