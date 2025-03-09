// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Data;
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
	public class Str : AbstractWrapper, IFileWrapper, IFileWrapperSaveExtension
	{
		#region Attributes
		/// <summary>
		/// Contains the Filename
		/// </summary>
		byte[] filename;

		/// <summary>
		/// Maximum Number of Lines to load
		/// </summary>
		int limit;
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
				if (value.Length < 64)
				{
					char[] cs = value.ToCharArray();
					for (int i = 0; i < value.Length; i++)
					{
						filename[i] = (byte)cs[i];
					}

					for (int i = value.Length; i < 64; i++)
					{
						filename[i] = 0;
					}
				}
			}
		}

		/// <summary>
		/// Returns /Sets the Format Code
		/// </summary>
		public Data.FormatCode Format
		{
			get; set; // should check it's valid
		}

		/// <summary>
		/// Returns/Sets all stored lines
		/// </summary>
		/// <remarks>This is the fastes way to acces the String Items!</remarks>
		public Hashtable Lines
		{
			get; set;
		}
		#endregion

		#region Extended accessor methods

		/// <summary>
		/// Gets or Sets the list of languages in the file
		/// </summary>
		/// <remarks>Adds empty lists when setting for missing languages</remarks>
		public StrLanguageList Languages
		{
			get
			{
				StrLanguageList lngs = new StrLanguageList();
				foreach (byte k in Lines.Keys)
				{
					lngs.Add(k);
				}

				lngs.Sort();

				return lngs;
			}
			set
			{
				foreach (StrLanguage l in value)
				{
					if (!Lines.ContainsKey(l.Id))
					{
						Lines.Add(l.Id, new StrItemList());
					}
				}
			}
		}

		/// <summary>
		/// Adds a new String Item
		/// </summary>
		/// <param name="item">The Item you want to add</param>
		public void Add(StrToken item)
		{
			StrItemList lng = (StrItemList)Lines[item.Language.Id];
			if (lng == null)
			{
				lng = new StrItemList();
				Lines[item.Language.Id] = lng;
			}

			lng.Add(item);
		}

		/// <summary>
		/// Removes this Item From the List
		/// </summary>
		/// <param name="item">The Item you want to remove</param>
		public void Remove(StrToken item)
		{
			StrItemList lng = (StrItemList)Lines[item.Language.Id];
			lng?.Remove(item);
		}

		/// <summary>
		/// StrItemList interface to the lines hashtable
		/// </summary>
		public StrItemList Items
		{
			get
			{
				StrItemList items = new StrItemList();
				StrLanguageList lngs = Languages;
				foreach (StrLanguage k in lngs)
				{
					items.AddRange((StrItemList)Lines[k.Id]);
				}

				return items;
			}
			set
			{
				Lines = new Hashtable();
				foreach (StrToken i in value)
				{
					Add(i);
				}
			}
		}

		/// <summary>
		/// Returns all Language-specific Strings
		/// </summary>
		/// <param name="l">the Language</param>
		/// <returns>List of Strings</returns>
		public StrItemList LanguageItems(StrLanguage l)
		{
			return l == null ? new StrItemList() : LanguageItems((Data.Languages)l.Id);
		}

		/// <summary>
		/// Returns all Language-specific Strings
		/// </summary>
		/// <param name="l">the Language</param>
		/// <returns>List of Strings</returns>
		public StrItemList LanguageItems(Data.Languages l)
		{
			StrItemList items = (StrItemList)Lines[(byte)l] ?? new StrItemList();

			return items;
		}

		/// <summary>
		/// Returns a Language String (if available in the passed Language)
		/// </summary>
		/// <param name="l">the Language</param>
		/// <returns>List of Strings</returns>
		public StrToken FallbackedLanguageItem(Data.Languages l, int index)
		{
			StrItemList list = LanguageItems(l);
			StrToken name = list.Length > index ? list[index] : new StrToken(0, 0, "", "");

			if (name.Title.Trim() == "")
			{
				list = LanguageItems(1);
				if (list.Length > index)
				{
					name = list[index];
				}
			}

			return name;
		}

		/// <summary>
		/// Returns all Langugae specific Strings, if the String is not included in the passed
		/// Language the Fallback String (use en) will be returned
		/// </summary>
		/// <param name="l">the Language</param>
		/// <returns>List of Strings</returns>
		public StrItemList FallbackedLanguageItems(Data.Languages l)
		{
			if (l == Data.Languages.English)
			{
				return LanguageItems(l);
			}

			StrItemList real = (StrItemList)LanguageItems(l).Clone();
			StrItemList fallback = Languages.Contains(Data.Languages.English)
				? LanguageItems(Data.Languages.English)
				: Languages.Count == 1 ? LanguageItems(Languages[0]) : LanguageItems(Data.Languages.English);

			for (int i = 0; i < fallback.Length; i++)
			{
				if (real.Length <= i)
				{
					real.Add(fallback[i]);
				}
				else if ((real[i] == null) || (real[i].Title.Trim() == ""))
				{
					real[i] = fallback[i];
				}
			}

			return real;
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Str(int limit)
			: base()
		{
			filename = new byte[64];
			Format = Data.FormatCode.normal;
			Lines = new Hashtable();
			this.limit = limit;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public Str()
			: base()
		{
			filename = new byte[64];
			Format = Data.FormatCode.normal;
			Lines = new Hashtable();
			limit = 0;
		}

		/// <summary>
		/// Removes all String Items that are not assigned to the Default Language
		/// </summary>
		public void ClearNonDefault()
		{
			StrItemList sil = Items;
			foreach (StrToken si in sil)
			{
				if (si.Language.Id != 1)
				{
					Remove(si);
				}
			}
		}

		/// <summary>
		/// Copy the content of the Default Language down to the other Languages
		/// </summary>
		public void CopyFromDefaultToAll()
		{
			StrItemList sil = Items;
			StrItemList def = LanguageItems(new StrLanguage(1));
			foreach (StrToken si in sil)
			{
				if (si.Language.Id != 1)
				{
					if (si.Index > 0 && si.Index < def.Count)
					{
						si.Title = def[si.Index].Title;
						si.Description = def[si.Index].Description;
					}
				}
			}
		}

		#region IWrapper member
		public override bool CheckVersion(uint version)
		{
			return true;
		}
		#endregion

		#region AbstractWrapper Member
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
				"Text List Wrapper",
				"Quaxi",
				"This Wrapper is overridden by 'PJSE STR#/TTAs/CTSS Wrapper' if it's enabled",
				9,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.txt.png")
				)
			);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		protected override void Unserialize(System.IO.BinaryReader reader)
		{
			Lines = new Hashtable();
			if (reader.BaseStream.Length <= 0x40)
			{
				return;
			}

			byte[] fi = reader.ReadBytes(0x40);

			Data.FormatCode fo = (Data.FormatCode)
				reader.ReadUInt16();
			if (fo != Data.FormatCode.normal)
			{
				return;
			}

			ushort count = reader.ReadUInt16();

			filename = fi;
			Format = fo;
			Lines = new Hashtable();

			if ((limit != 0) && (count > limit))
			{
				count = (ushort)limit; // limit number of StrItem entries loaded
			}

			for (int i = 0; i < count; i++)
			{
				StrToken.Unserialize(reader, Lines);
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
		protected override void Serialize(System.IO.BinaryWriter writer)
		{
			writer.Write(filename);
			writer.Write((ushort)Format);
			ArrayList lngs = Languages;

			ArrayList items = new ArrayList();
			foreach (StrLanguage k in lngs)
			{
				items.AddRange((ArrayList)Lines[k.Id]);
			}

			writer.Write((ushort)items.Count);

			foreach (StrToken i in items)
			{
				i.Serialize(writer);
			} //foreach language
		}
		#endregion

		#region IFileWrapperSaveExtension Member
		//all covered by Serialize()
		#endregion

		#region IFileWrapper Member
		public override string Description
		{
			get
			{
				string n =
					"filename="
					+ FileName
					+ ", languages="
					+ Languages.Length.ToString()
					+ ", lines="
					+ Items.Length.ToString();
				foreach (
					StrToken i in FallbackedLanguageItems(
						Helper.WindowsRegistry.Config.LanguageCode
					)
				)
				{
					if (i.Title != "")
					{
						return n + ", first=" + i.Title;
					}
				}

				return n + " (no strings)";
			}
		}

		/// <summary>
		/// Returns the Signature that can be used to identify Files processable with this Plugin
		/// </summary>
		public byte[] FileSignature => new byte[0];

		/// <summary>
		/// Returns a list of File Types this Plugin can process
		/// </summary>
		public FileTypes[] AssignableTypes
		{
			get
			{
				FileTypes[] types =
				{
					FileTypes.STR,
					FileTypes.TTAs,
					FileTypes.CTSS,
				};

				return types;
			}
		}

		#endregion
	}
}
