// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.Data
{
	/// <summary>
	/// Is an Item within the PackedFile Index new Alias(0x20 , "or 0x24 Bytes long"),
	/// </summary>
	public enum IndexTypes : uint
	{
		ptShortFileIndex = 0x01,
		ptLongFileIndex = 0x02,
	}
}