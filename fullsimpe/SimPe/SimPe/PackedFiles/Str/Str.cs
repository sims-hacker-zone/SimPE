// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Str
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
		public FormatCode Format
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
		public List<StrLanguage> Languages
		{
			get
			{
				List<StrLanguage> lngs = new List<StrLanguage>();
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
						Lines.Add(l.Id, new List<StrToken>());
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
			List<StrToken> lng = (List<StrToken>)Lines[item.Language.Id];
			if (lng == null)
			{
				lng = new List<StrToken>();
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
			List<StrToken> lng = (List<StrToken>)Lines[item.Language.Id];
			lng?.Remove(item);
		}

		/// <summary>
		/// List<StrToken> interface to the lines hashtable
		/// </summary>
		public List<StrToken> Items
		{
			get
			{
				List<StrToken> items = new List<StrToken>();
				List<StrLanguage> lngs = Languages;
				foreach (StrLanguage k in lngs)
				{
					items.AddRange((List<StrToken>)Lines[k.Id]);
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
		public List<StrToken> LanguageItems(StrLanguage l)
		{
			return l == null ? new List<StrToken>() : LanguageItems((Languages)l.Id);
		}

		/// <summary>
		/// Returns all Language-specific Strings
		/// </summary>
		/// <param name="l">the Language</param>
		/// <returns>List of Strings</returns>
		public List<StrToken> LanguageItems(Languages l)
		{
			List<StrToken> items = (List<StrToken>)Lines[(byte)l] ?? new List<StrToken>();

			return items;
		}

		/// <summary>
		/// Returns a Language String (if available in the passed Language)
		/// </summary>
		/// <param name="l">the Language</param>
		/// <returns>List of Strings</returns>
		public StrToken FallbackedLanguageItem(Languages l, int index)
		{
			List<StrToken> list = LanguageItems(l);
			StrToken name = list.Count > index ? list[index] : new StrToken(0, 0, "", "");

			if (name.Title.Trim() == "")
			{
				list = LanguageItems(1);
				if (list.Count > index)
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
		public List<StrToken> FallbackedLanguageItems(Languages l)
		{
			if (l == Data.Languages.English)
			{
				return LanguageItems(l);
			}

			List<StrToken> real = LanguageItems(l).Select(item => item).ToList();
			List<StrToken> fallback = Languages.Contains(Data.Languages.English)
				? LanguageItems(Data.Languages.English)
				: Languages.Count == 1 ? LanguageItems(Languages[0]) : LanguageItems(Data.Languages.English);

			for (int i = 0; i < fallback.Count; i++)
			{
				if (real.Count <= i)
				{
					real.Add(fallback[i]);
				}
				else if (real[i] == null || real[i].Title.Trim() == "")
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
			Format = FormatCode.normal;
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
			Format = FormatCode.normal;
			Lines = new Hashtable();
			limit = 0;
		}

		/// <summary>
		/// Removes all String Items that are not assigned to the Default Language
		/// </summary>
		public void ClearNonDefault()
		{
			List<StrToken> sil = Items;
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
			List<StrToken> sil = Items;
			List<StrToken> def = LanguageItems(new StrLanguage(1));
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
			return new StrForm();
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

			FormatCode fo = (FormatCode)
				reader.ReadUInt16();
			if (fo != FormatCode.normal)
			{
				return;
			}

			ushort count = reader.ReadUInt16();

			filename = fi;
			Format = fo;
			Lines = new Hashtable();

			if (limit != 0 && count > limit)
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
			List<StrLanguage> lngs = Languages;

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
					+ Languages.Count.ToString()
					+ ", lines="
					+ Items.Count.ToString();
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
