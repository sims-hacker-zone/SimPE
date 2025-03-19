// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Ltxt
{
	public enum LtxtMajorVersion : ushort
	{
		[DisplayName("Sims2", LocalizedResource = true)]
		Original = 0x000D,
		[DisplayName("Sims2EP3", LocalizedResource = true)]
		Business = 0x000E,
		[DisplayName("Sims2EP8", LocalizedResource = true)]
		Apartment = 0x0012,
	}
}
