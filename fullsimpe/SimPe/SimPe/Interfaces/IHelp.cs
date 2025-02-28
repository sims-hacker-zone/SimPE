// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Interfaces
{
	/// <summary>
	/// The  Interface for a Help Topic
	/// </summary>
	public interface IHelp
	{
		/// <remarks>
		/// This is explicit listed in the Interface description, as you should return a String (best would be Name)
		/// that identifies the Topic. This will resemble the Menuname
		/// </remarks>
		/// <summary>Returns a short describing String</summary>
		/// <returns>A Describing String for the Wrapper</returns>
		string ToString();

		/// <summary>
		/// a 16x16 Image, that is displayed as an Icon for the Help Topic (by defualt this is a questionmark)
		/// </summary>
		/// <returns>null for the derfault, or a custom Image</returns>
		System.Drawing.Image Icon
		{
			get;
		}

		/// <summary>
		/// Executed, when the User decided to show the Help
		/// </summary>
		/// <param name="e">Currently, this does not provide any data</param>
		void ShowHelp(ShowHelpEventArgs e);
	}
}
