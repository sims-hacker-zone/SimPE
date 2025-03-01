// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.Ltxt
{

	public partial class Ltxt
	{
		public enum LotType : byte
		{
			Residential = 0x00,
			Community = 0x01,
			Dorm = 0x02,
			GreekHouse = 0x03,
			SecretSociety = 0x04,
			Hotel = 0x05,
			SecretHoliday = 0x06,
			Hobby = 0x07,
			ApartmentBase = 0x08,
			ApartmentSublot = 0x09,
			Witches = 0x0a,
			Unknown = 0xff,
		}
	}
}
