// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// </summary>
	/// <remarks>
	/// </remarks>
	public interface ICommandLineFactory
	{
		/// <summary>
		/// </summary>
		ICommandLine[] KnownCommandLines
		{
			get;
		}
	}
}
