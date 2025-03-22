// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Objd
{
	[Flags]
	public enum ObjdBuildModeSort : uint
	{
		None = 0x0000_0000,
		[DisplayName("Miscellaneous / Columns")]
		Miscellaneous_Columns = 0x0001_0008,
		Staircases = 0x0001_0020,
		[DisplayName("Miscellaneous / Swimming Pools")]
		Miscellaneous_SwimmingPools = 0x0001_0040,
		[DisplayName("Miscellaneous / Multi-story Columns")]
		Miscellaneous_MultiStoryColumns = 0x0001_0100,
		[DisplayName("Miscellaneous / Connecting Column Arches")]
		Miscellaneous_ConnectingColumnArches = 0x0001_0200,
		Garage = 0x0001_0400,
		[DisplayName("Miscellaneous / Elevators")]
		Miscellaneous_Elevators = 0x0001_0800,
		Architecture = 0x0001_1000,
		[DisplayName("Garden Center / Trees")]
		Garden_Trees = 0x0004_0001,
		[DisplayName("Garden Center / Shrubs")]
		Garden_Shrubs = 0x0004_0002,
		[DisplayName("Garden Center / Flowers")]
		Garden_Flowers = 0x0004_0004,
		[DisplayName("Garden Center / Gardening")]
		Garden_Gardening = 0x0004_0010,
		[DisplayName("Doors & Windows / Doors")]
		DoorsWindows_Doors = 0x80001,

		[DisplayName("Doors & Windows / Multi-story Windows")]
		DoorsWindows_MultistoryWindows = 0x0008_0002,
		[DisplayName("Doors & Windows / Single Story Windows")]
		DoorsWindows_SingleStoryWindows = 0x0008_0004,
		[DisplayName("Miscellaneous / Gates")]
		Miscellaneous_Gates = 0x0008_0008,
		[DisplayName("Doors & Windows / Archways")]
		DoorsWindows_Archways = 0x0008_0010,
		[DisplayName("Doors & Windows / Multi-story Doors and Arches")]
		DoorsWindows_MultistoryDoorsArches = 0x0008_0100,
	}
}
