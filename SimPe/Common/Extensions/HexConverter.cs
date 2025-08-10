// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace SimPe.Common.Extensions;

public class HexConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is not Enum e)
		{
			return targetType.IsAssignableTo(typeof(string))
				? value switch
				{
					byte b => $"0x{b:X2}",
					sbyte b => $"0x{b:X2}",
					short s => $"0x{s:X4}",
					ushort s => $"0x{s:X4}",
					uint i => $"0x{i:X8}",
					int i => $"0x{i:X8}",
					long i => $"0x{i:X16}",
					ulong i => $"0x{i:X16}",
					_ => new BindingNotification(new InvalidCastException(), BindingErrorType.Error),
				}
				: new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
		}

		Type t = Enum.GetUnderlyingType(e.GetType());
		value = System.Convert.ChangeType(value, t);

		return targetType.IsAssignableTo(typeof(string))
			? value switch
			{
				byte b => $"0x{b:X2}",
				sbyte b => $"0x{b:X2}",
				short s => $"0x{s:X4}",
				ushort s => $"0x{s:X4}",
				uint i => $"0x{i:X8}",
				int i => $"0x{i:X8}",
				long i => $"0x{i:X16}",
				ulong i => $"0x{i:X16}",
				_ => new BindingNotification(new InvalidCastException(), BindingErrorType.Error),
			}
			: new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is not string s || !s.StartsWith("0x"))
		{
			return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
		}

		if (targetType.IsAssignableTo(typeof(byte)) && byte.TryParse(s[2..],
		                                                             NumberStyles.HexNumber |
		                                                             NumberStyles.AllowHexSpecifier,
		                                                             CultureInfo.InvariantCulture, out byte b))
		{
			return b;
		}

		if (targetType.IsAssignableTo(typeof(short)) && short.TryParse(s[2..],
		                                                               NumberStyles.HexNumber |
		                                                               NumberStyles.AllowHexSpecifier,
		                                                               CultureInfo.InvariantCulture,
		                                                               out short s1))
		{
			return s1;
		}

		if (targetType.IsAssignableTo(typeof(ushort)) && ushort.TryParse(s[2..],
		                                                                 NumberStyles.HexNumber |
		                                                                 NumberStyles.AllowHexSpecifier,
		                                                                 CultureInfo.InvariantCulture,
		                                                                 out ushort s2))
		{
			return s2;
		}

		if (targetType.IsAssignableTo(typeof(int)) && int.TryParse(s[2..], NumberStyles.HexNumber,
		                                                           CultureInfo.InvariantCulture, out int i1))
		{
			return i1;
		}

		if (targetType.IsAssignableTo(typeof(uint)) && uint.TryParse(s[2..],
		                                                             NumberStyles.HexNumber |
		                                                             NumberStyles.AllowHexSpecifier,
		                                                             CultureInfo.InvariantCulture,
		                                                             out uint i2))
		{
			return i2;
		}

		if (targetType.IsAssignableTo(typeof(long)) && long.TryParse(s[2..],
		                                                             NumberStyles.HexNumber |
		                                                             NumberStyles.AllowHexSpecifier,
		                                                             CultureInfo.InvariantCulture,
		                                                             out long l1))
		{
			return l1;
		}

		if (targetType.IsAssignableTo(typeof(ulong)) && ulong.TryParse(s[2..],
		                                                               NumberStyles.HexNumber |
		                                                               NumberStyles.AllowHexSpecifier,
		                                                               CultureInfo.InvariantCulture,
		                                                               out ulong l2))
		{
			return l2;
		}

		return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
	}
}
