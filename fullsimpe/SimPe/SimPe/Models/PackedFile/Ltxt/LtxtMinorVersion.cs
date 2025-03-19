// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Ltxt
{
	public enum LtxtMinorVersion : ushort
	{
		[DisplayName("Sims 2")]
		Original = 0x0006,
		[DisplayName("Sims 2 Bon Voyage")]
		Voyage = 0x0007,
		[DisplayName("Sims 2 FreeTime")]
		FreeTime = 0x0008,
		[DisplayName("Sims 2 Apartment Life")]
		Apartment = 0x000B,
	}
}
