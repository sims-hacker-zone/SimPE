// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Linq;

using Avalonia.Controls;

using Microsoft.VisualBasic;

using SimPe.Data;
using SimPe.Extensions;

namespace SimPe.Views.PackedFile.Idno
{
	internal struct IdnoVersionComboBoxItem
	{
		internal NeighborhoodVersion Item
		{
			get;
			set;
		}

		internal readonly string Str => $"{Item.GetDisplayName()} (0x{(uint)Item:X})";
	}
	public partial class IdnoPanel : UserControl
	{
		public IdnoPanel(Models.PackedFile.Idno.Idno idno)
		{
			DataContext = idno;
			InitializeComponent();
			VersionComboBox.ItemsSource = from item in Enum.GetValues<NeighborhoodVersion>()
										  select new IdnoVersionComboBoxItem { Item = item };
			VersionComboBox.SelectedItem = (from IdnoVersionComboBoxItem item in VersionComboBox.ItemsSource
											where item.Item == (DataContext as Models.PackedFile.Idno.Idno).Version
											select item).FirstOrDefault();
		}
	}
}
