// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.Interfaces
{
	/// <summary>
	/// Summary description for ICommandLineRegistry.
	/// </summary>
	public interface ICommandLineRegistry
	{
		/// <summary>
		/// Registers a CommandLine to the Registry
		/// </summary>
		/// <param name="CommandLine">The CommandLine to register</param>
		/// <remarks>The CommandLine must only be added if the Registry doesnt already contain it</remarks>
		void RegisterCommandLines(ICommandLine CommandLine);

		/// <summary>
		/// Registers all listed CommandLines with this Registry
		/// </summary>
		/// <param name="CommandLines">The CommandLines to register</param>
		/// <remarks>The CommandLine must only be added if the Registry doesnt already contain it</remarks>
		void RegisterCommandLines(IEnumerable<ICommandLine> commandlines);

		/// <summary>
		/// Registers all CommandLines supported by the Factory
		/// </summary>
		/// <param name="factory">The Factory Elements you want to register</param>
		/// <remarks>The CommandLine must only be added if the Registry doesnt already contain it</remarks>
		void Register(Plugin.ICommandLineFactory factory);

		/// <summary>
		/// Returns the List of Known CommandLines
		/// </summary>
		/// <remarks>The CommandLines should be Returned in Order of Priority starting with the lowest!</remarks>
		HashSet<ICommandLine> CommandLines
		{
			get;
		}
	}
}
