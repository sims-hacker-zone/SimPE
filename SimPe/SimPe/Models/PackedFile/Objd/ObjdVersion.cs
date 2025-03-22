// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Objd
{
	public enum ObjdVersion : uint
	{
		[DisplayName("Sims2", LocalizedResource = true)]
		BaseGame = 0x8B,
		[DisplayName("Sims2EP1", LocalizedResource = true)]
		University = 0x8C,
		[DisplayName("Sims2EP7", LocalizedResource = true)]
		Freetime = 0x8D,
	}
}
