// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for SearchItem.
	/// </summary>
	public class SearchItem
	{
		string flname;

		public SearchItem(Interfaces.Files.IPackedFileDescriptor pfd)
		{
			Descriptor = pfd;
			flname = null;
		}

		public SearchItem(string flname, Interfaces.Files.IPackedFileDescriptor pfd)
		{
			Descriptor = pfd;
			this.flname = flname;
		}

		public Interfaces.Files.IPackedFileDescriptor Descriptor
		{
			get;
		}

		public string FileName => flname ?? "";

		public override string ToString()
		{
			return flname == null ? Descriptor.ToString() : flname + ": " + Descriptor.ToString();
		}
	}
}
