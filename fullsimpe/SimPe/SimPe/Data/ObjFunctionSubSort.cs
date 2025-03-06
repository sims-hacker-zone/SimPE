// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Function Sort Flag
	/// </summary>
	/// <remarks>the higher byte contains the <see cref="ObjFunctionSortBits"/>, the lower one the actual SubSort</remarks>
	public enum ObjFunctionSubSort : uint
	{
		none = 0x0000,
		Seating_DiningroomChair = 0x101,
		Seating_LivingroomChair = 0x102,
		Seating_Sofas = 0x104,
		Seating_Beds = 0x108,
		Seating_Recreation = 0x110,
		Seating_UnknownA = 0x120,
		Seating_UnknownB = 0x140,
		Seating_Misc = 0x180,

		Surfaces_Counter = 0x201,
		Surfaces_Table = 0x202,
		Surfaces_EndTable = 0x204,
		Surfaces_Desks = 0x208,
		Surfaces_Coffeetable = 0x210,
		Surfaces_Business = 0x220,
		Surfaces_UnknownB = 0x240,
		Surfaces_Misc = 0x280,

		Decorative_Wall = 0x2001,
		Decorative_Sculpture = 0x2002,
		Decorative_Rugs = 0x2004,
		Decorative_Plants = 0x2008,
		Decorative_Mirror = 0x2010,
		Decorative_Curtain = 0x2020,
		Decorative_UnknownB = 0x2040,
		Decorative_Misc = 0x2080,

		Plumbing_Toilet = 0x1001,
		Plumbing_Shower = 0x1002,
		Plumbing_Sink = 0x1004,
		Plumbing_HotTub = 0x1008,
		Plumbing_UnknownA = 0x1010,
		Plumbing_UnknownB = 0x1020,
		Plumbing_UnknownC = 0x1040,
		Plumbing_Misc = 0x1080,

		Appliances_Cooking = 0x401,
		Appliances_Refrigerator = 0x402,
		Appliances_Small = 0x404,
		Appliances_Large = 0x408,
		Appliances_UnknownA = 0x410,
		Appliances_UnknownB = 0x420,
		Appliances_UnknownC = 0x440,
		Appliances_Misc = 0x480,

		Electronics_Entertainment = 0x801,
		Electronics_TV_and_Computer = 0x802,
		Electronics_Audio = 0x804,
		Electronics_Small = 0x808,
		Electronics_UnknownA = 0x810,
		Electronics_UnknownB = 0x820,
		Electronics_UnknownC = 0x840,
		Electronics_Misc = 0x880,

		Lighting_TableLamp = 0x8001,
		Lighting_FloorLamp = 0x8002,
		Lighting_WallLamp = 0x8004,
		Lighting_CeilingLamp = 0x8008,
		Lighting_Outdoor = 0x8010,
		Lighting_UnknownA = 0x8020,
		Lighting_UnknownB = 0x8040,
		Lighting_Misc = 0x8080,

		Hobbies_Creative = 0x10001,
		Hobbies_Knowledge = 0x10002,
		Hobbies_Excerising = 0x10004,
		Hobbies_Recreation = 0x10008,
		Hobbies_UnknownA = 0x10010,
		Hobbies_UnknownB = 0x10020,
		Hobbies_UnknownC = 0x10040,
		Hobbies_Misc = 0x10080,

		General_UnknownA = 0x4001,
		General_Dresser = 0x4002,
		General_UnknownB = 0x4004,
		General_Party = 0x4008,
		General_Child = 0x4010,
		General_Car = 0x4020,
		General_Pets = 0x4040,
		General_Misc = 0x4080,

		AspirationRewards_UnknownA = 0x40001,
		AspirationRewards_UnknownB = 0x40002,
		AspirationRewards_UnknownC = 0x40004,
		AspirationRewards_UnknownD = 0x40008,
		AspirationRewards_UnknownE = 0x40010,
		AspirationRewards_UnknownF = 0x40020,
		AspirationRewards_UnknownG = 0x40040,
		AspirationRewards_UnknownH = 0x40080,

		CareerRewards_UnknownA = 0x80001,
		CareerRewards_UnknownB = 0x80002,
		CareerRewards_UnknownC = 0x80004,
		CareerRewards_UnknownD = 0x80008,
		CareerRewards_UnknownE = 0x80010,
		CareerRewards_UnknownF = 0x80020,
		CareerRewards_UnknownG = 0x80040,
		CareerRewards_UnknownH = 0x80080,
	}
}
