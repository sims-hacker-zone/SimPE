// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.PackedFiles.Swaf
{
	/// <summary>
	/// A Want item stored in a Want File
	/// </summary>
	public class WantItem
	{
		#region Attributes

		public SwafItemType ItemType
		{
			get;
			set;
		}
		public uint Version
		{
			get; set;
		} = 8;

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

		public int Influence
		{
			get; set;
		}

		public WantFlags Flag
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

		public WantItem(Interfaces.IProviderRegistry provider, SwafItemType type)
		{
			Provider = provider;
			ItemType = type;
		}

		public WantItem(Swaf parent, SwafItemType type)
		{
			ItemType = type;
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public WantItem Unserialize(System.IO.BinaryReader reader)
		{
			Version = reader.ReadUInt32();
			SimInstance = reader.ReadUInt16();
			Guid = reader.ReadUInt32();
			Type = (WantType)reader.ReadByte();

			switch (Type)
			{
				case WantType.Skill:
					Value = reader.ReadUInt16();
					break;
				case WantType.Sim:
					Value = Version >= 8
							? reader.ReadUInt16()
							: (uint)0;
					break;
				default:
					Value = (byte)Type > 1
							? reader.ReadUInt32()
							: 0;
					break;
			}

			Property = reader.ReadUInt16();
			Index = reader.ReadUInt32();
			Score = reader.ReadInt32();

			if (Version >= 9)
			{
				Influence = reader.ReadInt32();
			}

			Flag = (WantFlags)reader.ReadByte();
			return this;
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
			}
			else if ((byte)Type > 1)
			{
				writer.Write(Value);
			}

			writer.Write(Property);
			writer.Write(Index);
			writer.Write(Score);

			if (Version >= 9)
			{
				writer.Write(Influence);
			}

			writer.Write((byte)Flag);
		}

		public override string ToString()
		{
			string n = Information.Name;
			n = n.Replace("$Value", Property.ToString());
			n = n.Replace("$Money", Property.ToString());
			string c = WantLoader.WantNameLoader.FindName(Type, Value);

			switch (Type)
			{
				case WantType.Career:
					if (c != null)
					{
						n = n.Replace("$JobTitle", c);
					}

					if (c != null)
					{
						n = n.Replace("$CareerTrack", c);
					}
					break;
				case WantType.Skill:
					if (c != null)
					{
						n = n.Replace("$Skill", c);
					}
					break;
				case WantType.Category:
					if (c != null)
					{
						n = n.Replace("$ObjectType", c);
					}
					break;
				case WantType.Guid:
					if (c != null)
					{
						n = n.Replace("$Object", c);
					}
					break;
				case WantType.Sim:
					if (c != null)
					{
						n = n.Replace("$Neighbor", c);
					}
					break;
			}
			return n;
		}
	}
}
