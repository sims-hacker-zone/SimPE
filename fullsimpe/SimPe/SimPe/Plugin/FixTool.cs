// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

using SimPe.Interfaces;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for ImportSemiTool.
	/// </summary>
	public class FixTool : AbstractTool, ITool
	{
		internal FixTool()
		{
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
			FixObject fo = new FixObject(package, FixVersion.UniversityReady, false);
			try
			{
				System.Collections.Hashtable map = fo.GetNameMap(false);
				if (map == null)
				{
					return new ToolResult(false, false);
				}

				WaitingScreen.Wait();

				fo.Fix(map, false);
				fo.CleanUp();
				fo.FixGroup();
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage("", ex);
			}
			finally
			{
				WaitingScreen.Stop();
			}

			return Helper.StartedGui != Executable.Classic ? new ToolResult(false, false) : (Interfaces.Plugin.IToolResult)new ToolResult(false, true);
		}

		public override string ToString()
		{
			return "Object Tool\\Fix Integrity";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.FixIntegrity;
		#endregion
	}
}
