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
		public int? LastValue
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
						int intParameter = (int)parameterValue;
						int intValue = (int)value;
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
							int intParameter = (int)parameterValue;

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
							int intParameter = (int)parameterValue;

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
