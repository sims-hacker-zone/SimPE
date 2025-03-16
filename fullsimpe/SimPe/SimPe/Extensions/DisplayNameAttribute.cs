// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Extensions
{
	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	internal class DisplayNameAttribute(string displayName) : Attribute
	{
		/// <summary>
		/// The display name of the enum member
		/// </summary>
		public string DisplayName
		{
			get; set;
		} = displayName;
	}
}
