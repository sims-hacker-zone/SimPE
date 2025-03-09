// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace SimPe.Wants
{
	internal class Settings : GlobalizedObject
	{
		private readonly Dictionary<string, string> options;
		private const string BASENAME = "PJSE\\Wants";

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

		public IEnumerable<int> SWAFColumns
		{
			get
			{
				if (!options.ContainsKey("SWAFColumns"))
				{
					options["SWAFColumns"] = null;
				}
				return options["SWAFColumns"] == null
					? null
					: (from col in options["SWAFColumns"].Split(new char[] { ',' })
					   select int.Parse(col));
			}
			set => options["SWAFColumns"] = string.Join(",", value);
		}

		public IEnumerable<bool> SWAFItemTypes
		{
			get
			{
				if (!options.ContainsKey("SWAFItemTypes"))
				{
					options["SWAFItemTypes"] = "true,true,true,true,true";
				}
				return options["SWAFItemTypes"] == null
					? null
					: (from col in options["SWAFItemTypes"].Split(new char[] { ',' })
					   select bool.Parse(col));
			}
			set => options["SWAFColumns"] = string.Join(",", value);
		}

		public int SWAFSplitterDistance
		{
			get
			{
				if (!options.ContainsKey("SWAFSplitterDistance"))
				{
					options["SWAFSplitterDistance"] = (-1).ToString();
				}
				return int.Parse(options["SWAFSplitterDistance"]);
			}
			set => options["SWAFSplitterDistance"] = value.ToString();
		}

		public int SWAFSortColumn
		{
			get
			{
				if (!options.ContainsKey("SWAFSortColumn"))
				{
					options["SWAFSortColumn"] = 2.ToString();
				}
				return int.Parse(options["SWAFSortColumn"]);
			}
			set => options["SWAFSortColumn"] = value.ToString();
		}
	}
}
