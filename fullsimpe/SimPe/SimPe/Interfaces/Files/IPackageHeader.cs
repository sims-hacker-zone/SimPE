// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Interfaces.Files
{
	/// <summary>
	/// Structural Data of a .package Header
	/// </summary>
	public interface IPackageHeader
	{
		/// <summary>
		/// Create a Clone of the Header
		/// </summary>
		/// <returns></returns>
		object Clone();

		/// <summary>
		/// Returns the Identifier of the File
		/// </summary>
		/// <remarks>This value should be DBPF</remarks>
		string Identifier
		{
			get;
		}

		/// <summary>
		/// Returns the Major Version of The Packages FileFormat
		/// </summary>
		/// <remarks>This value should be 1</remarks>
		int MajorVersion
		{
			get;
		}

		/// <summary>
		/// Returns the Minor Version of The Packages FileFormat
		/// </summary>
		/// <remarks>This value should be 0 or 1</remarks>
		int MinorVersion
		{
			get;
		}

		/// <summary>
		/// Returns the Overall Version of this Package
		/// </summary>
		long Version
		{
			get;
		}

		/// <summary>
		/// Returns or Sets the Type of the Package
		/// </summary>
		Data.IndexTypes IndexType
		{
			get; set;
		}

		/// <summary>
		/// The Icon to display (for lot packages)
		/// </summary>
		short Epicon
		{
			get; set;
		}

		/// <summary>
		/// Should the defined Icon be shown : 1 is true (for lot packages)
		/// </summary>
		short Showicon
		{
			get; set;
		}

		/// <summary>
		/// true if the version is greater or equal than 1.1
		/// </summary>
		bool IsVersion0101
		{
			get;
		}

		/// <summary>
		/// Returns Index Informations stored in the Header
		/// </summary>
		IPackageHeaderIndex Index
		{
			get;
		}

		/// <summary>
		/// Returns Hole Index Informations stored in the Header
		/// </summary>
		IPackageHeaderHoleIndex HoleIndex
		{
			get;
		}

		/// <summary>
		/// This is missused in SimPe as a Unique Creator ID
		/// </summary>
		uint Created
		{
			get; set;
		}
	}
}
