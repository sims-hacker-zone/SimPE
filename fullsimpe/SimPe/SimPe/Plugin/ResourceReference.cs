using System;
using System.Globalization;

using SimPe.Interfaces.Files;

namespace SimPe.Plugin
{
	/// <summary>
	/// Helper class
	/// </summary>
	public sealed class ResourceReference
	{
		public uint Type;
		public uint Group;
		public uint Instance;
		public uint SubType;

		public IPackedFileDescriptor FileDescriptor
		{
			get;
		}

		public ResourceReference(IPackedFileDescriptor file)
		{
			Type = file.Type;
			Group = file.Group;
			Instance = file.Instance;
			SubType = file.SubType;
			FileDescriptor = file;
		}

		public override bool Equals(object obj)
		{
			return obj is ResourceReference sr && GetHashCode() == sr.GetHashCode();
		}

		public override int GetHashCode()
		{
			return BitConverter.ToInt32(
				BitConverter.GetBytes(
					Type ^ Group ^ SubType ^ Instance
				),
				0
			);
		}

		public override string ToString()
		{
			return string.Format(
				"{0:X8}-{1:X8}-{2:X8}-{3:X8}",
				Type,
				Group,
				SubType,
				Instance
			);
		}

		public static uint GetHash(IPackedFileDescriptor pfd)
		{
			return pfd.Type ^ pfd.Group ^ pfd.SubType ^ pfd.Instance;
		}

		public static ResourceReference Parse(string s)
		{
			ResourceReference ret = null;
			if (!Utility.IsNullOrEmpty(s))
			{
				string[] parts = s.Split(new char[] { '-' });
				if (parts.Length != 4)
				{
					throw new FormatException(
						"The specified string was not in the correct format for a ResourceReference"
					);
				}

				NumberStyles format =
					NumberStyles.AllowHexSpecifier | NumberStyles.HexNumber;
				ret.Type = uint.Parse(parts[0], format);
				ret.Group = uint.Parse(parts[1], format);
				ret.SubType = uint.Parse(parts[2], format);
				ret.Instance = uint.Parse(parts[3], format);
			}
			return ret;
		}
	}
}
