// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Events;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Summary description for LoadSims2PackTool.
	/// </summary>
	public class Loads2cpTool : Interfaces.IToolPlus
	{
		internal Loads2cpTool()
		{
		}

		#region ITool Member

		public bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e)
		{
			return true;
		}

		public void Execute(object sender, ResourceEventArgs es)
		{
			if (!ChangeEnabledStateEventHandler(sender, es))
			{
				return;
			}
		}

		public override string ToString()
		{
			return "Package Tool\\Open s2cp...";
		}

		#endregion

		#region IToolExt Member

		public System.Drawing.Image Icon => GetIcon.S2pcOpen;

		public virtual bool Visible => true;

		#endregion
	}
}
