// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Objd
{
	public enum ObjdType : ushort
	{
		Unknown = 0x0000,
		Person = 0x0002,
		Normal = 0x0004,
		[DisplayName("Architectural Support")]
		ArchitecturalSupport = 0x0005,
		[DisplayName("Sim Type")]
		SimType = 0x0007,
		Door = 0x0008,
		Window = 0x0009,
		Stairs = 0x000A,
		[DisplayName("Modular Stairs")]
		ModularStairs = 0x000B,
		[DisplayName("Modular Stairs Portal")]
		ModularStairsPortal = 0x000C,
		Vehicle = 0x000D,
		Outfit = 0x000E,
		Memory = 0x000F,
		Template = 0x0010,
		[DisplayName("Unlinked Sim")]
		UnlinkedSim = 0x0011,
		Tiles = 0x0013,
	}
}
