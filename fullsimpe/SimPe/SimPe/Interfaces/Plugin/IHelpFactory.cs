// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// If a class inyour .dll implements this Interface, your Plugins can add a Menu into the Help Topics.
	/// </summary>
	public interface IHelpFactory
	{
		/// <summary>
		/// Returns all Plugin (dockable) Tools the Factory knows
		/// </summary>
		IHelp[] KnownHelpTopics
		{
			get;
		}
	}
}
