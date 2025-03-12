// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later


// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Numerics;

namespace SimPe.PackedFiles.Nhtr
{
	/// <summary>
	/// Summary description for NhtrLocation.
	/// </summary>
	[System.ComponentModel.TypeConverter(
		typeof(System.ComponentModel.ExpandableObjectConverter)
	)]
	public class NhtrLocation
	{
		public NhtrLocation()
		{
		}

		public Vector3 Position
		{
			get; set;
		} = Vector3.Zero;

		public float Orientation1
		{
			get; set;
		}

		public float Orientation2
		{
			get; set;
		}

		internal void Unserialize(System.IO.BinaryReader reader)
		{
			Position = new Vector3
			{
				Y = reader.ReadSingle(),
				X = reader.ReadSingle(),
				Z = reader.ReadSingle()
			};
			Orientation1 = reader.ReadSingle();
			Orientation2 = reader.ReadSingle();
		}

		internal void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(Position.Y);
			writer.Write(Position.X);
			writer.Write(Position.Z);

			writer.Write(Orientation1);
			writer.Write(Orientation2);
		}

		public override string ToString()
		{
			return Position.ToString() + " [" + Orientation1.ToString() + ", " + Orientation1.ToString() + "]";
		}
	}
}
