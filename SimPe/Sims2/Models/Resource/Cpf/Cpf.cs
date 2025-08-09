// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using SimPe.Common.Extensions;
using SimPe.Common.Models.Interfaces;
using SimPe.Sims2.Extensions;
using SimPe.Sims2.Views.Resource.Cpf;

namespace SimPe.Sims2.Models.Resource.Cpf;

public partial class Cpf(Resource resource) : ObservableObject, IWrapper
{
	private static readonly byte[] SIGNATURE = [0xE0, 0x50, 0xE7, 0xCB, 0x02, 0x00];
	private static readonly byte[] SIGNATURE_XML = "<?xml "u8.ToArray();
	[ObservableProperty] private IResource resource = resource;

	[ObservableProperty] private EnumDisplayNameItem<CpfType> type;

	[ObservableProperty] private ObservableCollection<CpfItem> items = [];

	public UserControl Panel { get; private set; }

	public string FriendlyName => null;

	public static IWrapper Unserialize(BinaryReader reader, Resource file)
	{
		byte[] sig = reader.ReadBytes(6);
		if (sig.SequenceEqual(SIGNATURE_XML))
		{
			return UnserializeXml(reader, file);
		}
		else if (!sig.SequenceEqual(SIGNATURE))
		{
			throw new InvalidDataException();
		}

		Cpf cpf = new(file)
		{
			Type = new(CpfType.Binary)
		};
		uint item_count = reader.ReadUInt32();
		for (int i = 0; i < item_count; i++)
		{
			cpf.Items.Add(CpfItem.Unserialize(reader, cpf));
		}

		foreach (CpfItem item in cpf.Items)
		{
			item.PropertyChanged += cpf.Item_OnPropertyChanged;
		}

		cpf.Panel = new CpfPanel { DataContext = cpf };
		return cpf;
	}

	public static IWrapper UnserializeXml(BinaryReader reader, Resource file)
	{
		Cpf cpf = new(file)
		{
			Type = new(CpfType.XML)
		};
		reader.BaseStream.Seek(0, SeekOrigin.Begin);
		XElement xml = XElement.Load(reader.BaseStream);
		foreach (XElement el in xml.Elements())
		{
			switch (el.Name.LocalName.ToLower())
			{
				case "anyuint32":
					cpf.Items.Add(new CpfItem(cpf)
						{ Type = new(CpfItemType.UInt), UintValue = (uint)el, Key = (string)el.Attribute("key") });
					break;
				case "anystring":
					cpf.Items.Add(new CpfItem(cpf)
					{
						Type = new(CpfItemType.String), StringValue = (string)el, Key = (string)el.Attribute("key")
					});
					break;
				case "anyfloat32":
					cpf.Items.Add(new CpfItem(cpf)
					{
						Type = new(CpfItemType.Float), FloatValue = (float)el, Key = (string)el.Attribute("key")
					});
					break;
				case "anyint32":
				case "anysint32":
					cpf.Items.Add(new CpfItem(cpf)
						{ Type = new(CpfItemType.Int), IntValue = (int)el, Key = (string)el.Attribute("key") });
					break;
				case "anyboolean":
					cpf.Items.Add(new CpfItem(cpf)
						{ Type = new(CpfItemType.Bool), BoolValue = (bool)el, Key = (string)el.Attribute("key") });
					break;
				default:
					break;
			}
		}

		foreach (CpfItem item in cpf.Items)
		{
			item.PropertyChanged += cpf.Item_OnPropertyChanged;
		}

		cpf.Panel = new CpfPanel { DataContext = cpf };
		return cpf;
	}

	public void Serialize(BinaryWriter writer)
	{
		if (Type.Item == CpfType.Binary)
		{
			writer.Write(SIGNATURE);
			writer.Write(Items.Count);
			foreach (CpfItem item in Items)
			{
				item.Serialize(writer);
			}
		}
		else
		{
			SerializeXml(writer);
		}
	}

	public void SerializeXml(BinaryWriter writer)
	{
		XElement root = new("cGZPropertySetString");
		foreach (CpfItem item in Items)
		{
			root.Add(item.Type.Item switch
			{
				CpfItemType.UInt => new XElement("AnyUint32",
					new XAttribute("key", item.Key),
					new XAttribute("type", $"0x{(uint)item.Type.Item:x8}"),
					item.UintValue),
				CpfItemType.String => new XElement("AnyString",
					new XAttribute("key", item.Key),
					new XAttribute("type", $"0x{(uint)item.Type.Item:x8}"),
					item.StringValue),
				CpfItemType.Float => new XElement("AnyFloat32",
					new XAttribute("key", item.Key),
					new XAttribute("type", $"0x{(uint)item.Type.Item:x8}"),
					item.FloatValue),
				CpfItemType.Bool => new XElement("AnyBoolean",
					new XAttribute("key", item.Key),
					new XAttribute("type", $"0x{(uint)item.Type.Item:x8}"),
					item.BoolValue),
				CpfItemType.Int => new XElement("AnySint32",
					new XAttribute("key", item.Key),
					new XAttribute("type", $"0x{(uint)item.Type.Item:x8}"),
					item.IntValue),
				_ => throw new NotImplementedException(),
			});
		}

		new XDocument([root]).Save(writer.BaseStream);
	}

	public void Item_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		OnPropertyChanged(nameof(Items));
	}
}
