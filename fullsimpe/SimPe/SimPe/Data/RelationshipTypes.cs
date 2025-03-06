// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Data
{
	/// <summary>
	/// Detailed Relationships between Sims
	/// </summary>
	public enum RelationshipTypes : uint
	{
		Unset_Unknown = 0x00,
		Parent = 0x01,
		Child = 0x02,
		Sibling = 0x03,
		Gradparent = 0x04,
		Grandchild = 0x05,
		Nice_Nephew = 0x07,
		Aunt = 0x06,
		Cousin = 0x08,
		Spouses = 0x09,
	}
}