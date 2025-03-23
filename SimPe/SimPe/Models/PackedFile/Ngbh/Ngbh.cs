// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Ngbh;

namespace SimPe.Models.PackedFile.Ngbh
{
	public partial class Ngbh(PackedFile file) : ObservableObject, IWrapper
	{
		public static ReadOnlySpan<byte> SIGNATURE => "HBGN"u8;
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private EnumDisplayNameItem<NgbhVersion> version;

		public bool IsBusinessOrHigher => Version >= NgbhVersion.Business;
		public bool IsNightlifeOrHigher => Version >= NgbhVersion.Nightlife;
		public bool IsSeasonsOrHigher => Version >= NgbhVersion.Seasons;
		public bool IsCastawayOrHigher => Version == NgbhVersion.Castaway;

		[ObservableProperty]
		private byte[] header = new byte[36];

		[ObservableProperty]
		private uint height;

		[ObservableProperty]
		private uint width;

		[ObservableProperty]
		private string terrainType;

		[ObservableProperty]
		private NgbhSlot[] universalTokens = new NgbhSlot[2];

		[ObservableProperty]
		private ObservableCollection<NgbhSlot> lots = [];

		[ObservableProperty]
		private ObservableCollection<NgbhSlot> families = [];

		[ObservableProperty]
		private ObservableCollection<NgbhSlot> sims = [];

		[ObservableProperty]
		private byte customHoodMarker;

		[ObservableProperty]
		private uint ePReadyMarker;

		public UserControl Panel
		{
			get; set;
		}

		public string FriendlyName => null;


		public static Ngbh Unserialize(BinaryReader reader, PackedFile file)
		{
			Ngbh ngbh = new(file);
			if (!SIGNATURE.SequenceEqual(reader.ReadBytes(4)))
			{
				throw new InvalidDataException();
			}
			ngbh.Version = new((NgbhVersion)reader.ReadUInt32());
			if (ngbh.IsCastawayOrHigher)
			{
				ngbh.Header = reader.ReadBytes(36);
			}
			else
			{
				reader.ReadUInt32();
			}
			ngbh.Height = reader.ReadUInt32();
			ngbh.Width = reader.ReadUInt32();
			int terrainTypeLen = reader.ReadInt32();
			ngbh.TerrainType = Encoding.UTF8.GetString(reader.ReadBytes(terrainTypeLen));
			_ = ngbh.Version >= NgbhVersion.Nightlife ? reader.ReadBytes(0x14) : reader.ReadBytes(0x18);
			ngbh.UniversalTokens[0] = NgbhSlot.Unserialize(reader, ngbh, false);
			ngbh.UniversalTokens[1] = NgbhSlot.Unserialize(reader, ngbh, false);
			uint lotsCount = reader.ReadUInt32();
			for (uint i = 0; i < lotsCount; i++)
			{
				ngbh.Lots.Add(NgbhSlot.Unserialize(reader, ngbh, true));
			}
			uint familiesCount = reader.ReadUInt32();
			for (uint i = 0; i < familiesCount; i++)
			{
				ngbh.Families.Add(NgbhSlot.Unserialize(reader, ngbh, true));
			}
			uint simsCount = reader.ReadUInt32();
			for (uint i = 0; i < simsCount; i++)
			{
				ngbh.Sims.Add(NgbhSlot.Unserialize(reader, ngbh, true));
			}
			ngbh.CustomHoodMarker = reader.ReadByte();
			ngbh.EPReadyMarker = reader.ReadUInt32();
			ngbh.Panel = new NgbhPanel() { DataContext = ngbh };
			return ngbh;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(SIGNATURE);
			writer.Write((uint)Version.Item);
			if (IsCastawayOrHigher)
			{
				writer.Write(Header);
			}
			else
			{
				writer.Write((uint)0);
			}
			writer.Write(Height);
			writer.Write(Width);
			writer.Write(Encoding.UTF8.GetByteCount(TerrainType));
			writer.Write(Encoding.UTF8.GetBytes(TerrainType));
			writer.Write(Version >= NgbhVersion.Nightlife ? new byte[0x14] : new byte[0x18]);
			UniversalTokens[0].Serialize(writer);
			UniversalTokens[0].Serialize(writer);
			writer.Write(Lots.Count);
			foreach (NgbhSlot item in Lots)
			{
				item.Serialize(writer);
			}
			writer.Write(Families.Count);
			foreach (NgbhSlot item in Families)
			{
				item.Serialize(writer);
			}
			writer.Write(Sims.Count);
			foreach (NgbhSlot item in Sims)
			{
				item.Serialize(writer);
			}
			writer.Write(CustomHoodMarker);
			writer.Write(EPReadyMarker);
		}
	}
}
