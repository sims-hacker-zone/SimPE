// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Plugin.Tool.Dockable
{
	/// <summary>
	/// Dockable Tool that displays Package specific Informations
	/// </summary>
	public class PackageDockTool : Interfaces.IDockableTool
	{
		ResourceDock rd;

		public PackageDockTool(ResourceDock rd)
		{
			this.rd = rd;
		}

		#region IDockableTool Member

		public Ambertation.Windows.Forms.DockPanel GetDockableControl()
		{
			return rd.dcPackage;
		}

		public event Events.ChangedResourceEvent ShowNewResource;

		Interfaces.Files.IPackageFile pkg;

		public void RefreshDock(object sender, Events.ResourceEventArgs es)
		{
			if (es.LoadedPackage != null)
			{
				if (es.LoadedPackage.Loaded)
				{
					bool newpkg = pkg == null;
					if (!newpkg)
					{
						newpkg = !es.LoadedPackage.Package.Equals(pkg);
					}

					if (newpkg)
					{
						Packages.PackageRepair pr =
							new Packages.PackageRepair(es.LoadedPackage.Package);
						rd.pgHead.SelectedObject = Helper.WindowsRegistry.HiddenMode ? pr.IndexDetailsAdvanced : (object)pr.IndexDetails;

						pkg = es.LoadedPackage.Package;

						rd.lv.Items.Clear();
						for (uint i = 0; i < pkg.Header.HoleIndex.Count; i++)
						{
							System.Windows.Forms.ListViewItem lvi =
								new System.Windows.Forms.ListViewItem();
							Packages.HoleIndexItem hii =
								es.LoadedPackage.Package.GetHoleIndex(i);
							lvi.Text = "0x" + Helper.HexString(hii.Offset);
							lvi.SubItems.Add("0x" + Helper.HexString(hii.Size));
							rd.lv.Items.Add(lvi);
						}
					}
					return;
				}
			}

			pkg = null;
			rd.pgHead.SelectedObject = null;
			rd.lv.Items.Clear();
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return rd.dcPackage.Text;
		}

		#endregion

		#region IToolExt Member

		public System.Windows.Forms.Shortcut Shortcut => System.Windows.Forms.Shortcut.None;

		public System.Drawing.Image Icon => rd.dcPackage.TabImage;

		public virtual bool Visible => GetDockableControl().IsDocked || GetDockableControl().IsFloating;

		#endregion
	}
}
