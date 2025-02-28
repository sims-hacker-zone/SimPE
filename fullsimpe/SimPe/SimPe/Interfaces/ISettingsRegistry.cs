// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.Interfaces
{
	/// <summary>
	/// Summary description for ISettingsRegistry.
	/// </summary>
	public interface ISettingsRegistry
	{
		/// <summary>
		/// Registers Settings to the Registry
		/// </summary>
		/// <param name="settings">The Topic to register</param>
		/// <remarks>The tool must only be added if the Registry doesnt already contain it</remarks>
		void RegisterSettings(ISettings settings);

		/// <summary>
		/// Registers all listed Settings with this Registry
		/// </summary>
		/// <param name="settings">The Topics to register</param>
		/// <remarks>The tool must only be added if the Registry doesnt already contain it</remarks>
		void RegisterSettings(IEnumerable<ISettings> settings);

		/// <summary>
		/// Registers all  Settings provided by a factory with this Registry
		/// </summary>
		/// <param name="factory">The providing Factory to register</param>
		/// <remarks>The tool must only be added if the Registry doesnt already contain it</remarks>
		void Register(Plugin.ISettingsFactory factory);

		/// <summary>
		/// Returns the List of Known Settings
		/// </summary>
		HashSet<ISettings> Settings
		{
			get;
		}
	}
}
