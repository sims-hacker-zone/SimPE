// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Models.PackedFile.Swaf
{
	/// <summary>
	/// Possible want types
	/// </summary>
	public enum WantType : byte
	{
		None = 0,
		Sim = 1,
		Object = 2,
		Category = 3,
		Skill = 4,
		Career = 5,
		Badge
	}
}
