// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.ThreeIdr;

namespace SimPe.Models.PackedFile.ThreeIdr
{
	public partial class ThreeIdr(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		public static byte[] SIGNATURE => [0xEF, 0xBE, 0xAD, 0xDE];

		[ObservableProperty]
		private EnumDisplayNameItem<IndexTypes> type;

		[ObservableProperty]
		private ObservableCollection<ThreeIdrItem> items = [];

		public UserControl Panel
		{
			get;
			private set;
		}

		public string FriendlyName => null;

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			ThreeIdr threeIdr = new(file);
			if (!SIGNATURE.SequenceEqual(reader.ReadBytes(4)))
			{
				throw new InvalidDataException();
			}
			threeIdr.Type = new((IndexTypes)reader.ReadUInt32());
			uint recordCount = reader.ReadUInt32();
			for (uint i = 0; i < recordCount; i++)
			{
				threeIdr.Items.Add(ThreeIdrItem.Unserialize(reader, threeIdr));
			}
			foreach (ThreeIdrItem item in threeIdr.Items)
			{
				item.PropertyChanged += threeIdr.Item_OnPropertyChanged;
			}
			threeIdr.Panel = new ThreeIdrPanel() { DataContext = threeIdr };

			return threeIdr;
		}

		public void Item_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged(nameof(Items));
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(SIGNATURE);
			writer.Write((uint)Type.Item);
			writer.Write(Items.Count);
			foreach (ThreeIdrItem item in Items)
			{
				item.Serialize(writer);
			}
		}
	}
}
