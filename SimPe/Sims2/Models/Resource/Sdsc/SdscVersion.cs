// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Sdsc;

public enum SdscVersion : ushort
{
	Unknown = 0,

	[DisplayName("Sims2", LocalizedResource = true)]
	BaseGame = 0x20,

	[DisplayName("Sims2EP1", LocalizedResource = true)]
	University = 0x22,

	[DisplayName("Sims2EP2", LocalizedResource = true)]
	Nightlife = 0x29,

	[DisplayName("Sims2EP3", LocalizedResource = true)]
	Business = 0x2a,

	[DisplayName("Sims2EP4", LocalizedResource = true)]
	Pets = 0x2c,

	[DisplayName("SimsCS", LocalizedResource = true)]
	Castaway = 0x2d,

	[DisplayName("Sims2EP6", LocalizedResource = true)]
	Voyage = 0x2e,

	[DisplayName("Sims 2 Bon Voyage Version 2")]
	VoyageB = 0x2f,

	[DisplayName("Sims2EP7", LocalizedResource = true)]
	Freetime = 0x33,

	[DisplayName("Sims2EP8", LocalizedResource = true)]
	Apartment = 0x36,
}
