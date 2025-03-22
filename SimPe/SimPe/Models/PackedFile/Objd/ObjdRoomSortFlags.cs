// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Objd
{
	[Flags]
	public enum ObjdRoomSortFlags : ushort
	{
		Kitchen = 0x0001,
		Bedroom = 0x0002,
		Bathroom = 0x0004,
		[DisplayName("Living Room")]
		LivingRoom = 0x0008,
		Outside = 0x0010,
		[DisplayName("Dining Room")]
		DiningRoom = 0x0020,
		Misc = 0x0040,
		Study = 0x0080,
		Kids = 0x0100,
	}
}
