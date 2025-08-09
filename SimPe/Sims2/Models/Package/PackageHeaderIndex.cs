// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Security;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Package;

public partial class PackageHeaderIndex : ObservableObject
{
	[ObservableProperty] private int type = 7;
	[ObservableProperty] private int count;
	[ObservableProperty] private uint offset;
	[ObservableProperty] private uint size;

	public static PackageHeaderIndex Unserialize(BinaryReader reader)
	{
		return new PackageHeaderIndex()
		{
			Type = reader.ReadInt32(),
			Count = reader.ReadInt32(),
			Offset = reader.ReadUInt32(),
			Size = reader.ReadUInt32()
		};
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Type);
		writer.Write(Count);
		writer.Write(Offset);
		writer.Write(Size);
	}
}
