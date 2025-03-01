// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

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
			SetName(Data.MetaData.STRING_FILE, pkg);
		}

		protected override void SetImage(Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor pfd = pkg.FindFile(
				0x856DDBAC,
				0,
				Data.MetaData.LOCAL_GROUP,
				0x35CA0002
			);
			if (pfd == null)
			{
				Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
					0x856DDBAC
				);
				if (pfds.Length > 0)
				{
					pfd = pfds[0];
				}
			}

			if (pfd != null)
			{
				PackedFiles.Wrapper.Picture pic =
					new PackedFiles.Wrapper.Picture();
				pic.ProcessData(pfd, pkg);
				nfo.Image = pic.Image;
			}

			nfo.KnockoutThumbnail = false;
		}
	}
}
