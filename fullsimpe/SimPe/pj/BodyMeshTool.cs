// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace pj
{
	class BodyMeshTool : AbstractWrapperFactory, IToolFactory, IHelpFactory
	{
		#region IToolFactory Members

		public IToolPlugin[] KnownTools => new IToolPlugin[]
				{
				};

		#endregion

		#region IHelpFactory Members

		public IHelp[] KnownHelpTopics => new IHelp[] { new BodyMeshHelp() };

		#endregion
	}
}
