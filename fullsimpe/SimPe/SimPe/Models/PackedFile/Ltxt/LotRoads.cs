using System;

namespace SimPe.Models.PackedFile.Ltxt
{
	[Flags]
	public enum LotRoads : byte
	{
		None = 0,
		Left = 1,
		Top = 2,
		Right = 4,
		Bottom = 8
	}
}
