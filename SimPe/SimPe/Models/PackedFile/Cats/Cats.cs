// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Cats;

namespace SimPe.Models.PackedFile.Cats
{
	public partial class Cats(PackedFile file) : ObservableObject, IWrapper
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
		private string content;

		public UserControl Panel
		{
			get;
			private set;
		}

		public string FriendlyName => FileName;

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Cats Cats = new(file)
			{
				FileName = Encoding.ASCII.GetString(reader.ReadBytes(64)),
				Content = reader.ReadUTF8CString()
			};

			Cats.Panel = new CatsPanel() { DataContext = Cats };

			return Cats;
		}

		public void Serialize(BinaryWriter writer)
		{
			byte[] buffer = Encoding.ASCII.GetBytes(FileName);
			Array.Resize(ref buffer, 64);
			writer.Write(buffer);
			writer.Write(Encoding.UTF8.GetBytes(Content));
			writer.Write((byte)0);
		}
	}
}
