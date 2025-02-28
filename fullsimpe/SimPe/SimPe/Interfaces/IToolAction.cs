// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Events;

namespace SimPe.Interfaces
{
	/// <summary>
	/// defines a Action Plugin
	/// </summary>
	public interface IToolAction : IToolPlugin, IToolExt
	{
		/// <summary>
		/// This Eventhandler will be connected to the ExecuteAction Event of the Caller, you should
		/// perform the Action here. You can notify the caller of Changes when setting the apropriate
		/// Attributes in e
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ExecuteEventHandler(object sender, ResourceEventArgs e);

		/// <summary>
		/// This EventHandler will be connected to the ChangeResource Event of the Caller, you can set
		/// the Enabled State here
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e);
	}
}
