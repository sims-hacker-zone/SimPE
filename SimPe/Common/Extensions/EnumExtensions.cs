// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Linq;

namespace SimPe.Common.Extensions;

public static class EnumExtensions
{
	public static string? GetDisplayName<T>(this T item) where T : struct, Enum
	{
		DisplayNameAttribute? attr = item.GetType()
		                                 .GetMember(item.ToString())
		                                 .FirstOrDefault()?.GetCustomAttributes(false)
		                                 .OfType<DisplayNameAttribute>()
		                                 .FirstOrDefault();
		return attr == null
			? item.ToString()
			: (attr.LocalizedResource
				? Resources.ResourceManager.GetString(attr.DisplayName,
				                                      Resources.Culture)
				: attr.DisplayName);
	}
}
