// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Wrapper
{
	/// <summary>
	/// Interface for Sim Description Files
	/// </summary>
	public interface IGroupCache
	{
		/// <summary>
		/// Return an apropriate Item for the passed File
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		IGroupCacheItem GetItem(string flname);
	}
}
