// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Plugin;

namespace SimPe.Cache
{
	/// <summary>
	/// Contains an Instance of a CacheFile
	/// </summary>
	internal class PackageCacheFile : CacheFile
	{
		public static string CacheFileName => Helper.GetSimPeLanguageCache("scanner_");

		/// <summary>
		/// Creaet a new Instance for an empty File
		/// </summary>
		public PackageCacheFile()
			: base()
		{
			DEFAULT_TYPE = ContainerType.Package;
		}

		/// <summary>
		/// Load/Add a Cache Item for the passed File
		/// </summary>
		/// <param name="filename">The Name of the File</param>
		public ScannerItem LoadItem(string filename)
		{
			CacheContainer mycc = UseConatiner(ContainerType.Package, filename);

			if (mycc.Items.Count == 0)
			{
				PackageCacheItem pci = new PackageCacheItem();
				ScannerItem item = new ScannerItem(pci, mycc)
				{
					FileName = filename
				};
				pci.Name = System.IO.Path.GetFileNameWithoutExtension(filename);
				mycc.Items.Add(pci);

				return item;
			}
			else
			{
				ScannerItem item = new ScannerItem(
					(PackageCacheItem)mycc.Items[0],
					mycc
				)
				{
					FileName = filename
				};

				return item;
			}
		}

		Hashtable map;

		/// <summary>
		/// Return the FileIndex represented by the Cached Files
		/// </summary>
		public Hashtable Map
		{
			get
			{
				if (map == null)
				{
					LoadFiles();
				}

				return map;
			}
		}

		/// <summary>
		/// Creates the Map
		/// </summary>
		/// <returns>the FileIndex</returns>
		/// <remarks>
		/// The Tags of the FileDescriptions contain the MMATCachItem Object,
		/// the FileNames of the FileDescriptions contain the Name of the package File
		/// </remarks>
		public void LoadFiles()
		{
			map = new Hashtable();

			foreach (CacheContainer cc in Containers)
			{
				if (cc.Type == ContainerType.Package && cc.Valid)
				{
					foreach (PackageCacheItem item in cc.Items)
					{
						ScannerItem si = new ScannerItem(item, cc)
						{
							FileName = cc.FileName
						};
						map[si.FileName.Trim().ToLower()] = item;
					}
				}
			} //foreach
		}
	}
}
