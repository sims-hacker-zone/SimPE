// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class SimsTool : AbstractTool, ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;

		internal SimsTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;
		}

		#region ITool Member

		public bool IsEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			return
				Helper.IsNeighborhoodFile(package?.FileName)
				|| Helper.IsLotCatalogFile(package?.FileName)
			;
		}

		private bool IsReallyEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			return package != null && prov.SimNameProvider != null
&& (Helper.IsNeighborhoodFile(package.FileName)
				|| Helper.IsLotCatalogFile(package.FileName));
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			if (!IsReallyEnabled(pfd, package))
			{
				System.Windows.Forms.MessageBox.Show(
					Localization.GetString(
						"This is not an appropriate context in which to use this tool"
					),
					Localization.Manager.GetString("simsbrowser")
				);
				return new ToolResult(false, false);
			}
			Sims sims = new Sims
			{
				Text = Localization.Manager.GetString("simsbrowser")
			};

			return sims.Execute(ref pfd, ref package, prov);
		}

		public override string ToString()
		{
			return "Neighbourhood\\"
				+ Localization.Manager.GetString("simsbrowser")
				+ "...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.SimBrowser;
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlShiftS;
		#endregion
	}
}
