// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Numerics;

namespace SimPe.PackedFiles.Nhtr
{
	/// <summary>
	/// Summary description for TileItem.
	/// </summary>
	public abstract class NhtrBaseItem : NhtrItem
	{
		protected Vector3 pos;
		protected Vector2 min,
			max;
		protected byte marker2;

		internal NhtrBaseItem(NhtrList parent, byte marker)
			: base(parent)
		{
			marker2 = marker;
			pos = Vector3.Zero;
			min = Vector2.Zero;
			max = Vector2.Zero;
		}

		public Vector3 Position
		{
			get => pos;
			set => pos = value;
		}

		public Vector2 BoundingBoxMinimum
		{
			get => min;
			set => min = value;
		}

		public Vector2 BoundingBoxMaximum
		{
			get => max;
			set => max = value;
		}

		public byte Marker2 => marker2;

		protected abstract void DoUnserialize(System.IO.BinaryReader reader);
		protected abstract void DoSerialize(System.IO.BinaryWriter writer);

		internal override void Unserialize(System.IO.BinaryReader reader)
		{
			base.Unserialize(reader);
			pos.Y = reader.ReadSingle();
			pos.X = reader.ReadSingle();
			pos.Z = reader.ReadSingle();

			min.Y = reader.ReadSingle();
			min.X = reader.ReadSingle();

			max.Y = reader.ReadSingle();
			max.X = reader.ReadSingle();

			marker2 = reader.ReadByte();

			DoUnserialize(reader);
		}

		internal override void Serialize(System.IO.BinaryWriter writer)
		{
			base.Serialize(writer);

			writer.Write(pos.Y);
			writer.Write(pos.X);
			writer.Write(pos.Z);

			writer.Write(min.Y);
			writer.Write(min.X);

			writer.Write(max.Y);
			writer.Write(max.X);

			writer.Write(marker2);

			DoSerialize(writer);
		}

		public override string ToString()
		{
			string s = Helper.HexString(marker) + "   ";
			s += Helper.HexString(marker2) + "   ";
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
