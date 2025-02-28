// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
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
		XmlRegistryKey xrk;

		public DownloadsSettings()
			: base(rm)
		{
			xrk = Helper.WindowsRegistry.PluginRegistryKey;
		}

		[System.ComponentModel.Category("Other")]
		public bool BuildPreviewForObjects
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey(BASENAME);
				object o = rkf.GetValue("BuildPreviewForObjects", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey(BASENAME);
				rkf.SetValue("BuildPreviewForObjects", value);
			}
		}

		[System.ComponentModel.Category("Recolors")]
		public bool BuildPreviewForRecolors
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey(BASENAME);
				object o = rkf.GetValue("BuildPreviewForRecolors", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey(BASENAME);
				rkf.SetValue("BuildPreviewForRecolors", value);

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
				XmlRegistryKey rkf = xrk.CreateSubKey(BASENAME);
				object o = rkf.GetValue("LoadBasedataForRecolors", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey(BASENAME);
				rkf.SetValue("LoadBasedataForRecolors", value);

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
