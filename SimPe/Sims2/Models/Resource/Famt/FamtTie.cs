// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Famt;

public partial class FamtTie(FamtSim parent) : ObservableObject
{
	[ObservableProperty] private FamtSim parent = parent;

	[ObservableProperty] private EnumDisplayNameItem<FamtType> type;

	[ObservableProperty] private ushort targetInstance;

	public static FamtTie Unserialize(BinaryReader reader, FamtSim parent)
	{
		return new FamtTie(parent)
		{
			Type = new((FamtType)reader.ReadUInt32()),
			TargetInstance = reader.ReadUInt16()
		};
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write((uint)Type.Item);
		writer.Write(TargetInstance);
	}

	public override string ToString()
	{
		return $"{Type.DisplayName}: 0x{TargetInstance:X4}";
	}
}
