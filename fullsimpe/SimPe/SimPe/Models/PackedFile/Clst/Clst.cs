// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Clst;

namespace SimPe.Models.PackedFile.Clst
{
	public partial class Clst(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private ObservableCollection<ClstItem> items = [];

		public UserControl Panel
		{
			get; private set;
		}

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Clst clst = new(file);
			int size = file.Size;
			int count = file.Package.Header.IndexType == IndexTypes.ptLongFileIndex ? size / 20 : size / 16;
			for (int i = 0; i < count; i++)
			{
				clst.Items.Add(ClstItem.Unserialize(reader, clst));
			}
			clst.Panel = new ClstPanel(clst);
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
}
