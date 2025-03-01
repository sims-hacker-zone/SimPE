// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.PackedFiles.Ltxt
{
	/// <summary>
	/// Lot Flags
	/// TODO: What do the other bits mean?
	/// </summary>
	[Flags]
	public enum LotFlags : uint
	{
		HasBeach = 0x0000_0080,
		IsHidden = 0x0000_0010,
		LowClass = 0x0000_1000,
		MiddleClass = 0x0000_2000,
		HighClass = 0x0000_4000
	}
}
