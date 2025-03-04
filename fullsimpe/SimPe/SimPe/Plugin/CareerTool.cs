// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;
using SimPe.PackedFiles.Glob;

namespace SimPe.Plugin
{
	/// <summary>
	/// Zusammenfassung für ImportSemiTool.
	/// </summary>
	public class CareerTool : AbstractTool, ITool
	{
		internal static Registry WindowsRegistry { get; } = Helper.WindowsRegistry;

		readonly IWrapperRegistry reg;
		readonly IProviderRegistry prov;

		internal CareerTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;
		}

		#region ITool Member

		internal static string DefaultCareerFile => "SimPe.files.base.career";

		public bool IsEnabled(Interfaces.Files.IPackedFileDescriptor pfd, Interfaces.Files.IPackageFile package)
		{
			return true;
		}

		private bool IsReallyEnabled(Interfaces.Files.IPackedFileDescriptor pfd, Interfaces.Files.IPackageFile package)
		{
			if (package == null || package.FileName == null)
			{
				return true;
			}

			Interfaces.Files.IPackedFileDescriptor[] globals = package.FindFiles(Data.MetaData.GLOB_FILE);
			if (globals.Length == 1)
			{
				Glob glob = new Glob();
				glob.ProcessData(globals[0], package);
				if (glob.SemiGlobalName == "JobDataGlobals")
				{
					return true;
				}
			}
			System.Windows.Forms.MessageBox.Show("This package does not contain a career.");
			return false;
		}

		public Interfaces.Plugin.IToolResult ShowDialog(ref Interfaces.Files.IPackedFileDescriptor pfd, ref Interfaces.Files.IPackageFile package)
		{
			if (!IsReallyEnabled(pfd, package))
			{
				return new ToolResult(false, false);
			}

			CareerEditor careerEditor = new CareerEditor();
			return careerEditor.Execute(ref pfd, ref package, prov);
		}


		public override string ToString()
		{
			return "Object Creation\\Bidou's Career Editor...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => System.Drawing.Image.FromStream(GetType().Assembly.GetManifestResourceStream("SimPe.img.CareerIcon.png"));
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;
		#endregion
	}
}
