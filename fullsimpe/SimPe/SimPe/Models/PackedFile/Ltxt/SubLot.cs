using System.IO;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.PackedFile.Ltxt
{
	public partial class SubLot(Ltxt parent) : ObservableObject
	{
		[ObservableProperty]
		private Ltxt parent = parent;

		[ObservableProperty]
		private uint subLotInstance;

		[ObservableProperty]
		private uint familyInstance;

		[ObservableProperty]
		private uint unknown;

		[ObservableProperty]
		private uint roommateInstance;

		public static SubLot Unserialize(BinaryReader reader, Ltxt parent)
		{
			return new SubLot(parent)
			{
				SubLotInstance = reader.ReadUInt32(),
				FamilyInstance = reader.ReadUInt32(),
				Unknown = reader.ReadUInt32(),
				RoommateInstance = reader.ReadUInt32(),
			};
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(SubLotInstance);
			writer.Write(FamilyInstance);
			writer.Write(Unknown);
			writer.Write(RoommateInstance);
		}
	}
}
