using System;
using System.ComponentModel;

namespace SimPe.Windows.Forms
{
	public partial class ResourceViewManager : Component
	{
		ResourceMaps maps;
		bool isbigneighbourhood = false;

		public ResourceViewManager()
		{
			InitializeComponent();

			maps = new ResourceMaps();
		}

		~ResourceViewManager()
		{
			CancelThreads();
		}

		ResourceListViewExt lv;
		public ResourceListViewExt ListView
		{
			get => lv;
			set
			{
				if (lv != value)
				{
					lv?.SetManager(null);

					lv = value;
					lv?.SetManager(this);
				}
			}
		}

		ResourceTreeViewExt tv;
		public ResourceTreeViewExt TreeView
		{
			get => tv;
			set
			{
				if (tv != value)
				{
					tv?.SetManager(null);

					tv = value;
					tv?.SetManager(this);
				}
			}
		}

		public bool Available => (tv != null && lv != null);

		Interfaces.Files.IPackageFile pkg;

		[Browsable(false)]
		public ResourceNameList Everything => maps.Everything;

		[Browsable(false)]
		public Interfaces.Files.IPackageFile Package
		{
			get => pkg;
			set
			{
				if (pkg != value)
				{
					Interfaces.Files.IPackageFile old = pkg;
					pkg = value;
					OnChangedPackage(old, pkg, true);
				}
			}
		}

		protected void OnChangedPackage(
			Interfaces.Files.IPackageFile oldpkg,
			Interfaces.Files.IPackageFile newpkg,
			bool lettreeviewselect
		)
		{
			lock (maps)
			{
				lv?.BeginUpdate();

				if (oldpkg != null)
				{
					oldpkg.SavedIndex -= new EventHandler(newpkg_SavedIndex);
					oldpkg.RemovedResource -= new EventHandler(newpkg_RemovedResource);
					oldpkg.AddedResource -= new EventHandler(newpkg_AddedResource);
				}
				maps.Clear();

				if (newpkg != null)
				{
					if (
						Helper.WindowsRegistry.ShowProgressWhenPackageLoads
						|| !Helper.WindowsRegistry.AsynchronSort
					)
					{
						Wait.Start(newpkg.Index.Length);
					}
					else
					{
						Wait.Start();
					}

					Wait.Message = Localization.GetString("Loading package...");
					int ct = 0;
					foreach (
						Interfaces.Files.IPackedFileDescriptor pfd in newpkg.Index
					)
					{
						NamedPackedFileDescriptor npfd = new NamedPackedFileDescriptor(
							pfd,
							newpkg
						);
						if (!Helper.WindowsRegistry.AsynchronSort)
						{
							npfd.GetRealName();
						}

						maps.Everything.Add(npfd);
						AddResourceToMaps(npfd);
						if (
							Helper.WindowsRegistry.ShowProgressWhenPackageLoads
							|| !Helper.WindowsRegistry.AsynchronSort
						)
						{
							Wait.Progress = ct++;
						}
					}
					Wait.Stop();
				}

				UpdateContent(lettreeviewselect);

				if (newpkg != null)
				{
					newpkg.AddedResource += new EventHandler(newpkg_AddedResource);
					newpkg.RemovedResource += new EventHandler(newpkg_RemovedResource);
					newpkg.SavedIndex += new EventHandler(newpkg_SavedIndex);
				}

				lv?.EndUpdate();
			}
		}

		internal void UpdateTree()
		{
			//lv.BeginUpdate();
			maps.Clear(false);
			foreach (NamedPackedFileDescriptor npfd in maps.Everything)
			{
				if (!Helper.WindowsRegistry.AsynchronSort)
				{
					npfd.GetRealName();
				}

				AddResourceToMaps(npfd);
			}
			tv?.SetResourceMaps(maps, false, false);
			//lv.EndUpdate(false);
		}

		private void UpdateContent(bool lettreeviewselect)
		{
			bool donotselect = false;
			string filonam = "nil";
			if (pkg != null)
			{
				filonam = pkg.FileName;
			}

			if (
				(
					maps.Everything.Count
						> Helper.WindowsRegistry.BigPackageResourceCount
					&& !Helper.WindowsRegistry.ResoruceTreeAllwaysAutoselect
				) || Helper.IsNeighborhoodFile(filonam)
			)
			{
				donotselect = true;
				lv.Clear();
			}

			if (lv != null && !lettreeviewselect)
			{
				if (donotselect)
				{
					lv.SetResources(new ResourceNameList());
				}
				else
				{
					lv.SetResources(maps.Everything);
				}
			}
			tv?.SetResourceMaps(
					maps,
					lettreeviewselect,
					Helper.IsNeighborhoodFile(filonam)
				);
			// if (tv != null) tv.SetResourceMaps(maps, lettreeviewselect, donotselect);
			isbigneighbourhood = donotselect;
		}

		void newpkg_SavedIndex(object sender, EventArgs e)
		{
			OnChangedPackage(pkg, pkg, true);
		}

		public void FakeSave()
		{
			newpkg_SavedIndex(null, null);
		}

		void newpkg_RemovedResource(object sender, EventArgs e)
		{
			//OnChangedPackage(pkg, pkg);
			lv?.Refresh();
		}

		void newpkg_AddedResource(object sender, EventArgs e)
		{
			OnChangedPackage(pkg, pkg, true);
		}

		private void AddResourceToMaps(NamedPackedFileDescriptor npfd)
		{
			AddToTypeMap(npfd);
			AddToGroupMap(npfd);
			AddToInstMap(npfd);
		}

		private void AddToTypeMap(NamedPackedFileDescriptor npfd)
		{
			ResourceNameList pfdlist = null;
			if (maps.ByType.ContainsKey(npfd.Descriptor.Type))
			{
				pfdlist = maps.ByType[npfd.Descriptor.Type];
			}
			else
			{
				pfdlist = new ResourceNameList();
				maps.ByType[npfd.Descriptor.Type] = pfdlist;
			}

			pfdlist.Add(npfd);
		}

		private void AddToGroupMap(NamedPackedFileDescriptor npfd)
		{
			ResourceNameList pfdlist = null;
			if (maps.ByGroup.ContainsKey(npfd.Descriptor.Group))
			{
				pfdlist = maps.ByGroup[npfd.Descriptor.Group];
			}
			else
			{
				pfdlist = new ResourceNameList();
				maps.ByGroup[npfd.Descriptor.Group] = pfdlist;
			}

			pfdlist.Add(npfd);
		}

		private void AddToInstMap(NamedPackedFileDescriptor npfd)
		{
			ResourceNameList pfdlist = null;
			if (maps.ByInstance.ContainsKey(npfd.Descriptor.LongInstance))
			{
				pfdlist = maps.ByInstance[npfd.Descriptor.LongInstance];
			}
			else
			{
				pfdlist = new ResourceNameList();
				maps.ByInstance[npfd.Descriptor.LongInstance] = pfdlist;
			}

			pfdlist.Add(npfd);
		}

		internal static int GetIndexForResourceType(uint type)
		{
			if (Helper.WindowsRegistry.DecodeFilenamesState)
			{
				Interfaces.Plugin.Internal.IPackedFileWrapper wrp =
					FileTableBase.WrapperRegistry.FindHandler(type);
				if (wrp != null)
				{
					return wrp.WrapperDescription.IconIndex;
				}
			}

			return 0;
		}

		public void CancelThreads()
		{
			lv?.CancelThreads();
		}

		public void StoreLayout()
		{
			lv?.StoreLayout();
		}

		public void RestoreLayout()
		{
			lv?.RestoreLayout();

			tv?.RestoreLayout();
		}

		public bool SelectResource(
			Interfaces.Scenegraph.IScenegraphFileIndexItem resource
		)
		{
			bool res = false;
			if (lv != null)
			{
				res = lv.SelectResource(resource);
			}

			if (!res && tv != null && lv != null && !isbigneighbourhood)
			{
				tv.SelectAll();
				res = lv.SelectResource(resource);
			}
			return res;
		}
	}
}
