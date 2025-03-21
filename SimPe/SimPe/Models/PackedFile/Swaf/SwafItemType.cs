// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Swaf
{
	public enum SwafItemType : uint
	{
		[DisplayName("Lifetime Want")]
		LifetimeWant,

		[DisplayName("Want")]
		Want,
		Fear,
		[DisplayName("Want History")]
		History
	}
}
