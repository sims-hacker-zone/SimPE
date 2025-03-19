// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Fami
{
	public enum FamiVersion : int
	{
		[DisplayName("Sims2", LocalizedResource = true)]
		BaseGame = 78,
		[DisplayName("Sims2EP1", LocalizedResource = true)]
		University = 79,
		[DisplayName("Sims2EP3", LocalizedResource = true)]
		Business = 81,
		[DisplayName("Sims2EP4", LocalizedResource = true)]
		Pets = 84,
		[DisplayName("Sims2EP6", LocalizedResource = true)]
		Voyage = 85,
		[DisplayName("SimsCS", LocalizedResource = true)]
		CastawayStories = 86,
	}
}
