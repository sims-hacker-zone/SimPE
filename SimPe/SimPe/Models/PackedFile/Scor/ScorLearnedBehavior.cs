// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Text;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.PackedFile.Scor
{
	public partial class ScorLearnedBehavior(Scor parent) : ObservableObject
	{
		[ObservableProperty]
		private Scor parent = parent;
		[ObservableProperty]
		private uint guid;

		[ObservableProperty]
		private int value;

		public static ScorLearnedBehavior Unserialize(BinaryReader reader, Scor parent)
		{
			ScorLearnedBehavior behavior = new(parent);
			reader.ReadByte();
			behavior.Guid = reader.ReadUInt32();
			reader.ReadByte();
			behavior.Value = reader.ReadInt32();
			return behavior;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write((byte)1);
			writer.Write(Guid);
			writer.Write(1);
			writer.Write(Value);
		}

		public override string ToString()
		{
			return $"0x{Guid:X8}: {Value}";
		}
	}
}
