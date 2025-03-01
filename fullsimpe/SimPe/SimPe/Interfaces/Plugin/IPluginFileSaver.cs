// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces.Plugin.Internal;

namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// Interface for Filehanders that are able to save their content to a BinaryStream
	/// </summary>
	public interface IFileWrapperSaveExtension : IPackedFileSaveExtension
	{
	}
}
