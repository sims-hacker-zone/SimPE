/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.IO;
using System.Xml;

using Microsoft.Win32;

namespace SimPe
{
	/// <summary>
	/// Handles Application Settings stored in the Registry
	/// </summary>
	/// <remarks>You cannot create instance of this class, use the
	/// <see cref="SimPe.Helper.WindowsRegistry"/> Field to acces the Registry</remarks>
	public class Registry
	{
		#region Attributes
		///Number of Recent Files stored in the Reg
		public const byte RECENT_COUNT = 15;

		/// <summary>
		/// The Root Registry Kex for this Application
		/// </summary>
		private RegistryKey rk;

		/// <summary>
		/// Contains the Registry
		/// </summary>
		XmlRegistry reg;

		/// <summary>
		/// The Root Registry Key for this Application
		/// </summary>
		XmlRegistryKey xrk;

		/// <summary>
		/// The registery for the MRU list
		/// </summary>
		XmlRegistry mru;

		/// <summary>
		/// The Root Registry Key for this Application
		/// </summary>
		XmlRegistryKey mrk;

		LayoutRegistry lr;

		/// <summary>
		/// Returns the LayoutRegistry
		/// </summary>
		public LayoutRegistry Layout => lr;
		long pver;
		// int pep, pepct; long pver; - seem not to be used will comment all out
		#endregion

		#region Management
		/// <summary>
		/// Creates a new Instance
		/// </summary>
		internal Registry()
		{
			rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(
				"Software\\Ambertation\\SimPe"
			);
			pver = this.GetPreviousVersion();
			// pep = -1;
			// pepct = this.GetPreviousEpCount();
			Reload();
			if (Helper.QARelease)
				this.WasQAUser = true;
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
			xrk = reg.CurrentUser.CreateSubKey(@"Software\Ambertation\SimPe");
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
			lr = new LayoutRegistry(null);
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
			if (lr != null)
				lr.Flush();
			if (reg != null)
				reg.Flush();
			if (mru != null)
				mru.Flush();
		}

		/// <summary>
		/// Returns the Registry Key you can use to store Optional Plugin Data
		/// </summary>
		public XmlRegistryKey PluginRegistryKey => xrk.CreateSubKey("PluginSettings");

		/// <summary>
		/// Returns the Base Registry Key
		/// </summary>
		public XmlRegistryKey RegistryKey => xrk;
		#endregion

		/// <summary>
		/// Update the SimPe paths
		/// </summary>
		public void UpdateSimPEDirectory()
		{
			RegistryKey rkf = rk.CreateSubKey("Settings");
			rkf.SetValue("Path", Helper.SimPePath);
			rkf.SetValue("DataPath", Helper.SimPeDataPath);
			rkf.SetValue("PluginPath", Helper.SimPePluginPath);
			rkf.SetValue("LastVersion", Helper.SimPeVersionLong);
		}

		/// <summary>
		/// Returns the DataFolder as set by the last SimPe run
		/// </summary>
		public string PreviousDataFolder
		{
			get
			{
				RegistryKey rkf = rk.CreateSubKey("Settings");
				return rkf.GetValue("DataPath", "").ToString();
			}
		}

		public string GetPreviousData()
		{
			RegistryKey rkf = rk.CreateSubKey("Settings");
			return rkf.GetValue("DataPath", "").ToString();
		}

		/// <summary>
		/// Returns the SimPe Version as set by the last SimPe run
		/// </summary>
		public long GetPreviousVersion()
		{
			RegistryKey rkf = rk.CreateSubKey("Settings");
			return Convert.ToInt64(rkf.GetValue("LastVersion", (long)0));
		}

		/// <summary>
		/// Returns the Version of the latest SimPe used so far
		/// </summary>
		public long PreviousVersion => pver;

		#region EP Handler
		public bool FoundUnknownEP()
		{
			string[] inst = InstalledEPExecutables;
			if (inst.Length == 0)
				return false;
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
					continue;
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
					return true;
			}
			return false;
		}

		public string[] InstalledEPExecutables
		{
			get
			{
				Microsoft.Win32.RegistryKey tk =
					Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
						"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\Sims2.exe",
						false
					);
				if (tk == null)
					return new string[0];
				object gr = tk.GetValue("Game Registry", false);
				Microsoft.Win32.RegistryKey rk =
					Microsoft.Win32.Registry.LocalMachine.OpenSubKey((string)gr, false);
				if (rk != null)
				{
					object o = rk.GetValue("EPsInstalled", "");
					if (o == null)
						return new string[0];

					string s = o.ToString();

					string[] ret = s.Split(new char[] { ',' });
					for (int i = 0; i < ret.Length; i++)
						ret[i] = ret[i].ToLower().Trim();

					return ret;
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
			get
			{
				if (HiddenMode)
					return false;
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("FileTableSimpleSelectUseGroups", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("FileTableSimpleSelectUseGroups", value);
			}
		}

		/// <summary>
		/// true, if the user wants the Wait bar to always be visible
		/// </summary>
		public bool ShowWaitBarPermanent
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowWaitBarPermanent", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("ShowWaitBarPermanent", value);
			}
		}

		/// <summary>
		/// true, if user want all neighbourhoods available
		/// </summary>
		[System.ComponentModel.Description(
			"Enable this to load sim story neighbourhoods as well as default"
		)]
		public bool LoadAllNeighbourhoods
		{
			get
			{
				if (
					Helper.WindowsRegistry.Layout.IsClassicPreset
					|| LoadOnlySimsStory > 0
				)
					return false;
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("LoadAllHoods", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("LoadAllHoods", value);
			}
		}

		/// <summary>
		/// true, if new Store Edition needs to be supported
		/// </summary>
		public bool UseExpansions2
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("UseExpansions2", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("LoadOnlySimsStory", 0);
				return Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
					return false;
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("UseBigIcons", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
					return false;
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowMoreSkills", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
					return false;
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowPetAbilities", "false");
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("ShowPetAbilities", value);
			}
		}

		/// <summary>
		/// true to load the main file table at startup
		/// </summary>
		[System.ComponentModel.Description(
			"Enable this to load the main file table at startup instead of when first needed"
		)]
		public bool LoadTableAtStartup
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("loadAtStartup", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("loadAtStartup", value);
			}
		}

		/// <summary>
		/// true, if user wants to activate the Cache
		/// </summary>
		public bool UseCache
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("UseCache", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("UseCache", value);
			}
		}

		/// <summary>
		/// true, if user wants see the startup splash screen
		/// </summary>
		public bool ShowStartupSplash
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowStartupSplash", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("ShowStartupSplash", value);
			}
		}

		/// <summary>
		/// true, if user wants to show the OBJD Filenames in OW
		/// </summary>
		public bool ShowObjdNames
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowObjdNames", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("ShowObjdNames", value);
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
					return false;
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("AllowChangeOfSecondaryAspiration", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("AllowChangeOfSecondaryAspiration", value);
			}
		}

		/// <summary>
		/// true, if user wants to show the Name of a Joint in the GMDC Plugin
		/// </summary>
		public bool ShowJointNames
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowJointNames", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("ShowJointNames", value);
			}
		}

		/// <summary>
		/// the Scaling Factor that is used by the Gmdc Importer/Exporter
		/// </summary>
		public float ImportExportScaleFactor
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ImExportScale", 1.0f);
				return Convert.ToSingle(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("EnableSimPEHiddenMode", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("UseMaxisGroupsCache", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
					return false;
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("DecodeFilenames", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("DecodeFilenames", value);
			}
		}

		/// <summary>
		/// Optional User Name
		/// </summary>
		public string Username
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("Username", "");
				return o.ToString();
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("Username", value);
			}
		}

		/// <summary>
		/// the cached UserId
		/// </summary>
		public uint CachedUserId
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("CUi", 0);
				return Convert.ToUInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("CUi", value);
			}
		}

		/// <summary>
		/// Language Code for SimPe
		/// </summary>
		public Data.MetaData.Languages LanguageCode
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("Language");
				if (o == null)
					return Helper.GetMatchingLanguage();
				else
					return (Data.MetaData.Languages)Convert.ToByte(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("Password", "");
				return o.ToString();
				//return descramble(o.ToString());
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
					XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
					XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
					XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
					XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("LoadMetaInfos", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("EnableSound", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("AutoBackup", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("WaitingScreen", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("WaitingScreenTopMost", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("LoadOWFast", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("UsePkgMaintainer", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("MultipleFiles", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("SimpleResourceSelect", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("FirefoxTabbing", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("WasQAUser", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("BigPackageResourceCount", 2000);
				return Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("GraphLineMode", 0x02);
				return Convert.ToInt16(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("GraphQuality", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("CresPrioritize", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("GmdcExtension", ".obj");
				string s = o.ToString();
				return s.Replace("*", "");
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("CorrectJointDefinitionOnExport", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("DeepSimScan", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("DeepSimTemplateScan", false);
				return Convert.ToBoolean(o) && DeepSimScan;
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowProgressWhenPackageLoads", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("AsynchronLoad", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("AsynchronSort", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ResoruceTreeAllwaysAutoselect", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("SortProcessCount", 16);
				return Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("UpdateResourceListWhenTGIChanges", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("LockDocks", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("allowlotzero", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue(
					"ResourceListFormat",
					(int)ResourceListFormats.JustNames
				);
				return (ResourceListFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue(
					"ResourceListUnknownDescriptionFormat",
					(int)ResourceListUnnamedFormats.GroupInstance
				);
				return (ResourceListUnnamedFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue(
					"ResourceListInstanceFormat",
					(int)ResourceListInstanceFormats.HexDec
				);
				return (ResourceListInstanceFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue(
					"ResourceListExtensionFormat",
					(int)ResourceListExtensionFormats.Short
				);
				return (ResourceListExtensionFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ReportFormat", (int)ReportFormats.Descriptive);
				return (ReportFormats)Convert.ToInt32(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
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
			XmlRegistryKey rkf = xrk.CreateSubKey("Priorities");
			object o = rkf.GetValue(Helper.HexString(uid));
			if (o == null)
				return 0x00000000;
			else
				return Convert.ToInt32(o);
		}

		/// <summary>
		/// Stores the Priority of a Wrapper
		/// </summary>
		/// <param name="uid">uique id of the Wrapper</param>
		/// <param name="priority">the new Priority</param>
		public void SetWrapperPriority(ulong uid, int priority)
		{
			XmlRegistryKey rkf = xrk.CreateSubKey("Priorities");
			rkf.SetValue(Helper.HexString(uid), priority);
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
				return;
			if (filename.Trim() == "")
				return;
			if (!System.IO.File.Exists(filename))
				return;

			filename = filename.Trim();
			XmlRegistryKey rkf = mrk.CreateSubKey("Listings");

			Ambertation.CaseInvariantArrayList al = (Ambertation.CaseInvariantArrayList)
				rkf.GetValue("RecentFiles", new Ambertation.CaseInvariantArrayList());
			if (al.Contains(filename))
				al.Remove(filename);

			al.Insert(0, filename);
			while (al.Count > RECENT_COUNT)
				al.RemoveAt(al.Count - 1);
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
					return false;

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
							pline = pline.Replace("  ", " ");
						string[] tokens = pline.Split(" ".ToCharArray());

						if (tokens.Length == 3)
						{
							if (
								(tokens[0] == "boolprop")
								&& (tokens[1] == "testingcheatsenabled")
								&& (tokens[2] == "true")
							)
								return true;
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
					return;
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
								pline = pline.Replace("  ", " ");
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
											newcont += "true";
										else
											newcont += "false";
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
							newcont += "true";
						else
							newcont += "false";
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
			get
			{
				return PathProvider.Global.BlurNudity;
			}
			set
			{
				PathProvider.Global.BlurNudity = value;
			}
		}

		public void BlurNudityUpdate()
		{
			PathProvider.Global.BlurNudityUpdate();
		}
		#endregion
		/*
		#region Obsolete
		
		/// <summary>
		/// Returns the latest number of the Expansion used so far - seems not to be used ever
		/// </summary>
		public int PreviousEpCount
		{
			get
			{
				if (pep == -1) pep = this.GetPreviousEp();
				return pep;
			}
		}
		protected int EPCount
		{
			get
			{
				int cints = 0;
				string[] cinst = InstalledEPExecutables;
				if (cinst.Length == 0) return 0;
				foreach (string csi in cinst)
				{
					if (csi != "") cints += 1;
				}
				return cints;
			}
		}

		/// <summary>
		/// Returns the number of the EPs used, and writes the new Number to the Registry
		/// </summary>
		protected int GetPreviousEpCount()
		{
			RegistryKey rkf = rk.CreateSubKey("Settings");
			int res = Convert.ToInt32(rkf.GetValue("LastEPCount", this.EPCount));

			rkf.SetValue("LastEPCount", this.EPCount);
			return res;
		}
		/// <summary>
		/// Returns the number of the latest EP used, and writes the new Number to the Registry
		/// </summary>
		protected int GetPreviousEp()
		{
			RegistryKey rkf = rk.CreateSubKey("Settings");
			int res = Convert.ToInt32(rkf.GetValue("LatestEP", 0));

			//rkf.SetValue("LatestEP", PathProvider.Global.EPInstalled);
			rkf.SetValue("LatestEP", PathProvider.Global.GameVersion);
			return res;
		}
		
		private string scramble(string rey)
		{
			byte[] b = Helper.ToBytes(rey);
			return Helper.BytesToHexList(b);
		}

		private string descramble(string rey)
		{
			string ret = "";
			byte[] b = Helper.HexListToBytes(rey);
			foreach (byte f in b) ret += (char)f;
			return ret;
		}
		/// <summary>
		/// oboslete??? True, if you want to see items added to the resoruceList at once (ie. no BeginUpdate)
		/// </summary>
		private bool ShowResourceListContentAtOnce
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("ShowResourceListContentAtOnce", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("ShowResourceListContentAtOnce", value);
			}
		}

		/// <summary>
		/// true, if user wants to activate the Cache
		/// </summary>
		public  bool XPStyle
		{
			get
			{
				XmlRegistryKey  rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("XPStyle", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("XPStyle", value);
			}
		}
		/// <summary>
		/// true, if the user wanted to use the HexViewer
		/// </summary>
		public  bool HexViewState
		{
			get
			{
				XmlRegistryKey  rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("HexViewEnabled", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("HexViewEnabled", value);
			}
		}
		/// <summary>
		/// Obsolete, Since there is no updates will always get/set false
		/// </summary>
		public bool CheckForUpdates
		{
			get
			{
				return false;
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("CheckForUpdates", false);
			}
		}
		/// <summary>
		/// When did whe perform the last UpdateCheck? Obsolete always returns the default
		/// </summary>
		public DateTime LastUpdateCheck
		{
			get
			{
				XmlRegistryKey  rkf = xrk.CreateSubKey("Settings");
				object o = rkf.GetValue("LastUpdateCheck", DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0, 0)));
				return Convert.ToDateTime(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey("Settings");
				rkf.SetValue("LastUpdateCheck", value);
			}
		}
		public class ObsoleteWarning : Warning
		{
			internal ObsoleteWarning(string message, string detail) : base(message, detail) { }
		}

		protected static void WarnObsolete()
		{
			// if (Helper.DebugMode)
				throw new SimPe.Registry.ObsoleteWarning("This call is obsolete!", "The Call to this method is obsolete.\n\n Please use the matching version in SimPe.PathProvider.Global, or see http://www.modthesims2.com/index.php? for details.");
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string RealEP1GamePath
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global[Expansions.University].RealInstallFolder;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string RealEP2GamePath
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global[Expansions.Nightlife].RealInstallFolder;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string RealEP3GamePath
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global[Expansions.Business].RealInstallFolder;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string RealSP1GamePath
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global[Expansions.FamilyFun].RealInstallFolder;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string RealSP2GamePath
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global[Expansions.Glamour].RealInstallFolder;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public int InstalledVersions
		{
			get
			{
				WarnObsolete();
				int ret = EPInstalled;
				ret |= SPInstalled<<16;
				return ret;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public int GameVersion
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global.GameVersion;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public int EPInstalled
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global.EPInstalled;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public int SPInstalled
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global.SPInstalled;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public int STInstalled
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global.STInstalled;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string RealSavegamePath
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.RealSavegamePath;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string RealGamePath
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global[Expansions.BaseGame].RealInstallFolder;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string SimsPath
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global[Expansions.BaseGame].InstallFolder;
			}
			set
			{
				 WarnObsolete();
				SimPe.PathProvider.Global[Expansions.BaseGame].InstallFolder = value;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string NvidiaDDSTool
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global.NvidiaDDSTool;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string StartupCheatFile
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global.StartupCheatFile;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string NeighborhoodFolder
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global.NeighborhoodFolder;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string BackupFolder
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global.BackupFolder;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string NvidiaDDSPath
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global.NvidiaDDSPath;
			}
			set
			{
				WarnObsolete();
				PathProvider.Global.NvidiaDDSPath = value;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string SimsEP1Path
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global[Expansions.University].InstallFolder;
			}
			set
			{
				WarnObsolete();
				PathProvider.Global[Expansions.University].InstallFolder = value;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string SimsEP2Path
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global[Expansions.Nightlife].InstallFolder;
			}
			set
			{
				WarnObsolete();
				PathProvider.Global[Expansions.Nightlife].InstallFolder = value;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string SimsEP3Path
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global[Expansions.Business].InstallFolder;
			}
			set
			{
				WarnObsolete();
				PathProvider.Global[Expansions.Business].InstallFolder = value;
			}
		}
		/// <summary>
		///Obsolete !
		/// </summary>
		public string SimsSP1Path
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global[Expansions.FamilyFun].InstallFolder;
			}
			set
			{
				WarnObsolete();
				PathProvider.Global[Expansions.FamilyFun].InstallFolder = value;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string SimsSP2Path
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global[Expansions.Glamour].InstallFolder;
			}
			set
			{
				WarnObsolete();
				PathProvider.Global[Expansions.Glamour].InstallFolder = value;
			}
		}
		protected static int GetVersion(int index) {
			if ((index & 0xFFFF0000) == 0x00020000) return 5;
			if ((index & 0xFFFF0000) == 0x00010000) return 4;
			if ((index & 0x0000FFFF) == 0x00000003) return 3;
			if ((index & 0x0000FFFF) == 0x00000002) return 2;
			if ((index & 0x0000FFFF) == 0x00000001) return 1;
			return 0;
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public static string GetEpName(int index)
		{

			WarnObsolete();
			return PathProvider.Global[GetVersion(index)].Name;
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string CurrentEPName
		{
			get
			{
				WarnObsolete();
				return SimPe.PathProvider.Global.Latest.DisplayName;
			}
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public static string GetExecutableName(int index)
		{
			WarnObsolete();
			return PathProvider.Global[GetVersion(index)].ExeName;
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public string GetExecutableFolder(int index)
		{
			WarnObsolete();
			return PathProvider.Global[GetVersion(index)].InstallFolder;
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string SimsApplication
		{
			get
			{
				WarnObsolete();
				return PathProvider.Global.SimsApplication;
			}
			
		}
		/// <summary>
		/// Obsolete!
		/// </summary>
		public string SimSavegameFolder
		{
			get
			{
				WarnObsolete();
				return PathProvider.SimSavegameFolder;
			}
			set
			{
				WarnObsolete();
				PathProvider.SimSavegameFolder = value;
			}
		}
		#endregion
		 */
	}
}
