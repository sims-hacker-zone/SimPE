// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Data;

namespace SimPe.Extensions
{
	public struct FileTypeInformation
	{
		public FileTypes Type;
		public string ShortName;
		public string LongName;
		public string Extension;
		public bool ContainsFileName;

		public static bool operator ==(FileTypeInformation a, FileTypeInformation b)
		{
			return a.Type == b.Type;
		}

		public static bool operator !=(FileTypeInformation a, FileTypeInformation b)
		{
			return a.Type != b.Type;
		}

		public override bool Equals(object obj)
		{
			return obj is FileTypeInformation fti && Type == fti.Type;
		}

		public override string ToString()
		{
			return LongName;
		}

		public override int GetHashCode()
		{
			return Type.GetHashCode();
		}
	}
}
