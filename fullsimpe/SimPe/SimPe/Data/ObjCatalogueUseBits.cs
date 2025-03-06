// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Catalogue Use Flag
	/// </summary>
	public enum ObjCatalogueUseBits : byte
	{
		Adults = 0x00,
		Children = 0x01,
		Group = 0x02,
		Teens = 0x03,
		Elders = 0x04,
		Toddlers = 0x05,
	}
}
