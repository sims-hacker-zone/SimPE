using System;
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	public class GametipWrapperFactory
		: SimPe.Interfaces.Plugin.AbstractWrapperFactory,
			SimPe.Interfaces.Plugin.IHelpFactory
	{
		#region AbstractWrapperFactory Member
		public override SimPe.Interfaces.IWrapper[] KnownWrappers
		{
			get
			{
				if (Helper.SimPeVersionLong < 330717003793) // requires updated simpe.workspace and GDF
				{
					return new IWrapper[0];
				}
				else if (Helper.StartedGui == Executable.Classic)
				{
					IWrapper[] wrappers = { new XGoal() };
					return wrappers;
				}
				else
				{
					IWrapper[] wrappers =
					{
						new GametipPackedFileWrapper(),
						new LastEPusePackedFileWrapper(),
						new GWInvPackedFileWrapper(),
					};
					return wrappers;
				}
			}
		}
		#endregion

		#region IHelpFactory Members

		class simmyHelp : IHelp
		{
			public System.Drawing.Image Icon
			{
				get { return null; }
			}

			public override string ToString()
			{
				return "Sims2 Beginners Guide";
			}

			public void ShowHelp(ShowHelpEventArgs e)
			{
				SimPe.RemoteControl.ShowHelp(
					"file://" + SimPe.Helper.SimPePath + "/Doc/BeginnerGuide.htm"
				);
			}
		}

		public IHelp[] KnownHelpTopics
		{
			get
			{
				if (
					Helper.StartedGui == Executable.Classic
					|| Helper.WindowsRegistry.HiddenMode
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
