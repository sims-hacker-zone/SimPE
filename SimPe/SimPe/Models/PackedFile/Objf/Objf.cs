// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Objf;

namespace SimPe.Models.PackedFile.Objf
{
	public partial class Objf(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private string fileName;

		private readonly byte[] Header = [0, 0, 0, 0, 0, 0, 0, 0, .. "fJBO"u8];

		[ObservableProperty]
		private ObservableCollection<ObjfEntry> entries = [];

		public UserControl Panel
		{
			get; private set;
		}

		public string FriendlyName => FileName;

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Objf objf = new(file)
			{
				FileName = Encoding.ASCII.GetString(reader.ReadBytes(64))
			};
			if (!reader.ReadBytes(12).SequenceEqual(objf.Header))
			{
				throw new InvalidDataException("Invalid Objf file");
			}
			uint entryCount = reader.ReadUInt32();
			for (ushort i = 0; i < entryCount; i++)
			{
				objf.Entries.Add(ObjfEntry.Unserialize(reader, i, objf));
			}
			objf.Panel = new ObjfPanel
			{
				DataContext = objf
			};
			return objf;
		}

		public void Serialize(BinaryWriter writer)
		{
			byte[] fileNameBytes = Encoding.ASCII.GetBytes(FileName);
			Array.Resize(ref fileNameBytes, 64);
			writer.Write(fileNameBytes);
			writer.Write(Header);
			writer.Write(Entries.Count);
			foreach (ObjfEntry entry in Entries)
			{
				entry.Serialize(writer);
			}
		}
	}
}
