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
using System.Collections;

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
		public Vector3f Translation
		{
			get; set;
		}

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
			Translation = new Vector3f();
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
		public Vector3f Transform(Vector3f v)
		{
			if (Order == TransformOrder.RotateTranslate)
			{
				v = Rotation.Rotate(v);
				return v + Translation;
			}
			else
			{
				v += Translation;
				return Rotation.Rotate(v);
			}
		}

		/// <summary>
		/// Create a Clone of this Transformation Set
		/// </summary>
		/// <returns></returns>
		public VectorTransformation Clone()
		{
			VectorTransformation v = new VectorTransformation(Order)
			{
				Rotation = Rotation.Clone(),
				Translation = Translation.Clone()
			};

			return v;
		}

#if DEBUG
		public string Name
		{
			get; set;
		}
#endif
	}

	#region container
	/// <summary>
	/// Typesave ArrayList for VectorTransformation Objects
	/// </summary>
	public class VectorTransformations : ArrayList
	{
		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new VectorTransformation this[int index]
		{
			get
			{
				return ((VectorTransformation)base[index]);
			}
			set
			{
				base[index] = value;
			}
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public VectorTransformation this[uint index]
		{
			get
			{
				return ((VectorTransformation)base[(int)index]);
			}
			set
			{
				base[(int)index] = value;
			}
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		public int Add(VectorTransformation item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, VectorTransformation item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(VectorTransformation item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(VectorTransformation item)
		{
			return base.Contains(item);
		}

		/// <summary>
		/// Number of stored Elements
		/// </summary>
		public int Length => Count;

		/// <summary>
		/// Create a clone of this Object
		/// </summary>
		/// <returns>The clone</returns>
		public override object Clone()
		{
			VectorTransformations list = new VectorTransformations();
			foreach (VectorTransformation item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
	#endregion
}
