// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.IO;
using System.Linq;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Scid;

namespace SimPe.Models.PackedFile.Scid
{
	public partial class Scid(PackedFile file) : ObservableObject, IWrapper
	{
		public static readonly byte[] SIGNATURE = [0x34, 0x6A, 0x2A, 0xCC];
		[ObservableProperty]
		private PackedFile file = file;

		[ObservableProperty]
		private uint unknown_00;

		[ObservableProperty]
		private uint unknown_01;

		[ObservableProperty]
		private ushort sCID;

		public UserControl Panel
		{
			get;
			private set;
		}

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			if (!SIGNATURE.SequenceEqual(reader.ReadBytes(4)))
			{
				throw new InvalidDataException();
			}
			Scid scid = new(file)
			{
				Unknown_00 = reader.ReadUInt32(),
				Unknown_01 = reader.ReadUInt32(),
				SCID = reader.ReadUInt16()
			};

			scid.Panel = new ScidPanel() { DataContext = scid };

			return scid;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(SIGNATURE);
			writer.Write(Unknown_00);
			writer.Write(Unknown_01);
			writer.Write(SCID);
		}
	}
}
