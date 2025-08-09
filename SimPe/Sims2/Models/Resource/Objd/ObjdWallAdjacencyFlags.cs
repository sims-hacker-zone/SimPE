using System;

namespace SimPe.Sims2.Models.Resource.Objd;

[Flags]
public enum ObjdWallAdjacencyFlags : ushort
{
	WallOnLeft = 0x0001,
	WallOnRight = 0x0002,
	WallInFront = 0x0004,
	WallBehind = 0x0008,
	WallAboveLeft = 0x0010,
	WallAboveRight = 0x0020
}
