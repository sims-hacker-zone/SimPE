// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

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

		}

		#region Attributes
		///Number of Recent Files stored in the Reg
		public const byte RECENT_COUNT = 15;

		/// <summary>
		/// Contains the Registry
		/// </summary>
		XmlRegistry reg;

		/// <summary>
		/// The registery for the MRU list
		/// </summary>
		XmlRegistry mru;

		/// <summary>
		/// The Root Registry Key for this Application
		/// </summary>
		XmlRegistryKey mrk;

		/// <summary>
		/// Returns the LayoutRegistry
		/// </summary>
		public LayoutRegistry Layout
		{
			get; private set;
		}

		public Configuration Config { get; private set; } = new Configuration();

		// int pep, pepct; long pver; - seem not to be used will comment all out
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
			// pep = -1;
			// pepct = this.GetPreviousEpCount();
			Reload();
			if (Helper.QARelease)
			{
				WasQAUser = true;
			}
		}

		/// <summary>
		/// Reload the SimPe Registry
		/// </summary>
		public void Reload()
		{
			reg = new XmlRegistry(
				Helper.DataFolder.SimPeXREG,
				Helper.DataFolder.SimPeXREGW,
				true
			);
			RegistryKey = reg.CurrentUser.CreateSubKey(@"Software\Ambertation\SimPe");
			ReloadLayout();
			mru = new XmlRegistry(
				Helper.DataFolder.MRUXREG,
				Helper.DataFolder.MRUXREGW,
				true
			);
			mrk = mru.CurrentUser.CreateSubKey(@"Software\Ambertation\SimPe");
		}

		/// <summary>
		/// Reload the SimPe Registry
		/// </summary>
		public void ReloadLayout()
		{
			//lr = new LayoutRegistry(xrk.CreateSubKey("Layout"));
			Layout = new LayoutRegistry(null);
		}

		/// <summary>
		/// Descturtor
		/// </summary>
		/// <remarks>
		/// Will flsuh the XmlRegistry to the disk
		/// </remarks>
		~Registry()
		{
			//Flush();
		}

		/// <summary>
		/// Write the Settings to the Disk
		/// </summary>
		public void Flush()
		{
			SaveConfig();
			Layout?.Flush();

			reg?.Flush();

			mru?.Flush();
		}

		/// <summary>
		/// Returns the Registry Key you can use to store Optional Plugin Data
		/// </summary>
		public XmlRegistryKey PluginRegistryKey => RegistryKey.CreateSubKey("PluginSettings");

		/// <summary>
		/// Returns the Base Registry Key
		/// </summary>
		public XmlRegistryKey RegistryKey
		{
			get; private set;
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
		/// Returns the DataFolder as set by the last SimPe run
		/// </summary>
		public string PreviousDataFolder => Config.DataPath;

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

		/// <summary>
		/// true, if the user wants File Table Simple Selection - Fixed now but Setting Manager has to be re-started for change to show
		/// </summary>
		public bool FileTableSimpleSelectUseGroups
		{
			get => !HiddenMode && Config.FileTableSimpleSelectUseGroups;
			set => Config.FileTableSimpleSelectUseGroups = value;
		}

		/// <summary>
		/// true, if new Store Edition needs to be supported
		/// </summary>
		public bool UseExpansions2
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("UseExpansions2", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("UseExpansions2", value);
			}
		}

		/// <summary>
		/// Set to an ST value to set all except that Sims Story Edition as not installed
		/// </summary>
		public int LoadOnlySimsStory
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("LoadOnlySimsStory", 0);
				return Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("LoadOnlySimsStory", value);
			}
		}

		/// <summary>
		/// true, if user likes bigger Icons on the main tool bars
		/// </summary>
		[System.ComponentModel.Description(
			"Enable this for larger Icons on the main toolbar and larger fonts in some areas"
		)]
		public bool UseBigIcons
		{
			get
			{
				if (Helper.WindowsRegistry.Layout.IsClassicPreset)
				{
					return false;
				}

				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("UseBigIcons", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("UseBigIcons", value);
			}
		}

		/// <summary>
		/// true, if user uses the custom Music and Art sim Skills
		/// </summary>
		[System.ComponentModel.Description(
			"Enable this if you use the Custom Music and Art Skills for your sims"
		)]
		public bool ShowMoreSkills
		{
			get
			{
				if (Helper.WindowsRegistry.Layout.IsClassicPreset)
				{
					return false;
				}

				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowMoreSkills", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ShowMoreSkills", value);
			}
		}

		/// <summary>
		/// true, if user uses the Dog Show or Training Items
		/// </summary>
		[System.ComponentModel.Description(
			"Enable this if you use the Pet Stories Dog Show or Training Items for your pets"
		)]
		public bool ShowPetAbilities
		{
			get
			{
				if (Helper.WindowsRegistry.Layout.IsClassicPreset)
				{
					return false;
				}

				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowPetAbilities", "false");
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ShowPetAbilities", value);
			}
		}

		/// <summary>
		/// true, if we allow Users to change the secondary aspiraions.
		/// </summary>
		public bool AllowChangeOfSecondaryAspiration
		{
			get
			{
				if (Helper.WindowsRegistry.Layout.IsClassicPreset)
				{
					return false;
				}

				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("AllowChangeOfSecondaryAspiration", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("AllowChangeOfSecondaryAspiration", value);
			}
		}

		/// <summary>
		/// the Scaling Factor that is used by the Gmdc Importer/Exporter
		/// </summary>
		public float ImportExportScaleFactor
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("ImExportScale", 1.0f);
				return Convert.ToSingle(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ImExportScale", value);
			}
		}

		/// <summary>
		/// true, if the HiddenMode (Crap Mode) is activated
		/// </summary>
		public bool HiddenMode
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("EnableSimPEHiddenMode", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("EnableSimPEHiddenMode", value);
			}
		}

		/// <summary>
		/// true, if Groups cache is going to be used
		/// </summary>
		[System.ComponentModel.Description(
			"Enable this if some thumbnails from custom packages do not load right. This will slow down the loading of the first package in a SimPe Session"
		)]
		public bool UseMaxisGroupsCache
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("UseMaxisGroupsCache", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("UseMaxisGroupsCache", value);
			}
		}

		/// <summary>
		/// true, if the user wanted to decode Filenames
		/// </summary>
		public bool DecodeFilenamesState
		{
			get
			{
				if (Helper.WindowsRegistry.Layout.IsClassicPreset)
				{
					return false;
				}

				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("DecodeFilenames", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("DecodeFilenames", value);
			}
		}

		/// <summary>
		/// the cached UserId
		/// </summary>
		public uint CachedUserId
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("CUi", 0);
				return Convert.ToUInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("CUi", value);
			}
		}

		/// <summary>
		/// Language Code for SimPe
		/// </summary>
		public Data.Languages LanguageCode
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("Language");
				return o == null ? Helper.GetMatchingLanguage() : (Data.Languages)Convert.ToByte(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("Language", (byte)value);
			}
		}

		/// <summary>
		/// Optional User Password
		/// </summary>
		public string Password
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("Password", "");
				return o.ToString();
				//return descramble(o.ToString());
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("Password", value);
				//rkf.SetValue("Password", scramble(value));
			}
		}

		/// <summary>
		/// This was not used and always return zero, I have
		/// Made it return the Current SimPe Version,
		/// Was an int which may cause an issue if an old
		/// addon did call it
		/// </summary>
		public long Version => Helper.SimPeVersionLong;

		/// <summary>
		/// Returns the maximum number of search results to show
		/// </summary>
		public int MaxSearchResults
		{
			get
			{
				try
				{
					XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
					object o = rkf.GetValue("MaxSearchResults", 2000);
					return (int)o;
				}
				catch (Exception)
				{
					return 16;
				}
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("MaxSearchResults", value);
			}
		}

		/// <summary>
		/// Returns the Thumbnail Size for Treeview Items in Object Workshop
		/// </summary>
		public int OWThumbSize
		{
			get
			{
				try
				{
					XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
					object o = rkf.GetValue("OWThumbSize", 24);
					return (int)o;
				}
				catch (Exception)
				{
					return 24;
				}
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("OWThumbSize", value);
			}
		}

		/// <summary>
		/// Returns the Thumbnail Size for Treeview Items in Object Workshop
		/// </summary>
		public bool OWincludewalls
		{
			get
			{
				try
				{
					XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
					object o = rkf.GetValue("OWWallsFloors", false);
					return (bool)o;
				}
				catch (Exception)
				{
					return false;
				}
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("OWWallsFloors", value);
			}
		}

		/// <summary>
		/// Trim junk from names for Treeview Items in Object Workshop
		/// </summary>
		public bool OWtrimnames
		{
			get
			{
				try
				{
					XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
					object o = rkf.GetValue("OWTrimNames", false);
					return (bool)o;
				}
				catch (Exception)
				{
					return false;
				}
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("OWTrimNames", value);
			}
		}

		/// <summary>
		/// true, if the user wants to Load Meta Information
		/// </summary>
		public bool LoadMetaInfo
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("LoadMetaInfos", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("LoadMetaInfos", value);
			}
		}

		/// <summary>
		/// true, if the user want's to start the Game with Sound
		/// </summary>
		public bool EnableSound
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("EnableSound", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("EnableSound", value);
			}
		}

		/// <summary>
		/// true, if the user wants .bak files to be generated
		/// </summary>
		public bool AutoBackup
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("AutoBackup", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("AutoBackup", value);
			}
		}

		/// <summary>
		/// true, if the user wants the Waiting Screen
		/// </summary>
		public bool WaitingScreen
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("WaitingScreen", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("WaitingScreen", value);
			}
		}

		/// <summary>
		/// true, if the user wants the Waiting Screen as a TopMost Window, seems not to be used but I don't know why not
		/// </summary>
		public bool WaitingScreenTopMost
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("WaitingScreenTopMost", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("WaitingScreenTopMost", value);
			}
		}

		/// <summary>
		/// true, if the user wants to load Object Workshop fast
		/// </summary>
		public bool LoadOWFast
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("LoadOWFast", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("LoadOWFast", value);
			}
		}

		/// <summary>
		/// true, if the user wants to use the package Maintainer
		/// </summary>
		public bool UsePackageMaintainer
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("UsePkgMaintainer", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("UsePkgMaintainer", value);
			}
		}

		/// <summary>
		/// true, if the user wants to be able to have Multiple Files open
		/// </summary>
		public bool MultipleFiles
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("MultipleFiles", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("MultipleFiles", value);
			}
		}

		/// <summary>
		/// true, if the user should select a Resource with only one click
		/// </summary>
		public bool SimpleResourceSelect
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("SimpleResourceSelect", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("SimpleResourceSelect", value);
			}
		}

		/// <summary>
		/// true, if the user want's to control the Tabs like done in FireFox
		/// </summary>
		public bool FirefoxTabbing
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("FirefoxTabbing", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("FirefoxTabbing", value);
			}
		}

		/// <summary>
		/// true, if the user ever started a QA Version
		/// </summary>
		public bool WasQAUser
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("WasQAUser", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("WasQAUser", value);
			}
		}

		/// <summary>
		/// Number of Resource Files per package
		/// </summary>
		public int BigPackageResourceCount
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("BigPackageResourceCount", 2000);
				return Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("BigPackageResourceCount", value);
			}
		}

		/// <summary>
		/// The LineMode that we should use for the GraphControls
		/// </summary>
		public int GraphLineMode
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("GraphLineMode", 0x02);
				return Convert.ToInt16(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("GraphLineMode", value);
			}
		}

		/// <summary>
		/// should we use Qulity Mode?
		/// </summary>
		public bool GraphQuality
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("GraphQuality", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("GraphQuality", value);
			}
		}

		/// <summary>
		/// should we prioritize mmat over cres
		/// </summary>
		public bool CresPrioritize
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("CresPrioritize", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("CresPrioritize", value);
			}
		}

		/// <summary>
		/// returns the last Extension used during a GMDC import/export
		/// </summary>
		public string GmdcExtension
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("GmdcExtension", ".obj");
				string s = o.ToString();
				return s.Replace("*", "");
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("GmdcExtension", value);
			}
		}

		/// <summary>
		/// true, if the user did want to correct the Joint definitions during the last Export
		/// </summary>
		public bool CorrectJointDefinitionOnExport
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("CorrectJointDefinitionOnExport", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("CorrectJointDefinitionOnExport", value);
			}
		}

		/// <summary>
		/// Should we search the objects.package's for Sims?
		/// </summary>
		public bool DeepSimScan
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("DeepSimScan", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("DeepSimScan", value);
			}
		}

		/// <summary>
		/// Should we search the objects.package's for Sims?
		/// </summary>
		public bool DeepSimTemplateScan
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("DeepSimTemplateScan", false);
				return Convert.ToBoolean(o) && DeepSimScan;
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("DeepSimTemplateScan", value);
			}
		}

		/// <summary>
		/// True, if you want to see the progress of a package loading
		/// </summary>
		public bool ShowProgressWhenPackageLoads
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowProgressWhenPackageLoads", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ShowProgressWhenPackageLoads", value);
			}
		}

		/// <summary>
		/// Should we load Stuff Asynchron to the main Thread?
		/// </summary>
		public bool AsynchronLoad
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("AsynchronLoad", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("AsynchronLoad", value);
			}
		}

		/// <summary>
		/// Should we sort Stuff Asynchron to the main Thread?
		/// </summary>
		public bool AsynchronSort
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("AsynchronSort", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("AsynchronSort", value);
			}
		}

		/// <summary>
		/// True, if you allways want to select a type in a resource tree when a package is loaded
		/// </summary>
		public bool ResoruceTreeAllwaysAutoselect
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("ResoruceTreeAllwaysAutoselect", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ResoruceTreeAllwaysAutoselect", value);
			}
		}

		/// <summary>
		/// How many threads do we start when we sort by name?
		/// </summary>
		public int SortProcessCount
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("SortProcessCount", 16);
				return Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("SortProcessCount", value);
			}
		}

		/// <summary>
		/// True, if you want to rebuild the ResourceTree whenever the type of a loaded Resource changes
		/// </summary>
		public bool UpdateResourceListWhenTGIChanges
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("UpdateResourceListWhenTGIChanges", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("UpdateResourceListWhenTGIChanges", value);
			}
		}

		/// <summary>
		/// Schould we lock the Docks?
		/// </summary>
		public bool LockDocks
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("LockDocks", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("LockDocks", value);
			}
		}

		/// <summary>
		/// set this true to allow families in the family bin to count as having a Lot
		/// </summary>
		[System.ComponentModel.Description(
			"Enable this to allow the family bin to count as a Lot"
		)]
		public bool AllowLotZero
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("allowlotzero", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("allowlotzero", value);
			}
		}

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
		/// How do we display the name column?
		/// </summary>
		public ResourceListFormats ResourceListFormat
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue(
					"ResourceListFormat",
					(int)ResourceListFormats.JustNames
				);
				return (ResourceListFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ResourceListFormat", (int)value);
			}
		}

		/// <summary>
		/// How do we display the name column?
		/// </summary>
		public ResourceListUnnamedFormats ResourceListUnknownDescriptionFormat
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue(
					"ResourceListUnknownDescriptionFormat",
					(int)ResourceListUnnamedFormats.GroupInstance
				);
				return (ResourceListUnnamedFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ResourceListUnknownDescriptionFormat", (int)value);
			}
		}

		/// <summary>
		/// How do we display the instance column?
		/// </summary>
		public ResourceListInstanceFormats ResourceListInstanceFormat
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue(
					"ResourceListInstanceFormat",
					(int)ResourceListInstanceFormats.HexDec
				);
				return (ResourceListInstanceFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ResourceListInstanceFormat", (int)value);
			}
		}
		public bool ResourceListInstanceFormatHexOnly => ResourceListInstanceFormat
					== ResourceListInstanceFormats.HexOnly;
		public bool ResourceListInstanceFormatDecOnly => ResourceListInstanceFormat
					== ResourceListInstanceFormats.DecOnly;
		public bool ResourceListInstanceFormatHexDec => ResourceListInstanceFormat == ResourceListInstanceFormats.HexDec;

		/// <summary>
		/// How do we display the name column?
		/// </summary>
		public ResourceListExtensionFormats ResourceListExtensionFormat
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue(
					"ResourceListExtensionFormat",
					(int)ResourceListExtensionFormats.Short
				);
				return (ResourceListExtensionFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ResourceListExtensionFormat", (int)value);
			}
		}

		/// <summary>
		/// Schould we disaplay the resource extensions in the list?
		/// </summary>
		public bool ResourceListShowExtensions => ResourceListExtensionFormat != ResourceListExtensionFormats.None;
		#endregion

		#region Report Format
		public enum ReportFormats : int
		{
			Descriptive,
			CSV,
		}

		/// <summary>
		/// The Which Format do Reports have
		/// </summary>
		public ReportFormats ReportFormat
		{
			get
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				object o = rkf.GetValue("ReportFormat", (int)ReportFormats.Descriptive);
				return (ReportFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = RegistryKey.CreateSubKey("Settings");
				rkf.SetValue("ReportFormat", (int)value);
			}
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
			XmlRegistryKey rkf = RegistryKey.CreateSubKey("Priorities");
			object o = rkf.GetValue($"{uid:X16}");
			return o == null ? 0x00000000 : Convert.ToInt32(o);
		}

		/// <summary>
		/// Stores the Priority of a Wrapper
		/// </summary>
		/// <param name="uid">uique id of the Wrapper</param>
		/// <param name="priority">the new Priority</param>
		public void SetWrapperPriority(ulong uid, int priority)
		{
			XmlRegistryKey rkf = RegistryKey.CreateSubKey("Priorities");
			rkf.SetValue($"{uid:X16}", priority);
		}
		#endregion

		#region recent Files
		public void ClearRecentFileList()
		{
			XmlRegistryKey rkf = mrk.CreateSubKey("Listings");
			rkf.SetValue("RecentFiles", new Ambertation.CaseInvariantArrayList());
			mru.Flush();
		}

		/// <summary>
		/// Returns a List of recently opened Files
		/// </summary>
		/// <returns>List of Filenames</returns>
		public string[] GetRecentFiles()
		{
			XmlRegistryKey rkf = mrk.CreateSubKey("Listings");
			Ambertation.CaseInvariantArrayList al = (Ambertation.CaseInvariantArrayList)
				rkf.GetValue("RecentFiles", new Ambertation.CaseInvariantArrayList());

			string[] res = new string[al.Count];
			al.CopyTo(res);
			return res;
		}

		/// <summary>
		/// Adds a File to the List of recently opened Files
		/// </summary>
		/// <param name="filename">The Filename</param>
		public void AddRecentFile(string filename)
		{
			if (filename == null)
			{
				return;
			}

			if (filename.Trim() == "")
			{
				return;
			}

			if (!System.IO.File.Exists(filename))
			{
				return;
			}

			filename = filename.Trim();
			XmlRegistryKey rkf = mrk.CreateSubKey("Listings");

			Ambertation.CaseInvariantArrayList al = (Ambertation.CaseInvariantArrayList)
				rkf.GetValue("RecentFiles", new Ambertation.CaseInvariantArrayList());
			if (al.Contains(filename))
			{
				al.Remove(filename);
			}

			al.Insert(0, filename);
			while (al.Count > RECENT_COUNT)
			{
				al.RemoveAt(al.Count - 1);
			}

			rkf.SetValue("RecentFiles", al);
			mru.Flush();
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
