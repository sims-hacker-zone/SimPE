// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe
{
	/// <summary>
	/// Summary description for ActionToolDescriptor.
	/// </summary>
	internal class ActionToolDescriptor
	{
		Interfaces.IToolAction tool;
		LoadedPackage lp;

		Events.ResourceEventArgs lasteventarg;

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="tool"></param>
		public ActionToolDescriptor(Interfaces.IToolAction tool)
		{
			//this.lp = lp;
			this.tool = tool;

			if (tool.Icon != null)
			{
			}

			//Make Sure the Action is disabled on StartUp
			ChangeEnabledStateEventHandler(
				null,
				new Events.ResourceEventArgs(lp)
			);
		}

		/// <summary>
		/// Fired when a Resource was changed by a ToolPlugin and the Enabled state needs to be changed
		/// </summary>
		public void ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			lp = e.LoadedPackage;

			lasteventarg = e;
		}
	}
}
