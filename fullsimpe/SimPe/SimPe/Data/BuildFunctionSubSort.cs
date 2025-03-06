// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Build Function Sort Flag
	/// </summary>
	/// <remarks>the higher 2 bytes contains the <see cref="ObjFunctionSortBits"/>, the lower one the actual SubSort</remarks>
	public enum BuildFunctionSubSort : uint
	{
		none = 0x00000,
		General_Columns = 0x10008,
		General_Stairs = 0x10020,
		General_Pool = 0x10040,
		General_TallColumns = 0x10100,
		General_Arch = 0x10200,
		General_Driveway = 0x10400,
		General_Elevator = 0x10800,
		General_Architectural = 0x11000,

		Garden_Trees = 0x40001,
		Garden_Shrubs = 0x40002,
		Garden_Flowers = 0x40004,
		Garden_Objects = 0x40010,

		Openings_Door = 0x80001,
		Openings_TallWindow = 0x80002,
		Openings_Window = 0x80004,
		Openings_Gate = 0x80008,
		Openings_Arch = 0x80010,
		Openings_TallDoor = 0x80100,

		unknown = 0x00069, // just to locate unknown things, is read but not written
	}
}
