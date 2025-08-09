// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Bnfo;

public enum BnfoVersion : uint
{
	[DisplayName("Sims2EP3", LocalizedResource = true)]
	Business = 0x04,
}
