// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Function for xml Based Objects
	/// </summary>
	public enum XObjFunctionSubSort : uint
	{
		Roof = 0x0100,

		Floor_Brick = 0x0201,
		Floor_Carpet = 0x0202,
		Floor_Lino = 0x0204,
		Floor_Poured = 0x0208,
		Floor_Stone = 0x0210,
		Floor_Tile = 0x0220,
		Floor_Wood = 0x0240,
		Floor_Other = 0x0200,

		Fence_Rail = 0x0400,
		Fence_Halfwall = 0x0401,

		Wall_Brick = 0x0501,
		Wall_Masonry = 0x0502,
		Wall_Paint = 0x0504,
		Wall_Paneling = 0x0508,
		Wall_Poured = 0x0510,
		Wall_Siding = 0x0520,
		Wall_Tile = 0x0540,
		Wall_Wallpaper = 0x0580,
		Wall_Other = 0x0500,

		Terrain = 0x0600,

		Hood_Landmark = 0x0701,
		Hood_Flora = 0x0702,
		Hood_Effects = 0x0703,
		Hood_Misc = 0x0704,
		Hood_Stone = 0x0705,
		Hood_Other = 0x0700,
	}
}
