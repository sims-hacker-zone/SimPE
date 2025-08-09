// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Srel;

public enum SrelFamilyRelations : uint
{
	Parent = 1,
	Child,
	Sibling,
	Grandparent,
	Grandchild,
	[DisplayName("Uncle/Aunt")] UncleAunt,
	[DisplayName("Niece/Nephew")] NieceNephew,
	Cousin,
	Spouse
}
