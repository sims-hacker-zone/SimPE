// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Geometry;

namespace SimPe.PackedFiles.Nhtr
{
	/// <summary>
	/// Summary description for TileItem.
	/// </summary>
	public abstract class NhtrBaseItem : NhtrItem
	{
		protected Vector3f pos;
		protected Vector2f min,
			max;
		protected byte marker2;

		internal NhtrBaseItem(NhtrList parent, byte marker)
			: base(parent)
		{
			marker2 = marker;
			pos = Vector3f.Zero;
			min = Vector2f.Zero;
			max = Vector2f.Zero;
		}

		public Vector3f Position
		{
			get => pos;
			set => pos = value;
		}

		public Vector2f BoundingBoxMinimum
		{
			get => min;
			set => min = value;
		}

		public Vector2f BoundingBoxMaximum
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

			writer.Write((float)pos.Y);
			writer.Write((float)pos.X);
			writer.Write((float)pos.Z);

			writer.Write((float)min.Y);
			writer.Write((float)min.X);

			writer.Write((float)max.Y);
			writer.Write((float)max.X);

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
