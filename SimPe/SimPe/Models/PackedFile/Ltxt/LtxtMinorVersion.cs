// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Ltxt
{
	public enum LtxtMinorVersion : ushort
	{
		[DisplayName("Sims2", LocalizedResource = true)]
		Original = 0x0006,
		[DisplayName("Sims2EP6", LocalizedResource = true)]
		Voyage = 0x0007,
		[DisplayName("Sims2EP7", LocalizedResource = true)]
		FreeTime = 0x0008,
		[DisplayName("Sims2EP8", LocalizedResource = true)]
		Apartment = 0x000B,
	}
}
