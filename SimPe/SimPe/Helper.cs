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
	/// Some Helper Functions frequently used in the handlers
	/// </summary>
	public static class Helper
	{
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
	}
}
