// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe.Interfaces
{
	/// <summary>
	/// Implement this interface to get called with the SimPe command line
	/// </summary>
	public interface ICommandLine
	{
		/// <summary>
		/// Parse() should check the first argument to see if it's recognised.
		/// If not, simply return false.  Else process the remaining arguments until satisfied.
		/// All arguments consumed should be removed.
		/// </summary>
		/// <param name="args"></param>
		/// <returns>False if SimPe should start; True if SimPe should exit</returns>
		bool Parse(List<string> argv);

		/// <summary>
		/// Called to determine what the "-help" option will display.
		/// The option name should be language-invariant.
		/// The help text can be language-specific.
		/// </summary>
		/// <returns>The command line option name (in string[0]) and help text (in string[1]).</returns>
		string[] Help();
	}
}
