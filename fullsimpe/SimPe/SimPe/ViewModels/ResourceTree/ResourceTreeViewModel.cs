// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;

using SimPe.Models.Package;
using SimPe.Models.PackedFile;

namespace SimPe.ViewModels.ResourceTree
{
	public partial class ResourceTreeViewModel : INotifyPropertyChanged
	{
		internal MainWindowViewModel parent;
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly PackageFile packageFile;

		public ObservableCollection<ResourceTreeTypeViewModel> Nodes
		{
			get; set;
		}

		public FlatTreeDataGridSource<PackedFile> FileSource
		{
			get; set;
		}

		public string Caption => $"All Resources ({packageFile.FileIndex.Count})";

		public ResourceTreeViewModel(PackageFile packageFile, MainWindowViewModel parent)
		{
			this.packageFile = packageFile;
			this.parent = parent;
			Nodes = new(packageFile.FileIndex.GroupBy(item => item.Type).Select(item => new ResourceTreeTypeViewModel(packageFile, item.Key, this)).OrderBy(item => item.Caption));
			FileSource = new(packageFile.FileIndex);
			FileSource.Columns.AddRange([
				new TextColumn<PackedFile, string>("Name", x => x.DisplayName),
				new TextColumn<PackedFile, string>("Type", x => x.TypeInfo.ShortName),
				new TextColumn<PackedFile, string>("Group", x => $"0x{x.Group:X8}"),
				new TextColumn<PackedFile, string>("Instance (high)", x => $"0x{x.InstanceHigh:X8}"),
				new TextColumn<PackedFile, string>("Instance", x => $"0x{x.Instance:X8}"),
				new TextColumn<PackedFile, int>("Size", x => x.Size),
				new TextColumn<PackedFile, string>("Uncompressed size", x => $"{(x.UncompressedSize == 0 ? "" : x.UncompressedSize)}"),
			]);
			FileSource.RowSelection.SelectionChanged += parent.Parent.RowSelection_Changed;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Caption)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nodes)));
		}
	}
}
