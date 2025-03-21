// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Models.Interfaces;
using SimPe.Views.PackedFile.Str;

namespace SimPe.Models.PackedFile.Str
{
	public partial class Str(PackedFile file) : ObservableObject, IWrapper
	{
		[ObservableProperty]
		private PackedFile file = file;
		[ObservableProperty]
		private string fileName;

		[ObservableProperty]
		private EnumDisplayNameItem<StrFileFormat> format;

		[ObservableProperty]
		private ushort count;

		[ObservableProperty]
		private ObservableCollection<StrItem> items = [];

		[ObservableProperty]
		private FlatTreeDataGridSource<StrItem> gridSource;

		public ILookup<EnumDisplayNameItem<Languages>, StrItem> ByLanguage => Items.ToLookup(item => item.Language);

		public ILookup<int, StrItem> ByIndex => (from item in ByLanguage
												 from data in item.Select((item, i) => (item, i))
												 select data).ToLookup(item => item.i, item => item.item);


		public UserControl Panel
		{
			get; private set;
		}

		public string FriendlyName => FileName;

		public StrItem this[Languages l, int index] => Items.Where(item => item.Language == l).Skip(index).FirstOrDefault();

		public IEnumerable<StrItem> this[int index] => from item in ByLanguage
													   select item.Skip(index).FirstOrDefault();

		public static IWrapper Unserialize(BinaryReader reader, PackedFile file)
		{
			Str str = new(file)
			{
				FileName = Encoding.ASCII.GetString(reader.ReadBytes(64))
			};

			byte type = reader.ReadByte();
			byte c = reader.ReadByte();
			if (type == 0)
			{
				str.Format = new(StrFileFormat.NoLanguage);
				str.Count = c;
			}
			else
			{
				str.Format = new((StrFileFormat)((c << 8) | type));
				str.Count = str.Format == StrFileFormat.NoDescriptions ? reader.ReadByte() : reader.ReadUInt16();
			}

			for (int i = 0; i < str.Count; i++)
			{
				str.Items.Add(StrItem.Unserialize(reader, str));
			}

			str.GridSource = new(str.Items);
			str.GridSource.Columns.AddRange([
				new TextColumn<StrItem, string>("Language", x => x.Language.ToString()),
				new TextColumn<StrItem, string>("Title", x => x.Title),
				new TextColumn<StrItem, string>("Description", x => x.Description),
			]);

			str.Panel = new StrPanel(str);

			return str;
		}

		public void Serialize(BinaryWriter writer)
		{
			throw new System.NotImplementedException();
		}
	}
}
