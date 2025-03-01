// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Available Neighbourhood Types
	/// </summary>
	public enum NeighborhoodType : uint
	{
		Unknown = 0x00,
		Normal = 0x01,
		University = 0x02,
		Downtown = 0x03,
		Suburb = 0x04,
		Village = 0x05,
		Lakes = 0x06,
		Island = 0x07,
		Custom = 0x08,
	}
}
