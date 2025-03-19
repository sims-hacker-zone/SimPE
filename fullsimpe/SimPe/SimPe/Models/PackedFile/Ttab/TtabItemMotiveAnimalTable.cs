// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.PackedFile.Ttab
{
	public partial class TtabItemMotiveAnimalTable(TtabItem parent) : ObservableObject
	{
		[ObservableProperty]
		private TtabItem parent = parent;

		[ObservableProperty]
		private ObservableCollection<TtabItemMotiveAnimalGroup> groups = [];

		public static TtabItemMotiveAnimalTable Unserialize(BinaryReader reader, TtabItem parent)
		{
			TtabItemMotiveAnimalTable table = new(parent);
			int groupCount = reader.ReadInt32();
			for (int i = 0; i < groupCount; i++)
			{
				table.Groups.Add(TtabItemMotiveAnimalGroup.Unserialize(reader, table));
			}
			return table;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(Groups.Count);
			foreach (TtabItemMotiveAnimalGroup item in Groups)
			{
				item.Serialize(writer);
			}

		}
	}

	public partial class TtabItemMotiveAnimalGroup(TtabItemMotiveAnimalTable parent) : ObservableObject
	{
		[ObservableProperty]
		private TtabItemMotiveAnimalTable parent = parent;

		[ObservableProperty]
		private ObservableCollection<TtabItemMotiveAnimalItem> items = [];

		public static TtabItemMotiveAnimalGroup Unserialize(BinaryReader reader, TtabItemMotiveAnimalTable parent)
		{
			TtabItemMotiveAnimalGroup group = new(parent);
			int itemCount = reader.ReadInt32();
			for (int i = 0; i < itemCount; i++)
			{
				group.Items.Add(TtabItemMotiveAnimalItem.Unserialize(reader, group));
			}
			return group;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(Items.Count);
			foreach (TtabItemMotiveAnimalItem item in Items)
			{
				item.Serialize(writer);
			}
		}
	}

	public partial class TtabItemMotiveAnimalItem(TtabItemMotiveAnimalGroup parent) : ObservableObject
	{
		[ObservableProperty]
		private TtabItemMotiveAnimalGroup parent = parent;

		[ObservableProperty]
		private ObservableCollection<TtabItemMotiveAnimalSingleItem> items = [];

		public static TtabItemMotiveAnimalItem Unserialize(BinaryReader reader, TtabItemMotiveAnimalGroup parent)
		{
			TtabItemMotiveAnimalItem item = new(parent);
			int itemCount = reader.ReadInt32();
			for (int i = 0; i < itemCount; i++)
			{
				item.Items.Add(TtabItemMotiveAnimalSingleItem.Unserialize(reader, item));
			}
			return item;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(Items.Count);
			foreach (TtabItemMotiveAnimalSingleItem item in Items)
			{
				item.Serialize(writer);
			}
		}
	}

	public partial class TtabItemMotiveAnimalSingleItem(TtabItemMotiveAnimalItem parent) : ObservableObject
	{
		[ObservableProperty]
		private TtabItemMotiveAnimalItem parent = parent;

		[ObservableProperty]
		private short min;

		[ObservableProperty]
		private short delta;

		[ObservableProperty]
		private short type;

		public static TtabItemMotiveAnimalSingleItem Unserialize(BinaryReader reader, TtabItemMotiveAnimalItem parent)
		{
			return new TtabItemMotiveAnimalSingleItem(parent)
			{
				Type = reader.ReadInt16(),
				Min = reader.ReadInt16(),
				Delta = reader.ReadInt16()
			};
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(Type);
			writer.Write(Min);
			writer.Write(Delta);
		}
	}
}
