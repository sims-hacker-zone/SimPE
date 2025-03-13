// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SimPe.PackedFiles.Str
{
	#region StrLanguage
	/// <summary>
	/// This class exists:
	/// - to provide access to Language Names given a Language ID
	/// - to make Language IDs comparable so that StrLanguageLists can be sorted
	/// </summary>
	public class StrLanguage : IComparer
	{

		/// <summary>
		/// Constructor
		/// This is the only way to set the Language ID
		/// </summary>
		/// <param name="lid">The Language ID</param>
		public StrLanguage(byte lid)
		{
			Id = lid;
		}

		#region Accessor methods
		/// <summary>
		/// Returns/Sets the Language Id
		/// </summary>
		public byte Id
		{
			get;
		}

		/// <summary>
		/// Returns the Language Name
		/// </summary>
		public string Name
		{
			get
			{
				string enumName = ((Data.Languages)Id).ToString();
				return Localization.Manager.GetString(enumName) ?? enumName;
			}
		}
		#endregion

		#region Cast methods
		public override string ToString()
		{
			return "0x" + Helper.HexString(Id) + " - " + Name;
		}

		// Enable casting byte to StrLanguage
		public static implicit operator StrLanguage(byte val)
		{
			return new StrLanguage(val);
		}

		// Enable casting StrLanguage to byte
		public static implicit operator byte(StrLanguage val)
		{
			return val.Id;
		}

		public static implicit operator Data.Languages(StrLanguage val)
		{
			return (Data.Languages)val.Id;
		}

		public static implicit operator StrLanguage(Data.Languages val)
		{
			return new StrLanguage((byte)val);
		}
		#endregion

		public override bool Equals(object obj)
		{
			return obj.GetType() == typeof(StrLanguage) ? Id == ((StrLanguage)obj).Id : base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#region IComparer Member
		/// <summary>
		/// Allow StrLanguage and byte objects to be compared
		/// </summary>
		/// <param name="x">First item (StrLanguage, byte)</param>
		/// <param name="y">Second Item (StrLanguage, byte)</param>
		/// <returns>Comparison value or "equal" if invalid object types passed</returns>
		public int Compare(object x, object y)
		{
			int a,
				b;

			if (x.GetType() == typeof(StrLanguage))
			{
				a = ((StrLanguage)x).Id;
			}
			else if (x.GetType() == typeof(byte))
			{
				a = (byte)x;
			}
			else
			{
				return 0;
			}

			if (y.GetType() == typeof(StrLanguage))
			{
				b = ((StrLanguage)y).Id;
			}
			else if (y.GetType() == typeof(byte))
			{
				b = (byte)y;
			}
			else
			{
				return 0;
			}

			return b - a;
		}
		#endregion
	}
	#endregion

	#region StrItem
	/// <summary>
	/// An Item stored in a STR# File
	/// </summary>
	public class StrToken
	{
		string title;
		string desc;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="index">hack to give line numbers</param>
		/// <param name="lid">Language ID (byte)</param>
		/// <param name="title">Item Title</param>
		/// <param name="desc">Item Description</param>
		public StrToken(int index, byte lid, string title, string desc)
		{
			Index = index;
			Language = new StrLanguage(lid);
			this.title = title;
			this.desc = desc;
			IsDirty = false;
		}

		#region Accessor methods
		internal int Index
		{
			get;
		}

		/// <summary>
		/// Language is read-only
		/// </summary>
		public StrLanguage Language
		{
			get;
		}

		public string Title
		{
			get => title;
			set
			{
				if (title != value)
				{
					title = value;
					IsDirty = true;
				}
			}
		}

		public string Description
		{
			get => desc;
			set
			{
				if (desc != value)
				{
					desc = value;
					IsDirty = true;
				}
			}
		}

		/// <summary>
		/// Dirty is read-only
		/// </summary>
		public bool IsDirty
		{
			get; private set;
		}
		#endregion


		#region Serialize / Unserialize
		/*
		 * File format is:
		 * byte - Language ID
		 * char[]\0 - Title
		 * char[]\0 - Description
		 */
		internal static void Unserialize(BinaryReader reader, Hashtable lines)
		{
			StrLanguage lid = new StrLanguage(reader.ReadByte());
			string title = StreamHelper.ReadPChar(reader);
			string desc = StreamHelper.ReadPChar(reader);

			if (lines[lid.Id] == null)
			{
				lines[lid.Id] = new List<StrToken>(); // Add a new List<StrToken> if needed
			} ((List<StrToken>)lines[lid.Id]).Add(
				new StrToken(((List<StrToken>)lines[lid.Id]).Count, lid, title, desc)
			);
		}

		internal void Serialize(BinaryWriter writer)
		{
			if (Language != null)
			{
				writer.Write(Language.Id);
			}
			else
			{
				writer.Write((byte)0);
			}

			if (title != null)
			{
				StreamHelper.WritePChar(writer, title);
			}
			else
			{
				StreamHelper.WritePChar(writer, "");
			}

			if (desc != null)
			{
				StreamHelper.WritePChar(writer, desc);
			}
			else
			{
				StreamHelper.WritePChar(writer, "");
			}
			//			dirty = false;
			// Mmm, "dirty" means what?  OK, so I added it...
		}
		#endregion

		public override string ToString()
		{
			return "0x" + Index.ToString("X") + " - " + Title;
		}
	}
	#endregion
}
