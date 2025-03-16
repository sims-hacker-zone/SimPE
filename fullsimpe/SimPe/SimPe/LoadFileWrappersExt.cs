// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

using SimPe.Interfaces;

namespace SimPe
{
	/// <summary>
	/// Class that can be used to Load external Filewrappers int the given Registry
	/// </summary>
	public class LoadFileWrappersExt : LoadFileWrappers
	{
		/// <summary>
		/// Constructor of The class
		/// </summary>
		/// <param name="registry">
		/// Registry the External Data should be added to
		/// </param>
		/// <param name="toolreg">Registry the tools should be added to</param>
		public LoadFileWrappersExt()
			: base(FileTableBase.WrapperRegistry, FileTable.ToolRegistry) { }

		static ArrayList exclude;

		static void CreateExcludeList()
		{
			exclude = new ArrayList();
		}

		static LoadFileWrappersExt()
		{
			CreateExcludeList();
		}

		/// <summary>
		/// Link all Listeners with the GUI Control
		/// </summary>
		/// <param name="ev"></param>
		public void AddListeners(ref Events.ChangedResourceEvent ev)
		{
			//load Listeners
			foreach (IListener item in FileTable.ToolRegistry.Listeners)
			{
				ev += new Events.ChangedResourceEvent(
					item.SelectionChangedHandler
				);
				item.SelectionChangedHandler(
					item,
					new Events.ResourceEventArgs(null)
				);
			}
		}
	}
}
