/***************************************************************************
 *   Copyright (C) 2008 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;

namespace pjOBJDTool
{
	public class pfOBJD : pjse.ExtendedWrapper<pfOBJDItem, pfOBJD>
	{
		private byte[] filename = null;
		private byte[] endName = null;
		public string Filename
		{
			get => SimPe.Helper.ToString(filename);
			set
			{
				if (!SimPe.Helper.ToString(filename).Equals(value))
				{
					filename = SimPe.Helper.ToBytes(value, 0x40);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			filename = null;
			endName = null;
			items = new List<pfOBJDItem>();

			filename = reader.ReadBytes(0x40);

			long limit =
				reader.BaseStream.Length - reader.BaseStream.Position - Filename.Length;
			while (items.Count * 2 < limit - 1)
			{
				items.Add(reader.ReadUInt16());
			}

			endName = reader.ReadBytes(
				(int)(reader.BaseStream.Length - reader.BaseStream.Position)
			);
			if (!Filename.Equals(SimPe.Helper.ToString(endName)))
			{
				throw new InvalidOperationException(
					"Trailing filename (\""
						+ SimPe.Helper.ToString(endName)
						+ "\") not equal to Filename (\""
						+ Filename
						+ "\")"
				);
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(filename);
			foreach (pfOBJDItem i in items)
			{
				writer.Write((ushort)i);
			}

			writer.Write(endName);
		}

		protected override SimPe.Interfaces.Plugin.IPackedFileUI CreateDefaultUIHandler()
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public class pfOBJDItem
		: pjse.ExtendedWrapperItem<pfOBJD, pfOBJDItem>,
			IComparable<ushort>,
			IEquatable<ushort>,
			IComparable<pfOBJDItem>
	{
		private ushort value;

		public pfOBJDItem(ushort value)
		{
			this.value = value;
		}

		#region Conversions
		public static explicit operator byte(pfOBJDItem i)
		{
			return (byte)i.value;
		}

		public static explicit operator short(pfOBJDItem i)
		{
			return (short)i.value;
		}

		public static implicit operator ushort(pfOBJDItem i)
		{
			return i.value;
		}

		public static explicit operator pfOBJDItem(short i)
		{
			return new pfOBJDItem((ushort)i);
		}

		public static implicit operator pfOBJDItem(ushort i)
		{
			return new pfOBJDItem(i);
		}

		public override string ToString()
		{
			return value.ToString();
		}
		#endregion

		public override bool Equals(pfOBJDItem other)
		{
			return value.Equals(other.value);
		}

		#region IComparable<ushort> Members

		public int CompareTo(ushort other)
		{
			return value.CompareTo(other);
		}

		#endregion

		#region IEquatable<ushort> Members

		public bool Equals(ushort other)
		{
			return value.Equals(other);
		}

		#endregion

		#region IComparable<pfOBJDItem> Members

		public int CompareTo(pfOBJDItem other)
		{
			return value.CompareTo(other.value);
		}

		#endregion
	}
}
