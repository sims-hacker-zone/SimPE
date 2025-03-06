// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.Data
{
	/// <summary>
	/// Categories used for the clothing scanner, the naming above appears and is bloody awfull
	/// </summary>
	[Flags]
	public enum OutfitCats : uint
	{
		Everyday = 0x07,
		Swimsuit = 0x08, // Swimmwear
		Pyjamas = 0x10,
		Formal = 0x20,
		Underwear = 0x40, //Undies
		Skin = 0x80,
		Maternity = 0x100, //Pregnant
		Gym = 0x200, //Activewear
		TryOn = 0x400,
		NakedOverlay = 0x800,
		WinterWear = 0x1000, // Outerwear
	}
}
