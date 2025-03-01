// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Resources;

using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace SimPe.Custom
{
	public class Settings : GlobalizedObject, ISettings
	{
		static ResourceManager rm = new ResourceManager(typeof(Localization));

		private static Settings settings;

		static Settings()
		{
			settings = new Settings();
		}

		public static bool Persistent => settings.KeepFilesOpen;

		public Settings()
			: base(rm) { }

		const string BASENAME = "Settings";
		XmlRegistryKey xrk = Helper.WindowsRegistry.RegistryKey;

		[System.ComponentModel.Category("SimPE")]
		public bool KeepFilesOpen
		{
			get
			{
				XmlRegistryKey rkf = xrk.CreateSubKey(BASENAME);
				object o = rkf.GetValue("keepFilesOpen", true);
				return Convert.ToBoolean(o);
			}
			set
			{
				XmlRegistryKey rkf = xrk.CreateSubKey(BASENAME);
				rkf.SetValue("keepFilesOpen", value);
			}
		}

		#region ISettings Members

		public override string ToString()
		{
			return "SimPE";
		}

		[System.ComponentModel.Browsable(false)]
		public System.Drawing.Image Icon => null;

		object ISettings.GetSettingsObject()
		{
			return this;
		}

		#endregion
	}

	public class SettingsFactory : AbstractWrapperFactory, ISettingsFactory
	{
		#region ISettingsFactory Members

		public ISettings[] KnownSettings => new ISettings[] { new Settings() };

		#endregion
	}
}
