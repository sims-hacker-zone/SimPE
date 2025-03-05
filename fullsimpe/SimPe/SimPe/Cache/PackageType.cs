// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Cache
{
	/// <summary>
	/// Type of a Package
	/// </summary>
	public enum PackageType : uint
	{
		/// <summary>
		/// This package was never scaned
		/// </summary>
		Undefined = 0x40,

		/// <summary>
		/// The Package was scanned, but the Type is unknown
		/// </summary>
		Unknown = 0x0,

		/// <summary>
		/// The package contains a Skin
		/// </summary>
		Skin = 0x1,

		/// <summary>
		/// The package contains a Wallpaper
		/// </summary>
		Wallpaper = 0x2,

		/// <summary>
		/// The package contains a Floor
		/// </summary>
		Floor = 0x4,

		/// <summary>
		/// The package contains a Clothing
		/// </summary>
		Clothing = 0x8,

		/// <summary>
		/// The package contains a Crap Object or Clone
		/// </summary>
		CustomObject = 0x10,

		/// <summary>
		/// The package contains a Recolour
		/// </summary>
		Recolour = 0x20,

		/// <summary>
		/// An Object properly created
		/// </summary>
		Object = 0x80,

		/// <summary>
		/// A CEP Related File
		/// </summary>
		CEP = 0x100,

		/// <summary>
		/// A Sim or Sim Template
		/// </summary>
		Sim = 0x200,

		/// <summary>
		/// Hairtones
		/// </summary>
		Hair = 0x1000,

		/// <summary>
		/// Makeup for Sims
		/// </summary>
		Makeup = 0x400,
		Accessory = 0x800,
		Eye = 0x401,
		Beard = 0x402,
		EyeBrow = 0x403,
		Lipstick = 0x404,
		Mask = 0x405,
		Blush = 0x406,
		EyeShadow = 0x407,
		Glasses = 0x801,

		/// <summary>
		/// Contains a Neighborhood
		/// </summary>
		Neighbourhood = 0x2000,

		/// <summary>
		/// Contains a Lot
		/// </summary>
		Lot = 0x4000,

		/// <summary>
		/// Describes a Fence
		/// </summary>
		Fence = 0x8000,

		/// <summary>
		/// Describes a Roof
		/// </summary>
		Roof = 0x10000,

		/// <summary>
		/// Describes TerrainPaint
		/// </summary>
		Terrain = 0x20000,

		/// <summary>
		/// Describes the Game Wide Inventory
		/// </summary>
		GameInventory = 0x40000,
	}
}
