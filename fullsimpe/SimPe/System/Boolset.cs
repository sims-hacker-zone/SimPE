// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace System
{
	/// <summary>
	/// Summary description for SystemClasses.
	/// </summary>
	public class Boolset
	{
		private bool[] bitset = null;

		private Boolset(int size, uint val)
		{
			bitset = new bool[size];
			for (int i = 0; i < size; i++)
			{
				bitset[i] = (val & (1 << i)) != 0;
			}
		}

		public Boolset(uint val)
			: this(32, val) { }

		public Boolset(ushort val)
			: this(16, val) { }

		public Boolset(byte val)
			: this(8, val) { }

		public Boolset(string val)
		{
			bitset = new bool[val.Length];
			int j = 0;
			for (int i = val.Length - 1; i >= 0; i--)
			{
				bitset[j++] = !val.Substring(i, 1).Equals("0");
			}
		}

		public static implicit operator Boolset(uint o)
		{
			return new Boolset(o);
		}

		public static implicit operator Boolset(ushort o)
		{
			return new Boolset(o);
		}

		public static implicit operator Boolset(byte o)
		{
			return new Boolset(o);
		}

		public static implicit operator Boolset(string o)
		{
			return new Boolset(o);
		}

		private static int doOperator(Boolset t, int l)
		{
			int val = 0;
			for (int i = 0; i < l && i < t.bitset.Length; i++)
			{
				val += (t[i] ? 1 : 0) << i;
			}

			return val;
		}

		public static implicit operator byte(Boolset t)
		{
			return (byte)doOperator(t, 8);
		}

		public static implicit operator ushort(Boolset t)
		{
			return (ushort)doOperator(t, 16);
		}

		public static implicit operator uint(Boolset t)
		{
			return (uint)doOperator(t, 32);
		}

		public static implicit operator string(Boolset t)
		{
			string s = "";
			for (int i = 0; i < t.bitset.Length; i++)
			{
				s = (t.bitset[i] ? "1" : "0") + s;
			}

			return s;
		}

		public override string ToString()
		{
			return this;
		}

		public bool this[int i]
		{
			get => i > bitset.Length ? throw new ArgumentOutOfRangeException() : bitset[i];
			set
			{
				if (i > bitset.Length)
				{
					throw new ArgumentOutOfRangeException();
				}

				bitset[i] = value;
				/*
				 *   set: val |= 1 << bit;
				 * clear: val -= (val & (1 << bit))
				 */
			}
		}

		public int Length => bitset.Length;

		public bool Matches(string mask)
		{
			// right-hand end of mask is low end of bitset
			int mcnt = mask.Length - 1;
			bool matched = true;
			int i = 0;
			while (matched && mcnt > 0 && i < bitset.Length)
			{
				if (mask[mcnt].Equals('0'))
				{
					matched = !bitset[i];
				}
				else if (mask[mcnt].Equals('1'))
				{
					matched = bitset[i];
				}

				mcnt--;
				i++;
			}
			return matched;
		}

		public void flip(int[] bits)
		{
			foreach (int bit in bits)
			{
				flip(bit);
			}
		}

		public void flip(int bit)
		{
			bitset[bit] = !bitset[bit];
		}
	}
}
