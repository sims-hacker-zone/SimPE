// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Drawing.Drawing2D;
using System.Numerics;

using SimPe.Extensions;

namespace SimPe.Plugin.Gmdc
{
	/// <summary>
	/// Describes the Order how Vectors should be Exported/read from a 3d-File
	/// </summary>
	public enum ElementSorting : byte
	{
		/// <summary>
		/// Normal X, Y, Z Order
		/// </summary>
		XYZ = 0,

		/// <summary>
		/// Flipped Depth with width (X, Z, Y)
		/// </summary>
		XZY = 1,

		/// <summary>
		/// Used when you want to display a Preview
		/// </summary>
		Preview,
	}

	/// <summary>
	/// Helper Class that is used to determin the Element Order
	/// </summary>
	public class ElementOrder
	{
		ElementSorting s;

		/// <summary>
		/// Returns/Sets the Sorting that should be Used
		/// </summary>
		public ElementSorting Sorting
		{
			get => s;
			set
			{
				s = value;
				if (s == ElementSorting.XZY || s == ElementSorting.Preview)
				{
					TransformMatrix = TrigonometricExtensions.RotateYawPitchRoll((float)Math.PI, (float)(-Math.PI / 2), 0);
					mi = TrigonometricExtensions.RotateYawPitchRoll((float)Math.PI, (float)(-Math.PI / 2), 0);
				}
				else
				{
					TransformMatrix = Matrix4x4.Identity;
					mi = Matrix4x4.Identity;
				}

				ScaleMatrix = Matrix4x4.CreateScale(Helper.WindowsRegistry.Config.ImportExportScaleFactor);
				msi = Matrix4x4.CreateScale(1.0f / Helper.WindowsRegistry.Config.ImportExportScaleFactor);

				if (TransformMatrix.IsOrthogonal())
				{
					mn = TransformMatrix;
					mni = Matrix4x4.Transpose(mn);
				}
				else
				{
					mn = Matrix4x4.Transpose(mi);
					Matrix4x4.Invert(mn, out mni);
				}
			}
		}

		Matrix4x4 mn,
			mi,
			mni, msi;

		/// <summary>
		/// Create a new Class with the given Sorting
		/// </summary>
		/// <param name="sorting">the sorting that should be used</param>
		public ElementOrder(ElementSorting sorting)
		{
			Sorting = sorting;
		}

		public Matrix4x4 TransformMatrix
		{
			get; private set;
		}

		public Matrix4x4 ScaleMatrix
		{
			get; private set;
		}

		public Quaternion TransformRotation(Quaternion q)
		{
			return Quaternion.CreateFromAxisAngle(Transform(q.GetAxis()), q.GetAngle());
		}

		public Quaternion InverseTransformRotation(Quaternion q)
		{
			return Quaternion.CreateFromAxisAngle(InverseTransform(q.GetAxis()), q.GetAngle());
		}

		/// <summary>
		/// Transform the passed vector to fit into the specified Coordinate System
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Vector3 Transform(Vector3 v)
		{
			return Vector3.Transform(v, TransformMatrix);
		}

		/// <summary>
		/// the inveres to <see cref="Transform"/>
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Vector3 InverseTransform(Vector3 v)
		{
			return Vector3.Transform(v, mi);
		}

		/// <summary>
		/// Transform the passed normalvector to fit into the specified Coordinate System
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Vector3 TransformNormal(Vector3 v)
		{
			return Vector3.Transform(v, mn);
		}

		/// <summary>
		/// the inveres to <see cref="TransformNormal"/>
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Vector3 InverseTransformNormal(Vector3 v)
		{
			return Vector3.Transform(v, mni);
		}

		/// <summary>
		/// Transform the passed vector to fit into the specified Coordinate System and Scale
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Vector3 TransformScaled(Vector3 v)
		{
			return Vector3.Transform(v, TransformMatrix * ScaleMatrix);
		}

		/// <summary>
		/// the inveres to <see cref="TransformScaled"/>
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Vector3 InverseTransformScaled(Vector3 v)
		{
			Matrix4x4.Invert((TransformMatrix * ScaleMatrix), out Matrix4x4 result);
			return Vector3.Transform(v, result);
		}

		/// <summary>
		/// Scale the passed Vector
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Vector3 Scale(Vector3 v)
		{
			return Vector3.Transform(v, ScaleMatrix);
		}

		/// <summary>
		/// the inveres to <see cref="Scale"/>
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Vector3 InverseScale(Vector3 v)
		{
			return Vector3.Transform(v, msi);
		}
	}
}
