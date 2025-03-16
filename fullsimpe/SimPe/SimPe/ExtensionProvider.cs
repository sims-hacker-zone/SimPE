// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Extensions;
namespace SimPe
{
	/// <summary>
	/// Which ExtensionType dou you want to have
	/// </summary>
	public enum ExtensionType : short
	{
		Package = 0x01,
		DisabledPackage = 0x02,
		ExtractedFile = 0x04,
		ExtractedFileDescriptor = 0x08,
		ExtrackedPackageDescriptor = 0x10,
		Sim2Pack = 0x20,
		Sim2PackCommunity = 0x40,
		AllFiles = 0x80,
		LuaScript = 0x100,
	}

	/// <summary>
	/// Describes one Extension
	/// </summary>
	public class ExtensionDescriptor
	{
		/// <summary>
		/// Create an Instance
		/// </summary>
		/// <param name="name">Description</param>
		/// <param name="ext">; seperated List of Extensions (like *.bmp;*.gif;*.tmp)</param>
		internal ExtensionDescriptor(string name, string ext)
		{
			Extensions = ext.Split(new char[] { ';' });
			Text = Localization.GetString(name);
		}

		/// <summary>
		/// Create an Instance
		/// </summary>
		internal ExtensionDescriptor(string name, IEnumerable<string> ext)
		{
			Extensions = ext;
			Text = Localization.GetString(name);
		}

		/// <summary>
		/// Returns a List of allowed Extensions for this Type (like *.bmp, *.gif, *.jpg)
		/// </summary>
		public IEnumerable<string> Extensions
		{
			get;
		}

		/// <summary>
		/// Returns the Name of this Extension
		/// </summary>
		public string Text
		{
			get;
		}

		/// <summary>
		/// Returns the ExtensionList as string
		/// </summary>
		/// <returns></returns>
		public string GetExtensionList()
		{
			return string.Join(";", Extensions);
		}

		/// <summary>
		/// Returens a string that can be used as a Filter in an open/save Dialog
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Text + " (" + GetExtensionList() + ")|" + GetExtensionList();
		}

		/// <summary>
		/// true, fi the passed File has one of the allowe dExtensions
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public bool AllowedExtension(string filename)
		{
			return Extensions.Any(item => filename.Trim().ToLower().EndsWith(item.Trim().ToLower().Replace("*", "")));
		}
	}

	/// <summary>
	/// Used to get some Default Extensions
	/// </summary>
	public class ExtensionProvider
	{
		/// <summary>
		/// Returns a list of all extractable Extensions
		/// </summary>
		/// <returns></returns>
		static IEnumerable<string> GetExtractExtensions(string suffix)
		{
			return (from FileTypes type in Enum.GetValues(typeof(FileTypes))
					select ("*." + type.ToFileTypeInformation().Extension + suffix)).Distinct();
		}

		/// <summary>
		/// Returns a List of known Extensions (key=ExtensionType, value =ExtensionDescriptor)
		/// </summary>
		public static Dictionary<ExtensionType, Avalonia.Platform.Storage.FilePickerFileType> ExtensionMap
		{
			get;
		} = new Dictionary<ExtensionType, Avalonia.Platform.Storage.FilePickerFileType>
		{
			[ExtensionType.Package] = new Avalonia.Platform.Storage.FilePickerFileType("DBPF Package")
			{
				Patterns = new List<string>
					{
						"*.package",
						"*.cache",
						"*.template",
						"*.sims"
					}
			},
			[ExtensionType.DisabledPackage] = new Avalonia.Platform.Storage.FilePickerFileType("Disabled DBPF Package")
			{
				Patterns = new List<string>
					{
						"*.packagedisabled",
						"*.simpedis",
					}
			},
			[ExtensionType.ExtractedFile] = new Avalonia.Platform.Storage.FilePickerFileType("Extracted File")
			{
				Patterns = GetExtractExtensions("").ToList()
			},
			[ExtensionType.ExtractedFileDescriptor] = new Avalonia.Platform.Storage.FilePickerFileType("Extracted File Descriptor")
			{
				Patterns = GetExtractExtensions(".xml").ToList()
			},
			[ExtensionType.ExtrackedPackageDescriptor] = new Avalonia.Platform.Storage.FilePickerFileType("Extracted Package")
			{
				Patterns = new List<string>
					{
						"package.xml"
					}
			},
			[ExtensionType.Sim2Pack] = new Avalonia.Platform.Storage.FilePickerFileType("Packed Objects")
			{
				Patterns = new List<string>
					{
						"*.sims2pack"
					}
			},
			[ExtensionType.Sim2PackCommunity] = new Avalonia.Platform.Storage.FilePickerFileType("Sims 2 Community Package")
			{
				Patterns = new List<string>
					{
						"*.s2cp"
					}
			},
			[ExtensionType.AllFiles] = new Avalonia.Platform.Storage.FilePickerFileType("All Files")
			{
				Patterns = new List<string>
					{
						"*.*"
					}
			},
			[ExtensionType.LuaScript] = new Avalonia.Platform.Storage.FilePickerFileType("LUA Script")
			{
				Patterns = new List<string>
					{
						"*.lua",
						"*.globalObjLua",
						"*.objLua",
						"luac.out",
					}
			},
		};

		/// <summary>
		/// Returns the descriptor for a given Type (returns a default Extension when the type was not found)
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static Avalonia.Platform.Storage.FilePickerFileType GetExtension(ExtensionType type)
		{

			return ExtensionMap.TryGetValue(type, out Avalonia.Platform.Storage.FilePickerFileType value) ? value : new Avalonia.Platform.Storage.FilePickerFileType("Unknown Type") { Patterns = new List<string> { "*.*" } };
		}

		/// <summary>
		/// returns the Filter String that provides the passed Types
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static IEnumerable<Avalonia.Platform.Storage.FilePickerFileType> BuildFilterString(ExtensionType[] types)
		{
			return from type in types
				   where ExtensionMap.ContainsKey(type)
				   select ExtensionMap[type];
		}

		/// <summary>
		/// Returns the Type of the passed File
		/// </summary>
		/// <param name="filename">The Filename you want to test</param>
		/// <returns></returns>
		public static ExtensionType GetExtension(string filename)
		{
			foreach (ExtensionType et in ExtensionMap.Keys)
			{
				Avalonia.Platform.Storage.FilePickerFileType ed = ExtensionMap[et];
			}

			return ExtensionType.AllFiles;
		}
	}
}
