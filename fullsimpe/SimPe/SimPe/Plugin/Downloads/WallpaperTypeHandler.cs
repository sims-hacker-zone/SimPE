// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System.Linq;

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for WallpaperTypeHandler.
	/// </summary>
	public class WallpaperTypeHandler : LotTypeHandler
	{
		public WallpaperTypeHandler()
			: base() { }

		internal static System.Drawing.Image SetFromTxtr(
			Interfaces.Files.IPackageFile pkg
		)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.FileTypes.TXTR
			);
			if (pfds.Length > 0)
			{
				Interfaces.Files.IPackedFileDescriptor pfd = pfds[0];
				foreach (Interfaces.Files.IPackedFileDescriptor p in pfds)
				{
					if (p.Size > pfd.Size)
					{
						pfd = p;
					}
				}

				Rcol rcol = new GenericRcol();
				rcol.ProcessData(pfd, pkg);

				if (rcol.Blocks.FirstOrDefault() is ImageData id)
				{
					MipMap m = id.GetLargestTexture(
						new System.Drawing.Size(
							PackageInfo.IMAGESIZE,
							PackageInfo.IMAGESIZE
						)
					);
					if (m != null)
					{
						return m.Texture;
					}
				}
			}

			return null;
		}

		protected override void SetImage(Interfaces.Files.IPackageFile pkg)
		{
			nfo.Image = SetFromTxtr(pkg);
			nfo.KnockoutThumbnail = false;
		}
	}
}
