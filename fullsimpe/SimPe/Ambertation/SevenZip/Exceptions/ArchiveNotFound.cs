// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

namespace Ambertation.SevenZip.Exceptions
{
	public class ArchiveNotFound : SevenZipException
	{
		public ArchiveNotFound(string aname)
			: base("Could not find the Archive \"" + aname + "\".")
		{
		}
	}
}
