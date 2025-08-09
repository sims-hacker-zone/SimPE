using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Sims2.Extensions;

namespace SimPe.Sims2.Models.Resource.Ngbh;

public partial class NgbhSlot(Ngbh parent) : ObservableObject
{
	[ObservableProperty] private Ngbh parent = parent;

	[ObservableProperty] private uint instanceID;

	[ObservableProperty] private EnumDisplayNameItem<NgbhVersion> version;

	[ObservableProperty] private ObservableCollection<NgbhItem> specialTokens = [];

	[ObservableProperty] private ObservableCollection<NgbhItem> tokens = [];

	private bool hasInstanceID;

	public static NgbhSlot Unserialize(BinaryReader reader, Ngbh parent, bool hasInstanceID)
	{
		NgbhSlot slot = new(parent);
		if (hasInstanceID)
		{
			slot.InstanceID = reader.ReadUInt32();
			slot.hasInstanceID = hasInstanceID;
		}

		if (parent.IsNightlifeOrHigher)
		{
			slot.Version = new((NgbhVersion)reader.ReadUInt32());
		}

		uint specialTokenCount = reader.ReadUInt32();
		for (uint i = 0; i < specialTokenCount; i++)
		{
			slot.SpecialTokens.Add(NgbhItem.Unserialize(reader, slot));
		}

		foreach (NgbhItem item in slot.SpecialTokens)
		{
			item.PropertyChanged += slot.Item_PropertyChanged;
		}

		uint tokenCount = reader.ReadUInt32();
		for (uint i = 0; i < tokenCount; i++)
		{
			slot.Tokens.Add(NgbhItem.Unserialize(reader, slot));
		}

		foreach (NgbhItem item in slot.Tokens)
		{
			item.PropertyChanged += slot.Item_PropertyChanged;
		}

		return slot;
	}

	public void Serialize(BinaryWriter writer)
	{
		if (hasInstanceID)
		{
			writer.Write(InstanceID);
		}

		if (Parent.IsNightlifeOrHigher)
		{
			writer.Write((uint)Version.Item);
		}

		writer.Write(SpecialTokens.Count);
		foreach (NgbhItem item in SpecialTokens)
		{
			item.Serialize(writer);
		}

		writer.Write(Tokens.Count);
		foreach (NgbhItem item in Tokens)
		{
			item.Serialize(writer);
		}
	}

	public override string ToString()
	{
		return $"0x{InstanceID:X8}: {SpecialTokens.Count} Special Tokens, {Tokens.Count} Tokens";
	}

	public void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged();
	}
}
