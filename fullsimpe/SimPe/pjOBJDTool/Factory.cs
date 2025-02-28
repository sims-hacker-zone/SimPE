// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
		public override IWrapper[] KnownWrappers => new IWrapper[] { };

		#endregion

		#region IToolFactory Member

		public IToolPlugin[] KnownTools => new IToolPlugin[] { };
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
