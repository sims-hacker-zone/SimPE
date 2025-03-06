// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Room Sort Flag
	/// </summary>
	public enum ObjRoomSortBits : byte
	{
		Kitchen = 0x00,
		Bedroom = 0x01,
		Bathroom = 0x02,
		LivingRoom = 0x03,
		Outside = 0x04,
		DiningRoom = 0x05,
		Misc = 0x06,
		Study = 0x07,
		Kids = 0x08,
	}
}
