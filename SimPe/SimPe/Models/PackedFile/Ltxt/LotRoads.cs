using System;

namespace SimPe.Models.PackedFile.Ltxt
{
	[Flags]
	public enum LotRoads : byte
	{
		Left = 1,
		Top = 2,
		Right = 4,
		Bottom = 8
	}
}
