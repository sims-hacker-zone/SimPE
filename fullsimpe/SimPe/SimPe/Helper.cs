// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using SimPe.Data;
using SimPe.Forms.MainUI;

namespace SimPe
{
	/// <summary>
	/// Determins the Executable that was started
	/// </summary>
	public enum Executable : byte
	{
		Classic = 1,
		Default = 2,
		WizardsOfSimpe = 3,
		Other = 4,
	}

	/// <summary>
	/// Some Helper Functions frequently used in the handlers
	/// </summary>
	public static class Helper
	{
		/// <summary>
		/// Linebreaks
		/// </summary>
		public const string lbr = "\r\n";

		/// <summary>
		/// Tabs
		/// </summary>
		public const string tab = "    ";

		/// <summary>
		/// Characters allowd in a Filepath
		/// </summary>
		public const string PATH_CHARACTERS =
			"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz�0123456789.-_ �";

		/// <summary>
		/// Character used to Seperate Folders in a Path
		/// </summary>
		public const string PATH_SEP = "\\";

		/// <summary>
		/// Contains a Link to the Registry Object
		/// </summary>
		static Registry reg = null;

		/// <summary>
		/// Returns the Link to the Windows Registry
		/// </summary>
		public static Registry WindowsRegistry
		{
			get
			{
				if (reg == null)
				{
					reg = new Registry();
				}

				return reg;
			}
		}

		/// <summary>
		/// Creates a HexString (with Leading 0) of the given Length
		/// </summary>
		/// <param name="input">The HexFormated String with arbitrary Length</param>
		/// <param name="length">The min. Length for the String</param>
		/// <returns>The input String with added zeros.</returns>
		public static string MinStrLength(string input, int length)
		{
			while (input.Length < length)
			{
				input = "0" + input;
			}

			return input;
		}

		/// <summary>
		/// Creates a HexString (with Leading 0) of the given Length
		/// </summary>
		/// <param name="input">The HexFormated String with arbitrary Length</param>
		/// <param name="length">The min. Length for the String</param>
		/// <returns>The input String with added zeros.</returns>
		public static string StrLength(string input, int length)
		{
			while (input.Length < length)
			{
				input += "0";
			}

			if (input.Length > length)
			{
				input = input.Substring(0, length);
			}

			return input;
		}

		/// <summary>
		/// Creates a HexString (with Leading 0) of the given Length
		/// </summary>
		/// <param name="input">The HexFormated String with arbitrary Length</param>
		/// <param name="length">The min. Length for the String</param>
		/// <returns>The input String with added zeros.</returns>
		/// <param name="left">True, if you want to add from the left, and cut from the right</param>
		public static string StrLength(string input, int length, bool left)
		{
			if (left)
			{
				return StrLength(input, length);
			}

			while (input.Length < length)
			{
				input = "0" + input;
			}

			if (input.Length > length)
			{
				input = input.Substring(input.Length - length, length);
			}

			return input;
		}

		/// <summary>
		/// Returns the Value as HexString
		/// </summary>
		/// <param name="input">the Input Value</param>
		/// <returns>value as HexString (allways 8 Chars long)</returns>
		public static string HexStringInt(int input)
		{
			return HexString((uint)input);
		}

		/// <summary>
		/// Returns the Value as HexString
		/// </summary>
		/// <param name="input">the Input Value</param>
		/// <returns>value as HexString (allways 8 Chars long)</returns>
		public static string HexString(uint input)
		{
			return $"{input:X8}";
		}

		/// <summary>
		/// Returns the Value as HexString
		/// </summary>
		/// <param name="input">the Input Value</param>
		/// <returns>value as HexString (allways 8 Chars long)</returns>
		public static string HexString(FileTypes input)
		{
			return $"{(uint)input:X8}";
		}

		/// <summary>
		/// Returns the Value as HexString
		/// </summary>
		/// <param name="input">the Input Value</param>
		/// <returns>value as HexString (allways 4 Chars long)</returns>
		public static string HexString(short input)
		{
			return HexString((ushort)input);
		}

		/// <summary>
		/// Returns the Value as HexString
		/// </summary>
		/// <param name="input">the Input Value</param>
		/// <returns>value as HexString (allways 4 Chars long)</returns>
		public static string HexString(ushort input)
		{
			return $"{input:X4}";
		}

		/// <summary>
		/// Returns the Value as HexString
		/// </summary>
		/// <param name="input">the Input Value</param>
		/// <returns>value as HexString (allways 4 Chars long)</returns>
		public static string HexString(byte input)
		{
			return $"{input:X2}";
		}

		/// <summary>
		/// Returns the Value represented by the HexString
		/// </summary>
		/// <param name="txt">The hex String</param>
		/// <returns>the represented value</returns>
		public static uint HexStringToUInt(string txt)
		{
			return StringToUInt32(txt, 0, 16);
		}

		/// <summary>
		/// Returns the Value represented by the HexString
		/// </summary>
		/// <param name="txt">The hex String</param>
		/// <returns>the represented value</returns>
		public static uint StringToUInt32(string txt, uint def, byte bbase)
		{
			try
			{
				return Convert.ToUInt32(txt, bbase);
			}
			catch
			{
				return def;
			}
		}

		/// <summary>
		/// Returns the Value represented by the HexString
		/// </summary>
		/// <param name="txt">The hex String</param>
		/// <returns>the represented value</returns>
		public static float StringToFloat(string txt, float def)
		{
			try
			{
				return Convert.ToSingle(txt);
			}
			catch
			{
				return def;
			}
		}

		/// <summary>
		/// Returns the Value represented by the HexString
		/// </summary>
		/// <param name="txt">The hex String</param>
		/// <returns>the represented value</returns>
		public static int StringToInt32(string txt, int def, byte bbase)
		{
			try
			{
				return Convert.ToInt32(txt, bbase);
			}
			catch
			{
				return def;
			}
		}

		/// <summary>
		/// Returns the Value represented by the HexString
		/// </summary>
		/// <param name="txt">The hex String</param>
		/// <returns>the represented value</returns>
		public static ushort StringToUInt16(string txt, ushort def, byte bbase)
		{
			try
			{
				return Convert.ToUInt16(txt, bbase);
			}
			catch
			{
				return def;
			}
		}

		/// <summary>
		/// Returns the Value represented by the HexString
		/// </summary>
		/// <param name="txt">The hex String</param>
		/// <returns>the represented value</returns>
		public static short StringToInt16(string txt, short def, byte bbase)
		{
			try
			{
				return Convert.ToInt16(txt, bbase);
			}
			catch
			{
				return def;
			}
		}

		/// <summary>
		/// Returns the Value represented by the HexString
		/// </summary>
		/// <param name="txt">The hex String</param>
		/// <returns>the represented value</returns>
		public static byte StringToByte(string txt, byte def, byte bbase)
		{
			try
			{
				return Convert.ToByte(txt, bbase);
			}
			catch
			{
				return def;
			}
		}

		/// <summary>
		/// Removes all Characters that are not allowed in the String
		/// </summary>
		/// <param name="input">The String you want to change</param>
		/// <param name="allowed">A string coinatining all Allowed Characters</param>
		/// <returns>the string without illegal Characters</returns>
		public static string RemoveUnlistedCharacters(string input, string allowed)
		{
			string output = "";
			for (int i = 0; i < input.Length; i++)
			{
				char c = input[i];
				if (allowed.IndexOf(c) != -1)
				{
					output += c;
				}
			}

			return output;
		}

		/// <summary>
		/// Shows an Exception Message for the User
		/// </summary>
		/// <param name="ex">The Exception</param>
		public static void ExceptionMessage(Exception ex)
		{
			MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}");
		}

		/// <summary>
		/// Shows an Exception Message for the User
		/// </summary>
		/// <param name="ex">The Exception</param>
		/// <param name="message">An operation Description (when did the Exception occur)</param>
		public static void ExceptionMessage(string message, Exception ex)
		{
			MessageBox.Show($"{message}\n\n{ex.Message}\n\n{ex.StackTrace}");
		}

		/// <summary>
		/// Creates a String from an Object
		/// </summary>
		/// <param name="o">The Input Object</param>
		/// <returns>The stored value as String</returns>
		public static string ToString(object o)
		{
			return o == null ? "" : o.ToString();
		}

		/// <summary>
		/// Returns the Path SimPe is located in
		/// </summary>
		public static string SimPePath => Path.GetDirectoryName(
					System.Windows.Forms.Application.ExecutablePath
				);

		/// <summary>
		/// Returns the Path SimPe Plugins are located in
		/// </summary>
		public static string SimPePluginPath => Path.Combine(
					Path.GetDirectoryName(
						System.Windows.Forms.Application.ExecutablePath
					),
					"Plugins"
				);

		/// <summary>
		/// Returns the Path for SimPe Teleports
		/// </summary>
		public static string SimPeTeleportPath
		{
			get
			{
				string dir = Path.Combine(
					Path.Combine(
						Environment.GetFolderPath(
							Environment.SpecialFolder.ApplicationData
						),
						"SimPe"
					),
					"Teleport"
				);
				// string dir = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "Teleport");
				try
				{
					if (!Directory.Exists(dir))
					{
						Directory.CreateDirectory(dir);
					}
				}
				catch { }
				return dir;
			}
		}

		/// <summary>
		/// Returns the Name of a Language Cache File with the passed Prefix
		/// </summary>
		/// <param name="prefix"></param>
		/// <returns></returns>
		public static string GetSimPeLanguageCache(string prefix)
		{
			return WindowsRegistry.Config.LoadOnlySimsStory > 0
				? Path.Combine(
					SimPeDataPath,
					prefix
						+ HexString((byte)WindowsRegistry.Config.LanguageCode)
						+ Convert.ToString(WindowsRegistry.Config.LoadOnlySimsStory)
						+ ".simpepkg"
				)
				: Path.Combine(
					SimPeDataPath,
					prefix
						+ HexString((byte)WindowsRegistry.Config.LanguageCode)
						+ ".simpepkg"
				);
		}

		/// <summary>
		/// Returns the Name of the Cache File for the current Language
		/// </summary>
		public static string SimPeLanguageCache => GetSimPeLanguageCache("objcache_");

		/// <summary>
		/// Outdated, use SimPeLanguageCache
		/// Returns the Name of a Cache File with the passed Prefix
		/// </summary>
		/// <param name="prefix"></param>
		/// <returns></returns>
		public static string GetSimPeCache(string prefix)
		{
			return Path.Combine(SimPeDataPath, prefix + ".simpepkg");
		}

		/// <summary>
		/// Outdated, use SimPeLanguageCache
		/// Returns the Name of the Language independent Cache File
		/// </summary>
		public static string SimPeCache => GetSimPeCache("objcache");

		public static string Profile { get; set; } = "";

		/// <summary>
		/// Returns the Path additional SimPe Files are located in
		/// </summary>
		public static string SimPeDataPath
		{
			get
			{
				string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe", "Data");
				try
				{
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
				}
				catch { }
				return path;
			}
		}

		public class DataFolder
		{
			/// <summary>
			/// The folder containing profiles
			/// </summary>
			public static string Profiles
			{
				get
				{
					string path = Path.Combine(SimPeDataPath, "Profiles");
					try
					{
						if (!Directory.Exists(path))
						{
							Directory.CreateDirectory(path);
						}
					}
					catch { }
					return path;
				}
			}

			static string ProfilePath(string s)
			{
				return ProfilePath(s, false);
			}

			static string ProfilePath(string s, bool readOnly)
			{
				string path = SimPeDataPath;
				if (Profile.Length > 0 && readOnly)
				{
					path = Path.Combine(Path.Combine(path, "Profiles"), Profile);
				}

				return Path.Combine(path, s);
			}

			/// <summary>
			/// The path of the filetable folders file (write)
			/// </summary>
			public static string FoldersXREGW => ProfilePath("folders.xreg");

			/// <summary>
			/// The path of the filetable folders file (readonly)
			/// </summary>
			public static string FoldersXREG => ProfilePath("folders.xreg", true);

			/// <summary>
			/// The path of the filetable folders file (write)
			/// </summary>
			public static string ExpansionsXREGW => ECCorNewSEfound ? ProfilePath("expansions2.xreg") : ProfilePath("expansions.xreg");

			/// <summary>
			/// The path of the filetable folders file (readonly)
			/// </summary>
			public static string ExpansionsXREG => ECCorNewSEfound ? ProfilePath("expansions2.xreg", true) : ProfilePath("expansions.xreg", true);
		}

		/// <summary>
		/// Returns the Path additional SimPe Files are located in
		/// </summary>
		public static string SimPePluginDataPath
		{
			get
			{
				string path = Path.Combine(SimPeDataPath, "Plugins");
				try
				{
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
				}
				catch { }
				return path;
			}
		}

		/// <summary>
		/// Returns the File, that holds the users Viewport Data
		/// </summary>
		public static string SimPeViewportFile => Path.Combine(SimPeDataPath, "vport.set");

		public static string SimPeSemiGlobalFile => Path.Combine(SimPeDataPath, "semiglobals.xml");

		/// <summary>
		/// Bit number identifying what's been "enabled" on the commandline
		/// </summary>
		private enum RunModeFlags : int
		{
			localmode = 0,
			noplugins,
			fileformat,
			noerrors,
			anypackage,
		}; // bit number

		private static Boolset RunModeFlag = 0;

		/// <summary>
		/// "localmode": when true, do not load the file table
		/// </summary>
		public static bool LocalMode
		{
			get => RunModeFlag[(int)RunModeFlags.localmode];
			set => RunModeFlag[(int)RunModeFlags.localmode] = value;
		}

		/// <summary>
		/// "noplugins": when true, do not load plugins (other than core)
		/// </summary>
		public static bool NoPlugins
		{
			get => RunModeFlag[(int)RunModeFlags.noplugins];
			set => RunModeFlag[(int)RunModeFlags.noplugins] = value;
		}

		/// <summary>
		/// "fileformat": when true, prefix filenames with their format, when known (for PJSE wrappers at this stage)
		/// </summary>
		public static bool FileFormat
		{
			get => RunModeFlag[(int)RunModeFlags.fileformat];
			set => RunModeFlag[(int)RunModeFlags.fileformat] = value;
		}

		/// <summary>
		/// "noerrors": when true, suppress ExceptionMessage dialog
		/// </summary>
		public static bool NoErrors
		{
			get => RunModeFlag[(int)RunModeFlags.noerrors];
			set => RunModeFlag[(int)RunModeFlags.noerrors] = value;
		}

		/// <summary>
		/// "anypackage": when true, allow packages to be opened regardless of DBPF version number
		/// </summary>
		public static bool AnyPackage
		{
			get => RunModeFlag[(int)RunModeFlags.anypackage];
			set => RunModeFlag[(int)RunModeFlags.anypackage] = value;
		}

		/// <summary>
		/// Indicates whether a given plugin should load, based on "noplugins" command line option
		/// </summary>
		/// <param name="flname">plugin name to test</param>
		/// <returns>true if okay to load, else false</returns>
		public static bool CanLoadPlugin(string flname)
		{
			return !NoPlugins; /*
			if (!NoPlugins) return true;
			// flname = flname.Trim().ToLower();
			// if (flname.Contains("\\pj")) return true;
			// if (flname.Contains("systemclasses")) return true;
			// if (flname.Contains("simpe.dockbox")) return true;
			return false; */
		}

		/// <summary>
		/// Returns the Version Information for the started Executable
		/// </summary>
		public static System.Diagnostics.FileVersionInfo ExecutableVersion => System.Diagnostics.FileVersionInfo.GetVersionInfo(
					System.Windows.Forms.Application.ExecutablePath
				);

		/// <summary>
		/// Returns the the overall SimPe Version
		/// </summary>
		public static System.Diagnostics.FileVersionInfo SimPeVersion
		{
			get
			{
				try
				{
					return System.Diagnostics.FileVersionInfo.GetVersionInfo(
						typeof(Helper).Assembly.Location
					);
				}
				catch
				{
					return ExecutableVersion;
				}
			}
		}

		/// <summary>
		/// Returns the long Version Number
		/// </summary>
		public static long SimPeVersionLong => VersionToLong(SimPeVersion);

		/// <summary>
		/// Returns the long Version Number
		/// </summary>
		public static long VersionToLong(System.Diagnostics.FileVersionInfo ver)
		{
			long lver = ver.FileMajorPart;
			lver = (lver << 16) + ver.FileMinorPart;
			lver = (lver << 16) + ver.FileBuildPart;
			lver = (lver << 16) + ver.FilePrivatePart;
			return lver;
		}

		/// <summary>
		/// Formats the Version and returns it
		/// </summary>
		/// <param name="ver"></param>
		/// <returns></returns>
		public static string VersionToString(System.Diagnostics.FileVersionInfo ver)
		{
			return ver.FileMajorPart
				+ "."
				+ ver.FileMinorPart
				+ "."
				+ ver.FileBuildPart
				+ "."
				+ ver.FilePrivatePart;
		}

		/// <summary>
		/// Returns the Version Number as Text
		/// </summary>
		public static string SimPeVersionString
		{
			get
			{
				System.Diagnostics.FileVersionInfo ver = SimPeVersion;
				return VersionToString(ver);
			}
		}

		/// <summary>
		/// true if this is a QA Release
		/// </summary>
		public static bool QARelease => (SimPeVersion.ProductMinorPart % 2) == 1;

		/// <summary>
		/// true if Extra Stuff or New Store Editon enabled
		/// </summary>
		public static bool ECCorNewSEfound
		{
			get
			{
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					Microsoft.Win32.RegistryKey tk =
						Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
							"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\Sims2ECC.exe",
							false
						);
					if (tk != null)
					{
						return true;
					}

					tk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
						"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\Sims2SC.exe",
						false
					);
					if (tk == null)
					{
						return false;
					}

					object gr = tk.GetValue("Game Registry", "");
					Microsoft.Win32.RegistryKey rk =
						Microsoft.Win32.Registry.LocalMachine.OpenSubKey((string)gr, false);
					if (rk != null)
					{
						object o = rk.GetValue("Suppression Exe", "");
						string s = o.ToString();
						if (s.Contains("Sims2EP8.exe"))
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		/// Returnst the Gui that was started
		/// </summary>
		public static Executable StartedGui => WindowsRegistry.Config.Layout.IsClassicPreset ? Executable.Classic
					: System
											.Windows.Forms.Application.ExecutablePath.Trim()
											.ToLower()
											.EndsWith("wizards of simpe.exe")
						? Executable.WizardsOfSimpe
						: System
																.Windows.Forms.Application.ExecutablePath.Trim()
																.ToLower()
																.EndsWith("simpe.exe")
											? Executable.Default
											: Executable.Other;

		/// <summary>
		/// Creates a String from a byte Array
		/// </summary>
		/// <param name="data">The Byte Array</param>
		/// <returns>the String Representation</returns>
		public static string ToString(byte[] data)
		{
			if (data == null)
			{
				return "";
			}

			string text = "";
			BinaryReader ms = new BinaryReader(new MemoryStream(data));
			try
			{
				while (ms.BaseStream.Position < ms.BaseStream.Length)
				{
					if (ms.PeekChar() == 0)
					{
						break;
					}

					if (ms.PeekChar() == -1)
					{
						break;
					}

					text += ms.ReadChar();
				}
			}
			catch (Exception) { }

			return text;
		}

		/// <summary>
		/// Returns the passed String as a Byte Array of the given Length
		/// </summary>
		/// <param name="str">The String to Convert</param>
		/// <returns>A Byte Array of the given Length (filled with 0)</returns>
		public static byte[] ToBytes(string str)
		{
			return ToBytes(str, 0);
		}

		/// <summary>
		/// Returns the passed String as a Byte Array of the given Length
		/// </summary>
		/// <param name="str">The String to Convert</param>
		/// <param name="len">Length of the Array (the returned Array will have this exact Length)</param>
		/// <returns>A Byte Array of the given Length (filled with 0)</returns>
		public static byte[] ToBytes(string str, int len)
		{
			/*System.IO.MemoryStream ms = new MemoryStream();
			System.IO.BinaryWriter bw = new BinaryWriter(ms);
			foreach (char c in str)
			{
				if ((len==0) || (bw.BaseStream.Position<len)) bw.Write(c);
			}
			if (len!=0) ms.SetLength(len);

			bw.Flush();
			System.IO.BinaryReader br = new BinaryReader(ms);
			br.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
			ret = br.ReadBytes((int)br.BaseStream.Length);*/

			byte[] ret = null;
			if (len != 0)
			{
				ret = new byte[len];
				Encoding.ASCII.GetBytes(
					str,
					0,
					Math.Min(len, str.Length),
					ret,
					0
				);
			}
			else
			{
				ret = Encoding.ASCII.GetBytes(str);
			}

			return ret;
		}

		/// <summary>
		/// Copy a Complete directory
		/// </summary>
		/// <param name="sourcePath"></param>
		/// <param name="destinationPath"></param>
		/// <param name="recurse"></param>
		/// <remarks>created by Mark (daviesma@qca.org.uk)</remarks>
		public static void CopyDirectory(
			string sourcePath,
			string destinationPath,
			bool recurse
		)
		{
			string[] files;
			if (
				destinationPath[destinationPath.Length - 1]
				!= Path.DirectorySeparatorChar
			)
			{
				destinationPath += Path.DirectorySeparatorChar;
			}

			if (!Directory.Exists(destinationPath))
			{
				Directory.CreateDirectory(destinationPath);
			}

			files = Directory.GetFileSystemEntries(sourcePath);
			foreach (string element in files)
			{
				// lets not back up or restore the useless extra backup files
				if (!element.EndsWith(".bkp"))
				{
					if (recurse)
					{
						// copy sub directories (recursively)
						if (Directory.Exists(element))
						{
							CopyDirectory(
								element,
								destinationPath + Path.GetFileName(element),
								recurse
							);
						}
						// copy files in directory
						else
						{
							File.Copy(
								element,
								destinationPath + Path.GetFileName(element),
								true
							);
						}
					}
					else
					{
						// only copy files in directory
						if (!Directory.Exists(element))
						{
							File.Copy(
								element,
								destinationPath + Path.GetFileName(element),
								true
							);
						}
					}
				}
			}
		}

		/// <summary>
		/// Returns the Language Code that matches the Sims2 Language first
		/// if not then Returns the Language Code that matches the current Culture best
		/// </summary>
		/// <returns>The language Code</returns>
		public static Languages GetMatchingLanguage()
		{
			Languages lng = Languages.English;
			switch (PathProvider.Global.InGameLang)
			{
				case "US English":
					return Languages.English;
				case "French":
					return Languages.French;
				case "German":
					return Languages.German;
				case "Italian":
					return Languages.Italian;
				case "Spanish":
					return Languages.Spanish;
				case "Swedish":
					return Languages.Swedish;
				case "Finnish":
					return Languages.Finnish;
				case "Dutch":
					return Languages.Dutch;
				case "Danish":
					return Languages.Danish;
				case "Brazilian Portuguese":
					return Languages.Brazilian;
				case "Czech":
					return Languages.Czech;
				case "Japanese":
					return Languages.Japanese;
				case "Korean":
					return Languages.Korean;
				case "Russian":
					return Languages.Russian;
				case "Simplified Chinese":
					return Languages.SimplifiedChinese;
				case "Traditional Chinese":
					return Languages.TraditionalChinese;
				case "English":
					return Languages.English_uk;
				case "Polish":
					return Languages.Polish;
				case "Thai":
					return Languages.Thai;
				case "Norwegian":
					return Languages.Norwegian;
				case "Portuguese":
					return Languages.Portuguese;
				case "Hungarian":
					return Languages.Hungarian;
			}

			switch (System.Threading.Thread.CurrentThread.CurrentCulture.ThreeLetterISOLanguageName.ToUpper())
			{
				case "ENA":
					return Languages.English_uk;
				case "ENG":
					return Languages.English_uk;
				case "ENZ":
					return Languages.English_uk;
				case "ENS":
					return Languages.English_uk;
				case "ENC":
					return Languages.English_uk;
				case "ENU":
					return Languages.English;
				case "DEU":
					return Languages.German;
				case "ESP":
					return Languages.Spanish;
				case "FIN":
					return Languages.Finnish;
				case "CHS":
					return Languages.SimplifiedChinese;
				case "CHT":
					return Languages.TraditionalChinese;
				case "FRE":
					return Languages.French;
				case "JPN":
					return Languages.Japanese;
				case "ITA":
					return Languages.Italian;
				case "DUT":
					return Languages.Dutch;
				case "DAN":
					return Languages.Danish;
				case "NOR":
					return Languages.Norwegian;
				case "RUS":
					return Languages.Russian;
				case "POR":
					return Languages.Portuguese;
				case "POL":
					return Languages.Polish;
				case "THA":
					return Languages.Thai;
				case "KOR":
					return Languages.Korean;
				case "HUN":
					return Languages.Hungarian;
			}

			return lng;
		}

		/// <summary>
		/// Creates a HexList from teh Byte Array
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static string BytesToHexList(byte[] data)
		{
			return BytesToHexList(data, -1);
		}

		/// <summary>
		/// Creates a HexList from teh Byte Array
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static string BytesToHexList(byte[] data, int dwordperrow)
		{
			if (dwordperrow > 0)
			{
				dwordperrow++;
			}

			string s = "";
			int dwords = 0;
			for (int i = 0; i < data.Length; i++)
			{
				byte b = data[i];
				s += HexString(b) + " ";
				if (i % 4 == 3)
				{
					s += " ";
					dwords++;
				}
				if (dwordperrow > 0)
				{
					if (dwords % dwordperrow == dwordperrow - 1)
					{
						dwords = 0;
						s += lbr;
					}
				}
			}
			return s.Trim();
		}

		/// <summary>
		/// Converts a string like "AF 23 12 B3" to a Byte Array
		/// </summary>
		/// <param name="hexlist"></param>
		/// <returns>The Byte Array</returns>
		public static byte[] HexListToBytes(string hexlist)
		{
			while (hexlist.IndexOf("  ") != -1)
			{
				hexlist = hexlist.Replace("  ", " ");
			}

			string[] tokens = hexlist.Split(" ".ToCharArray());
			byte[] data = new byte[tokens.Length];

			for (int i = 0; i < tokens.Length; i++)
			{
				data[i] = tokens[i].Trim() != "" ? Convert.ToByte(tokens[i], 16) : (byte)0;
			}
			return data;
		}

		/// <summary>
		/// Changes the Length of the ByteArray
		/// </summary>
		/// <param name="array"></param>
		/// <param name="len"></param>
		/// <returns></returns>
		public static byte[] SetLength(byte[] array, int len)
		{
			if (array.Length == len)
			{
				return array;
			}

			byte[] ret = new byte[len];
			for (int i = 0; i < Math.Min(array.Length, ret.Length); i++)
			{
				ret[i] = array[i];
			}

			return ret;
		}

		/// <summary>
		/// Returns true, if the Helper dll was compiled with the DEBUG Flag
		/// </summary>
		public static bool DebugMode => WindowsRegistry.Config.HiddenMode;

		/// <summary>
		/// Returns filename of the Main Neighborhood
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		private const string NEIGHBORHOOD_PACKAGE = "_neighborhood.package";

		public static string GetMainNeighborhoodFile(string filename)
		{
			if (filename == null)
			{
				return "";
			}

			string flname = Path.GetFileName(filename);
			flname = flname.Trim().ToLower();

			if (flname.EndsWith(NEIGHBORHOOD_PACKAGE))
			{
				return filename;
			}

			flname = Path.GetFileNameWithoutExtension(flname);
			string[] parts = flname.Split(new char[] { '_' }, 2);
			return parts.Length == 0
				? filename
				: Path.Combine(
				Path.GetDirectoryName(filename),
				parts[0] + NEIGHBORHOOD_PACKAGE
			);
		}
		static List<string> KnownHoods => new List<string>
		{
			"university",
			"downtown",
			"suburb",
			"vacation",
			"tutorial"
		};

		/// <summary>
		/// Returns true if this is a Neighborhood File
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		public static bool IsNeighborhoodFile(string filename)
		{
			filename = Path.GetFileName(filename)?.Trim().ToLower();
			return filename != null
					&& filename != ""
					&& (filename.Contains(NEIGHBORHOOD_PACKAGE)
						|| KnownHoods.Any(hood => filename.Contains("_" + hood + "0")
								&& filename.EndsWith(".package")));
		}

		/// <summary>
		/// Returns true if this file is in the Lot Catalogue
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		public static bool IsLotCatalogFile(string filename)
		{
			if (filename == null || filename == "")
			{
				return false;
			}

			if (Path.GetDirectoryName(filename).EndsWith("LotCatalog"))
			{
				filename = Path.GetFileName(filename);
				filename = filename.Trim().ToLower();
				if (filename.StartsWith("cx_00"))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Returns either the Game Path or the installation Path of the EP if found
		/// </summary>
		/// <returns></returns>
		public static string NewestGamePath => PathProvider.Global.Latest.InstallFolder;

		/// <summary>
		/// Returns a Save FileName
		/// </summary>
		/// <param name="flname"></param>
		/// <returns></returns>
		public static string SaveFileName(string flname)
		{
			if (flname == null)
			{
				flname = "";
			}

			flname = flname.Replace("\\", "_");
			flname = flname.Replace("/", "_");
			flname = flname.Replace(":", "_");
			return flname;
		}

		/// <summary>
		/// Compares tow Filenames, or parts of FileNames
		/// </summary>
		/// <param name="fl1"></param>
		/// <param name="fl2"></param>
		/// <returns></returns>
		public static bool EqualFileName(string fl1, string fl2)
		{
			return fl1.Trim().ToLower() == fl2.Trim().ToLower();
		}

		public static bool IsAbsolutePath(string path)
		{
			return path != null && path.Trim().IndexOf(":") == 1;
		}

		/// <summary>
		/// Returns a compareable Filename
		/// </summary>
		/// <param name="fl"></param>
		/// <returns></returns>
		public static string CompareableFileName(string fl)
		{
			return fl.Trim().TrimEnd(new char[] { '\\' }).ToLower();
		}

		#region Folders

		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		static extern uint GetLongPathName(
			string lpszShortPath,
			[Out] StringBuilder lpszLongPath,
			uint cchBuffer
		);

		/// <summary>
		/// The ToShortPathNameToLongPathName function retrieves the long path form of a specified short input path
		/// </summary>
		/// <param name="shortName">The short name path</param>
		/// <returns>A long name path string</returns>
		public static string ToLongPathName(string shortName)
		{
			if (!Directory.Exists(shortName))
			{
				return shortName.Trim().ToLower();
			}

			StringBuilder longNameBuffer = new StringBuilder(256);
			uint bufferSize = (uint)longNameBuffer.Capacity;

			GetLongPathName(shortName, longNameBuffer, bufferSize);

			return longNameBuffer.ToString();
		}

		public static string ToLongFileName(string shortName)
		{
			return Path.Combine(
				ToLongPathName(Path.GetDirectoryName(shortName)),
				Path.GetFileName(shortName)
			);
		}

		#endregion

#pragma warning disable IDE0046
		public static System.Windows.Forms.Keys ToKeys(System.Windows.Forms.Shortcut sc)
		{
			System.Windows.Forms.Keys ret = System.Windows.Forms.Keys.None;
			string name = sc.ToString().ToLower();

			if (name == "none")
			{
				return ret;
			}

			SetKey(ref ret, ref name, "ctrl", System.Windows.Forms.Keys.Control);
			SetKey(ref ret, ref name, "shift", System.Windows.Forms.Keys.Shift);
			SetKey(ref ret, ref name, "alt", System.Windows.Forms.Keys.Alt);
			SetKey(ref ret, ref name, "ins", System.Windows.Forms.Keys.Insert);
			SetKey(ref ret, ref name, "del", System.Windows.Forms.Keys.Delete);
			SetKey(ref ret, ref name, "bksp", System.Windows.Forms.Keys.Back);

			if (SetKey(ref ret, ref name, "uparrow", System.Windows.Forms.Keys.Up))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "downarrow", System.Windows.Forms.Keys.Down))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "leftarrow", System.Windows.Forms.Keys.Left))
			{
				return ret;
			}

			if (
				SetKey(ref ret, ref name, "rightarrow", System.Windows.Forms.Keys.Right)
			)
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f1", System.Windows.Forms.Keys.F1))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f2", System.Windows.Forms.Keys.F2))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f3", System.Windows.Forms.Keys.F3))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f4", System.Windows.Forms.Keys.F4))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f5", System.Windows.Forms.Keys.F5))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f6", System.Windows.Forms.Keys.F6))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f7", System.Windows.Forms.Keys.F7))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f8", System.Windows.Forms.Keys.F8))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f9", System.Windows.Forms.Keys.F9))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f10", System.Windows.Forms.Keys.F10))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f11", System.Windows.Forms.Keys.F11))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f12", System.Windows.Forms.Keys.F12))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "1", System.Windows.Forms.Keys.D1))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "2", System.Windows.Forms.Keys.D2))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "3", System.Windows.Forms.Keys.D3))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "4", System.Windows.Forms.Keys.D4))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "5", System.Windows.Forms.Keys.D5))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "6", System.Windows.Forms.Keys.D6))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "7", System.Windows.Forms.Keys.D7))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "8", System.Windows.Forms.Keys.D8))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "9", System.Windows.Forms.Keys.D9))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "0", System.Windows.Forms.Keys.D0))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "a", System.Windows.Forms.Keys.A))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "b", System.Windows.Forms.Keys.B))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "c", System.Windows.Forms.Keys.C))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "d", System.Windows.Forms.Keys.D))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "e", System.Windows.Forms.Keys.E))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "f", System.Windows.Forms.Keys.F))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "g", System.Windows.Forms.Keys.G))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "h", System.Windows.Forms.Keys.H))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "i", System.Windows.Forms.Keys.I))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "j", System.Windows.Forms.Keys.J))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "k", System.Windows.Forms.Keys.K))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "l", System.Windows.Forms.Keys.L))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "m", System.Windows.Forms.Keys.M))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "n", System.Windows.Forms.Keys.N))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "o", System.Windows.Forms.Keys.O))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "p", System.Windows.Forms.Keys.P))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "q", System.Windows.Forms.Keys.Q))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "r", System.Windows.Forms.Keys.R))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "s", System.Windows.Forms.Keys.S))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "t", System.Windows.Forms.Keys.T))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "u", System.Windows.Forms.Keys.U))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "v", System.Windows.Forms.Keys.V))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "w", System.Windows.Forms.Keys.W))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "x", System.Windows.Forms.Keys.X))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "y", System.Windows.Forms.Keys.Y))
			{
				return ret;
			}

			if (SetKey(ref ret, ref name, "z", System.Windows.Forms.Keys.Z))
			{
				return ret;
			}

			return ret;
		}

		private static bool SetKey(
			ref System.Windows.Forms.Keys ret,
			ref string name,
			string capt,
			System.Windows.Forms.Keys key
		)
		{
			if (name.IndexOf(capt) >= 0)
			{
				name = name.Replace(capt, "");
				ret |= key;

				//System.Diagnostics.Debug.WriteLine(name+": "+ret);
				return true;
			}

			return false;
		}
	}
}
