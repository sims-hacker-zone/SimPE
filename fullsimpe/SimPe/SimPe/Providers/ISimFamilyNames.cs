// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

namespace SimPe.Interfaces.Providers
{
	/// <summary>
	/// Interface to obtain the SimFamilyNames Alias List from the Type Registry
	/// </summary>
	public interface ISimFamilyNames : ICommonPackage
	{
		/// <summary>
		/// Returns the the Alias with the specified Type
		/// </summary>
		/// <param name="id">The id of a Sim</param>
		/// <returns>The Alias of the Sim</returns>
		IAlias FindName(uint id);

		/// <summary>
		/// Returns a List of All SimID's found in the Package
		/// </summary>
		/// <returns>The List of found SimID's</returns>
		ArrayList GetAllSimIDs();
	}
}
