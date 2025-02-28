// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace pjse.guidtool
{
	/// <summary>
	/// Summary description for GUIDTool.
	/// </summary>
	public class GUIDTool : AbstractTool, ITool
	{
		#region ITool Members

		public bool IsEnabled(
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
			GUIDForm form = new GUIDForm(package != null);
			form.Show();
			return new SimPe.Plugin.ToolResult(false, false);
		}

		#endregion

		#region IToolPlugin Members

		public override string ToString()
		{
			return "PJSE\\" + Localization.GetString("gt_ResourceFinder");
		}

		#endregion

		public override System.Drawing.Image Icon => SimPe.GetIcon.pjSearch;
	}
}
