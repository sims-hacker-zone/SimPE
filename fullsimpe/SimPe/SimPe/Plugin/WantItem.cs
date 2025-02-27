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

namespace SimPe.Plugin
{
	/// <summary>
	/// Meanings of the Want Bits
	/// </summary>
	public enum WantFlagValues : byte
	{
		Locked = 0,
	}

	/// <summary>
	/// All known Want Flags
	/// </summary>
	public class WantFlags : SimPe.FlagBase
	{
		internal WantFlags(ushort val)
			: base(val) { }

		public bool Locked
		{
			get
			{
				return GetBit((byte)WantFlagValues.Locked);
			}
			set
			{
				SetBit((byte)WantFlagValues.Locked, value);
			}
		}
	}

	/// <summary>
	/// A Want item stored in a Want File
	/// </summary>
	public class WantItem
	{
		#region Attributes
		public uint Version
		{
			get; set;
		}

		public ushort SimInstance
		{
			get; set;
		}

		public uint Guid
		{
			get; set;
		}

		public WantType Type
		{
			get; set;
		}

		public uint Value
		{
			get; set;
		}

		public ushort Property
		{
			get; set;
		}

		public uint Index
		{
			get; set;
		}

		public int Score
		{
			get; set;
		}

		public WantFlags Flag
		{
			get; set;
		}

		public int Influence
		{
			get; set;
		}

		public Interfaces.IProviderRegistry Provider
		{
			get;
		}

		/// <summary>
		/// Returns Informations about the Selected want
		/// </summary>
		public WantInformation Information => WantInformation.LoadWant(Guid);
		#endregion

		public WantItem(Interfaces.IProviderRegistry provider)
		{
			Version = 8;
			this.Provider = provider;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			Version = reader.ReadUInt32();
			SimInstance = reader.ReadUInt16();
			Guid = reader.ReadUInt32();
			Type = (WantType)reader.ReadByte();

			if (Type == WantType.Skill)
			{
				Value = reader.ReadUInt16();
			}
			else if (Type == WantType.Sim)
			{
				if (Version >= 8)
				{
					Value = reader.ReadUInt16();
				}
				else
				{
					Value = 0;
				}
			}
			else if ((byte)Type > 1)
			{
				Value = reader.ReadUInt32();
			}
			else
			{
				Value = 0;
			}

			Property = reader.ReadUInt16();
			Index = reader.ReadUInt32();
			Score = reader.ReadInt32();

			if (Version >= 9)
			{
				Influence = reader.ReadInt32();
			}

			Flag = new WantFlags(reader.ReadByte());
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(Version);
			writer.Write(SimInstance);
			writer.Write(Guid);
			writer.Write((byte)Type);

			if (Type == WantType.Skill)
			{
				writer.Write((ushort)Value);
			}
			else if (Type == WantType.Sim)
			{
				if (Version >= 8)
				{
					writer.Write((ushort)Value);
				}
				else
				{
					Value = 0;
				}
			}
			else if ((byte)Type > 1)
			{
				writer.Write((uint)Value);
			}
			else
			{
				Value = 0;
			}

			writer.Write(Property);
			writer.Write(Index);
			writer.Write(Score);

			if (Version >= 9)
			{
				writer.Write(Influence);
			}

			writer.Write((byte)Flag.Value);
		}

		public override string ToString()
		{
			string n = Information.Name;
			n = n.Replace("$Value", this.Property.ToString());
			n = n.Replace("$Money", this.Property.ToString());
			string c = WantLoader.WantNameLoader.FindName(Type, this.Value);

			if (this.Type == WantType.Career)
			{
				if (c != null)
				{
					n = n.Replace("$JobTitle", c);
				}

				if (c != null)
				{
					n = n.Replace("$CareerTrack", c);
				}
			}
			else if (this.Type == WantType.Skill)
			{
				if (c != null)
				{
					n = n.Replace("$Skill", c);
				}
			}
			else if (this.Type == WantType.Category)
			{
				if (c != null)
				{
					n = n.Replace("$ObjectType", c);
				}
			}
			else if (this.Type == WantType.Object)
			{
				if (c != null)
				{
					n = n.Replace("$Object", c);
				}
			}
			else if (this.Type == WantType.Sim)
			{
				if (c != null)
				{
					n = n.Replace("$Neighbor", c);
				}
			}

			return n;
		}
	}
}
