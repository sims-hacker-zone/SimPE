// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Cache
{
	/// <summary>
	/// What type have the items stored in the container
	/// </summary>
	public enum ContainerType : byte
	{
		None = 0x00,
		Object = 0x01,
		MaterialOverride = 0x02,
		Want = 0x03,
		Memory = 0x04,
		Package = 0x05,
		Rcol = 0x06,
		Goal = 0x07,
	};
}
