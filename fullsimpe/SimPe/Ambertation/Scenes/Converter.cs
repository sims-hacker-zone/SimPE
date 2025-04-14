// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using Ambertation.Geometry;
using Microsoft.DirectX;

namespace Ambertation.Scenes
{
	public class Converter
	{
		public static Microsoft.DirectX.Vector2 ToDx(Ambertation.Geometry.Vector2 v)
		{
			return new Microsoft.DirectX.Vector2((float)v.X, (float)v.Y);
		}

		public static Microsoft.DirectX.Vector3 ToDx(Ambertation.Geometry.Vector3 v)
		{
			return new Microsoft.DirectX.Vector3((float)v.X, (float)v.Y, (float)v.Z);
		}

		public static Microsoft.DirectX.Vector4 ToDx(Ambertation.Geometry.Vector4 v)
		{
			return new Microsoft.DirectX.Vector4((float)v.X, (float)v.Y, (float)v.Z, (float)v.W);
		}

		public static Microsoft.DirectX.Matrix ToDx(Transformation t)
		{
			return Microsoft.DirectX.Matrix.Multiply(Microsoft.DirectX.Matrix.Scaling(ToDx(t.Scaling)), Microsoft.DirectX.Matrix.Multiply(Microsoft.DirectX.Matrix.RotationX((float)t.Rotation.X), Microsoft.DirectX.Matrix.Multiply(Microsoft.DirectX.Matrix.RotationY((float)t.Rotation.Y), Microsoft.DirectX.Matrix.Multiply(Microsoft.DirectX.Matrix.RotationZ((float)t.Rotation.Z), Microsoft.DirectX.Matrix.Translation(ToDx(t.Translation))))));
		}

		public static Ambertation.Geometry.Matrix FromDx(Microsoft.DirectX.Matrix m)
		{
			Ambertation.Geometry.Matrix matrix = new Ambertation.Geometry.Matrix(4, 4);
			matrix[0, 0] = m.M11;
			matrix[0, 1] = m.M21;
			matrix[0, 2] = m.M31;
			matrix[0, 3] = m.M41;
			matrix[1, 0] = m.M12;
			matrix[1, 1] = m.M22;
			matrix[1, 2] = m.M32;
			matrix[1, 3] = m.M42;
			matrix[2, 0] = m.M13;
			matrix[2, 1] = m.M23;
			matrix[2, 2] = m.M33;
			matrix[2, 3] = m.M43;
			matrix[3, 0] = m.M14;
			matrix[3, 1] = m.M24;
			matrix[3, 2] = m.M34;
			matrix[3, 3] = m.M44;
			return matrix;
		}

		public static Microsoft.DirectX.Matrix ToDx(Ambertation.Geometry.Matrix t)
		{
			Microsoft.DirectX.Matrix result = new Microsoft.DirectX.Matrix();
			result.M11 = (float)t[0, 0];
			result.M21 = (float)t[0, 1];
			result.M31 = (float)t[0, 2];
			result.M41 = (float)t[0, 3];
			result.M12 = (float)t[1, 0];
			result.M22 = (float)t[1, 1];
			result.M32 = (float)t[1, 2];
			result.M42 = (float)t[1, 3];
			result.M13 = (float)t[2, 0];
			result.M23 = (float)t[2, 1];
			result.M33 = (float)t[2, 2];
			result.M43 = (float)t[2, 3];
			result.M14 = (float)t[3, 0];
			result.M24 = (float)t[3, 1];
			result.M34 = (float)t[3, 2];
			result.M44 = (float)t[3, 3];
			return result;
		}
	}
}
