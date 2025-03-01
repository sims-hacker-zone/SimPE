// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Events;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Summary description for Saves2cpTool.
	/// </summary>
	public class Saves2cpTool : Interfaces.IToolPlus
	{
		internal Saves2cpTool()
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

			if (es.Loaded)
			{
				Packages.Sims2CommunityPack.ShowSaveDialog(
					new Packages.GeneratableFile[] { es.LoadedPackage.Package },
					true
				);
			}
			else
			{
				Packages.Sims2CommunityPack.ShowSaveDialog(
					new Packages.GeneratableFile[0],
					true
				);
			}
		}

		public override string ToString()
		{
			return "Package Tool\\Create s2cp...";
		}

		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => GetIcon.S2pc;

		public virtual bool Visible => true;

		#endregion
	}
}
