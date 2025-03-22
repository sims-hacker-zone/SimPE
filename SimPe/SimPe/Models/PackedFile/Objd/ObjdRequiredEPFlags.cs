// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Objd
{
	[Flags]
	public enum ObjdRequiredEPFlags : uint
	{
		[DisplayName("Sims2", LocalizedResource = true)]
		BaseGame = 0x0000_0001,
		[DisplayName("Sims2EP1", LocalizedResource = true)]
		University = 0x0000_0002,
		[DisplayName("Sims2EP2", LocalizedResource = true)]
		Nightlife = 0x0000_0004,
		[DisplayName("Sims2EP3", LocalizedResource = true)]
		Business = 0x0000_0008,
		[DisplayName("Sims2SP1", LocalizedResource = true)]
		FamilyFun = 0x0000_0010,
		[DisplayName("Sims2SP2", LocalizedResource = true)]
		GlamourLife = 0x0000_0020,
		[DisplayName("Sims2EP4", LocalizedResource = true)]
		Pets = 0x0000_0040,
		[DisplayName("Sims2EP5", LocalizedResource = true)]
		Seasons = 0x0000_0080,
		[DisplayName("Sims2SP3", LocalizedResource = true)]
		Celebration = 0x0000_0100,
		[DisplayName("Sims2SP4", LocalizedResource = true)]
		Fashion = 0x0000_0200,
		[DisplayName("Sims2EP6", LocalizedResource = true)]
		BonVoyage = 0x0000_0400,
		[DisplayName("Sims2SP5", LocalizedResource = true)]
		TeenStyle = 0x0000_0800,
		[DisplayName("Sims2StoreOld", LocalizedResource = true)]
		StoreEdition_old = 0x0000_1000,
		[DisplayName("Sims2EP7", LocalizedResource = true)]
		Freetime = 0x0000_2000,
		[DisplayName("Sims2SP6", LocalizedResource = true)]
		KitchenBath = 0x0000_4000,
		[DisplayName("Sims2SP7", LocalizedResource = true)]
		IkeaHome = 0x0000_8000,
		[DisplayName("Sims2EP8", LocalizedResource = true)]
		ApartmentLife = 0x0001_0000,
		[DisplayName("Sims2SP9", LocalizedResource = true)]
		MansionGarden = 0x0002_0000,
	}
}
