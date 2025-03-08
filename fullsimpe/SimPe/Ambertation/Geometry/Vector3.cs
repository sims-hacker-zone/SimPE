// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

using SimPe.Geometry;
using SimPe;

namespace Ambertation.Geometry
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class Vector3 : Vector2
	{
		protected double z;

		protected double w;

		public double Z
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

		public Vector3 UnitVector
		{
			get
			{
				double length = Length;
				if (length != 0.0)
				{
					return this / length;
				}

				return new Vector3();
			}
		}

		public virtual double Norm => Math.Pow(x, 2.0) + Math.Pow(y, 2.0) + Math.Pow(z, 2.0);

		public double Length => Math.Sqrt(Norm);

		public double this[int index]
		{
			get
			{
				switch (index)
				{
					case 0: return x;
					case 1: return y;
					case 2: return z;
					default: return w;
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						x = value;
						break;
					case 1:
						y = value;
						break;
					case 2:
						z = value;
						break;
				}

				w = value;
			}
		}

		public new static Vector3 Zero => new Vector3(0.0, 0.0, 0.0);

		public static Vector3 NaN => new Vector3(double.NaN, double.NaN, double.NaN);

		public bool IsNaN => double.IsNaN(base.X) || double.IsNaN(base.Y) || double.IsNaN(Z);

		public double GetMaxComponent()
		{
			return Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs(z));
		}

		public void Set(double x, double y, double z)
		{
			base.x = x;
			base.y = y;
			this.z = z;
			w = 1.0;
		}

		public void SetMin(Vector3 v)
		{
			x = Math.Min(v.x, x);
			y = Math.Min(v.y, y);
			z = Math.Min(v.z, z);
		}

		public void SetMax(Vector3 v)
		{
			x = Math.Max(v.x, x);
			y = Math.Max(v.y, y);
			z = Math.Max(v.z, z);
		}

		public Vector3(Matrix m)
			: base(0.0, 0.0)
		{
			if (m.Rows < 3 || m.Rows > 4 || m.Columns != 1)
			{
				throw new GeometryException(m.ToString() + " cannot be converted to a Vector4d!");
			}

			double num = 1.0;
			Set(m[0, 0] / num, m[1, 0] / num, m[2, 0] / num);
		}

		public Vector3()
			: this(0.0, 0.0, 0.0)
		{
		}

		public Vector3(double d)
			: this(d, d, d)
		{
		}

		public Vector3(double x, double y, double z)
			: base(0.0, 0.0)
		{
			Set(x, y, z);
		}

		public override string ToString()
		{
			return base.ToString() + ";" + z;
		}

		public Vector4 ToVector4()
		{
			return ToVector4(1.0);
		}

		public Vector4 ToVector4(double w)
		{
			return new Vector4(base.X, base.Y, Z, w);
		}

		public string ToMaple()
		{
			return "<" + base.X.ToString("N6", CultureInfo.InvariantCulture) + ", " + base.Y.ToString("N6", CultureInfo.InvariantCulture) + ", " + Z.ToString("N6", CultureInfo.InvariantCulture) + ">";
		}

		public string ToMaple(double w)
		{
			return "<" + base.X.ToString("N6", CultureInfo.InvariantCulture) + ", " + base.Y.ToString("N6", CultureInfo.InvariantCulture) + ", " + Z.ToString("N6", CultureInfo.InvariantCulture) + ", " + w.ToString("N6", CultureInfo.InvariantCulture) + ">";
		}

		public void Normalize()
		{
			double length = Length;
			if (length != 0.0)
			{
				base.X /= length;
				base.Y /= length;
				Z /= length;
			}
		}

		public static Vector3 operator !(Vector3 v)
		{
			return v * -1.0;
		}

		public static Vector3 operator +(Vector3 v1, Vector3 v2)
		{
			return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
		}

		public static Vector3 operator -(Vector3 v1, Vector3 v2)
		{
			return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
		}

		public static Vector3 operator *(Vector3 v1, double d)
		{
			return new Vector3(v1.x * d, v1.y * d, v1.z * d);
		}

		public static Vector3 operator *(double d, Vector3 v1)
		{
			return new Vector3(v1.x * d, v1.y * d, v1.z * d);
		}

		public static void SetMatrixCulumn(Matrix m, int col, Vector3 v)
		{
			m[0, col] = v.X;
			m[1, col] = v.Y;
			m[2, col] = v.Z;
			if (m.Rows > 3)
			{
				m[3, col] = 1.0;
			}
		}

		public static void SetMatrixRow(Matrix m, int row, Vector3 v)
		{
			m[row, 0] = v.X;
			m[row, 1] = v.Y;
			m[row, 2] = v.Z;
			if (m.Columns > 3)
			{
				m[row, 3] = 1.0;
			}
		}

		public static explicit operator Matrix(Vector3 v)
		{
			Matrix matrix = new Matrix(4, 1);
			SetMatrixCulumn(matrix, 0, v);
			return matrix;
		}

		public static explicit operator Vector3(Matrix m)
		{
			return new Vector3(m[0, 0], m[1, 0], m[2, 0]);
		}

		public static Vector3 operator /(Vector3 v1, double d)
		{
			return new Vector3(v1.x / d, v1.y / d, v1.z / d);
		}

		public static double operator *(Vector3 v1, Vector3 v2)
		{
			return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
		}

		public Vector3 Transform(Matrix m)
		{
			return (Vector3)(m * (Matrix)this);
		}

		public static Vector3 operator *(Matrix m, Vector3 v)
		{
			return v.Transform(m);
		}

		public static double operator &(Vector3 v1, Vector3 v2)
		{
			return v1 * v2;
		}

		public static Vector3 operator |(Vector3 v1, Vector3 v2)
		{
			return new Vector3(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
		}

		public static bool operator ==(Vector3 v1, Vector3 v2)
		{
			if ((object)v1 == null || (object)v2 == null)
			{
				return (object)v1 == null && (object)v2 == null;
			}

			return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
		}

		public static bool operator !=(Vector3 v1, Vector3 v2)
		{
			if ((object)v1 == null || (object)v2 == null)
			{
				return (object)v1 != null || (object)v2 != null;
			}

			return v1.x != v2.x || v1.y != v2.y || v1.z != v2.z;
		}

		public static implicit operator Point(Vector3 v)
		{
			return new Point((int)v.x, (int)v.y);
		}

		public static double Dot(Vector3 a, Vector3 b)
		{
			return a * b;
		}

		public static Vector3 Cross(Vector3 a, Vector3 b)
		{
			return a | b;
		}

		public static Vector3 Transform(Matrix m, Vector3 v)
		{
			return v.Transform(m);
		}

		public virtual object Clone()
		{
			return new Vector3(x, y, z);
		}

		public override bool Equals(object obj)
		{
			if (obj == null || (object)GetType() != obj.GetType())
			{
				return false;
			}

			Vector3 vector = (Vector3)obj;
			return x == vector.x && y == vector.y && z == vector.z;
		}

		public override int GetHashCode()
		{
			return (((base.X.GetHashCode() % 4095 << 12) | (base.Y.GetHashCode() % 4095)) << 12) | (Z.GetHashCode() % 255);
		}

		public bool IsMultiple(Vector3 v)
		{
			if (this == v)
			{
				return true;
			}

			if (x == 0.0 && v.x != 0.0)
			{
				return false;
			}

			if (y == 0.0 && v.y != 0.0)
			{
				return false;
			}

			if (z == 0.0 && v.z != 0.0)
			{
				return false;
			}

			if (x != 0.0 && v.x == 0.0)
			{
				return false;
			}

			if (y != 0.0 && v.y == 0.0)
			{
				return false;
			}

			if (z != 0.0 && v.z == 0.0)
			{
				return false;
			}

			double num = double.PositiveInfinity;
			if (base.X != 0.0)
			{
				num = v.x / x;
			}

			double num2 = double.PositiveInfinity;
			if (base.Y != 0.0)
			{
				num2 = v.y / y;
			}

			double num3 = double.PositiveInfinity;
			if (Z != 0.0)
			{
				num3 = v.z / z;
			}

			return (num == num2 || double.IsPositiveInfinity(num2) || double.IsPositiveInfinity(num)) && (num2 == num3 || double.IsPositiveInfinity(num2) || double.IsPositiveInfinity(num3)) && (num == num3 || double.IsPositiveInfinity(num) || double.IsPositiveInfinity(num3));
		}

		public Vector3 RadiantsToDegrees()
		{
			return new Vector3(Helpers.RadToDeg(base.X), Helpers.RadToDeg(base.Y), Helpers.RadToDeg(Z));
		}

		public Vector3 DegreesToRadiants()
		{
			return new Vector3(Helpers.DegToRad(base.X), Helpers.DegToRad(base.Y), Helpers.DegToRad(Z));
		}
	}
}
