// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper
{
	internal class ObjdItem
	{
		public ushort val;
		public long position;
	}

	/// <summary>
	/// Represents a PackedFile in SDsc Format
	/// </summary>
	public class Objd
		: AbstractWrapper,
			IFileWrapper,
			IFileWrapperSaveExtension
	{
		/// <summary>
		///the stored Filename
		/// </summary>
		private byte[] filename;

		/// <summary>
		/// Spaces of unknown Data
		/// </summary>
		private byte[] reserved_01;

		/// <summary>
		/// Spaces of unknown Data
		/// </summary>
		private byte[] reserved_02;

		/// <summary>
		/// Returns the Name of a Sim
		/// </summary>
		/*public string SimName
		{
			get
			{
				string n = FileName;
				int p = n.IndexOf(" - ");
				if (p==-1) return "Unknown";
				else
				{
					p += 3;
					return n.Substring(p, n.Length - p).Trim();
				}

			}
		}*/


		/// <summary>
		/// Returns/Sets the Name of a Sim
		/// </summary>
		public string FileName
		{
			get =>
				/*string s = "";
System.IO.MemoryStream ms = new System.IO.MemoryStream(filename);
System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
try
{
	while (br.BaseStream.Position < br.BaseStream.Length)
	{
		if (br.PeekChar()==0) break;
		s += br.ReadChar();
	}
}
catch (Exception) {};*/
				Helper.ToString(filename);
			set => filename = Helper.SetLength(Helper.ToBytes(value, 64), 64);
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint Guid
		{
			get => SimId;
			set => SimId = value;
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint SimId
		{
			get; set;
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint ProxyGuid
		{
			get; set;
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		public uint OriginalGuid
		{
			get; set;
		}

		/// <summary>
		/// Returns the GUID of the Object
		/// </summary>
		protected uint InternalGUID
		{
			get
			{
				uint simid = (uint)(
					(GetAttributeShort("guid_2 - Read Only") << 16)
					+ GetAttributeShort("guid_1 - Read Only")
				);
				return simid;
			}
			set
			{
				uint simid = value;
				ObjdItem guid1 = (ObjdItem)attr["guid_1 - Read Only"] ?? new ObjdItem();

				guid1.val = (ushort)(simid & 0xffff);
				attr["guid_1 - Read Only"] = guid1;

				ObjdItem guid2 = (ObjdItem)attr["guid_2 - Read Only"];
				if (guid2 == null)
				{
					guid1 = new ObjdItem();
				}

				guid2.val = (ushort)((simid >> 16) & 0xffff);
				attr["guid_2 - Read Only"] = guid2;
			}
		}

		/// <summary>
		/// Returns the Template GUID
		/// </summary>
		protected uint InternalTemplateGUID
		{
			get
			{
				uint simid = (uint)(
					(GetAttributeShort("Proxy GUID 2") << 16)
					+ GetAttributeShort("Proxy GUID 1")
				);
				return simid;
			}
			set
			{
				uint simid = value;
				ObjdItem guid1 = (ObjdItem)attr["Proxy GUID 1"] ?? new ObjdItem();

				guid1.val = (ushort)(simid & 0xffff);
				attr["guid_1 - Read Only"] = guid1;

				ObjdItem guid2 = (ObjdItem)attr["Proxy GUID 2"];
				if (guid2 == null)
				{
					guid1 = new ObjdItem();
				}

				guid2.val = (ushort)((simid >> 16) & 0xffff);
				attr["guid_2 - Read Only"] = guid2;
			}
		}

		/// <summary>
		/// Returns the Original GUID
		/// </summary>
		protected uint InternalOriginalGUID
		{
			get
			{
				uint simid = (uint)(
					(GetAttributeShort("original guid 2 - Read Only") << 16)
					+ GetAttributeShort("original guid 1 - Read Only")
				);
				return simid;
			}
			set
			{
				uint simid = value;
				ObjdItem guid1 = (ObjdItem)attr["original guid 1 - Read Only"] ?? new ObjdItem();

				guid1.val = (ushort)(simid & 0xffff);
				attr["guid_1 - Read Only"] = guid1;

				ObjdItem guid2 = (ObjdItem)attr["original guid 2 - Read Only"];
				if (guid2 == null)
				{
					guid1 = new ObjdItem();
				}

				guid2.val = (ushort)((simid >> 16) & 0xffff);
				attr["guid_2 - Read Only"] = guid2;
			}
		}

		/// <summary>
		/// returns the Instance of the assigned Catalog Description
		/// </summary>
		public ushort CTSSId
		{
			get; private set;
		}

		/// <summary>
		/// Retursn / Sets the Type of an Object
		/// </summary>
		public ushort Type
		{
			get; set;
		}

		/// <summary>
		/// Returns a stored Attribute as Unsigned short Value
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ushort GetAttributeShort(string name)
		{
			object o = attr[name];
			return o == null ? (ushort)0 : ((ObjdItem)o).val;
		}

		/// <summary>
		/// Returns the position of the Attribute in the Stream
		/// </summary>
		/// <param name="name">Name of the Attribute</param>
		/// <returns></returns>
		public long GetAttributePosition(string name)
		{
			object o = attr[name];
			return o == null ? 0 : ((ObjdItem)o).position;
		}

		#region IWrapper Member
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo("OBJD Wrapper", "Quaxi", "---", 3);
		}
		#endregion

		#region AbstractWrapper Member
		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.Objd();
		}

		Interfaces.Providers.IOpcodeProvider opcodes;

		public Objd(Interfaces.Providers.IOpcodeProvider opcodes)
			: base()
		{
			filename = new byte[0];
			reserved_01 = new byte[0];
			reserved_02 = new byte[0];
			items = new ArrayList();
			attr = new Hashtable();
			this.opcodes = opcodes;
			Type = 1;
		}

		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			attr = new Hashtable();
			filename = reader.ReadBytes(0x40);
			long pos = reader.BaseStream.Position;
			if (reader.BaseStream.Length >= 0x54)
			{
				reader.BaseStream.Seek(0x52, System.IO.SeekOrigin.Begin);
				Type = reader.ReadUInt16();
			}
			else
			{
				Type = 0;
			}

			if (reader.BaseStream.Length >= 0x60)
			{
				reader.BaseStream.Seek(0x5C, System.IO.SeekOrigin.Begin);
				SimId = reader.ReadUInt32();
			}
			else
			{
				SimId = 0;
			}

			if (reader.BaseStream.Length >= 0x7E)
			{
				reader.BaseStream.Seek(0x7A, System.IO.SeekOrigin.Begin);
				ProxyGuid = reader.ReadUInt32();
			}
			else
			{
				ProxyGuid = 0;
			}

			if (reader.BaseStream.Length >= 0x94)
			{
				reader.BaseStream.Seek(0x92, System.IO.SeekOrigin.Begin);
				CTSSId = reader.ReadUInt16();
			}
			else
			{
				CTSSId = 0;
			}

			if (reader.BaseStream.Length >= 0xD0)
			{
				reader.BaseStream.Seek(0xCC, System.IO.SeekOrigin.Begin);
				OriginalGuid = reader.ReadUInt32();
			}
			else
			{
				OriginalGuid = 0;
			}

			reader.BaseStream.Seek(pos, System.IO.SeekOrigin.Begin);

			ArrayList names = new ArrayList();
			if (opcodes != null)
			{
				names = opcodes.OBJDDescription(Type);
			}

			if (names.Count == 0)
			{
				/*reserved_01 = reader.ReadBytes(0x1C);
				//simid = reader.ReadUInt32();
				ObjdItem item = new ObjdItem();
				item.position = reader.BaseStream.Position;
				item.val = reader.ReadUInt16();
				attr["guid_1 - Read Only"] = item;

				item = new ObjdItem();
				item.position = reader.BaseStream.Position;
				item.val = reader.ReadUInt16();
				attr["guid_2 - Read Only"] = item;
				reserved_02 = reader.ReadBytes((int)(reader.BaseStream.Length - (reader.BaseStream.Position)));

				item = new ObjdItem();
				item.position = reader.BaseStream.Position;
				if (reader.BaseStream.Length>=0x90)
				{
					reader.BaseStream.Seek(0x8E, System.IO.SeekOrigin.Begin);
					item.val = reader.ReadUInt16();

					ObjdItem item2 = new ObjdItem();
					item2.position = reader.BaseStream.Position;
					item2.val = reader.ReadUInt16();
					attr["function sort flags"] = item2;
				}
				else item.val = 0;
				attr["room sort flags"] = item;

				item = new ObjdItem();
				item.position = reader.BaseStream.Position;
				if (reader.BaseStream.Length>=0x94)
				{
					reader.BaseStream.Seek(0x92, System.IO.SeekOrigin.Begin);
					item.val = reader.ReadUInt16();
				}
				else item.val = 0;
				attr["catalog strings id"] = item;	*/
			}
			else
			{
				foreach (string name in names)
				{
					if (reader.BaseStream.Position > reader.BaseStream.Length - 2)
					{
						break;
					}

					ObjdItem item = new ObjdItem
					{
						position = reader.BaseStream.Position,
						val = reader.ReadUInt16()
					};
					string sname = name;
					if (name.Trim() == "")
					{
						sname = "0x" + Helper.HexString((uint)item.position);
					}

					attr[sname] = item;
				}

				/*guid = this.InternalGUID;
				proxyguid = this.InternalTemplateGUID;
				originalguid = this.InternalOriginalGUID;*/
			}
		}

		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(filename);

			ArrayList names = new ArrayList();
			if (opcodes != null)
			{
				names = opcodes.OBJDDescription(Type);
			}

			if (names.Count == 0)
			{
				writer.Write(reserved_01);
				//writer.Write(simid);
				writer.Write(GetAttributeShort("guid_1 - Read Only"));
				writer.Write(GetAttributeShort("guid_2 - Read Only"));
				writer.Write(reserved_02);
			}
			else
			{
				/*this.InternalGUID = guid;
				this.InternalOriginalGUID = originalguid;
				this.InternalTemplateGUID = proxyguid;*/
				foreach (string name in names)
				{
					string sname = name;
					if (sname.Trim() == "")
					{
						sname =
							"0x" + Helper.HexString((uint)writer.BaseStream.Position);
					}

					if (attr[sname] == null)
					{
						break;
					}

					writer.Write(GetAttributeShort(sname));
				}
				CTSSId = GetAttributeShort("catalog strings id");
			}

			writer.BaseStream.Seek(0x52, System.IO.SeekOrigin.Begin);
			writer.Write(Type);

			writer.BaseStream.Seek(0x5C, System.IO.SeekOrigin.Begin);
			writer.Write(SimId);

			writer.BaseStream.Seek(0x7A, System.IO.SeekOrigin.Begin);
			writer.Write(ProxyGuid);

			writer.BaseStream.Seek(0x92, System.IO.SeekOrigin.Begin);
			writer.Write(CTSSId);

			writer.BaseStream.Seek(0xCC, System.IO.SeekOrigin.Begin);
			writer.Write(OriginalGuid);
		}
		#endregion

		#region IPackedFileWrapper Member

		public FileTypes[] AssignableTypes => new FileTypes[] { FileTypes.OBJD };

		public byte[] FileSignature => new byte[] { };

		#endregion

		#region IPackedFileProperties Member

		Hashtable attr;
		ArrayList items;

		/*public IPackedFileProperties[] Items
		{
			get
			{
				if (items==null) items = new ArrayList();
				IPackedFileProperties[] i = new IPackedFileProperties[items.Count];
				items.CopyTo(i);
				return i;
			}
		}*/

		public Hashtable Attributes
		{
			get
			{
				if (attr == null)
				{
					attr = new Hashtable();
				}

				return attr;
			}
		}

		#endregion
	}
}
