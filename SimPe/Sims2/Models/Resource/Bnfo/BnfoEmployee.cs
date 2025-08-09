using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Bnfo;

public partial class BnfoEmployee(Bnfo parent) : ObservableObject
{
	[ObservableProperty] private Bnfo parent = parent;

	[ObservableProperty] private ushort instance;

	[ObservableProperty] private EnumDisplayNameItem<BnfoEmployeePayRate> payRate;

	/// <summary>
	/// What amount the game considers as "Fairly Paid"
	/// According to the formula:
	/// 15 base
	/// + 1 per skill point
	/// + 5 per bronze talent badge
	/// + 10 per silver talent badge
	/// + 15 per golden talent badge
	/// (+ 70 when manager, but this doesn't work due to a bug in the game)
	/// </summary>
	[ObservableProperty] private uint fairPay;

	public static BnfoEmployee Unserialize(BinaryReader reader, Bnfo parent)
	{
		return new BnfoEmployee(parent)
		{
			Instance = reader.ReadUInt16(),
			PayRate = new((BnfoEmployeePayRate)reader.ReadUInt32()),
			FairPay = reader.ReadUInt32()
		};
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Instance);
		writer.Write((uint)PayRate.Item);
		writer.Write(FairPay);
	}
}
