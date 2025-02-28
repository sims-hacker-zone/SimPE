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

			System.Windows.Forms.OpenFileDialog ofd =
				new System.Windows.Forms.OpenFileDialog
				{
					Filter = ExtensionProvider.BuildFilterString(
				new ExtensionType[]
				{
					ExtensionType.Sim2Pack,
					ExtensionType.AllFiles,
				}
			)
				};
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Packages.S2CPDescriptor[] ds =
					Packages.Sims2CommunityPack.ShowSimpleOpenDialog(
						ofd.FileName,
						System.Windows.Forms.SelectionMode.One
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
			return "Package Tool\\Open Sims2Pack...";
		}

		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => GetIcon.S2packOpen;

		public virtual bool Visible => true;

		#endregion
	}
}
