// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace SimPe.Common.Models.Interfaces;

public interface IFile
{
	public IStorageFile StorageFile { get; set; }

	public ObservableCollection<IResource> Resources { get; }

	public static virtual Task<IFile> Open(IStorageFile file)
	{
		throw new NotImplementedException();
	}

	public Task Save(IStorageFile file);
}
