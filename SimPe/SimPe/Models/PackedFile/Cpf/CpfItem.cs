// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Text;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Cpf
{
	public partial class CpfItem(Cpf parent) : ObservableObject
	{
		[ObservableProperty]
		private Cpf parent = parent;

		[ObservableProperty]
		private EnumDisplayNameItem<CpfItemType> type;

		[ObservableProperty]
		private string key;

		[ObservableProperty]
		private uint uintValue;

		[ObservableProperty]
		private string stringValue;

		[ObservableProperty]
		private float floatValue;

		[ObservableProperty]
		private bool boolValue;

		[ObservableProperty]
		private int intValue;

		public bool IsUInt => Type.Item == CpfItemType.UInt;
		public bool IsBool => Type.Item == CpfItemType.Bool;
		public bool IsFloat => Type.Item == CpfItemType.Float;
		public bool IsInt => Type.Item == CpfItemType.Int;
		public bool IsString => Type.Item == CpfItemType.String;

		public static CpfItem Unserialize(BinaryReader reader, Cpf parent)
		{
			CpfItem item = new(parent)
			{
				Type = new((CpfItemType)reader.ReadUInt32())
			};
			int key_length = reader.ReadInt32();
			item.Key = Encoding.UTF8.GetString(reader.ReadBytes(key_length));
			switch (item.Type.Item)
			{
				case CpfItemType.UInt:
					item.UintValue = reader.ReadUInt32();
					break;
				case CpfItemType.String:
					int value_length = reader.ReadInt32();
					item.StringValue = Encoding.UTF8.GetString(reader.ReadBytes(value_length));
					break;
				case CpfItemType.Float:
					item.FloatValue = reader.ReadSingle();
					break;
				case CpfItemType.Bool:
					item.BoolValue = reader.ReadBoolean();
					break;
				case CpfItemType.Int:
					item.IntValue = reader.ReadInt32();
					break;
				default:
					break;
			}
			return item;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write((uint)Type.Item);
			writer.Write(Encoding.UTF8.GetByteCount(Key));
			writer.Write(Encoding.UTF8.GetBytes(Key));
			switch (Type.Item)
			{
				case CpfItemType.UInt:
					writer.Write(UintValue);
					break;
				case CpfItemType.String:
					writer.Write(Encoding.UTF8.GetByteCount(StringValue));
					writer.Write(Encoding.UTF8.GetBytes(StringValue));
					break;
				case CpfItemType.Float:
					writer.Write(FloatValue);
					break;
				case CpfItemType.Bool:
					writer.Write(BoolValue);
					break;
				case CpfItemType.Int:
					writer.Write(IntValue);
					break;
			}
		}

		public override string ToString()
		{
			return Key;
		}
	}
}
