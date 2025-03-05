// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimPe.Packages
{
	/// <summary>
	/// Maintains a List of all opened Packages
	/// </summary>
	public class PackageMaintainer
	{
		static PackageMaintainer me;

		/// <summary>
		/// Returns the active package maintainer
		/// </summary>
		public static PackageMaintainer Maintainer
		{
			get
			{
				if (me == null)
				{
					me = new PackageMaintainer();
				}

				return me;
			}
		}

		private readonly Dictionary<string, GeneratableFile> ht = new Dictionary<string, GeneratableFile>(StringComparer.InvariantCultureIgnoreCase);

		/// <summary>
		/// Set or Get the FileIndex used to hold loaded Packages
		/// </summary>
		public Interfaces.Scenegraph.IScenegraphFileIndex FileIndex
		{
			get;
			set;
		}

		/// <summary>
		/// Create a new instance
		/// </summary>
		internal PackageMaintainer()
		{
		}

		/// <summary>
		/// Remove a given Package from the Maintainer
		/// </summary>
		/// <param name="pkg"></param>
		internal void RemovePackage(GeneratableFile pkg)
		{
			if (!Helper.WindowsRegistry.UsePackageMaintainer)
			{
				return;
			}

			if (pkg == null)
			{
				return;
			}

			RemovePackage(pkg.FileName);
		}

		/// <summary>
		/// Remove a given Package from the Maintainer
		/// </summary>
		/// <param name="pkg"></param>
		public void RemovePackagesInPath(string folder)
		{
			if (folder == null)
			{
				return;
			}
			folder = folder.Trim().ToLower();
			foreach (string k in from key in ht.Keys where key.Trim().ToLower().StartsWith(folder) select key)
			{
				RemovePackage(k);
			}
		}

		/// <summary>
		/// Remove a given Package from the Maintainer
		/// </summary>
		/// <param name="pkg"></param>
		internal void RemovePackage(string flname)
		{
			if (flname == null)
			{
				return;
			}

			if (ht.ContainsKey(flname))
			{
				FileTableBase.FileIndex.ClosePackage(ht[flname]);
				//((GeneratableFile)ht[filename]).Close(true);
				ht.Remove(flname);
			}
		}

		internal void SyncFileIndex(GeneratableFile pkg)
		{
			FileIndex.Clear();
			if (pkg.Index.Length <= Helper.WindowsRegistry.BigPackageResourceCount)
			{
				FileIndex.AddIndexFromPackage(pkg);
			}
		}

		/// <summary>
		/// Checks if the package on the passed Filename is already maintained here
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public bool Contains(string filename)
		{
			return ht.ContainsKey(filename);
		}

		/// <summary>
		/// Load a Package File from the Maintainer
		/// </summary>
		/// <param name="filename">the name of the package</param>
		/// <param name="sync">true, if the package should be synchronized with the Filesystem befor it is returned</param>
		/// <returns>an instance of <see cref="GeneratableFile"/> for the given Filename</returns>
		/// <remarks>
		/// If the package was loaded once in this session, this Method will return an instance to the
		/// last loaded Version. Otherwise it wil create a new instance
		/// </remarks>
		public GeneratableFile LoadPackageFromFile(string filename, bool sync)
		{
			GeneratableFile ret;
			if (filename == null)
			{
				ret = File.CreateNew();
			}
			else
			{
				if (!Helper.WindowsRegistry.UsePackageMaintainer)
				{
					ret = new GeneratableFile(filename);
				}
				else
				{
					if (!ht.ContainsKey(filename))
					{
						ht[filename] = new GeneratableFile(filename);
					}
					else if (sync)
					{
						FileTableBase.FileIndex.ClosePackage(
							ht[filename]
						);
						//((GeneratableFile)ht[filename]).Close(true);
						ht[filename].ReloadFromFile(filename);
					}
					ret = ht[filename];
				}
			}

			if (sync)
			{
				SyncFileIndex(ret);
			}

			return ret;
		}
	}
}
