// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Data
{
	/// <summary>
	/// outfit type used for Property Sets (Skins)
	/// </summary>
	[Flags]
	public enum SkinParts : uint
	{
		Hair = 0x01,
		Face = 0x02,
		Top = 0x04,
		Body = 0x08,
		Bottom = 0x10,
		Jewellery = 0x20,
		LongTail = 0x40,
		Ear_Up = 0x80,
		ShortTail = 0x100,
		Ear_Flop = 0x200,
		LongBrushTail = 0x400,
		ShortBrushTail = 0x800,
		SpitzTail = 0x1000,
		LongFlowingTail = 0x2000,
	}
}
