// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace SimPe.Sims1.Data;

public enum ResourceTypes : uint
{
	Unknown = 0,
	RSMP = 0x72736D70,
	OBJD = 0x4f424a44,
	OBJF = 0X4F424A66,
	CTSS = 0X43545353,
	STR = 0X53545223,
	TTAB = 0X54544142,
	TTAS = 0X54544173,
	BHAV = 0X42484156,
	BMP_ = 0X424D505F,
	GLOB = 0X474C4F42,
	SLOT = 0X534C4F54,
	FWAV = 0X46574156,
	BCON = 0X42434F4E,
	SPR2 = 0X53505232,
	PALT = 0X50414C54,
	SIMI = 0x53494D49,
	HOUS = 0x484F5553,
	FLRm = 0X464C526D,
	WALm = 0X57414C6D,
	Arry = 0x41727279,
	objt = 0X6F626A74,
	ObjM = 0X4F626A4D,
	THMB = 0x54484d42,
	Optn = 0x4F70746E,
	XXXX = 0x58585858,
}
