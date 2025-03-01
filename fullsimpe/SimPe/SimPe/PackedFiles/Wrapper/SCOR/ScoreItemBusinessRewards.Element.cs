// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.PackedFiles.Wrapper.SCOR
{
	partial class ScoreItemBusinessRewards
	{
		public class Element
		{
			public Element()
			{
				Name = "";
				Data = BitConverter.GetBytes(0x00000103);
			}

			public string Name
			{
				get; set;
			}

			internal byte[] Data
			{
				get; private set;
			}

			public void LoadData(System.IO.BinaryReader reader)
			{
				Name = StreamHelper.ReadString(reader);
				Data = ScorItem.UnserializeDefaultToken(reader);
			}

			public void SaveData(System.IO.BinaryWriter writer, bool last)
			{
				StreamHelper.WriteString(writer, Name);
				writer.Write(Data);
				ScorItem.SerializeDefaultToken(writer, last);
			}

			public override string ToString()
			{
				string s = Name + ": " + Helper.BytesToHexList(Data);
				return s;
			}
		}
	}
}
