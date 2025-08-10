using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;
using AvaloniaHex.Document;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims1.Data;

namespace SimPe.Sims1.Models.Resource;

public partial class Resource(IFFFile.IFFFile file) : ObservableObject, IResource
{
	[ObservableProperty] private IFile file = file;

	[ObservableProperty] private EnumDisplayNameItem<ResourceTypes> type;

	[ObservableProperty] private ushort iD;

	[ObservableProperty] private uint size;

	[ObservableProperty] private ushort flags;

	[ObservableProperty] private string name;

	[ObservableProperty] private byte[] data;

	[ObservableProperty] private byte[]? userData;

	public bool ResourceChanged => UserData != null;

	public DynamicBinaryDocument DataDocument => new(Data) { IsReadOnly = true };

	public DynamicBinaryDocument UserDataDocument => new(UserData) { IsReadOnly = true };


	public string DisplayName => Name;

	public IWrapper Wrapper { get; set; }

	public static Resource? Unserialize(BinaryReader reader, IFFFile.IFFFile file)
	{
		EnumDisplayNameItem<ResourceTypes> type =
			new((ResourceTypes)BinaryPrimitives.ReadUInt32BigEndian(reader.ReadBytes(4).AsSpan()));
		uint size = BinaryPrimitives.ReadUInt32BigEndian(reader.ReadBytes(4).AsSpan());
		if (type == ResourceTypes.XXXX)
		{
			reader.BaseStream.Position += size - 8;
			return null;
		}

		Resource resource = new(file)
		{
			Type = type,
			Size = size,
			ID = BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2).AsSpan()),
			Flags = BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2).AsSpan()),
			Name = Encoding.UTF8.GetString(reader.ReadBytes(64)),
		};

		resource.Data = reader.ReadBytes((int)resource.Size - 76);

		return resource;
	}
}
