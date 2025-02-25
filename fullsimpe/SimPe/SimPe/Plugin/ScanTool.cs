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
	internal class ScanerTool : Interfaces.AbstractTool, Interfaces.ITool
	{
		static ScannerForm ds;

		internal ScanerTool() { }

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
			if (ds == null)
				ds = new ScannerForm();
			RemoteControl.ShowSubForm(ds);

			if (ds.FileName == null)
				return new ToolResult(false, false);
			else
			{
				SimPe.Packages.GeneratableFile gf =
					SimPe.Packages.GeneratableFile.LoadFromFile(ds.FileName);
				package = gf;
				return new ToolResult(false, true);
			}
		}

		public override string ToString()
		{
			return "Scan Folders...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon
		{
			get
			{
				return System.Drawing.Image.FromStream(
					this.GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.scanfolder.png")
				);
			}
		}

		public override System.Windows.Forms.Shortcut Shortcut
		{
			get { return System.Windows.Forms.Shortcut.CtrlF; }
		}
		#endregion
	}
}
