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
	public class WorkshopTool : Interfaces.AbstractTool, Interfaces.ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;
		Workshop ws;

		internal WorkshopTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;

			ws = new Workshop();
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
			if (Helper.StartedGui == Executable.Default)
			{
				if (
					Message.Show(
						SimPe.Localization.GetString("ObsoleteOW"),
						SimPe.Localization.GetString("Warning"),
						System.Windows.Forms.MessageBoxButtons.YesNo
					) == System.Windows.Forms.DialogResult.No
				)
				{
					return new ToolResult(false, false);
				}
			}

			SimPe.Interfaces.Files.IPackageFile pkg = ws.Execute(prov, package);

			if (pkg != null)
			{
				if (pkg.Reader != null)
				{
					if (!pkg.Reader.BaseStream.CanWrite)
					{
						new ToolResult(false, false);
					}
				}

				package = pkg;
				return new ToolResult(false, true);
			}
			else
			{
				return new ToolResult(false, false);
			}
		}

		public override string ToString()
		{
			if (Helper.StartedGui == Executable.Default)
			{
				return "Object Creation\\Windowed Object Workshop...";
			}
			else
			{
				return "Object Creation\\Object Workshop...";
			}
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => SimPe.GetIcon.CreatePackageW;
		public override System.Windows.Forms.Shortcut Shortcut
		{
			get
			{
				if (Helper.StartedGui == Executable.Default)
				{
					return System.Windows.Forms.Shortcut.None;
				}
				else
				{
					return System.Windows.Forms.Shortcut.CtrlW;
				}
			}
		}
		#endregion
	}
}
