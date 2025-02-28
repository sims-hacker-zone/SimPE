// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces.Plugin
{
	/// <summary>
	/// If a class inyour .dll implements this Interface, your Plugins can add a Menu into the Help Topics.
	/// </summary>
	public interface ISettingsFactory
	{
		/// <summary>
		/// Returns all Settings the Facory knows about
		/// </summary>
		ISettings[] KnownSettings
		{
			get;
		}
	}
}
