// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.Ltxt
{

	public partial class Ltxt
	{
		public class SubLot
		{
			public uint ApartmentSublot
			{
				get; set;
			}

			public uint Family
			{
				get; set;
			}

			internal uint Unknown2
			{
				get; set;
			}

			internal uint Unknown3
			{
				get; set;
			}

			internal SubLot()
			{
			}

			internal SubLot(System.IO.BinaryReader reader)
			{
				Unserialize(reader);
			}

			private void Unserialize(System.IO.BinaryReader reader)
			{
				ApartmentSublot = reader.ReadUInt32();
				Family = reader.ReadUInt32();
				Unknown2 = reader.ReadUInt32();
				Unknown3 = reader.ReadUInt32();
			}

			internal void Serialize(System.IO.BinaryWriter writer)
			{
				writer.Write(ApartmentSublot);
				writer.Write(Family);
				writer.Write(Unknown2);
				writer.Write(Unknown3);
			}
		}
	}
}
