// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;

namespace SimPe.Sims2.Data;

public enum GameTypes : byte
{
	[DisplayName("Sims2", LocalizedResource = true)]
	Sims2 = 0x01,
	[DisplayName("SimsLS", LocalizedResource = true)]
	SimsLS = 0x02,
	[DisplayName("SimsPS", LocalizedResource = true)]
	SimsPS = 0x03,
	[DisplayName("SimsCS", LocalizedResource = true)]
	SimsCS = 0x04,
}
