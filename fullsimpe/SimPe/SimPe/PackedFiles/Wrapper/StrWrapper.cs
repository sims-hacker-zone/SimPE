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
using System.Collections;
using System.Collections.Generic;
using System.IO;

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
	public class StrWrapper
		: pjse.ExtendedWrapper<
			StrItem,
			StrWrapper
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
		/// Format Code of the FIle
		/// </summary>
		private ushort format = (ushort)Data.MetaData.FormatCode.normal;

		/// <summary>
		/// Contains the LanguageIDs used in the wrapper
		/// </summary>
		Dictionary<byte, List<StrItem>> languages =
			new Dictionary<byte, List<StrItem>>();
		#endregion

		#region Accessor methods
		/// <summary>
		/// Returns / Sets the Filename
		/// </summary>
		public string FileName
		{
			get
			{
				return Helper.ToString(filename);
			}
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
		/// Returns / Sets the Format Code
		/// </summary>
		public ushort Format
		{
			get
			{
				return format;
			}
			set
			{
				if (format != value)
				{
					format = value;
					OnWrapperChanged(this, new EventArgs());
				}
			}
		}

		public bool HasLanguage(byte value)
		{
			return languages.ContainsKey(value) && languages[value].Count > 0;
		}

		public int CountOf(byte value)
		{
			return languages.ContainsKey(value) ? languages[value].Count : 0;
		}

		public byte[] Languages
		{
			get
			{
				byte[] result = new byte[languages.Keys.Count];
				languages.Keys.CopyTo(result, 0);
				List<byte> sortable = new List<byte>(result);
				sortable.Sort();
				return sortable.ToArray();
			}
		}
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public StrWrapper()
			: base() { }

		public void CleanUp()
		{
			Hashtable lngs = new Hashtable();
			foreach (StrItem i in items)
			{
				if (lngs[i.LanguageID] == null)
				{
					lngs[i.LanguageID] = new List<StrItem>();
				} ((List<StrItem>)lngs[i.LanguageID]).Add(i);
			}
			foreach (List<StrItem> l in lngs.Values)
			{
				for (int i = l.Count - 1; i >= 0; i--)
				{
					if (
						l[i].Title.Trim().Equals("")
						&& l[i].Description.Trim().Equals("")
					)
					{
						languages[l[i].LanguageID].Remove(l[i]);
						items.Remove(l[i]);
					}
					else
					{
						break;
					}
				}
			}
		}

		#region AbstractWrapper Member
		public override bool CheckVersion(uint version)
		{
			return true;
		}

		protected override IPackedFileUI CreateDefaultUIHandler()
		{
			return new UserInterface.StrForm();
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"PJSE STR#/TTAs/CTSS Wrapper",
				"Peter L Jones",
				"String Editor",
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
		protected override void Serialize(BinaryWriter writer)
		{
			CleanUp();

			writer.Write(filename);
			if (format == 0x0000)
			{
				writer.Write((byte)0);
				writer.Write((byte)items.Count);
			}
			else if (format == 0xFFFE)
			{
				writer.Write(format);
				writer.Write((byte)items.Count);
			}
			else
			{
				writer.Write(format);
				writer.Write((ushort)items.Count);
			}
			foreach (StrItem i in items)
			{
				i.Serialize(writer);
			}
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(BinaryReader reader)
		{
			filename = reader.ReadBytes(0x40);

			ushort count;
			byte type = reader.ReadByte();
			byte c = reader.ReadByte();
			if (type == 0x00)
			{
				format = type;
				count = c;
			}
			else if (type == 0xFE)
			{
				format = (ushort)((c << 8) | type);
				count = reader.ReadByte();
			}
			else
			{
				format = (ushort)((c << 8) | type);
				count = reader.ReadUInt16();
			}

			items = new List<StrItem>();
			languages = new Dictionary<byte, List<StrItem>>();
			while (items.Count < count)
			{
				items.Add(new StrItem(this, reader));
				if (!languages.ContainsKey(items[items.Count - 1].LanguageID))
				{
					languages.Add(
						items[items.Count - 1].LanguageID,
						new List<StrItem>()
					);
				}

				languages[items[items.Count - 1].LanguageID]
					.Add(items[items.Count - 1]);
			}

			CleanUp();
		}

		#endregion

		public const uint Strtype = 0x53545223;
		public const uint TTAstype = 0x54544173;
		public const uint CTSStype = 0x43545353;

		#region IFileWrapper Member
		/// <summary>
		/// Returns a list of File Types this Plugin can process
		/// </summary>
		public uint[] AssignableTypes => new uint[] { Strtype, TTAstype, CTSStype };

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by AbstractWrapper
		protected override string GetResourceName(Data.TypeAlias ta)
		{
			if (!Helper.FileFormat)
			{
				return base.GetResourceName(ta);
			}

			Interfaces.Files.IPackedFile pf = Package.Read(FileDescriptor);
			byte[] ab = pf.GetUncompressedData(0x42);
			return (
					ab.Length > 0x41
						? "0x"
							+ Helper.HexString(ab[0x41])
							+ Helper.HexString(ab[0x40])
							+ ": "
						: ""
				) + Helper.ToString(pf.GetUncompressedData(0x40));
		}
		#endregion

		#region pjse.ExtendedWrapper<StrItem> Members
		public new void Add(StrItem item)
		{
			if ((format == 0x0000 || format == 0xFFFE) && items.Count >= 0xFF)
			{
				return;
			}

			if (format == 0x0000)
			{
				item.Parent = null; // prevent anyone getting told about the change...
				item.LanguageID = 1;
			}

			item.Parent = this;

			if (!languages.ContainsKey(item.LanguageID))
			{
				languages.Add(item.LanguageID, new List<StrItem>());
			}

			if (!languages[item.LanguageID].Contains(item))
			{
				languages[item.LanguageID].Add(item);
			}

			items.Add(item);
			if (!item.Title.Trim().Equals("") || !item.Description.Trim().Equals(""))
			{
				OnWrapperChanged(items, new EventArgs());
			}
		}

		public void Add(byte lid, string title, string desc)
		{
			Add(new StrItem(this, lid, title, desc));
		}

		public new bool Remove(StrItem item)
		{
			if (item != null && languages.ContainsKey(item.LanguageID))
			{
				languages[item.LanguageID].Remove(item);
			}

			return base.Remove(item);
		}

		public bool Remove(byte lid)
		{
			foreach (StrItem si in items)
			{
				if (si.LanguageID == lid)
				{
					si.Title = si.Description = "";
				}
			}

			CleanUp();
			return true;
		}

		public void DefaultOnly()
		{
			foreach (StrItem si in items)
			{
				if (si.LanguageID != 1)
				{
					si.Title = si.Description = "";
				}
			}

			CleanUp();
		}

		public void CleanHim()
		{
			foreach (StrItem si in items)
			{
				if (
					si.LanguageID < 12
					|| (si.LanguageID > 12 && si.LanguageID < 21)
					|| si.LanguageID == 25
					|| si.LanguageID == 26
					|| si.LanguageID == 28
					|| si.LanguageID == 35
				)
				{
					si.Description = "";
				}
				else
				{
					si.Title = si.Description = "";
				}
			}

			CleanUp();
		}

		public StrItem this[byte lid, int index]
		{
			get
			{
				return (index >= 0 && index < this[lid].Count)
					? this[lid][index]
					: null;
			}
		}

		public List<StrItem> this[byte lid]
		{
			get
			{
				return languages.ContainsKey(lid)
					? languages[lid]
					: new List<StrItem>();
			}
		}

		/*public StrItem this[bool fallback, byte lid, int index]
		{
			get
			{
				StrItem i = this[lid, index];
				return (fallback && (i == null || i.Title.Trim().Equals(""))) ? this[0x01, index] : i;
			}
		}*/
		#endregion

		public void ExportLanguage(byte lid, String path)
		{
			StreamWriter sw = new StreamWriter(path, false);
			sw.WriteLine("<-Comment->");
			sw.WriteLine("PJSE String file - single language export");
			if (languages[lid].Count == 0)
			{
				sw.WriteLine("<-String->");
				sw.WriteLine("<-Desc->");
			}
			else
			{
				List<StrItem> items = this[lid];
				foreach (StrItem item in items)
				{
					sw.WriteLine("<-String->");
					if (item.Title.Trim().Length > 0)
					{
						sw.WriteLine(item.Title);
					}

					sw.WriteLine("<-Desc->");
					if (item.Description.Trim().Length > 0)
					{
						sw.WriteLine(item.Description);
					}
				}
			}
			sw.Close();
			sw.Dispose();
			sw = null;
		}

		public void ImportLanguage(byte lid, String path)
		{
			if (File.Exists(path))
			{
				StreamReader sr = new StreamReader(path);
				int lineCt = -1;
				bool isString = false;
				bool isDesc = false;
				for (string line = sr.ReadLine(); line != null; line = sr.ReadLine())
				{
					if (line.Equals("<-Comment->"))
					{
						isString = false;
						isDesc = false;
					}
					else if (line.Equals("<-String->"))
					{
						isString = true;
						isDesc = false;
						lineCt++;
						if (this[lid, lineCt] != null)
						{
							this[lid, lineCt].Description = this[lid, lineCt].Title =
								"";
						}
						else
						{
							Add(lid, "", "");
						}
					}
					else if (isString && line.Equals("<-Desc->"))
					{
						isString = false;
						isDesc = true;
					}
					else if (isString)
					{
						this[lid, lineCt].Title +=
							(this[lid, lineCt].Title.Length == 0 ? "" : "\n") + line;
					}
					else if (isDesc)
					{
						this[lid, lineCt].Description +=
							(this[lid, lineCt].Description.Length == 0 ? "" : "\n")
							+ line;
					}
				}
				sr.Close();
			}
		}
	}

	/// <summary>
	/// An Item stored in a STR# File
	/// </summary>
	public class StrItem : pjse.ExtendedWrapperItem<StrWrapper, StrItem>
	{
		#region Attributes
		private byte lid = 0;
		private string title = null;
		private string desc = null;
		#endregion

		#region Accessor methods
		public byte LanguageID
		{
			get
			{
				return lid;
			}
			set
			{
				if (lid != value)
				{
					lid = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				if (title != value)
				{
					title = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}

		public string Description
		{
			get
			{
				return desc;
			}
			set
			{
				if (desc != value)
				{
					desc = value;
					if (parent != null)
					{
						parent.OnWrapperChanged(this, new EventArgs());
					}
				}
			}
		}
		#endregion

		public StrItem(StrWrapper parent)
		{
			this.parent = parent;
		}

		public StrItem(StrWrapper parent, BinaryReader reader)
		{
			this.parent = parent;
			Unserialize(reader);
		}

		public StrItem(StrWrapper parent, byte lid, string title, string desc)
		{
			this.parent = parent;
			this.lid = lid;
			this.title = title;
			this.desc = desc;
		}

		public override string ToString()
		{
			return Title;
		}

		public static implicit operator String(StrItem si)
		{
			return si.Title;
		}

		public void Unserialize(BinaryReader reader)
		{
			if (parent.Format == 0x0000)
			{
				lid = 1;
				title = reader.ReadString();
				desc = "";
			}
			else if (parent.Format == 0xFFFE)
			{
				lid = (byte)(reader.ReadByte() + 1);
				title = UnserializeStringZero(reader);
				desc = "";
			}
			else
			{
				lid = reader.ReadByte();
				title = UnserializeStringZero(reader);
				desc = UnserializeStringZero(reader);
			}
		}

		public void Serialize(BinaryWriter writer)
		{
			if (parent.Format == 0x0000)
			{
				writer.Write(title);
			}
			else if (parent.Format == 0xFFFE)
			{
				writer.Write((byte)(lid - 1));
				SerializeStringZero(writer, title);
			}
			else
			{
				writer.Write(lid);
				SerializeStringZero(writer, title);
				SerializeStringZero(writer, desc);
			}
		}

		/* added a 'try / catch' because it throws error on a unicode char, the reader's encoding can't be set because it
		 * arrives as parameter. A unicode character generally means the file has some corruption anyway so we don't even
		 * attempt to read past it, don't add a message to the returned string to let the user know or error messages may
		 * become part of thier saved file without thier knowledge.
		 * CJH.
		*/
		private string UnserializeStringZero(BinaryReader r)
		{
			string s = "";
			while (r.BaseStream.Position < r.BaseStream.Length)
			{
				try
				{
					char b = r.ReadChar();
					if (b == 0)
					{
						break;
					}

					s += b;
				}
				catch
				{
					break;
				}
			}
			return s;
		}

		private void SerializeStringZero(BinaryWriter w, string s)
		{
			if (s != null)
			{
				foreach (char c in s)
				{
					w.Write(c);
				}
			}

			w.Write((char)0);
		}
	}
}
