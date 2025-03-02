// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.IO;

namespace Ambertation.XSI.IO
{
	public abstract class Header
	{
		public enum Format
		{
			txt,
			bin,
			com,
			unk
		}

		public enum Compression
		{
			lzw,
			zip,
			non
		}

		public const int MAGIC = 543781752;

		public const short MAJOR = 3;

		public const short MINOR = 0;

		public const int FLOAT = 32;

		protected int magic;

		protected short major;

		protected short minor;

		protected int floatsz;

		protected Format format;

		protected Compression compression;

		private bool valid;

		public short MajorVersion
		{
			get
			{
				return major;
			}
			set
			{
				major = value;
			}
		}

		public short MinorVersion
		{
			get
			{
				return minor;
			}
			set
			{
				minor = value;
			}
		}

		public int Version => (major << 16) + minor;

		public bool Valid => valid;

		internal Header()
		{
			magic = 543781752;
			minor = 0;
			major = 3;
			floatsz = 32;
			format = Format.unk;
			compression = Compression.non;
			valid = true;
		}

		protected Format ToFormat(string s)
		{
			switch (s)
			{
				case "txt ": return Format.txt;
				case "bin ": return Format.bin;
				case "com ": return Format.com;
				default: return Format.unk;
			}
		}

		protected Compression ToCompression(string s)
		{
			if (s == "zip ")
			{
				return Compression.zip;
			}

			if (s == "lzw ")
			{
				return Compression.lzw;
			}

			return Compression.non;
		}

		internal void DeSerialize(StreamReader sr)
		{
			valid = DeSerializeHeader(sr);
		}

		protected abstract bool DeSerializeHeader(StreamReader sr);

		internal abstract void Serialize(StreamWriter sw);
	}
}
