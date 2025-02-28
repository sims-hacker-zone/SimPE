// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class SkinWorkshopTool : Interfaces.AbstractTool, Interfaces.ITool
	{
		internal static Registry WindowsRegistry => Helper.WindowsRegistry;

		SkinWorkshop ws;

		internal SkinWorkshopTool()
		{
			ws = new SkinWorkshop();
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
			Interfaces.Files.IPackageFile pkg = ws.Execute(package);

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
			return "Object Creation\\Skin Workshop...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.SkinWorkshop;
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;
		#endregion
	}
}
