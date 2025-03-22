// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Objd
{
	[Flags]
	public enum ObjdFunctionSortFlags : ushort
	{
		Comfort = 0x0001,
		Surfaces = 0x0002,
		Appliances = 0x0004,
		Electronics = 0x0008,
		Plumbing = 0x0010,
		Decorative = 0x0020,
		Miscellaneous = 0x0040,
		Lighting = 0x0080,
		Hobbies = 0x0100,
		[DisplayName("Career Rewards")]
		CareerRewards = 0x0200,
		[DisplayName("Aspiration Rewards")]
		AspirationRewards = 0x0400,
	}
}
