// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

namespace SimPe.Interfaces.Providers
{
	/// <summary>
	/// Interface to obtain the SimNames Alias List from the Type Registry
	/// </summary>
	public interface ISimNames
	{
		/// <summary>
		/// Returns or sets the Folder where the Character Files are stored
		/// </summary>
		/// <remarks>Automatically Updates the stored Names</remarks>
		string BaseFolder
		{
			get; set;
		}

		/// <summary>
		/// Returrns the stored Alias Data (key is the simid, value an IAlias Object)
		/// </summary>
		Hashtable StoredData
		{
			get; set;
		}

		/// <summary>
		/// Returns the the Alias with the specified Type
		/// </summary>
		/// <param name="id">The id of a Sim</param>
		/// <returns>The Alias of the Sim</returns>
		IAlias FindName(uint id);
	}
}
