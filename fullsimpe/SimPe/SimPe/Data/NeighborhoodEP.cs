// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Extensions;

namespace SimPe.Data
{
	/// <summary>
	/// Available EPs
	/// </summary>
	public enum NeighborhoodEP : uint
	{
		[DisplayName("Sims 2 Base Game")]
		BaseGame = 0x00,
		[DisplayName("Sims 2 University")]
		University = 0x01,
		[DisplayName("Sims 2 Nightlife")]
		Nightlife = 0x02,
		[DisplayName("Sims 2 Open for Business")]
		Business = 0x03,
		[DisplayName("Sims 2 Family Fun Stuff")]
		FamilyFun = 0x04,
		[DisplayName("Sims 2 Glamour Life Stuff")]
		GlamourLife = 0x05,
		[DisplayName("Sims 2 Pets")]
		Pets = 0x06,
		[DisplayName("Sims 2 Seasons")]
		Seasons = 0x07,
		[DisplayName("Sims 2 Celebration! Stuff")]
		Celebration = 0x08,
		[DisplayName("Sims 2 H&M Fashion Stuff")]
		Fashion = 0x09,
		[DisplayName("Sims 2 Bon Voyage")]
		BonVoyage = 0x0a,
		[DisplayName("Sims 2 Teen Style Stuff")]
		TeenStyle = 0x0b,
		[DisplayName("Sims 2 Store Edition (old)")]
		StoreEdition_old = 0x0c,
		[DisplayName("Sims 2 FreeTime")]
		Freetime = 0x0d,
		[DisplayName("Sims 2 Kitchen & Bath Interior Design Stuff")]
		KitchenBath = 0x0e,
		[DisplayName("Sims 2 IKEA Home Stuff")]
		IkeaHome = 0x0f,
		[DisplayName("Sims 2 Apartment Life")]
		ApartmentLife = 0x10,
		[DisplayName("Sims 2 Mansion & Garden Stuff")]
		MansionGarden = 0x11,
		[DisplayName("Sims 2 Store Edition")]
		StoreEdition = 0x1f,
	}
}
