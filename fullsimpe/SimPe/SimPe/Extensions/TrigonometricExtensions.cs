// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Numerics;

namespace SimPe.Extensions
{
	public static class TrigonometricExtensions
	{
		// TODO(autinerd): Replace with System.Numeric.DegreesToRadians() when targeting .NET 7+
		public static float DegreesToRadians(this float number)
		{
			return number * (float)Math.PI / 180.0f;
		}

		public static float RadiansToDegrees(this float number)
		{
			return number * 180.0f / (float)Math.PI;
		}

		public static Matrix4x4 RotateYawPitchRoll(float yaw, float pitch, float roll)
		{
			return new Matrix4x4((float)Math.Cos(yaw), 0, (float)Math.Sin(yaw), 0,
								 0, 1, 0, 0,
								 (float)-Math.Sin(yaw), 0, (float)Math.Cos(yaw), 0,
								 0, 0, 0, 1) *
					new Matrix4x4(1, 0, 0, 0,
								  0, (float)Math.Cos(pitch), (float)-Math.Sin(pitch), 0,
								  0, (float)Math.Sin(pitch), (float)Math.Cos(pitch), 0,
								  0, 0, 0, 1) *
					new Matrix4x4((float)Math.Cos(roll), (float)-Math.Sin(roll), 0, 0,
								 (float)Math.Sin(roll), (float)Math.Cos(roll), 0, 0,
								 0, 0, 1, 0,
								 0, 0, 0, 1);
		}

		public static bool IsOrthogonal(this Matrix4x4 matrix)
		{
			return (matrix * Matrix4x4.Transpose(matrix)).IsIdentity;
		}

		public static Vector3 GetAxis(this Quaternion q)
		{
			float s = (float)Math.Sqrt(1 - (q.W * q.W));
			return new Vector3(q.X / s, q.Y / s, q.Z / s);
		}

		public static float GetAngle(this Quaternion q)
		{
			return 2.0f * (float)Math.Acos(q.W);
		}

		/// <summary>
		/// Get the Euler Angles represented by this Quaternion
		/// </summary>
		/// <returns></returns>
		/// X=Pitch
		/// Y=Yaw
		/// Z=Roll
		/// </remarks>
		public static Vector3 GetEulerAnglesZYX(this Quaternion q)
		{
			Vector3 v = new Vector3(0, 0, 0)
			{
				Y = (float)Math.Asin(-(2 * ((q.X * q.Z) - (q.W * q.Y))))
			};
			if (v.Y < Math.PI / 2.0)
			{
				if (v.Y > Math.PI / -2.0)
				{
					v.Z = (float)Math.Atan2(2 * ((q.X * q.Y) + (q.W * q.Z)), 1 - (2 * (Math.Pow(q.Y, 2) + Math.Pow(q.Z, 2))));
					v.X = (float)Math.Atan2(2 * ((q.Y * q.Z) + (q.W * q.X)), 1 - (2 * (Math.Pow(q.X, 2) + Math.Pow(q.Y, 2))));
				}
				else
				{
					v.Z = (float)(-1 * Math.Atan2(-(2 * ((q.X * q.Y) - (q.W * q.Z))), 2 * ((q.X * q.Z) + (q.W * q.Y))));
				}
			}
			else
			{
				v.Z = (float)Math.Atan2(-(2 * ((q.X * q.Y) - (q.W * q.Z))), 2 * ((q.X * q.Z) + (q.W * q.Y)));
			}

			return v;
		}

		public static void Unserialize(this Vector3 v, System.IO.BinaryReader reader)
		{
			v.X = reader.ReadSingle();
			v.Y = reader.ReadSingle();
			v.Z = reader.ReadSingle();
		}

		public static void Serialize(this Vector3 v, System.IO.BinaryWriter writer)
		{
			writer.Write(v.X);
			writer.Write(v.Y);
			writer.Write(v.Z);
		}

		public static void Unserialize(this Vector2 v, System.IO.BinaryReader reader)
		{
			v.X = reader.ReadSingle();
			v.Y = reader.ReadSingle();
		}

		public static void Serialize(this Vector2 v, System.IO.BinaryWriter writer)
		{
			writer.Write(v.X);
			writer.Write(v.Y);
		}

		public static void Unserialize(this Quaternion v, System.IO.BinaryReader reader)
		{
			v.X = reader.ReadSingle();
			v.Y = reader.ReadSingle();
			v.Z = reader.ReadSingle();
			v.W = reader.ReadSingle();
		}

		public static void Unserialize(this Vector4 v, System.IO.BinaryReader reader)
		{
			v.X = reader.ReadSingle();
			v.Y = reader.ReadSingle();
			v.Z = reader.ReadSingle();
			v.W = reader.ReadSingle();
		}

		public static void Serialize(this Vector4 v, System.IO.BinaryWriter writer)
		{
			writer.Write(v.X);
			writer.Write(v.Y);
			writer.Write(v.Z);
			writer.Write(v.W);
		}

		public static void Serialize(this Quaternion v, System.IO.BinaryWriter writer)
		{
			writer.Write(v.X);
			writer.Write(v.Y);
			writer.Write(v.Z);
			writer.Write(v.W);
		}

		public static Vector3 SetComponent(this Vector3 v, byte index, float value)
		{
			switch (index)
			{
				case 0:
					return new Vector3(value, v.Y, v.Z);
				case 1:
					return new Vector3(v.X, value, v.Z);
				case 2:
					return new Vector3(v.X, v.Y, value);
				default:
					return v;
			}
		}

		public static Vector3 ToNumericsVector(this Ambertation.Geometry.Vector3 v)
		{
			return new Vector3((float)v.X, (float)v.Y, (float)v.Z);
		}
	}
}
