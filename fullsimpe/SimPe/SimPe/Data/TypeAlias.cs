// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Data
{
	/// <summary>
	/// Conects an Type Id Value with a name
	/// </summary>
	public sealed class TypeAlias : Alias
	{
		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="shortname">The short name</param>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		public TypeAlias(bool containsflname, string shortname, uint val, string name)
			: base(val, name)
		{
			this.shortname = shortname;
			extension = null;
			Known = true;
			containsfilename = containsflname;
			IgnoreDuringCacheBuild = false;
		}

		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="shortname">The short name</param>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		/// <param name="extension">proposed File Extension</param>
		/// <param name="containsflname">true if the first 64 Bytes are the Filename</param>
		/// <param name="known">true if the filetype is known(default)</param>
		public TypeAlias(
			bool containsflname,
			string shortname,
			uint val,
			string name,
			string extension
		)
			: this(containsflname, shortname, val, name, extension, true, false) { }

		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="shortname">The short name</param>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		/// <param name="extension">proposed File Extension</param>
		/// <param name="containsflname">true if the first 64 Bytes are the Filename</param>
		/// <param name="known">true if the filetype is known(default)</param>
		/// <param name="nodecompforcache">true, if this resource should not get decompressed during cache build/update</param>
		public TypeAlias(
			bool containsflname,
			string shortname,
			uint val,
			string name,
			string extension,
			bool known,
			bool nodecompforcache
		)
			: base(val, name)
		{
			this.shortname = shortname;
			this.extension = extension;
			Known = known;
			containsfilename = containsflname;
			IgnoreDuringCacheBuild = nodecompforcache;
		}

		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="shortname">The short name</param>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		/// <param name="known">true if the filetype is known(default)</param>
		/// <param name="nodecompforcache">true, if this resource should not get decompressed during cache build/update</param>
		public TypeAlias(
			bool containsflname,
			string shortname,
			uint val,
			string name,
			bool known,
			bool nodecompforcache
		)
			: base(val, name)
		{
			this.shortname = shortname;
			extension = "";
			Known = known;
			containsfilename = containsflname;
			IgnoreDuringCacheBuild = nodecompforcache;
		}

		/*
		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// Obsolete - Only here for compatibility
		/// <param name="shortname">The short name</param>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		/// <param name="known">true if the filetype is known(default)</param>
		public TypeAlias(bool containsflname, string shortname, uint val, string name, bool known)
			: base(val, name)
		{

			this.shortname = shortname;
			this.extension = "";
			knowntype = known;
			this.containsfilename = containsflname;
			this.nodecompforcache = true;
		}
		*/
		/// <summary>
		/// True if the first 64 Byte of this Type are interpreted as Filename
		/// </summary>
		public bool containsfilename;

		/// <summary>
		/// The associated short name
		/// </summary>
		public string shortname;

		/// <summary>
		/// null, or a proposed File extension
		/// </summary>
		private string extension;

		/// <summary>
		/// Returns the default Extension
		/// </summary>
		public string Extension
		{
			get
			{
				if (extension == null)
				{
					return "simpe";
				}
				else if (extension == "")
				{
					return "simpe";
				}

				return extension;
			}
		}

		/// <summary>
		/// Craetes a String from the Object
		/// </summary>
		/// <returns>Simply Returns the Name Attribute</returns>
		public override string ToString()
		{
			return Name;
		}

		/// <summary>
		/// Returns true if the Type is known
		/// </summary>
		public bool Known
		{
			get;
		}

		/// <summary>
		/// Returns true, if this resource should be ignored during the cache build phase
		/// </summary>
		public bool IgnoreDuringCacheBuild
		{
			get;
		}
	}
}
