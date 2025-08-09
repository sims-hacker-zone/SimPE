// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using SimPe.Sims2.Data;
using SimPe.Common.Extensions;
using SimPe.Sims2.Models.Package;
using SimPe.Sims2.Models.Resource;
using SimPe.Sims2.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims1.Data;

namespace SimPe.ViewModels.ResourceTree;

public partial class ResourceTreeTypeViewModel : INotifyPropertyChanged
{
	internal ResourceTreeViewModel parent;
	public event PropertyChangedEventHandler PropertyChanged;

	private readonly IFile file;

	private readonly uint type;

	public ObservableCollection<IResource> Files { get; private set; }

	public FlatTreeDataGridSource<IResource> FileSource { get; set; }

	public bool HasWrapper { get; private set; }

	public string Caption { get; private set; }

	public ResourceTreeTypeViewModel(IFile file, uint type, ResourceTreeViewModel parent)
	{
		this.file = file;
		this.type = type;
		this.parent = parent;
		switch (file)
		{
			case PackageFile packageFile:
				Files = new(packageFile.Resources.Where(item =>
					(item as Sims2.Models.Resource.Resource).Type.Item == (FileTypes)type));
				FileSource = new(Files);
				FileSource.Columns.AddRange([
					new TextColumn<IResource, string>("Name", x => (x as Sims2.Models.Resource.Resource).DisplayName),
					new TextColumn<IResource, string>("Type",
						x =>
							$"{(x as Sims2.Models.Resource.Resource).TypeInfo.ShortName} (0x{(uint)(x as Sims2.Models.Resource.Resource).Type.Item:X8})"),
					new TextColumn<IResource, string>("Group",
						x => $"0x{(x as Sims2.Models.Resource.Resource).Group:X8}"),
					new TextColumn<IResource, string>("Instance (high)",
						x => $"0x{(x as Sims2.Models.Resource.Resource).InstanceHigh:X8}"),
					new TextColumn<IResource, string>("Instance",
						x => $"0x{(x as Sims2.Models.Resource.Resource).Instance:X8}"),
					new TextColumn<IResource, int>("Size", x => (x as Sims2.Models.Resource.Resource).Size),
					new TextColumn<IResource, string>("Uncompressed size",
						x =>
							$"{((x as Sims2.Models.Resource.Resource).UncompressedSize == 0 ? "" : (x as Sims2.Models.Resource.Resource).UncompressedSize)}"),
				]);
				HasWrapper = Wrappers.Unserializers.ContainsKey((FileTypes)type);
				Caption =
					$"{((FileTypes)type).ToFileTypeInformation().LongName} ({((FileTypes)type).ToFileTypeInformation().ShortName}) ({Files.Count})";
				break;
			case Sims1.Models.IFFFile.IFFFile iffFile:
				Files = new(iffFile.Resources.Where(item =>
					(item as Sims1.Models.Resource.Resource).Type.Item == (ResourceTypes)type));
				FileSource = new(Files);
				FileSource.Columns.AddRange([
					new TextColumn<IResource, string>("Name", x => (x as Sims1.Models.Resource.Resource).DisplayName),
					new TextColumn<IResource, string>("Type",
						x =>
							$"{(x as Sims1.Models.Resource.Resource).Type.Item} (0x{(uint)(x as Sims1.Models.Resource.Resource).Type.Item:X8})"),
					new TextColumn<IResource, string>("ID", x => $"0x{(x as Sims1.Models.Resource.Resource).ID:X4}"),
					new TextColumn<IResource, uint>("Size", x => (x as Sims1.Models.Resource.Resource).Size),
				]);
				Caption = $"{(ResourceTypes)type} ({Files.Count})";
				break;
		}

		FileSource.RowSelection.SelectionChanged += parent.parent.Parent.RowSelection_Changed;
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Files)));
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileSource)));
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Caption)));
	}
}
