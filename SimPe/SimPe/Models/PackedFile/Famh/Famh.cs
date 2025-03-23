// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Models.PackedFile.Fami;
using SimPe.Views.PackedFile.Famh;

namespace SimPe.Models.PackedFile.Famh
{
	public partial class Famh(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		private static ReadOnlySpan<byte> SIGNATURE => "hMAF"u8;

		[ObservableProperty]
		private EnumDisplayNameItem<FamiVersion> version;

		[ObservableProperty]
		private ObservableCollection<FamhEntry> entries = [];

		public UserControl Panel
		{
			get; set;
		}

		public string FriendlyName => null;

		public static Famh Unserialize(BinaryReader reader, PackedFile file)
		{
			Famh famh = new(file);
			if (!SIGNATURE.SequenceEqual(reader.ReadBytes(4)))
			{
				throw new InvalidDataException();
			}
			famh.Version = new((FamiVersion)reader.ReadUInt32());
			reader.ReadBytes(5);
			int entryCount = reader.ReadInt32();
			for (int i = 0; i < entryCount; i++)
			{
				famh.Entries.Add(FamhEntry.Unserialize(reader, famh));
			}
			famh.Panel = new FamhPanel() { DataContext = famh };
			return famh;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(SIGNATURE);
			writer.Write((uint)Version.Item);
			writer.Write([0, 0, 0, 0, 0]);
			writer.Write(Entries.Count);
			foreach (FamhEntry item in Entries)
			{
				item.Serialize(writer);
			}
		}
	}
}
