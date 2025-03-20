// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Globalization;

using Avalonia.Data;
using Avalonia.Data.Converters;

namespace SimPe.Extensions
{
	public class EnumToCheckedConverter : IValueConverter
	{
		public Type Type
		{
			get; set;
		}
		public uint? LastValue
		{
			get; private set;
		}
		public bool Flags
		{
			get; set;
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null && value.GetType() == Type)
			{
				try
				{
					object parameterValue = Enum.Parse(Type, parameter as string);

					if (Flags)
					{
						uint intParameter = (uint)parameterValue;
						uint intValue = (uint)value;
						LastValue = intValue;

						return (intValue & intParameter) == intParameter;
					}
					else
					{
						return Equals(parameterValue, value);
					}
				}
				catch (ArgumentNullException)
				{
					return false;
				}
				catch (ArgumentException)
				{
					throw new NotSupportedException();
				}
			}
			else if (value == null)
			{
				return false;
			}

			throw new NotSupportedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is not null and bool check)
			{
				if (check)
				{
					try
					{
						if (Flags && LastValue.HasValue)
						{
							object parameterValue = Enum.Parse(Type, parameter as string);
							uint intParameter = (uint)parameterValue;

							return Enum.ToObject(Type, LastValue | intParameter);
						}
						else
						{
							return Enum.Parse(Type, parameter as string);
						}
					}
					catch (ArgumentNullException)
					{
						return new BindingNotification(null);
					}
					catch (ArgumentException)
					{
						return new BindingNotification(null);
					}
				}
				else
				{
					try
					{
						if (Flags && LastValue.HasValue)
						{
							object parameterValue = Enum.Parse(Type, parameter as string);
							uint intParameter = (uint)parameterValue;

							return Enum.ToObject(Type, LastValue ^ intParameter);
						}
						else
						{
							return new BindingNotification(null);
						}
					}
					catch (ArgumentNullException)
					{
						return new BindingNotification(null);
					}
					catch (ArgumentException)
					{
						return new BindingNotification(null);
					}
				}
			}
			throw new NotSupportedException();
		}
	}
}
