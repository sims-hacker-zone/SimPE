// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Packages
{
	/// <summary>
	/// State of a FileStream
	/// </summary>
	public enum StreamState : byte
	{
		/// <summary>
		/// The Stream is Opene
		/// </summary>
		Opened,

		/// <summary>
		/// The Stream is Closed
		/// </summary>
		Closed,

		/// <summary>
		/// The stream is not available
		/// </summary>
		Removed,
	}
}
