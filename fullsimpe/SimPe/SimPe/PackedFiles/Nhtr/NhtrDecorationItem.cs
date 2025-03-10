// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace SimPe.PackedFiles.Nhtr
{
	/// <summary>
	/// Summary description for TileItem.
	/// </summary>
	public class NhtrDecorationItem : NhtrBaseItem
	{
		protected uint guid;
		protected float rot;

		internal NhtrDecorationItem(NhtrList parent)
			: base(parent, 8) { }

		[System.ComponentModel.TypeConverter(
			typeof(Ambertation.NumberBaseTypeConverter)
		)]
		public uint GUID
		{
			get => guid;
			set => guid = value;
		}

		public float Rotation
		{
			get => rot;
			set => rot = value;
		}

		protected override void DoUnserialize(System.IO.BinaryReader reader)
		{
			guid = reader.ReadUInt32();
			rot = reader.ReadSingle();
		}

		protected override void DoSerialize(System.IO.BinaryWriter writer)
		{
			writer.Write(guid);
			writer.Write(rot);
		}

		public override string ToLongString()
		{
			string s = "";
			s += "Marker: " + Helper.HexString(marker) + Helper.lbr;
			s += "Marker 2: " + Helper.HexString(marker2) + Helper.lbr;
			s += "GUID: " + Helper.HexString(guid) + Helper.lbr;
			s += "Rotation: " + rot + Helper.lbr;
			s += "Position: " + pos.ToString() + Helper.lbr;
			s += "BoundingBox: " + min.ToString() + " / " + max.ToString() + Helper.lbr;
			return s;
		}

		public override string ToString()
		{
			string s = Helper.HexString(marker) + "   ";
			s += Helper.HexString(marker2) + "   ";
			s += Helper.HexString(GUID) + "   ";
			s += rot + "   ";
			s += pos.ToString() + "   ";
			s += min.ToString() + "   ";
			s += max.ToString() + "   ";

			if (s.Length > 0xff)
			{
				s = s.Substring(0, 0xff) + "...";
			}

			return s;
		}
	}
}
