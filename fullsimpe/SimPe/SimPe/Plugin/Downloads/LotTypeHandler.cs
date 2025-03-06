// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.PackedFiles.Picture;

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for LotTypeHandler.
	/// </summary>
	public class LotTypeHandler : SimpleTypeHandler
	{
		public LotTypeHandler()
			: base() { }

		protected override void SetName(Interfaces.Files.IPackageFile pkg)
		{
			SetName(Data.FileTypes.STR, pkg);
		}

		protected override void SetImage(Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
				FileTypes.IMG,
				0,
				Data.MetaData.LOCAL_GROUP,
				0x35CA0002
			);
			if (pfd == null)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
					FileTypes.IMG
				);
				if (pfds.Length > 0)
				{
					pfd = pfds[0];
				}
			}

			if (pfd != null)
			{
				Picture pic = new Picture();
				pic.ProcessData(pfd, pkg);
				nfo.Image = pic.Image;
			}

			nfo.KnockoutThumbnail = false;
		}
	}
}
