// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SimPe.Forms.MainUI;
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Glob;

namespace SimPe.Plugin
{
	class GenSemiGlobals : ICommandLine
	{
		#region ICommandLine Members

		public async Task<bool> Parse(List<string> argv)
		{
			if (!argv.Remove("-gensemiglob"))
			{
				return false;
			}

			await Message.Show("bla");

			List<uint> added =
				new List<uint>();
			FileTableBase.FileIndex.Load();
			IEnumerable<Interfaces.Scenegraph.IScenegraphFileIndexItem> resources =
				FileTableBase.FileIndex.FindFile(Data.FileTypes.GLOB, true);
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
				}

				ct++;

				Glob glb = new Glob().ProcessFile(item);

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

			return true;
		}

		public string[] Help()
		{
			return new string[] { "-gensemiglob", null };
		}

		#endregion
	}
}
