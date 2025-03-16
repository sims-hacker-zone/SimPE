// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.Package
{
	public partial class PackageHeaderHole : ObservableObject
	{
		[ObservableProperty]
		private int count;
		[ObservableProperty]
		private uint offset;
		[ObservableProperty]
		private uint size;

		public static PackageHeaderHole Unserialize(BinaryReader reader)
		{
			return new PackageHeaderHole()
			{
				Count = reader.ReadInt32(),
				Offset = reader.ReadUInt32(),
				Size = reader.ReadUInt32()
			};
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(Count);
			writer.Write(Offset);
			writer.Write(Size);
		}
	}
}
