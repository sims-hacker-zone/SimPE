// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Cache
{
	public enum ObjectCacheItemVersions : byte
	{
		Outdated = 0x00,
		ClassicOW = 0x03,
		DockableOW = 0x05,
		Unsupported = 0xff,
	}
}
