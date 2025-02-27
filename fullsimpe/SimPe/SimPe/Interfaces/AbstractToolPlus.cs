/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
namespace SimPe.Interfaces
{
	/// <summary>
	/// Abstract Implementation for <see cref="IToolExt"/> classes
	/// </summary>
	public abstract class AbstractToolPlus : AbstractTool, IToolPlus
	{
		#region ITool Member

		public abstract Plugin.IToolResult ShowDialog(
			ref Files.IPackedFileDescriptor pfd,
			ref Files.IPackageFile package
		);
		public abstract bool IsEnabled(
			Files.IPackedFileDescriptor pfd,
			Files.IPackageFile package
		);

		#endregion

		public static Files.IPackedFileDescriptor ExtractFileDescriptor(
			Events.ResourceEventArgs e
		)
		{
			if (e == null)
			{
				return null;
			}

			Files.IPackedFileDescriptor pfd = null;
			if (e.Count > 0)
			{
				if (e[0].HasFileDescriptor)
				{
					pfd = e[0].Resource.FileDescriptor;
				}
			}

			return pfd;
		}

		public static Files.IPackageFile ExtractPackage(
			Events.ResourceEventArgs e
		)
		{
			if (e == null)
			{
				return null;
			}

			Files.IPackageFile pkg = null;
			if (e.Count > 0)
			{
				if (e[0].HasPackage)
				{
					pkg = e[0].Resource.Package;
				}
			}

			if (pkg == null && e.Loaded)
			{
				pkg = e.LoadedPackage.Package;
			}

			return pkg;
		}

		#region IToolPlus Member

		public virtual void Execute(object sender, Events.ResourceEventArgs e)
		{
			Files.IPackedFileDescriptor pfd = ExtractFileDescriptor(e);
			Files.IPackageFile pkg = ExtractPackage(e);

			if (!IsEnabled(pfd, pkg))
			{
				return;
			}

			Plugin.IToolResult ires = ShowDialog(ref pfd, ref pkg);

			if (e.Count > 0)
			{
				e[0].ChangedFile = ires.ChangedFile;
				e[0].ChangedPackage = ires.ChangedPackage;
			}
		}

		public virtual bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			Files.IPackedFileDescriptor pfd = ExtractFileDescriptor(e);
			Files.IPackageFile pkg = ExtractPackage(e);

			return IsEnabled(pfd, pkg);
		}

		#endregion
	}
}
