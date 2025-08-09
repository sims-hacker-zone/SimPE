// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims1.Models.IFFFile;
using SimPe.Sims1.Models.Resource;
using SimPe.Sims2.Models.Package;
using SimPe.Sims2.Models.Resource;

namespace SimPe.ViewModels.ResourceTree;

public partial class ResourceTreeViewModel : INotifyPropertyChanged
{
	internal MainWindowViewModel parent;
	public event PropertyChangedEventHandler PropertyChanged;

	private readonly IFile file;

	public ObservableCollection<ResourceTreeTypeViewModel> Nodes { get; set; }

	public FlatTreeDataGridSource<IResource> FileSource { get; set; }

	public string Caption => $"All Resources ({file.Resources.Count})";

	public ResourceTreeViewModel(IFile file, MainWindowViewModel parent)
	{
		this.file = file;
		this.parent = parent;
		FileSource = new(file.Resources);

		if (file is PackageFile packageFile)
		{
			Nodes = new(file.Resources.GroupBy(item => (item as Sims2.Models.Resource.Resource).Type)
				.Select(item => new ResourceTreeTypeViewModel(packageFile, (uint)item.Key.Item, this))
				.OrderBy(item => item.Caption));
			FileSource.Columns.Clear();
			FileSource.Columns.AddRange([
				new TextColumn<IResource, string>("Name", x => (x as Sims2.Models.Resource.Resource).DisplayName),
				new TextColumn<IResource, string>("Type",
					x =>
						$"{(x as Sims2.Models.Resource.Resource).TypeInfo.ShortName} (0x{(uint)(x as Sims2.Models.Resource.Resource).Type.Item:X8})"),
				new TextColumn<IResource, string>("Group", x => $"0x{(x as Sims2.Models.Resource.Resource).Group:X8}"),
				new TextColumn<IResource, string>("Instance (high)",
					x => $"0x{(x as Sims2.Models.Resource.Resource).InstanceHigh:X8}"),
				new TextColumn<IResource, string>("Instance",
					x => $"0x{(x as Sims2.Models.Resource.Resource).Instance:X8}"),
				new TextColumn<IResource, int>("Size", x => (x as Sims2.Models.Resource.Resource).Size),
				new TextColumn<IResource, string>("Uncompressed size",
					x =>
						$"{((x as Sims2.Models.Resource.Resource).UncompressedSize == 0 ? "" : (x as Sims2.Models.Resource.Resource).UncompressedSize)}"),
			]);
		}
		else if (file is IFFFile iffFile)
		{
			Nodes = new(file.Resources.GroupBy(item => (item as Sims1.Models.Resource.Resource).Type)
				.Select(item => new ResourceTreeTypeViewModel(iffFile, (uint)item.Key.Item, this))
				.OrderBy(item => item.Caption));
			FileSource.Columns.Clear();
			FileSource.Columns.AddRange([
				new TextColumn<IResource, string>("Name", x => (x as Sims1.Models.Resource.Resource).DisplayName),
				new TextColumn<IResource, string>("Type",
					x =>
						$"{(x as Sims1.Models.Resource.Resource).Type.Item} (0x{(uint)(x as Sims1.Models.Resource.Resource).Type.Item:X8})"),
				new TextColumn<IResource, string>("ID", x => $"0x{(x as Sims1.Models.Resource.Resource).ID:X4}"),
				new TextColumn<IResource, uint>("Size", x => (x as Sims1.Models.Resource.Resource).Size),
			]);
		}

		FileSource.RowSelection.SelectionChanged += parent.Parent.RowSelection_Changed;
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Caption)));
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nodes)));
	}
}
