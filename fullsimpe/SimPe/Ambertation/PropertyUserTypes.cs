// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
			Color = cl;
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
			double d = cmp / (double)0xff;
			return (float)d;
		}

		public override string ToString()
		{
			return ToFloat(Color.R)
					.ToString("N5", CultureInfo.InvariantCulture)
				+ ","
				+ ToFloat(Color.G)
					.ToString("N5", CultureInfo.InvariantCulture)
				+ ","
				+ ToFloat(Color.B)
					.ToString("N5", CultureInfo.InvariantCulture);
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
			Color o = Color.Black;

			while (s.IndexOf(" ") != -1)
			{
				s = s.Replace(" ", "");
			}

			if (s.IndexOf(";") == -1)
			{
				string[] parts = s.Split(",".ToCharArray(), 4);
				o = parts.Length < 3
					? Color.Black
					: parts.Length == 3
						? Color.FromArgb(
											(int)(
												Convert.ToSingle(
													parts[0],
													CultureInfo.InvariantCulture
												) * 0xff
											),
											(int)(
												Convert.ToSingle(
													parts[1],
													CultureInfo.InvariantCulture
												) * 0xff
											),
											(int)(
												Convert.ToSingle(
													parts[2],
													CultureInfo.InvariantCulture
												) * 0xff
											)
										)
						: Color.FromArgb(
											(int)(
												Convert.ToSingle(
													parts[0],
													CultureInfo.InvariantCulture
												) * 0xff
											),
											(int)(
												Convert.ToSingle(
													parts[1],
													CultureInfo.InvariantCulture
												) * 0xff
											),
											(int)(
												Convert.ToSingle(
													parts[2],
													CultureInfo.InvariantCulture
												) * 0xff
											),
											(int)(
												Convert.ToSingle(
													parts[3],
													CultureInfo.InvariantCulture
												) * 0xff
											)
										);
			}
			else
			{
				string[] parts = s.Split(";".ToCharArray(), 4);
				o = parts.Length < 3
					? Color.Black
					: parts.Length == 3
						? Color.FromArgb(

												Convert.ToInt16(
													parts[0],
													CultureInfo.InvariantCulture
												)
											,

												Convert.ToInt16(
													parts[1],
													CultureInfo.InvariantCulture
												)
											,

												Convert.ToInt16(
													parts[2],
													CultureInfo.InvariantCulture
												)

										)
						: Color.FromArgb(

												Convert.ToInt16(
													parts[0],
													CultureInfo.InvariantCulture
												)
											,

												Convert.ToInt16(
													parts[1],
													CultureInfo.InvariantCulture
												)
											,

												Convert.ToInt16(
													parts[2],
													CultureInfo.InvariantCulture
												)
											,

												Convert.ToInt16(
													parts[3],
													CultureInfo.InvariantCulture
												)

										);
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
			return destinationType == typeof(BaseChangeableNumber) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(
			ITypeDescriptorContext context,
			CultureInfo culture,
			object value,
			Type destinationType
		)
		{
			if (
				destinationType == typeof(string)
				&& value is BaseChangeableNumber
			)
			{
				BaseChangeableNumber so = (BaseChangeableNumber)value;
				type = so.Type;

				return so.ToString();
			}
			else if (destinationType == typeof(string))
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
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(
			ITypeDescriptorContext context,
			CultureInfo culture,
			object value
		)
		{
			if (value is string s)
			{
				try
				{
					if (type == null)
					{
						type = context.PropertyDescriptor.PropertyType;
					}
#pragma warning disable IDE0046
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
#pragma warning restore IDE0046
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
				switch (DigitBase)
				{
					case 16:
						return "Hexadecimal";
					case 2:
						return "Binary";
					default:
						return "Decimal";
				}
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
			get => (short)(LongValue & 0xffff);
			set => LongValue = (short)(value & 0xffff);
		}

		/// <summary>
		/// The actual Value (as Integer)
		/// </summary>
		public int IntegerValue
		{
			get => (int)LongValue;
			set => LongValue = value;
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

			LongValue = Type == typeof(byte)
				? System.Convert.ToByte(o)
				: Type == typeof(sbyte)
					? System.Convert.ToSByte(o)
					: Type == typeof(short)
									? System.Convert.ToInt16(o)
									: Type == typeof(ushort)
													? System.Convert.ToUInt16(o)
													: Type == typeof(int)
																	? System.Convert.ToInt32(o)
																	: Type == typeof(uint)
																					? System.Convert.ToUInt32(o)
																					: Type == typeof(long) ? System.Convert.ToInt64(o) : (long)System.Convert.ToUInt64(o);

			Type = t;
		}

		/// <summary>
		/// The actual value (same type as this value was created with, or last set)
		/// </summary>
		public object ObjectValue
		{
			set => SetValue(value, value.GetType());
			get
			{
#pragma warning disable IDE0046
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

				return LongValue;
#pragma warning restore IDE0046
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

			switch (DigitBase)
			{
				case 16:
					len /= 4;
					return "0x" + SimPe.Helper.StrLength(LongValue.ToString("x"), len, false);
				case 2:
					return "b"
									+ SimPe.Helper.StrLength(
										System.Convert.ToString(LongValue, 2),
										len,
										false
									);
				default:
					return LongValue.ToString();
			}
		}

		public static implicit operator uint(BaseChangeableNumber bcn)
		{
			return (uint)bcn.IntegerValue;
		}
	}
}
