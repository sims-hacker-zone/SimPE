// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Data;

namespace SimPe.Sims2.Models.Package;

public partial class PackageFile : ObservableObject, IFile
{
	[ObservableProperty] private IStorageFile storageFile;

	[ObservableProperty] private PackageHeader header;

	public ObservableCollection<IResource> Resources { get; } = [];

	public bool FileChanged => Resources.Any(resource => resource.ResourceChanged);

	public static async Task<IFile> Open(IStorageFile file)
	{
		PackageFile package = new()
		{
			StorageFile = file
		};

		await using Stream stream = await package.StorageFile.OpenReadAsync();
		using BinaryReader reader = new(stream, Encoding.ASCII);
		reader.BaseStream.Seek(0, SeekOrigin.Begin);

		package.Header = PackageHeader.Unserialize(reader);

		package.UnserializeFileIndex(reader);

		package.OnPropertyChanged(nameof(Resources));

		return package;
	}

	public async Task Save(IStorageFile file)
	{
		ArgumentNullException.ThrowIfNull(file);

		foreach (IResource resource in Resources)
		{
			resource.ReadContent();
		}

		Header.Hole.Count = 0;
		Header.Hole.Offset = 0;
		Header.Hole.Size = 0;

		await using Stream stream = await file.OpenWriteAsync();
		stream.SetLength(0);
		await stream.FlushAsync();
		await using BinaryWriter writer = new(stream, Encoding.ASCII);
		writer.BaseStream.Seek(0, SeekOrigin.Begin);

		Header.Serialize(writer);
		List<FileIndexItem> indices = [];
		foreach (Resource.Resource resource in Resources)
		{
			indices.Add(new()
			{
				Type = (uint)resource.Type.Item,
				Group = resource.Group,
				Instance = resource.Instance,
				InstanceHigh = resource.InstanceHigh,
				Offset = (uint)writer.BaseStream.Position,
				Size = (uint)(resource.UserData ?? resource.Data).Length,
			});
			resource.Serialize(writer);
		}

		Header.Index.Count = indices.Count;
		Header.Index.Offset = (uint)writer.BaseStream.Position;
		Header.Index.Size = (uint)(indices.Count * (Header.IndexType == IndexTypes.ptLongFileIndex ? 24 : 20));

		foreach (FileIndexItem item in indices)
		{
			writer.Write(item.Type);
			writer.Write(item.Group);
			writer.Write(item.Instance);
			if (Header.IndexType == IndexTypes.ptLongFileIndex) writer.Write(item.InstanceHigh);
			writer.Write(item.Offset);
			writer.Write(item.Size);
		}

		writer.BaseStream.Seek(0, SeekOrigin.Begin);
		Header.Serialize(writer);
	}

	public void UnserializeFileIndex(BinaryReader reader)
	{
		reader.BaseStream.Seek(Header.Index.Offset, SeekOrigin.Begin);
		for (int i = 0; i < Header.Index.Count; i++)
		{
			Resources.Add(Resource.Resource.Unserialize(reader, this));
		}
	}

	#region File Search

	public Resource.Resource? FindFile(FileTypes type, uint @group, uint instanceHigh, uint instance)
	{
		return FindFiles(type, @group, instanceHigh, instance).FirstOrDefault();
	}

	public IEnumerable<Resource.Resource> FindFiles(FileTypes? type, uint? @group, uint? instanceHigh, uint? instance)
	{
		return (IEnumerable<Resource.Resource>)(from resource in Resources
		                                        where (type == null || (resource as Resource.Resource).Type == type)
		                                              && (@group == null || (resource as Resource.Resource).Group ==
			                                              @group)
		                                              && (instanceHigh == null ||
		                                                  (resource as Resource.Resource).InstanceHigh == instanceHigh)
		                                              && (instance == null ||
		                                                  (resource as Resource.Resource).Instance == instance)
		                                        select resource as Resource.Resource);
	}

	#endregion

	public override string ToString()
	{
		return $"{(FileChanged ? "* " : "")}{StorageFile.Path.LocalPath} ({Resources.Count} resources)";
	}
}
