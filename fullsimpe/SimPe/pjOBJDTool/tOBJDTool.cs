/***************************************************************************
 *   Copyright (C) 2008 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
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
using SimPe.Interfaces.Plugin;

namespace pjOBJDTool
{
	class tOBJDTool : AbstractTool, ITool
	{
		internal static SimPe.Registry WindowsRegistry => SimPe.Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;
		cOBJDTool cobjdtool;

		internal tOBJDTool(IWrapperRegistry reg, IProviderRegistry prov)
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
			if (package == null)
				return false;
			SimPe.Interfaces.Files.IPackedFileDescriptor[] obbies = package.FindFiles(
				SimPe.Data.MetaData.OBJD_FILE
			);
			if (obbies.Length < 1)
				return false;
			return true;
		}

		public bool IsReallyEnabled(
			SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			SimPe.Interfaces.Files.IPackageFile package
		)
		{
			return true;
		}

		public SimPe.Interfaces.Plugin.IToolResult ShowDialog(
			ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			ref SimPe.Interfaces.Files.IPackageFile package
		)
		{
			if (!IsReallyEnabled(pfd, package))
				return new SimPe.Plugin.ToolResult(false, false);
			if (cobjdtool == null)
				cobjdtool = new cOBJDTool();
			return cobjdtool.Execute(ref pfd, ref package, prov);
		}

		public override string ToString()
		{
			return "PJSE\\OBJD Tool";
		}

		#endregion

		/*
		public IToolPlugin[] KnownTools { get { return new IToolPlugin[] { new cOBJDTool() }; } }

		#region IToolPlugin Members

		string IToolPlugin.ToString()
		{
			return L.Get("pjCOBJDTool");
		}

		#endregion
		*/

		#region IToolExt Member
		public override System.Drawing.Image Icon => SimPe.GetIcon.pjOBJDtool;
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;
		#endregion
	}
}
