/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.ComponentModel;

namespace SimPe
{
	/// <summary>
	/// Basic Class you can use if you have to implement Flags
	/// </summary>
	[
		TypeConverterAttribute(typeof(FlagBaseConverter)),
		DescriptionAttribute("This Property contains some Flags")
	]
	public class FlagBase : Serializer, Ambertation.IPropertyClass
	{
		public FlagBase(ushort flags)
		{
			this.Value = flags;
		}

		public FlagBase(object flags)
		{
			this.Value = 0;
			try
			{
				this.Value = Convert.ToUInt16(flags);
			}
			catch { }
		}

		[System.ComponentModel.Browsable(false)]
		public ushort Value
		{
			get; set;
		}

		protected bool GetBit(byte nr)
		{
			ushort mask = (ushort)(1 << nr);
			return ((Value & mask) != 0);
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
