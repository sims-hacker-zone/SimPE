using System;

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for SimTypeHandler.
	/// </summary>
	public class RecolorTypeHandler : ITypeHandler, IDisposable
	{
		protected PackageInfo nfo;

		public RecolorTypeHandler()
		{
		}

		protected void PostponedRender(object sender, EventArgs e)
		{
			Wait.SubStart();
			Wait.Message = "Building Preview";
			PackageInfo nfo = sender as PackageInfo;
			object[] data = nfo.RenderData as object[];
			tmppkg = Packages.File.LoadFromFile(data[1].ToString());
			if (tmppkg == null)
			{
				return;
			}

			Interfaces.Scenegraph.IScenegraphFileIndex fii =
				DownloadsToolFactory.TeleportFileIndex.AddNewChild();
			MmatWrapper mmat = data[0] as MmatWrapper;

			mmat.ProcessData(mmat.FileDescriptor, tmppkg);
			if (mmat != null)
			{
				fii.AddIndexFromPackage(mmat.Package, true);
				if (
					System.IO.File.Exists(
						System.IO.Path.Combine(
							Helper.SimPePluginPath,
							"simpe.workshop.plugin.dll"
						)
					)
				)
				{
					try
					{
						Ambertation.Scenes.Scene scn =
							PreviewForm.RenderScene(mmat); // depends on simpe.workshop.plugin.dll, pity as that may not exist
						nfo.RenderedImage = DefaultTypeHandler.Get3dPreview(
							scn
						);
						scn.Dispose();
						mmat.Dispose();
					}
					catch { }
				}
				else
				{
					nfo.RenderedImage = GetImage.Demo;
				}
			}

			fii.CloseAssignedPackages();
			DownloadsToolFactory.TeleportFileIndex.RemoveChild(fii);

			this.DisposeTmpPkg();
			Wait.SubStop();
		}

		Interfaces.Files.IPackageFile tmppkg;

		protected virtual bool BeforeLoadContent(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg
		)
		{
			bool ret = false;
			DisposeTmpPkg();

			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.MetaData.MMAT
			);
			if (pfds.Length > 0)
			{
				MmatWrapper mmat = new MmatWrapper();
				mmat.ProcessData(pfds[0], pkg);
				nfo.Name = mmat.ModelName + ", " + mmat.SubsetName;

				if (DownloadsToolFactory.Settings.LoadBasedataForRecolors)
				{
					Interfaces.Scenegraph.IScenegraphFileIndex fii =
						DownloadsToolFactory.TeleportFileIndex.AddNewChild();
					if (System.IO.File.Exists(pkg.SaveFileName))
					{
						string dir = System.IO.Path.GetDirectoryName(pkg.SaveFileName);
						string[] files = System.IO.Directory.GetFiles(dir);
						foreach (string file in files)
						{
							if (file.EndsWith(".package") || file.EndsWith(".sims"))
							{
								if (!FileTableBase.FileIndex.Contains(file))
								{
									fii.AddIndexFromPackage(file);
								}
							}
						}
					}
					if (
						System.IO.File.Exists(
							System.IO.Path.Combine(
								Helper.SimPePluginPath,
								"simpe.workshop.plugin.dll"
							)
						)
					)
					{
						//SimPe.Plugin.DownloadsToolFactory.TeleportFileIndex.WriteContentToConsole();
						tmppkg =
							Tool.Dockable.ObjectWorkshopHelper.CreatCloneByGuid(
								mmat.ObjectGUID
							); // depends on simpe.workshop.plugin.dll, pity as that may not exist
						if (


								DownloadsToolFactory
								.Settings
								.BuildPreviewForRecolors
						)
						{
							if (tmppkg.Index.Length > 0)
							{
								ret = true;
							}

							tmppkg.CopyDescriptors(pkg);
							foreach (
								Interfaces.Files.IPackedFileDescriptor pfd in tmppkg.Index
							)
							{
								if (pfd.Equals(mmat.FileDescriptor))
								{
									mmat.ProcessData(pfd, tmppkg);
								}
							}

							string name = "render.tmp";
							int index = 0;

							string rname = null;
							do
							{
								rname = System.IO.Path.Combine(
									Helper.SimPeTeleportPath,
									index + "_" + name
								);
								index++;
							} while (System.IO.File.Exists(rname));
							tmppkg.Save(rname);

							nfo.RenderData = new object[] { mmat, tmppkg.SaveFileName };
							nfo.PostponedRenderer = new EventHandler(PostponedRender);
						}
					}

					fii.CloseAssignedPackages();
					DownloadsToolFactory.TeleportFileIndex.RemoveChild(
						fii
					);
				}
			}

			return ret;
		}

		protected virtual void AfterLoadContent(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg
		)
		{
			DisposeTmpPkg();
		}

		void DisposeTmpPkg()
		{
			if (tmppkg != null)
			{
				tmppkg.Close();
				Packages.StreamFactory.CloseStream(tmppkg.SaveFileName);
				if (tmppkg is Packages.GeneratableFile)
				{
					((Packages.GeneratableFile)tmppkg).Dispose();
				}
			}
			tmppkg = null;
		}

		#region ITypeHandler Member



		public void LoadContent(
			Cache.PackageType type,
			Interfaces.Files.IPackageFile pkg
		)
		{
			nfo = new PackageInfo(pkg);
			bool hasprev = BeforeLoadContent(type, pkg);

			if (tmppkg != null)
			{
				XTypeHandler hnd = new XTypeHandler(
					Cache.PackageType.CustomObject,
					tmppkg,
					false,
					false
				);
				if (hnd.Objects.Length > 0)
				{
					PackageInfo snfo = hnd.Objects[0] as PackageInfo;
					if (snfo != null)
					{
						if (snfo.Name.Trim() == "")
						{
							snfo.Name = nfo.Name;
						}

						snfo.Image = nfo.Image;
						snfo.RenderedImage = nfo.RenderedImage;
						snfo.RenderData = nfo.RenderData;
						snfo.PostponedRenderer = nfo.PostponedRenderer;
						nfo.Dispose();
						nfo = snfo;
						nfo.ClearGuidList();
					}
				}
				hnd.Dispose();
			}

			if (!hasprev)
			{
				nfo.Image = WallpaperTypeHandler.SetFromTxtr(pkg);
				nfo.KnockoutThumbnail = false;
			}

			AfterLoadContent(type, pkg);
		}

		public IPackageInfo[] Objects => new IPackageInfo[] { nfo };

		#endregion

		public virtual void Dispose()
		{
			nfo = null;
			DisposeTmpPkg();
		}
	}
}
