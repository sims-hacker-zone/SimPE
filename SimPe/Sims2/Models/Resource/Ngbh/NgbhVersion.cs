// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Ngbh;

public enum NgbhVersion : uint
{
	[DisplayName("Sims2", LocalizedResource = true)]
	BaseGame = 0x6F,

	[DisplayName("Sims2EP1", LocalizedResource = true)]
	University = 0x70,

	[DisplayName("Sims2EP2", LocalizedResource = true)]
	Nightlife = 0xBE,

	[DisplayName("Sims2EP3", LocalizedResource = true)]
	Business = 0xC2,

	[DisplayName("Sims2EP5", LocalizedResource = true)]
	Seasons = 0xCB,

	[DisplayName("SimsCS", LocalizedResource = true)]
	Castaway = 0xCE,
}
