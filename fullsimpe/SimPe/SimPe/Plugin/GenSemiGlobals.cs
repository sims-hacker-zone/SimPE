// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Interfaces;

namespace SimPe.Plugin
{
	class GenSemiGlobals : ICommandLine
	{
		#region ICommandLine Members

		public bool Parse(List<string> argv)
		{
			if (!argv.Remove("-gensemiglob"))
			{
				return false;
			}

			List<uint> added =
				new List<uint>();
			Splash.Screen.SetMessage("Loading FileTable...");
			FileTableBase.FileIndex.Load();
			Splash.Screen.SetMessage("Looking for GLOB Resources...");
			Interfaces.Scenegraph.IScenegraphFileIndexItem[] resources =
				FileTableBase.FileIndex.FindFile(Data.MetaData.GLOB_FILE, true);

			Splash.Screen.SetMessage("Found " + resources.Length + " GLOB Resources");
			string fl = Helper.SimPeSemiGlobalFile;
			//            Console.WriteLine("Opening " + fl);
			System.IO.StreamWriter sw = new System.IO.StreamWriter(fl, false);
			sw.WriteLine("<semiglobals>");

			int ct = 0;
			int unq = 0;
			foreach (
				Interfaces.Scenegraph.IScenegraphFileIndexItem item in resources
			)
			{
				if (ct % 23 == 0)
				{
					Splash.Screen.SetMessage(
						"Wrote " + ct + " (" + unq + " unique) entries"
					);
				}

				ct++;

				Glob glb = new Glob();
				glb.ProcessData(item);

				if (!added.Contains(glb.SemiGlobalGroup))
				{
					sw.WriteLine("  <semiglobal>");
					sw.WriteLine("    <known />");
					sw.WriteLine(
						"    <group>"
							+ Helper.HexString(glb.SemiGlobalGroup)
							+ "</group>"
					);
					sw.WriteLine("    <name>" + glb.SemiGlobalName + "</name>");
					sw.WriteLine("  </semiglobal>");
					added.Add(glb.SemiGlobalGroup);
					unq++;
				}
			}
			//            Console.WriteLine("Wrote " + ct + " (" + unq + " unique) entries");
			sw.WriteLine("</semiglobals>");
			//            Console.WriteLine("Finished writing to " + fl);
			sw.Close();
			sw.Dispose();
			sw = null;
			//            Console.WriteLine("Closed File");
			Splash.Screen.SetMessage("");

			return true;
		}

		public string[] Help()
		{
			return new string[] { "-gensemiglob", null };
		}

		#endregion
	}
}
