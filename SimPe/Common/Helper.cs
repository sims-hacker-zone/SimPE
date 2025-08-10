// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimPe.Common;

/// <summary>
/// Some Helper Functions frequently used in the handlers
/// </summary>
public static class Helper
{
	/// <summary>
	/// Removes all Characters that are not allowed in the String
	/// </summary>
	/// <param name="input">The String you want to change</param>
	/// <returns>the string without illegal Characters</returns>
	public static string RemoveUnlistedCharacters(string input)
	{
		HashSet<char> chars = new(Path.GetInvalidFileNameChars());
		return new(input.Where(c => !chars.Contains(c)).ToArray());
	}
}
