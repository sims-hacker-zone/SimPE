// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;

using SimPe.Plugin;

namespace SimPe.Cache
{
	/// <summary>
	/// Contains an Instance of a CacheFile
	/// </summary>
	public class ObjectLoaderCacheFile : CacheFile
	{
		/// <summary>
		/// Creaet a new Instance for an empty File
		/// </summary>
		public ObjectLoaderCacheFile()
			: base()
		{
			DEFAULT_TYPE = ContainerType.Object;
		}

		/// <summary>
		/// Add a Object Item to the Cache
		/// </summary>
		/// <param name="oci">The Cache Item</param>
		/// <param name="filename">name of the package File where the Object was in</param>
		public void AddItem(ObjectCacheItem oci, string filename)
		{
			CacheContainer mycc = UseConatiner(ContainerType.Object, filename);
			mycc.Items.Add(oci);
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
					LoadObjects();
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
		public void LoadObjects()
		{
			fi = new FileIndex(new ArrayList())
			{
				Duplicates = true
			};

			foreach (CacheContainer cc in Containers)
			{
				if (cc.Type == ContainerType.Object && cc.Valid)
				{
					foreach (ObjectCacheItem mci in cc.Items)
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
	}
}
