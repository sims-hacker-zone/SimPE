// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Data;
using SimPe.Sims2.Models.Package;
using SimPe.Sims2.Views.Resource.Clst;

namespace SimPe.Sims2.Models.Resource.Clst;

public partial class Clst(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private ObservableCollection<ClstItem> items = [];

	public UserControl Panel { get; private set; }

	public string FriendlyName => null;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		Clst clst = new(file);
		int size = file.Size;
		int count = (file.File as PackageFile).Header.IndexType == IndexTypes.ptLongFileIndex
			? size / 20
			: size / 16;
		for (int i = 0; i < count; i++)
		{
			clst.Items.Add(ClstItem.Unserialize(reader, clst));
		}

		clst.Panel = new ClstPanel() { DataContext = clst };
		return clst;
	}

	public void Serialize(BinaryWriter writer)
	{
		foreach (ClstItem item in Items)
		{
			item.Serialize(writer);
		}
	}
}
