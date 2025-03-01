// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Files
{
	/// <summary>
	/// Index Informations stored in the Header
	/// </summary>
	public interface IPackageHeaderIndex : IPackageHeaderHoleIndex
	{
		/// <summary>
		/// returns the Index Type of the File
		/// </summary>
		/// <remarks>This value should be 7</remarks>
		int Type
		{
			get; set;
		}
	}
}
