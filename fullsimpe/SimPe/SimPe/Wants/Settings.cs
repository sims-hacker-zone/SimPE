// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Resources;

namespace SimPe.Wants
{
	class Settings : GlobalizedObject
	{
		const string BASENAME = "PJSE\\Wants";
		XmlRegistryKey xrk = Helper.WindowsRegistry.PluginRegistryKey;
		XmlRegistryKey rkf =
			Helper.WindowsRegistry.PluginRegistryKey.CreateSubKey(BASENAME);

		public Settings()
			: base(new ResourceManager(typeof(Settings))) { }

		private static Settings settings = new Settings();

		public static int[] SWAFColumns
		{
			get
			{
				object o = settings.rkf.GetValue("SWAFColumns", null);
				if (o == null || o as string == null)
				{
					return null;
				}

				try
				{
					string[] cols = ((string)o).Split(new char[] { ',' }, 11);
					if (cols.Length != 11)
					{
						return null;
					}

					List<int> li = new List<int>();
					foreach (string s in cols)
					{
						li.Add(Convert.ToInt32(s));
					}

					return li.ToArray();
				}
				catch
				{
					return null;
				}
			}
			set
			{
				if (value.Length != 11)
				{
					throw new ArgumentOutOfRangeException();
				}

				bool nc = true;
				int[] old = SWAFColumns;
				if (old == null)
				{
					nc = false;
				}
				else
				{
					for (int i = 0; i < value.Length && nc; i++)
					{
						nc = value[i] == old[i];
					}
				}

				if (nc)
				{
					return;
				}

				string s = value[0].ToString();
				for (int i = 1; i < value.Length; i++)
				{
					s += "," + value[i].ToString();
				}

				settings.rkf.SetValue("SWAFColumns", s);
			}
		}

		public static bool[] SWAFItemTypes
		{
			get
			{
				bool[] def = new bool[] { true, true, true, true };
				object o = settings.rkf.GetValue("SWAFItemTypes", null);
				if (o == null || o as string == null)
				{
					return def;
				}

				try
				{
					string[] ckbs = ((string)o).Split(new char[] { ',' }, 4);
					if (ckbs.Length != 4)
					{
						return def;
					}

					List<bool> li = new List<bool>();
					foreach (string s in ckbs)
					{
						li.Add(Convert.ToBoolean(s));
					}

					return li.ToArray();
				}
				catch
				{
					return def;
				}
			}
			set
			{
				if (value.Length != 4)
				{
					throw new ArgumentOutOfRangeException();
				}

				bool nc = true;
				bool[] old = SWAFItemTypes;
				if (old == null)
				{
					nc = false;
				}
				else
				{
					for (int i = 0; i < value.Length && nc; i++)
					{
						nc = value[i] == old[i];
					}
				}

				if (nc)
				{
					return;
				}

				string s = value[0].ToString();
				for (int i = 1; i < value.Length; i++)
				{
					s += "," + value[i].ToString();
				}

				settings.rkf.SetValue("SWAFItemTypes", s);
			}
		}

		public static int SWAFSplitterDistance
		{
			get
			{
				try
				{
					return (int)settings.rkf.GetValue("SWAFSplitterDistance", -1);
				}
				catch
				{
					return -1;
				}
			}
			set => settings.rkf.SetValue("SWAFSplitterDistance", value);
		}

		public static int SWAFSortColumn
		{
			get
			{
				try
				{
					return (int)settings.rkf.GetValue("SWAFSortColumn", 2);
				}
				catch
				{
					return 2;
				}
			}
			set => settings.rkf.SetValue("SWAFSortColumn", value);
		}
	}
}
