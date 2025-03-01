// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace pjHoodTool
{
	class tObjKeyTool
		: AbstractWrapperFactory,
			IToolFactory,
			IHelpFactory,
			ICommandLineFactory
	{
		#region IToolFactory Members
		public IToolPlugin[] KnownTools => new IToolPlugin[] { };
		#endregion

		#region IHelpFactory Members
		public IHelp[] KnownHelpTopics => new IHelp[] { new hHoodHelp() };
		#endregion

		#region ICommandLineFactory Members

		public ICommandLine[] KnownCommandLines => new ICommandLine[] { new cHoodTool() };

		#endregion
	}
}
