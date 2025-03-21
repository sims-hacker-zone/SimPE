// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Extensions;

namespace SimPe.Models.PackedFile.Swaf
{
	public partial class SwafItem(Swaf parent, EnumDisplayNameItem<SwafItemType> type) : ObservableObject
	{
		[ObservableProperty]
		private Swaf parent = parent;

		[ObservableProperty]
		private EnumDisplayNameItem<SwafItemType> type = type;

		[ObservableProperty]
		private EnumDisplayNameItem<SwafItemVersion> version;

		[ObservableProperty]
		private ushort simInstance;

		[ObservableProperty]
		private uint guid;

		[ObservableProperty]
		private EnumDisplayNameItem<WantType> wantType;

		[ObservableProperty]
		private uint value;

		[ObservableProperty]
		private ushort property;

		[ObservableProperty]
		private uint index;

		[ObservableProperty]
		private int score;

		[ObservableProperty]
		private int influence;

		[ObservableProperty]
		private bool locked;

		public static SwafItem Unserialize(BinaryReader reader, Swaf parent, EnumDisplayNameItem<SwafItemType> type)
		{
			SwafItem item = new(parent, type)
			{
				Version = new((SwafItemVersion)reader.ReadUInt32()),
				SimInstance = reader.ReadUInt16(),
				Guid = reader.ReadUInt32(),
				WantType = new((WantType)reader.ReadByte())
			};

			item.Value = item.WantType.Item switch
			{
				Models.PackedFile.Swaf.WantType.Skill => reader.ReadUInt16(),
				Models.PackedFile.Swaf.WantType.Sim => item.Version.Item >= SwafItemVersion.Version8 ? reader.ReadUInt16() : (uint)0,
				_ => item.WantType.Item > Models.PackedFile.Swaf.WantType.Sim
							? reader.ReadUInt32()
							: 0
			};

			item.Property = reader.ReadUInt16();
			item.Index = reader.ReadUInt32();
			item.Score = reader.ReadInt32();

			if (item.Version >= SwafItemVersion.Version9)
			{
				item.Influence = reader.ReadInt32();
			}
			item.Locked = reader.ReadBoolean();

			return item;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write((uint)Version.Item);
			writer.Write(SimInstance);
			writer.Write(Guid);
			writer.Write((byte)WantType.Item);

			if (WantType.Item == Models.PackedFile.Swaf.WantType.Skill
				|| (WantType.Item == Models.PackedFile.Swaf.WantType.Sim
					&& Version >= SwafItemVersion.Version8))
			{
				writer.Write((ushort)Value);
			}
			else if (WantType.Item > Models.PackedFile.Swaf.WantType.Sim)
			{
				writer.Write(Value);
			}

			writer.Write(Property);
			writer.Write(Index);
			writer.Write(Score);

			if (Version >= SwafItemVersion.Version9)
			{
				writer.Write(Influence);
			}

			writer.Write(Locked);
		}

		public override string ToString()
		{
			return $"{Type}: {WantType} - 0x{Guid:X8}";
		}
	}
}
