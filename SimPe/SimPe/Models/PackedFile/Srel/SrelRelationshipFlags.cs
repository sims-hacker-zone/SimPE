// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Models.PackedFile.Srel
{
	[Flags]
	public enum SrelRelationshipFlags : uint
	{
		Crush = 0x01,
		Love = 0x02,
		Engaged = 0x04,
		Married = 0x08,
		Friend = 0x10,
		BestFriend = 0x20,
		GoingSteady = 0x40,
		Enemy = 0x80,
		Family = 0x4000,
		Known = 0x8000
	}
}
