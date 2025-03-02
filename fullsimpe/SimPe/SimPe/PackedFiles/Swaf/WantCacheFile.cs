// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections.Generic;

using SimPe.Cache;

namespace SimPe.PackedFiles.Swaf
{
	/// <summary>
	/// Contains an Instance of a CacheFile
	/// </summary>
	public class WantCacheFile : CacheFile
	{
		/// <summary>
		/// Creaet a new Instance for an empty File
		/// </summary>
		public WantCacheFile()
			: base()
		{
			DEFAULT_TYPE = ContainerType.Want;
		}

		/// <summary>
		/// Add a Want Item to the Cache
		/// </summary>
		/// <param name="want">The Want File</param>
		public void AddItem(WantInformation want)
		{
			CacheContainer mycc = UseConatiner(
				ContainerType.Want,
				want.XWant.Package.FileName
			);

			mycc.Items.Add(new WantCacheItem
			{
				FileDescriptor = want.XWant.FileDescriptor,
				Folder = want.XWant.Folder,
				Guid = want.Guid,
				Icon = want.Icon,
				Influence = want.XWant.Influence,
				Name = want.Name,
				ObjectType = want.XWant.ObjectType,
				Score = want.XWant.Score
			});
		}

		private Dictionary<uint, WantCacheItem> map;

		/// <summary>
		/// Return the FileIndex represented by the Cached Files
		/// </summary>
		public Dictionary<uint, WantCacheItem> Map
		{
			get
			{
				if (map == null)
				{
					LoadWants();
				}

				return map;
			}
		}

		public void LoadWants()
		{
			map = new Dictionary<uint, WantCacheItem>();

			foreach (CacheContainer cc in Containers)
			{
				if (cc.Type == ContainerType.Want && cc.Valid)
				{
					foreach (WantCacheItem wci in cc.Items)
					{
						map[wci.Guid] = wci;
					}
				}
			}
		}
	}
}
