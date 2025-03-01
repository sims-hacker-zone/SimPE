// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.Globalization;

namespace SimPe
{
	/// <summary>
	/// Used for dynamic PropertyGrids using <see cref="FlagBase"/> Objects.
	/// </summary>
	public class FlagBaseConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(
			ITypeDescriptorContext context,
			Type destinationType
		)
		{
			return destinationType == typeof(FlagBase) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(
			ITypeDescriptorContext context,
			CultureInfo culture,
			object value,
			Type destinationType
		)
		{
			return destinationType == typeof(string) && value is FlagBase
				? Helper.MinStrLength(value.ToString(), 16)
				: base.ConvertTo(context, culture, value, destinationType);
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
			if (value is string)
			{
				try
				{
					ushort s = Convert.ToUInt16((string)value, 2);
					return Activator.CreateInstance(
						context.PropertyDescriptor.PropertyType,
						new object[] { s }
					);
				}
				catch
				{
					throw new ArgumentException(
						"Can not convert '"
							+ (string)value
							+ "'. This is not a valid Flag Value!"
					);
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
