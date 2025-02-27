/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class NeighborhoodTool : Interfaces.AbstractTool, Interfaces.ITool
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
			SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			SimPe.Interfaces.Files.IPackageFile package
		)
		{
			return true;
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			ref SimPe.Interfaces.Files.IPackageFile package
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
						return new Plugin.ToolResult(false, false);
					}
				}
			}
			NeighborhoodForm nf = new NeighborhoodForm();
			nf.Text = Localization.Manager.GetString("neighborhoodbrowser");

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
		public override System.Drawing.Image Icon => SimPe.GetIcon.tbNeighboorhood;
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlShiftN;
		#endregion
	}
}
