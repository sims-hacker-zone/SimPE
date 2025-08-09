using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Ngbh;

public partial class NgbhItem(NgbhSlot parent) : ObservableObject
{
	[ObservableProperty] private NgbhSlot parent = parent;

	[ObservableProperty] private uint guid;

	[ObservableProperty] private CheckableFlagEnum<NgbhItemFlags> flags1;
	[ObservableProperty] private CheckableFlagEnum<NgbhItemFlags> flags2;

	[ObservableProperty] private uint inventoryNumber;

	[ObservableProperty] private ushort unknown;

	[ObservableProperty] private ObservableCollection<ushort> dataItems = [];

	public static NgbhItem Unserialize(BinaryReader reader, NgbhSlot parent)
	{
		NgbhItem item = new(parent)
		{
			Guid = reader.ReadUInt32(),
			Flags1 = new((NgbhItemFlags)reader.ReadUInt16())
		};
		if (parent.Parent.IsBusinessOrHigher)
		{
			item.Flags2 = new((NgbhItemFlags)reader.ReadUInt16());
		}

		if (parent.Parent.IsNightlifeOrHigher)
		{
			item.InventoryNumber = reader.ReadUInt32();
		}

		if (parent.Parent.IsSeasonsOrHigher)
		{
			item.Unknown = reader.ReadUInt16();
		}

		uint datacount = reader.ReadUInt32();
		for (uint i = 0; i < datacount; i++)
		{
			item.DataItems.Add(reader.ReadUInt16());
		}

		item.Flags1.PropertyChanged += item.Item_PropertyChanged;
		item.Flags2.PropertyChanged += item.Item_PropertyChanged;
		return item;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Guid);
		writer.Write((ushort)Flags1.Value);
		if (Parent.Parent.IsBusinessOrHigher)
		{
			writer.Write((ushort)Flags2.Value);
		}

		if (Parent.Parent.IsNightlifeOrHigher)
		{
			writer.Write(InventoryNumber);
		}

		if (Parent.Parent.IsSeasonsOrHigher)
		{
			writer.Write(Unknown);
		}

		writer.Write(DataItems.Count);
		foreach (ushort item in DataItems)
		{
			writer.Write(item);
		}
	}

	public override string ToString()
	{
		return $"0x{Guid:X8} - Items: {DataItems.Count}";
	}

	public void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged();
	}
}
