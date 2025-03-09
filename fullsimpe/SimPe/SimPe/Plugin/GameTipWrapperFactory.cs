// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Interfaces;

namespace SimPe.Plugin
{
	public class GametipWrapperFactory
		: Interfaces.Plugin.AbstractWrapperFactory,
			Interfaces.Plugin.IHelpFactory
	{
		#region AbstractWrapperFactory Member
		public override IWrapper[] KnownWrappers => Helper.SimPeVersionLong < 330717003793
					? (new IWrapper[0])
					: Helper.StartedGui == Executable.Classic
						? (new IWrapper[] { })
						: (new IWrapper[] { });
		#endregion

		#region IHelpFactory Members

		class simmyHelp : IHelp
		{
			public System.Drawing.Image Icon => null;

			public override string ToString()
			{
				return "Sims2 Beginners Guide";
			}

			public void ShowHelp(ShowHelpEventArgs e)
			{
				RemoteControl.ShowHelp(
					"file://" + Helper.SimPePath + "/Doc/BeginnerGuide.htm"
				);
			}
		}

		public IHelp[] KnownHelpTopics
		{
			get
			{
				if (
					Helper.StartedGui == Executable.Classic
					|| Helper.WindowsRegistry.Config.HiddenMode
				)
				{
					return new IHelp[0];
				}
				else
				{
					IHelp[] helpTopics = { new simmyHelp() };
					return helpTopics;
				}
			}
		}
		#endregion
	}
}
