// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Objd;
using SimPe.PackedFiles.Str;

namespace SimPe.Packages
{
	/// <summary>
	/// Basic Descriptor used for Dependency Files
	/// </summary>
	public class S2CPDescriptorBase
	{
		/// <summary>
		/// Creates a new Instance
		/// </summary>
		/// <param name="p">The Package this Object describes</param>
		public S2CPDescriptorBase(GeneratableFile p)
		{
			package = p;
			objectversion = "0";

			if (p != null)
			{
				name = System.IO.Path.GetFileName(p.FileName);
				if (name == "")
				{
					name = Localization.Manager.GetString("Unknown") + ".package";
				}

				string author = "";
				string title = "";
				string description = "";
				string contact = "";
				string gameguid = "";
				guid = GetGlobalGuid(
					p,
					ref name,
					ref title,
					ref author,
					ref contact,
					ref description,
					ref gameguid
				);
			}
		}

		/// <summary>
		/// Reads the Guid from the Package
		/// </summary>
		/// <param name="p">The Package to load the Guid From</param>
		/// <param name="name">Returns the name stored in te package</param>
		/// <param name="title">The Title of this package</param>
		/// <param name="author">Author of this package</param>
		/// <param name="contact">How to contact the Author</param>
		/// <param name="description">Description of this Package</param>
		/// <param name="gameguid">The List of original Game Guids</param>
		/// <returns>null if no GUID Data was found, otherwise null</returns>
		public static string GetGlobalGuid(
			File p,
			ref string name,
			ref string title,
			ref string author,
			ref string contact,
			ref string description,
			ref string gameguid
		)
		{
			string guid = null;

			Interfaces.Files.IPackedFileDescriptor pfd = p.FindFile(
				Data.FileTypes.STR,
				0xffffffff,
				0x00000000,
				0xffffffff
			);
			if (pfd != null)
			{
				List<StrToken> sitems = new PackedFiles.Str.Str().ProcessFile(pfd, p).LanguageItems(1);

				if (sitems.Count > 0)
				{
					guid = sitems[0].Title;
					gameguid = sitems[0].Description;
				}
				else
				{
					guid = System.Guid.NewGuid().ToString();
				}

				if (sitems.Count > 1)
				{
					author = sitems[1].Title;
					contact = sitems[1].Description;
				}

				if (sitems.Count > 2)
				{
					name = sitems[2].Title;
				}
			}

			//Title and Description is stored in the CatalogString
			Interfaces.Files.IPackedFileDescriptor[] pfds = p.FindFiles(
				Data.FileTypes.OBJD
			);

			uint ctssid = 1;
			uint group = 0xffffffff;
			if (pfds.Length > 0)
			{
				Objd objd =
					new PackedFiles.Objd.Objd(null).ProcessFile(pfds[0], p);
				ctssid = objd.CTSSId;
				group = objd.FileDescriptor.Group;
			}

			pfd = p.FindFile(Data.FileTypes.CTSS, 0, group, ctssid);
			if (pfd != null)
			{
				List<StrToken> sitems = new PackedFiles.Str.Str().ProcessFile(pfd, p).LanguageItems(1);

				if (sitems.Count > 0)
				{
					title = sitems[0].Title;
				}

				if (sitems.Count > 1)
				{
					description = sitems[1].Title;
				}
			}
			return guid;
		}

		/// <summary>
		/// Possible results of a Validation
		/// </summary>
		/// <remarks>CRCMismath is not used yet</remarks>
		public enum ValidationState
		{
			/// <summary>
			/// The Data is consistent
			/// </summary>
			OK = 0x00,

			/// <summary>
			/// The CRC from the XMl and the actual CRC do not match
			/// </summary>
			CRCMismatch = 0x01,

			/// <summary>
			/// The GlobalGUID from the Xml and the GlobalGUID stored in the package do not match
			/// </summary>
			GlobalGUIDMismatch = 0x02,

			/// <summary>
			/// The Name from the Xml and the one stored in the package do not match
			/// </summary>
			NameMismatch = 0x03,

			/// <summary>
			/// The Name of teh Author does not match
			/// </summary>
			AuthorMismatch = 0x04,

			/// <summary>
			/// The original Guids have changed
			/// </summary>
			GameGuidMismatch = 0x05,

			/// <summary>
			/// The Data could not be validated
			/// </summary>
			UnableToValidate = 0xff,
		};

		/// <summary>
		/// validates the package aginst the stored GUID/Name
		/// </summary>
		/// <remarks>If you have loaded a Package from a S2CP File, the GUID and Name Attributes of this Object
		/// will contain the values stored in the Describing XML. You can validate those Values against the Data
		/// stored in the Package itself with this Method.</remarks>
		public virtual ValidationState Valid
		{
			get
			{
				if (package == null)
				{
					return ValidationState.UnableToValidate;
				}

				string n = "-";
				string t = "-";
				string a = "-";
				string c = "-";
				string d = "-";
				string gg = "-";
				string g = GetGlobalGuid(
					package,
					ref n,
					ref t,
					ref a,
					ref c,
					ref d,
					ref gg
				);

				return g != guid ? ValidationState.GlobalGUIDMismatch : n != name ? ValidationState.NameMismatch : ValidationState.OK;
			}
		}

		/// <summary>
		/// If this Dependency Optional
		/// </summary>
		protected bool optional;

		/// <summary>
		/// If this Dependency Optional
		/// </summary>
		public bool Optional
		{
			get => optional;
			set => optional = value;
		}

		/// <summary>
		/// Filename of the container Package (can return null)
		/// </summary>
		protected string name;

		/// <summary>
		/// Returns/Sets the Filename of the container Package (can return null)
		/// </summary>
		public string Name
		{
			get => name;
			set => name = value;
		}

		/// <summary>
		/// Description for the File
		/// </summary>
		protected string objectversion;

		/// <summary>
		/// Returns/Sets the Description for the File
		/// </summary>
		public string ObjectVersion
		{
			get => objectversion;
			set => objectversion = value;
		}

		/// <summary>
		/// The guid for the File or (can return null)
		/// </summary>
		protected string guid;

		/// <summary>
		/// Returns/Sets the The guid for the File or (can return null)
		/// </summary>
		public string Guid
		{
			get => guid;
			set => guid = value;
		}

		/// <summary>
		/// The associated Package
		/// </summary>
		protected GeneratableFile package;

		/// <summary>
		/// Returns/Sets the The associated Package
		/// </summary>
		public GeneratableFile Package
		{
			get => package;
			set => package = value;
		}

		/// <summary>
		/// Retursn a descriptive String for the Object
		/// </summary>
		/// <returns>The Description of this Object</returns>
		public override string ToString()
		{
			return Guid != null ? Name + " (" + Guid + ")" : Name;
		}
	}

	/// <summary>
	/// Descriptor for a Packed file in the the S2CP
	/// </summary>
	public class S2CPDescriptor : S2CPDescriptorBase
	{
		/// <summary>
		/// Creates a new Insttance
		/// </summary>
		/// <param name="p">The Package this Object describes</param>
		/// <param name="author">Author of this Package</param>
		/// <param name="contact">How to contact the Autor</param>
		/// <param name="title">Title of this Package</param>
		/// <param name="description">Description for the Package</param>
		/// <param name="compressed">true if this Package should be stored compressed</param>
		/// <param name="extension">true, if you wnt to use the Community Extionsins (Will create a textFile in the Package if needed)</param>
		/// <param name="dependency">Objects this one depends on</param>
		public S2CPDescriptor(
			GeneratableFile p,
			string author,
			string contact,
			string title,
			string description,
			Sims2CommunityPack.CompressionStrength compressed,
			S2CPDescriptorBase[] dependency,
			bool extension
		)
			: base(p)
		{
			Type = "Object";
			GameVersion = "2141707388.153.1";
			this.description = description;
			Compressed = compressed;
			objectversion = "1.0";
			Crc = "0";
			this.author = author;
			this.contact = contact;
			this.title = title;
			gameguid = GameGuid;

			Dependency = dependency == null ? (new S2CPDescriptorBase[0]) : dependency;

			if (p != null)
			{
				guid = GetSetGlobalGuid(
					p,
					ref name,
					ref this.title,
					ref this.author,
					ref this.contact,
					ref this.description,
					ref gameguid
				);
			}
		}

		/// <summary>
		/// Updates the S2CP ID File with the cuurrent settings
		/// </summary>
		/// <param name="p">The Package to change/read from</param>
		/// <param name="guid">The packages GUID</param>
		/// <param name="name">The Name for the Package (used if the File is created)</param>
		/// <param name="author">Author of this package</param>
		/// <param name="contact">How to contact the Author</param>
		/// <param name="gameguid">The List of original Game Guids</param>
		/// <returns>the stored or the new GlobalGUID</returns>
		public static void UpdateGlobalGuid(
			File p,
			string guid,
			string name,
			string author,
			string contact,
			string gameguid
		)
		{
			Interfaces.Files.IPackedFileDescriptor pfd = p.FindFile(
				Data.FileTypes.STR,
				0xffffffff,
				0x00000000,
				0xffffffff
			);
			Str str = null;

			StrLanguage[] lng =
				new StrLanguage[1];
			lng[0] = new PackedFiles.Str.StrLanguage(1);

			if (pfd == null)
			{
				str = new PackedFiles.Str.Str
				{
					FileDescriptor = new PackedFileDescriptor
					{
						Type = Data.FileTypes.STR,
						Group = 0,
						SubType = 0xffffffff,
						Instance = 0xffffffff
					}
				};
				str.Languages.Add(lng[0]);
				// str.SynchronizeUserData();
				// str.Package = p;
				p.Add(str.FileDescriptor);
			}
			else
			{
				str = new PackedFiles.Str.Str().ProcessFile(pfd, p);
			}
			List<StrToken> items = str.LanguageItems(1);

			if (guid == null)
			{
				guid = System.Guid.NewGuid().ToString();
			}

			if (str.Items.Count > 0)
			{
				str.Items[0].Title = guid;
				str.Items[0].Description = gameguid;
			}
			else
			{
				str.Add(
					new PackedFiles.Str.StrToken(0, lng[0], guid, gameguid)
				);
			}

			if (str.Items.Count > 1)
			{
				str.Items[1].Title = author;
				str.Items[1].Description = contact;
			}
			else
			{
				str.Add(
					new PackedFiles.Str.StrToken(1, lng[0], author, contact)
				);
			}

			if (str.Items.Count > 2)
			{
				str.Items[2].Title = name;
				str.Items[2].Description = "";
			}
			else
			{
				str.Add(new PackedFiles.Str.StrToken(2, lng[0], name, ""));
			}

			str.SynchronizeUserData();
		}

		/// <summary>
		/// Updates the S2CP ID File with the cuurrent settings
		/// </summary>
		/// <param name="p">The Package to change/read from</param>
		/// <param name="title">Title of this Object</param>
		/// <param name="description">Description of this Package</param>
		/// <returns>the stored or the new GlobalGUID</returns>
		public static void UpdateGlobalGuid(File p, string title, string description)
		{
			Interfaces.Files.IPackedFileDescriptor pfd = null;
			Str str = null;

			StrLanguage[] lng =
				new StrLanguage[1];
			lng[0] = new PackedFiles.Str.StrLanguage(1);

			//Title and Description is stored in the CatalogString
			Interfaces.Files.IPackedFileDescriptor[] pfds = p.FindFiles(
				Data.FileTypes.OBJD
			);
			uint ctssid = 1;
			uint group = 0xffffffff;
			if (pfds.Length > 0)
			{
				Objd objd =
					new PackedFiles.Objd.Objd(null).ProcessFile(pfds[0], p);
				ctssid = objd.CTSSId;
				group = objd.FileDescriptor.Group;
			}

			pfd = p.FindFile(Data.FileTypes.CTSS, 0, group, ctssid);
			if (pfd == null)
			{
				str = new PackedFiles.Str.Str
				{
					FileDescriptor = new PackedFileDescriptor
					{
						Type = Data.FileTypes.CTSS,
						Group = 0xffffffff,
						SubType = 0x00000000,
						Instance = 0x1
					}
				};

				str.Languages.Add(lng[0]);

				p.Add(str.FileDescriptor);
			}
			else
			{
				str = new PackedFiles.Str.Str().ProcessFile(pfd, p);
			}

			List<StrToken> items = str.LanguageItems(1);
			if (str.Items.Count > 0)
			{
				str.Items[0].Title = title;
			}
			else
			{
				str.Add(new PackedFiles.Str.StrToken(0, lng[0], title, ""));
			}

			if (str.Items.Count > 1)
			{
				str.Items[1].Title = description;
			}
			else
			{
				str.Add(
					new PackedFiles.Str.StrToken(1, lng[0], description, "")
				);
			}

			str.SynchronizeUserData();
		}

		/// <summary>
		/// Synchronizes the S2CP ID File with the current Settings
		/// </summary>
		public void Update()
		{
			UpdateGlobalGuid(
				Package,
				guid,
				name,
				author,
				contact,
				gameguid
			);
			UpdateGlobalGuid(Package, title, description);
		}

		/// <summary>
		/// Adds theGlobalGUID Data to the package if it is missing and generates a new GUID for it.
		/// </summary>
		/// <param name="p">The Package to change/read from</param>
		/// <param name="name">The Name for the Package (used if the File is created)</param>
		/// <param name="title">Title of this Object</param>
		/// <param name="author">Author of this package</param>
		/// <param name="contact">How to contact the Author</param>
		/// <param name="description">Description of this Package</param>
		/// <param name="gameguid">The List of original Game Guids</param>
		/// <returns>the stored or the new GlobalGUID</returns>
		/// <remarks>If the GlobalGUID File does exist, the Data from this File will be returned and no new
		/// GlobalGUID will be returned</remarks>
		public static string GetSetGlobalGuid(
			File p,
			ref string name,
			ref string title,
			ref string author,
			ref string contact,
			ref string description,
			ref string gameguid
		)
		{
			string guid = null;

			Interfaces.Files.IPackedFileDescriptor pfd = p.FindFile(
				Data.FileTypes.STR,
				0xffffffff,
				0x00000000,
				0xffffffff
			);
			if (pfd == null)
			{
				guid = System.Guid.NewGuid().ToString();
				UpdateGlobalGuid(p, guid, name, author, contact, gameguid);
			}
			else
			{
				guid = GetGlobalGuid(
					p,
					ref name,
					ref title,
					ref author,
					ref contact,
					ref description,
					ref gameguid
				);
			}

			Interfaces.Files.IPackedFileDescriptor[] pfds = p.FindFiles(
				Data.FileTypes.OBJD
			);
			uint ctssid = 1;
			uint group = 0xffffffff;
			if (pfds.Length > 0)
			{
				Objd objd =
					new PackedFiles.Objd.Objd(null).ProcessFile(pfds[0], p);
				ctssid = objd.CTSSId;
				group = objd.FileDescriptor.Group;
			}

			pfd = p.FindFile(Data.FileTypes.CTSS, 0, group, ctssid);
			if (pfd == null)
			{
				UpdateGlobalGuid(p, title, description);
			}
			else
			{
				guid = GetGlobalGuid(
					p,
					ref name,
					ref title,
					ref author,
					ref contact,
					ref description,
					ref gameguid
				);
			}

			return guid;
		}

		/// <summary>
		/// validates the package aginst the stored GUID/Name
		/// </summary>
		/// <remarks>If you have loaded a Package from a S2CP File, the GUID and Name Attributes of this Object
		/// will contain the values stored in the Describing XML. You can validate those Values against the Data
		/// stored in the Package itself with this Method.</remarks>
		///
		public override ValidationState Valid
		{
			get
			{
				if (package == null)
				{
					return ValidationState.UnableToValidate;
				}

				string n = "-";
				string t = "-";
				string a = "-";
				string c = "-";
				string d = "-";
				string gg = "-";
				string g = GetGlobalGuid(
					package,
					ref n,
					ref t,
					ref a,
					ref c,
					ref d,
					ref gg
				);

				return g != guid
					? ValidationState.GlobalGUIDMismatch
					: n != name
					? ValidationState.NameMismatch
					: a != author && a != ""
					? ValidationState.AuthorMismatch
					: gg != GameGuid && GameGuid != "" ? ValidationState.GameGuidMismatch : ValidationState.OK;
			}
		}

		/// <summary>
		/// Returns/Sets the  list of objects this one depends on
		/// </summary>
		public S2CPDescriptorBase[] Dependency
		{
			get; set;
		}

		/// <summary>
		/// Title of the Package
		/// </summary>
		string title;

		/// <summary>
		/// Returns/Sets the Title of the Package
		/// </summary>
		public string Title
		{
			get => title;
			set => title = value;
		}

		/// <summary>
		/// Returns/Sets the Type of the Package
		/// </summary>
		public string Type
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets the Versionnumber of the Game
		/// </summary>
		public string GameVersion
		{
			get; set;
		}

		/// <summary>
		/// Returns/Sets the Description for the File
		/// </summary>
		public string Crc
		{
			get; set;
		}

		/// <summary>
		/// Description for the File
		/// </summary>
		string description;

		/// <summary>
		/// Returns/Sets the Description for the File
		/// </summary>
		public string Description
		{
			get => description;
			set => description = value;
		}

		/// <summary>
		/// Author of the File
		/// </summary>
		string author;

		/// <summary>
		/// Returns/Sets the Author of the File
		/// </summary>
		public string Author
		{
			get => author;
			set => author = value;
		}

		/// <summary>
		/// Author of the File
		/// </summary>
		string contact;

		/// <summary>
		/// Returns/Sets the Contact Person of the File
		/// </summary>
		public string Contact
		{
			get => contact;
			set => contact = value;
		}

		string gameguid;

		/// <summary>
		/// Returns a Space seperated List of all Guids stored in the Package
		/// </summary>
		public string GameGuid
		{
			get
			{
				if (gameguid != null)
				{
					return gameguid;
				}

				if (package == null)
				{
					return "";
				}

				Interfaces.Files.IPackedFileDescriptor[] pfds = package.FindFiles(
					Data.FileTypes.OBJD
				);
				gameguid = "";
				foreach (Interfaces.Files.IPackedFileDescriptor pfd in pfds)
				{
					Objd objd =
						new PackedFiles.Objd.Objd(null).ProcessFile(pfd, package);
					gameguid += " 0x" + Helper.HexString(objd.Guid);
					// gameguid += " " + objd.Guid.ToString();
				}

				return gameguid.Trim();
			}
			set => gameguid = value;
		}

		/// <summary>
		/// Returns /Sets wether the File should be Compressed or Not
		/// </summary>
		/// <remarks>After the Description is loaded form a s2cp File, this Property
		/// Indicates if the Package was compressed or not</remarks>
		public Sims2CommunityPack.CompressionStrength Compressed
		{
			get; set;
		}

		/// <summary>
		/// Retursn a descriptive String for the Object
		/// </summary>
		/// <returns>The Description of this Object</returns>
		public override string ToString()
		{
			return Guid != null
				? Name
					+ " ("
					+ Guid
					+ ", Compression="
					+ Compressed.ToString()
					+ ", State="
					+ Valid.ToString()
					+ ")"
				: Name;
		}
	}
}
