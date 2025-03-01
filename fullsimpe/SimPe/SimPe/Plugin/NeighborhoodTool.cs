// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class NeighborhoodTool : AbstractTool, ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;

		internal NeighborhoodTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;
		}

		#region ITool Member

		public bool IsEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			return true;
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			if (
				PathProvider
					.Global.GetSaveGamePathForGroup(PathProvider.Global.CurrentGroup)
					.Count > 0
			)
			{
				if (
					!System.IO.Directory.Exists(
						PathProvider.Global.GetSaveGamePathForGroup(
							PathProvider.Global.CurrentGroup
						)[0]
					)
				)
				{
					System.Windows.Forms.MessageBox.Show(
						"The Folder "
							+ PathProvider.Global.GetSaveGamePathForGroup(
								PathProvider.Global.CurrentGroup
							)[0]
							+ " was not found.\nPlease specify the correct SaveGame Folder in the Options Dialog."
					);
					return new ToolResult(false, false);
				}
			}
			else
			{
				System.Windows.Forms.MessageBox.Show(
					"Neighbourhood Folder was not found.\nPlease specify the correct SaveGame Folder in the Options Dialog."
				);
				return new ToolResult(false, false);
			}

			if (package != null)
			{
				if (package.HasUserChanges)
				{
					if (
						System.Windows.Forms.MessageBox.Show(
							Localization.Manager.GetString("unsavedchanges"),
							Localization.Manager.GetString("savechanges?"),
							System.Windows.Forms.MessageBoxButtons.YesNo
						) == System.Windows.Forms.DialogResult.No
					)
					{
						return new ToolResult(false, false);
					}
				}
			}
			NeighborhoodForm nf = new NeighborhoodForm
			{
				Text = Localization.Manager.GetString("neighborhoodbrowser")
			};

			Interfaces.Plugin.IToolResult ret = nf.Execute(ref package, prov);
			if (ret.ChangedPackage)
			{
				pfd = null;
			}

			return ret;
		}

		public override string ToString()
		{
			return "Neighbourhood\\"
				+ Localization.Manager.GetString("neighborhoodbrowser")
				+ "...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.tbNeighboorhood;
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlShiftN;
		#endregion
	}
}
