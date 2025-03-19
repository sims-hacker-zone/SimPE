// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Ltxt
{
	public enum LtxtMajorVersion : ushort
	{
		[DisplayName("Sims 2")]
		Original = 0x000D,
		[DisplayName("Sims 2 Open for Business")]
		Business = 0x000E,
		[DisplayName("Sims 2 Apartment Life")]
		Apartment = 0x0012,
	}
}
