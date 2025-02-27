/***************************************************************************
 *   Original (C) Bidou, assumed to be licenced as part of SimPE           *
 *   Pet updates copyright (C) 2007 by Peter L Jones                       *
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
using SimPe.Interfaces;

namespace pjOBJDTool
{
	/// <summary>
	/// Lists all Plugins (=FileType Wrappers) available in this Package
	/// </summary>
	/// <remarks>
	/// GetWrappers() has to return a list of all Plugins provided by this Library.
	/// If a Plugin isn't returned, SimPe won't recognize it!
	/// </remarks>
	public class WrapperFactory
		: SimPe.Interfaces.Plugin.AbstractWrapperFactory,
			SimPe.Interfaces.Plugin.IToolFactory,
			SimPe.Interfaces.Plugin.IHelpFactory
	{
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
				IWrapper[] wrappers = { };
				return wrappers;
			}
		}

		#endregion

		#region IToolFactory Member

		public IToolPlugin[] KnownTools
		{
			get
			{
				IToolPlugin[] tools =
				{
					new tOBJDTool(this.LinkedRegistry, this.LinkedProvider),
				};
				return tools;
			}
		}
		#endregion

		#region IHelpFactory Members

		class hOBJDHelp : IHelp
		{
			public System.Drawing.Image Icon => null;

			public override string ToString()
			{
				return "PJ OBJD Tool";
			}

			public void ShowHelp(SimPe.ShowHelpEventArgs e)
			{
				SimPe.RemoteControl.ShowHelp(
					"file://"
						+ SimPe.Helper.SimPePluginPath
						+ "/pjOBJDTool.plugin/pjOBJDTool_Help"
						+ "/Contents.htm"
				);
			}
		}

		public IHelp[] KnownHelpTopics
		{
			get
			{
				IHelp[] helpTopics = { new hOBJDHelp() };
				return helpTopics;
			}
		}
		#endregion
	}
}
