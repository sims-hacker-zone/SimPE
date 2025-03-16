// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Threading.Tasks;

namespace SimPe
{
	/// <summary>
	/// This is the entry point for the RemoteHandlers of the main SimPe Form
	/// </summary>
	internal class RemoteHandler
	{
		LoadedPackage lp;
		ResourceLoader rl;
		PluginManager plugger;

		internal RemoteHandler(
			LoadedPackage lp,
			ResourceLoader rl
		)
		{
			this.lp = lp;
			this.rl = rl;
			plugger = null;

			RemoteControl.OpenPackageFkt = new RemoteControl.OpenPackageDelegate(
				OpenPackage
			);
			RemoteControl.OpenPackedFileFkt =
				new RemoteControl.OpenPackedFileDelegate(OpenPackedFile);
			RemoteControl.OpenMemoryPackageFkt =
				new RemoteControl.OpenMemPackageDelegate(OpenMemPackage);
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

		public async Task<bool> OpenPackedFile(
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
						int bprc = Helper.WindowsRegistry.Config.BigPackageResourceCount;
						Helper.WindowsRegistry.Config.BigPackageResourceCount = int.MaxValue;

						if (
							!lp.LoadFromPackage(
								(Packages.GeneratableFile)fii.Package
							)
						)
						{
							Helper.WindowsRegistry.Config.BigPackageResourceCount = bprc;
							return false;
						}
						Helper.WindowsRegistry.Config.BigPackageResourceCount = bprc;
					}
				}
			}
			catch (Exception ex)
			{
				await Helper.ExceptionMessage(ex);
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
	}
}
