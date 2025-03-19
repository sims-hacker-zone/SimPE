// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Fami
{
	public enum FamiVersion : int
	{
		[DisplayName("Sims 2")]
		BaseGame = 78,
		[DisplayName("Sims 2 University")]
		University = 79,
		[DisplayName("Sims 2 Open for Business")]
		Business = 81,
		[DisplayName("Sims 2 Pets")]
		Pets = 84,
		[DisplayName("Sims 2 Bon Voyage")]
		Voyage = 85,
		[DisplayName("Sims Castaway Stories")]
		CastawayStories = 86,
	}
}
