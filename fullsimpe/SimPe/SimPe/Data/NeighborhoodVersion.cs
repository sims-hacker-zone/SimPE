// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Extensions;

namespace SimPe.Data
{
	/// <summary>
	/// Known Neighborhood Versions
	/// </summary>
	public enum NeighborhoodVersion : uint
	{
		[DisplayName("Unknown")]
		Unknown = 0x00,
		[DisplayName("Sims 2")]
		Sims2 = 0x03,
		[DisplayName("Sims 2 University")]
		Sims2_University = 0x05,
		[DisplayName("Sims 2 Nightlife")]
		Sims2_Nightlife = 0x07,
		[DisplayName("Sims 2 Open for Business")]
		Sims2_Business = 0x08,
		[DisplayName("Sims 2 Pets")]
		Sims2_Pets = 0x09,
		[DisplayName("Sims 2 Seasons")]
		Sims2_Seasons = 0x0A,
	}
}
