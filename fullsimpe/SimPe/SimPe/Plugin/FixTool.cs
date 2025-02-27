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
	public class FixTool : Interfaces.AbstractTool, Interfaces.ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;

		internal FixTool(IWrapperRegistry reg, IProviderRegistry prov)
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
			return true;
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			ref SimPe.Interfaces.Files.IPackageFile package
		)
		{
			FixObject fo = new FixObject(package, FixVersion.UniversityReady, false);
			try
			{
				System.Collections.Hashtable map = fo.GetNameMap(false);
				if (map == null)
					return new ToolResult(false, false);

				WaitingScreen.Wait();

				fo.Fix(map, false);
				fo.CleanUp();
				fo.FixGroup();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				WaitingScreen.Stop();
			}

			if (Helper.StartedGui != Executable.Classic)
				return new ToolResult(false, false);
			else
				return new ToolResult(false, true);
		}

		public override string ToString()
		{
			return "Object Tool\\Fix Integrity";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => SimPe.GetIcon.FixIntegrity;
		#endregion
	}
}
