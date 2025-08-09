using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Models.Resource.Ltxt;
using SimPe.Sims2.Views.Resource.Lotd;

namespace SimPe.Sims2.Models.Resource.Lotd;

public partial class Lotd(Resource resource) : ObservableObject, IWrapper
{
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private string resourceName;

	private EnumDisplayNameItem<LtxtMinorVersion> version;

	public EnumDisplayNameItem<LtxtMinorVersion> Version
	{
		get => version;
		set
		{
			if (SetProperty(ref version, value))
			{
				OnPropertyChanged(nameof(IsVoyageOrHigher));
				OnPropertyChanged(nameof(IsFreetimeOrHigher));
				OnPropertyChanged(nameof(IsApartmentOrHigher));
			}
		}
	}

	[ObservableProperty] private uint width;

	[ObservableProperty] private uint height;


	[ObservableProperty] private EnumDisplayNameItem<LotType> type;

	[ObservableProperty] private CheckableFlagEnum<LotRoads> lotRoads;

	[ObservableProperty] private EnumDisplayNameItem<LotRotation> lotRotation;

	[ObservableProperty] private CheckableFlagEnum<LotFlags> lotFlags;

	[ObservableProperty] private string name;

	[ObservableProperty] private string description;

	[ObservableProperty] private ObservableCollection<float> elevationOffsets = [];

	[ObservableProperty] private float unknown_00;

	[ObservableProperty] private CheckableFlagEnum<LotHobbyFlags> lotHobbyFlags;

	[ObservableProperty] private byte apartmentCount;

	[ObservableProperty] private uint apartmentPriceRangeHigh;

	[ObservableProperty] private uint apartmentPriceRangeLow;

	[ObservableProperty] private uint lotClassValue;

	[ObservableProperty] private bool useLotClassValue;

	public bool IsVoyageOrHigher => Version >= LtxtMinorVersion.Voyage;
	public bool IsFreetimeOrHigher => Version >= LtxtMinorVersion.FreeTime;
	public bool IsApartmentOrHigher => Version >= LtxtMinorVersion.Apartment;

	public UserControl Panel { get; private set; }

	public string FriendlyName => ResourceName;

	public static Lotd Unserialize(BinaryReader reader, Resource file)
	{
		Lotd lotd = new(file);
		lotd.ResourceName = Encoding.UTF8.GetString(reader.ReadBytes(64));
		lotd.Version = new((LtxtMinorVersion)reader.ReadUInt16());
		lotd.Width = reader.ReadUInt32();
		lotd.Height = reader.ReadUInt32();
		lotd.Type = new((LotType)reader.ReadByte());
		lotd.LotRoads = new((LotRoads)reader.ReadByte());
		lotd.LotRotation = new((LotRotation)reader.ReadByte());
		lotd.LotFlags = new((LotFlags)reader.ReadUInt32());
		lotd.Name = reader.ReadString();
		lotd.Description = reader.ReadString();
		int elevationOffsetCount = reader.ReadInt32();
		for (int i = 0; i < elevationOffsetCount; i++)
		{
			lotd.ElevationOffsets.Add(reader.ReadSingle());
		}

		if (lotd.IsVoyageOrHigher)
		{
			lotd.Unknown_00 = reader.ReadSingle();
		}

		if (lotd.IsFreetimeOrHigher)
		{
			lotd.LotHobbyFlags = new((LotHobbyFlags)reader.ReadUInt32());
		}

		if (lotd.IsApartmentOrHigher)
		{
			lotd.ApartmentCount = reader.ReadByte();
			lotd.ApartmentPriceRangeHigh = reader.ReadUInt32();
			lotd.ApartmentPriceRangeLow = reader.ReadUInt32();
			lotd.LotClassValue = reader.ReadUInt32();
			lotd.UseLotClassValue = reader.ReadBoolean();
		}

		lotd.Panel = new LotdPanel { DataContext = lotd };
		return lotd;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write((ushort)Version.Item);
		writer.Write(Width);
		writer.Write(Height);
		writer.Write((byte)Type.Item);
		writer.Write((byte)LotRoads.Value);
		writer.Write((byte)LotRotation.Item);
		writer.Write((uint)LotFlags.Value);
		writer.Write(Encoding.UTF8.GetByteCount(Name));
		writer.Write(Encoding.UTF8.GetBytes(Name));
		writer.Write(Encoding.UTF8.GetByteCount(Description));
		writer.Write(Encoding.UTF8.GetBytes(Description));
		writer.Write(ElevationOffsets.Count);
		foreach (float item in ElevationOffsets)
		{
			writer.Write(item);
		}

		if (IsVoyageOrHigher)
		{
			writer.Write(Unknown_00);
		}

		if (IsFreetimeOrHigher)
		{
			writer.Write((uint)LotHobbyFlags.Value);
		}

		if (IsApartmentOrHigher)
		{
			writer.Write(ApartmentCount);
			writer.Write(ApartmentPriceRangeHigh);
			writer.Write(ApartmentPriceRangeLow);
			writer.Write(LotClassValue);
			writer.Write(UseLotClassValue);
		}
	}
}
