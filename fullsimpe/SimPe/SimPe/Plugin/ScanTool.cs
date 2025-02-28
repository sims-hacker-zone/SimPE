// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	internal class ScanerTool : Interfaces.AbstractTool, Interfaces.ITool
	{
		static ScannerForm ds;

		internal ScanerTool()
		{
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
			if (ds == null)
			{
				ds = new ScannerForm();
			}

			RemoteControl.ShowSubForm(ds);

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
			return "Scan Folders...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.scanfolder.png")
				);

		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlF;
		#endregion
	}
}
