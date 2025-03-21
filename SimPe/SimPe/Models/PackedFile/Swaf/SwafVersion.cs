// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Swaf
{
	public enum SwafVersion : uint
	{
		[DisplayName("Sims2", LocalizedResource = true)]
		Version1 = 1,

		[DisplayName("Sims2EP1", LocalizedResource = true)]
		Version5 = 5,

		[DisplayName("Version 6")]
		Version6 = 6,
		[DisplayName("Version 7")]
		Version7 = 7
	}

	public enum SwafItemVersion : uint
	{
		[DisplayName("Version 4")]
		Version4 = 4,
		[DisplayName("Version 7")]
		Version7 = 7,
		[DisplayName("Version 8")]
		Version8,
		[DisplayName("Version 9")]
		Version9,
		[DisplayName("Version 10")]
		Version10
	}
}
