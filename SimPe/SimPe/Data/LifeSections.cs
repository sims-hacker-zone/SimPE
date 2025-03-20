// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Data
{
	/// <summary>
	/// How old (in Life Sections) is the Sim
	/// </summary>
	public enum LifeSections : ushort
	{
		Unknown = 0x00,
		Baby = 0x01,
		Toddler = 0x02,
		Child = 0x03,
		Teen = 0x10,
		Adult = 0x13,
		Elder = 0x33,
		YoungAdult = 0x40,
	}
}