/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Bcon
		: pjse.ExtendedWrapper<
			BconItem,
			Bcon
		> //AbstractWrapper				//Implements some of the default Behaviur of a Handler, you can Implement yourself if you want more flexibility!
			,
			IFileWrapper //This Interface is used when loading a File
			,
			IFileWrapperSaveExtension //This Interface (if available) will be used to store a File
									  //,IPackedFileProperties		//This Interface can be used by thirdparties to retrive the FIleproperties, however you don't have to implement it!
	{
		#region Attributes
		/// <summary>
		/// Contains the Filename
		/// </summary>
		private byte[] filename = new byte[64];

		/// <summary>
		/// Just A Flag
		/// </summary>
		private bool flag = false;
		#endregion

		#region Accessor methods
		/// <summary>
		/// Returns the Filename
		/// </summary>
		public string FileName
		{
			get => Helper.ToString(filename);
			set
			{
				if (!Helper.ToString(filename).Equals(value))
				{
					filename = Helper.ToBytes(value, 0x40);
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		/// Returns /Sets the Flag
		/// </summary>
		public bool Flag
		{
			get => flag;
			set
			{
				if (flag != value)
				{
					flag = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Bcon()
			: base() { }

		#region AbstractWrapper Member
		public override bool CheckVersion(uint version)
		{
			return (version == 0012) //0.00
				|| (version == 0013); //0.10
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.BconForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"PJSE BCON Wrapper",
				"Peter L Jones",
				"BCON Value Editor",
				1
			);
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(filename);
			int countflag = items.Count | (flag ? 0x8000 : 0x0000);
			writer.Write((ushort)countflag);

			foreach (short v in items)
			{
				writer.Write(v);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			filename = reader.ReadBytes(64);
			ushort countflag = reader.ReadUInt16();
			flag = (countflag & 0x8000) != 0;
			int length = countflag & 0x7fff;

			items = new List<BconItem>();
			while (items.Count < length)
			{
				items.Add(reader.ReadInt16());
			}
		}

		#endregion

		public const uint Bcontype = 0x42434F4E;

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Type this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[] { Bcontype };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		public new void Add(BconItem item)
		{
			Add(item, 0x8000);
		}

		public new void Insert(int index, BconItem item)
		{
			Insert(index, item, 0x8000);
		}
	}

	public class BconItem
		: pjse.ExtendedWrapperItem<Bcon, BconItem>,
			IComparable<short>,
			IEquatable<short>,
			IComparable<BconItem>
	{
		private Int16 value;

		public BconItem(Int16 value)
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
