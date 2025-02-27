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
using System.ComponentModel;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// This Exception can be cause when dealing with AnimationAxisTransform classes
	/// </summary>
	public class AxisTransformException : Exception
	{
		public AxisTransformException(string message)
			: base(message) { }
	}

	/// <summary>
	/// This Represents one Transformation within the <see cref="AnimationAxisTransformBlock"/>
	/// </summary>
	public class AnimationAxisTransform
		: IDisposable,
			ICloneable,
			IComparable
	{
		#region Attributes
		/// <summary>
		/// Index of this Object within the Parent List
		/// </summary>
		[
			Description("Index of this Object within the Parent List"),
			Category("Information")
		]
		public int Index
		{
			get; private set;
		}

		public AnimationAxisTransformBlock parent;

		/// <summary>
		/// Retuens the Parent of this Block
		/// </summary>
		[Browsable(false)]
		public AnimationAxisTransformBlock Parent => parent;

		ushort tc;

		/// <summary>
		/// The TimeCode for this Frame
		/// </summary>
		[Description("When should this Frame get displayed?"), Category("Information")]
		public short TimeCode
		{
			get
			{
				return (short)(tc & 0x7fff);
			}
			set
			{
				tc = (ushort)((tc & 0x8000) | (ushort)(value & 0x7fff));
			}
		}

		/// <summary>
		/// Use this KeyFrame as a Linear Pole?
		/// </summary>
		[Description("Use this KeyFrame as a Linear Pole."), Category("Information")]
		public bool Linear
		{
			get
			{
				return ((tc & 0x8000) == 0x8000);
			}
			set
			{
				tc = (ushort)(tc & 0x7fff);
				if (value)
				{
					tc = (ushort)(tc | 0x8000);
				}
			}
		}

		/// <summary>
		/// Unknown?
		/// </summary>
		[Description("True if the Parent is Locked."), Category("Information")]
		public bool ParentLocked
		{
			get
			{
				if (parent == null)
				{
					return true;
				}

				return parent.Locked;
			}
			set
			{
				parent.Locked = value;
			}
		}

		/// <summary>
		/// The Transformation Parameter for this Frame
		/// </summary>
		[
			Description("The Transformation Parameter for this Frame."),
			Category("Information")
		]
		public short Parameter
		{
			get; set;
		}

		/// <summary>
		/// The Transformation Parameter for this Frame
		/// </summary>
		[
			Description("The Transformation Parameter as Floatingpoint Value."),
			Category("Information")
		]
		public float ParameterFloat
		{
			get
			{
				return GetCompressedFloat(Parameter);
			}
			set
			{
				Parameter = FromCompressedFloat(value);
			}
		}

		public short Unknown1
		{
			get; set;
		}

		public short Unknown2
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Create a new Instance.
		/// </summary>
		/// <param name="parent">The parent Block</param>
		/// <remarks>
		/// Instances are only valid in the context of a <see cref="AnimationAxisTransformBlock"/>!
		/// </remarks>
		internal AnimationAxisTransform(AnimationAxisTransformBlock parent, int index)
		{
			SetIndex(index);
			SetParent(parent);

			Reset();
		}

		public AnimationAxisTransform()
			: this(null, -1) { }

		public AnimationAxisTransform(AnimationAxisTransformBlock parent)
			: this(parent, -1) { }

		public AnimationAxisTransform CloneBase()
		{
			AnimationAxisTransform aat = new AnimationAxisTransform(null, -1);
			aat.Linear = Linear;
			aat.TimeCode = TimeCode;
			aat.Parameter = Parameter;
			aat.Unknown1 = Unknown1;
			aat.Unknown2 = Unknown2;

			return aat;
		}

		internal void SetIndex(int index)
		{
			Index = index;
		}

		internal void SetParent(AnimationAxisTransformBlock parent)
		{
			this.parent = parent;
		}

		/// <summary>
		/// Reset the stored Values
		/// </summary>
		public void Reset()
		{
			tc = 0;
			Parameter = 0;
			Unknown1 = 0;
			Unknown2 = 0;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void UnserializeData(System.IO.BinaryReader reader)
		{
			Reset();
			short[] datas = new short[parent.TokenSize];
			for (int i = 0; i < datas.Length; i++)
			{
				datas[i] = reader.ReadInt16();
			}

			if (parent.Type == AnimationTokenType.TwoByte)
			{
				Parameter = datas[0];
			}
			else if (parent.Type == AnimationTokenType.SixByte)
			{
				tc = (ushort)datas[0];
				Parameter = datas[1];
				Unknown1 = datas[2];
			}
			else
			{
				tc = (ushort)datas[0];
				Parameter = datas[1];
				Unknown1 = datas[2];
				Unknown2 = datas[3];
			}
		}

		/// <summary>
		/// Serializes to a BinaryStream from the Attributes of this Instance
		/// </summary>
		/// <param name="writer">The Stream that receives the Data</param>
		internal void SerializeData(System.IO.BinaryWriter writer)
		{
			short[] datas = new short[parent.TokenSize];

			if (parent.Type == AnimationTokenType.TwoByte)
			{
				datas[0] = Parameter;
			}
			else if (parent.Type == AnimationTokenType.SixByte)
			{
				datas[0] = (short)tc;
				datas[1] = Parameter;
				datas[2] = Unknown1;
			}
			else
			{
				datas[0] = (short)tc;
				datas[1] = Parameter;
				datas[2] = Unknown1;
				datas[3] = Unknown2;
			}

			for (int i = 0; i < datas.Length; i++)
			{
				writer.Write(datas[i]);
			}
		}

		#region IDisposable Member

		public void Dispose()
		{
			if (parent != null)
			{
				parent = null;
			}
		}

		#endregion

		#region ICloneable Member

		public object Clone()
		{
			return CloneBase();
		}

		#endregion

		public override string ToString()
		{
			string s = TimeCode.ToString() + ": " + Parameter.ToString();
			if (parent == null)
			{
				s += ", " + Unknown1.ToString() + "; " + Unknown2.ToString();
			}
			else
			{
				if (parent.Type == AnimationTokenType.SixByte)
				{
					s += "; " + Unknown1.ToString();
				}

				if (parent.Type == AnimationTokenType.EightByte)
				{
					s += "; " + Unknown1.ToString() + "; " + Unknown2.ToString();
				}
			}
			if (Linear)
			{
				s += " (linear)";
			}

			if (ParentLocked)
			{
				s += " (locked)";
			}

			return s;
		}

		#region IComparable Member

		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}

			if (!(obj is AnimationAxisTransform))
			{
				return -1;
			}

			AnimationAxisTransform aat = (AnimationAxisTransform)obj;
			return TimeCode.CompareTo(aat.TimeCode);
		}

		#endregion

		#region Float Converters

		public float GetCompressedFloat(short val)
		{
			if (parent != null)
			{
				return parent.GetCompressedFloat(val);
			}

			return AnimationAxisTransformBlock.GetCompressedFloat(
				val,
				AnimationAxisTransformBlock.SCALE
			);
		}

		public short FromCompressedFloat(float val)
		{
			if (parent != null)
			{
				return parent.FromCompressedFloat(val);
			}

			return AnimationAxisTransformBlock.FromCompressedFloat(
				val,
				AnimationAxisTransformBlock.SCALE
			);
		}

		#endregion
	}
}
