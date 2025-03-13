// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SimPe.Plugin.Gmdc
{
	#region GMDCElementValue
	/// <summary>
	/// Contains a SingleFloat Value
	/// </summary>
	public class GmdcElementValueBase
	{
		/// <summary>
		/// Scalar Multiplication
		/// </summary>
		/// <param name="evb">First Value</param>
		/// <param name="d">Scalar Factor</param>
		/// <returns>The resulting Value</returns>
		public static GmdcElementValueBase operator *(
			GmdcElementValueBase evb,
			double d
		)
		{
			GmdcElementValueBase n = evb.Clone();
			for (int i = 0; i < n.Data.Length; i++)
			{
				n.Data[i] = (float)(n.Data[i] * d);
			}

			return n;
		}

		/// <summary>
		/// Scalar Multiplication
		/// </summary>
		/// <param name="evb">First Value</param>
		/// <param name="d">Scalar Factor</param>
		/// <returns>The resulting Value</returns>
		public static GmdcElementValueBase operator *(
			double d,
			GmdcElementValueBase evb
		)
		{
			return evb * d;
		}

		/// <summary>
		/// The plain stored Data
		/// </summary>
		public float[] Data
		{
			get; set;
		}

		/// <summary>
		/// Returns the number of Float Elements stored here
		/// </summary>
		internal virtual byte Size => 0;

		public GmdcElementValueBase()
		{
			Data = new float[Size];
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal virtual void Unserialize(BinaryReader reader)
		{
			for (int i = 0; i < Data.Length; i++)
			{
				Data[i] = reader.ReadSingle();
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
		internal virtual void Serialize(BinaryWriter writer)
		{
			for (int i = 0; i < Data.Length; i++)
			{
				writer.Write(Data[i]);
			}
		}

		/// <summary>
		/// This output is used in the ListBox View
		/// </summary>
		/// <returns>A String Describing the Data</returns>
		public override string ToString()
		{
			string s = "";
			for (int i = 0; i < Data.Length; i++)
			{
				if (i != 0)
				{
					s += ", ";
				}

				s += Data[i].ToString("N6");
			}
			return s;
		}

		/// <summary>
		/// Create a Clone of this Object
		/// </summary>
		/// <returns>The Clone</returns>
		public virtual GmdcElementValueBase Clone()
		{
			return this;
		}

		/// <summary>
		/// This Method supports the Internal process of creating a Clone
		/// </summary>
		/// <param name="dest">The object that should receive the copied Data</param>
		protected void Clone(GmdcElementValueBase dest)
		{
			for (int i = 0; i < Data.Length; i++)
			{
				dest.Data[i] = Data[i];
			}
		}

		public override int GetHashCode()
		{
			int f = 0;
			for (int i = 0; i < Data.Length; i++)
			{
				f += Data[i].GetHashCode();
			}

			return f;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (obj is GmdcElementValueBase)
			{
				float epsilon = float.Epsilon * 10;
				GmdcElementValueBase g = (GmdcElementValueBase)obj;
				if (g.Data.Length != Data.Length)
				{
					return false;
				}

				for (int i = 0; i < Data.Length; i++)
				{
					if (Math.Abs(g.Data[i] - Data[i]) > epsilon)
					{
						return false;
					}
				}

				return true;
			}
			return base.Equals(obj);
		}
	}

	/// <summary>
	/// Contains a single Float Value
	/// </summary>
	public class GmdcElementValueOneFloat : GmdcElementValueBase
	{
		internal override byte Size => 1;

		internal GmdcElementValueOneFloat()
			: base() { }

		/// <summary>
		/// Create an Instance of this class
		/// </summary>
		/// <param name="f1">The Float Value</param>
		public GmdcElementValueOneFloat(float f1)
		{
			Data = new float[Size];
			Data[0] = f1;
		}

		/// <summary>
		/// Create a Clone of this Object
		/// </summary>
		/// <returns>The Clone</returns>
		public override GmdcElementValueBase Clone()
		{
			GmdcElementValueBase dest = new GmdcElementValueOneFloat();
			Clone(dest);
			return dest;
		}
	}

	/// <summary>
	/// Contains a two gloat Value
	/// </summary>
	public class GmdcElementValueTwoFloat : GmdcElementValueBase
	{
		internal override byte Size => 2;

		internal GmdcElementValueTwoFloat()
			: base() { }

		/// <summary>
		/// Create an Instance of this class
		/// </summary>
		/// <param name="f1">The first Value</param>
		/// <param name="f2">The second Value</param>
		public GmdcElementValueTwoFloat(float f1, float f2)
		{
			Data = new float[Size];
			Data[0] = f1;
			Data[1] = f2;
		}

		/// <summary>
		/// Create a Clone of this Object
		/// </summary>
		/// <returns>The Clone</returns>
		public override GmdcElementValueBase Clone()
		{
			GmdcElementValueBase dest = new GmdcElementValueTwoFloat();
			Clone(dest);
			return dest;
		}
	}

	/// <summary>
	/// Contains a three gloat Value
	/// </summary>
	public class GmdcElementValueThreeFloat : GmdcElementValueBase
	{
		internal override byte Size => 3;

		internal GmdcElementValueThreeFloat()
			: base() { }

		/// <summary>
		/// Create an Instance of this class
		/// </summary>
		/// <param name="f1">The first Value</param>
		/// <param name="f2">The second Value</param>
		/// <param name="f3">The third Value</param>
		public GmdcElementValueThreeFloat(float f1, float f2, float f3)
		{
			Data = new float[Size];
			Data[0] = f1;
			Data[1] = f2;
			Data[2] = f3;
		}

		/// <summary>
		/// Create a Clone of this Object
		/// </summary>
		/// <returns>The Clone</returns>
		public override GmdcElementValueBase Clone()
		{
			GmdcElementValueBase dest = new GmdcElementValueThreeFloat();
			Clone(dest);
			return dest;
		}
	}

	/// <summary>
	/// Contains a two gloat Value
	/// </summary>
	public class GmdcElementValueOneInt : GmdcElementValueBase
	{
		internal override byte Size => 1;

		internal GmdcElementValueOneInt()
			: base() { }

		/// <summary>
		/// Create an Instance of this class
		/// </summary>
		/// <param name="i1">The integer Value</param>
		public GmdcElementValueOneInt(int i1)
		{
			Data = new float[Size];
			Value = i1;
		}

		/// <summary>
		/// Returns /Sets the stored Value
		/// </summary>
		public int Value
		{
			get => val; //(int)Data[0];
			set
			{
				Data[0] = value;
				val = value;
			}
		}

		/// <summary>
		/// Returns / Sets the Bytes that are stored as one Dword Value
		/// </summary>
		/// <remarks>
		/// Changein one of the passed Bytes will NOT effect the stored Value, you have to
		/// write a complete Array back into this Property to change the stored Value!
		/// </remarks>
		public byte[] Bytes
		{
			get => BitConverter.GetBytes(Value);
			set => Value = BitConverter.ToInt32(value, 0);
		}

		public void SetByte(int index, byte val)
		{
			byte[] r = Bytes;
			r[index] = val;
			Bytes = r;
		}

		/// <summary>
		/// This output is used in the ListBox View
		/// </summary>
		/// <returns>A String Describing the Data</returns>
		public override string ToString()
		{
			string s = Value.ToString() + " (";
			byte[] b = Bytes;
			for (int i = 0; i < b.Length; i++)
			{
				s += b[i].ToString() + " ";
			}

			s = s.Trim() + ")";
			return s;
		}

		internal override void Serialize(BinaryWriter writer)
		{
			//writer.Write((int)Data[0]);
			writer.Write(val);
		}

		int val;

		internal override void Unserialize(BinaryReader reader)
		{
			val = reader.ReadInt32();
			Data[0] = val;
		}

		/// <summary>
		/// Create a Clone of this Object
		/// </summary>
		/// <returns>The Clone</returns>
		public override GmdcElementValueBase Clone()
		{
			GmdcElementValueBase dest = new GmdcElementValueOneInt();
			Clone(dest);
			return dest;
		}
	}
	#endregion

	/// <summary>
	/// This class contains the Elements Section of a Geometric Data Container
	/// </summary>
	public class GmdcElement : GmdcLinkBlock
	{
		#region Attributes

		/// <summary>
		/// Number of stored <see cref="Values"/> that can be used
		/// </summary>
		public int Number
		{
			get; set;
		}

		/// <summary>
		/// The Type of Data that is stored in <see cref="Values"/>.
		/// </summary>
		public ElementIdentity Identity
		{
			get; set;
		}

		/// <summary>
		/// If one <see cref="GmdcLink"/> is referenceing more than one <see cref="GmdcElement"/>
		/// of the same <see cref="Identity"/>, this value is used to differ them. (Zero based)
		/// </summary>
		public int GroupId
		{
			get; set;
		}

		/// <summary>
		/// What Type are the <see cref="Values"/> stored in.
		/// </summary>
		/// <remarks>This Filed Determins which SubClass of <see cref="GmdcElementValueBase"/> is used for
		/// the <see cref="Values"/> Members</remarks>
		public BlockFormat BlockFormat
		{
			get; set;
		}

		/// <summary>
		/// Describes the Elemnet
		/// </summary>
		public SetFormat SetFormat
		{
			get; set;
		}

		/// <summary>
		/// Contains a List of <see cref="GmdcElementValueBase"/> Values. The Type of the Elements
		/// is determined by the <see cref="BlockFormat"/> Property.
		/// </summary>
		public List<GmdcElementValueBase> Values
		{
			get; set;
		}

		/// <summary>
		/// Yet unknown what this is doing
		/// </summary>
		public List<int> Items
		{
			get; set;
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public GmdcElement(GeometryDataContainer parent)
			: base(parent)
		{
			Values = new List<GmdcElementValueBase>();
			Items = new List<int>();
		}

		/// <summary>
		/// Returns an instance of GmdcElementValueBase class in the apropriate Format
		/// </summary>
		/// <returns>A class Instance</returns>
		/// <remarks>The Type of the instance is determined using the SubType</remarks>
		public GmdcElementValueBase GetValueInstance()
		{
			switch (BlockFormat)
			{
				case BlockFormat.OneDword:
					return new GmdcElementValueOneInt();
				case BlockFormat.OneFloat:
					return new GmdcElementValueOneFloat();
				case BlockFormat.TwoFloat:
					return new GmdcElementValueTwoFloat();
				case BlockFormat.ThreeFloat:
					return new GmdcElementValueThreeFloat();
			}

			return new GmdcElementValueOneFloat();
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(BinaryReader reader)
		{
			Number = reader.ReadInt32();
			uint id = reader.ReadUInt32();
			Identity = (ElementIdentity)id;
			GroupId = reader.ReadInt32();
			BlockFormat = (BlockFormat)reader.ReadInt32();
			SetFormat = (SetFormat)reader.ReadInt32();

			GmdcElementValueBase dummy = GetValueInstance();
			int len = reader.ReadInt32() / (4 * dummy.Size);
			Values.Clear();
			for (int i = 0; i < len; i++)
			{
				dummy = GetValueInstance();
				dummy.Unserialize(reader);
				Values.Add(dummy);
			}

			ReadBlock(reader, Items);
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public void Serialize(BinaryWriter writer)
		{
			//automatically keep the Number Field correct
			if (Items.Count == 0)
			{
				Number = Values.Count;
				foreach (int i in Items)
				{
					if (i > Number)
					{
						Number = i - 1;
					}
				}
			}

			writer.Write(Number);

			writer.Write((int)Identity);
			writer.Write(GroupId);
			writer.Write((uint)BlockFormat);
			writer.Write((uint)SetFormat);

			int size = 1;
			if (Values.Count > 0)
			{
				size = Values[0].Size;
			}

			writer.Write(Values.Count * 4 * size);
			for (int i = 0; i < Values.Count; i++)
			{
				Values[i].Serialize(writer);
			}

			WriteBlock(writer, Items);
		}

		/// <summary>
		/// This output is used in the ListBox View
		/// </summary>
		/// <returns>A String Describing the Data</returns>
		public override string ToString()
		{
			return Identity.ToString()
				+ ", "
				+ SetFormat.ToString()
				+ ", "
				+ BlockFormat.ToString()
				+ " ("
				+ Values.Count.ToString()
				+ ")";
		}
	}
}
