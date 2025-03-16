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

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			return null;
		}

		public override string ToString()
		{
			return "Neighbourhood\\Sims Surgery...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.SimSurgery;
		#endregion
	}
}
