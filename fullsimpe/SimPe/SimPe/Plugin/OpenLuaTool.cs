// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin
{
	/// <summary>
	/// Simple Tool in order to acces the Virual LUA Package
	/// </summary>
	public class OpenLuaTool : Interfaces.AbstractTool, Interfaces.ITool
	{
		public OpenLuaTool()
		{
			//
			// TODO: F�gen Sie hier die Konstruktorlogik hinzu
			//
		}

		#region ITool Member

		public bool IsEnabled(
			Interfaces.Files.IPackedFileDescriptor pfd,
			Interfaces.Files.IPackageFile package
		)
		{
			return PathProvider.Global.EPInstalled >= 0x2;
		}

		public Interfaces.Plugin.IToolResult ShowDialog(
			ref Interfaces.Files.IPackedFileDescriptor pfd,
			ref Interfaces.Files.IPackageFile package
		)
		{
			package = ObjLuaLoader.VirtualPackage;
			return new ToolResult(false, true);
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Object Tool\\Open virtual LUA package";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.OpenLua;
		#endregion
	}
}
