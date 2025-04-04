using System.Collections.ObjectModel;
using System.IO;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.PackedFile.Bnfo
{
	public partial class BnfoCustomer(Bnfo parent) : ObservableObject
	{
		[ObservableProperty]
		private Bnfo parent = parent;

		[ObservableProperty]
		private ushort instance;

		[ObservableProperty]
		private int loyalty;

		[ObservableProperty]
		private ObservableCollection<uint> data = [];

		[ObservableProperty]
		private ObservableCollection<uint> data2 = [];

		[ObservableProperty]
		private uint unknown_00;

		[ObservableProperty]
		private uint unknown_01;

		[ObservableProperty]
		private int stars;

		public static BnfoCustomer Unserialize(BinaryReader reader, Bnfo parent)
		{
			BnfoCustomer customer = new(parent)
			{
				Instance = reader.ReadUInt16(),
				Loyalty = reader.ReadInt32()
			};
			uint dataCount = reader.ReadUInt32();
			for (int i = 0; i < dataCount; i++)
			{
				customer.Data.Add(reader.ReadUInt32());
			}
			uint data2Count = reader.ReadUInt32();
			for (int i = 0; i < data2Count; i++)
			{
				customer.Data2.Add(reader.ReadUInt32());
			}
			customer.Unknown_00 = reader.ReadUInt32();
			customer.Unknown_01 = reader.ReadUInt32();
			customer.Stars = reader.ReadInt32();
			return customer;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(Instance);
			writer.Write(Loyalty);
			writer.Write(Data.Count);
			foreach (uint item in Data)
			{
				writer.Write(item);
			}
			writer.Write(Data2.Count);
			foreach (uint item in Data2)
			{
				writer.Write(item);
			}
			writer.Write(Unknown_00);
			writer.Write(Unknown_01);
			writer.Write(Stars);
		}
	}
}
