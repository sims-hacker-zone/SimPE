// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using Classless.Hasher;

namespace SimPe
{
	/// <summary>
	/// Contains needed Hash Algorithms
	/// </summary>
	public class Hashes
	{
		public static CRC Crc24 { get; } = new CRC(CRCParameters.GetParameters(CRCStandard.CRC24));

		public static CRC Crc32
		{
			get;
		} = new CRC(
			new CRCParameters(32, 0x04C11DB7, 0xffffffff, 0, false)
		);

		public static CRC Crc32_cas
		{
			get;
		} = new CRC(
			CRCParameters.GetParameters(CRCStandard.CRC32_CAS)
		);

		/// <summary>
		/// Seed Value for Group CRC-24 hash
		/// </summary>
		public const uint CRC24Seed = 0x00B704CE;

		/// <summary>
		/// Poly Value for CRC-24 Hash
		/// </summary>
		public const uint CRC24Poly = 0x01864CFB;

		/// <summary>
		/// Seed Value for Group CRC-32 hash
		/// </summary>
		public const uint CRC32Seed = 0x00B704CE;

		/// <summary>
		/// Poly Value for CRC-32 Hash
		/// </summary>
		public const uint CRC32Poly = 0x01864CFB;

		/// <summary>
		/// Returns the CRC24 Hash of a byte Array
		/// </summary>
		/// <param name="seed"></param>
		/// <param name="poly"></param>
		/// <param name="octets"></param>
		/// <returns>The CRS-24 hash Value</returns>
		public static long CRC24(uint seed, uint poly, char[] octets)
		{
			long crc = seed;
			int i;

			for (int index = 0; index < octets.Length; index++)
			{
				crc ^= octets[index] << 16;
				for (i = 0; i < 8; i++)
				{
					crc <<= 1;
					if ((crc & 0x1000000) != 0)
					{
						crc ^= poly;
					}
				}
			}
			return crc & 0x00ffffff;
		}

		public static ulong ToLong(byte[] input)
		{
			ulong ret = 0;
			foreach (byte b in input)
			{
				ret <<= 8;
				ret += b;
			}

			return ret;
		}

		/// <summary>
		/// Returns the Group hash for a File
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static uint FileGroupHash(string filename)
		{
			return Data.MetaData.CUSTOM_GROUP;
			/*filename = filename.Trim().ToLower();
			byte[] rt = crc24.ComputeHash(Helper.ToBytes(filename, 0));//CRC24Seed, CRC24Poly, filename.ToCharArray());

			return (uint)(ToLong(rt) | 0x7f000000);*/
		}

		/// <summary>
		/// Returns the NREF Group Hash
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static uint GroupHash(string name)
		{
			name = name.Trim().ToLower();
			byte[] rt = Crc24.ComputeHash(Helper.ToBytes(name, 0)); //CRC24Seed, CRC24Poly, filename.ToCharArray());

			return (uint)(ToLong(rt) | 0x7f000000);
		}

		/// <summary>
		/// Returns the Instance Hash for a File
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static uint InstanceHash(string filename)
		{
			filename = filename.Trim().ToLower();
			byte[] rt = Crc24.ComputeHash(Helper.ToBytes(filename, 0)); //CRC24Seed, CRC24Poly, filename.ToCharArray());

			return (uint)(ToLong(rt) | 0xff000000);
		}

		/// <summary>
		/// Returns the Instance Hash for a File
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static uint SubTypeHash(string filename)
		{
			filename = filename.Trim().ToLower();
			byte[] rt = Crc32.ComputeHash(Helper.ToBytes(filename, 0)); //CRC24Seed, CRC24Poly, filename.ToCharArray());

			return (uint)ToLong(rt);
		}

		/// <summary>
		/// Returns a CRC32CAS hash for the passed string
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static uint GetCrc32CAS(string s)
		{
			byte[] rt = Crc32_cas.ComputeHash(Helper.ToBytes(s, 0)); //CRC24Seed, CRC24Poly, filename.ToCharArray());

			return (uint)ToLong(rt);
		}

		/// <summary>
		/// Returns a CRC32 hash for the passed string
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static uint GetCrc32(string s)
		{
			byte[] rt = Crc32.ComputeHash(Helper.ToBytes(s, 0)); //CRC24Seed, CRC24Poly, filename.ToCharArray());

			return (uint)ToLong(rt);
		}

		/// <summary>
		/// Returns a crc24 hash for the string
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static uint GetCrc24(string s)
		{
			byte[] rt = Crc24.ComputeHash(Helper.ToBytes(s, 0)); //CRC24Seed, CRC24Poly, filename.ToCharArray());

			return (uint)ToLong(rt);
		}

		/// <summary>
		/// Retruns the Filename without the Hash
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static string StripHashFromName(string filename)
		{
			if (filename == null)
			{
				return "";
			}

			if (filename.IndexOf("#") == 0)
			{
				if (filename.IndexOf("!") >= 1)
				{
					string[] part = filename.Split("!".ToCharArray(), 2);
					return part[1];
				}
			}

			return filename;
		}

		/// <summary>
		/// Retruns the Group Specified by the Group Hash
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="defgroup"></param>
		/// <returns></returns>
		public static uint GetHashGroupFromName(string filename, uint defgroup)
		{
			if (filename.IndexOf("#") == 0)
			{
				if (filename.IndexOf("!") >= 1)
				{
					string[] part = filename.Split("!".ToCharArray(), 2);

					string hash = part[0].Replace("#", "").Replace("!", "");
					try
					{
						return Convert.ToUInt32(hash, 16);
					}
					catch (Exception)
					{
						return defgroup;
					}
				}
			}

			return defgroup;
		}

		/// <summary>
		/// Creates a hashed Filename
		/// </summary>
		/// <param name="hash"></param>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static string AssembleHashedFileName(uint hash, string filename)
		{
			return "#0x" + Helper.MinStrLength(hash.ToString("x"), 8) + "!" + filename;
		}
	}

	public class UserVerification
	{
		public static uint GenerateUserId(uint guid, string username, string password)
		{
			if (username.Trim() == "")
			{
				return 0;
			}

			uint hash = Hashes.GetCrc32(username) & 0xFFFFFFFE;
			guid = (guid << 8) & 0xFFFFFF00;
			return guid == 0 ? hash : ((hash | 0x00000001) & 0x000000FF) | guid;
		}

		public static bool ValidUserId(uint id, string username, string password)
		{
			if (username.Trim() == "")
			{
				return id == 0;
			}

			uint hash = Hashes.GetCrc32(username) & 0xFFFFFFFE;

			if ((id & 1) == 0)
			{
				return id == hash;
			}

			uint guid = GetUserGuid(id);
			id &= 0x000000FE;
			hash &= 0x000000FE;
			return id == hash;
		}

		public static uint GetUserGuid(uint id)
		{
			uint guid = id >> 8;
			return guid;
		}

		public static bool HaveUserId => (Helper.WindowsRegistry.Config.CachedUserId != 0)
					&& (Helper.WindowsRegistry.Config.UserName.Trim() != "");

		public static bool HaveValidUserId => HaveUserId
					&& ValidUserId(
						Helper.WindowsRegistry.Config.CachedUserId,
						Helper.WindowsRegistry.Config.UserName,
						Helper.WindowsRegistry.Config.Password
					);

		public static uint UserId => Helper.WindowsRegistry.Config.CachedUserId;
	}
}
