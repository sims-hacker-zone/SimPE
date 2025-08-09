// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Resource.Scor;

public partial class ScorBestFriendForeverItem(Scor parent) : ObservableObject
{
	[ObservableProperty] private Scor parent = parent;

	[ObservableProperty] private uint unknown00;

	[ObservableProperty] private uint unknown01;

	[ObservableProperty] private uint unknown02;

	[ObservableProperty] private float unknown03;

	[ObservableProperty] private uint unknown04;

	[ObservableProperty] private float unknown05;

	public static ScorBestFriendForeverItem Unserialize(BinaryReader reader, Scor parent)
	{
		ScorBestFriendForeverItem item = new(parent);
		reader.ReadByte();
		item.Unknown00 = reader.ReadUInt32();
		reader.ReadByte();
		item.Unknown01 = reader.ReadUInt32();
		reader.ReadByte();
		item.Unknown02 = reader.ReadUInt32();
		reader.ReadByte();
		item.Unknown03 = reader.ReadSingle();
		reader.ReadByte();
		item.Unknown04 = reader.ReadUInt32();
		reader.ReadByte();
		item.Unknown05 = reader.ReadSingle();
		return item;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write((byte)1);
		writer.Write(Unknown00);
		writer.Write((byte)5);
		writer.Write(Unknown01);
		writer.Write((byte)1);
		writer.Write(Unknown02);
		writer.Write((byte)0);
		writer.Write(Unknown03);
		writer.Write((byte)1);
		writer.Write(Unknown04);
		writer.Write((byte)0);
		writer.Write(Unknown05);
	}

	public override string ToString()
	{
		return $"{Unknown00}: {Unknown01} - {Unknown02} - {Unknown03} - {Unknown04} - {Unknown05}";
	}
}
