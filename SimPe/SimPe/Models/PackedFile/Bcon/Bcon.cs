// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Bcon;

namespace SimPe.Models.PackedFile.Bcon
{
	public partial class Bcon(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;

		private string fileName;

		public string FileName
		{
			get => fileName;
			set
			{
				if (SetProperty(ref fileName, value))
				{
					OnPropertyChanged(FriendlyName);
				}
			}
		}

		[ObservableProperty]
		private byte flag;

		[ObservableProperty]
		private ObservableCollection<ushort> constants = [];

		public UserControl Panel
		{
			get;
			private set;
		}

		public string FriendlyName => FileName;

		public static Bcon Unserialize(BinaryReader reader, PackedFile file)
		{
			Bcon bcon = new(file)
			{
				FileName = Encoding.UTF8.GetString(reader.ReadBytes(64))
			};
			byte count = reader.ReadByte();
			bcon.Flag = reader.ReadByte();
			for (int i = 0; i < count; i++)
			{
				bcon.Constants.Add(reader.ReadUInt16());
			}
			bcon.Panel = new BconPanel() { DataContext = bcon };
			return bcon;
		}

		public void Serialize(BinaryWriter writer)
		{
			byte[] buffer = Encoding.UTF8.GetBytes(FileName);
			Array.Resize(ref buffer, 64);
			writer.Write(buffer);
			writer.Write(Constants.Count);
			writer.Write(Flag);
			foreach (ushort item in Constants)
			{
				writer.Write(item);
			}
		}
	}
}
