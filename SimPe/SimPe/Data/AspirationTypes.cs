// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Data
{
	/// <summary>
	/// Which general apiration does a Sim have
	/// </summary>
	public enum AspirationTypes : ushort
	{
		Nothing = 0x00,
		Romance = 0x01,
		Family = 0x02,
		Fortune = 0x04,

		// Power = 0x08,
		Reputation = 0x10,
		Knowledge = 0x20,
		Growup = 0x40,
		Pleasure = 0x80,
		Chees = 0x100,
	}
}