// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Common.Extensions;

namespace SimPe.Sims2.Data;

/// <summary>
/// Available EPs
/// </summary>
public enum NeighborhoodEP : uint
{
	[DisplayName("Sims2", LocalizedResource = true)]
	BaseGame = 0x00,

	[DisplayName("Sims2EP1", LocalizedResource = true)]
	University = 0x01,

	[DisplayName("Sims2EP2", LocalizedResource = true)]
	Nightlife = 0x02,

	[DisplayName("Sims2EP3", LocalizedResource = true)]
	Business = 0x03,

	[DisplayName("Sims2SP1", LocalizedResource = true)]
	FamilyFun = 0x04,

	[DisplayName("Sims2SP2", LocalizedResource = true)]
	GlamourLife = 0x05,

	[DisplayName("Sims2EP4", LocalizedResource = true)]
	Pets = 0x06,

	[DisplayName("Sims2EP5", LocalizedResource = true)]
	Seasons = 0x07,

	[DisplayName("Sims2SP3", LocalizedResource = true)]
	Celebration = 0x08,

	[DisplayName("Sims2SP4", LocalizedResource = true)]
	Fashion = 0x09,

	[DisplayName("Sims2EP6", LocalizedResource = true)]
	BonVoyage = 0x0a,

	[DisplayName("Sims2SP5", LocalizedResource = true)]
	TeenStyle = 0x0b,

	[DisplayName("Sims2StoreOld", LocalizedResource = true)]
	StoreEdition_old = 0x0c,

	[DisplayName("Sims2EP7", LocalizedResource = true)]
	Freetime = 0x0d,

	[DisplayName("Sims2SP6", LocalizedResource = true)]
	KitchenBath = 0x0e,

	[DisplayName("Sims2SP7", LocalizedResource = true)]
	IkeaHome = 0x0f,

	[DisplayName("Sims2EP8", LocalizedResource = true)]
	ApartmentLife = 0x10,

	[DisplayName("Sims2SP9", LocalizedResource = true)]
	MansionGarden = 0x11,

	[DisplayName("Sims2Store", LocalizedResource = true)]
	StoreEdition = 0x1f,
}
