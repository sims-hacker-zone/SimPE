// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Numerics;

using SimPe.Extensions;
using SimPe.Geometry;

namespace SimPe.Plugin
{
	public class ExtensionItem
	{
		//Known Types
		public enum ItemTypes : byte
		{
			Value = 0x02,
			Float = 0x03,
			Translation = 0x05,
			String = 0x06,
			Array = 0x07,
			Rotation = 0x08,
			Binary = 0x09,
		}

		#region Attributes
		public ItemTypes Typecode
		{
			get; set;
		}

		string varname;
		public string Name
		{
			get => varname ?? "";
			set => varname = value;
		}

		public int Value
		{
			get; set;
		}

		public float Single
		{
			get; set;
		}

		public Vector3 Translation
		{
			get; set;
		}

		public string String
		{
			get; set;
		}

		public List<ExtensionItem> Items
		{
			get; set;
		}

		public Quaternion Rotation
		{
			get; set;
		}

		public byte[] Data
		{
			get; set;
		}

		#endregion

		public ExtensionItem()
		{
			varname = "";
			Translation = new Vector3();
			Single = 0;
			Items = new List<ExtensionItem>();
			Rotation = new Quaternion();
			Data = new byte[0];
			String = "";
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader)
		{
			Typecode = (ItemTypes)reader.ReadByte();
			varname = reader.ReadString();

			switch (Typecode)
			{
				case ItemTypes.Value:
				{
					Value = reader.ReadInt32();
					break;
				}
				case ItemTypes.Float:
				{
					Single = reader.ReadSingle();
					break;
				}
				case ItemTypes.Translation:
				{
					Translation.Unserialize(reader);
					break;
				}
				case ItemTypes.String:
				{
					String = reader.ReadString();
					break;
				}
				case ItemTypes.Array:
				{
					uint itemcount = reader.ReadUInt32();
					Items = new List<ExtensionItem>();
					for (int i = 0; i < itemcount; i++)
					{
						Items.Add(new ExtensionItem());
						Items[i].Unserialize(reader);
					}
					break;
				}
				case ItemTypes.Rotation:
				{
					Rotation.Unserialize(reader);
					break;
				}
				case ItemTypes.Binary:
				{
					int len = reader.ReadInt32();
					Data = reader.ReadBytes(len);
					break;
				}
				default:
				{
					throw new Exception(
						"Unknown Extension Item 0x"
							+ Helper.HexString((byte)Typecode)
							+ "\n\nPosition: 0x"
							+ $"{reader.BaseStream.Position:X16}"
					);
				}
			}
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
			writer.Write((byte)Typecode);
			writer.Write(varname);

			switch (Typecode)
			{
				case ItemTypes.Value:
				{
					writer.Write(Value);
					break;
				}
				case ItemTypes.Float:
				{
					writer.Write(Single);
					break;
				}
				case ItemTypes.Translation:
				{
					Translation.Serialize(writer);
					break;
				}
				case ItemTypes.String:
				{
					writer.Write(String);
					break;
				}
				case ItemTypes.Array:
				{
					writer.Write((uint)Items.Count);
					for (int i = 0; i < Items.Count; i++)
					{
						Items[i].Serialize(writer);
					}
					break;
				}
				case ItemTypes.Rotation:
				{
					Rotation.Serialize(writer);
					break;
				}
				case ItemTypes.Binary:
				{
					writer.Write(Data.Length);
					writer.Write(Data);
					break;
				}
				default:
				{
					throw new Exception(
						"Unknown Extension Item 0x" + Helper.HexString((byte)Typecode)
					);
				}
			}
		}

		public override string ToString()
		{
			string name = varname + " = (" + Typecode.ToString() + ") ";
			switch (Typecode)
			{
				case ItemTypes.Value:
				{
					name += Value.ToString();
					break;
				}
				case ItemTypes.Float:
				{
					name += Single.ToString();
					break;
				}
				case ItemTypes.Translation:
				{
					name += Translation.ToString();
					break;
				}
				case ItemTypes.String:
				{
					name += String;
					break;
				}
				case ItemTypes.Array:
				{
					name += Items.Count.ToString() + " items";
					break;
				}
				case ItemTypes.Rotation:
				{
					name += Rotation.ToString();
					break;
				}
				case ItemTypes.Binary:
				{
					name += Helper.BytesToHexList(Data);
					break;
				}
			}
			return name;
		}
	}

	/// <summary>
	/// This is the actual FileWrapper
	/// </summary>
	/// <remarks>
	/// The wrapper is used to (un)serialize the Data of a file into it's Attributes. So Basically it reads
	/// a BinaryStream and translates the data into some userdefine Attributes.
	/// </remarks>
	public class Extension : AbstractRcolBlock
	{
		#region Attributes

		public byte TypeCode
		{
			get; set;
		}

		string varname;
		public string VarName
		{
			get
			{
				return varname == null ? "" : varname;
			}
			set => varname = value;
		}

		public List<ExtensionItem> Items
		{
			get; set;
		}

		byte[] data;

		//int unknown1;
		//int unknown2;
		#endregion


		/// <summary>
		/// Constructor
		/// </summary>
		public Extension(Rcol parent)
			: base(parent)
		{
			Items = new List<ExtensionItem>();
			version = 0x03;
			TypeCode = 0x07;
			data = new byte[0];
			varname = "";
		}

		#region IRcolBlock Member

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public override void Unserialize(System.IO.BinaryReader reader)
		{
			Unserialize(reader, 0);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public void Unserialize(System.IO.BinaryReader reader, uint ver)
		{
			version = reader.ReadUInt32();
			TypeCode = reader.ReadByte();

			if (TypeCode < 0x07)
			{
				int sz = 16;
				if ((TypeCode != 0x03) || (ver == 4))
				{
					sz += 15;
				}

				if ((TypeCode <= 0x03) && (version == 3))
				{
					sz = ver == 5 ? 31 : 15;
				}
				if ((TypeCode <= 0x03) && ver == 4)
				{
					sz = 31;
				}

				Items = new List<ExtensionItem>
				{
					new ExtensionItem
					{
						Typecode = ExtensionItem.ItemTypes.Binary,
						Data = reader.ReadBytes(sz)
					}
				};
			}
			else
			{
				varname = reader.ReadString();

				uint count = reader.ReadUInt32();

				Items = new List<ExtensionItem>();
				for (int i = 0; i < count; i++)
				{
					Items.Add(new ExtensionItem());
					Items[i].Unserialize(reader);
				}
			}
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public override void Serialize(System.IO.BinaryWriter writer)
		{
			Serialize(writer, 0);
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, uint ver)
		{
			writer.Write(version);
			writer.Write(TypeCode);

			if (TypeCode < 0x07)
			{
				int sz = 16;
				if ((TypeCode != 0x03) || (ver == 4))
				{
					sz += 15;
				}

				if ((TypeCode <= 0x03) && (version == 3))
				{
					sz = ver == 5 ? 31 : 15;
				}
				if ((TypeCode <= 0x03) && ver == 4)
				{
					sz = 31;
				}

				if (Items.Count > 0)
				{
					data = Items[0].Data;
				}

				data = Helper.SetLength(data, sz);
				writer.Write(data);
			}
			else
			{
				writer.Write(varname);

				writer.Write((uint)Items.Count);
				for (int i = 0; i < Items.Count; i++)
				{
					Items[i].Serialize(writer);
				}
			}
		}

		TabPage.Extension form = null;
		public override System.Windows.Forms.TabPage TabPage
		{
			get
			{
				if (form == null)
				{
					form = new TabPage.Extension();
				}

				return form;
			}
		}
		#endregion

		/// <summary>
		/// You can use this to setop the Controls on a TabPage befor it is dispplayed
		/// </summary>
		protected override void InitTabPage()
		{
			if (form == null)
			{
				form = new TabPage.Extension();
			}

			form.tb_ver.Text = "0x" + Helper.HexString(version);
			form.tb_type.Text = "0x" + Helper.HexString(TypeCode);
			form.tb_name.Text = varname;

			form.lb_items.Items.Clear();
			foreach (ExtensionItem ei in Items)
			{
				form.lb_items.Items.Add(ei);
			}

			form.gbIems.Tag = Items;
		}

		#region IDisposable Member

		public override void Dispose()
		{
			form?.Dispose();

			form = null;
		}

		#endregion
	}
}
