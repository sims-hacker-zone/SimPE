using System.IO;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.PackedFile.Bnfo
{
	public partial class BnfoHistory(Bnfo parent) : ObservableObject
	{
		[ObservableProperty]
		private Bnfo parent = parent;

		[ObservableProperty]
		private uint unknown_00;

		[ObservableProperty]
		private ushort unknown_01;

		[ObservableProperty]
		private int unknown_02;

		[ObservableProperty]
		private uint unknown_03;

		[ObservableProperty]
		private byte unknown_04;

		[ObservableProperty]
		private int unknown_05;

		[ObservableProperty]
		private uint unknown_06;

		[ObservableProperty]
		private uint unknown_07;

		[ObservableProperty]
		private uint unknown_08;

		[ObservableProperty]
		private int unknown_09;

		[ObservableProperty]
		private uint unknown_10;

		[ObservableProperty]
		private uint unknown_11;

		[ObservableProperty]
		private int unknown_12;

		[ObservableProperty]
		private uint unknown_13;

		[ObservableProperty]
		private byte unknown_14;

		[ObservableProperty]
		private uint unknown_15;

		[ObservableProperty]
		private int unknown_16;

		[ObservableProperty]
		private int unknown_17;

		[ObservableProperty]
		private int unknown_18;

		[ObservableProperty]
		private int unknown_19;

		public static BnfoHistory Unserialize(BinaryReader reader, Bnfo parent)
		{
			return new BnfoHistory(parent)
			{
				Unknown_00 = reader.ReadUInt32(),
				Unknown_01 = reader.ReadUInt16(),
				Unknown_02 = reader.ReadInt32(),
				Unknown_03 = reader.ReadUInt32(),
				Unknown_04 = reader.ReadByte(),
				Unknown_05 = reader.ReadInt32(),
				Unknown_06 = reader.ReadUInt32(),
				Unknown_07 = reader.ReadUInt32(),
				Unknown_08 = reader.ReadUInt32(),
				Unknown_09 = reader.ReadInt32(),
				Unknown_10 = reader.ReadUInt32(),
				Unknown_11 = reader.ReadUInt32(),
				Unknown_12 = reader.ReadInt32(),
				Unknown_13 = reader.ReadUInt32(),
				Unknown_14 = reader.ReadByte(),
				Unknown_15 = reader.ReadUInt32(),
				Unknown_16 = reader.ReadInt32(),
				Unknown_17 = reader.ReadInt32(),
				Unknown_18 = reader.ReadInt32(),
				Unknown_19 = reader.ReadInt32()
			};
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(Unknown_00);
			writer.Write(Unknown_01);
			writer.Write(Unknown_02);
			writer.Write(Unknown_03);
			writer.Write(Unknown_04);
			writer.Write(Unknown_05);
			writer.Write(Unknown_06);
			writer.Write(Unknown_07);
			writer.Write(Unknown_08);
			writer.Write(Unknown_09);
			writer.Write(Unknown_10);
			writer.Write(Unknown_11);
			writer.Write(Unknown_12);
			writer.Write(Unknown_13);
			writer.Write(Unknown_14);
			writer.Write(Unknown_15);
			writer.Write(Unknown_16);
			writer.Write(Unknown_17);
			writer.Write(Unknown_18);
			writer.Write(Unknown_19);
		}
	}
}
