// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Resources;

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// The Preferences for the Content Plugin
	/// </summary>
	public class DownloadsSettings : GlobalizedObject, Interfaces.ISettings
	{
		static ResourceManager rm = new ResourceManager(typeof(DownloadsSettings));
		const string BASENAME = "DownloadsPlugin";
		Dictionary<string, string> settings;

		public DownloadsSettings()
			: base(rm)
		{
			if (!Helper.WindowsRegistry.Config.PluginSettings.ContainsKey(BASENAME))
			{
				Helper.WindowsRegistry.Config.PluginSettings[BASENAME] = new Dictionary<string, string>();
			}
			settings = Helper.WindowsRegistry.Config.PluginSettings[BASENAME];
		}

		[System.ComponentModel.Category("Other")]
		public bool BuildPreviewForObjects
		{
			get
			{
				if (!settings.ContainsKey("BuildPreviewForObjects"))
				{
					settings["BuildPreviewForObjects"] = true.ToString();
				}
				return bool.Parse(settings["BuildPreviewForObjects"]);
			}
			set => settings["BuildPreviewForObjects"] = value.ToString();
		}

		[System.ComponentModel.Category("Recolors")]
		public bool BuildPreviewForRecolors
		{
			get
			{
				if (!settings.ContainsKey("BuildPreviewForRecolors"))
				{
					settings["BuildPreviewForRecolors"] = true.ToString();
				}
				return bool.Parse(settings["BuildPreviewForRecolors"]);
			}
			set
			{
				settings["BuildPreviewForRecolors"] = value.ToString();
				if (value)
				{
					LoadBasedataForRecolors = true;
				}
			}
		}

		[System.ComponentModel.Category("Recolors")]
		public bool LoadBasedataForRecolors
		{
			get
			{
				if (!settings.ContainsKey("LoadBasedataForRecolors"))
				{
					settings["LoadBasedataForRecolors"] = true.ToString();
				}
				return bool.Parse(settings["LoadBasedataForRecolors"]);
			}
			set
			{
				settings["LoadBasedataForRecolors"] = value.ToString();
				if (!value)
				{
					BuildPreviewForRecolors = false;
				}
			}
		}

		#region ISettings Member

		public object GetSettingsObject()
		{
			return this;
		}

		public override string ToString()
		{
			return rm.GetString("Content Plugin Preferences");
		}

		[System.ComponentModel.Browsable(false)]
		public System.Drawing.Image Icon =>
				// TODO:  No Image available
				null;
		#endregion
	}
}
