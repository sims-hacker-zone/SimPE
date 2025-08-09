using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Sims2.Data;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Models.Package;

namespace SimPe.Sims2.Models.Resource.Clst;

public partial class ClstItem(Clst parent) : ObservableObject
{
	[ObservableProperty] private Clst parent = parent;

	[ObservableProperty] private FileTypes type;

	[ObservableProperty] private uint group;

	[ObservableProperty] private uint instanceHigh;

	[ObservableProperty] private uint instance;

	[ObservableProperty] private uint uncompressedSize;

	public static ClstItem Unserialize(BinaryReader reader, Clst parent)
	{
		ClstItem item = new(parent)
		{
			Type = (FileTypes)reader.ReadUInt32(),
			Group = reader.ReadUInt32(),
			Instance = reader.ReadUInt32()
		};
		if ((parent.Resource.File as PackageFile).Header.IndexType == IndexTypes.ptLongFileIndex)
		{
			item.InstanceHigh = reader.ReadUInt32();
		}

		item.UncompressedSize = reader.ReadUInt32();
		return item;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write((uint)Type);
		writer.Write(Group);
		writer.Write(Instance);
		if ((parent.Resource.File as PackageFile).Header.IndexType == IndexTypes.ptLongFileIndex)
		{
			writer.Write(InstanceHigh);
		}

		writer.Write(UncompressedSize);
	}

	public override string ToString()
	{
		return
			$"{Type.ToFileTypeInformation().LongName}: {Group:X8} - {InstanceHigh:X8} - {Instance:X8}; Uncompressed size = {UncompressedSize}";
	}
}
