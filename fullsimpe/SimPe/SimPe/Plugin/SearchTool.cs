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
	public class SearchTool : AbstractTool, ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;
		Search sc;
		string flname;

		internal SearchTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;
			sc = new Search
			{
				prov = prov
			};
			flname = "";
		}

		#region ITool Member

		public bool IsEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			return package != null && package.FileName != null;
		}

		private bool IsReallyEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			if (package == null || package.FileName == null)
			{
				return false;
			}

			if (flname.ToLower().Trim() != package.FileName.ToLower().Trim())
			{
				sc.Reset();
			}

			flname = package.FileName;
			return true;
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
					ToString()
				);
				return new ToolResult(false, false);
			}
			if (flname.ToLower().Trim() != package.FileName.ToLower().Trim())
			{
				sc.Reset();
			}

			Interfaces.Files.IPackedFileDescriptor selpfd = sc.Execute(package);

			if (selpfd != null)
			{
				pfd = selpfd;
				return new ToolResult(true, false);
			}
			else
			{
				return new ToolResult(false, false);
			}
		}

		public override string ToString()
		{
			return Localization.GetString("Search Current File...");
		}

		#endregion
		#region IToolExt Member
		public override System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.search.png")
				);
		#endregion
	}
}
