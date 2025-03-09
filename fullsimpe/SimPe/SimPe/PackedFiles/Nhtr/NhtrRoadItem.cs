// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.PackedFiles.Nhtr
{
	/// <summary>
	/// Summary description for TileItem.
	/// </summary>
	public class NhtrRoadItem : NhtrBaseItem
	{
		internal NhtrRoadItem(NhtrList parent)
			: base(parent, 3)
		{
			TopLeft = new NhtrLocation();
			TopRight = new NhtrLocation();
			BottomLeft = new NhtrLocation();
			BottomRight = new NhtrLocation();
			Texture = 0x00000300;

			Data = new byte[10];
		}

		[System.ComponentModel.Category("Placement")]
		public NhtrLocation TopLeft
		{
			get; set;
		}

		[System.ComponentModel.Category("Placement")]
		public NhtrLocation TopRight
		{
			get; set;
		}

		[System.ComponentModel.Category("Placement")]
		public NhtrLocation BottomLeft
		{
			get; set;
		}

		[System.ComponentModel.Category("Placement")]
		public NhtrLocation BottomRight
		{
			get; set;
		}

		[System.ComponentModel.TypeConverter(
			typeof(Ambertation.NumberBaseTypeConverter)
		)]
		public uint Texture
		{
			get; set;
		}

		public byte[] Data
		{
			get; private set;
		}

		protected override void DoUnserialize(System.IO.BinaryReader reader)
		{
			TopLeft.Unserialize(reader);
			TopRight.Unserialize(reader);
			BottomLeft.Unserialize(reader);
			BottomRight.Unserialize(reader);

			Texture = reader.ReadUInt32();
			Data = reader.ReadBytes(Data.Length);
			//reader.ReadByte();
		}

		protected override void DoSerialize(System.IO.BinaryWriter writer)
		{
			TopLeft.Serialize(writer);
			TopRight.Serialize(writer);
			BottomLeft.Serialize(writer);
			BottomRight.Serialize(writer);

			writer.Write(Texture);
			writer.Write(Data);
		}

		public override string ToLongString()
		{
			string s = "";
			s += "Marker: " + Helper.HexString(marker) + Helper.lbr;
			s += "Marker 2: " + Helper.HexString(marker2) + Helper.lbr;
			s += "Position: " + pos.ToString() + Helper.lbr;
			s += "BoundingBox: " + min.ToString() + " / " + max.ToString() + Helper.lbr;
			s += "Top-Left: " + TopLeft.ToString() + Helper.lbr;
			s += "Top-Right: " + TopRight.ToString() + Helper.lbr;
			s += "Bottom-Left: " + BottomLeft.ToString() + Helper.lbr;
			s += "Bottom-Right: " + BottomRight.ToString() + Helper.lbr;
			s += "Texture: " + Helper.HexString(Texture) + Helper.lbr;
			s += Helper.BytesToHexList(Data, 4);
			return s;
		}

		public override string ToString()
		{
			string s = Helper.HexString(marker) + "   ";
			s += Helper.HexString(marker2) + "   ";
			s += Helper.HexString(Texture) + "   ";
			s += Helper.BytesToHexList(Data);
			s += pos.ToString() + "   ";
			s += min.ToString() + "   ";
			s += max.ToString() + "   ";
			s += TopLeft.ToString() + "   ";
			s += TopRight.ToString() + "   ";
			s += BottomLeft.ToString() + "   ";
			s += BottomRight.ToString() + "   ";

			if (s.Length > 0xff)
			{
				s = s.Substring(0, 0xff) + "...";
			}

			return s;
		}
	}
}
