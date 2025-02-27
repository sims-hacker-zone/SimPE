/***************************************************************************
 *   Original (C) Bidou, assumed to be licenced as part of SimPE           *
 *   Pet updates copyright (C) 2007 by Peter L Jones                       *
 *   Updates copyright (C) 2008 by Peter L Jones                           *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using SimPe.Interfaces;

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

		internal static string DefaultCareerFile => "SimPe.data.base.career";

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
