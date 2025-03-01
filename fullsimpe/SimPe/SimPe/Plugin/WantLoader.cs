// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

using SimPe.Cache;

namespace SimPe.Plugin
{
	/// <summary>
	/// This basically is a Class describing the Wants (loaded from the Cache)
	/// </summary>
	public class WantCacheInformation : WantInformation
	{
		/// <summary>
		/// Use WantInformation::LoadWant() to create a new Instance
		/// </summary>
		/// <param name="guid">The guid of the Want</param>
		WantCacheInformation(uint guid)
			: base(guid)
		{
			name = "";
		}

		/// <summary>
		/// Use WantInformation::LoadWant() to create a new Instance
		/// </summary>
		WantCacheInformation()
			: base()
		{
			name = "";
		}

		/// <summary>
		/// Load Informations about a specific Want
		/// </summary>
		/// <param name="guid">The GUID of the want</param>
		/// <returns>A Want Information Structure</returns>
		public static WantCacheInformation LoadWant(WantCacheItem wci)
		{
			WantCacheInformation ret = new WantCacheInformation
			{
				icon = wci.Icon,
				name = wci.Name,
				guid = wci.Guid
			};

			XWant w = new XWant();
			PackedFiles.Wrapper.CpfItem i =
				new PackedFiles.Wrapper.CpfItem
				{
					Name = "id",
					UIntegerValue = wci.Guid
				};
			w.AddItem(i, true);
			i = new PackedFiles.Wrapper.CpfItem
			{
				Name = "folder",
				StringValue = wci.Folder
			};
			w.AddItem(i, true);
			i = new PackedFiles.Wrapper.CpfItem
			{
				Name = "score",
				IntegerValue = wci.Score
			};
			w.AddItem(i, true);
			i = new PackedFiles.Wrapper.CpfItem
			{
				Name = "influence",
				IntegerValue = wci.Influence
			};
			w.AddItem(i, true);
			i = new PackedFiles.Wrapper.CpfItem
			{
				Name = "objectType",
				StringValue = wci.ObjectType
			};
			w.AddItem(i, true);

			ret.wnt = w;

			return ret;
		}

		System.Drawing.Image icon;
		public override System.Drawing.Image Icon => icon;

		string name;
		public override string Name => name;
	}

	/// <summary>
	/// This basically is a Class describing the Wants
	/// </summary>
	public class WantInformation
	{
		protected XWant wnt;
		PackedFiles.Wrapper.Str str;
		PackedFiles.Wrapper.Picture primicon;
		protected uint guid;
		internal string prefix = "";

		static Hashtable wantcache;

		/// <summary>
		/// Use WantInformation::LoadWant() to create a new Instance
		/// </summary>
		protected WantInformation()
		{
		}

		/// <summary>
		/// Use WantInformation::LoadWant() to create a new Instance
		/// </summary>
		/// <param name="guid">The guid of the Want</param>
		protected WantInformation(uint guid)
		{
			this.guid = guid;

			wnt = WantLoader.GetWant(guid);
			str = WantLoader.LoadText(wnt);
			primicon = WantLoader.LoadIcon(wnt);
		}

		#region Cache
		static WantCacheFile cachefile;

		static void LoadCache()
		{
			if (cachefile != null)
			{
				return;
			}

			cachefile = new WantCacheFile();
			if (!Helper.WindowsRegistry.UseCache)
			{
				return;
			}

			Wait.SubStart();
			Wait.Message = "Loading Cache";
			try
			{
				cachefile.Load(Helper.SimPeLanguageCache, true);
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			Wait.SubStop();
		}

		/// <summary>
		/// Save the Cache to the FileSystem
		/// </summary>
		public static void SaveCache()
		{
			if (!Helper.WindowsRegistry.UseCache)
			{
				return;
			}

			if (cachefile == null)
			{
				return;
			}

			Wait.SubStart();
			Wait.Message = "Saveing Cache";
			cachefile.Save(Helper.SimPeLanguageCache);
			Wait.SubStop();
		}
		#endregion

		/// <summary>
		/// Load Informations about a specific Want
		/// </summary>
		/// <param name="guid">The GUID of the want</param>
		/// <returns>A Want Information Structure</returns>
		public static WantInformation LoadWant(uint guid)
		{
			LoadCache();
			if (wantcache == null)
			{
				wantcache = cachefile.Map;
			}

			if (wantcache.ContainsKey(guid))
			{
				object o = wantcache[guid];
				WantInformation wf = o.GetType() == typeof(WantInformation) ? (WantInformation)o : WantCacheInformation.LoadWant((WantCacheItem)o);

				return wf;
			}
			else
			{
				WantInformation wf = new WantInformation(guid);
				wantcache[guid] = wf;
				cachefile.AddItem(wf);
				return wf;
			}
		}

		/// <summary>
		/// Returns the XWant File
		/// </summary>
		public XWant XWant => wnt;

		/// <summary>
		/// Returns the Name of this Want
		/// </summary>
		public virtual string Name => str == null
					? "0x" + Helper.HexString(guid)
					: str.FallbackedLanguageItem(
					Helper.WindowsRegistry.LanguageCode,
					0
				).Title;

		/// <summary>
		/// Returns Icon for this want or null
		/// </summary>
		public virtual System.Drawing.Image Icon => primicon?.Image;

		/// <summary>
		/// The guid of the current Want
		/// </summary>
		public uint Guid => guid;

		public override string ToString()
		{
			return prefix + Name;
		}
	}

	/// <summary>
	/// This class is used to fill the UI for this FileType with Data
	/// </summary>
	public class WantLoader
	{
		static Hashtable wants = null;
		static Packages.File txtpkg = null;
		static WantNameLoader wnl;

		// static SimPe.Packages.File imgpkg = null; // Never used ??

		/// <summary>
		/// Returns a Hashtable of all available Wants
		/// </summary>
		/// <remarks>key is the want GUID, value is a XWant object</remarks>
		public static Hashtable Wants
		{
			get
			{
				if (wants == null)
				{
					LoadWants();
				}

				return wants;
			}
		}

		/// <summary>
		/// Returns a WantNameLoader you can use to determine Names
		/// </summary>
		public static WantNameLoader WantNameLoader
		{
			get
			{
				if (wnl == null)
				{
					wnl = new WantNameLoader();
				}

				return wnl;
			}
		}

		/// <summary>
		/// Loads the Text Package File
		/// </summary>
		static void LoadTextPackage()
		{
			Wait.SubStart();
			txtpkg = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.Latest.InstallFolder,
					"TSData\\Res\\Text\\Wants.package"
				)
			);

			string img =
				System.IO.Path.Combine(
					PathProvider.Global[Expansions.BaseGame].InstallFolder,
					"TSData\\Res\\UI\\ui.package"
				)
			;
			FileTableBase.FileIndex.AddIndexFromPackage(img);
			foreach (ExpansionItem ei in PathProvider.Global.Expansions)
			{
				if (ei.Exists)
				{
					img =
						System.IO.Path.Combine(
							ei.InstallFolder,
							"TSData\\Res\\UI\\ui.package"
						)
					;
					FileTableBase.FileIndex.AddIndexFromPackage(img);
				}
			}

			Wait.SubStop();
		}

		/// <summary>
		/// Load the available Wants
		/// </summary>
		static void LoadWants()
		{
			Wait.SubStart();
			wants = new Hashtable();

			FileTableBase.FileIndex.Load();
			Interfaces.Scenegraph.IScenegraphFileIndexItem[] wtss =
				FileTableBase.FileIndex.FindFile(Data.MetaData.XWNT, true);

			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem wts in wtss)
			{
				wants[wts.FileDescriptor.Instance] = wts;
			}

			Wait.SubStop();
		}

		/// <summary>
		/// Returns a XWAnt File for this Item or null
		/// </summary>
		/// <param name="guid">The GUID of the Want</param>
		/// <returns>The Xant Object representing That want (or null if not found)</returns>
		public static XWant GetWant(uint guid)
		{
			if (wants == null)
			{
				LoadWants();
			}

			Interfaces.Scenegraph.IScenegraphFileIndexItem wts =
				(Interfaces.Scenegraph.IScenegraphFileIndexItem)wants[guid];
			if (wts != null)
			{
				XWant xwnt = new XWant();
				wts.FileDescriptor.UserData = wts
					.Package.Read(wts.FileDescriptor)
					.UncompressedData;
				xwnt.ProcessData(wts);

				return xwnt;
			}

			return null;
		}

		/// <summary>
		/// Returns the String File describing that want
		/// </summary>
		/// <param name="wnt">The Want File</param>
		/// <returns>The Str File or null if none was found</returns>
		public static PackedFiles.Wrapper.Str LoadText(XWant wnt)
		{
			if (wnt == null)
			{
				return null;
			}

			if (txtpkg == null)
			{
				LoadTextPackage();
			}

			Interfaces.Files.IPackedFileDescriptor[] pfds = txtpkg.FindFile(
				Data.MetaData.STRING_FILE,
				0,
				wnt.StringInstance
			);
			if (pfds.Length > 0)
			{
				PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();
				pfds[0].UserData = txtpkg.Read(pfds[0]).UncompressedData;
				str.ProcessData(pfds[0], txtpkg);

				return str;
			}

			return null;
		}

		/// <summary>
		/// Returns the Icon File for the passed Want
		/// </summary>
		/// <param name="wnt">The Want File</param>
		/// <returns>The Picture File or null if none was found</returns>
		public static PackedFiles.Wrapper.Picture LoadIcon(XWant wnt)
		{
			if (wnt == null)
			{
				return null;
			}

			if (txtpkg == null)
			{
				LoadTextPackage();
			}

			Interfaces.Scenegraph.IScenegraphFileIndexItem[] items =
				FileTableBase.FileIndex.FindFile(wnt.IconFileDescriptor, null);
			if (items.Length > 0)
			{
				PackedFiles.Wrapper.Picture pic =
					new PackedFiles.Wrapper.Picture();
				items[0].FileDescriptor.UserData = items[0]
					.Package.Read(items[0].FileDescriptor)
					.UncompressedData;
				pic.ProcessData(items[0]);

				return pic;
			}
			return null;
		}
	}
}
