// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Models.Interfaces;

namespace SimPe.Common.Models;

public partial class FileLoader : ObservableObject
{
	public static FileLoader Instance { get; } = new();
	private readonly ObservableCollection<Func<IStorageFile, Task<IFile>>> fileLoaders = [];
	[ObservableProperty] private ObservableCollection<IFile> loadedFiles = [];

	[ObservableProperty] private ObservableCollection<IFile> openedFiles = [];

	[ObservableProperty] private IFile? openedFile;

	public static List<FilePickerFileType> FileTypeFilter { get; } = [];

	public static List<FilePickerFileType> FileTypeFullFilter =>
	[
		new("All supported files")
		{
			Patterns = new List<string>(from item in FileTypeFilter from pattern in item.Patterns select pattern)
		},
		..FileTypeFilter
	];

	public static void RegisterFileLoader(Func<IStorageFile, Task<IFile>> loader)
	{
		ArgumentNullException.ThrowIfNull(loader);
		Instance.fileLoaders.Add(loader);
	}

	public static async Task<IFile> OpenFile(IStorageFile file)
	{
		ArgumentNullException.ThrowIfNull(file);

		// Check if the file is already loaded
		IFile? existingFile = Instance.LoadedFiles.FirstOrDefault(f => f.StorageFile == file);
		if (existingFile != null)
		{
			// If the file is already loaded and not explicitly opened, add it to the opened files and return it
			if (!Instance.OpenedFiles.Contains(existingFile))
			{
				Instance.OpenedFiles.Add(existingFile);
				Instance.OnPropertyChanged(nameof(OpenedFiles));
			}

			Instance.OpenedFile = existingFile;
			return existingFile;
		}

		foreach (Func<IStorageFile, Task<IFile>> loader in Instance.fileLoaders)
		{
			try
			{
				IFile loadedFile = await loader(file);
				if (loadedFile != null)
				{
					Instance.LoadedFiles.Add(loadedFile);
					Instance.OnPropertyChanged(nameof(LoadedFiles));
					Instance.OpenedFiles.Add(loadedFile);
					Instance.OnPropertyChanged(nameof(OpenedFiles));
					Instance.OpenedFile = loadedFile;

					return loadedFile;
				}
			}
			catch
			{
			}
		}

		throw new NotSupportedException($"No loader registered for file type: {file.Name}");
	}

	public static async Task<IFile> LoadFile(IStorageFile file)
	{
		ArgumentNullException.ThrowIfNull(file);

		// Check if the file is already loaded
		IFile? existingFile = Instance.LoadedFiles.FirstOrDefault(f => f.StorageFile == file);
		if (existingFile != null)
		{
			return existingFile;
		}

		foreach (Func<IStorageFile, Task<IFile>> loader in Instance.fileLoaders)
		{
			try
			{
				IFile loadedFile = await loader(file);
				if (loadedFile != null)
				{
					Instance.LoadedFiles.Add(loadedFile);
					Instance.OnPropertyChanged(nameof(LoadedFiles));
					return loadedFile;
				}
			}
			catch
			{
			}
		}

		throw new NotSupportedException($"No loader registered for file type: {file.Name}");
	}
}
