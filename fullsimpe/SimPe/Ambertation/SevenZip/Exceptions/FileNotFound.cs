// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.SevenZip.Exceptions
{
	public class FileNotFound : SevenZipException
	{
		public FileNotFound(string aname)
			: base("Could not find the File \"" + aname + "\".")
		{
		}
	}
}
