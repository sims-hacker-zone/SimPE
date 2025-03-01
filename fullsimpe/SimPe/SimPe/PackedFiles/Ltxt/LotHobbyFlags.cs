using System;

namespace SimPe.PackedFiles.Ltxt
{
	[Flags]
	public enum LotHobbyFlags : uint
	{
		Cooking = 0x0000_0001,
		Art = 0x0000_0002,
		Films = 0x0000_0004,
		Sport = 0x0000_0008,
		Games = 0x0000_0010,
		Nature = 0x0000_0020,
		Tinkering = 0x0000_0040,
		Fitness = 0x0000_0080,
		Science = 0x0000_0100,
		Music = 0x0000_0200
	}
}
