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
	/// Zusammenfassung für ImportSemiTool.
	/// </summary>
	public class ScenegraphTool : AbstractTool, ITool
	{
		IWrapperRegistry reg;
		IProviderRegistry prov;
		ScenegraphForm sg;

		internal ScenegraphTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;

			sg = new ScenegraphForm();
		}

		#region ITool Member

		public bool IsEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			return (package != null);
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			Interfaces.Files.IPackedFileDescriptor opfd = pfd;
			sg.Execute(prov, package, ref pfd);

			if ((pfd == null) && (opfd == null))
			{
				return new ToolResult(false, false);
			}

			if ((pfd != null) && (opfd == null))
			{
				return new ToolResult(true, false);
			}

			return new ToolResult(!pfd.Equals(opfd), false);
		}

		public override string ToString()
		{
			return "Object Tool\\Scenegrapher...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream(
							"SimPe.img.scenegrapher.png"
						)
				);

		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlG;
		#endregion
	}
}
