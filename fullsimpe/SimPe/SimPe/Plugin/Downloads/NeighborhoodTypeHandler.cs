// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.Data;
using SimPe.PackedFiles.Str;

namespace SimPe.Plugin.Downloads
{
	/// <summary>
	/// Summary description for SimTypeHandler.
	/// </summary>
	public class NeighborhoodTypeHandler : SimpleTypeHandler
	{
		public NeighborhoodTypeHandler()
		{
		}

		protected override void SetName(Interfaces.Files.IPackageFile pkg)
		{
			Interfaces.Files.IPackedFileDescriptor[] pfds = pkg.FindFiles(
				Data.FileTypes.CTSS
			);

			if (pfds.Length > 0)
			{
				StrItemList items =
					DefaultTypeHandler.GetCtssItems(pfds[0], pkg);
				if (items.Length > 0)
				{
					nfo.Name = items[0].Title;
				}

				if (items.Length > 1)
				{
					nfo.Description = items[1].Title;
				}
			}
		}

		protected override void SetImage(Interfaces.Files.IPackageFile pkg)
		{
			SetImage(FileTypes.IMG, pkg);
			nfo.KnockoutThumbnail = true;
		}
	}
}
