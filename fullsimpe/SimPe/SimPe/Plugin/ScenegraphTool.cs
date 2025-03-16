// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Zusammenfassung für ImportSemiTool.
	/// </summary>
	public class ScenegraphTool : AbstractTool, ITool
	{
		IWrapperRegistry reg;
		IProviderRegistry prov;

		internal ScenegraphTool(IWrapperRegistry reg, IProviderRegistry prov)
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
			return package != null;
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			Interfaces.Files.IPackedFileDescriptor opfd = pfd;

			return (pfd == null) && (opfd == null)
				? new ToolResult(false, false)
				: (pfd != null) && (opfd == null) ? new ToolResult(true, false) : (Interfaces.Plugin.IToolResult)new ToolResult(!pfd.Equals(opfd), false);
		}

		public override string ToString()
		{
			return "Object Tool\\Scenegrapher...";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream(
							"SimPe.img.scenegrapher.png"
						)
				);
		#endregion
	}
}
