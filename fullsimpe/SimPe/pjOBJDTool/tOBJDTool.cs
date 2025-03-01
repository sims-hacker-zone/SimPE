// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace pjOBJDTool
{
	class tOBJDTool : AbstractTool, ITool
	{
		internal static SimPe.Registry WindowsRegistry => SimPe.Helper.WindowsRegistry;

		IWrapperRegistry reg;
		IProviderRegistry prov;
		cOBJDTool cobjdtool;

		internal tOBJDTool(IWrapperRegistry reg, IProviderRegistry prov)
		{
			this.reg = reg;
			this.prov = prov;
		}

		#region ITool Member

		public bool IsEnabled(
			SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			SimPe.Interfaces.Files.IPackageFile package
		)
		{
			if (package == null)
			{
				return false;
			}

			SimPe.Interfaces.Files.IPackedFileDescriptor[] obbies = package.FindFiles(
				SimPe.Data.MetaData.OBJD_FILE
			);
			return obbies.Length >= 1;
		}

		public bool IsReallyEnabled(
			SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			SimPe.Interfaces.Files.IPackageFile package
		)
		{
			return true;
		}

		public SimPe.Interfaces.Plugin.IToolResult ShowDialog(
			ref SimPe.Interfaces.Files.IPackedFileDescriptor pfd,
			ref SimPe.Interfaces.Files.IPackageFile package
		)
		{
			if (!IsReallyEnabled(pfd, package))
			{
				return new SimPe.Plugin.ToolResult(false, false);
			}

			if (cobjdtool == null)
			{
				cobjdtool = new cOBJDTool();
			}

			return cobjdtool.Execute(ref pfd, ref package, prov);
		}

		public override string ToString()
		{
			return "PJSE\\OBJD Tool";
		}

		#endregion

		/*
		public IToolPlugin[] KnownTools { get { return new IToolPlugin[] { new cOBJDTool() }; } }

		#region IToolPlugin Members

		string IToolPlugin.ToString()
		{
			return L.Get("pjCOBJDTool");
		}

		#endregion
		*/

		#region IToolExt Member
		public override System.Drawing.Image Icon => SimPe.GetIcon.pjOBJDtool;
		public override System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;
		#endregion
	}
}
