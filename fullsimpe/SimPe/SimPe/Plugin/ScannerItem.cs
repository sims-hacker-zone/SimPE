// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
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
			get => filename;
			set
			{
				if (filename.Trim().ToLower() != value.Trim().ToLower())
				{
					pkg = null;
				}

				filename = value;
			}
		}

		public CacheContainer ParentContainer
		{
			get;
		}

		Packages.GeneratableFile pkg = null;

		/// <summary>
		/// Returns the Package Instance fo the given FileNmae
		/// </summary>
		public Packages.GeneratableFile Package
		{
			get
			{
				if (pkg == null)
				{
					pkg = Packages.File.LoadFromFile(FileName);
				}

				return pkg;
			}
			set => pkg = value;
		}

		public ScannerItem(PackageCacheItem pci, CacheContainer cc)
		{
			PackageCacheItem = pci;
			ParentContainer = cc;
			filename = "";
		}

		public System.Windows.Forms.ListViewItem ListViewItem
		{
			get; set;
		}
	}
}
