// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class ImportSemiTool : AbstractTool, ITool
	{
		IWrapperRegistry reg;
		IProviderRegistry prov;

		internal ImportSemiTool(IWrapperRegistry reg, IProviderRegistry prov)
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
			return prov != null && prov.OpcodeProvider != null && package != null;
		}

		ImportSemi isg;

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			if (isg == null)
			{
				isg = new ImportSemi();
			}

			isg.Execute(package, reg, prov);
			return new ToolResult(false, true);
		}

		public override string ToString()
		{
			return "Object Tool\\Import Semi Globals...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.ImportSemi;
		#endregion
	}
}
