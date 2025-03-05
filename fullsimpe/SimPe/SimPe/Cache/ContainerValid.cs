// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Cache
{
	/// <summary>
	/// Detailed Information about the Valid State of the Container
	/// </summary>
	public enum ContainerValid : byte
	{
		Yes = 0x04,
		FileNotFound = 0x01,
		Modified = 0x02,
		UnknownVersion = 0x03,
	}
}
