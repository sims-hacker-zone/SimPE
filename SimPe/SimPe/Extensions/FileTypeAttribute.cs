// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace SimPe.Extensions
{
	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]

	internal class FileTypeAttribute : Attribute
	{
		/// <summary>
		/// The long name of the file type to display
		/// </summary>
		public string DisplayName
		{
			get; set;
		}

		/// <summary>
		/// The suggested file extension
		/// </summary>
		public string Extension
		{
			get; set;
		} = "simpe";
		/// <summary>
		/// Is the file contains a file name in the first 64 bytes
		/// </summary>
		public bool ContainsFileName
		{
			get; set;
		} = false;
	}
}
