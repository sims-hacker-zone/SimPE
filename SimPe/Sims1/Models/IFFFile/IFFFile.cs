// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;

namespace SimPe.Sims1.Models.IFFFile;

public partial class IFFFile : ObservableObject, IFile
{
	[ObservableProperty] private IStorageFile storageFile;

	[ObservableProperty] private IFFFileVersion version;

	[ObservableProperty] private ObservableCollection<IResource> resources = [];

	public static async Task<IFile> Open(IStorageFile file)
	{
		IFFFile iffFile = new()
		{
			StorageFile = file
		};

		await using Stream stream = await iffFile.StorageFile.OpenReadAsync();
		using BinaryReader reader = new(stream, Encoding.ASCII);
		reader.BaseStream.Seek(0, SeekOrigin.Begin);

		if (!reader.ReadBytes(9).SequenceEqual("IFF FILE "u8.ToArray()))
		{
			throw new InvalidDataException("Invalid IFF file");
		}

		byte[] versionBytes = reader.ReadBytes(3);
		iffFile.Version = versionBytes.SequenceEqual("2.0"u8.ToArray())
			? IFFFileVersion.VERSION_2_0
			: versionBytes.SequenceEqual("2.5"u8.ToArray())
				? IFFFileVersion.VERSION_2_5
				: throw new InvalidDataException("Unsupported IFF file version");

		if (iffFile.Version == IFFFileVersion.VERSION_2_0)
		{
			if (!reader.ReadBytes(52)
			           .SequenceEqual((":TYPE FOLLOWED BY SIZE\0"u8 + " JAMIE DOORNBOS & MAXIS 1996\0"u8).ToArray()))
			{
				throw new InvalidDataException("Invalid IFF file header for version 2.0");
			}
		}
		else if (iffFile.Version == IFFFileVersion.VERSION_2_5)
		{
			if (!reader.ReadBytes(48)
			           .SequenceEqual((":TYPE FOLLOWED BY SIZE\0"u8 + " JAMIE DOORNBOS & MAXIS 1"u8).ToArray()))
			{
				throw new InvalidDataException("Invalid IFF file header for version 2.5");
			}

			reader.ReadUInt32();
		}

		while (reader.BaseStream.Position < reader.BaseStream.Length)
		{
			Resource.Resource? resource = Resource.Resource.Unserialize(reader, iffFile);
			if (resource is not null)
				iffFile.Resources.Add(resource);
		}

		return iffFile;
	}

	public Task Save(IStorageFile file)
	{
		throw new NotImplementedException();
	}

	public override string ToString()
	{
		return $"{StorageFile.Path.LocalPath} ({Resources.Count} resources)";
	}
}
