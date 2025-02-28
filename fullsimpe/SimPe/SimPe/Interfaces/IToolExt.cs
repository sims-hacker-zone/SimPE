// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces
{
	/// <summary>
	/// Defines extended properties for the <see cref="ITool"/> Interface.
	/// </summary>
	public interface IToolExt : IToolPlugin
	{
		/// <summary>
		/// Returns null or the Icon that should be dispalyed for this Menu Item (can be null)
		/// </summary>
		/// <returns></returns>
		System.Drawing.Image Icon
		{
			get;
		}

		/// <summary>
		/// Returns the wanted Shortcut
		/// </summary>
		System.Windows.Forms.Shortcut Shortcut
		{
			get;
		}

		/// <summary>
		/// Returns true if the Tool is curently visible on the GUI
		/// </summary>
		bool Visible
		{
			get;
		}
	}
}
