// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Objf;

public partial class ObjfEntry(Objf parent) : ObservableObject
{
	[ObservableProperty] private Objf parent = parent;
	[ObservableProperty] private EnumDisplayNameItem<ObjfFunction> functionID;

	[ObservableProperty] private ushort actionID;
	[ObservableProperty] private ushort guardianID;

	public static ObjfEntry Unserialize(BinaryReader reader, ushort functionID, Objf parent)
	{
		ObjfEntry entry = new(parent)
		{
			FunctionID = new((ObjfFunction)functionID),
			GuardianID = reader.ReadUInt16(),
			ActionID = reader.ReadUInt16(),
		};
		return entry;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(GuardianID);
		writer.Write(ActionID);
	}

	public override string ToString()
	{
		return $"{FunctionID}: 0x{GuardianID:X4} - 0x{ActionID:X4}";
	}
}
