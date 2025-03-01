// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.ComponentModel;
using System.Resources;

namespace pj
{
	class Settings : SimPe.GlobalizedObject
	{
		const string BASENAME = "PJSE\\BMtool";
		SimPe.XmlRegistryKey xrk = SimPe.Helper.WindowsRegistry.PluginRegistryKey;
		SimPe.XmlRegistryKey rkf =
			SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(BASENAME);

		public Settings()
			: base(new ResourceManager(typeof(Settings))) { }

		private static Settings settings = new Settings();

		[Category("PJSE")]
		public static bool BodyMeshExtractUseCres
		{
			get
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				object o = rkf.GetValue("meshexttractusecres", false);
				return Convert.ToBoolean(o);
			}
			set
			{
				SimPe.XmlRegistryKey rkf =
					SimPe.Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(
						BASENAME
					);
				rkf.SetValue("meshexttractusecres", value);
			}
		}
	}
}
