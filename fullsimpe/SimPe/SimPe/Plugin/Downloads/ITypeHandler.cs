// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// This Interface is provided by classes, that read the Content of a certain Object Type
	/// </summary>
	/// <remarks>Defining classes must have a public Constructur that takes no Arguments</remarks>
	public interface ITypeHandler
	{
		/// <summary>
		/// Load the content of the passed package
		/// </summary>
		/// <param name="type"></param>
		/// <param name="pkg"></param>
		void LoadContent(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg
		);

		/// <summary>
		/// Returns informations about the Content stored in the package
		/// </summary>
		IPackageInfo[] Objects
		{
			get;
		}
	}
}
