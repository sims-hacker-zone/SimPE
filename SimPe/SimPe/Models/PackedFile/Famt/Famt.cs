// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Famt;
using SimPe.Views.PackedFile.Ngbh;

namespace SimPe.Models.PackedFile.Famt
{
	public partial class Famt(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private EnumDisplayNameItem<FamtVersion> version;

		[ObservableProperty]
		private ObservableCollection<FamtSim> sims = [];

		public UserControl Panel
		{
			get; set;
		}

		public string FriendlyName => "Family Ties";

		public static Famt Unserialize(BinaryReader reader, PackedFile file)
		{
			Famt famt = new(file)
			{
				Version = new((FamtVersion)reader.ReadUInt32())
			};
			if (famt.Version.Item != FamtVersion.Version1)
			{
				throw new InvalidDataException();
			}
			uint simCount = reader.ReadUInt32();
			for (int i = 0; i < simCount; i++)
			{
				famt.Sims.Add(FamtSim.Unserialize(reader, famt));
			}
			famt.Panel = new FamtPanel() { DataContext = famt };
			return famt;
		}
		public void Serialize(BinaryWriter writer)
		{
			writer.Write((uint)Version.Item);
			writer.Write(Sims.Count);
			foreach (FamtSim item in Sims)
			{
				item.Serialize(writer);
			}
		}
	}
}
