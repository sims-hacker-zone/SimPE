using System.ComponentModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Sims2.Data;
using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.ThreeIdr;

public partial class ThreeIdrItem(ThreeIdr parent) : ObservableObject
{
	[ObservableProperty] private ThreeIdr parent = parent;

	[ObservableProperty] private EnumDisplayNameItem<FileTypes> type;

	[ObservableProperty] private uint group;

	[ObservableProperty] private uint instanceHigh;

	[ObservableProperty] private uint instance;

	public static ThreeIdrItem Unserialize(BinaryReader reader, ThreeIdr parent)
	{
		ThreeIdrItem item = new(parent)
		{
			Type = new((FileTypes)reader.ReadUInt32()),
			Group = reader.ReadUInt32(),
			Instance = reader.ReadUInt32()
		};
		if (parent.Type == IndexTypes.ptLongFileIndex)
		{
			item.InstanceHigh = reader.ReadUInt32();
		}

		return item;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write((uint)Type.Item);
		writer.Write(Group);
		writer.Write(Instance);
		if (Parent.Type == IndexTypes.ptLongFileIndex)
		{
			writer.Write(InstanceHigh);
		}
	}

	public override string ToString()
	{
		return $"{Type} - {Group:X8} - {InstanceHigh:X8} - {Instance:X8}";
	}
}
