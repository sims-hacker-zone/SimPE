// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Packages
{
	/// <summary>
	/// Structure of an HoleIndex Item
	/// </summary>
	public class HoleIndexItem
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="offset">the offset of the Hole</param>
		/// <param name="size">the size of the Hole</param>
		public HoleIndexItem(uint offset, int size)
		{
			this.offset = offset;
			this.size = size;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		internal HoleIndexItem()
		{
			offset = 0;
			size = 0;
		}

		/// <summary>
		/// Location of the File within the Package
		/// </summary>
		internal uint offset;

		/// <summary>
		/// Returns the Location of the File within the Package
		/// </summary>
		public uint Offset
		{
			get => offset;
			set => offset = value;
		}

		/// <summary>
		/// Size of the compressed File
		/// </summary>
		internal int size;

		/// <summary>
		/// Returns the Size of the File
		/// </summary>
		public virtual int Size
		{
			get => size;
			set => size = value;
		}

		/// <summary>
		/// return true if the passed Hole Index directly follows this one
		/// </summary>
		/// <param name="hii">another Hole</param>
		/// <returns>true if it follows the current Hole</returns>
		public bool IsMyFollowup(HoleIndexItem hii)
		{
			return (offset + size) == hii.Offset;
		}
	}
}
