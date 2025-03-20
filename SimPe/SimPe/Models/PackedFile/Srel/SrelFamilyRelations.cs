// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Srel
{
	public enum SrelFamilyRelations : uint
	{
		Parent = 1,
		Child,
		Sibling,
		Grandparent,
		Grandchild,
		[DisplayName("Uncle/Aunt")]
		UncleAunt,
		[DisplayName("Niece/Nephew")]
		NieceNephew,
		Cousin,
		Spouse
	}
}
