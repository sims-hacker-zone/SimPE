// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe
{
	/// <summary>
	/// Used to send Data along with a call to <see cref="Interfaces.IHelp.ShowHelp"/>
	/// </summary>
	public class ShowHelpEventArgs : System.EventArgs
	{
		public ShowHelpEventArgs()
			: base() { }
	}
}
