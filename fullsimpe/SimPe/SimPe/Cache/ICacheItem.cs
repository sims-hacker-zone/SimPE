// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Cache
{
	/// <summary>
	/// Contains one CacheItem
	/// </summary>
	public interface ICacheItem
	{
		/// <summary>
		/// Load the Item from the Stream
		/// </summary>
		/// <param name="reader">the Stream Reader</param>
		void Load(System.IO.BinaryReader reader);

		/// <summary>
		/// Save the Item to the Stream
		/// </summary>
		/// <param name="writer">the Stream Writer</param>
		void Save(System.IO.BinaryWriter writer);

		/// <summary>
		/// Returns the Version of this CacheItem
		/// </summary>
		byte Version
		{
			get;
		}
	}
}
