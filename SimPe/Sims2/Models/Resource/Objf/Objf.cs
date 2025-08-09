// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Views.Resource.Objf;

namespace SimPe.Sims2.Models.Resource.Objf;

public partial class Objf(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private string resourceName;

	private readonly byte[] Header = [0, 0, 0, 0, 0, 0, 0, 0, .. "fJBO"u8];

	[ObservableProperty] private ObservableCollection<ObjfEntry> entries = [];

	public UserControl Panel { get; private set; }

	public string FriendlyName => ResourceName;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		Objf objf = new(file)
		{
			ResourceName = Encoding.ASCII.GetString(reader.ReadBytes(64))
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
		byte[] fileNameBytes = Encoding.ASCII.GetBytes(ResourceName);
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
