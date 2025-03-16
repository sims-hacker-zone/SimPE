// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Events;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Zusammenfassung für LoadSims2PackTool.
	/// </summary>
	public class LoadSims2PackTool : Interfaces.IToolPlus
	{
		internal LoadSims2PackTool()
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
			return "Package Tool\\Open Sims2Pack...";
		}

		#endregion

		#region IToolExt Member

		public System.Drawing.Image Icon => GetIcon.S2packOpen;

		public virtual bool Visible => true;

		#endregion
	}
}
