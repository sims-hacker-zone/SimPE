// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Events;

namespace SimPe.Plugin.Tool
{
	/// <summary>
	/// Zusammenfassung für ImportSemiTool.
	/// </summary>
	public class CreateListFromPackageTool : Interfaces.IToolPlus
	{
		internal CreateListFromPackageTool()
		{
		}

		#region ITool Member

		public bool ChangeEnabledStateEventHandler(object sender, ResourceEventArgs e)
		{
			return e.Loaded;
		}

		public void Execute(object sender, ResourceEventArgs es)
		{
			if (!ChangeEnabledStateEventHandler(sender, es))
			{
				return;
			}

			ResourceContainers c = new ResourceContainers();
			foreach (
				Interfaces.Files.IPackedFileDescriptor pfd in es.LoadedPackage
					.Package
					.Index
			)
			{
				Interfaces.Scenegraph.IScenegraphFileIndexItem fii =
					new FileIndexItem(pfd, es.LoadedPackage.Package);
				ResourceContainer rc = new ResourceContainer(fii);
				c.Add(rc);
			}

			CreateListFromSelectionTool.Execute(c);
		}

		public override string ToString()
		{
			return "Create Description\\from Package...";
		}

		#endregion

		#region IToolExt Member
		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.CtrlShiftD;

		public System.Drawing.Image Icon => System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.package.png")
				);

		public virtual bool Visible => true;

		#endregion
	}
}
