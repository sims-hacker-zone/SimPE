// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Enumerates known Object Types
	/// </summary>
	public enum ObjectTypes : ushort
	{
		Unknown = 0x0000,
		Person = 0x0002,
		Normal = 0x0004,
		ArchitecturalSupport = 0x0005,
		SimType = 0x0007,
		Door = 0x0008,
		Window = 0x0009,
		Stairs = 0x000A,
		ModularStairs = 0x000B,
		ModularStairsPortal = 0x000C,
		Vehicle = 0x000D,
		Outfit = 0x000E,
		Memory = 0x000F,
		Template = 0x0010,
		UnlinkedSim = 0x0011,
		Tiles = 0x0013,
	}
}
