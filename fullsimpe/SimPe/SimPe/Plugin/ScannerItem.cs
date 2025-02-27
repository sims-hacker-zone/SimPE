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
using SimPe.Cache;

namespace SimPe.Plugin
{
	/// <summary>
	/// An Instance of this class represents one scanned Package
	/// </summary>
	public class ScannerItem
	{
		public PackageCacheItem PackageCacheItem
		{
			get;
		}

		string filename;

		/// <summary>
		/// The FileName of the Package File
		/// </summary>
		public string FileName
		{
			get
			{
				return filename;
			}
			set
			{
				if (filename.Trim().ToLower() != value.Trim().ToLower())
				{
					pkg = null;
				}

				filename = value;
			}
		}

		public SimPe.Cache.CacheContainer ParentContainer
		{
			get;
		}

		SimPe.Packages.GeneratableFile pkg = null;

		/// <summary>
		/// Returns the Package Instance fo the given FileNmae
		/// </summary>
		public SimPe.Packages.GeneratableFile Package
		{
			get
			{
				if (pkg == null)
				{
					pkg = SimPe.Packages.GeneratableFile.LoadFromFile(FileName);
				}

				return pkg;
			}
			set
			{
				pkg = value;
			}
		}

		public ScannerItem(PackageCacheItem pci, SimPe.Cache.CacheContainer cc)
		{
			this.PackageCacheItem = pci;
			this.ParentContainer = cc;
			filename = "";
		}

		public System.Windows.Forms.ListViewItem ListViewItem
		{
			get; set;
		}
	}
}
