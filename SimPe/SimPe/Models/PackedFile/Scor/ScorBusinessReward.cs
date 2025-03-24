// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Text;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.PackedFile.Scor
{
	public partial class ScorBusinessReward(Scor parent) : ObservableObject
	{
		[ObservableProperty]
		private Scor parent = parent;
		[ObservableProperty]
		private string type;

		[ObservableProperty]
		private byte valueType;

		[ObservableProperty]
		private uint value;

		public static ScorBusinessReward Unserialize(BinaryReader reader, Scor parent)
		{
			ScorBusinessReward reward = new(parent);
			reader.ReadByte();
			int typeNameLen = reader.ReadInt32();
			reward.Type = Encoding.UTF8.GetString(reader.ReadBytes(typeNameLen));
			reward.ValueType = reader.ReadByte();
			reward.Value = reward.ValueType == 0 ? (uint)reader.ReadSingle() : reader.ReadUInt32();
			return reward;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write((byte)4);
			writer.Write(Encoding.UTF8.GetByteCount(Type));
			writer.Write(Encoding.UTF8.GetBytes(Type));
			if (ValueType == 0)
			{
				writer.Write(0);
				writer.Write((float)Value);
			}
			else
			{
				writer.Write(ValueType);
				writer.Write(Value);
			}
		}

		public override string ToString()
		{
			return $"{Type}: {Value}";
		}
	}
}
