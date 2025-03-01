// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Plugin;

namespace SimPe.Cache
{
	/// <summary>
	/// Contains an Instance of a CacheFile
	/// </summary>
	public class MMATCacheFile : CacheFile
	{
		/// <summary>
		/// Creaet a new Instance for an empty File
		/// </summary>
		public MMATCacheFile()
			: base()
		{
			DEFAULT_TYPE = ContainerType.MaterialOverride;
		}

		/// <summary>
		/// Add a MaterialOverride to the Cache
		/// </summary>
		/// <param name="mmat">The Material Override to add</param>
		public void AddItem(MmatWrapper mmat)
		{
			CacheContainer mycc = UseConatiner(
				ContainerType.MaterialOverride,
				mmat.Package.FileName
			);

			MMATCacheItem mci = new MMATCacheItem
			{
				Default = mmat.DefaultMaterial,
				ModelName = mmat.ModelName.Trim().ToLower(),
				Family = mmat.Family.Trim().ToLower(),
				FileDescriptor = mmat.FileDescriptor
			};

			mycc.Items.Add(mci);
		}

		FileIndex fi;

		/// <summary>
		/// Return the FileIndex represented by the Cached Files
		/// </summary>
		public FileIndex FileIndex
		{
			get
			{
				if (fi == null)
				{
					LoadOverrides();
				}

				return fi;
			}
		}

		/// <summary>
		/// Creates a FileIndex with all available MMAT Files
		/// </summary>
		/// <returns>the FileIndex</returns>
		/// <remarks>
		/// The Tags of the FileDescriptions contain the MMATCachItem Object,
		/// the FileNames of the FileDescriptions contain the Name of the package File
		/// </remarks>
		public void LoadOverrides()
		{
			fi = new FileIndex(new ArrayList())
			{
				Duplicates = true
			};

			foreach (CacheContainer cc in Containers)
			{
				if (cc.Type == ContainerType.MaterialOverride && cc.Valid)
				{
					foreach (MMATCacheItem mci in cc.Items)
					{
						Interfaces.Files.IPackedFileDescriptor pfd = mci.FileDescriptor;
						pfd.Filename = cc.FileName;
						fi.AddIndexFromPfd(
							pfd,
							null,
							FileIndex.GetLocalGroup(pfd.Filename)
						);
					}
				}
			} //foreach
		}

		Hashtable defaultmap;
		Hashtable modelmap;

		/// <summary>
		/// Returns all known MMAT Files sorted by the Default State
		/// </summary>
		public Hashtable DefaultMap
		{
			get
			{
				if (defaultmap == null)
				{
					LoadOverrideMaps();
				}

				return defaultmap;
			}
		}

		/// <summary>
		/// Returns all known MMAT Files sorted by the ModelName
		/// </summary>
		public Hashtable ModelMap
		{
			get
			{
				if (modelmap == null)
				{
					LoadOverrideMaps();
				}

				return modelmap;
			}
		}

		/// <summary>
		/// Load the Map Files
		/// </summary>
		public void LoadOverrideMaps()
		{
			defaultmap = new Hashtable();
			modelmap = new Hashtable();

			defaultmap[true] = new CacheItems();
			defaultmap[false] = new CacheItems();
			foreach (CacheContainer cc in Containers)
			{
				if (cc.Type == ContainerType.MaterialOverride && cc.Valid)
				{
					foreach (MMATCacheItem mci in cc.Items)
					{
						CacheItems l = (CacheItems)defaultmap[mci.Default];
						l.Add(mci);

						l = (CacheItems)modelmap[mci.ModelName];
						if (l == null)
						{
							l = new CacheItems();
							modelmap[mci.ModelName] = l;
						}
						l.Add(mci);
					}
				}
			} //foreach
		}
	}
}
