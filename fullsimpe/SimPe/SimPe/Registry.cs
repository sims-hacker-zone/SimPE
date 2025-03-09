// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

using SimPe.Forms.MainUI;

using Microsoft.Win32;

namespace SimPe
{
	/// <summary>
	/// Handles Application Settings stored in the Registry
	/// </summary>
	/// <remarks>You cannot create instance of this class, use the
	/// <see cref="Helper.WindowsRegistry"/> Field to acces the Registry</remarks>
	public class Registry
	{
		public class LayoutConfiguration
		{
			/// <summary>
			/// returns a list of Strings that hold the names of all available ToolbarButtons
			/// </summary>
			public List<string> VisibleToolbarButtons
			{
				get; set;
			} = new List<string>()
			{
				"action.SimPe.Actions.Default.AddAction",
				"action.SimPe.Actions.Default.ExportAction",
				"action.SimPe.Actions.Default.ReplaceAction",
				"action.SimPe.Actions.Default.DeleteAction",
				"action.SimPe.Actions.Default.RestoreAction",
				"action.SimPe.Actions.Default.CloneAction",
				"action.SimPe.Actions.Default.CreateAction",
				"action.SimPe.Plugin.Tool.Action.ActionGlobalFixTGI",
				"SimPe.Plugin.Tool.LoadSims2PackTool",
				"SimPe.Plugin.NeighborhoodTool",
				"SimPe.Plugin.SimsTool",
				"SimPe.Plugin.SurgeryTool"
			};
			/// <summary>
			/// gets / sets the Theme for SimPe
			/// </summary>
			/// <remarks>Math.Min caps the maximum theme to 10 to prevent errors, must be increased to add another theme</remarks>
			public byte SelectedTheme { get; set; } = 1;
			/// <summary>
			/// true if classic pre-set has been launched
			/// </summary>
			public bool IsClassicPreset { get; set; } = false;
			/// <summary>
			/// true if the Layout should be stored on exit
			/// </summary>
			public bool AutoStoreLayout { get; set; } = true;
			public string ColumnOrder { get; set; } = "Name,Type,Group,InstHi,Inst,Offset,Size";
			/// <summary>
			/// Width of the Column in the main Window
			/// </summary>
			public int NameColumnWidth { get; set; } = 280;
			/// <summary>
			/// Width of the Column in the main Window
			/// </summary>
			public int TypeColumnWidth { get; set; } = 70;
			/// <summary>
			/// Width of the Column in the main Window
			/// </summary>
			public int GroupColumnWidth { get; set; } = 120;
			/// <summary>
			/// Width of the Column in the main Window
			/// </summary>
			public int InstanceHighColumnWidth { get; set; } = 120;
			/// <summary>
			/// Width of the Column in the main Window
			/// </summary>
			public int InstanceColumnWidth { get; set; } = 160;
			/// <summary>
			/// Width of the Column in the main Window
			/// </summary>
			public int OffsetColumnWidth { get; set; } = 120;
			/// <summary>
			/// Width of the Column in the main Window
			/// </summary>
			public int SizeColumnWidth { get; set; } = 140;
		}
		public class Configuration
		{
			public string Path { get; set; } = Helper.SimPePath;
			public string DataPath { get; set; } = Helper.SimPeDataPath;
			public string PluginPath { get; set; } = Helper.SimPePluginPath;
			public long LastVersion
			{
				get; set;
			}
			/// <summary>
			/// Whether the wait bar should always be shown
			/// </summary>
			public bool ShowWaitBarPermanent { get; set; } = true;
			public bool FileTableSimpleSelectUseGroups { get; set; } = true;
			/// <summary>
			/// Whether Sims Stories Hoods should be loaded as well
			/// </summary>
			public bool LoadAllHoods { get; set; } = false;
			public string UserName { get; set; } = "";
			/// <summary>
			/// Optional User Password
			/// </summary>
			public string Password { get; set; } = "";
			/// <summary>
			/// Whether the main file table should be loaded on startup
			/// </summary>
			public bool LoadTableAtStartup { get; set; } = false;
			/// <summary>
			/// Whether to enable the cache
			/// </summary>
			public bool UseCache { get; set; } = true;
			/// <summary>
			/// Whether to show the splash screen on startup
			/// </summary>
			public bool ShowStartupSplash { get; set; } = true;
			/// <summary>
			/// Whether to show the OBJD file names in Object Workshop
			/// </summary>
			public bool ShowObjdNames { get; set; } = false;
			/// <summary>
			/// Whether Joint names should be shown in GMDC
			/// </summary>
			public bool ShowJointNames { get; set; } = false;
			/// <summary>
			///Whether to decode Filenames
			/// </summary>
			public bool DecodeFilenamesState { get; set; } = true;
			/// <summary>
			/// Returns the maximum number of search results to show
			/// </summary>
			public int MaxSearchResults { get; set; } = 2000;
			/// <summary>
			/// Returns the Thumbnail Size for Treeview Items in Object Workshop
			/// </summary>
			public int OWThumbSize { get; set; } = 24;
			/// <summary>
			/// Whether to show walls in Object Workshop
			/// </summary>
			public bool OWincludewalls { get; set; } = false;
			/// <summary>
			/// Trim junk from names for Treeview Items in Object Workshop
			/// </summary>
			public bool OWtrimnames { get; set; } = false;
			/// <summary>
			/// true, if new Store Edition needs to be supported
			/// </summary>
			public bool UseExpansions2 { get; set; } = false;
			/// <summary>
			/// Set to an ST value to set all except that Sims Story Edition as not installed
			/// </summary>
			public int LoadOnlySimsStory { get; set; } = 0;
			/// <summary>
			/// true, if user uses the custom Music and Art sim Skills
			/// </summary>
			public bool ShowMoreSkills { get; set; } = false;
			/// <summary>
			/// true, if user uses the Dog Show or Training Items
			/// </summary>
			public bool ShowPetAbilities { get; set; } = false;
			/// <summary>
			/// the Scaling Factor that is used by the Gmdc Importer/Exporter
			/// </summary>
			public float ImportExportScaleFactor { get; set; } = 1.0f;
			/// <summary>
			/// true, if the HiddenMode is activated
			/// </summary>
			public bool HiddenMode { get; set; } = false;
			/// <summary>
			/// true, if Groups cache is going to be used
			/// </summary>
			public bool UseMaxisGroupsCache { get; set; } = false;
			/// <summary>
			/// the cached UserId
			/// </summary>
			public uint CachedUserId { get; set; } = 0;
			/// <summary>
			/// Language Code for SimPe
			/// </summary>
			public Data.Languages LanguageCode { get; set; } = Data.Languages.English;
			/// <summary>
			/// true, if the user wants to Load Meta Information
			/// </summary>
			public bool LoadMetaInfo { get; set; } = true;
			/// <summary>
			/// true, if the user want's to start the Game with Sound
			/// </summary>
			public bool EnableSound { get; set; } = true;
			/// <summary>
			/// true, if the user wants .bak files to be generated
			/// </summary>
			public bool AutoBackup { get; set; } = false;
			/// <summary>
			/// true, if the user wants the Waiting Screen
			/// </summary>
			public bool WaitingScreen { get; set; } = true;
			/// <summary>
			/// true, if the user wants to load Object Workshop fast
			/// </summary>
			public bool LoadOWFast { get; set; } = false;
			/// <summary>
			/// true, if the user wants to use the package Maintainer
			/// </summary>
			public bool UsePackageMaintainer { get; set; } = true;
			/// <summary>
			/// true, if the user wants to be able to have Multiple Files open
			/// </summary>
			public bool MultipleFiles { get; set; } = true;
			/// <summary>
			/// true, if the user should select a Resource with only one click
			/// </summary>
			public bool SimpleResourceSelect { get; set; } = true;
			/// <summary>
			/// true, if the user want's to control the Tabs like done in FireFox
			/// </summary>
			public bool FirefoxTabbing { get; set; } = true;
			/// <summary>
			/// Number of Resource Files per package
			/// </summary>
			public int BigPackageResourceCount { get; set; } = 2000;
			/// <summary>
			/// The LineMode that we should use for the GraphControls
			/// </summary>
			public int GraphLineMode { get; set; } = 2;
			/// <summary>
			/// should we use Quality Mode?
			/// </summary>
			public bool GraphQuality { get; set; } = true;
			/// <summary>
			/// should we prioritize mmat over cres
			/// </summary>
			public bool CresPrioritize { get; set; } = true;
			/// <summary>
			/// returns the last Extension used during a GMDC import/export
			/// </summary>
			public string GmdcExtension { get; set; } = ".obj";
			/// <summary>
			/// true, if the user did want to correct the Joint definitions during the last Export
			/// </summary>
			public bool CorrectJointDefinitionOnExport { get; set; } = false;
			/// <summary>
			/// Should we search the objects.package's for Sims?
			/// </summary>
			public bool DeepSimScan { get; set; } = true;
			/// <summary>
			/// Should we search the objects.package's for Sims?
			/// </summary>
			public bool DeepSimTemplateScan { get; set; } = false;
			/// <summary>
			/// True, if you want to see the progress of a package loading
			/// </summary>
			public bool ShowProgressWhenPackageLoads { get; set; } = false;
			/// <summary>
			/// Should we load Stuff Asynchron to the main Thread?
			/// </summary>
			public bool AsynchronLoad { get; set; } = false;
			/// <summary>
			/// Should we sort Stuff Asynchron to the main Thread?
			/// </summary>
			public bool AsynchronSort { get; set; } = true;
			/// <summary>
			/// True, if you allways want to select a type in a resource tree when a package is loaded
			/// </summary>
			public bool ResoruceTreeAlwaysAutoselect { get; set; } = true;
			/// <summary>
			/// How many threads do we start when we sort by name?
			/// </summary>
			public int SortProcessCount { get; set; } = 16;
			/// <summary>
			/// True, if you want to rebuild the ResourceTree whenever the type of a loaded Resource changes
			/// </summary>
			public bool UpdateResourceListWhenTGIChanges { get; set; } = true;
			/// <summary>
			/// Schould we lock the Docks?
			/// </summary>
			public bool LockDocks { get; set; } = false;
			/// <summary>
			/// set this true to allow families in the family bin to count as having a Lot
			/// </summary>
			public bool AllowLotZero { get; set; } = true;
			/// <summary>
			/// true, if user likes bigger Icons on the main tool bars
			/// </summary>
			public bool UseBigIcons { get; set; } = false;
			public List<string> RecentFiles { get; set; } = new List<string>();
			/// <summary>
			/// How do we display the name column?
			/// </summary>
			public ResourceListFormats ResourceListFormat { get; set; } = ResourceListFormats.JustNames;
			/// <summary>
			/// How do we display the name column?
			/// </summary>
			public ResourceListUnnamedFormats ResourceListUnknownDescriptionFormat
			{
				get; set;
			} = ResourceListUnnamedFormats.GroupInstance;
			/// <summary>
			/// How do we display the instance column?
			/// </summary>
			public ResourceListInstanceFormats ResourceListInstanceFormat { get; set; } = ResourceListInstanceFormats.HexDec;
			/// <summary>
			/// How do we display the name column?
			/// </summary>
			public ResourceListExtensionFormats ResourceListExtensionFormat { get; set; } = ResourceListExtensionFormats.Short;
			/// <summary>
			/// The Which Format do Reports have
			/// </summary>
			public ReportFormats ReportFormat { get; set; } = ReportFormats.Descriptive;
			public Dictionary<ulong, int> WrapperPriority { get; set; } = new Dictionary<ulong, int>();
			public bool KeepFilesOpen { get; set; } = true;
			public Dictionary<string, string> ExpansionInstallPaths { get; set; } = new Dictionary<string, string>();
			public string SaveGamePath { get; set; } = "";
			public string NvidiaDDSPath { get; set; } = "";
			public Dictionary<string, Dictionary<string, string>> ExtTools { get; set; } = new Dictionary<string, Dictionary<string, string>>();
			public int ExtObdjFormInitialTab { get; set; } = 0;
			public Dictionary<string, Dictionary<string, string>> PluginSettings { get; set; } = new Dictionary<string, Dictionary<string, string>>();
			public LayoutConfiguration Layout { get; set; } = new LayoutConfiguration();
			public Dictionary<uint, string> AdditionalCareers { get; set; } = new Dictionary<uint, string>();
			public Dictionary<uint, string> AdditionalMajors { get; set; } = new Dictionary<uint, string>();
			public Dictionary<uint, string> AdditionalSchools { get; set; } = new Dictionary<uint, string>();
		}

		#region Attributes
		public Configuration Config { get; private set; } = new Configuration();
		#endregion

		#region Management
		/// <summary>
		/// Creates a new Instance
		/// </summary>
		internal Registry()
		{
			string configpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe", "config.json");
			bool success = true;
			if (File.Exists(configpath))
			{
				try
				{
					Config = JsonSerializer.Deserialize<Configuration>(File.ReadAllText(configpath, Encoding.UTF8), new JsonSerializerOptions
					{
						UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip,
						DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
					});
				}
				catch (Exception ex) { Message.Show($"Config could not be loaded!\n{ex.Message}\n{ex.StackTrace}"); success = false; }
			}
			else
			{
				success = false;
			}
			if (!success)
			{
				Message.Show("No config found! Creating a new one.");
			}
		}

		/// <summary>
		/// Write the Settings to the Disk
		/// </summary>
		public void Flush()
		{
			SaveConfig();
		}
		#endregion

		/// <summary>
		/// Update the SimPe paths
		/// </summary>
		public void UpdateSimPEDirectory()
		{
			Config.Path = Helper.SimPePath;
			Config.DataPath = Helper.SimPeDataPath;
			Config.PluginPath = Helper.SimPePluginPath;
			Config.LastVersion = Helper.SimPeVersionLong;

			SaveConfig();
		}

		public void SaveConfig()
		{
			string configpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe", "config.json");
			try
			{
				File.WriteAllText(configpath, JsonSerializer.Serialize(Config, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);
			}
			catch (Exception ex)
			{
				Message.Show($"Config could not be saved!\n{ex.Message}\n{ex.StackTrace}");
			}
		}

		/// <summary>
		/// Returns the Version of the latest SimPe used so far
		/// </summary>
		public long PreviousVersion => Config.LastVersion;

		#region EP Handler
		public bool FoundUnknownEP()
		{
			string[] inst = InstalledEPExecutables;
			if (inst.Length == 0)
			{
				return false;
			}

			string[] eenames =
			{
				"sims2.exe",
				"sims2ep1.exe",
				"sims2ep2.exe",
				"sims2ep3.exe",
				"sims2sp1.exe",
				"sims2sp2.exe",
				"sims2ep4.exe",
				"sims2ep5.exe",
				"sims2sp4.exe",
				"sims2sp5.exe",
				"sims2ep6.exe",
				"sims2sp6.exe",
				"sims2ecc.exe",
				"sims2ep7.exe",
				"sims2sp7.exe",
				"sims2sp8.exe",
				"sims2ep8.exe",
				"sims2ep9.exe",
				"sims2sc.exe",
			};

			foreach (string si in inst)
			{
				if (si == "")
				{
					continue;
				}

				bool found = false;
				foreach (string n in eenames)
				{
					if (si == n)
					{
						found = true;
						break;
					}
				}
				if (!found)
				{
					return true;
				}
			}
			return false;
		}

		public string[] InstalledEPExecutables
		{
			get
			{
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					RegistryKey tk =
						Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
							"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\Sims2.exe",
							false
						);
					if (tk == null)
					{
						return new string[0];
					}

					object gr = tk.GetValue("Game Registry", false);
					RegistryKey rk =
						Microsoft.Win32.Registry.LocalMachine.OpenSubKey((string)gr, false);
					if (rk != null)
					{
						object o = rk.GetValue("EPsInstalled", "");
						if (o == null)
						{
							return new string[0];
						}

						string s = o.ToString();

						string[] ret = s.Split(new char[] { ',' });
						for (int i = 0; i < ret.Length; i++)
						{
							ret[i] = ret[i].ToLower().Trim();
						}

						return ret;
					}
					else
					{
						return new string[0];
					}
				}
				else
					return new string[0];
			}
		}

		#endregion

		#region ResourceList
		public enum ResourceListFormats : int
		{
			LongTypeNames,
			ShortTypeNames,
			JustNames,
			JustLongType,
		}

		public enum ResourceListUnnamedFormats : int
		{
			Instance,
			GroupInstance,
			FullTGI,
		}

		public enum ResourceListExtensionFormats : int
		{
			Hex,
			Short,
			Long,
			None,
		}

		public enum ResourceListInstanceFormats : int
		{
			HexOnly,
			DecOnly,
			HexDec,
		}

		/// <summary>
		/// Schould we disaplay the resource extensions in the list?
		/// </summary>
		public bool ResourceListShowExtensions => Config.ResourceListExtensionFormat != ResourceListExtensionFormats.None;
		#endregion

		#region Report Format
		public enum ReportFormats : int
		{
			Descriptive,
			CSV,
		}
		#endregion

		#region Wrappers
		/// <summary>
		/// Returns the Priority for the Wrapper identified with the given UID
		/// </summary>
		/// <param name="uid">uique id of the Wrapper</param>
		/// <returns>Priority for the Wrapper</returns>
		public int GetWrapperPriority(ulong uid)
		{
			return Config.WrapperPriority.ContainsKey(uid) ? Config.WrapperPriority[uid] : 0;
		}

		/// <summary>
		/// Stores the Priority of a Wrapper
		/// </summary>
		/// <param name="uid">uique id of the Wrapper</param>
		/// <param name="priority">the new Priority</param>
		public void SetWrapperPriority(ulong uid, int priority)
		{
			Config.WrapperPriority[uid] = priority;
		}
		#endregion

		#region recent Files
		public void ClearRecentFileList()
		{
			Config.RecentFiles.Clear();
		}

		/// <summary>
		/// Returns a List of recently opened Files
		/// </summary>
		/// <returns>List of Filenames</returns>
		public IEnumerable<string> GetRecentFiles()
		{
			return Config.RecentFiles.Select(item => item).Reverse();
		}

		/// <summary>
		/// Adds a File to the List of recently opened Files
		/// </summary>
		/// <param name="filename">The Filename</param>
		public void AddRecentFile(string filename)
		{
			if (filename == null || filename.Trim() == "" || !File.Exists(filename))
			{
				return;
			}

			filename = filename.Trim();
			if (Config.RecentFiles.Contains(filename))
			{
				Config.RecentFiles.Remove(filename);
			}
			Config.RecentFiles.Add(filename);
			if (Config.RecentFiles.Count > 15)
			{
				Config.RecentFiles = Config.RecentFiles.Select(item => item)
					.Reverse().Take(15).Reverse().ToList();
			}
		}
		#endregion

		#region Starup Cheat File
		/// <summary>
		/// Returns true if the Game will start in Debug Mode
		/// </summary>
		public bool GameDebug
		{
			get
			{
				if (!System.IO.File.Exists(PathProvider.Global.StartupCheatFile))
				{
					return false;
				}

				try
				{
					System.IO.TextReader fs = System.IO.File.OpenText(
						PathProvider.Global.StartupCheatFile
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
						{
							pline = pline.Replace("  ", " ");
						}

						string[] tokens = pline.Split(" ".ToCharArray());

						if (tokens.Length == 3)
						{
							if (
								(tokens[0] == "boolprop")
								&& (tokens[1] == "testingcheatsenabled")
								&& (tokens[2] == "true")
							)
							{
								return true;
							}
						}
					}
				}
				catch (Exception) { }

				return false;
			}
			set
			{
				if (
					!System.IO.Directory.Exists(
						System.IO.Path.GetDirectoryName(
							PathProvider.Global.StartupCheatFile
						)
					)
				)
				{
					return;
				}

				try
				{
					string newcont = "";
					bool found = false;
					if (System.IO.File.Exists(PathProvider.Global.StartupCheatFile))
					{
						System.IO.TextReader fs = System.IO.File.OpenText(
							PathProvider.Global.StartupCheatFile
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
							{
								pline = pline.Replace("  ", " ");
							}

							string[] tokens = pline.Split(" ".ToCharArray());

							if (tokens.Length == 3)
							{
								if (
									(tokens[0] == "boolprop")
									&& (tokens[1] == "testingcheatsenabled")
								)
								{
									if (!found)
									{
										newcont += "boolProp testingCheatsEnabled ";
										if (value)
										{
											newcont += "true";
										}
										else
										{
											newcont += "false";
										}

										newcont += Helper.lbr;
										found = true;
									}
									continue;
								}
							}
							newcont += line.Trim();
							newcont += Helper.lbr;
						}

						System.IO.File.Delete(PathProvider.Global.StartupCheatFile);
					}

					if (!found)
					{
						newcont += "boolProp testingCheatsEnabled ";
						if (value)
						{
							newcont += "true";
						}
						else
						{
							newcont += "false";
						}

						newcont += Helper.lbr;
					}

					System.IO.TextWriter fw = System.IO.File.CreateText(
						PathProvider.Global.StartupCheatFile
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

		#region Censor Patch
		/// <summary>
		/// Returns true if the Game will start in Debug Mode
		/// </summary>
		[System.ComponentModel.ReadOnly(true)]
		public bool BlurNudity
		{
			get => PathProvider.Global.BlurNudity;
			set => PathProvider.Global.BlurNudity = value;
		}

		public void BlurNudityUpdate()
		{
			PathProvider.Global.BlurNudityUpdate();
		}
		#endregion
	}
}
