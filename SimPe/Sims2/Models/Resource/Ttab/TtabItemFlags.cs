// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Sims2.Models.Resource.Ttab;

[Flags]
public enum TtabItemFlags : ushort
{
	Visitor = 0x0001,
	Joinable = 0x0002,
	Immediately = 0x0004,
	Consectuive = 0x0008,
	NoChildren = 0x0010,
	NoDemoChild = 0x0020,
	NoAdults = 0x0040,
	DebugMenu = 0x0080,
	AutoFirst = 0x0100,
	Toddlers = 0x0200,
	Elders = 0x0400,
	Teens = 0x0800,
	Dogs = 0x1000,
	Cats = 0x2000,
	AllowNested = 0x4000,
	Nest = 0x8000,

	// After Version 0x54, some flags have new meanings
	ChildrenV54 = 0x0010,
	TwoWayV54 = 0x0020,
	AdultsV54 = 0x0040,
	AdultBigDogsV54 = 0x1000,
	AdultCatsV54 = 0x2000
}
