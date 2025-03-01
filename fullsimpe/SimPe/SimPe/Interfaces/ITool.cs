// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Events;

namespace SimPe.Interfaces
{
	/// <summary>
	/// The Basic Interface for ToolPlugins (dockable (<see cref="IDockableTool"/>) or not (<see cref="ITool"/>))
	/// </summary>
	public interface IToolPlugin
	{
		/// <remarks>
		/// This is explicit listed in the Interface description, as you should return a String (best would be Name)
		/// that identifies the Wrapper
		/// </remarks>
		/// <summary>Returns a short describing String</summary>
		/// <returns>A Describing String for the Wrapper</returns>
		string ToString();
	}

	/// <summary>
	/// defines an Object that can be put into a Registry
	/// </summary>
	public interface ITool : IToolPlugin
	{
		/// <summary>
		/// Starts the Tool Window
		/// </summary>
		/// <param name="package">The currently opened Package</param>
		/// <param name="pfd">The currently selected File</param>
		/// <returns>true, if the package was changed</returns>
		Plugin.IToolResult ShowDialog(
			ref Files.IPackedFileDescriptor pfd,
			ref Files.IPackageFile package
		);

		/// <summary>
		/// Returns true if the Menu Item can be enabled
		/// </summary>
		/// <param name="pfd">Descriptor for the currently selected File or null if none</param>
		/// <param name="package">The opened Package or null if none</param>
		/// <returns>true if this tool is avaliable</returns>
		bool IsEnabled(
			Files.IPackedFileDescriptor pfd,
			Files.IPackageFile package
		);
	}

	/// <summary>
	/// defines a Action Plugin with the new Interface
	/// </summary>
	public interface IToolPlus : IToolExt
	{
		/// <summary>
		/// This Eventhandler will be connected to the ExecuteAction Event of the Caller, you should
		/// perform the Action here. You can notify the caller of Changes when setting the apropriate
		/// Attributes in e
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Execute(object sender, ResourceEventArgs e);

		/// <summary>
		/// This EventHandler will be connected to the ChangeResource Event of the Caller, you can set
		/// the Enabled State here
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e);
	}
}
