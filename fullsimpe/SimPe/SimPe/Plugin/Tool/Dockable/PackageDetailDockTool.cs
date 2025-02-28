// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Dockable Tool that displays Package specific Informations
	/// </summary>
	public class PackageDetailDockTool : Interfaces.IDockableTool
	{
		dcPackageDetails dc;

		public PackageDetailDockTool()
		{
			dc = new dcPackageDetails();
			pkg = null;
		}

		#region IDockableTool Member

		public Ambertation.Windows.Forms.DockPanel GetDockableControl()
		{
			return dc;
		}

		public event Events.ChangedResourceEvent ShowNewResource;

		Interfaces.Files.IPackageFile pkg;

		public void RefreshDock(object sender, Events.ResourceEventArgs es)
		{
			if (!es.Loaded)
			{
				dc.SetPackage(null);
			}
			else
			{
				//Only once for a package
				if (pkg != null)
				{
					if (pkg.Equals(es.LoadedPackage.Package))
					{
						return;
					}
				}

				dc.SetPackage(es.LoadedPackage.Package);
			}

			pkg = es.LoadedPackage.Package;
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return dc.Text;
		}

		#endregion

		#region IToolExt Member

		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => dc.TabImage;

		public virtual bool Visible => GetDockableControl().IsDocked || GetDockableControl().IsFloating;

		#endregion
	}
}
