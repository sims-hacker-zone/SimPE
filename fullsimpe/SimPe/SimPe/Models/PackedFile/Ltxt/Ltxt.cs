using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Ltxt;

namespace SimPe.Models.PackedFile.Ltxt
{
	public partial class Ltxt(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		private EnumDisplayNameItem<LtxtMajorVersion> majorVersion;
		public EnumDisplayNameItem<LtxtMajorVersion> MajorVersion
		{
			get => majorVersion;
			set
			{
				if (SetProperty(ref majorVersion, value))
				{
					OnPropertyChanged(nameof(IsBusinessOrHigher));
					OnPropertyChanged(nameof(IsApartmentOrHigher));
				}
			}
		}

		private EnumDisplayNameItem<LtxtMinorVersion> minorVersion;
		public EnumDisplayNameItem<LtxtMinorVersion> MinorVersion
		{
			get => minorVersion;
			set
			{
				if (SetProperty(ref minorVersion, value))
				{
					OnPropertyChanged(nameof(IsVoyageOrHigher));
					OnPropertyChanged(nameof(IsFreetimeOrHigher));
					OnPropertyChanged(nameof(IsApartmentOrHigher));
				}
			}
		}

		[ObservableProperty]
		private uint width;

		[ObservableProperty]
		private uint height;

		[ObservableProperty]
		private EnumDisplayNameItem<LotType> type;

		[ObservableProperty]
		private LotRoads lotRoads;

		[ObservableProperty]
		private EnumDisplayNameItem<LotRotation> lotRotation;

		[ObservableProperty]
		private LotFlags lotFlags;

		[ObservableProperty]
		private string name;

		[ObservableProperty]
		private string description;

		[ObservableProperty]
		private ObservableCollection<float> elevationOffsets = [];

		[ObservableProperty]
		private float unknown_00;

		[ObservableProperty]
		private LotHobbyFlags lotHobbyFlags;

		[ObservableProperty]
		private byte apartmentCount;

		[ObservableProperty]
		private uint apartmentPriceRangeHigh;

		[ObservableProperty]
		private uint apartmentPriceRangeLow;

		[ObservableProperty]
		private uint lotClassValue;

		[ObservableProperty]
		private bool useLotClassValue;

		[ObservableProperty]
		private uint positionY;

		[ObservableProperty]
		private uint positionX;

		[ObservableProperty]
		private float lotElevation;

		[ObservableProperty]
		private uint lotInstance;

		[ObservableProperty]
		private EnumDisplayNameItem<LotOrientation> lotOrientation;

		[ObservableProperty]
		private string lotTexture;

		[ObservableProperty]
		private byte unknown_01;

		[ObservableProperty]
		private uint businessOwnerInstance;

		[ObservableProperty]
		private uint apartmentBaseInstance;

		[ObservableProperty]
		private byte[] unknown_02 = [0, 0, 0, 0, 0, 0, 0, 0, 0];

		[ObservableProperty]
		private ObservableCollection<SubLot> subLots = [];

		[ObservableProperty]
		private ObservableCollection<uint> unknown_03 = [];

		public bool IsBusinessOrHigher => MajorVersion >= LtxtMajorVersion.Business;
		public bool IsVoyageOrHigher => MinorVersion >= LtxtMinorVersion.Voyage;
		public bool IsFreetimeOrHigher => MinorVersion >= LtxtMinorVersion.FreeTime;
		public bool IsApartmentOrHigher => MajorVersion >= LtxtMajorVersion.Apartment
											|| MinorVersion >= LtxtMinorVersion.Apartment;

		public UserControl Panel
		{
			get;
			private set;
		}

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Ltxt ltxt = new(file)
			{
				MajorVersion = new((LtxtMajorVersion)reader.ReadUInt16()),
				MinorVersion = new((LtxtMinorVersion)reader.ReadUInt16()),
				Width = reader.ReadUInt32(),
				Height = reader.ReadUInt32(),
				Type = new((LotType)reader.ReadByte()),
				LotRoads = (LotRoads)reader.ReadByte(),
				LotRotation = new((LotRotation)reader.ReadByte()),
				LotFlags = (LotFlags)reader.ReadUInt32(),
				Name = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32())),
				Description = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()))
			};
			int elevationOffsetCount = reader.ReadInt32();
			for (int i = 0; i < elevationOffsetCount; i++)
			{
				ltxt.ElevationOffsets.Add(reader.ReadSingle());
			}
			if (ltxt.IsVoyageOrHigher)
			{
				ltxt.Unknown_00 = reader.ReadSingle();
			}
			if (ltxt.IsFreetimeOrHigher)
			{
				ltxt.LotHobbyFlags = (LotHobbyFlags)reader.ReadUInt32();
			}
			if (ltxt.IsApartmentOrHigher)
			{
				ltxt.ApartmentCount = reader.ReadByte();
				ltxt.ApartmentPriceRangeHigh = reader.ReadUInt32();
				ltxt.ApartmentPriceRangeLow = reader.ReadUInt32();
				ltxt.LotClassValue = reader.ReadUInt32();
				ltxt.UseLotClassValue = reader.ReadBoolean();
			}

			ltxt.PositionY = reader.ReadUInt32();
			ltxt.PositionX = reader.ReadUInt32();
			ltxt.LotElevation = reader.ReadSingle();
			ltxt.LotInstance = reader.ReadUInt32();
			ltxt.LotOrientation = new((LotOrientation)reader.ReadByte());
			ltxt.LotTexture = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
			ltxt.Unknown_01 = reader.ReadByte();
			if (ltxt.IsBusinessOrHigher)
			{
				ltxt.BusinessOwnerInstance = reader.ReadUInt32();
			}
			if (ltxt.IsApartmentOrHigher)
			{
				ltxt.ApartmentBaseInstance = reader.ReadUInt32();
				ltxt.Unknown_02 = reader.ReadBytes(9);
				int sublotCount = reader.ReadInt32();
				for (int i = 0; i < sublotCount; i++)
				{
					ltxt.SubLots.Add(SubLot.Unserialize(reader, ltxt));
				}
				int unknown_03_count = reader.ReadInt32();
				for (int i = 0; i < unknown_03_count; i++)
				{
					ltxt.Unknown_03.Add(reader.ReadUInt32());
				}
			}
			ltxt.Panel = new LtxtPanel(ltxt);
			return ltxt;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write((ushort)MajorVersion.Item);
			writer.Write((ushort)MinorVersion.Item);
			writer.Write(Width);
			writer.Write(Height);
			writer.Write((byte)Type.Item);
			writer.Write((byte)LotRoads);
			writer.Write((byte)LotRotation.Item);
			writer.Write((uint)LotFlags);
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
				writer.Write((uint)LotHobbyFlags);
			}
			if (IsApartmentOrHigher)
			{
				writer.Write(ApartmentCount);
				writer.Write(ApartmentPriceRangeHigh);
				writer.Write(ApartmentPriceRangeLow);
				writer.Write(LotClassValue);
				writer.Write(UseLotClassValue);
			}
			writer.Write(PositionY);
			writer.Write(PositionX);
			writer.Write(LotElevation);
			writer.Write(LotInstance);
			writer.Write((byte)LotOrientation.Item);
			writer.Write(Encoding.UTF8.GetByteCount(LotTexture));
			writer.Write(Encoding.UTF8.GetBytes(LotTexture));
			writer.Write(Unknown_01);
			if (IsBusinessOrHigher)
			{
				writer.Write(BusinessOwnerInstance);
			}
			if (IsApartmentOrHigher)
			{
				writer.Write(ApartmentBaseInstance);
				writer.Write(Unknown_02);
				writer.Write(SubLots.Count);
				foreach (SubLot item in SubLots)
				{
					item.Serialize(writer);
				}
				foreach (uint item in Unknown_03)
				{
					writer.Write(item);
				}
			}
		}
	}
}
