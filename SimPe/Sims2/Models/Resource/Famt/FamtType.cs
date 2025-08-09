// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Famt;

public enum FamtType : uint
{
	[DisplayName("My mother is")] Mother = 0x00,
	[DisplayName("My father is")] Father = 0x01,
	[DisplayName("Married to")] Spouse = 0x02,
	[DisplayName("My sibling is")] Sibling = 0x03,
	[DisplayName("My child is")] Child = 0x04,
}
