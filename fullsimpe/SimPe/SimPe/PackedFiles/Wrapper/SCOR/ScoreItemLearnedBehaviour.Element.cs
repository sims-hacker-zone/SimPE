using System;
using System.Collections.Generic;
using System.Text;

namespace SimPe.PackedFiles.Wrapper.SCOR
{
	partial class ScoreItemLearnedBehaviour
	{
		class Element
		{
			public Element()
			{
				Unknown1 = 1;
				Unknown3 = 1;
			}

			public byte Unknown1
			{
				get; set;
			}

			public uint Guid
			{
				get; set;
			}

			public uint Value
			{
				get; set;
			}
			public byte Unknown3
			{
				get; set;
			}

			public void LoadData(System.IO.BinaryReader reader)
			{
				Unknown1 = reader.ReadByte();
				Guid = reader.ReadUInt32();

				Unknown3 = reader.ReadByte();
				Value = reader.ReadUInt32();
			}

			public void SaveData(System.IO.BinaryWriter writer)
			{
				writer.Write(Unknown1);
				writer.Write(Guid);
				writer.Write(Unknown3);
				writer.Write(Value);
			}

			public override string ToString()
			{
				string s = "0x" + Helper.HexString(Guid);
				;
				foreach (ExtObjd objd in LearnedBahaviourComboBox.BehaviourObjds)
					if (objd.Guid == Guid)
						s = objd.FileName;
				s +=
					"("
					+ Helper.HexString(Unknown1)
					+ " "
					+ Helper.HexString(Value)
					+ " "
					+ Helper.HexString(Unknown3)
					+ ")";
				return s;
			}
		}
	}
}
