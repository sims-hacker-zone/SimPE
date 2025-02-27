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
using System;

using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class SurgeryTool : Interfaces.AbstractTool, Interfaces.ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;

		internal SurgeryTool(IWrapperRegistry reg, IProviderRegistry prov)
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
			return (
				Helper.IsNeighborhoodFile(package?.FileName)
				|| Helper.IsLotCatalogFile(package?.FileName)
			);
		}

		private bool IsReallyEnabled(
			SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			SimPe.Interfaces.Files.IPackageFile package
		)
		{
			if (package == null)
				return false;
			if (prov.SimNameProvider == null)
				return false;
			return (
				Helper.IsNeighborhoodFile(package.FileName)
				|| Helper.IsLotCatalogFile(package.FileName)
			);
		}

		Surgery surg;

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			ref SimPe.Interfaces.Files.IPackageFile package
		)
		{
			if (!IsReallyEnabled(pfd, package))
			{
				System.Windows.Forms.MessageBox.Show(
					SimPe.Localization.GetString(
						"This is not an appropriate context in which to use this tool"
					),
					Localization.Manager.GetString("Sims Surgery Tool")
				);
				return new Plugin.ToolResult(false, false);
			}
			if (surg == null)
				surg = new Surgery();
			surg.Text = Localization.Manager.GetString("Sims Surgery Tool");

			return surg.Execute(ref pfd, ref package, prov);
		}

		public override string ToString()
		{
			return "Neighbourhood\\Sims Surgery...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => SimPe.GetIcon.SimSurgery;
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;
		#endregion
	}
}
