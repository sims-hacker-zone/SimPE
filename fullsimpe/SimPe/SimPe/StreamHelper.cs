// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe
{
	/// <summary>
	/// Some usefull Methods to Read Data
	/// </summary>
	public class StreamHelper
	{
		/// <summary>
		/// Reads a string from the Stream, that is 32-Bit Length Encoded
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static string ReadString(System.IO.BinaryReader reader)
		{
			int ct = reader.ReadInt32();
			return Helper.ToString(reader.ReadBytes(ct));
		}

		/// <summary>
		/// Writes a 32-Bit Length Encoded String
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="s"></param>
		public static void WriteString(System.IO.BinaryWriter writer, string s)
		{
			if (s.Length > 0)
			{
				writer.Write((uint)s.Length);
				writer.Write(Helper.ToBytes(s, s.Length));
			}
			else
			{
				writer.Write((uint)0);
			}
		}

		/// <summary>
		/// Reads a 0-terminated string
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		public static string ReadPChar(System.IO.BinaryReader r)
		{
			char b = r.ReadChar();
			string s = "";
			while (b != 0 && r.BaseStream.Position <= r.BaseStream.Length)
			{
				s += b;
				b = r.ReadChar();
			}
			return s;
		}

		/// <summary>
		/// Reads a 0-terminated string
		/// </summary>
		/// <param name="w"></param>
		/// <param name="s"></param>
		public static void WritePChar(System.IO.BinaryWriter w, string s)
		{
			foreach (char c in s)
			{
				w.Write(c);
			}

			w.Write((char)0);
		}
	}
}
