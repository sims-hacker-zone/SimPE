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

			System.Windows.Forms.OpenFileDialog ofd =
				new System.Windows.Forms.OpenFileDialog
				{
					Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.Sim2PackCommunity,
					ExtensionType.AllFiles,
				}
			)
				};
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Packages.S2CPDescriptor[] ds =
					Packages.Sims2CommunityPack.ShowOpenDialog(
						ofd.FileName,
						System.Windows.Forms.SelectionMode.MultiExtended
					);
				if (ds != null)
				{
					foreach (Packages.S2CPDescriptor d in ds)
					{
						RemoteControl.OpenMemoryPackage(d.Package);
					}
				}
			}
		}

		public override string ToString()
		{
			return "Package Tool\\Open s2cp...";
		}

		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => GetIcon.S2pcOpen;

		public virtual bool Visible => true;

		#endregion
	}
}
