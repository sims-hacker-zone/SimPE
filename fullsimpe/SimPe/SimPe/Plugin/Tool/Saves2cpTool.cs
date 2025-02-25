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
using SimPe.Events;
using SimPe.Interfaces;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Summary description for Saves2cpTool.
	/// </summary>
	public class Saves2cpTool : SimPe.Interfaces.IToolPlus
	{
		internal Saves2cpTool() { }

		#region ITool Member

		public bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e)
		{
			return true;
		}

		public void Execute(object sender, ResourceEventArgs es)
		{
			if (!ChangeEnabledStateEventHandler(sender, es))
				return;

			if (es.Loaded)
			{
				SimPe.Packages.Sims2CommunityPack.ShowSaveDialog(
					new SimPe.Packages.GeneratableFile[] { es.LoadedPackage.Package },
					true
				);
			}
			else
			{
				SimPe.Packages.Sims2CommunityPack.ShowSaveDialog(
					new SimPe.Packages.GeneratableFile[0],
					true
				);
			}
		}

		public override string ToString()
		{
			return "Package Tool\\Create s2cp...";
		}

		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut
		{
			get { return System.Windows.Forms.Shortcut.None; }
		}

		public System.Drawing.Image Icon
		{
			get { return SimPe.GetIcon.S2pc; }
		}

		public virtual bool Visible
		{
			get { return true; }
		}

		#endregion
	}
}
