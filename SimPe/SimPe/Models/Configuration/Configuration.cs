// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Avalonia.Collections;

using CommunityToolkit.Mvvm.ComponentModel;

using SimPe.Data;
using SimPe.Extensions;
using SimPe.Views;

namespace SimPe.Models.Configuration
{
	public partial class Configuration : ObservableObject
	{
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
		public ObservableCollection<string> RecentFiles { get; set; } = [];
		public AvaloniaDictionary<ulong, int> WrapperPriority { get; set; } = [];
		public bool KeepFilesOpen { get; set; } = true;
		[ObservableProperty]
		private ObservableCollection<InstalledExpansionConfig> expansionInstallPaths = [];
		public string SaveGamePath { get; set; } = "";
		public string NvidiaDDSPath { get; set; } = "";
		public AvaloniaDictionary<string, AvaloniaDictionary<string, string>> ExtTools { get; set; } = [];
		public int ExtObdjFormInitialTab { get; set; } = 0;
		public AvaloniaDictionary<string, AvaloniaDictionary<string, string>> PluginSettings { get; set; } = [];
		public AvaloniaDictionary<uint, string> AdditionalCareers { get; set; } = [];
		public AvaloniaDictionary<uint, string> AdditionalMajors { get; set; } = [];
		public AvaloniaDictionary<uint, string> AdditionalSchools { get; set; } = [];

		private static readonly JsonSerializerOptions options = new()
		{
			UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip,
			DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
			WriteIndented = true
		};

		public static async Task<Configuration> Load()
		{
			if (!options.Converters.OfType<DictionaryTKeyEnumTValueConverter>().Any())
			{
				options.Converters.Add(new DictionaryTKeyEnumTValueConverter());
			}
			string configpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe", "config.json");
			bool success = true;
			Configuration config = new();
			if (File.Exists(configpath))
			{
				try
				{
					config = JsonSerializer.Deserialize<Configuration>(await File.ReadAllTextAsync(configpath, Encoding.UTF8), options);
				}
				catch (Exception ex) { await Message.Show($"Config could not be loaded!\n{ex.Message}\n{ex.StackTrace}"); success = false; }
			}
			else
			{
				success = false;
			}
			if (!success)
			{
				await Message.Show("No config found! Creating a new one.");
			}
			config.LastVersion = Helper.SimPeVersionLong;

			return config;
		}

		public async Task Save()
		{
			if (!options.Converters.OfType<DictionaryTKeyEnumTValueConverter>().Any())
			{
				options.Converters.Add(new DictionaryTKeyEnumTValueConverter());
			}
			string configpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimPe", "config.json");
			try
			{
				await File.WriteAllTextAsync(configpath, JsonSerializer.Serialize(this, options), Encoding.UTF8);
			}
			catch (Exception ex)
			{
				await Message.Show($"Config could not be saved!\n{ex.Message}\n{ex.StackTrace}");
			}
		}
	}
}
