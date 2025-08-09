// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Swaf;

public enum SwafItemType : uint
{
	[DisplayName("Lifetime Want")] LifetimeWant,

	[DisplayName("Want")] Want,
	Fear,
	[DisplayName("Want History")] History
}
