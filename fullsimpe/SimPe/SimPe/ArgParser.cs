// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

namespace SimPe
{
	public class ArgParser
	{
		public static bool Parse(
			List<string> argv,
			int index,
			string parm,
			ref string result
		)
		{
			int i = argv.IndexOf(parm);
			if (i == index && argv.Count > i + 1)
			{
				argv.RemoveAt(i);
				result = argv[i];
				argv.RemoveAt(i);
				return true;
			}
			return false;
		}

		public static int Parse(List<string> argv, int index, List<string> parm)
		{
			if (argv.Count <= index)
			{
				return -1;
			}

			int i = parm.IndexOf(argv[index]);
			if (i >= 0)
			{
				argv.RemoveAt(index);
			}

			return i;
		}

		public static int Parse(List<string> argv, string parm)
		{
			int i = argv.IndexOf(parm);
			if (i >= 0)
			{
				argv.RemoveAt(i);
			}

			return i;
		}
	}
}
