// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Resource.Ttab;

public partial class TtabItemMotiveHumanTable(TtabItem parent) : ObservableObject
{
	[ObservableProperty] private TtabItem parent = parent;

	[ObservableProperty] private ObservableCollection<TtabItemMotiveHumanGroup> groups = [];

	public static TtabItemMotiveHumanTable Unserialize(BinaryReader reader, TtabItem parent)
	{
		TtabItemMotiveHumanTable table = new(parent);
		int count = parent.Parent.Version < 0x44 ? 1 : (parent.Parent.Version < 0x54 ? 7 : reader.ReadInt32());
		for (int i = 0; i < count; i++)
		{
			table.Groups.Add(TtabItemMotiveHumanGroup.Unserialize(reader, table));
		}

		return table;
	}

	public void Serialize(BinaryWriter writer)
	{
		if (Parent.Parent.Version >= 0x54)
		{
			writer.Write(Groups.Count);
			foreach (TtabItemMotiveHumanGroup item in Groups)
			{
				item.Serialize(writer);
			}
		}
		else if (Parent.Parent.Version >= 0x44)
		{
			for (int i = 0; i < Groups.Count && i < 7; i++)
			{
				Groups[i].Serialize(writer);
			}

			for (int i = Groups.Count; i < 7; i++)
			{
				new TtabItemMotiveHumanGroup(this).Serialize(writer);
			}
		}
		else
		{
			if (Groups.Any())
			{
				Groups[0].Serialize(writer);
			}
			else
			{
				new TtabItemMotiveHumanGroup(this).Serialize(writer);
			}
		}
	}
}

public partial class TtabItemMotiveHumanGroup(TtabItemMotiveHumanTable parent) : ObservableObject
{
	[ObservableProperty] private TtabItemMotiveHumanTable parent = parent;

	[ObservableProperty] private ObservableCollection<TtabItemMotiveHumanSingleItem> items = [];

	public static TtabItemMotiveHumanGroup Unserialize(BinaryReader reader, TtabItemMotiveHumanTable parent)
	{
		TtabItemMotiveHumanGroup group = new(parent);
		int count = parent.Parent.Parent.Version >= 0x54 ? reader.ReadInt32() : 16;
		for (int i = 0; i < count; i++)
		{
			group.Items.Add(TtabItemMotiveHumanSingleItem.Unserialize(reader, group));
		}

		return group;
	}

	public void Serialize(BinaryWriter writer)
	{
		if (Parent.Parent.Parent.Version >= 0x54)
		{
			writer.Write(Items.Count);
			foreach (TtabItemMotiveHumanSingleItem item in Items)
			{
				item.Serialize(writer);
			}
		}
		else
		{
			for (int i = 0; i < Items.Count && i < 16; i++)
			{
				Items[i].Serialize(writer);
			}

			for (int i = Items.Count; i < 16; i++)
			{
				new TtabItemMotiveHumanSingleItem(this).Serialize(writer);
			}
		}
	}
}

public partial class TtabItemMotiveHumanSingleItem(TtabItemMotiveHumanGroup parent) : ObservableObject
{
	[ObservableProperty] private TtabItemMotiveHumanGroup parent = parent;

	[ObservableProperty] private short min;

	[ObservableProperty] private short delta;

	[ObservableProperty] private short type;

	public static TtabItemMotiveHumanSingleItem Unserialize(BinaryReader reader, TtabItemMotiveHumanGroup parent)
	{
		TtabItemMotiveHumanSingleItem item = new(parent);
		if (parent.Parent.Parent.Parent.Version >= 0x52)
		{
			item.Type = reader.ReadInt16();
			item.Min = reader.ReadInt16();
			item.Delta = reader.ReadInt16();
		}
		else
		{
			item.Min = reader.ReadInt16();
			item.Delta = reader.ReadInt16();
			item.Type = reader.ReadInt16();
		}

		return item;
	}

	public void Serialize(BinaryWriter writer)
	{
		if (Parent.Parent.Parent.Parent.Version >= 0x52)
		{
			writer.Write(Type);
			writer.Write(Min);
			writer.Write(Delta);
		}
		else
		{
			writer.Write(Min);
			writer.Write(Delta);
			writer.Write(Type);
		}
	}
}
