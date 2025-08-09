using System.Collections.Generic;
using System.Linq;
using SimPe.Sims2.Data;

namespace SimPe.Sims2.Extensions;

public static class EnumExtensions
{
	/// <summary>
	/// translates the Ages from a SDesc to a Property Set age
	/// </summary>
	public static Ages AgeTranslation(this LifeSections age)
	{
		return age switch
		{
			LifeSections.Adult => Ages.Adult,
			LifeSections.Baby => Ages.Baby,
			LifeSections.Child => Ages.Child,
			LifeSections.Elder => Ages.Elder,
			LifeSections.Teen => Ages.Teen,
			LifeSections.Toddler => Ages.Toddler,
			_ => Ages.Adult,
		};
	}

	/// <summary>
	/// Cache for the <see cref="FileTypeInformation"/>, so that the Reflection is only done once per runtime.
	/// </summary>
	private static readonly Dictionary<FileTypes, FileTypeInformation> fticache = [];

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
				LongName = $"Unknown (0x{(uint)item:X8})",
				Extension = "simpe"
			};
	}
}
