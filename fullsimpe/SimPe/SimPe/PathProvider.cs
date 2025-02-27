using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimPe
{
	public enum Expansions : uint
	{
		None = 0x0,
		BaseGame = 0x1, //0
		University = 0x2, //1
		Nightlife = 0x4, //2

		// Non-SP XMas stuff
		Business = 0x8, //3
		FamilyFun = 0x10, //4
		Glamour = 0x20, //5
		Pets = 0x40, //6

		// Non-SP Happy Holidays
		Seasons = 0x80, //7
		Celebrations = 0x100, //8
		Fashion = 0x200, //9
		Voyage = 0x400, //10
		Teen = 0x800, //11
		Extra = 0x1000, //12 -- This should be Store
		FreeTime = 0x2000, //13
		Kitchens = 0x4000, //14
		IKEA = 0x8000, //15
		Apartments = 0x00010000, //16 --Flags2--
		Mansions = 0x00020000, //17
		XP18 = 0x00040000, //18
		XP19 = 0x00080000, //19
		Store = 0x00100000, //20 -- May need to comment this one out again

		// Store =             0x08000000,//27 -- Store is actually 31 but that is taken
		IslandStories = 0x10000000, //28 -- SimPe stolen: beware!!
		PetStories = 0x20000000, //29 -- SimPe stolen: beware!!
		LifeStories = 0x40000000, //30 -- SimPe stolen: beware!!
		Custom = 0x80000000, //31
	}

	public class PathProvider : IEnumerable<string>
	{
		internal const int GROUP_COUNT = 32;
		static ExpansionItem nil = new ExpansionItem(null);
		public static ExpansionItem Nil => nil;

		XmlRegistry reg;
		XmlRegistryKey xrk;
		List<ExpansionItem> exps;
		List<string> paths;
		public List<ExpansionItem> Expansions => exps;

		Dictionary<Expansions, ExpansionItem> map;
		int spver,
			epver,
			stver;
		ExpansionItem latest;
		List<string> censorfiles;
		Expansions lastknown;
		Dictionary<long, Ambertation.CaseInvariantArrayList> savgamemap;

		long avlgrp;

		public static string ExpansionFile // CJH
		{
			get
			{
				string name = Helper.DataFolder.ExpansionsXREG;
				if (System.IO.File.Exists(name))
					return Helper.DataFolder.ExpansionsXREG;
				else if (Helper.ECCorNewSEfound)
					return System.IO.Path.Combine(
						Helper.SimPeDataPath,
						"expansions2.xreg"
					);
				else
					return System.IO.Path.Combine(
						Helper.SimPeDataPath,
						"expansions.xreg"
					);
				// else return System.IO.Path.Combine(Helper.SimPeDataPath, "expansions.xreg");
			}
		}

		static PathProvider glb;
		public static PathProvider Global
		{
			get
			{
				if (glb == null)
					glb = new PathProvider();
				return glb;
			}
		}

		private PathProvider()
		{
			reg = new XmlRegistry(ExpansionFile, ExpansionFile, true);
			xrk = reg.CurrentUser.CreateSubKey("Expansions");
			exps = new List<ExpansionItem>();
			map = new Dictionary<Expansions, ExpansionItem>();
			savgamemap = new Dictionary<long, Ambertation.CaseInvariantArrayList>();
			censorfiles = new List<string>();
			avlgrp = 0;

			Load();
		}

		void Load()
		{
			censorfiles.Add(
				System.IO.Path.Combine(
					SimSavegameFolder,
					@"Downloads\quaxi_nl_censor_v1.package"
				)
			);
			censorfiles.Add(
				System.IO.Path.Combine(
					SimSavegameFolder,
					@"Downloads\quaxi_nl_censor.package"
				)
			);
			string[] names = xrk.GetSubKeyNames();
			int ver = -1;
			avlgrp = 0;
			System.Diagnostics.Debug.WriteLine("\r\n----\r\nExpansionItems");
			foreach (string name in names)
			{
				ExpansionItem i = new ExpansionItem(xrk.OpenSubKey(name, false));
				exps.Add(i);
				map[i.Expansion] = i;
				if (i.Flag.Class == ExpansionItem.Classes.Story)
					continue;
				if (i.CensorFile != "")
				{
					string fl = System.IO.Path.Combine(
						SimSavegameFolder,
						@"Downloads\" + i.CensorFileName
					);
					if (!censorfiles.Contains(fl))
						censorfiles.Add(fl);
					fl = System.IO.Path.Combine(
						SimSavegameFolder,
						@"Config\" + i.CensorFileName
					);
					if (!censorfiles.Contains(fl))
						censorfiles.Add(fl);
				}
				if (i.Version > ver)
				{
					ver = i.Version;
					lastknown = i.Expansion;
				}
				avlgrp = avlgrp | (uint)i.Group;
			}
			System.Diagnostics.Debug.WriteLine("----\r\n");

			spver = GetMaxVersion(ExpansionItem.Classes.StuffPack);
			epver = GetMaxVersion(ExpansionItem.Classes.ExpansionPack);
			stver = GetMaxVersion(ExpansionItem.Classes.Story);
			latest = this.GetLatestExpansion();

			exps.Sort();

			CreateSaveGameMap();

			paths = new List<string>();
			foreach (ExpansionItem ei in exps)
				if (ei.Exists)
					if (System.IO.Directory.Exists(ei.InstallFolder))
						paths.Add(ei.InstallFolder);
		}

		private void CreateSaveGameMap()
		{
			foreach (ExpansionItem ei in exps)
			{
				foreach (long grp in ei.Groups)
				{
					Ambertation.CaseInvariantArrayList list;
					if (savgamemap.ContainsKey(grp))
						list = savgamemap[grp];
					else
					{
						list = new Ambertation.CaseInvariantArrayList();
						savgamemap[grp] = list;
					}

					ei.AddSaveGamePaths(list);
				}
			}
		}

		protected int GetMaxVersion(ExpansionItem.Classes sp)
		{
			int ret = 0;
			foreach (ExpansionItem i in exps)
			{
				if (i.Exists || i.InstallFolder != "")
				{
					if (sp == i.Flag.Class && i.Flag.FullObjectsPackage)
					{
						if (i.Version > ret)
							ret = i.Version;
					}
				}
			}

			return ret;
		}

		public Expansions LastKnown => lastknown;

		public int GameVersion // if Ts2 not installed will return a Story Version if installed
		{
			get
			{
				if (
					!GetExpansion(SimPe.Expansions.BaseGame).Exists
					&& epver == 0
					&& spver == 0
					&& stver > 0
				)
					return stver;
				return Math.Max(epver, spver);
			}
		}

		public int EPInstalled => epver;

		public int SPInstalled => spver;

		public int STInstalled => stver;

		/// <summary>
		/// Name of the Sims Application
		/// </summary>
		public string SimsApplication
		{
			get
			{
				if (Latest.Version != Latest.PreferedRuntimeVersion)
				{
					ExpansionItem ei = GetHighestAvailableExpansion(
						Latest.PreferedRuntimeVersion,
						Latest.Version
					);
					return ei.ApplicationPath;
				}
				return Latest.ApplicationPath;
			}
		}

		public string InGameLang
		{
			get
			{
				Microsoft.Win32.RegistryKey tk;
				if (Latest.Version == 19 || Latest.Version == 18)
					tk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
						"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\Sims2EP9.exe",
						false
					);
				else
					tk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
						"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\"
							+ Latest.ExeName,
						false
					);
				if (tk == null)
					return "English";
				object gr = tk.GetValue("Game Registry", "");
				Microsoft.Win32.RegistryKey rk =
					Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
						(string)gr + "\\1.0",
						false
					);
				if (rk != null)
				{
					object o = rk.GetValue("Language");
					if (o == null)
						return "Invalid Language Id";
					return SimPe.Data.MetaData.GetLanguageName(
						Convert.ToInt16(o.ToString())
					);
				}
				else
					return "Invalid Language Id";
			}
		}

		public void SetDefaultPaths()
		{
			foreach (ExpansionItem i in exps)
			{
				i.InstallFolder = i.RealInstallFolder;
			}
			SimSavegameFolder = RealSavegamePath;
		}

		/// <summary>
		/// Returns the object describing the highest Expansion available on the System
		/// </summary>
		public ExpansionItem Latest => latest;

		protected ExpansionItem GetLatestExpansion()
		{
			return GetExpansion(GameVersion);
		}

		/// <summary>
		/// Returns the object describing the Expansion associated with that Version, or Nil
		/// </summary>
		/// <param name="version"></param>
		/// <returns>null will be returned, if the passed Expansion is not yet defined. If it is just not installed on
		/// the users Nil, a valid object will be returned, but the <see cref="ExoansionItem.Exists"/> property
		/// returns false.</returns>
		public ExpansionItem GetExpansion(int version)
		{
			Expansions exp = (Expansions)Math.Pow(2, version);
			return GetExpansion(exp);
		}

		/// <summary>
		/// Returns the object describing the highest Expansion in the interval [minver, maxver[
		/// </summary>
		/// <param name="minver"></param>
		/// <param name="maxver"></param>
		/// <returns>null will be returned, if the passed Expansion is not yet defined. If it is just not installed on
		/// the users Nil, a valid object will be returned, but the <see cref="ExoansionItem.Exists"/> property
		/// returns false.</returns>
		/// by including t.InstallFolder it will also find user manually configured EPs
		public ExpansionItem GetHighestAvailableExpansion(int minver, int maxver)
		{
			ExpansionItem exp = null;
			ExpansionItem t = null;
			int v = minver;
			maxver++;
			while (v < maxver)
			{
				t = GetExpansion(v++);
				if (t != null)
					if (t.Exists || t.InstallFolder != "")
						exp = t;
			}
			return exp;
		}

		/// <summary>
		/// Returns the object describing the Lowest Expansion in the interval [minver, maxver[
		/// </summary>
		public ExpansionItem GetLowestAvailableExpansion(int minver, int maxver)
		{
			ExpansionItem exp = null;
			ExpansionItem t = null;
			int v = maxver;
			minver--;
			while (v > minver)
			{
				t = GetExpansion(v--);
				if (t != null)
					if (t.Exists || t.InstallFolder != "")
						exp = t;
			}
			return exp;
		}

		/// <summary>
		/// Returns the object describing the passed Expansion, or Nil if it is not known
		/// </summary>
		/// <param name="exp"></param>
		/// <returns>Nil will be returned, if the passed Expansion is not yet defined. If it is just not installed on
		/// the users System, a valid object will be returned, but the <see cref="ExoansionItem.Exists"/> property
		/// returns false.</returns>
		public ExpansionItem GetExpansion(Expansions exp)
		{
			if (!map.ContainsKey(exp))
				return Nil;
			return map[exp];
		}

		public ExpansionItem this[Expansions ep]
		{
			get
			{
				return GetExpansion(ep);
			}
		}

		public ExpansionItem this[int ver]
		{
			get
			{
				return GetExpansion(ver);
			}
		}

		/// <summary>
		/// Bit-wise OR of the groups (from expansions.xreg) of all known games
		/// </summary>
		public long AvailableGroups => avlgrp;

		/// <summary>
		/// The group (from expansions.xreg) for the current GameVersion
		/// </summary>
		public int CurrentGroup => GetExpansion(GameVersion).Group;

		#region Censor Patch
		/// <summary>
		/// Returns true if the Game will start in Debug Mode
		/// </summary>
		internal bool BlurNudity
		{
			get
			{
				if (PathProvider.Global.EPInstalled < 18)
				{
					if (latest.CensorFile == "")
						return BlurNudityPreEP2;
					else
						return BlurNudityPostEP2;
				}
				else
					return true;
			}
			set
			{
				if (PathProvider.Global.EPInstalled < 18)
				{
					if (latest.CensorFile == "")
					{
						BlurNudityPostEP2 = false;
						BlurNudityPreEP2 = value;
					}
					else
					{
						BlurNudityPostEP2 = value;
					}
				}
				else
				{
					BlurNudityPostEP2 = true;
					BlurNudityPreEP2 = true;
				}
			}
		}

		protected bool BlurNudityPostEP2
		{
			get
			{
				return GetBlurNudity();
			}
			set
			{
				SetBlurNudity(value, latest.CensorFile, false);
			}
		}

		internal void BlurNudityUpdate()
		{
			if (EPInstalled >= 3 && !GetBlurNudity())
			{
				SetBlurNudity(true, latest.CensorFile, true);
				SetBlurNudity(false, latest.CensorFile, true);
			}
		}

		bool GetBlurNudity()
		{
			foreach (string fl in censorfiles)
				if (System.IO.File.Exists(fl))
					return false;

			return true;
		}

		void SetBlurNudity(bool value, string resname, bool silent)
		{
			if (PathProvider.Global.EPInstalled > 17)
				silent = true;
			if (!value)
			{
				string fl = latest.CensorFile;
				string f2 = latest.SensorFile;
				string folder = System.IO.Path.GetDirectoryName(fl);

				if (System.IO.File.Exists(fl) || System.IO.File.Exists(f2))
					return;

				if (!silent)
					if (
						System.Windows.Forms.MessageBox.Show(
							SimPe
								.Localization.GetString("Censor_Install_Warn")
								.Replace("{filename}", fl),
							SimPe.Localization.GetString("Warning"),
							System.Windows.Forms.MessageBoxButtons.YesNo
						) == System.Windows.Forms.DialogResult.No
					)
						return;

				try
				{
					if (!System.IO.Directory.Exists(folder))
						System.IO.Directory.CreateDirectory(folder);

					string[] names = typeof(Helper).Assembly.GetManifestResourceNames();
					System.IO.Stream s = null;
					foreach (string name in names)
					{
						if (
							name.Trim()
								.ToLower()
								.EndsWith(latest.CensorFileName.Trim().ToLower())
						)
							s = typeof(Helper).Assembly.GetManifestResourceStream(name);
					}

					System.IO.BinaryReader br = new BinaryReader(s);
					try
					{
						FileStream fs = System.IO.File.Create(fl);
						System.IO.BinaryWriter bw = new BinaryWriter(fs);
						try
						{
							bw.Write(br.ReadBytes((int)br.BaseStream.Length));
						}
						finally
						{
							bw.Close();
							bw = null;
							fs.Close();
							fs.Dispose();
							fs = null;
						}
					}
					finally
					{
						br.Close();
					}
				}
				catch (Exception ex)
				{
					Helper.ExceptionMessage(ex);
				}
			}
			else
			{
				foreach (string fl in censorfiles)
					if (System.IO.File.Exists(fl))
					{
						try
						{
							if (!silent)
								if (
									System.Windows.Forms.MessageBox.Show(
										SimPe
											.Localization.GetString(
												"Censor_UnInstall_Warn"
											)
											.Replace("{filename}", fl),
										SimPe.Localization.GetString("Warning"),
										System.Windows.Forms.MessageBoxButtons.YesNo
									) == System.Windows.Forms.DialogResult.No
								)
									return;
							System.IO.File.Delete(fl);
						}
						catch (Exception ex)
						{
							Helper.ExceptionMessage(ex);
						}
					}
			}
		}

		protected bool BlurNudityPreEP2
		{
			get
			{
				if (!System.IO.File.Exists(StartupCheatFile))
					return true;

				try
				{
					System.IO.TextReader fs = System.IO.File.OpenText(StartupCheatFile);
					string cont = fs.ReadToEnd();
					fs.Close();
					fs.Dispose();
					fs = null;
					string[] lines = cont.Split("\n".ToCharArray());

					foreach (string line in lines)
					{
						string pline = line.ToLower().Trim();
						while (pline.IndexOf("  ") != -1)
							pline = pline.Replace("  ", " ");
						string[] tokens = pline.Split(" ".ToCharArray());

						if (tokens.Length == 3)
						{
							if (
								(tokens[0] == "intprop")
								&& (tokens[1] == "censorgridsize")
							)
								return (Convert.ToInt32(tokens[2]) != 0);
						}
					}
				}
				catch (Exception) { }

				return true;
			}
			set
			{
				if (
					!System.IO.Directory.Exists(
						System.IO.Path.GetDirectoryName(StartupCheatFile)
					)
				)
					return;

				try
				{
					string newcont = "";
					bool found = false;
					if (System.IO.File.Exists(StartupCheatFile))
					{
						System.IO.TextReader fs = System.IO.File.OpenText(
							StartupCheatFile
						);
						string cont = fs.ReadToEnd();
						fs.Close();
						fs.Dispose();
						fs = null;

						string[] lines = cont.Split("\n".ToCharArray());

						foreach (string line in lines)
						{
							string pline = line.ToLower().Trim();
							while (pline.IndexOf("  ") != -1)
								pline = pline.Replace("  ", " ");
							string[] tokens = pline.Split(" ".ToCharArray());

							if (tokens.Length == 3)
							{
								if (
									(tokens[0] == "intprop")
									&& (tokens[1] == "censorgridsize")
								)
								{
									if (!found)
									{
										if (!value)
										{
											newcont += "intprop censorgridsize 0";
											newcont += Helper.lbr;
										}
										found = true;
									}
									continue;
								}
							}
							newcont += line.Trim();
							newcont += Helper.lbr;
						}

						System.IO.File.Delete(StartupCheatFile);
					}

					if (!found)
					{
						if (!value)
						{
							newcont += "intprop censorgridsize 0";
							newcont += Helper.lbr;
						}
					}

					System.IO.TextWriter fw = System.IO.File.CreateText(
						StartupCheatFile
					);
					fw.Write(newcont.Trim());
					fw.Close();
					fw.Dispose();
					fw = null;
				}
				catch (Exception) { }
			}
		}
		#endregion

		#region Paths
		/*public IList<string> GetSaveGamePathForGroup()
		{
			return GetSaveGamePathForGroup(AvailableGroups);
		}*/

		public IList<string> GetSaveGamePathForGroup(long grp)
		{
			List<string> list = new List<string>();

			foreach (long g in savgamemap.Keys)
			{
				if ((g & grp) == 0)
					continue;
				Ambertation.CaseInvariantArrayList ps = savgamemap[g];
				if (ps == null)
					continue;
				foreach (string s in ps)
					if (!list.Contains(Helper.CompareableFileName(s)))
						list.Add(Helper.CompareableFileName(s));
			}

			return list.AsReadOnly();
		}

		/*public ExpansionItem.NeighborhoodPaths GetNeighborhoodsForGroup()
		{
			return GetNeighborhoodsForGroup(AvailableGroups);
		}*/

		public ExpansionItem.NeighborhoodPaths GetNeighborhoodsForGroup(long grp)
		{
			ExpansionItem.NeighborhoodPaths hoods =
				new ExpansionItem.NeighborhoodPaths();
			if ((GetExpansion(SimPe.Expansions.BaseGame).Group & grp) != 0)
			{
				ExpansionItem.NeighborhoodPath def = new ExpansionItem.NeighborhoodPath(
					"",
					NeighborhoodFolder,
					this[SimPe.Expansions.BaseGame],
					true
				);
				hoods.Add(def);
			}
			foreach (ExpansionItem ei in Expansions)
			{
				if ((ei.Group & grp) == 0)
					continue;
				ei.AddNeighborhoodPaths(hoods);
			}

			return hoods;
		}

		public long SaveGamePathProvidedByGroup(string path)
		{
			path = Helper.CompareableFileName(path);
			foreach (long grp in savgamemap.Keys)
			{
				Ambertation.CaseInvariantArrayList ps = savgamemap[grp];
				foreach (string s in ps)
					if (path.StartsWith(Helper.CompareableFileName(s)))
						return grp;
			}

			return 0;
		}

		public static string RealSavegamePath
		{
			get
			{
				try
				{
					string path;
					if (Helper.WindowsRegistry.LoadOnlySimsStory == 0)
						path = System.IO.Path.Combine(PersonalFolder, "EA Games");
					else
						path = System.IO.Path.Combine(
							PersonalFolder,
							"Electronic Arts"
						); // For Sim Stories
					path = System.IO.Path.Combine(path, DisplayedName);
					return Helper.ToLongPathName(path);
				}
				catch (Exception)
				{
					return "";
				}
			}
		}

		/// <summary>
		/// This Folder contains al Sims User Data
		/// </summary>
		public static string SimSavegameFolder
		{
			get
			{
				try
				{
					XmlRegistryKey rkf =
						Helper.WindowsRegistry.RegistryKey.CreateSubKey("Settings");
					object o = rkf.GetValue("SavegamePath");
					if (o == null)
					{
						return RealSavegamePath;
					}
					else
					{
						string fl = o.ToString();
						if (!System.IO.Directory.Exists(fl))
							return RealSavegamePath;
						return fl;
					}
				}
				catch (Exception)
				{
					return RealSavegamePath;
				}
			}
			set
			{
				XmlRegistryKey rkf = Helper.WindowsRegistry.RegistryKey.CreateSubKey(
					"Settings"
				);
				if (value == "")
					rkf.DeleteSubKey("SavegamePath", false);
				else
					rkf.SetValue("SavegamePath", value);
			}
		}

		/// <summary>
		/// Returns the DisplayName for a given Expansion
		/// </summary>
		/// <param name="ei">Expansion you are looking for</param>
		/// <returns>DisplayName of the Expoansion</returns>
		internal static string GetDisplayedNameForExpansion(ExpansionItem ei)
		{
			try
			{
				Microsoft.Win32.RegistryKey rk = ei.Registry;
				return GetDisplayedNameForExpansion(rk);
			}
			catch (Exception)
			{
				return "The Sims 2";
			}
		}

		/// <summary>
		/// Returns the Display name stored in a RegistryKey.
		/// </summary>
		/// <param name="registryKey">RegistryKey to look in</param>
		/// <returns>DisplayName found in that Key</returns>
		protected static string GetDisplayedNameForExpansion(
			Microsoft.Win32.RegistryKey registryKey
		)
		{
			if (registryKey != null)
			{
				var obj = registryKey.GetValue("DisplayName");
				if (obj != null)
				{
					return obj.ToString();
				}
			}

			return "The Sims 2";
		}

		/// <summary>
		/// Returns the Displayed BaseGame name, no good for sim stories
		/// </summary>
		protected static string DisplayedName
		{
			get
			{
				try
				{
					Microsoft.Win32.RegistryKey tk;
					if (Helper.WindowsRegistry.LoadOnlySimsStory == 28) // Castaway Stories
						tk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
							"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe",
							false
						);
					else if (Helper.WindowsRegistry.LoadOnlySimsStory == 29) // Pet Stories
						tk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
							"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsPS.exe",
							false
						);
					else if (Helper.WindowsRegistry.LoadOnlySimsStory == 30) // Life Stories
						tk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
							"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsLS.exe",
							false
						);
					else
						tk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
							"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\Sims2.exe",
							false
						);
					if (tk != null)
					{
						object o = tk.GetValue("Game Registry", false);
						Microsoft.Win32.RegistryKey rk =
							Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
								(string)o,
								false
							);
						return GetDisplayedNameForExpansion(rk);
					}
					else
						return "The Sims 2";
				}
				catch (Exception)
				{
					return "The Sims 2";
				}
			}
		}

		/// <summary>
		/// Returns the Location of the Personal Folder
		/// </summary>
		internal static string PersonalFolder => Environment.GetFolderPath(Environment.SpecialFolder.Personal);

		/// <summary>
		/// Name of the Nvidia DDS Path
		/// </summary>
		public string NvidiaDDSPath
		{
			get
			{
				try
				{
					XmlRegistryKey rkf =
						Helper.WindowsRegistry.RegistryKey.CreateSubKey("Settings");
					object o = rkf.GetValue("NvidiaDDS");
					if (o == null)
						return "";
					return o.ToString();
				}
				catch (Exception)
				{
					return "";
				}
			}
			set
			{
				XmlRegistryKey rkf = Helper.WindowsRegistry.RegistryKey.CreateSubKey(
					"Settings"
				);
				rkf.SetValue("NvidiaDDS", value);
			}
		}

		/// <summary>
		/// The location of theNvidia Tool
		/// </summary>
		public string NvidiaDDSTool => System.IO.Path.Combine(NvidiaDDSPath, "nvdxt.exe");

		/// <summary>
		/// Returns the Name of the Startup Cheat File
		/// </summary>
		public string StartupCheatFile => System.IO.Path.Combine(
					SimSavegameFolder,
					"Config\\userStartup.cheat"
				);

		/// <summary>
		/// Looks for the Neighborhoods subfolder in the specified path
		/// </summary>
		/// <param name="path">Base Path</param>
		/// <returns>the suggested neighborhood folder</returns>
		protected static string BuildNeighborhoodFolder(string path)
		{
			return System.IO.Path.Combine(path, "Neighborhoods");
		}

		/// <summary>
		/// returns the Fldeer where the users default Neighborhood is stored
		/// </summary>
		public string NeighborhoodFolder
		{
			get
			{
				try
				{
					return BuildNeighborhoodFolder(SimSavegameFolder);
				}
				catch (Exception)
				{
					return "";
				}
			}
		}

		/// <summary>
		/// returns the Fodler where the Backups are stored
		/// </summary>
		public string BackupFolder
		{
			get
			{
				try
				{
					return System.IO.Path.Combine(
						System.IO.Path.Combine(PersonalFolder, "EA Games"),
						"SimPE Backup"
					);
				}
				catch (Exception)
				{
					return "";
				}
			}
		}
		#endregion

		/// <summary>
		/// Write Changes
		/// </summary>
		internal void Flush()
		{
			reg.Flush();
		}

		#region IEnumerator<string> Member

		public string Current => throw new Exception("The method or operation is not implemented.");

		#endregion

		#region IDisposable Member

		public void Dispose()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion



		#region IEnumerable<string> Member

		public IEnumerator<string> GetEnumerator()
		{
			return paths.GetEnumerator();
		}

		#endregion

		#region IEnumerable Member

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return paths.GetEnumerator();
		}

		#endregion
	}
}
