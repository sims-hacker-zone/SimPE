// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;

namespace SimPe.Sims2.Data;

public enum GameTypes : byte
{
	[DisplayName("Sims2", LocalizedResource = true)]
	Sims2 = 1,

	[DisplayName("SimsLS", LocalizedResource = true)]
	SimsLS,

	[DisplayName("SimsPS", LocalizedResource = true)]
	SimsPS,

	[DisplayName("SimsCS", LocalizedResource = true)]
	SimsCS,
}
