// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using System.Text;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Models.PackedFile.Scor
{
	public partial class ScorWitchName(Scor parent) : ObservableObject
	{
		[ObservableProperty]
		private Scor parent = parent;

		[ObservableProperty]
		private uint id;

		[ObservableProperty]
		private string name;

		public static ScorWitchName Unserialize(BinaryReader reader, Scor parent)
		{
			ScorWitchName item = new(parent);
			reader.ReadByte();
			item.Id = reader.ReadUInt32();
			reader.ReadByte();
			int nameLength = reader.ReadInt32();
			item.Name = Encoding.UTF8.GetString(reader.ReadBytes(nameLength));
			return item;
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write((byte)1);
			writer.Write(Id);
			writer.Write((byte)4);
			writer.Write(Encoding.UTF8.GetByteCount(Name));
			writer.Write(Encoding.UTF8.GetBytes(Name));
		}

		public override string ToString()
		{
			return $"{Id}: {Name}";
		}
	}
}
