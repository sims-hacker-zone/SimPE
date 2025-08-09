using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Cpf;

public enum CpfItemType : uint
{
	[DisplayName("Unsigned Integer")] UInt = 0xEB61E4F7,
	[DisplayName("String")] String = 0x0B8BEA18,
	[DisplayName("Floating-point Number")] Float = 0xABC78708,
	[DisplayName("Boolean")] Bool = 0xCBA908E1,
	[DisplayName("Signed Integer")] Int = 0x0C264712
}
