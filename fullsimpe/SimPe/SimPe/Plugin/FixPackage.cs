// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Interfaces;

namespace SimPe.Plugin
{
	public class FixPackage : ICommandLine
	{
		#region ICommandLine Members

		public bool Parse(List<string> argv)
		{
			int i = ArgParser.Parse(argv, "-fix");
			if (i < 0)
			{
				return false;
			}

			string modelname = "";
			string prefix = "";
			string package = "";
			string vertxt = "";
			FixVersion ver = FixVersion.UniversityReady;

			while (argv.Count > i)
			{
				if (ArgParser.Parse(argv, i, "-package", ref package))
				{
					continue;
				}

				if (ArgParser.Parse(argv, i, "-modelname", ref modelname))
				{
					continue;
				}

				if (ArgParser.Parse(argv, i, "-prefix", ref prefix))
				{
					continue;
				}

				if (ArgParser.Parse(argv, i, "-fixversion", ref vertxt))
				{
					switch (vertxt.Trim().ToLower())
					{
						case "uni1":
							ver = FixVersion.UniversityReady;
							break;
						case "uni2":
							ver = FixVersion.UniversityReady2;
							break;
					}
					continue;
				}
				Message.Show(Help()[0]);
				return true;
			}

			Fix(package, prefix + modelname, ver);
			return true;
		}

		public string[] Help()
		{
			return new string[]
			{
				"-fix -package <pkg> -modelname <mdl> -prefix <pfx> -fixversion uni1|uni2",
				null,
			};
		}

		#endregion


		public static void Fix(string package, string modelname, FixVersion ver)
		{
			if (System.IO.File.Exists(package))
			{
				Packages.GeneratableFile pkg =
					Packages.File.LoadFromFile(package);

				System.Collections.Hashtable map = RenameForm.GetNames(
					modelname.Trim() != "",
					pkg,
					null,
					modelname
				);
				FixObject fo = new FixObject(pkg, ver, false);
				fo.Fix(map, false);
				fo.CleanUp();
				fo.FixGroup();

				pkg.Save();
			}
		}
	}
}
