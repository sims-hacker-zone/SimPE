/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;

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
			get
			{
				return s;
			}
			set
			{
				s = value;
				if (s == ElementSorting.XZY || s == ElementSorting.Preview)
				{
					Geometry.Matrixd mt =
						Geometry.Matrixd.RotateYawPitchRoll(
							Math.PI,
							-Math.PI / 2,
							0
						);
					TransformMatrix = mt.To33Matrix();

					mt = Geometry.Matrixd.RotateYawPitchRoll(
						Math.PI,
						-Math.PI / 2,
						0
					);
					mi = mt.To33Matrix();
				}
				else
				{
					TransformMatrix = Geometry.Matrixd.GetIdentity(3, 3);
					mi = Geometry.Matrixd.GetIdentity(3, 3);
				}

				ScaleMatrix =
					Geometry.Matrixd.Scale(
						Helper.WindowsRegistry.ImportExportScaleFactor
					)
					.To33Matrix();
				msi =
					Geometry.Matrixd.Scale(
						1.0 / Helper.WindowsRegistry.ImportExportScaleFactor
					)
					.To33Matrix();

				if (TransformMatrix.Orthogonal)
				{
					mn = TransformMatrix;
					mni = mn.GetTranspose();
				}
				else
				{
					mn = mi.GetTranspose();
					mni = !mn;
				}
			}
		}

		Geometry.Matrixd mn,
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

		public Geometry.Matrixd TransformMatrix
		{
			get; private set;
		}

		public Geometry.Matrixd ScaleMatrix
		{
			get; private set;
		}

		public Geometry.Quaternion TransformRotation(Geometry.Quaternion q)
		{
			Geometry.Vector3f r = q.Axis;
			r = Transform(r);
			q = Geometry.Quaternion.FromAxisAngle(r, q.Angle);

			return q;
		}

		public Geometry.Quaternion InverseTransformRotation(
			Geometry.Quaternion q
		)
		{
			Geometry.Vector3f r = q.Axis;
			r = InverseTransform(r);
			q = Geometry.Quaternion.FromAxisAngle(r, q.Angle);

			return q;
		}

		/// <summary>
		/// Transform the passed vector to fit into the specified Coordinate System
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Geometry.Vector3f Transform(Geometry.Vector3f v)
		{
			return TransformMatrix * v;
		}

		/// <summary>
		/// the inveres to <see cref="Transform"/>
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Geometry.Vector3f InverseTransform(Geometry.Vector3f v)
		{
			return mi * v;
		}

		/// <summary>
		/// Transform the passed normalvector to fit into the specified Coordinate System
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Geometry.Vector3f TransformNormal(Geometry.Vector3f v)
		{
			return mn * v;
		}

		/// <summary>
		/// the inveres to <see cref="TransformNormal"/>
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Geometry.Vector3f InverseTransformNormal(Geometry.Vector3f v)
		{
			return mni * v;
		}

		/// <summary>
		/// Transform the passed vector to fit into the specified Coordinate System and Scale
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Geometry.Vector3f TransformScaled(Geometry.Vector3f v)
		{
			return (TransformMatrix * ScaleMatrix) * v;
		}

		/// <summary>
		/// the inveres to <see cref="TransformScaled"/>
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Geometry.Vector3f InverseTransformScaled(Geometry.Vector3f v)
		{
			return !(TransformMatrix * ScaleMatrix) * v;
		}

		/// <summary>
		/// Scale the passed Vector
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Geometry.Vector3f Scale(Geometry.Vector3f v)
		{
			return ScaleMatrix * v;
		}

		/// <summary>
		/// the inveres to <see cref="Scale"/>
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public Geometry.Vector3f InverseScale(Geometry.Vector3f v)
		{
			return msi * v;
		}
	}
}
