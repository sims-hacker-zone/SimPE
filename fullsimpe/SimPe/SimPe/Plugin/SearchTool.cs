// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class SearchTool : AbstractTool, ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;
		Search sc;
		string flname;

		internal SearchTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;
			sc = new Search
			{
				prov = prov
			};
			flname = "";
		}

		#region ITool Member

		public bool IsEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			return package != null && package.FileName != null;
		}

		private bool IsReallyEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			if (package == null || package.FileName == null)
			{
				return false;
			}

			if (flname.ToLower().Trim() != package.FileName.ToLower().Trim())
			{
				sc.Reset();
			}

			flname = package.FileName;
			return true;
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
					ToString()
				);
				return new ToolResult(false, false);
			}
			if (flname.ToLower().Trim() != package.FileName.ToLower().Trim())
			{
				sc.Reset();
			}

			Interfaces.Files.IPackedFileDescriptor selpfd = sc.Execute(package);

			if (selpfd != null)
			{
				pfd = selpfd;
				return new ToolResult(true, false);
			}
			else
			{
				return new ToolResult(false, false);
			}
		}

		public override string ToString()
		{
			return Localization.GetString("Search Current File...");
		}

		#endregion
		#region IToolExt Member
		public override System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.search.png")
				);
		#endregion
	}
}
