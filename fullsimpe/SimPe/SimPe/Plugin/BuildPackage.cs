// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;
using System.Threading.Tasks;

using SimPe.Forms.MainUI;
using SimPe.Interfaces;
using SimPe.Packages;

namespace SimPe.Plugin
{
	class BuildPackage : ICommandLine
	{
		#region ICommandLine Members
		public async Task<bool> Parse(List<string> argv)
		{
			int i = ArgParser.Parse(argv, "-build");
			if (i < 0)
			{
				return false;
			}

			string output = "";
			string input = "";

			while (argv.Count - i > 0 && input.Length == 0 && output.Length == 0)
			{
				if (ArgParser.Parse(argv, i, "-desc", ref input))
				{
					continue;
				}

				if (ArgParser.Parse(argv, i, "-out", ref output))
				{
					continue;
				}

				await Message.Show(Help()[0]);
				return true;
			}

			if (input.Length == 0 || output.Length == 0)
			{
				Message.Show(Help()[0]);
				return true;
			}
			if (!System.IO.File.Exists(input))
			{
				Message.Show(Help()[0]);
				return true;
			}

			GeneratableFile pkg = File.LoadFromStream(
				XmlPackageReader.OpenExtractedPackage(input)
			);
			pkg.Save(output);
			return true;
		}

		public string[] Help()
		{
			return new string[] { "-build -desc <input> -out <output>", "" };
		}
		#endregion
	}
}
