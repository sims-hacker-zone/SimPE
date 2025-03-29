// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Bhav;

namespace SimPe.Models.PackedFile.Bhav
{
	public partial class Bhav(PackedFile file) : ObservableObject, IWrapper
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
		private ushort version;

		[ObservableProperty]
		private byte treeType;

		[ObservableProperty]
		private byte parameterCount;

		[ObservableProperty]
		private byte localVarCount;

		[ObservableProperty]
		private byte headerFlag;

		[ObservableProperty]
		private int treeVersion;

		[ObservableProperty]
		private ObservableCollection<BhavInstruction> instructions = [];

		[ObservableProperty]
		private byte cacheFlags;


		public UserControl Panel
		{
			get;
			private set;
		}

		public string FriendlyName => FileName;

		public static Bhav Unserialize(BinaryReader reader, PackedFile file)
		{
			Bhav bhav = new(file)
			{
				FileName = Encoding.UTF8.GetString(reader.ReadBytes(64)),
				Version = reader.ReadUInt16()
			};
			ushort instructionCount = reader.ReadUInt16();
			bhav.TreeType = reader.ReadByte();
			bhav.ParameterCount = reader.ReadByte();
			bhav.LocalVarCount = reader.ReadByte();
			bhav.HeaderFlag = reader.ReadByte();
			bhav.TreeVersion = reader.ReadInt32();
			if (bhav.Version >= 0x8009)
			{
				bhav.CacheFlags = reader.ReadByte();
			}
			for (int i = 0; i < instructionCount; i++)
			{
				bhav.Instructions.Add(BhavInstruction.Unserialize(reader, bhav));
			}
			foreach (BhavInstruction item in bhav.Instructions)
			{
				item.PropertyChanged += bhav.Item_PropertyChanged;
			}
			bhav.Panel = new BhavPanel() { DataContext = bhav };
			return bhav;
		}

		public void Serialize(BinaryWriter writer)
		{
			byte[] buffer = Encoding.UTF8.GetBytes(FileName);
			Array.Resize(ref buffer, 64);
			writer.Write(buffer);
			writer.Write(Version);
			writer.Write((ushort)Instructions.Count);
			writer.Write(TreeType);
			writer.Write(ParameterCount);
			writer.Write(LocalVarCount);
			writer.Write(HeaderFlag);
			writer.Write(TreeVersion);
			foreach (BhavInstruction item in Instructions)
			{
				item.Serialize(writer);
			}
			if (Version >= 0x8009)
			{
				writer.Write(CacheFlags);
			}
		}

		public void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged();
		}

	}
}
