// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
	public class ToolFactory3D
		: Interfaces.Plugin.AbstractWrapperFactory,
			Interfaces.Plugin.IToolFactory
	{
		public ToolFactory3D()
		{
		}

		#region AbstractWrapperFactory Member
		/// <summary>
		/// Returns a List of all available Plugins in this Package
		/// </summary>
		/// <returns>A List of all provided Plugins (=FileType Wrappers)</returns>
		public override IWrapper[] KnownWrappers =>
				// TODO:  You can add more Wrappers here
				new IWrapper[] { };

		#endregion

		#region IToolFactory Member

		public IToolPlugin[] KnownTools => new IToolPlugin[] { };
		#endregion
	}
}
