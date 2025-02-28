// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Interfaces.Files;

namespace SimPe.Interfaces.Providers
{
	/// <summary>
	/// Common Interface for Providers needing a Package File
	/// </summary>
	public interface ICommonPackage
	{
		/// <summary>
		/// Returns or sets the Folder where the Character Files are stored
		/// </summary>
		/// <remarks>Sets the names List to null</remarks>
		IPackageFile BasePackage
		{
			get; set;
		}

		/// <summary>
		/// Fired, whenever the <see cref="BasePackage"/> was changed
		/// </summary>
		event EventHandler ChangedPackage;
	}
}
