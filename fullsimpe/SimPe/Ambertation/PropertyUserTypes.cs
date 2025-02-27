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
using System.Drawing;
using System.Globalization;

namespace Ambertation
{
	/// <summary>
	/// Stores a Floatingpoint Color
	/// </summary>
	public class FloatColor
	{
		public Color Color
		{
			get; set;
		}

		FloatColor(Color cl)
		{
			this.Color = cl;
		}

		FloatColor(string s)
		{
			Color = ToColor(s);
		}

		public static FloatColor FromColor(Color cl)
		{
			return new FloatColor(cl);
		}

		public static FloatColor FromString(string s)
		{
			return new FloatColor(s);
		}

		float ToFloat(int cmp)
		{
			double d = (double)cmp / (double)0xff;
			return (float)d;
		}

		public override string ToString()
		{
			return ToFloat(Color.R)
					.ToString("N5", System.Globalization.CultureInfo.InvariantCulture)
				+ ","
				+ ToFloat(Color.G)
					.ToString("N5", System.Globalization.CultureInfo.InvariantCulture)
				+ ","
				+ ToFloat(Color.B)
					.ToString("N5", System.Globalization.CultureInfo.InvariantCulture);
		}

		// Explicit conversion from DBBool to bool. Throws an
		// exception if the given DBBool is dbNull, otherwise returns
		// true or false:
		public static implicit operator Color(FloatColor x)
		{
			return x.Color;
		}

		/// <summary>
		/// Returns the color represented by a string like 1.0,1.0,1.0
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static Color ToColor(string s)
		{
			Color o = System.Drawing.Color.Black;

			while (s.IndexOf(" ") != -1)
			{
				s = s.Replace(" ", "");
			}

			if (s.IndexOf(";") == -1)
			{
				string[] parts = s.Split(",".ToCharArray(), 4);
				if (parts.Length < 3)
				{
					o = System.Drawing.Color.Black;
				}
				else if (parts.Length == 3)
				{
					o = System.Drawing.Color.FromArgb(
						(int)(
							System.Convert.ToSingle(
								parts[0],
								System.Globalization.CultureInfo.InvariantCulture
							) * 0xff
						),
						(int)(
							System.Convert.ToSingle(
								parts[1],
								System.Globalization.CultureInfo.InvariantCulture
							) * 0xff
						),
						(int)(
							System.Convert.ToSingle(
								parts[2],
								System.Globalization.CultureInfo.InvariantCulture
							) * 0xff
						)
					);
				}
				else
				{
					o = System.Drawing.Color.FromArgb(
						(int)(
							System.Convert.ToSingle(
								parts[0],
								System.Globalization.CultureInfo.InvariantCulture
							) * 0xff
						),
						(int)(
							System.Convert.ToSingle(
								parts[1],
								System.Globalization.CultureInfo.InvariantCulture
							) * 0xff
						),
						(int)(
							System.Convert.ToSingle(
								parts[2],
								System.Globalization.CultureInfo.InvariantCulture
							) * 0xff
						),
						(int)(
							System.Convert.ToSingle(
								parts[3],
								System.Globalization.CultureInfo.InvariantCulture
							) * 0xff
						)
					);
				}
			}
			else
			{
				string[] parts = s.Split(";".ToCharArray(), 4);
				if (parts.Length < 3)
				{
					o = System.Drawing.Color.Black;
				}
				else if (parts.Length == 3)
				{
					o = System.Drawing.Color.FromArgb(
						(int)(
							System.Convert.ToInt16(
								parts[0],
								System.Globalization.CultureInfo.InvariantCulture
							)
						),
						(int)(
							System.Convert.ToInt16(
								parts[1],
								System.Globalization.CultureInfo.InvariantCulture
							)
						),
						(int)(
							System.Convert.ToInt16(
								parts[2],
								System.Globalization.CultureInfo.InvariantCulture
							)
						)
					);
				}
				else
				{
					o = System.Drawing.Color.FromArgb(
						(int)(
							System.Convert.ToInt16(
								parts[0],
								System.Globalization.CultureInfo.InvariantCulture
							)
						),
						(int)(
							System.Convert.ToInt16(
								parts[1],
								System.Globalization.CultureInfo.InvariantCulture
							)
						),
						(int)(
							System.Convert.ToInt16(
								parts[2],
								System.Globalization.CultureInfo.InvariantCulture
							)
						),
						(int)(
							System.Convert.ToInt16(
								parts[3],
								System.Globalization.CultureInfo.InvariantCulture
							)
						)
					);
				}
			}

			return o;
		}
	}

	/// <summary>
	/// This is a typeconverter for the special Short class
	/// </summary>
	public class NumberBaseTypeConverter : TypeConverter
	{
		Type type;

		public override bool CanConvertTo(
			ITypeDescriptorContext context,
			Type destinationType
		)
		{
			if (destinationType == typeof(BaseChangeableNumber))
			{
				return true;
			}

			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(
			ITypeDescriptorContext context,
			CultureInfo culture,
			object value,
			Type destinationType
		)
		{
			if (
				destinationType == typeof(System.String)
				&& value is BaseChangeableNumber
			)
			{
				BaseChangeableNumber so = (BaseChangeableNumber)value;
				type = so.Type;

				return so.ToString();
			}
			else if (destinationType == typeof(System.String))
			{
				BaseChangeableNumber so = new BaseChangeableNumber(value);
				return so.ToString();
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override bool CanConvertFrom(
			ITypeDescriptorContext context,
			Type sourceType
		)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}

			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(
			ITypeDescriptorContext context,
			CultureInfo culture,
			object value
		)
		{
			if (value is string)
			{
				try
				{
					string s = (string)value;

					if (type == null)
					{
						type = context.PropertyDescriptor.PropertyType;
					}

					BaseChangeableNumber bcn = BaseChangeableNumber.Convert(s, type);
					if (context.PropertyDescriptor.PropertyType == typeof(long))
					{
						return bcn.LongValue;
					}

					if (context.PropertyDescriptor.PropertyType == typeof(ulong))
					{
						return (ulong)bcn.LongValue;
					}

					if (context.PropertyDescriptor.PropertyType == typeof(int))
					{
						return bcn.IntegerValue;
					}

					if (context.PropertyDescriptor.PropertyType == typeof(uint))
					{
						return (uint)bcn.IntegerValue;
					}

					if (context.PropertyDescriptor.PropertyType == typeof(short))
					{
						return (short)bcn.IntegerValue;
					}

					if (context.PropertyDescriptor.PropertyType == typeof(ushort))
					{
						return (ushort)bcn.IntegerValue;
					}

					if (context.PropertyDescriptor.PropertyType == typeof(byte))
					{
						return (byte)bcn.IntegerValue;
					}

					if (context.PropertyDescriptor.PropertyType == typeof(sbyte))
					{
						return (sbyte)bcn.IntegerValue;
					}

					return bcn;
				}
				catch
				{
					throw new ArgumentException(
						"Can not convert '"
							+ (string)value
							+ "'. This is not a valid "
							+ BaseChangeableNumber.BaseName
							+ " Number of Type "
							+ type.Name
							+ "!"
					);
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}

	/// <summary>
	/// This is a class that can present short Values in diffrent Ways
	/// </summary>
	[
		TypeConverter(typeof(NumberBaseTypeConverter)),
		Description("This Values can be displayed in Dec, Hex and Bin")
	]
	public class BaseChangeableNumber
	{
		internal Type Type
		{
			get; private set;
		}

		/// <summary>
		/// The Number Base used for Display
		/// </summary>
		public static int DigitBase { get; set; } = 16;

		/// <summary>
		/// Name of this Number Representation
		/// </summary>
		public static string BaseName
		{
			get
			{
				if (DigitBase == 16)
				{
					return "Hexadecimal";
				}

				if (DigitBase == 2)
				{
					return "Binary";
				}

				return "Decimal";
			}
		}

		/// <summary>
		/// Converts a String Back to a type of this Class
		/// </summary>
		/// <param name="s">The string Representation</param>
		/// <param name="type">the type of the Target Number</param>
		/// <returns>a new Instance</returns>
		public static BaseChangeableNumber Convert(string s, Type type)
		{
			s = s.Trim().ToLower();
			object val = 0;

			int b = 10;
			int o = 0;
			if (s.StartsWith("0x"))
			{
				b = 16;
				o = 0;
			}
			else if (s.StartsWith("b"))
			{
				b = 2;
				o = 1;
			}

			s = s.Substring(o);
			if (type == typeof(byte))
			{
				val = System.Convert.ToByte(s, b);
			}
			else if (type == typeof(sbyte))
			{
				val = System.Convert.ToSByte(s, b);
			}
			else if (type == typeof(short))
			{
				val = System.Convert.ToInt16(s, b);
			}
			else if (type == typeof(ushort))
			{
				val = System.Convert.ToUInt16(s, b);
			}
			else if (type == typeof(int))
			{
				val = System.Convert.ToInt32(s, b);
			}
			else if (type == typeof(uint))
			{
				val = System.Convert.ToUInt32(s, b);
			}
			else if (type == typeof(long))
			{
				val = System.Convert.ToInt64(s, b);
			}
			else if (type == typeof(ulong))
			{
				val = (long)System.Convert.ToUInt64(s, b);
			}

			//SetValue(val, type);
			return new BaseChangeableNumber(val, type);
		}

		public BaseChangeableNumber(object v)
		{
			ObjectValue = v;
			if (v != null)
			{
				Type = v.GetType();
			}
		}

		internal BaseChangeableNumber(object v, Type t)
		{
			SetValue(v, t);
		}

		internal BaseChangeableNumber()
		{
			LongValue = 0;
			Type = typeof(int);
		}

		/// <summary>
		/// The actual Value (as short)
		/// </summary>
		public short Value
		{
			get
			{
				return (short)(LongValue & 0xffff);
				;
			}
			set
			{
				LongValue = (short)(value & 0xffff);
			}
		}

		/// <summary>
		/// The actual Value (as Integer)
		/// </summary>
		public int IntegerValue
		{
			get
			{
				return (int)LongValue;
			}
			set
			{
				LongValue = value;
			}
		}

		/// <summary>
		/// The actual Value (as Long)
		/// </summary>
		public long LongValue
		{
			get; set;
		}

		internal void SetValue(object o, Type t)
		{
			Type = t; //o.GetType();

			if (Type == typeof(byte))
			{
				LongValue = System.Convert.ToByte(o);
			}
			else if (Type == typeof(sbyte))
			{
				LongValue = System.Convert.ToSByte(o);
			}
			else if (Type == typeof(short))
			{
				LongValue = System.Convert.ToInt16(o);
			}
			else if (Type == typeof(ushort))
			{
				LongValue = System.Convert.ToUInt16(o);
			}
			else if (Type == typeof(int))
			{
				LongValue = System.Convert.ToInt32(o);
			}
			else if (Type == typeof(uint))
			{
				LongValue = System.Convert.ToUInt32(o);
			}
			else if (Type == typeof(long))
			{
				LongValue = System.Convert.ToInt64(o);
			}
			else
			{
				LongValue = (long)System.Convert.ToUInt64(o);
			}

			Type = t;
		}

		/// <summary>
		/// The actual value (same type as this value was created with, or last set)
		/// </summary>
		public object ObjectValue
		{
			set
			{
				SetValue(value, value.GetType());
			}
			get
			{
				if (Type == typeof(int))
				{
					return (int)LongValue;
				}

				if (Type == typeof(uint))
				{
					return (uint)LongValue;
				}

				if (Type == typeof(short))
				{
					return (short)LongValue;
				}

				if (Type == typeof(ushort))
				{
					return (ushort)LongValue;
				}

				if (Type == typeof(byte))
				{
					return (byte)LongValue;
				}

				if (Type == typeof(ulong))
				{
					return (ulong)LongValue;
				}

				return (long)LongValue;
			}
		}

		/// <summary>
		/// Return the String Representation of the stored Value
		/// </summary>
		/// <returns>A String</returns>
		public override string ToString()
		{
			int len = 64;
			if (Type == typeof(byte))
			{
				len = 8;
			}
			else if (Type == typeof(sbyte))
			{
				len = 8;
			}
			else if (Type == typeof(short))
			{
				len = 16;
			}
			else if (Type == typeof(ushort))
			{
				len = 16;
			}
			else if (Type == typeof(int))
			{
				len = 32;
			}
			else if (Type == typeof(uint))
			{
				len = 32;
			}
			else if (Type == typeof(long))
			{
				len = 64;
			}
			else if (Type == typeof(ulong))
			{
				len = 64;
			}

			if (DigitBase == 16)
			{
				len = len / 4;
				return "0x" + SimPe.Helper.StrLength(LongValue.ToString("x"), len, false);
			}
			else if (DigitBase == 2)
			{
				return "b"
					+ SimPe.Helper.StrLength(
						System.Convert.ToString(LongValue, 2),
						len,
						false
					);
			}
			else
			{
				return LongValue.ToString();
			}
		}

		public static implicit operator uint(BaseChangeableNumber bcn)
		{
			return (uint)bcn.IntegerValue;
		}
	}
}
