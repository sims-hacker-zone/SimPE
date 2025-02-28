// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class DownloadScanTool : ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;
		DownloadScan ds;

		internal DownloadScanTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;

			ds = new DownloadScan
			{
				prov = this.prov
			};
		}

		#region ITool Member

		public bool IsEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			return true;
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			ds.ShowDialog();

			if (ds.FileName == null)
			{
				return new ToolResult(false, false);
			}
			else
			{
				Packages.GeneratableFile gf =
					Packages.File.LoadFromFile(ds.FileName);
				package = gf;
				return new ToolResult(false, true);
			}
		}

		public override string ToString()
		{
			return "Scan Downloads...";
		}

		#endregion
	}
}
