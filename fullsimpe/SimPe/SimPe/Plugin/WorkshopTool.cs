// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class WorkshopTool : AbstractTool, ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;
		Workshop ws;

		internal WorkshopTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;

			ws = new Workshop();
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
			if (Helper.StartedGui == Executable.Default)
			{
				if (
					Message.Show(
						Localization.GetString("ObsoleteOW"),
						Localization.GetString("Warning"),
						System.Windows.Forms.MessageBoxButtons.YesNo
					) == System.Windows.Forms.DialogResult.No
				)
				{
					return new ToolResult(false, false);
				}
			}

			Interfaces.Files.IPackageFile pkg = ws.Execute(prov, package);

			if (pkg != null)
			{
				if (pkg.Reader != null)
				{
					if (!pkg.Reader.BaseStream.CanWrite)
					{
						new ToolResult(false, false);
					}
				}

				package = pkg;
				return new ToolResult(false, true);
			}
			else
			{
				return new ToolResult(false, false);
			}
		}

		public override string ToString()
		{
			return Helper.StartedGui == Executable.Default
				? "Object Creation\\Windowed Object Workshop..."
				: "Object Creation\\Object Workshop...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.CreatePackageW;
		public override System.Windows.Forms.Shortcut Shortcut => Helper.StartedGui == Executable.Default ? System.Windows.Forms.Shortcut.None : System.Windows.Forms.Shortcut.CtrlW;
		#endregion
	}
}
