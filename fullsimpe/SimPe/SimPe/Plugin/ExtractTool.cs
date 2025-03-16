// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Threading.Tasks;

using SimPe.Data;
using SimPe.Forms.MainUI;
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ExtractTool.
	/// </summary>
	public class ExtractTool : AbstractTool, ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;

		internal ExtractTool(IWrapperRegistry reg, IProviderRegistry prov)
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
			return package != null && package.FileName != null;
		}

		private async Task<bool> IsReallyEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			if (package == null || package.FileName == null)
			{
				return false;
			}

			if (package.FindFiles(FileTypes.STR).Length > 0
				|| package.FindFiles(FileTypes.TTAs).Length > 0
				|| package.FindFiles(FileTypes.CTSS).Length > 0)
			{
				return true;
			}

			await Message.Show(
				"This package does not contain any Text Files."
			);
			return false;
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			return new ToolResult(false, false);
		}

		public override string ToString()
		{
			return "Object Tool\\Single Language Extractor...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.Extractor.png")
				);
		#endregion
	}
}
