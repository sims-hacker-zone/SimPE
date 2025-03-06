// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;

namespace SimPe.Extensions
{
	public static class EnumExtensions
	{
		/// <summary>
		/// translates the Ages from a SDesc to a Property Set age
		/// </summary>
		public static Ages AgeTranslation(this LifeSections age)
		{
			switch (age)
			{
				case LifeSections.Adult:
					return Ages.Adult;
				case LifeSections.Baby:
					return Ages.Baby;
				case LifeSections.Child:
					return Ages.Child;
				case LifeSections.Elder:
					return Ages.Elder;
				case LifeSections.Teen:
					return Ages.Teen;
				case LifeSections.Toddler:
					return Ages.Toddler;
				default:
					return Ages.Adult;
			}
		}


		/// <summary>
		/// Cache for the <see cref="FileTypeInformation"/>, so that the Reflection is only done once per runtime.
		/// </summary>
		private static readonly Dictionary<FileTypes, FileTypeInformation> fticache = new Dictionary<FileTypes, FileTypeInformation>();

		/// <summary>
		/// Builds the <see cref="FileTypeInformation"/> for a <see cref="FileTypes"/>
		/// </summary>
		/// <param name="item">The file type</param>
		/// <returns>The <see cref="FileTypeInformation"/></returns>
		public static FileTypeInformation ToFileTypeInformation(this FileTypes item)
		{
			if (fticache.ContainsKey(item))
			{
				return fticache[item];
			}
			FileTypeAttribute attr = item.GetType()
							.GetMember(item.ToString())
							.FirstOrDefault()?.GetCustomAttributes(false)
							.OfType<FileTypeAttribute>()
							.FirstOrDefault();
			return fticache[item] = attr != null
				? new FileTypeInformation
				{
					ContainsFileName = attr.ContainsFileName,
					Extension = attr.Extension,
					LongName = attr.DisplayName,
					ShortName = item.ToString(),
					Type = item
				}
				: new FileTypeInformation
				{
					Type = item,
					ShortName = $"UNK_{(uint)item:X8}",
					LongName = $"Unknown (0x{(uint)item:X8})"
				};
		}
	}
}
