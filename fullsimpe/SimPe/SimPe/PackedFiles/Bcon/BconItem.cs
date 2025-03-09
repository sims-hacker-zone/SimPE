// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe.PackedFiles.Bcon
{
	public class BconItem
		: pjse.ExtendedWrapperItem<Bcon, BconItem>,
			IComparable<short>,
			IEquatable<short>,
			IComparable<BconItem>
	{
		private short value;

		public BconItem(short value)
		{
			this.value = value;
		}

		public static explicit operator byte(BconItem i)
		{
			return (byte)i.value;
		}

		public static implicit operator short(BconItem i)
		{
			return i.value;
		}

		public static explicit operator ushort(BconItem i)
		{
			return (ushort)i.value;
		}

		public static implicit operator BconItem(short i)
		{
			return new BconItem(i);
		}

		public override string ToString()
		{
			return value.ToString();
		}

		public override bool Equals(BconItem other)
		{
			return value.Equals(other.value);
		}

		#region IComparable<short> Members

		public int CompareTo(short other)
		{
			return value.CompareTo(other);
		}

		#endregion

		#region IEquatable<short> Members

		public bool Equals(short other)
		{
			return value.Equals(other);
		}

		#endregion

		#region IComparable<BconItem> Members

		public int CompareTo(BconItem other)
		{
			return value.CompareTo(other.value);
		}

		#endregion
	}
}
