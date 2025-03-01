// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Wrapper
{
	/// <summary>
	/// Interface for Sim Description Files
	/// </summary>
	public interface IGroupCacheItem
	{
		/// <summary>
		/// Returns the FileName for this Item
		/// </summary>
		string FileName
		{
			get;
		}

		/// <summary>
		/// Returns the Group that was assigned by the Game
		/// </summary>
		uint LocalGroup
		{
			get;
		}
	}
}
