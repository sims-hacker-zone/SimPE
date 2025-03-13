// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces
{
	/// <summary>
	/// defines a Listener
	/// </summary>
	public interface IListener : IToolPlugin
	{
		/// <summary>
		/// This EventHandler will be connected to the ChangeResource Event of the Caller, you can set
		/// the Enabled State here
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns>
		/// Should allways return true for listeners.
		/// Tools displayed in a Menu or ActionList, should only return true, when they are
		/// enabled for the passed Selection and package
		/// </returns>
		void SelectionChangedHandler(object sender, Events.ResourceEventArgs e);
	}
}
