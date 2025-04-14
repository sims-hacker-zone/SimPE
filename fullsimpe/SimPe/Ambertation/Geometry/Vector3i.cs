// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.ComponentModel;

namespace Ambertation.Geometry
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Vector3i
	{
		private int x;

		private int y;

		private int z;

		public static Vector3i Zero => new Vector3i(0, 0, 0);

		public int X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public int Z
		{
			get
			{
				return z;
			}
			set
			{
				z = value;
			}
		}

		public int this[int index]
		{
			get
			{
				switch (index)
				{
					case 0: return X;
					case 1: return Y;
					default: return Z;
				}
			}
			set
			{
				if (index == 0)
				{
					X = value;
				}

				if (index == 1)
				{
					Y = value;
				}

				Z = value;
			}
		}

		public Vector3i(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public override string ToString()
		{
			return x + ";" + y + ";" + z;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3i)
			{
				Vector3i vector3i = obj as Vector3i;
				return vector3i.X == X && vector3i.Y == Y && vector3i.Z == Z;
			}

			return base.Equals(obj);
		}
	}
}
