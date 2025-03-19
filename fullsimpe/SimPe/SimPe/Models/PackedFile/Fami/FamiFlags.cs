// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Models.PackedFile.Fami
{
	[Flags]
	public enum FamiFlags : uint
	{
		HasPhone = 0x01,
		HasBaby = 0x02,
		NewLot = 0x04,
		HasComputer = 0x08
	}
}
