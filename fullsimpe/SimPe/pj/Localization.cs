// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Resources;

namespace pj
{
	public class L
	{
		private static ResourceManager resource = null;

		static L()
		{
			resource = new ResourceManager(typeof(L));
		}

		public static string Get(string name)
		{
			return resource.GetString(name)
#if DEBUG
			?? "<<" + name + ">>";
#else
			?? name;
#endif
		}
	}
}
