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
using System.IO;
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Lists all Plugins (=FileType Wrappers) available in this Package
	/// </summary>
	/// <remarks>
	/// GetWrappers() has to return a list of all Plugins provided by this Library.
	/// If a Plugin isn't returned, SimPe won't recognize it!
	/// </remarks>
	public class CopyrightToolFactory : SimPe.Interfaces.Plugin.AbstractWrapperFactory, SimPe.Interfaces.Plugin.IToolFactory, SimPe.Interfaces.Plugin.IHelpFactory
	{
		public CopyrightToolFactory()
		{
			
		}

		#region AbstractWrapperFactory Member
		/// <summary>
		/// Returns a List of all available Plugins in this Package
		/// </summary>
		/// <returns>A List of all provided Plugins (=FileType Wrappers)</returns>
		public override SimPe.Interfaces.IWrapper[] KnownWrappers
		{
			get 
			{
				// TODO:  You can add more Wrappers here
				IWrapper[] wrappers = {
										  
									  };
				return wrappers;
			}
		}

		#endregion

		#region IToolFactory Member

		public IToolPlugin[] KnownTools
		{
			get
			{
				IToolPlugin[] tools = null;
				if (Helper.StartedGui != Executable.Classic && UserVerification.HaveValidUserId)
				{
					tools = new IToolPlugin[]{ new SimPe.Plugin.Tool.Action.ActionAddCopyright() };
				}
				else 
				{
					tools =  new IToolPlugin[]{ };
				}
				return tools;
			}
		}
		#endregion

		#region IHelpFactory Members

		class easHelp : IHelp
		{
			public System.Drawing.Image Icon { get { return null; } }
			public override string ToString() { return "EA Support"; }
			public void ShowHelp(ShowHelpEventArgs e)
			{
				if (File.Exists(SimPe.Helper.NewestGamePath + "/Support/EA Help/Electronic_Arts_Technical_Support.htm"))
					SimPe.RemoteControl.ShowHelp("file://" + SimPe.Helper.NewestGamePath + "/Support/EA Help/Electronic_Arts_Technical_Support.htm");
				else
					SimPe.RemoteControl.ShowHelp("file://" + SimPe.Helper.SimPePath + "/Doc/NoFile.htm");
			}
		}

		public IHelp[] KnownHelpTopics
		{
			get
			{
				if (Helper.StartedGui == Executable.Classic || Helper.WindowsRegistry.HiddenMode)
				{
					return new IHelp[0];
				}
				else
				{
					IHelp[] helpTopics = { new easHelp() };
					return helpTopics;
				}
			}
		}

		#endregion
	}
}