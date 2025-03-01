// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Files
{
	/// <summary>
	/// Hole Index of the File
	/// </summary>
	/// <remarks>
	/// Holes ar simple Placeholders filled with Data currently nor usefull.
	/// </remarks>
	public interface IPackageHeaderHoleIndex
	{
		/// <summary>
		/// Returns the Number of items stored in the Index
		/// </summary>
		int Count
		{
			get; set;
		}

		/// <summary>
		/// Returns the Offset for the Hole Index
		/// </summary>
		uint Offset
		{
			get; set;
		}

		/// <summary>
		/// Returns the Size of the Hole Index
		/// </summary>
		int Size
		{
			get; set;
		}

		/// <summary>
		/// Returns the size of One Item stored in the index
		/// </summary>
		int ItemSize
		{
			get;
		}
	}
}
