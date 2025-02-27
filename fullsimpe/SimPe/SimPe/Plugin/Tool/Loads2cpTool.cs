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
	/// Summary description for LoadSims2PackTool.
	/// </summary>
	public class Loads2cpTool : SimPe.Interfaces.IToolPlus
	{
		internal Loads2cpTool()
		{
		}

		#region ITool Member

		public bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e)
		{
			return true;
		}

		public void Execute(object sender, ResourceEventArgs es)
		{
			if (!ChangeEnabledStateEventHandler(sender, es))
				return;

			System.Windows.Forms.OpenFileDialog ofd =
				new System.Windows.Forms.OpenFileDialog();
			ofd.Filter = SimPe.ExtensionProvider.BuildFilterString(
				new SimPe.ExtensionType[]
				{
					ExtensionType.Sim2PackCommunity,
					ExtensionType.AllFiles,
				}
			);
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				SimPe.Packages.S2CPDescriptor[] ds =
					SimPe.Packages.Sims2CommunityPack.ShowOpenDialog(
						ofd.FileName,
						System.Windows.Forms.SelectionMode.MultiExtended
					);
				if (ds != null)
					foreach (SimPe.Packages.S2CPDescriptor d in ds)
						SimPe.RemoteControl.OpenMemoryPackage(d.Package);
			}
		}

		public override string ToString()
		{
			return "Package Tool\\Open s2cp...";
		}

		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => SimPe.GetIcon.S2pcOpen;

		public virtual bool Visible => true;

		#endregion
	}
}
