// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Packages
{
	/// <summary>
	/// Hole Index of the File
	/// </summary>
	/// <remarks>
	/// Holes ar simple Placeholders filled with Data currently nor usefull.
	/// </remarks>
	public class HeaderHole : Interfaces.Files.IPackageHeaderHoleIndex
	{
		/// <summary>
		/// Number of Holes stored in the File
		/// </summary>
		internal int count;

		/// <summary>
		/// Returns the Number of items stored in the Index
		/// </summary>
		public int Count
		{
			get => count;
			set => count = value;
		}

		/// <summary>
		/// Offset for the Hole Index
		/// </summary>
		internal uint offset;

		/// <summary>
		/// Returns the Offset for the Hole Index
		/// </summary>
		public uint Offset
		{
			get => offset;
			set => offset = value;
		}

		/// <summary>
		/// Size of the Hole Index
		/// </summary>
		internal int size;

		/// <summary>
		/// Returns the Size of the Hole Index
		/// </summary>
		public int Size
		{
			get => size;
			set => size = value;
		}

		/// <summary>
		/// Returns the size of One Item stored in the index
		/// </summary>
		public virtual int ItemSize => Count != 0 ? Size / Count : 0;
	}
}
