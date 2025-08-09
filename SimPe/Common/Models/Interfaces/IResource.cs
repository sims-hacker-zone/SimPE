// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Common.Models.Interfaces;

public interface IResource
{
	public IFile File { get; set; }

	public bool ResourceChanged { get; }

	public string DisplayName { get; }

	public void ReadContent()
	{
	}

	public byte[] Data { get; set; }

	public IWrapper Wrapper { get; }
}
