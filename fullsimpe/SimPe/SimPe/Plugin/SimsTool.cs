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
	public class SimsTool : AbstractTool, ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;

		internal SimsTool(IWrapperRegistry reg, IProviderRegistry prov)
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
			return (
				Helper.IsNeighborhoodFile(package?.FileName)
				|| Helper.IsLotCatalogFile(package?.FileName)
			);
		}

		private bool IsReallyEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			if (package == null)
			{
				return false;
			}

			if (prov.SimNameProvider == null)
			{
				return false;
			}

			return (
				Helper.IsNeighborhoodFile(package.FileName)
				|| Helper.IsLotCatalogFile(package.FileName)
			);
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			if (!IsReallyEnabled(pfd, package))
			{
				System.Windows.Forms.MessageBox.Show(
					Localization.GetString(
						"This is not an appropriate context in which to use this tool"
					),
					Localization.Manager.GetString("simsbrowser")
				);
				return new ToolResult(false, false);
			}
			Sims sims = new Sims
			{
				Text = Localization.Manager.GetString("simsbrowser")
			};

			return sims.Execute(ref pfd, ref package, prov);
		}

		public override string ToString()
		{
			return "Neighbourhood\\"
				+ Localization.Manager.GetString("simsbrowser")
				+ "...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.SimBrowser;
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlShiftS;
		#endregion
	}
}
