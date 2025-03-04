// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.Glob
{
	/// <summary>
	/// Named Glob File
	/// </summary>
	public class NamedGlob : Glob
	{
		public override string ToString()
		{
			return SemiGlobalName;
		}
	}
}
