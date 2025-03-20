// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Data
{
	/// <summary>
	/// Categories used for Property Sets (Skins) (Updated by Theo)
	/// </summary>
	[Flags]
	public enum SkinCategories : uint
	{
		Casual1 = 0x01,
		Casual2 = 0x02,
		Casual3 = 0x04,
		Everyday = Casual1 | Casual2 | Casual3,
		Swimmwear = 0x08,
		PJ = 0x10,
		Formal = 0x20,
		Undies = 0x40,
		Skin = 0x80,
		Pregnant = 0x100,
		Activewear = 0x200,
		TryOn = 0x400,
		NakedOverlay = 0x800,
		Outerwear = 0x1000,
		Hair = 0x2000, // does not exist so won't be used but gives me somewhere to shove hair out of the way when browsing for clothes
	}
}
