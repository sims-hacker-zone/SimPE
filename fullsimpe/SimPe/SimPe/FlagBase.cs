// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;

namespace SimPe
{
	/// <summary>
	/// Basic Class you can use if you have to implement Flags
	/// </summary>
	[
		TypeConverter(typeof(FlagBaseConverter)),
		Description("This Property contains some Flags")
	]
	public class FlagBase : Serializer, Ambertation.IPropertyClass
	{
		public FlagBase(ushort flags)
		{
			Value = flags;
		}

		public FlagBase(object flags)
		{
			Value = 0;
			try
			{
				Value = Convert.ToUInt16(flags);
			}
			catch { }
		}

		[Browsable(false)]
		public ushort Value
		{
			get; set;
		}

		protected bool GetBit(byte nr)
		{
			ushort mask = (ushort)(1 << nr);
			return (Value & mask) != 0;
		}

		protected void SetBit(byte nr, bool val)
		{
			ushort mask = (ushort)(1 << nr);
			Value = (ushort)(Value | mask);
			if (!val)
			{
				Value -= mask;
			}
		}

		public override string ToString()
		{
			return Convert.ToString(Value, 2);
		}

		public static implicit operator ushort(FlagBase m)
		{
			return m.Value;
		}

		public static implicit operator short(FlagBase m)
		{
			return (short)m.Value;
		}
	}
}
