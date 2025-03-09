// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;
using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Mmat;

namespace SimPe.Plugin
{
	/// <summary>
	/// Lists all Plugins (=FileType Wrappers) available in this Package
	/// </summary>
	/// <remarks>
	/// GetWrappers() has to return a list of all Plugins provided by this Library.
	/// If a Plugin isn't returned, SimPe won't recognize it!
	/// </remarks>
	public class WorkshopToolFactory
		: Interfaces.Plugin.AbstractWrapperFactory,
			Interfaces.Plugin.IToolFactory,
			Interfaces.Plugin.IHelpFactory
	{
		internal static IToolPlugin[] Last;

		public WorkshopToolFactory()
		{
			MmatWrapper.GlobalCpfPreview =
				new CpfUI.ExecutePreview(
					PreviewForm.Execute
				);
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

		#region IHelpFactory Members

		class obwHelp : IHelp
		{
			public System.Drawing.Image Icon => null;

			public override string ToString()
			{
				return "Object Workshop";
			}

			public void ShowHelp(ShowHelpEventArgs e)
			{
				RemoteControl.ShowHelp(
					"file://" + Helper.SimPePath + "/Doc/OWoptions.htm"
				);
			}
		}

		public IHelp[] KnownHelpTopics
		{
			get
			{
				if (Helper.StartedGui == Executable.Classic)
				{
					return new IHelp[0];
				}
				else
				{
					IHelp[] helpTopics = { new obwHelp() };
					return helpTopics;
				}
			}
		}
		#endregion
	}
}
