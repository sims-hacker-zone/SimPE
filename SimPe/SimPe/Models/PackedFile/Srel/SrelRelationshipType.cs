// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Models.PackedFile.Srel
{
	public enum SrelRelationshipType : ushort
	{
		Positive = 0,
		Negative = 0xFFFF
	}
}
