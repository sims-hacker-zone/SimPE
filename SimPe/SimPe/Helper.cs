// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using SimPe.Data;
using SimPe.Views;

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
		/// Character used to Seperate Folders in a Path
		/// </summary>
		public const string PATH_SEP = "\\";

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
		public static string HexString(uint input)
		{
			return $"{input:X8}";
		}

		/// <summary>
		/// Removes all Characters that are not allowed in the String
		/// </summary>
		/// <param name="input">The String you want to change</param>
		/// <param name="allowed">A string coinatining all Allowed Characters</param>
		/// <returns>the string without illegal Characters</returns>
		public static string RemoveUnlistedCharacters(string input)
		{
			HashSet<char> chars = new(Path.GetInvalidFileNameChars());
			return new string(input.Where(c => !chars.Contains(c)).ToArray());
		}

		/// <summary>
		/// Shows an Exception Message for the User
		/// </summary>
		/// <param name="ex">The Exception</param>
		public static async Task ExceptionMessage(Exception ex)
		{
			await Message.Show($"{ex.Message}\n\n{ex.StackTrace}");
		}

		/// <summary>
		/// Shows an Exception Message for the User
		/// </summary>
		/// <param name="ex">The Exception</param>
		/// <param name="message">An operation Description (when did the Exception occur)</param>
		public static async Task ExceptionMessage(string message, Exception ex)
		{
			await Message.Show($"{message}\n\n{ex.Message}\n\n{ex.StackTrace}");
		}

		/// <summary>
		/// Returns the Path SimPe is located in
		/// </summary>
		public static string SimPePath => AppDomain.CurrentDomain.BaseDirectory;

		/// <summary>
		/// Returns the Path SimPe Plugins are located in
		/// </summary>
		public static string SimPePluginPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
					"Plugins"
				);

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


		/// <summary>
		/// Returns the Version Information for the started Executable
		/// </summary>
		public static System.Diagnostics.FileVersionInfo ExecutableVersion => System.Diagnostics.FileVersionInfo.GetVersionInfo(
					Environment.ProcessPath
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
		/// Returns a compareable Filename
		/// </summary>
		/// <param name="fl"></param>
		/// <returns></returns>
		public static string CompareableFileName(string fl)
		{
			return fl.Trim().TrimEnd(new char[] { '\\' }).ToLower();
		}
	}
}
