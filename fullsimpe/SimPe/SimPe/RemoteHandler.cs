// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;

namespace SimPe
{
	/// <summary>
	/// This is the entry point for the RemoteHandlers of the main SimPe Form
	/// </summary>
	internal class RemoteHandler
	{
		LoadedPackage lp;
		ResourceLoader rl;
		System.Windows.Forms.ToolStripMenuItem docs;
		PluginManager plugger;

		internal RemoteHandler(
			System.Windows.Forms.Form form,
			LoadedPackage lp,
			ResourceLoader rl,
			System.Windows.Forms.ToolStripMenuItem docmenu
		)
		{
			this.lp = lp;
			this.rl = rl;
			docs = docmenu;
			plugger = null;

			RemoteControl.OpenPackageFkt = new RemoteControl.OpenPackageDelegate(
				OpenPackage
			);
			RemoteControl.OpenPackedFileFkt =
				new RemoteControl.OpenPackedFileDelegate(OpenPackedFile);
			RemoteControl.OpenMemoryPackageFkt =
				new RemoteControl.OpenMemPackageDelegate(OpenMemPackage);
			RemoteControl.ShowDockFkt = new RemoteControl.ShowDockDelegate(
				ShowDock
			);

			RemoteControl.ApplicationForm = form;
		}

		internal void SetPlugger(PluginManager plugger)
		{
			this.plugger = plugger;
		}

		public bool OpenPackage(string filename)
		{
			return System.IO.File.Exists(filename) && lp.LoadFromFile(filename);
		}

		public bool OpenMemPackage(Interfaces.Files.IPackageFile pkg)
		{
			return pkg != null && pkg is Packages.GeneratableFile file && lp.LoadFromPackage(file);
		}

		public bool OpenPackedFile(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		)
		{
			if (fii == null)
			{
				return false;
			}

			try
			{
				if (fii.Package != null)
				{
					if (!fii.Package.Equals(lp.Package))
					{
						int bprc = Helper.WindowsRegistry.BigPackageResourceCount;
						Helper.WindowsRegistry.BigPackageResourceCount = int.MaxValue;

						if (
							!lp.LoadFromPackage(
								(Packages.GeneratableFile)fii.Package
							)
						)
						{
							Helper.WindowsRegistry.BigPackageResourceCount = bprc;
							return false;
						}
						Helper.WindowsRegistry.BigPackageResourceCount = bprc;
					}
				}
			}
			catch (Exception ex)
			{
				Helper.ExceptionMessage(ex);
				return false;
			}

			bool res = rl.AddResource(fii, false);
			if (res && LoadedResource != null)
			{
				FireLoadEvent(fii);
			}

			return res;
		}

		/// <summary>
		/// Fires the <see cref="LoadedResource"/> Event
		/// </summary>
		/// <param name="fii"></param>
		public void FireLoadEvent(
			Interfaces.Scenegraph.IScenegraphFileIndexItem fii
		)
		{
			Events.ResourceEventArgs e = new Events.ResourceEventArgs(lp);
			e.Items.Add(new Events.ResourceContainer(fii));
			LoadedResource(this, e);
		}

		/// <summary>
		/// Fires when the Remote COntrol did select a File
		/// </summary>
		public event Events.ChangedResourceEvent LoadedResource;

		/// <summary>
		/// Make a doc Visible or Hide it
		/// </summary>
		/// <param name="doc">The Doc you want to show/hide</param>
		public void ShowDock(Ambertation.Windows.Forms.DockPanel doc, bool hide)
		{
			if (hide && doc.IsOpen)
			{
				doc.Close();
			}

			if (!hide)
			{
				if (!doc.IsOpen)
				{
					doc.OpenFloating();
				}

				if (doc.Collapsed)
				{
					doc.Expand(false);
				}

				doc.EnsureVisible();
				if (!doc.IsOpen)
				{
					plugger.ChangedGuiResourceEventHandler();
				}
			}

			foreach (object o in docs.DropDownItems)
			{
				if (!(o is System.Windows.Forms.ToolStripMenuItem mi))
				{
					continue;
				}

				if (mi.Tag as Ambertation.Windows.Forms.DockPanel == doc)
				{
					mi.Checked = doc.IsOpen;
				}
			}
		}
	}
}
