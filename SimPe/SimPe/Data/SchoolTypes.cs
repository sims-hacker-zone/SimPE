// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Data
{
	/// <summary>
	/// Type of school a Sim attends
	/// </summary>

	public enum SchoolTypes : uint
	{
		Unknown = 0xFFFFFFFF,
		NoSchool = 0x00000000,
		PublicSchool = 0xD06788B5,
		PrivateSchool = 0xCC8F4C11,
	}
}