// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.Interfaces
{
	/// <summary>
	/// Summary description for IToolRegistry.
	/// </summary>
	public interface IHelpRegistry
	{
		/// <summary>
		/// Registers a Help Topic to the Registry
		/// </summary>
		/// <param name="topic">The Topic to register</param>
		/// <remarks>The tool must only be added if the Registry doesnt already contain it</remarks>
		void RegisterHelpTopic(IHelp topic);

		/// <summary>
		/// Registers all listed Help Topics with this Registry
		/// </summary>
		/// <param name="topics">The Topics to register</param>
		/// <remarks>The tool must only be added if the Registry doesnt already contain it</remarks>
		void RegisterHelpTopic(IEnumerable<IHelp> topics);

		/// <summary>
		/// Registers all  Help Topics provided by a factory with this Registry
		/// </summary>
		/// <param name="factory">The providing Factory to register</param>
		/// <remarks>The tool must only be added if the Registry doesnt already contain it</remarks>
		void Register(Plugin.IHelpFactory factory);

		/// <summary>
		/// Returns the List of Known Help Topics
		/// </summary>
		HashSet<IHelp> HelpTopics
		{
			get;
		}
	}
}
