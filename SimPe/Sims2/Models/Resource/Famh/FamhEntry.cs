// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Resource.Famh;

public partial class FamhEntry(Famh parent) : ObservableObject
{
	[ObservableProperty] private Famh parent = parent;

	[ObservableProperty] private ushort lotInstance;

	[ObservableProperty] private ushort familyMembers;
	[ObservableProperty] private ushort maleAdults;
	[ObservableProperty] private ushort femaleAdults;
	[ObservableProperty] private ushort maleChildren;
	[ObservableProperty] private ushort femaleChildren;
	[ObservableProperty] private ushort unknown00;
	[ObservableProperty] private ushort unknown01;
	[ObservableProperty] private ushort unknown02;
	[ObservableProperty] private ushort unknown03;
	[ObservableProperty] private ushort unknown04;
	[ObservableProperty] private ushort unknown05;
	[ObservableProperty] private ushort unknown06;
	[ObservableProperty] private ushort unknown07;
	[ObservableProperty] private ushort unknown08;
	[ObservableProperty] private ushort unknown09;
	[ObservableProperty] private ushort unknown10;
	[ObservableProperty] private ushort unknown11;
	[ObservableProperty] private ushort unknown12;
	[ObservableProperty] private ushort unknown13;
	[ObservableProperty] private ushort unknown14;
	[ObservableProperty] private ushort unknown15;
	[ObservableProperty] private ushort unknown16;
	[ObservableProperty] private ushort unknown17;
	[ObservableProperty] private ushort unknown18;
	[ObservableProperty] private ushort unknown19;
	[ObservableProperty] private ushort unknown20;
	[ObservableProperty] private int unknown21;
	[ObservableProperty] private int unknown22;
	[ObservableProperty] private ushort unknown23;
	[ObservableProperty] private ushort unknown24;
	[ObservableProperty] private uint money;
	[ObservableProperty] private ushort familyFriends;
	[ObservableProperty] private short unknown25;
	[ObservableProperty] private short unknown26;
	[ObservableProperty] private bool unknown27;
	[ObservableProperty] private short unknown28;
	[ObservableProperty] private ObservableCollection<string> texts = [];

	public static FamhEntry Unserialize(BinaryReader reader, Famh parent)
	{
		FamhEntry entry = new(parent)
		{
			LotInstance = reader.ReadUInt16(),
			FamilyMembers = reader.ReadUInt16(),
			MaleAdults = reader.ReadUInt16(),
			FemaleAdults = reader.ReadUInt16(),
			MaleChildren = reader.ReadUInt16(),
			FemaleChildren = reader.ReadUInt16(),
			Unknown00 = reader.ReadUInt16(),
			Unknown01 = reader.ReadUInt16(),
			Unknown02 = reader.ReadUInt16(),
			Unknown03 = reader.ReadUInt16(),
			Unknown04 = reader.ReadUInt16(),
			Unknown05 = reader.ReadUInt16(),
			Unknown06 = reader.ReadUInt16(),
			Unknown07 = reader.ReadUInt16(),
			Unknown08 = reader.ReadUInt16(),
			Unknown09 = reader.ReadUInt16(),
			Unknown10 = reader.ReadUInt16(),
			Unknown11 = reader.ReadUInt16(),
			Unknown12 = reader.ReadUInt16(),
			Unknown13 = reader.ReadUInt16(),
			Unknown14 = reader.ReadUInt16(),
			Unknown15 = reader.ReadUInt16(),
			Unknown16 = reader.ReadUInt16(),
			Unknown17 = reader.ReadUInt16(),
			Unknown18 = reader.ReadUInt16(),
			Unknown19 = reader.ReadUInt16(),
			Unknown20 = reader.ReadUInt16(),
			Unknown21 = reader.ReadInt32(),
			Unknown22 = reader.ReadInt32(),
			Unknown23 = reader.ReadUInt16(),
			Unknown24 = reader.ReadUInt16(),
			Money = reader.ReadUInt32(),
			FamilyFriends = reader.ReadUInt16(),
			Unknown25 = reader.ReadInt16(),
			Unknown26 = reader.ReadInt16(),
			Unknown27 = reader.ReadBoolean(),
			Unknown28 = reader.ReadInt16()
		};
		uint textCount = reader.ReadUInt32();
		for (int i = 0; i < textCount; i++)
		{
			int textLength = reader.ReadInt32();
			entry.Texts.Add(Encoding.UTF8.GetString(reader.ReadBytes(textLength)));
		}

		return entry;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(LotInstance);
		writer.Write(FamilyMembers);
		writer.Write(MaleAdults);
		writer.Write(FemaleAdults);
		writer.Write(MaleChildren);
		writer.Write(FemaleChildren);
		writer.Write(Unknown00);
		writer.Write(Unknown01);
		writer.Write(Unknown02);
		writer.Write(Unknown03);
		writer.Write(Unknown04);
		writer.Write(Unknown05);
		writer.Write(Unknown06);
		writer.Write(Unknown07);
		writer.Write(Unknown08);
		writer.Write(Unknown09);
		writer.Write(Unknown10);
		writer.Write(Unknown11);
		writer.Write(Unknown12);
		writer.Write(Unknown13);
		writer.Write(Unknown14);
		writer.Write(Unknown15);
		writer.Write(Unknown16);
		writer.Write(Unknown17);
		writer.Write(Unknown18);
		writer.Write(Unknown19);
		writer.Write(Unknown20);
		writer.Write(Unknown21);
		writer.Write(Unknown22);
		writer.Write(Unknown23);
		writer.Write(Unknown24);
		writer.Write(Money);
		writer.Write(FamilyFriends);
		writer.Write(Unknown25);
		writer.Write(Unknown26);
		writer.Write(Unknown27);
		writer.Write(Unknown28);
		writer.Write(Texts.Count);
		foreach (string item in Texts)
		{
			writer.Write(Encoding.UTF8.GetByteCount(item));
			writer.Write(Encoding.UTF8.GetBytes(item));
		}
	}
}
