// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Bnfo
{
	public enum BnfoVersion : uint
	{
		[DisplayName("Sims2EP3", LocalizedResource = true)]
		Business = 0x04,
	}
}
