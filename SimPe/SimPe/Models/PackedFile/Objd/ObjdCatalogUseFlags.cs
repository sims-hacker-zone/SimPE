// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Models.PackedFile.Objd
{
	[Flags]
	public enum ObjdCatalogUseFlags : ushort
	{
		AdultsOnly = 0x0001,
		ChildrenOnly = 0x0002,
		GroupActivity = 0x0004,
		TeensOnly = 0x0008,
		EldersOnly = 0x0010,
		ToddlersOnly = 0x0020
	}
}
