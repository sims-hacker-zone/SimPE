namespace SimPe
{
	/// <summary>
	/// The type and location of a Folder/file
	/// </summary>
	public class FileTableItem
	{
		string relpath;
		string path;

		public FileTableItem(string path)
		{
			IsRecursive = false;
			IsFile = false;
			if (path.StartsWith(":"))
			{
				path = path.Substring(1, path.Length - 1);
				IsRecursive = true;
			}
			else if (path.StartsWith("*"))
			{
				path = path.Substring(1, path.Length - 1);
				IsFile = true;
			}

			this.path = path;
			relpath = path;
			EpVersion = -1;
			Type = FileTablePaths.Absolute;
			Ignore = false;
		}

		public bool Ignore
		{
			get; set;
		}

		public FileTableItem(string path, bool rec, bool fl)
			: this(path, rec, fl, -1, false) { }

		public FileTableItem(string path, bool rec, bool fl, int ver)
			: this(path, rec, fl, ver, false) { }

		public FileTableItem(string path, bool rec, bool fl, int ver, bool ign)
			: this(path, FileTablePaths.Absolute, rec, fl, ver, ign) { }

		public FileTableItem(
			string relpath,
			FileTableItemType type,
			bool rec,
			bool fl,
			int ver,
			bool ign
		)
		{
			IsRecursive = rec;
			IsFile = fl;
			EpVersion = ver;
			Type = type;
			SetName(relpath);
			Ignore = ign;
		}

		internal void SetRecursive(bool state)
		{
			IsRecursive = state;
		}

		internal void SetFile(bool state)
		{
			IsFile = state;
		}

		public static string GetRoot(FileTableItemType type)
		{
			string ret = null;
			ret = type.GetRoot();

			if (ret != null)
			{
				if (!ret.EndsWith(Helper.PATH_SEP))
				{
					ret += Helper.PATH_SEP;
				}
			}

			if (ret == Helper.PATH_SEP)
			{
				ret = null;
			}

			return ret;
		}

		public static int GetEPVersion(FileTableItemType type)
		{
			return type.GetEPVersion();
		}

		bool CutName(string name, FileTableItemType type)
		{
			try
			{
				if (System.IO.Directory.Exists(name))
				{
					if (!Helper.IsAbsolutePath(name))
					{
						return false;
					}
				}
			}
			catch { }

			string root = GetRoot(type);
			if (root == null || root == "" || root == Helper.PATH_SEP)
			{
				return false;
			}

			root = Helper.CompareableFileName(Helper.ToLongPathName(root));
			if (!root.EndsWith(Helper.PATH_SEP))
			{
				root += Helper.PATH_SEP;
			}

			string ename = Helper.CompareableFileName(name);
			name = name.Trim();
			if (!ename.EndsWith(Helper.PATH_SEP))
			{
				ename += Helper.PATH_SEP;
				name += Helper.PATH_SEP;
			}

			if (ename.StartsWith(root))
			{
				path = name.Substring(root.Length); //ename.Replace(root, "");
				if (!IsFile)
				{
					if (path.StartsWith(Helper.PATH_SEP))
					{
						path = path.Substring(1);
					}
				}

				Type = type;
				return true;
			}

			return false;
		}

		internal void SetName(string name)
		{
			string n = name;

			foreach (ExpansionItem ei in PathProvider.Global.Expansions)
			{
				if (CutName(n, ei.Expansion))
				{
					return;
				}
			}

			if (CutName(n, FileTablePaths.SaveGameFolder))
			{
				return;
			}

			if (CutName(n, FileTablePaths.SimPEDataFolder))
			{
				return;
			}

			if (CutName(n, FileTablePaths.SimPEFolder))
			{
				return;
			}

			if (CutName(n, FileTablePaths.SimPEPluginFolder))
			{
				return;
			}

			//if (Helper.IsAbsolutePath(name)) name = Helper.CompareableFileName(Helper.ToLongPathName(name));
			path = name;
		}

		public FileTableItemType Type
		{
			get; set;
		}

		/// <summary>
		/// Check this to determine if this item should be used in the FileTable
		/// </summary>
		public bool Use => IsAvail && !Ignore && IsUseable;

		public bool IsRecursive
		{
			get; set;
		}

		public bool IsFile
		{
			get; set;
		}

		public bool IsUseable => EpVersion == -1 || EpVersion == PathProvider.Global.GameVersion;

		public int EpVersion
		{
			get; set;
		}

		public bool IsAvail
		{
			get
			{
				if (!IsUseable)
				{
					return false;
				}

				return Exists;
			}
		}

		public bool Exists
		{
			get
			{
				if (IsFile)
				{
					return System.IO.File.Exists(Name);
				}
				else
				{
					return System.IO.Directory.Exists(Name);
				}
			}
		}

		public string Name
		{
			get
			{
				string r = GetRoot(Type);

				if (r == null)
				{
					return path;
				}

				string p = path.Trim();
				if (p.StartsWith(Helper.PATH_SEP))
				{
					p = path.Substring(1);
				}

				string ret = System.IO.Path.Combine(r, p);

				if (IsFile)
				{
					if (ret.EndsWith(Helper.PATH_SEP))
					{
						ret = ret.Substring(0, ret.Length - 1);
					}
				}

				return ret;
			}
			set => SetName(value);
		}

		public string RelativePath
		{
			get
			{
				if (IsFile)
				{
					if (path.EndsWith(Helper.PATH_SEP))
					{
						path = path.Substring(0, path.Length - 1);
					}
				}

				return path;
			}
		}

		public string[] GetFiles()
		{
			string[] files;

			if (!IsUseable || !IsAvail)
			{
				files = new string[0];
			}
			else if (IsFile)
			{
				files = new string[1];
				files[0] = Name;
			}
			else
			{
				string n = Name;
				if (System.IO.Directory.Exists(n))
				{
					files = System.IO.Directory.GetFiles(n, "*.package");
				}
				else
				{
					files = new string[0];
				}
			}
			return files;
		}

		public override string ToString()
		{
			string n = "";
			if (IsFile)
			{
				n += "File: ";
			}
			else if (IsRecursive)
			{
				n += "RecursiveFolder: ";
			}
			else
			{
				n += "Folder: ";
			}

			if (!IsUseable)
			{
				n = "(Unused) " + n;
			}
			else if (!IsAvail)
			{
				n = "(Missing) " + n;
			}

			if (!Helper.WindowsRegistry.UseExpansions2 && Type.ToString() == "Extra")
			{
				n += "{Store}" + path;
			}
			else
			{
				n += "{" + Type.ToString() + "}" + path;
			}

			if (EpVersion != -1)
			{
				n += " (Only when GameVersion=" + EpVersion.ToString() + ")";
			}

			return n;
		}
	}
}
