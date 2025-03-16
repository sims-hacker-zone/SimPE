// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Mmat;

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
			PackageInfo nfo = sender as PackageInfo;
			object[] data = nfo.RenderData as object[];
			tmppkg = Packages.File.LoadFromFile(data[1].ToString());
			if (tmppkg == null)
			{
				return;
			}

			// Interfaces.Scenegraph.IScenegraphFileIndex fii =
			// 	DownloadsToolFactory.TeleportFileIndex.AddNewChild();
			MmatWrapper mmat = data[0] as MmatWrapper;

			mmat.ProcessData(mmat.FileDescriptor, tmppkg);
			if (mmat != null)
			{
				nfo.RenderedImage = GetImage.Demo;
			}

			// DownloadsToolFactory.TeleportFileIndex.RemoveChild(fii);

			DisposeTmpPkg();
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
				Data.FileTypes.MMAT
			);
			if (pfds.Length > 0)
			{
				MmatWrapper mmat = new MmatWrapper().ProcessFile(pfds[0], pkg);
				nfo.Name = mmat.ModelName + ", " + mmat.SubsetName;
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
					if (hnd.Objects[0] is PackageInfo snfo)
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
