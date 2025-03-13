// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.Interfaces
{
	/// <summary>
	/// Summary description for IToolRegistry.
	/// </summary>
	public interface IToolRegistry
	{
		/// <summary>
		/// Registers a Tool to the Registry
		/// </summary>
		/// <param name="tool">The Tool to register</param>
		/// <remarks>The tool must only be added if the Registry doesnt already contain it</remarks>
		void Register(IToolPlugin tool);

		/// <summary>
		/// Registers all listed Tools with this Registry
		/// </summary>
		/// <param name="tools">The Tools to register</param>
		/// <remarks>The tool must only be added if the Registry doesnt already contain it</remarks>
		void Register(IEnumerable<IToolPlugin> tools);

		/// <summary>
		/// Registers all Tools supported by the Factory
		/// </summary>
		/// <param name="factory">The Factory Elements you want to register</param>
		/// <remarks>The tool must only be added if the Registry doesnt already contain it</remarks>
		void Register(Plugin.IToolFactory factory);

		/// <summary>
		/// Return a Collection of loaded Listeners
		/// </summary>
		List<IListener> Listeners
		{
			get;
		}

		/// <summary>
		/// Returns the List of Known Tools
		/// </summary>
		/// <remarks>The Tools should be Returned in Order of Priority starting with the lowest!</remarks>
		HashSet<ITool> Tools
		{
			get;
		}

		/// <summary>
		/// Returns the List of Known Tools
		/// </summary>
		/// <remarks>The Tools should be Returned in Order of Priority starting with the lowest!</remarks>
		HashSet<IToolPlus> ToolsPlus
		{
			get;
		}

		/// <summary>
		/// Returns a List of Know Doackable Tools
		/// </summary>
		HashSet<IDockableTool> Docks
		{
			get;
		}

		/// <summary>
		/// Returns a List of Know Action Tool
		/// </summary>
		HashSet<IToolAction> Actions
		{
			get;
		}
	}
}
