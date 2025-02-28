// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class SurgeryTool : AbstractTool, ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;

		internal SurgeryTool(IWrapperRegistry reg, IProviderRegistry prov)
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

		Surgery surg;

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
					Localization.Manager.GetString("Sims Surgery Tool")
				);
				return new ToolResult(false, false);
			}
			if (surg == null)
			{
				surg = new Surgery();
			}

			surg.Text = Localization.Manager.GetString("Sims Surgery Tool");

			return surg.Execute(ref pfd, ref package, prov);
		}

		public override string ToString()
		{
			return "Neighbourhood\\Sims Surgery...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.SimSurgery;
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;
		#endregion
	}
}
