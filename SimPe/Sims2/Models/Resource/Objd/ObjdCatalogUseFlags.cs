// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Objd;

[Flags]
public enum ObjdCatalogUseFlags : ushort
{
	[DisplayName("Adults only")] AdultsOnly = 0x0001,
	[DisplayName("Children only")] ChildrenOnly = 0x0002,
	[DisplayName("Group activity")] GroupActivity = 0x0004,
	[DisplayName("Teens only")] TeensOnly = 0x0008,
	[DisplayName("Elders only")] EldersOnly = 0x0010,
	[DisplayName("Toddlers only")] ToddlersOnly = 0x0020
}
