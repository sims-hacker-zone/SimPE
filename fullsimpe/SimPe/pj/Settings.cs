// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;

using SimPe;

namespace pj
{
	internal class Settings : GlobalizedObject
	{
		private readonly Dictionary<string, string> options;
		private const string BASENAME = "PJSE\\BMtool";

		public Settings()
			: base(new ResourceManager(typeof(Settings)))
		{
			if (!Helper.WindowsRegistry.Config.PluginSettings.ContainsKey(BASENAME))
			{
				Helper.WindowsRegistry.Config.PluginSettings[BASENAME] = new Dictionary<string, string>();
			}
			options = Helper.WindowsRegistry.Config.PluginSettings[BASENAME];
		}

		public static Settings Options = new Settings();

		[Category("PJSE")]
		public bool BodyMeshExtractUseCres
		{
			get
			{
				if (!options.ContainsKey("BodyMeshExtractUseCres"))
				{
					options["BodyMeshExtractUseCres"] = false.ToString();
				}
				return bool.Parse(options["BodyMeshExtractUseCres"]);
			}
			set => options["BodyMeshExtractUseCres"] = value.ToString();
		}
	}
}
