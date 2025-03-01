// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Events;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Zusammenfassung für SaveSims2PackTool.
	/// </summary>
	public class SaveSims2PackTool : Interfaces.IToolPlus
	{
		internal SaveSims2PackTool()
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
				Packages.Sims2CommunityPack.ShowSimpleSaveDialog(
					new Packages.GeneratableFile[] { es.LoadedPackage.Package }
				);
			}
			else
			{
				Packages.Sims2CommunityPack.ShowSimpleSaveDialog(
					new Packages.GeneratableFile[0]
				);
			}
		}

		public override string ToString()
		{
			return "Package Tool\\Create Sims2Pack...";
		}

		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => GetIcon.S2pack;

		public virtual bool Visible => true;

		#endregion
	}
}
