// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;

namespace SimPe.Plugin.Tool.Dockable.Finder
{
	public sealed class FinderToolRegistry
	{
		static FinderToolRegistry glb = null;
		public static FinderToolRegistry Global
		{
			get
			{
				if (glb == null)
				{
					glb = new FinderToolRegistry();
				}

				return glb;
			}
		}

		List<Type> list;

		private FinderToolRegistry()
		{
			list = new List<Type>();
			map =
				new Dictionary<
					Interfaces.IFinderResultGui,
					Interfaces.AFinderTool[]
				>();

			Add(typeof(FindObj));
			Add(typeof(FindInNmap));
			Add(typeof(FindInStr));
			Add(typeof(FindInCpf));
			Add(typeof(FindTGI));
			Add(typeof(FindInNref));
			Add(typeof(FindInSG));
		}

		public void Add(Type tool)
		{
			list.Add(tool);
		}

		Dictionary<
			Interfaces.IFinderResultGui,
			Interfaces.AFinderTool[]
		> map;

		public Interfaces.AFinderTool[] CreateToolInstances(
			Interfaces.IFinderResultGui gui
		)
		{
			if (map.ContainsKey(gui))
			{
				return map[gui];
			}

			Interfaces.AFinderTool[] ret = new Interfaces.AFinderTool[
				list.Count
			];
			for (int i = 0; i < list.Count; i++)
			{
				ret[i] =
					Activator.CreateInstance(list[i], new object[] { gui })
					as Interfaces.AFinderTool;
			}

			map[gui] = ret;
			return ret;
		}
	}
}
