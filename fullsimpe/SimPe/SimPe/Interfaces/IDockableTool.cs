// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using Ambertation.Windows.Forms;

using SimPe.Events;

namespace SimPe.Interfaces
{
	/// <summary>
	/// defines an Object that can be put into Dock of the Main Form
	/// </summary>
	public interface IDockableTool : IToolPlugin, IToolExt
	{
		/// <summary>
		/// Fired, when a new Resource should be displayed
		/// </summary>
		event ChangedResourceEvent ShowNewResource;

		/// <summary>
		/// Starts the Tool Window
		/// </summary>
		/// <param name="package">The currently opened Package</param>
		/// <param name="pfd">The currently selected File</param>
		/// <returns>true, if the package was changed</returns>
		DockPanel GetDockableControl();

		/// <summary>
		/// This EventHandler will be connected to the ChangeResource Event of the Caller, you can set
		/// the Enabled State here
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void RefreshDock(object sender, ResourceEventArgs e);
	}
}
