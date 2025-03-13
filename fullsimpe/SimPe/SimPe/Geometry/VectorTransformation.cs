// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Numerics;

using SimPe.Extensions;

namespace SimPe.Geometry
{
	/// <summary>
	/// One basic Vector Transformation
	/// </summary>
	public class VectorTransformation
	{
		public const double SMALL_NUMBER = 0.000001;

		/// <summary>
		/// What Order should the Transformation be applied
		/// </summary>
		public enum TransformOrder : byte
		{
			/// <summary>
			/// Rotate then Translate
			/// </summary>
			RotateTranslate = 0,

			/// <summary>
			/// Translate then Rotate (rigid Body)
			/// </summary>
			TranslateRotate = 1,
		};

		#region Attributes

		/// <summary>
		/// Returns / Sets the current Order
		/// </summary>
		public TransformOrder Order
		{
			get; set;
		}

		/// <summary>
		/// The Translation
		/// </summary>
		public Vector3 Translation
		{
			get; set;
		} = new Vector3();

		/// <summary>
		/// The Rotation
		/// </summary>
		public Quaternion Rotation
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="o">The order of the Transform</param>
		public VectorTransformation(TransformOrder o)
		{
			Order = o;
			Rotation = Quaternion.Identity;
		}

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <remarks>Order is implicit set to <see cref="TransformOrder.TranslateRotate"/></remarks>
		public VectorTransformation()
			: this(TransformOrder.TranslateRotate) { }

		public override string ToString()
		{
			return "trans=" + Translation.ToString() + "    rot=" + Rotation.ToString();
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public virtual void Unserialize(System.IO.BinaryReader reader)
		{
			if (Order == TransformOrder.RotateTranslate)
			{
				Rotation.Unserialize(reader);
				Translation.Unserialize(reader);
			}
			else
			{
				Translation.Unserialize(reader);
				Rotation.Unserialize(reader);
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public virtual void Serialize(System.IO.BinaryWriter writer)
		{
			if (Order == TransformOrder.RotateTranslate)
			{
				Rotation.Serialize(writer);
				Translation.Serialize(writer);
			}
			else
			{
				Translation.Serialize(writer);
				Rotation.Serialize(writer);
			}
		}

		/// <summary>
		/// Applies the Transformation to the passed Vertex
		/// </summary>
		/// <param name="v">The Vertex you want to Transform</param>
		/// <returns>Transformed Vertex</returns>
		public Vector3 Transform(Vector3 v)
		{
			if (Order == TransformOrder.RotateTranslate)
			{
				v = Vector3.Transform(v, Rotation);
				return v + Translation;
			}
			else
			{
				v += Translation;
				return Vector3.Transform(v, Rotation);
			}
		}

		/// <summary>
		/// Create a Clone of this Transformation Set
		/// </summary>
		/// <returns></returns>
		public VectorTransformation Clone()
		{
			return new VectorTransformation(Order)
			{
				Rotation = Rotation,
				Translation = Translation
			};
		}

#if DEBUG
		public string Name
		{
			get; set;
		}
#endif
	}
}
