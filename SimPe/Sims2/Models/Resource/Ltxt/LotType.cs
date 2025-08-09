// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Ltxt;

public enum LotType : byte
{
	[DisplayName("Residential Lot")] Residential,
	[DisplayName("Community Lot")] Community,
	[DisplayName("Dorm (University)")] Dorm,

	[DisplayName("Greek House (University)")]
	GreekHouse,

	[DisplayName("Secret Society Lot (University)")]
	SecretSociety,
	[DisplayName("Hotel (Bon Voyage)")] Hotel,

	[DisplayName("Hidden Vacation Lot (Bon Voyage)")]
	HiddenVacation,

	[DisplayName("Hidden Hobby Lot (FreeTime)")]
	HiddenHobby,

	[DisplayName("Apartment Base Lot (Apartment Life)")]
	ApartmentBase,

	[DisplayName("Apartment Sublot (Apartment Life)")]
	ApartmentSublot,

	[DisplayName("Hidden Witches Lot (Apartment Life)")]
	Witches,
}
