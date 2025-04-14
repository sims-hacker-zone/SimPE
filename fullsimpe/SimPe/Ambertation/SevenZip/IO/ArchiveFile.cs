// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace Ambertation.SevenZip.IO
{
	public class ArchiveFile : IDisposable
	{
		private string name;

		private DateTime date;

		private long size;

		private long csize;

		public string Name => name;

		public DateTime CreationDate => date;

		public long UncompressedSize => size;

		public long CompressedSize => csize;

		internal ArchiveFile(string[] parts)
		{
			name = parts[5];
			try
			{
				size = Convert.ToInt64(parts[3]);
				csize = Convert.ToInt64(parts[4]);
			}
			catch
			{
				size = -1L;
			}

			date = DateTime.Parse(parts[0] + " " + parts[1]);
		}

		public override string ToString()
		{
			return name + " (size=" + size + "; csize=" + csize + "; date=" + date.ToShortDateString() + " " + date.ToShortTimeString() + ")";
		}

		public void Dispose()
		{
			name = null;
		}
	}
}
