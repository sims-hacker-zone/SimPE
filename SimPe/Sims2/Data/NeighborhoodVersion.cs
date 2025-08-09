// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;

namespace SimPe.Sims2.Data;

/// <summary>
/// Known Neighborhood Versions
/// </summary>
public enum NeighborhoodVersion : uint
{
	[DisplayName("Unknown")] Unknown = 0x00,

	[DisplayName("Sims2", LocalizedResource = true)]
	Sims2 = 0x03,

	[DisplayName("Sims2EP1", LocalizedResource = true)]
	Sims2_University = 0x05,

	[DisplayName("Sims2EP2", LocalizedResource = true)]
	Sims2_Nightlife = 0x07,

	[DisplayName("Sims2EP3", LocalizedResource = true)]
	Sims2_Business = 0x08,

	[DisplayName("Sims2EP4", LocalizedResource = true)]
	Sims2_Pets = 0x09,

	[DisplayName("Sims2EP5", LocalizedResource = true)]
	Sims2_Seasons = 0x0A,
}
